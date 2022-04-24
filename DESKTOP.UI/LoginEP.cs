using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChateauDuPet.BLL;
using ChateauDuPet.DTO;

namespace ChateauBanco.UI
{
    public partial class LoginEP : Form
    {
        public LoginEP()
        {
            InitializeComponent();
        }

        private void LoginEP_Load(object sender, EventArgs e)
        {
            txtEmail.Focus(); 
            //pegando informação digitada pelo usuario
            string objUser = txtEmail.Text;
            string objSenha = txtSenha.Text;
            string objTipo = BoxTipo.Text;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
             

            if (BoxTipo.SelectedItem.ToString() == "Selecione uma opção")
            {
                string objEmailA = txtEmail.Text;
                string objSenhaA = txtSenha.Text;
                AdministrativoDTO objModeloExp = new AdministrativoDTO();
                AdministrativoBLL objValidaExp = new AdministrativoBLL();

                objModeloExp = objValidaExp.AutenticarAdministrativo(objEmailA, objSenhaA);
                if (objModeloExp != null)
                {
                    Sessao.EmailUser = txtEmail.Text.Trim();

                    MainProfissional obj = new MainProfissional();
                    obj.Show();
                    this.Visible = false;

                }
            }
            try
            {
                if (BoxTipo.SelectedItem.ToString() == "Profissional")
                {
                    string objEmailP = txtEmail.Text.Trim();
                    string objSenhaP = txtSenha.Text.Trim();
                    //instanciado obj DTO
                    ProfissionalDTO objModelo = new ProfissionalDTO();
                    ProfissionalBLL objValida = new ProfissionalBLL();

                    objModelo = objValida.AutenticarProfissional(objEmailP, objSenhaP);

                    if (objModelo != null)
                    {
                        Sessao.EmailUser = txtEmail.Text.Trim();

                        MainProfissional obj2 = new MainProfissional();

                        obj2.Show();
                        this.Visible = false;

                    }

                }
                if (BoxTipo.SelectedItem.ToString() == "Empresa")
                {

                    string objEmailE = txtEmail.Text;
                    string objSenhaE = txtSenha.Text;

                    EmpresaDTO objModeloExp = new EmpresaDTO();
                    EmpresaBLL objValidaExp = new EmpresaBLL();

                    objModeloExp = objValidaExp.AutenticarEmpresa(objEmailE,objSenhaE);
                     
                    if (objModeloExp != null)
                    {
                        objModeloExp.IdEmpresa = Sessao.IdEmpresa;
                        Sessao.EmailUser = objModeloExp.Email;
                        MainEmpresa obj2 = new MainEmpresa();
                        obj2.Show();
                        this.Visible = false;

                    }
                } 
            }
            catch (Exception ex)
            {

                Limpar();
                MessageBox.Show("Usuario não Invalido !! " + ex.Message); 
            }
        }
            public void Limpar()
        {
            txtEmail.Text = txtSenha.Text = string.Empty;
            BoxTipo.SelectedItem = null;
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
