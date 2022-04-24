using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChateauDuPet.DTO;
using ChateauDuPet.BLL;

namespace ChateauDuPet.UI
{
    public partial class AddCertificados : System.Web.UI.Page
    {

        CertificadoBLL objCerBLL = new CertificadoBLL();
        CertificadoDTO objCerDTO = new CertificadoDTO();
         

        protected void Page_Load(object sender, EventArgs e)
        {
            

            int idpro = Sessao.IdProfissional;
            int idProfissional = Convert.ToInt32(Request.QueryString["IdProfissional"]);

            int idCertificado = Convert.ToInt32(Request.QueryString["IdCertificado"]);




            if (idCertificado != 0)
            { 
                rptCurso.Visible = true;

                rptCurso.DataSource = objCerBLL.FiltroCerID(idCertificado);
                rptCurso.DataBind();



            }
            if (idProfissional != 0)
            {
                RptCertificadoNEW.Visible = true;

            }
        }

        protected void Cadastrar_Click(object sender, EventArgs e)
        {
            int idpro = Sessao.IdProfissional;
            int idProfissional = Convert.ToInt32(Request.QueryString["IdProfissional"]);

            if (idpro == idProfissional)
            {

                //objCerDTO.Curso = txtCurso1.Text;
                //objCerDTO.Instituicao = txtInstituiçao1.Text;
                //objCerDTO.DataInicio = txtDataInicial1.Text;
                //objCerDTO.DataConclusao = txtDataFinal1.Text;
                //objCerDTO.Descricao = txtDescricaoCurso1.Text;
                //objCerDTO.FKProfissional = idProfissional;

                //objCerBLL.CadastrarCertificado(objCerDTO);
                //Limpar();

                lblMensagem.Text = "Cadastrado com Sucesso!";
            }
            else
            {

            }

        }

        protected void EditarCertificado_Click(object sender, EventArgs e)
        {

            int idpro = Sessao.IdProfissional;

            int idCertificado = Convert.ToInt32(Request.QueryString["IdCertificado"]);
            //if (idpro !=  0)
            //{ objCerDTO.Curso = txtCurso.Text;
            ////    objCerDTO.Instituicao = txtInstituiçao.Text;
            ////    objCerDTO.DataInicio = txtDataInicial.Text;
            ////    objCerDTO.DataConclusao = txtDataFinal.Text;
            ////    objCerDTO.Descricao = txtDescricaoCurso.Text;
            ////    objCerDTO.FKProfissional = idpro;

            ////    objCerBLL.EditarCertificado(objCerDTO);
            ////    lblMensagem.Text = "Cadastrado com Sucesso!";

            ////    Limpar();
            //}
        }
        public void Limpar()
        {
        //    txtCurso.Text = string Empty
        //    txtInstituiçao.Text = string Empty;
        //    txtDataInicial.Text = string Empty;
        //    txtDataFinal.Text = string Empty;
        //    txtDescricaoCurso.Text = string Empty;
      
        //    txtCurso1.Text = string Empty;
        //    txtInstituiçao1.Text = string Empty;
        //    txtDataInicial1.Text = string Empty;
        //    txtDataFinal1.Text = string Empty;
        //    txtDescricaoCurso1.Text = string Empty;
        }
    }
}