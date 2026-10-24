using ChateauDuPet.BLL;
using ChateauDuPet.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChateauDuPet.Web.Pages.Profissional;

public class IndexModel(VagaBLL vagas, PerfilBLL perfis) : PageModel
{
    public ProfissionalDTO Perfil { get; private set; } = null!;
    public List<CandidaturaDTO> Candidaturas { get; private set; } = [];
    public List<VagaDTO> Vagas { get; private set; } = [];
    public bool PerfilIncompleto { get; private set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var id = User.Logado()!.Id;
        if (await perfis.ObterProfissionalAsync(id) is not { } perfil) return RedirectToPage("/Sair");
        Perfil = perfil;
        Candidaturas = await vagas.CandidaturasDoProfissionalAsync(id);
        Vagas = await vagas.ListarAsync();
        PerfilIncompleto = string.IsNullOrWhiteSpace(perfil.DsBiografia) && (await perfis.ExperienciasAsync(id)).Count == 0;
        return Page();
    }
}
