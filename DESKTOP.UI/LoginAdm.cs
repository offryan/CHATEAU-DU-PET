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
    //public partial class LoginAdm : Form
    //{
    //    public LoginAdm()
    //    {
    //        InitializeComponent();
    //    }

    //    private void LoginAdm_Load(object sender, EventArgs e)
    //    {
    //        txtEmail.Focus();
    //    }

    //    private void btnCancelar_Click(object sender, EventArgs e)
    //    {
    //        txtEmail.Text = txtSenha.Text = string.Empty;
    //        txtEmail.Focus();
    //    }

    //    private void btnEntrar_Click(object sender, EventArgs e)
    //    {

    //        try
    //        {
    //            //pegando informação digitada pelo usuario
    //            string objUser = txtEmail.Text;
    //            string objSenha = txtSenha.Text;

    //            //instanciado obj DTO
    //            UsuarioDTO objModelo = new UsuarioDTO();
    //            UsuarioBLL objValida = new UsuarioBLL();
    //            objModelo = objValida.AutenticaUser(objUser, objSenha);

    //            if (objModelo != null)
    //            {
    //                switch (objModelo.IdTipoUsuario)
    //                {
    //                    case 1:
    //                        Session.nomeUsuario = txtEmail.Text.Trim();
    //                        MainAdm obj = new MainAdm();
    //                        obj.Show();
    //                        this.Visible = false;
    //                        break;

    //                    case 2:
    //                        Session.nomeUsuario = txtEmail.Text.Trim();
    //                        MainProfissional obj2 = new MainProfissional();
    //                        obj2.Show();
    //                        this.Visible = false;
    //                        break;




    //                }
    //            }
    //            else
    //            {
    //                MessageBox.Show("Deu problema denovo!");
    //            }


    //        }
    //        catch (Exception ex)
    //        {

    //            MessageBox.Show("Usuario não cadastrado !! " + ex.Message);
    //        }
    //    }

    //    private void btnSair_Click(object sender, EventArgs e)
    //    {
    //        Application.Exit();
    //    }
    //}

}

