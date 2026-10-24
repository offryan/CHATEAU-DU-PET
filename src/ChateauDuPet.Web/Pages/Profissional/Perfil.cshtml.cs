using ChateauDuPet.BLL;
using ChateauDuPet.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChateauDuPet.Web.Pages.Profissional;

public class PerfilModel(PerfilBLL perfis) : PageModel
{
    [BindProperty] public ProfissionalDTO Dados { get; set; } = new();
    [BindProperty] public ExperienciaDTO NovaExperiencia { get; set; } = new() { DataInicio = DateTime.Today };
    [BindProperty] public CertificadoDTO NovoCertificado { get; set; } = new() { DataInicio = DateTime.Today };

    public List<ExperienciaDTO> Experiencias { get; private set; } = [];
    public List<CertificadoDTO> Certificados { get; private set; } = [];
    public string? Erro { get; private set; }

    private int IdLogado => User.Logado()!.Id;

    public async Task<IActionResult> OnGetAsync()
    {
        if (await perfis.ObterProfissionalAsync(IdLogado) is not { } perfil) return NotFound();
        Dados = perfil;
        await CarregarListasAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostDadosAsync()
    {
        Dados.IdProfissional = IdLogado; // nunca confia no id vindo do formulário
        return await Concluir(await perfis.AtualizarProfissionalAsync(Dados), "Dados atualizados.");
    }

    public async Task<IActionResult> OnPostExperienciaAsync() =>
        await Concluir(await perfis.AdicionarExperienciaAsync(NovaExperiencia, IdLogado), "Experiência adicionada.");

    public async Task<IActionResult> OnPostCertificadoAsync() =>
        await Concluir(await perfis.AdicionarCertificadoAsync(NovoCertificado, IdLogado), "Certificado adicionado.");

    public async Task<IActionResult> OnPostExcluirExperienciaAsync(int id)
    {
        await perfis.ExcluirExperienciaAsync(id, IdLogado);
        TempData["Mensagem"] = "Experiência removida.";
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostExcluirCertificadoAsync(int id)
    {
        await perfis.ExcluirCertificadoAsync(id, IdLogado);
        TempData["Mensagem"] = "Certificado removido.";
        return RedirectToPage();
    }

    private async Task<IActionResult> Concluir(Resultado r, string mensagem)
    {
        if (r.Sucesso)
        {
            TempData["Mensagem"] = mensagem;
            return RedirectToPage();
        }
        Erro = r.Erro;
        if (await perfis.ObterProfissionalAsync(IdLogado) is { } perfil) Dados = perfil;
        await CarregarListasAsync();
        return Page();
    }

    private async Task CarregarListasAsync()
    {
        Experiencias = await perfis.ExperienciasAsync(IdLogado);
        Certificados = await perfis.CertificadosAsync(IdLogado);
    }
}
