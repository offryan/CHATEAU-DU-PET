using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChateauDuPet.DTO;
using ChateauDuPet.BLL;

namespace ChateauDuPet.UI.Empresa
{
    public partial class Vagas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            int FKEmpresa = Convert.ToInt32(Request.QueryString["id"]);
          VagaDTO  objDTO = new VagaDTO();
            VagaBLL objBLL = new VagaBLL(); 

            objDTO.Vaga = txtTitulo.Text;
            objDTO.Experiencia = ddllExperiencia.SelectedValue;
            objDTO.Registro = ddllRegistro.SelectedValue;
            objDTO.Descricao = txtMensagem.Text;
            objDTO.Sexo = ddllSexo.SelectedValue;
            objDTO.Validade = ddllValidade.SelectedValue;
            objDTO.DataPublicacao = DateTime.Now;
            objDTO.FKEmpresa = FKEmpresa;


            objBLL.CadastrarVaga(objDTO);


        }
    }
}