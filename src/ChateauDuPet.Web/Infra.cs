using System.Security.Claims;
using System.Xml.Linq;
using ChateauDuPet.DTO;
using Dapper;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Npgsql;

namespace ChateauDuPet.Web;

public static class Papeis
{
    public const string Empresa = nameof(TipoUsuario.Empresa);
    public const string Profissional = nameof(TipoUsuario.Profissional);
    public const string Administrativo = nameof(TipoUsuario.Administrativo);
}

public static class UsuarioExtensions
{
    public static ClaimsPrincipal ParaPrincipal(this UsuarioLogado u) => new(new ClaimsIdentity(
    [
        new Claim(ClaimTypes.NameIdentifier, u.Id.ToString()),
        new Claim(ClaimTypes.Name, u.Nome),
        new Claim(ClaimTypes.Email, u.Email),
        new Claim(ClaimTypes.Role, u.Tipo.ToString())
    ], "Cookies"));

    /// <summary>Usuário logado na requisição, ou null se for visitante.</summary>
    public static UsuarioLogado? Logado(this ClaimsPrincipal principal)
    {
        if (principal.Identity?.IsAuthenticated != true) return null;
        return new UsuarioLogado(
            int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier)!),
            principal.FindFirstValue(ClaimTypes.Name)!,
            principal.FindFirstValue(ClaimTypes.Email)!,
            Enum.Parse<TipoUsuario>(principal.FindFirstValue(ClaimTypes.Role)!));
    }

    public static string PainelUrl(this UsuarioLogado u) => u.Tipo switch
    {
        TipoUsuario.Empresa => "/Empresa",
        TipoUsuario.Profissional => "/Profissional",
        _ => "/Admin"
    };
}

/// <summary>Guarda as chaves de Data Protection na tabela DataProtectionKeys.</summary>
public class ChavesNoBanco(NpgsqlDataSource dataSource) : IXmlRepository
{
    public IReadOnlyCollection<XElement> GetAllElements()
    {
        using var conn = dataSource.OpenConnection();
        return conn.Query<string>("SELECT Xml FROM DataProtectionKeys").Select(XElement.Parse).ToList();
    }

    public void StoreElement(XElement element, string friendlyName)
    {
        using var conn = dataSource.OpenConnection();
        conn.Execute("""
            INSERT INTO DataProtectionKeys (FriendlyName, Xml) VALUES (@friendlyName, @xml)
            ON CONFLICT (FriendlyName) DO UPDATE SET Xml = EXCLUDED.Xml
            """, new { friendlyName, xml = element.ToString(SaveOptions.DisableFormatting) });
    }
}
