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
    public partial class Cadastro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {


            try
            {

                if (cbTermos.Checked && cbPolitica.Checked)
                {

                    if (DLLTipoUSer.SelectedItem.ToString() == "Profissional")
                    {
                        string objEmailP = txtEmail.Text.Trim();
                        string objCPF = txtCpf.Text.Trim();
                        string objUser = txtUser.Text.Trim();
                        ProfissionalDTO objAutenticaEmailDTO = new ProfissionalDTO();
                        ProfissionalBLL objAutenticaEmailBLL = new ProfissionalBLL();

                        objAutenticaEmailDTO = objAutenticaEmailBLL.AutenticaEmailBLL(objEmailP);

                        if (objAutenticaEmailDTO == null)
                        {

                            ProfissionalDTO objAutenticaUserDTO = new ProfissionalDTO();
                            ProfissionalBLL objAutenticaUserBLL = new ProfissionalBLL();
                            objAutenticaUserDTO = objAutenticaUserBLL.AutenticaUserBLL(objUser);
                            if (objAutenticaUserDTO == null)
                            {

                                ProfissionalDTO objAutenticaCPFDTO = new ProfissionalDTO();
                                ProfissionalBLL objAutenticaCPFBLL = new ProfissionalBLL();
                                objAutenticaCPFDTO = objAutenticaCPFBLL.AutenticaCPFBLL(objCPF);
                                if (objAutenticaCPFDTO == null)
                                {
                                    ProfissionalDTO objDTO = new ProfissionalDTO();
                                    ProfissionalBLL objCad = new ProfissionalBLL();

                                    objDTO.Nome = txtNome.Text;
                                    objDTO.CPF = txtCpf.Text;
                                    objDTO.Email = txtEmail.Text;
                                    objDTO.Senha = senhaC.Text;
                                    objDTO.Telefone = txtTelefone.Text;
                                    objDTO.Nascimento = txtData.Text;
                                    objDTO.Sexo = DDLSexo.Text;
                                    objDTO.User = txtUser.Text;
                                    objDTO.Termos = DateTime.Now;
                                    objDTO.Privacidade = DateTime.Now;
                                    objDTO.FKTipoUser = Convert.ToInt32(DLLTipoUSer.SelectedValue);


                                    objCad.CadastrarProfissional(objDTO);

                                    Limpar();
                                    lblMensagem.Visible = false;

                                    lblMensagemCadastrado.Visible = true;
                                    lblMensagemCadastrado.Text = "Cadastrado com sucesso!";
                                }
                                else
                                {
                                    lblMensagemCadastrado.Visible = false;
                                    lblMensagem.Visible = true;
                                    lblMensagem.Text = "USUARIO já cadastrado!";

                                }
                            }
                            else
                            {
                                lblMensagemCadastrado.Visible = false;

                                lblMensagem.Visible = true;
                                lblMensagem.Text = "CPF já cadastrado!";

                            }
                        }
                        else
                        {
                            lblMensagemCadastrado.Visible = false;

                            lblMensagem.Visible = true;
                            lblMensagem.Text = "Email já cadastrado!";

                        }

                    }
                    if (DLLTipoUSer.SelectedItem.ToString() == "Empresa")
                    {
                        string objEmailE = txtEmail.Text;
                        string objUser = txtUser.Text;
                        string objCPF = txtCpf.Text;

                        EmpresaDTO objAutenticaEmailDTO = new EmpresaDTO();
                        EmpresaBLL objAutenticaEmailBLL = new EmpresaBLL();

                        objAutenticaEmailDTO = objAutenticaEmailBLL.AutenticaEmailBLL(objEmailE);

                        if (objAutenticaEmailDTO == null)
                        {

                            EmpresaDTO objAutenticaUserDTO = new EmpresaDTO();
                            EmpresaBLL objAutenticaUserBLL = new EmpresaBLL();
                            objAutenticaUserDTO = objAutenticaUserBLL.AutenticaUserBLL(objUser);
                            if (objAutenticaUserDTO == null)
                            {

                                EmpresaDTO objAutenticaCPFDTO = new EmpresaDTO();
                                EmpresaBLL objAutenticaCPFBLL = new EmpresaBLL();
                                objAutenticaCPFDTO = objAutenticaCPFBLL.AutenticaCPFBLL(objCPF);
                                if (objAutenticaCPFDTO == null)
                                {


                                    EmpresaDTO objDTO = new EmpresaDTO();
                                    EmpresaBLL objCad = new EmpresaBLL();

                                    objDTO.Recrutador = txtNome.Text;
                                    objDTO.CPF = txtCpf.Text;
                                    objDTO.Email = txtEmail.Text;
                                    objDTO.SenhaEmpresa = senhaC.Text;
                                    objDTO.Telefone = txtTelefone.Text;
                                    objDTO.Nascimento = txtData.Text;
                                    objDTO.Sexo = DDLSexo.Text;
                                    objDTO.User = txtUser.Text;
                                    objDTO.Termos = DateTime.Now;
                                    objDTO.Privacidade = DateTime.Now;
                                    objDTO.FKTipoUser = Convert.ToInt32(DLLTipoUSer.SelectedValue);
                                    objCad.CadastrarEmpresa(objDTO);

                                    Limpar(); 
                                    lblMensagemCadastrado.Visible = true;
                                    lblMensagemCadastrado.Text = "Cadastrado com sucesso!";
                                }
                                else
                                {
                                    lblMensagem.Visible = true;

                                    lblMensagem.Text = "USUARIO já cadastrado!";

                                }
                            }
                            else
                            {
                                lblMensagem.Visible = true;

                                lblMensagem.Text = "CPF já cadastrado!";

                            }
                        }
                        else
                        {
                            lblMensagem.Visible = true;
                            lblMensagem.Text = "Email já cadastrado!";

                        }

                    }

                }
                else
                {
                    lblMensagem.Visible = true;
                    lblMensagem.Text = "Selecione os Termos de uso e as Pilítica de privacidade!";
                    

                }
                
            }
            catch (Exception)
            {
                Limpar();
                lblMensagem.Visible = true;
                lblMensagem.Text = "Erro ao cadastrar!";

            }

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {

            Limpar();
        }

        public void Limpar()
        {
            txtNome.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtEmail.Text = string.Empty;
            senha.Text = string.Empty;
            senhaC.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtData.Text = string.Empty;
            DDLSexo.Text = string.Empty;
            txtUser.Text = string.Empty;
            DLLTipoUSer.SelectedValue = string.Empty;
            txtNome.Focus();
        }
        protected void BtnCadastrar_Click1(object sender, EventArgs e)
        {

            try
            {

                if (cbTermos.Checked == cbPolitica.Checked)
                {

                    if (DLLTipoUSer.SelectedItem.ToString() == "Profissional")
                    {

                        ProfissionalDTO objDTO = new ProfissionalDTO();
                        ProfissionalBLL objCad = new ProfissionalBLL();

                        objDTO.Nome = txtNome.Text;
                        objDTO.CPF = txtCpf.Text;
                        objDTO.Email = txtEmail.Text;
                        objDTO.Senha = senhaC.Text;
                        objDTO.Telefone = txtTelefone.Text;
                        objDTO.Nascimento = txtData.Text;
                        objDTO.Sexo = DDLSexo.Text;
                        objDTO.User = txtUser.Text;
                        objDTO.Termos = DateTime.Now;
                        objDTO.Privacidade = DateTime.Now;
                        objDTO.FKTipoUser = Convert.ToInt32(DLLTipoUSer.SelectedValue);


                        objCad.CadastrarProfissional(objDTO);


                        lblMensagem.Text = "Cadastrado com sucesso!";


                    }
                    if (DLLTipoUSer.SelectedItem.ToString() == "Empresa")
                    {
                        EmpresaDTO objDTO = new EmpresaDTO();
                        EmpresaBLL objCad = new EmpresaBLL();

                        objDTO.Recrutador = txtNome.Text;
                        objDTO.CPF = txtCpf.Text;
                        objDTO.Email = txtEmail.Text;
                        objDTO.SenhaEmpresa = senhaC.Text;
                        objDTO.Telefone = txtTelefone.Text;
                        objDTO.Nascimento = txtData.Text;
                        objDTO.Sexo = DDLSexo.Text;
                        objDTO.User = txtUser.Text;
                        objDTO.Termos = DateTime.Now;
                        objDTO.Privacidade = DateTime.Now;
                        objDTO.FKTipoUser = Convert.ToInt32(DLLTipoUSer.SelectedValue);
                        objCad.CadastrarEmpresa(objDTO);

                        Limpar();
                        lblMensagem.Text = "Cadastrado com sucesso!";

                    }
                }
                else
                {
                    lblMensagem.Text = "Selecione a os campos acima!";

                }
            }
            catch (Exception)
            {
                Limpar();
                lblMensagem.Text = "Erro ao cadastrar!";

            }

        }
    }
}