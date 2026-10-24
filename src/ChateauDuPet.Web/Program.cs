using ChateauDuPet.BLL;
using ChateauDuPet.DAL;
using ChateauDuPet.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.HttpOverrides;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Render injeta a porta na variável PORT
if (Environment.GetEnvironmentVariable("PORT") is { Length: > 0 } porta)
    builder.WebHost.UseUrls($"http://0.0.0.0:{porta}");

// String de conexão: variável DATABASE_URL (formato URI do Supabase) ou ConnectionStrings:Chateau
var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
    ?? builder.Configuration.GetConnectionString("Chateau")
    ?? throw new InvalidOperationException("Configure a variável de ambiente DATABASE_URL.");
builder.Services.AddSingleton(NpgsqlDataSource.Create(Conexao.NormalizarConnectionString(connectionString)));

builder.Services.AddScoped<AdministrativoDAL>();
builder.Services.AddScoped<EmpresaDAL>();
builder.Services.AddScoped<ProfissionalDAL>();
builder.Services.AddScoped<ExperienciaDAL>();
builder.Services.AddScoped<CertificadoDAL>();
builder.Services.AddScoped<VagaDAL>();
builder.Services.AddScoped<CandidaturaDAL>();
builder.Services.AddScoped<AutenticacaoBLL>();
builder.Services.AddScoped<CadastroBLL>();
builder.Services.AddScoped<VagaBLL>();
builder.Services.AddScoped<PerfilBLL>();

// As chaves que protegem cookies e formulários ficam no banco: o container do Render é
// recriado a cada deploy e, sem isso, todo mundo seria deslogado.
builder.Services.AddSingleton<ChavesNoBanco>();
builder.Services.AddDataProtection().SetApplicationName("ChateauDuPet");
builder.Services.AddOptions<KeyManagementOptions>()
    .Configure<ChavesNoBanco>((opcoes, repositorio) => opcoes.XmlRepository = repositorio);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opcoes =>
    {
        opcoes.LoginPath = "/Login";
        opcoes.AccessDeniedPath = "/Login";
        opcoes.Cookie.Name = "chateau.auth";
        opcoes.ExpireTimeSpan = TimeSpan.FromHours(8);
    });
builder.Services.AddAuthorization();

builder.Services.AddRazorPages(opcoes =>
{
    opcoes.Conventions.AuthorizeFolder("/Empresa", Papeis.Empresa);
    opcoes.Conventions.AuthorizeFolder("/Profissional", Papeis.Profissional);
    opcoes.Conventions.AuthorizeFolder("/Admin", Papeis.Administrativo);
});
builder.Services.AddAuthorizationBuilder()
    .AddPolicy(Papeis.Empresa, p => p.RequireRole(Papeis.Empresa))
    .AddPolicy(Papeis.Profissional, p => p.RequireRole(Papeis.Profissional))
    .AddPolicy(Papeis.Administrativo, p => p.RequireRole(Papeis.Administrativo));

builder.Services.Configure<ForwardedHeadersOptions>(opcoes =>
{
    // O Render termina o HTTPS no proxy dele e repassa a requisição em HTTP
    opcoes.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    opcoes.KnownNetworks.Clear();
    opcoes.KnownProxies.Clear();
});

var app = builder.Build();

app.UseForwardedHeaders();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/health", () => Results.Ok("ok"));
app.MapRazorPages();

app.Run();
