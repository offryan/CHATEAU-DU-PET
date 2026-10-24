using ChateauDuPet.DAL;
using ChateauDuPet.DTO;

namespace ChateauDuPet.BLL;

public class VagaBLL(VagaDAL vagas, CandidaturaDAL candidaturas)
{
    public Task<List<VagaDTO>> ListarAsync(string? busca = null) => vagas.ListarAsync(busca);
    public Task<List<VagaDTO>> ListarDaEmpresaAsync(int idEmpresa) => vagas.ListarPorEmpresaAsync(idEmpresa);
    public Task<VagaDTO?> ObterAsync(int idVaga) => vagas.ObterPorIdAsync(idVaga);

    public async Task<Resultado> PublicarAsync(VagaDTO v, int idEmpresa)
    {
        if (Validar(v) is { } erro) return Resultado.Falha(erro);
        v.FKEmpresa = idEmpresa;
        return Resultado.Ok(await vagas.InserirAsync(v));
    }

    public async Task<Resultado> EditarAsync(VagaDTO v, int idEmpresa)
    {
        if (Validar(v) is { } erro) return Resultado.Falha(erro);
        v.FKEmpresa = idEmpresa;
        return await vagas.AtualizarAsync(v) ? Resultado.Ok(v.IdVaga) : Resultado.Falha("Vaga não encontrada.");
    }

    public async Task<Resultado> ExcluirAsync(int idVaga, UsuarioLogado usuario)
    {
        int? dona = usuario.Tipo switch
        {
            TipoUsuario.Administrativo => null,
            TipoUsuario.Empresa => usuario.Id,
            _ => -1 // profissional não exclui vagas
        };
        return await vagas.ExcluirAsync(idVaga, dona) ? Resultado.Ok() : Resultado.Falha("Vaga não encontrada.");
    }

    public async Task<Resultado> CandidatarAsync(int idProfissional, int idVaga)
    {
        if (await vagas.ObterPorIdAsync(idVaga) is null) return Resultado.Falha("Vaga não encontrada.");
        return await candidaturas.CandidatarAsync(idProfissional, idVaga)
            ? Resultado.Ok()
            : Resultado.Falha("Você já se candidatou a esta vaga.");
    }

    public Task<bool> CancelarCandidaturaAsync(int idProfissional, int idVaga) => candidaturas.CancelarAsync(idProfissional, idVaga);
    public Task<bool> JaCandidatadoAsync(int idProfissional, int idVaga) => candidaturas.JaCandidatadoAsync(idProfissional, idVaga);
    public Task<List<CandidaturaDTO>> CandidaturasDoProfissionalAsync(int idProfissional) => candidaturas.ListarPorProfissionalAsync(idProfissional);

    /// <summary>Empresa só vê candidatos das próprias vagas; administrador vê de todas.</summary>
    public Task<List<CandidaturaDTO>> CandidatosDaVagaAsync(int idVaga, UsuarioLogado usuario) =>
        candidaturas.ListarPorVagaAsync(idVaga, usuario.Tipo == TipoUsuario.Administrativo ? null : usuario.Id);

    private static string? Validar(VagaDTO v)
    {
        if (string.IsNullOrWhiteSpace(v.NmVaga)) return "Informe o nome da vaga.";
        if (string.IsNullOrWhiteSpace(v.DsDescricao)) return "Descreva a vaga.";
        return null;
    }
}
