using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChateauDuPet.Web.Pages;

public class SobreModel : PageModel
{
    [BindProperty]
    public ContatoInput Contato { get; set; } = new();

    public bool Enviado { get; private set; }

    public void OnGet() { }

    // Na demonstração a mensagem só é validada: não existe servidor de e-mail configurado.
    public void OnPost()
    {
        if (!ModelState.IsValid) return;
        Enviado = true;
        ModelState.Clear();
        Contato = new();
    }

    public class ContatoInput
    {
        [Required(ErrorMessage = "Campo Nome é obrigatório!")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "Campo E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O E-mail é inválido!")]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Campo Telefone é obrigatório")]
        public string Telefone { get; set; } = "";

        [Required(ErrorMessage = "Campo Mensagem é obrigatório")]
        public string Mensagem { get; set; } = "";
    }
}
