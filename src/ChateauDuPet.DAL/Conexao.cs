using Npgsql;

namespace ChateauDuPet.DAL;

// Base dos repositórios: cada operação abre uma conexão do pool e devolve ao final.
// A string de conexão vem de variável de ambiente, nunca do código.
public abstract class Conexao
{
    private readonly NpgsqlDataSource _dataSource;

    protected Conexao(NpgsqlDataSource dataSource) => _dataSource = dataSource;

    protected async Task<NpgsqlConnection> AbrirAsync() => await _dataSource.OpenConnectionAsync();

    /// <summary>
    /// Aceita tanto o formato chave=valor do Npgsql quanto a URI
    /// postgresql://usuario:senha@host:porta/banco que o Supabase mostra.
    /// </summary>
    public static string NormalizarConnectionString(string valor)
    {
        if (!valor.StartsWith("postgres://") && !valor.StartsWith("postgresql://"))
            return valor;

        var uri = new Uri(valor);
        var credenciais = uri.UserInfo.Split(':', 2);
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = uri.Host,
            Port = uri.Port > 0 ? uri.Port : 5432,
            Database = uri.AbsolutePath.Trim('/') is { Length: > 0 } banco ? banco : "postgres",
            Username = Uri.UnescapeDataString(credenciais[0]),
            Password = credenciais.Length > 1 ? Uri.UnescapeDataString(credenciais[1]) : null,
            SslMode = SslMode.Require
        };
        return builder.ConnectionString;
    }
}
