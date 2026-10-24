using ChateauDuPet.DTO;
using Dapper;
using Npgsql;

namespace ChateauDuPet.DAL;

public class VagaDAL(NpgsqlDataSource ds) : Conexao(ds)
{
    private const string SelectComEmpresa = """
        SELECT v.*,
               COALESCE(NULLIF(e.DsNomeFantasia, ''), e.NmRecrutador) AS NomeEmpresa,
               e.DsCidade AS CidadeEmpresa,
               (SELECT count(*) FROM Candidatos c WHERE c.FKVaga = v.IdVaga)::int AS TotalCandidatos
        FROM Vaga v
        JOIN Empresa e ON e.IdEmpresa = v.FKEmpresa
        """;

    public async Task<List<VagaDTO>> ListarAsync(string? busca = null)
    {
        await using var conn = await AbrirAsync();
        return (await conn.QueryAsync<VagaDTO>($"""
            {SelectComEmpresa}
            WHERE @busca::text IS NULL OR v.NmVaga ILIKE '%' || @busca || '%' OR v.DsDescricao ILIKE '%' || @busca || '%'
            ORDER BY v.DataPublicacao DESC, v.IdVaga DESC
            """, new { busca = string.IsNullOrWhiteSpace(busca) ? null : busca.Trim() })).ToList();
    }

    public async Task<List<VagaDTO>> ListarPorEmpresaAsync(int idEmpresa)
    {
        await using var conn = await AbrirAsync();
        return (await conn.QueryAsync<VagaDTO>($"""
            {SelectComEmpresa}
            WHERE v.FKEmpresa = @idEmpresa
            ORDER BY v.DataPublicacao DESC, v.IdVaga DESC
            """, new { idEmpresa })).ToList();
    }

    public async Task<VagaDTO?> ObterPorIdAsync(int id)
    {
        await using var conn = await AbrirAsync();
        return await conn.QuerySingleOrDefaultAsync<VagaDTO>($"{SelectComEmpresa} WHERE v.IdVaga = @id", new { id });
    }

    public async Task<int> InserirAsync(VagaDTO v)
    {
        await using var conn = await AbrirAsync();
        return await conn.ExecuteScalarAsync<int>("""
            INSERT INTO Vaga (NmVaga, DsExperiencia, DsTipoRegistro, DsDescricao, DsSexo, Validade, FKEmpresa)
            VALUES (@NmVaga, @DsExperiencia, @DsTipoRegistro, @DsDescricao, @DsSexo, @Validade, @FKEmpresa)
            RETURNING IdVaga
            """, v);
    }

    /// <summary>Só altera se a vaga pertencer à empresa informada.</summary>
    public async Task<bool> AtualizarAsync(VagaDTO v)
    {
        await using var conn = await AbrirAsync();
        return await conn.ExecuteAsync("""
            UPDATE Vaga SET NmVaga = @NmVaga, DsExperiencia = @DsExperiencia, DsTipoRegistro = @DsTipoRegistro,
                   DsDescricao = @DsDescricao, DsSexo = @DsSexo, Validade = @Validade
            WHERE IdVaga = @IdVaga AND FKEmpresa = @FKEmpresa
            """, v) > 0;
    }

    /// <summary>Exclui a vaga. Com idEmpresa = null (administrador) exclui qualquer vaga.</summary>
    public async Task<bool> ExcluirAsync(int id, int? idEmpresa)
    {
        await using var conn = await AbrirAsync();
        return await conn.ExecuteAsync(
            "DELETE FROM Vaga WHERE IdVaga = @id AND (@idEmpresa::int IS NULL OR FKEmpresa = @idEmpresa)",
            new { id, idEmpresa }) > 0;
    }
}

public class CandidaturaDAL(NpgsqlDataSource ds) : Conexao(ds)
{
    /// <summary>Retorna false se o profissional já era candidato da vaga.</summary>
    public async Task<bool> CandidatarAsync(int idProfissional, int idVaga)
    {
        await using var conn = await AbrirAsync();
        return await conn.ExecuteAsync("""
            INSERT INTO Candidatos (FKProfissional, FKVaga) VALUES (@idProfissional, @idVaga)
            ON CONFLICT (FKProfissional, FKVaga) DO NOTHING
            """, new { idProfissional, idVaga }) > 0;
    }

    public async Task<bool> CancelarAsync(int idProfissional, int idVaga)
    {
        await using var conn = await AbrirAsync();
        return await conn.ExecuteAsync(
            "DELETE FROM Candidatos WHERE FKProfissional = @idProfissional AND FKVaga = @idVaga",
            new { idProfissional, idVaga }) > 0;
    }

    public async Task<bool> JaCandidatadoAsync(int idProfissional, int idVaga)
    {
        await using var conn = await AbrirAsync();
        return await conn.ExecuteScalarAsync<bool>(
            "SELECT EXISTS (SELECT 1 FROM Candidatos WHERE FKProfissional = @idProfissional AND FKVaga = @idVaga)",
            new { idProfissional, idVaga });
    }

    public async Task<List<CandidaturaDTO>> ListarPorProfissionalAsync(int idProfissional)
    {
        await using var conn = await AbrirAsync();
        return (await conn.QueryAsync<CandidaturaDTO>("""
            SELECT c.*, v.NmVaga, COALESCE(NULLIF(e.DsNomeFantasia, ''), e.NmRecrutador) AS NomeEmpresa
            FROM Candidatos c
            JOIN Vaga v    ON v.IdVaga = c.FKVaga
            JOIN Empresa e ON e.IdEmpresa = v.FKEmpresa
            WHERE c.FKProfissional = @idProfissional
            ORDER BY c.DsData DESC
            """, new { idProfissional })).ToList();
    }

    /// <summary>Candidatos de uma vaga. Com idEmpresa informado, só lista se a vaga for dessa empresa.</summary>
    public async Task<List<CandidaturaDTO>> ListarPorVagaAsync(int idVaga, int? idEmpresa)
    {
        await using var conn = await AbrirAsync();
        return (await conn.QueryAsync<CandidaturaDTO>("""
            SELECT c.*, v.NmVaga, p.NmProfissional, p.DsEmail, p.FormacaoEscolar
            FROM Candidatos c
            JOIN Vaga v         ON v.IdVaga = c.FKVaga
            JOIN Profissional p ON p.IdProfissional = c.FKProfissional
            WHERE c.FKVaga = @idVaga AND (@idEmpresa::int IS NULL OR v.FKEmpresa = @idEmpresa)
            ORDER BY c.DsData
            """, new { idVaga, idEmpresa })).ToList();
    }
}
