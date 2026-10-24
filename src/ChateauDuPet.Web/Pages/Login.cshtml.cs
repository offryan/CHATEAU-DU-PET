using ChateauDuPet.BLL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChateauDuPet.Web.Pages;

public class LoginModel(AutenticacaoBLL autenticacao) : PageModel
{
    [BindProperty] public string Email { get; set; } = "";
    [BindProperty] public string Senha { get; set; } = "";
    [BindProperty(SupportsGet = true)] public string? ReturnUrl { get; set; }

    public string? Erro { get; private set; }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        var usuario = await autenticacao.EntrarAsync(Email, Senha);
        if (usuario is null)
        {
            Erro = "E-mail ou senha incorretos.";
            return Page();
        }

        await HttpContext.SignInAsync(usuario.ParaPrincipal());
        return LocalRedirect(Url.IsLocalUrl(ReturnUrl) ? ReturnUrl! : usuario.PainelUrl());
    }
}
