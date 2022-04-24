using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChateauDuPet.DTO;
using ChateauDuPet.BLL;

namespace ChateauDuPet.UI.MainProfissional
{
    public partial class Perfil_Profissional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            int idProfissional = Convert.ToInt32(Request.QueryString["id"]);
            int idpro = Sessao.IdProfissional;

            if (idpro == idProfissional)
            {



                ProfissionalBLL SelecionaBLL = new ProfissionalBLL();
                ProfissionalDTO SelecinaDTO = new ProfissionalDTO();

                rptPerfil.DataSource = SelecionaBLL.FiltrarID(idProfissional);
                rptPerfil.DataBind();
                rptEndereco.DataSource = SelecionaBLL.FiltrarID(idProfissional);
                rptEndereco.DataBind();

                //lblNome.Text = SelecinaDTO.Nome;
                ////lblEmail.Text = SelecinaDTO.Email;
                ////lblTel.Text = SelecinaDTO.Telefone;
                //lblBiografiaPro.Text = SelecinaDTO.Biografia;
                //imagePro.ImageUrl = SelecinaDTO.UrlImage.Replace("~", ".");
                //lblFormacaoEscolar.Text = SelecinaDTO.FormacaoEscolar;
                //lblSexo.Text = SelecinaDTO.Sexo;
                //lblEndereco.Text = SelecinaDTO.Endereco;
                //lblNumero.Text = SelecinaDTO.NroEndereco;
                //lblComplemento.Text = SelecinaDTO.Complemento;
                //lblCep.Text = SelecinaDTO.CEP;
                //lblBairro.Text = SelecinaDTO.Bairro;
                //lblCidade.Text = SelecinaDTO.Cidade;
                //lblUF.Text = SelecinaDTO.UF;
                //lbluser.Text = SelecinaDTO.User;


                CertificadoDTO objCerDTO = new CertificadoDTO();
                CertificadoBLL objCerBLL = new CertificadoBLL();
                rptCurso.DataSource = objCerBLL.FiltroCerID(idProfissional);
                rptCurso.DataBind();
                //btnCadastrarCert.Visible = true;

                //CertificadoDTO objcertificadoDTO = objCerBLL.SelecionarCertificado(Sessao.IdProfissional);

                //lblCurso.Text = objcertificadoDTO.Curso;
                //lblInstituicao.Text = objcertificadoDTO.Instituicao;
                //lblDataInicio.Text = objcertificadoDTO.DataInicio;
                //lblDataConclusao.Text = objcertificadoDTO.DataConclusao;
                //lblDescricao.Text = objcertificadoDTO.Descricao;

                ExperienciaDTO objExpDTO = new ExperienciaDTO();
                ExperienciaBLL objExpBLL = new ExperienciaBLL();
                rptExperiencia.DataSource = objExpBLL.FiltroExpID(idProfissional);
                rptExperiencia.DataBind();
                //btnCadastrarExpe.Visible = true;


            }

            //lblCargo.Text = objExpDTO.Cargo;
            //lblEmpresa.Text = objExpDTO.Empresa;
            //lblTipoContrato.Text = objExpDTO.TipoContrato;
            //lblLocalidade.Text = objExpDTO.Localidade;
            //lblDataInicio.Text = objExpDTO.DataInicio;
            //lblDataFinal.Text = objExpDTO.DataFinal;



        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}