using ChateauDuPet.DTO;
using Dapper;
using Npgsql;

namespace ChateauDuPet.DAL;

public class AdministrativoDAL(NpgsqlDataSource ds) : Conexao(ds)
{
    public async Task<AdministrativoDTO?> ObterPorEmailAsync(string email)
    {
        await using var conn = await AbrirAsync();
        return await conn.QuerySingleOrDefaultAsync<AdministrativoDTO>(
            "SELECT * FROM Administrativo WHERE lower(DsEmail) = lower(@email)", new { email });
    }

    public async Task<AdministrativoDTO?> ObterPorIdAsync(int id)
    {
        await using var conn = await AbrirAsync();
        return await conn.QuerySingleOrDefaultAsync<AdministrativoDTO>(
            "SELECT * FROM Administrativo WHERE IdAdministrativo = @id", new { id });
    }
}

public class EmpresaDAL(NpgsqlDataSource ds) : Conexao(ds)
{
    public async Task<EmpresaDTO?> ObterPorEmailAsync(string email)
    {
        await using var conn = await AbrirAsync();
        return await conn.QuerySingleOrDefaultAsync<EmpresaDTO>(
            "SELECT * FROM Empresa WHERE lower(DsEmail) = lower(@email)", new { email });
    }

    public async Task<EmpresaDTO?> ObterPorIdAsync(int id)
    {
        await using var conn = await AbrirAsync();
        return await conn.QuerySingleOrDefaultAsync<EmpresaDTO>(
            "SELECT * FROM Empresa WHERE IdEmpresa = @id", new { id });
    }

    public async Task<List<EmpresaDTO>> ListarAsync()
    {
        await using var conn = await AbrirAsync();
        return (await conn.QueryAsync<EmpresaDTO>("SELECT * FROM Empresa ORDER BY NmRecrutador")).ToList();
    }

    /// <summary>Retorna qual campo já está em uso ("e-mail", "usuário" ou "CPF"), ou null.</summary>
    public async Task<string?> CampoDuplicadoAsync(string email, string usuario, string cpf, int ignorarId = 0)
    {
        await using var conn = await AbrirAsync();
        return await conn.QueryFirstOrDefaultAsync<string>("""
            SELECT CASE WHEN lower(DsEmail) = lower(@email) THEN 'e-mail'
                        WHEN lower(DsUser)  = lower(@usuario) THEN 'usuário'
                        ELSE 'CPF' END
            FROM Empresa
            WHERE IdEmpresa <> @ignorarId
              AND (lower(DsEmail) = lower(@email) OR lower(DsUser) = lower(@usuario) OR NroCPF = @cpf)
            LIMIT 1
            """, new { email, usuario, cpf, ignorarId });
    }

    public async Task<int> InserirAsync(EmpresaDTO e)
    {
        await using var conn = await AbrirAsync();
        return await conn.ExecuteScalarAsync<int>("""
            INSERT INTO Empresa (NmRecrutador, DsUser, DsEmail, NroCPF, SenhaEmpresa, NroTelefone, DtNascimento, DsSexo,
                                 NroCNPJ, DsNomeFantasia, DsRazaoSocial)
            VALUES (@NmRecrutador, @DsUser, @DsEmail, @NroCPF, @SenhaEmpresa, @NroTelefone, @DtNascimento, @DsSexo,
                    @NroCNPJ, @DsNomeFantasia, @DsRazaoSocial)
            RETURNING IdEmpresa
            """, e);
    }

    public async Task AtualizarPerfilAsync(EmpresaDTO e)
    {
        await using var conn = await AbrirAsync();
        await conn.ExecuteAsync("""
            UPDATE Empresa SET NmRecrutador = @NmRecrutador, NroTelefone = @NroTelefone,
                   DsEndereco = @DsEndereco, NroEndereco = @NroEndereco, DsComplemento = @DsComplemento,
                   DsCep = @DsCep, DsBairro = @DsBairro, DsCidade = @DsCidade, DsUF = @DsUF,
                   NroCNPJ = @NroCNPJ, DsNomeFantasia = @DsNomeFantasia, DsRazaoSocial = @DsRazaoSocial,
                   DsDataAbertura = @DsDataAbertura
            WHERE IdEmpresa = @IdEmpresa
            """, e);
    }

