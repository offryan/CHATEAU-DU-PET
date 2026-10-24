using System.Net.Mail;
using System.Text.RegularExpressions;
using ChateauDuPet.DAL;
using ChateauDuPet.DTO;

namespace ChateauDuPet.BLL;

public record Resultado(bool Sucesso, string? Erro = null, int Id = 0)
{
    public static Resultado Ok(int id = 0) => new(true, Id: id);
    public static Resultado Falha(string erro) => new(false, erro);
}

public class CadastroBLL(EmpresaDAL empresas, ProfissionalDAL profissionais)
{
    public static string SoDigitos(string? valor) => Regex.Replace(valor ?? "", @"\D", "");

    public async Task<Resultado> CadastrarEmpresaAsync(EmpresaDTO e, string senha)
    {
        e.NroCPF = SoDigitos(e.NroCPF);
        e.NroTelefone = SoDigitos(e.NroTelefone);
        if (ValidarComum(e.NmRecrutador, e.DsEmail, e.DsUser, e.NroCPF, e.NroTelefone, 12, senha, e.DtNascimento) is { } erro)
            return Resultado.Falha(erro);

        if (await empresas.CampoDuplicadoAsync(e.DsEmail, e.DsUser, e.NroCPF) is { } campo)
            return Resultado.Falha($"Já existe uma empresa cadastrada com esse {campo}.");

        e.SenhaEmpresa = AutenticacaoBLL.GerarHash(senha);
        return Resultado.Ok(await empresas.InserirAsync(e));
    }

    public async Task<Resultado> CadastrarProfissionalAsync(ProfissionalDTO p, string senha)
    {
        p.NroCPF = SoDigitos(p.NroCPF);
        p.NroTelefone = SoDigitos(p.NroTelefone);
        if (ValidarComum(p.NmProfissional, p.DsEmail, p.DsUser, p.NroCPF, p.NroTelefone, 11, senha, p.DtNascimento) is { } erro)
            return Resultado.Falha(erro);

        if (await profissionais.CampoDuplicadoAsync(p.DsEmail, p.DsUser, p.NroCPF) is { } campo)
            return Resultado.Falha($"Já existe um profissional cadastrado com esse {campo}.");

        p.SenhaProfissional = AutenticacaoBLL.GerarHash(senha);
        return Resultado.Ok(await profissionais.InserirAsync(p));
    }

    private static string? ValidarComum(string nome, string email, string usuario, string cpf, string telefone,
                                        int maxTelefone, string senha, DateTime nascimento)
    {
        if (string.IsNullOrWhiteSpace(nome)) return "Informe o nome.";
        if (!MailAddress.TryCreate(email, out _)) return "Informe um e-mail válido.";
        if (!Regex.IsMatch(usuario ?? "", "^[a-zA-Z0-9._]{3,50}$"))
            return "O usuário deve ter de 3 a 50 caracteres: letras, números, ponto ou sublinhado.";
        if (cpf.Length != 11) return "O CPF deve ter 11 dígitos.";
        if (telefone.Length < 10 || telefone.Length > maxTelefone) return "Informe um telefone com DDD.";
        if (senha.Length < 8) return "A senha deve ter pelo menos 8 caracteres.";
        var idade = DateTime.Today.Year - nascimento.Year - (DateTime.Today.DayOfYear < nascimento.DayOfYear ? 1 : 0);
        if (idade < 16 || idade > 110) return "Informe uma data de nascimento válida.";
        return null;
    }
}
