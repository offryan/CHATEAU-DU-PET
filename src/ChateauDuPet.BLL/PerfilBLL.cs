using ChateauDuPet.DAL;
using ChateauDuPet.DTO;

namespace ChateauDuPet.BLL;

public class PerfilBLL(ProfissionalDAL profissionais, EmpresaDAL empresas, ExperienciaDAL experiencias, CertificadoDAL certificados)
{
    public Task<ProfissionalDTO?> ObterProfissionalAsync(int id) => profissionais.ObterPorIdAsync(id);
    public Task<EmpresaDTO?> ObterEmpresaAsync(int id) => empresas.ObterPorIdAsync(id);
    public Task<List<ProfissionalDTO>> ListarProfissionaisAsync() => profissionais.ListarAsync();
    public Task<List<EmpresaDTO>> ListarEmpresasAsync() => empresas.ListarAsync();
    public Task<List<ExperienciaDTO>> ExperienciasAsync(int idProfissional) => experiencias.ListarPorProfissionalAsync(idProfissional);
    public Task<List<CertificadoDTO>> CertificadosAsync(int idProfissional) => certificados.ListarPorProfissionalAsync(idProfissional);

    public async Task<Resultado> AtualizarProfissionalAsync(ProfissionalDTO p)
    {
        if (string.IsNullOrWhiteSpace(p.NmProfissional)) return Resultado.Falha("Informe o nome.");
        p.NroTelefone = CadastroBLL.SoDigitos(p.NroTelefone);
        p.DsCEP = CadastroBLL.SoDigitos(p.DsCEP);
        await profissionais.AtualizarPerfilAsync(p);
        return Resultado.Ok(p.IdProfissional);
    }

    public async Task<Resultado> AtualizarEmpresaAsync(EmpresaDTO e)
    {
        if (string.IsNullOrWhiteSpace(e.NmRecrutador)) return Resultado.Falha("Informe o nome do recrutador.");
        e.NroTelefone = CadastroBLL.SoDigitos(e.NroTelefone);
        e.DsCep = CadastroBLL.SoDigitos(e.DsCep);
        await empresas.AtualizarPerfilAsync(e);
        return Resultado.Ok(e.IdEmpresa);
    }

    public async Task<Resultado> AdicionarExperienciaAsync(ExperienciaDTO e, int idProfissional)
    {
        if (string.IsNullOrWhiteSpace(e.DsCargo) || string.IsNullOrWhiteSpace(e.DsEmpresa))
            return Resultado.Falha("Informe o cargo e a empresa.");
        if (e.DataFinal is { } fim && fim < e.DataInicio)
            return Resultado.Falha("A data final não pode ser antes da data de início.");
        e.FKProfissional = idProfissional;
        await experiencias.InserirAsync(e);
        return Resultado.Ok();
    }

    public async Task<Resultado> AdicionarCertificadoAsync(CertificadoDTO c, int idProfissional)
    {
        if (string.IsNullOrWhiteSpace(c.DsCurso) || string.IsNullOrWhiteSpace(c.DsInstituicao))
            return Resultado.Falha("Informe o curso e a instituição.");
        if (c.DataConclusao is { } fim && fim < c.DataInicio)
            return Resultado.Falha("A conclusão não pode ser antes do início.");
        c.FKProfissional = idProfissional;
        await certificados.InserirAsync(c);
        return Resultado.Ok();
    }

    public Task<bool> ExcluirExperienciaAsync(int id, int idProfissional) => experiencias.ExcluirAsync(id, idProfissional);
    public Task<bool> ExcluirCertificadoAsync(int id, int idProfissional) => certificados.ExcluirAsync(id, idProfissional);

    // Exclusões feitas pelo administrador
    public Task ExcluirProfissionalAsync(int id) => profissionais.ExcluirAsync(id);
    public Task ExcluirEmpresaAsync(int id) => empresas.ExcluirAsync(id);
}
