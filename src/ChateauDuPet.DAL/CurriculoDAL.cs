using ChateauDuPet.DTO;
using Dapper;
using Npgsql;

namespace ChateauDuPet.DAL;

// Experiências e certificados sempre filtram pelo profissional dono do registro,
// para um usuário não conseguir alterar o currículo de outro trocando o id na URL.

public class ExperienciaDAL(NpgsqlDataSource ds) : Conexao(ds)
{
    public async Task<List<ExperienciaDTO>> ListarPorProfissionalAsync(int idProfissional)
    {
        await using var conn = await AbrirAsync();
        return (await conn.QueryAsync<ExperienciaDTO>(
            "SELECT * FROM Experiencia WHERE FKProfissional = @idProfissional ORDER BY DataInicio DESC",
            new { idProfissional })).ToList();
    }

    public async Task InserirAsync(ExperienciaDTO e)
    {
        await using var conn = await AbrirAsync();
        await conn.ExecuteAsync("""
            INSERT INTO Experiencia (DsCargo, DsEmpresa, DsTipoContrato, DsLocalidade, DataInicio, DataFinal, FKProfissional)
            VALUES (@DsCargo, @DsEmpresa, @DsTipoContrato, @DsLocalidade, @DataInicio, @DataFinal, @FKProfissional)
            """, e);
    }

    public async Task<bool> ExcluirAsync(int id, int idProfissional)
    {
        await using var conn = await AbrirAsync();
        return await conn.ExecuteAsync(
            "DELETE FROM Experiencia WHERE IdExperiencia = @id AND FKProfissional = @idProfissional",
            new { id, idProfissional }) > 0;
    }
}

public class CertificadoDAL(NpgsqlDataSource ds) : Conexao(ds)
{
    public async Task<List<CertificadoDTO>> ListarPorProfissionalAsync(int idProfissional)
    {
        await using var conn = await AbrirAsync();
        return (await conn.QueryAsync<CertificadoDTO>(
            "SELECT * FROM Certificado WHERE FKProfissional = @idProfissional ORDER BY DataInicio DESC",
            new { idProfissional })).ToList();
    }

    public async Task InserirAsync(CertificadoDTO c)
    {
        await using var conn = await AbrirAsync();
        await conn.ExecuteAsync("""
            INSERT INTO Certificado (DsCurso, DsInstituicao, DataInicio, DataConclusao, DsDescricao, FKProfissional)
            VALUES (@DsCurso, @DsInstituicao, @DataInicio, @DataConclusao, @DsDescricao, @FKProfissional)
            """, c);
    }

    public async Task<bool> ExcluirAsync(int id, int idProfissional)
    {
        await using var conn = await AbrirAsync();
        return await conn.ExecuteAsync(
            "DELETE FROM Certificado WHERE IdCertificado = @id AND FKProfissional = @idProfissional",
            new { id, idProfissional }) > 0;
    }
}
