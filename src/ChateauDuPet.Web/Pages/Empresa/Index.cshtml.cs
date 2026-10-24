using ChateauDuPet.BLL;
using ChateauDuPet.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChateauDuPet.Web.Pages.Empresa;

public class IndexModel(VagaBLL vagas, PerfilBLL perfis) : PageModel
{
    public EmpresaDTO Empresa { get; private set; } = null!;
    public List<VagaDTO> Vagas { get; private set; } = [];
    public List<ProfissionalDTO> Profissionais { get; private set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        var id = User.Logado()!.Id;
        if (await perfis.ObterEmpresaAsync(id) is not { } empresa) return RedirectToPage("/Sair");
        Empresa = empresa;
        Vagas = await vagas.ListarDaEmpresaAsync(id);
        Profissionais = await perfis.ListarProfissionaisAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostExcluirAsync(int id)
    {
        var r = await vagas.ExcluirAsync(id, User.Logado()!);
        TempData["Mensagem"] = r.Sucesso ? "Vaga excluída." : r.Erro;
        return RedirectToPage();
    }
}
