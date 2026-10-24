using ChateauDuPet.BLL;
using ChateauDuPet.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChateauDuPet.Web.Pages.Vagas;

public class DetalheModel(VagaBLL vagas) : PageModel
{
    public VagaDTO Vaga { get; private set; } = null!;
    public UsuarioLogado? Usuario { get; private set; }
    public bool JaCandidatado { get; private set; }
    public string? Erro { get; private set; }

    public async Task<IActionResult> OnGetAsync(int id) => await CarregarAsync(id) ? Page() : NotFound();

    // Razor Pages não aplica [Authorize] em handlers, então a checagem do perfil é feita aqui
    public async Task<IActionResult> OnPostCandidatarAsync(int id)
    {
        if (User.Logado() is not { Tipo: TipoUsuario.Profissional } pro) return Challenge();

        var r = await vagas.CandidatarAsync(pro.Id, id);
        if (r.Sucesso)
        {
            TempData["Mensagem"] = "Candidatura enviada! A empresa já pode ver seu perfil.";
            return RedirectToPage(new { id });
        }
        Erro = r.Erro;
        return await CarregarAsync(id) ? Page() : NotFound();
    }

    public async Task<IActionResult> OnPostCancelarAsync(int id)
    {
        if (User.Logado() is not { Tipo: TipoUsuario.Profissional } pro) return Challenge();

        await vagas.CancelarCandidaturaAsync(pro.Id, id);
        TempData["Mensagem"] = "Candidatura cancelada.";
        return RedirectToPage(new { id });
    }

    private async Task<bool> CarregarAsync(int id)
    {
        if (await vagas.ObterAsync(id) is not { } vaga) return false;
        Vaga = vaga;
        Usuario = User.Logado();
        if (Usuario?.Tipo == TipoUsuario.Profissional)
            JaCandidatado = await vagas.JaCandidatadoAsync(Usuario.Id, id);
        return true;
    }
}
