using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChateauDuPet.BLL;
using ChateauDuPet.DTO;


namespace ChateauDuPet.UI
{
    public partial class EditarPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int IDProfissional = Sessao.IdProfissional;

            ProfissionalDTO objDTO = new ProfissionalDTO();
            ProfissionalBLL objCad = new ProfissionalBLL();
            objDTO = objCad.SelecionarPro(Sessao.IdProfissional);

            objDTO.Nome = txtNome.Text;
            objDTO.CPF = lblCPF.Text;
            objDTO.Email = txtEmail.Text;
            objDTO.Telefone = txtTelefone.Text;
            objDTO.Nascimento = txtData.Text;
            objDTO.Sexo = DDLSexo.Text;
            objDTO.User = txtUser.Text;

            objDTO.Endereco = txtRua.Text;
            objDTO.NroEndereco = txtNumero.Text;
            objDTO.Complemento = txtComplemento.Text;
            objDTO.CEP = txtCEP.Text;
            objDTO.Bairro = txtBairro.Text;
            objDTO.Cidade = txtCidade.Text;
            objDTO.UF = ddlEstado.Text;

            ExperienciaBLL objExBLL = new ExperienciaBLL();
            ExperienciaDTO objExDTO = new ExperienciaDTO();
            //objExDTO = objExBLL.SelecionaExperiencia(IDProfissional);
            objExDTO.Cargo = txtCargo.Text;
            objExDTO.Empresa = txtEmpresa.Text;
            objExDTO.DataInicio = txtDataInicio.Text;
            objExDTO.DataFinal = txtDataFinal.Text;
            objExDTO.FKProfissional = IDProfissional;


            CertificadoBLL objCerBLL = new CertificadoBLL();
            CertificadoDTO objCerDTO = new CertificadoDTO();
            //objCerDTO = objCerBLL.SelecionarCertificado(IDProfissional);
            objCerDTO.Curso = txtCurso.Text;
            objCerDTO.Instituicao = txtInstituiçao.Text;
            objCerDTO.DataInicio = txtDataInicio.Text;
            objCerDTO.DataInicio = txtDataInicio.Text;
            objCerDTO.Descricao = txtDescricaoCurso.Text;
            objCerDTO.FKProfissional = IDProfissional;

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {

        }

        protected void imagePro_Click(object sender, ImageClickEventArgs e)
        {
        }
    }
}