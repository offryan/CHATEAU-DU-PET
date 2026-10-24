using System.ComponentModel.DataAnnotations;
using ChateauDuPet.BLL;
using ChateauDuPet.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChateauDuPet.Web.Pages;

public class CadastroModel(CadastroBLL cadastro) : PageModel
{
    [BindProperty]
    public CadastroInput Form { get; set; } = new();

    public string? Erro { get; private set; }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Form.Senha != Form.ConfirmarSenha)
            ModelState.AddModelError("Form.ConfirmarSenha", "As senhas não conferem.");
        if (!Form.AceitaPolitica || !Form.AceitaTermos)
            ModelState.AddModelError("Form.AceitaTermos", "É preciso aceitar a política de privacidade e os termos de uso.");
        if (!ModelState.IsValid) return Page();

        var agora = DateTime.Now;
        Resultado r;
        UsuarioLogado novo;
        if (Form.Tipo == TipoUsuario.Empresa)
        {
            var empresa = new EmpresaDTO
            {
                NmRecrutador = Form.Nome.Trim(), DsUser = Form.Usuario.Trim(), DsEmail = Form.Email.Trim(),
                NroCPF = Form.Cpf, NroTelefone = Form.Telefone, DtNascimento = Form.Nascimento!.Value,
                DsSexo = Form.Sexo, DsNomeFantasia = Form.NomeFantasia?.Trim(), NroCNPJ = Form.Cnpj?.Trim(),
                DtTermos = agora, DsPrivacidade = agora
            };
            r = await cadastro.CadastrarEmpresaAsync(empresa, Form.Senha);
            novo = new UsuarioLogado(r.Id, empresa.NomeExibicao, empresa.DsEmail, TipoUsuario.Empresa);
        }
        else
        {
            var pro = new ProfissionalDTO
            {
                NmProfissional = Form.Nome.Trim(), DsUser = Form.Usuario.Trim(), DsEmail = Form.Email.Trim(),
                NroCPF = Form.Cpf, NroTelefone = Form.Telefone, DtNascimento = Form.Nascimento!.Value,
                DsSexo = Form.Sexo, DtTermos = agora, DsPrivacidade = agora
            };
            r = await cadastro.CadastrarProfissionalAsync(pro, Form.Senha);
            novo = new UsuarioLogado(r.Id, pro.NmProfissional, pro.DsEmail, TipoUsuario.Profissional);
        }

        if (!r.Sucesso)
        {
            Erro = r.Erro;
            return Page();
        }

        await HttpContext.SignInAsync(novo.ParaPrincipal());
        TempData["Mensagem"] = "Cadastro feito! Complete seu perfil para aparecer melhor para as empresas.";
        return Redirect(novo.PainelUrl());
    }

    public class CadastroInput
    {
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "Campo Usuário é obrigatório")]
        public string Usuario { get; set; } = "";

        [Required(ErrorMessage = "Escolha o tipo de usuário")]
        public TipoUsuario? Tipo { get; set; }

        [Required(ErrorMessage = "Campo Data é obrigatório")]
        public DateTime? Nascimento { get; set; }

        [Required(ErrorMessage = "Campo CPF é obrigatório")]
        public string Cpf { get; set; } = "";

        [Required(ErrorMessage = "Campo Telefone é obrigatório")]
        public string Telefone { get; set; } = "";

        [Required(ErrorMessage = "Escolha uma opção")]
        public string Sexo { get; set; } = "";

        [Required(ErrorMessage = "Campo E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O e-mail é inválido!")]
        public string Email { get; set; } = "";

        public string? NomeFantasia { get; set; }
        public string? Cnpj { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        public string Senha { get; set; } = "";

        [Required(ErrorMessage = "Confirme a senha")]
        public string ConfirmarSenha { get; set; } = "";

        public bool AceitaPolitica { get; set; }
        public bool AceitaTermos { get; set; }
    }
}
