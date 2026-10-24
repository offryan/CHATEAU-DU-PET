using ChateauDuPet.BLL;
using ChateauDuPet.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChateauDuPet.Web.Pages.Empresa;

public class VagaModel(VagaBLL vagas) : PageModel
{
    [BindProperty]
    public VagaDTO Form { get; set; } = new() { Validade = "1 mês", DsSexo = "Indiferente" };

    public string? Erro { get; private set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null) return Page();

        // Só carrega vagas da própria empresa
        if (await vagas.ObterAsync(id.Value) is not { } vaga || vaga.FKEmpresa != User.Logado()!.Id) return NotFound();
        Form = vaga;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var idEmpresa = User.Logado()!.Id;
        var r = Form.IdVaga == 0
            ? await vagas.PublicarAsync(Form, idEmpresa)
            : await vagas.EditarAsync(Form, idEmpresa);

        if (!r.Sucesso)
        {
            Erro = r.Erro;
            return Page();
        }
        TempData["Mensagem"] = Form.IdVaga == 0 ? "Vaga publicada!" : "Vaga atualizada.";
        return RedirectToPage("Index");
    }
}
