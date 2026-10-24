using ChateauDuPet.BLL;
using ChateauDuPet.DAL;
using Npgsql;

namespace ChateauDuPet.Tests;

/// <summary>
/// Cria um banco PostgreSQL limpo para os testes com os mesmos schema.sql e seed.sql do Supabase.
/// Servidor configurável pela variável CHATEAU_TEST_DB (padrão: Postgres local, usuário postgres/postgres).
/// </summary>
public sealed class BancoFixture : IAsyncLifetime
{
    private const string NomeBanco = "chateau_testes";
    private readonly string _servidor =
        Environment.GetEnvironmentVariable("CHATEAU_TEST_DB") ?? "Host=localhost;Username=postgres;Password=postgres";

    public NpgsqlDataSource DataSource { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        await using (var admin = new NpgsqlConnection(_servidor + ";Database=postgres"))
        {
            await admin.OpenAsync();
            await new NpgsqlCommand($"DROP DATABASE IF EXISTS {NomeBanco} WITH (FORCE)", admin).ExecuteNonQueryAsync();
            await new NpgsqlCommand($"CREATE DATABASE {NomeBanco}", admin).ExecuteNonQueryAsync();
        }

        DataSource = NpgsqlDataSource.Create(_servidor + $";Database={NomeBanco}");
        await using var conn = await DataSource.OpenConnectionAsync();
        foreach (var arquivo in new[] { "schema.sql", "seed.sql" })
            await new NpgsqlCommand(await File.ReadAllTextAsync(CaminhoDatabase(arquivo)), conn).ExecuteNonQueryAsync();
    }

    public async Task DisposeAsync() => await DataSource.DisposeAsync();

    public AutenticacaoBLL Autenticacao() => new(new AdministrativoDAL(DataSource), new EmpresaDAL(DataSource), new ProfissionalDAL(DataSource));
    public CadastroBLL Cadastro() => new(new EmpresaDAL(DataSource), new ProfissionalDAL(DataSource));
    public VagaBLL Vagas() => new(new VagaDAL(DataSource), new CandidaturaDAL(DataSource));
    public PerfilBLL Perfil() => new(new ProfissionalDAL(DataSource), new EmpresaDAL(DataSource),
                                     new ExperienciaDAL(DataSource), new CertificadoDAL(DataSource));

    private static string CaminhoDatabase(string arquivo)
    {
        for (var dir = new DirectoryInfo(AppContext.BaseDirectory); dir is not null; dir = dir.Parent)
        {
            var caminho = Path.Combine(dir.FullName, "database", arquivo);
            if (File.Exists(caminho)) return caminho;
        }
        throw new FileNotFoundException($"database/{arquivo} não encontrado");
    }
}

[CollectionDefinition("Banco")]
public class BancoCollection : ICollectionFixture<BancoFixture>;
