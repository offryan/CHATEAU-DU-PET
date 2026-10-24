using ChateauDuPet.BLL;
using ChateauDuPet.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChateauDuPet.Web.Pages.Empresa;

public class CandidatosModel(VagaBLL vagas) : PageModel
{
    public VagaDTO Vaga { get; private set; } = null!;
    public List<CandidaturaDTO> Candidatos { get; private set; } = [];

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var usuario = User.Logado()!;
        if (await vagas.ObterAsync(id) is not { } vaga || vaga.FKEmpresa != usuario.Id) return NotFound();
        Vaga = vaga;
        Candidatos = await vagas.CandidatosDaVagaAsync(id, usuario);
        return Page();
    }
}
