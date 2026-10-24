using ChateauDuPet.BLL;
using ChateauDuPet.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChateauDuPet.Web.Pages.Profissionais;

// Currículos só aparecem para usuários logados; contato só para empresas, administradores e o próprio dono
[Authorize]
public class DetalheModel(PerfilBLL perfis) : PageModel
{
    public ProfissionalDTO Perfil { get; private set; } = null!;
    public List<ExperienciaDTO> Experiencias { get; private set; } = [];
    public List<CertificadoDTO> Certificados { get; private set; } = [];
    public bool MostrarContato { get; private set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var usuario = User.Logado()!;
        if (usuario.Tipo == TipoUsuario.Profissional && usuario.Id != id) return Forbid();
        if (await perfis.ObterProfissionalAsync(id) is not { } perfil) return NotFound();

        Perfil = perfil;
        Experiencias = await perfis.ExperienciasAsync(id);
        Certificados = await perfis.CertificadosAsync(id);
        MostrarContato = true; // quem chega aqui é empresa, administrador ou o próprio profissional
        return Page();
    }
}