    public async Task ExcluirAsync(int id)
    {
        await using var conn = await AbrirAsync();
        await conn.ExecuteAsync("DELETE FROM Empresa WHERE IdEmpresa = @id", new { id });
    }
}

public class ProfissionalDAL(NpgsqlDataSource ds) : Conexao(ds)
{
    public async Task<ProfissionalDTO?> ObterPorEmailAsync(string email)
    {
        await using var conn = await AbrirAsync();
        return await conn.QuerySingleOrDefaultAsync<ProfissionalDTO>(
            "SELECT * FROM Profissional WHERE lower(DsEmail) = lower(@email)", new { email });
    }

    public async Task<ProfissionalDTO?> ObterPorIdAsync(int id)
    {
        await using var conn = await AbrirAsync();
        return await conn.QuerySingleOrDefaultAsync<ProfissionalDTO>(
            "SELECT * FROM Profissional WHERE IdProfissional = @id", new { id });
    }

    public async Task<List<ProfissionalDTO>> ListarAsync()
    {
        await using var conn = await AbrirAsync();
        return (await conn.QueryAsync<ProfissionalDTO>("SELECT * FROM Profissional ORDER BY NmProfissional")).ToList();
    }

    /// <summary>Retorna qual campo já está em uso ("e-mail", "usuário" ou "CPF"), ou null.</summary>
    public async Task<string?> CampoDuplicadoAsync(string email, string usuario, string cpf, int ignorarId = 0)
    {
        await using var conn = await AbrirAsync();
        return await conn.QueryFirstOrDefaultAsync<string>("""
            SELECT CASE WHEN lower(DsEmail) = lower(@email) THEN 'e-mail'
                        WHEN lower(DsUser)  = lower(@usuario) THEN 'usuário'
                        ELSE 'CPF' END
            FROM Profissional
            WHERE IdProfissional <> @ignorarId
              AND (lower(DsEmail) = lower(@email) OR lower(DsUser) = lower(@usuario) OR NroCPF = @cpf)
            LIMIT 1
            """, new { email, usuario, cpf, ignorarId });
    }

    public async Task<int> InserirAsync(ProfissionalDTO p)
    {
        await using var conn = await AbrirAsync();
        return await conn.ExecuteScalarAsync<int>("""
            INSERT INTO Profissional (NmProfissional, DsUser, DsEmail, NroCPF, SenhaProfissional, NroTelefone, DtNascimento, DsSexo)
            VALUES (@NmProfissional, @DsUser, @DsEmail, @NroCPF, @SenhaProfissional, @NroTelefone, @DtNascimento, @DsSexo)
            RETURNING IdProfissional
            """, p);
    }

    public async Task AtualizarPerfilAsync(ProfissionalDTO p)
    {
        await using var conn = await AbrirAsync();
        await conn.ExecuteAsync("""
            UPDATE Profissional SET NmProfissional = @NmProfissional, NroTelefone = @NroTelefone,
                   DsBiografia = @DsBiografia, FormacaoEscolar = @FormacaoEscolar,
                   DsEndereco = @DsEndereco, NroEndereco = @NroEndereco, DsComplemento = @DsComplemento,
                   DsCEP = @DsCEP, DsBairro = @DsBairro, DsCidade = @DsCidade, DsUF = @DsUF
            WHERE IdProfissional = @IdProfissional
            """, p);
    }

    public async Task ExcluirAsync(int id)
    {
        await using var conn = await AbrirAsync();
        await conn.ExecuteAsync("DELETE FROM Profissional WHERE IdProfissional = @id", new { id });
    }
}
