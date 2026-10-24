using ChateauDuPet.DAL;
using ChateauDuPet.DTO;

namespace ChateauDuPet.BLL;

public class AutenticacaoBLL(AdministrativoDAL admins, EmpresaDAL empresas, ProfissionalDAL profissionais)
{
    public static string GerarHash(string senha) => BCrypt.Net.BCrypt.HashPassword(senha, workFactor: 11);

    private static bool Confere(string senha, string hash) => BCrypt.Net.BCrypt.Verify(senha, hash);

    /// <summary>
    /// Procura o e-mail nos três tipos de usuário. Retorna null se o e-mail não existir
    /// ou a senha não conferir, sem revelar qual dos dois falhou.
    /// </summary>
    public async Task<UsuarioLogado?> EntrarAsync(string email, string senha)
    {
        email = email.Trim();
        if (email.Length == 0 || senha.Length == 0) return null;

        var adm = await admins.ObterPorEmailAsync(email);
        if (adm is not null)
            return Confere(senha, adm.SenhaADM)
                ? new UsuarioLogado(adm.IdAdministrativo, adm.NmADM, adm.DsEmail, TipoUsuario.Administrativo)
                : null;

        var empresa = await empresas.ObterPorEmailAsync(email);
        if (empresa is not null)
            return Confere(senha, empresa.SenhaEmpresa)
                ? new UsuarioLogado(empresa.IdEmpresa, empresa.NomeExibicao, empresa.DsEmail, TipoUsuario.Empresa)
                : null;

        var pro = await profissionais.ObterPorEmailAsync(email);
        if (pro is not null)
            return Confere(senha, pro.SenhaProfissional)
                ? new UsuarioLogado(pro.IdProfissional, pro.NmProfissional, pro.DsEmail, TipoUsuario.Profissional)
                : null;

        return null;
    }
}
