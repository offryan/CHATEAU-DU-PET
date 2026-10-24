using ChateauDuPet.BLL;
using ChateauDuPet.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChateauDuPet.Web.Pages.Vagas;

public class IndexModel(VagaBLL vagas) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? Busca { get; set; }

    public List<VagaDTO> Vagas { get; private set; } = [];

    public async Task OnGetAsync() => Vagas = await vagas.ListarAsync(Busca);
}
