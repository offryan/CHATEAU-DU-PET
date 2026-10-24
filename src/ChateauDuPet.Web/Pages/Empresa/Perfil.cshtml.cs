using ChateauDuPet.BLL;
using ChateauDuPet.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChateauDuPet.Web.Pages.Empresa;

public class PerfilModel(PerfilBLL perfis) : PageModel
{
    [BindProperty]
    public EmpresaDTO Form { get; set; } = new();

    public string? Erro { get; private set; }

    public async Task<IActionResult> OnGetAsync()
    {
        if (await perfis.ObterEmpresaAsync(User.Logado()!.Id) is not { } empresa) return NotFound();
        Form = empresa;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Form.IdEmpresa = User.Logado()!.Id; // nunca confia no id vindo do formulário
        var r = await perfis.AtualizarEmpresaAsync(Form);
        if (!r.Sucesso)
        {
            Erro = r.Erro;
            return Page();
        }
        TempData["Mensagem"] = "Dados da empresa atualizados.";
        return RedirectToPage("Index");
    }
}
