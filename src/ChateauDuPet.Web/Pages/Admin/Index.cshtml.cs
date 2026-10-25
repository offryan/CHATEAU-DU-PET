using ChateauDuPet.BLL;
using ChateauDuPet.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChateauDuPet.Web.Pages.Admin;

public class IndexModel(PerfilBLL perfis, VagaBLL vagas) : PageModel
{
    public List<ProfissionalDTO> Profissionais { get; private set; } = [];
    public List<EmpresaDTO> Empresas { get; private set; } = [];
    public List<VagaDTO> Vagas { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Profissionais = await perfis.ListarProfissionaisAsync();
        Empresas = await perfis.ListarEmpresasAsync();
        Vagas = await vagas.ListarAsync();
    }

    public async Task<IActionResult> OnPostExcluirProfissionalAsync(int id)
    {
        await perfis.ExcluirProfissionalAsync(id);
        TempData["Mensagem"] = "Candidato excluído.";
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostExcluirEmpresaAsync(int id)
    {
        await perfis.ExcluirEmpresaAsync(id);
        TempData["Mensagem"] = "Empresa excluída.";
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostExcluirVagaAsync(int id)
    {
        await vagas.ExcluirAsync(id, User.Logado()!);
        TempData["Mensagem"] = "Vaga excluída.";
        return RedirectToPage();
    }
}
