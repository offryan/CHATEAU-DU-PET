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
    public partial class MainEmpresa : Form
    {
        public MainEmpresa()
        {
            InitializeComponent();
            EmpresaDTO objDTO = new EmpresaDTO();
            EmpresaBLL objBLL = new EmpresaBLL();

            objBLL.SelecionarID(Sessao.IdEmpresa);

            gbPerfil.Visible = false;
            gbCandidatos.Visible = false;
            gbCadastroV.Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {  
            VagaBLL objCadastrarVaga = new VagaBLL();
            VagaDTO objDTO = new VagaDTO();

            objDTO.Vaga = txtTitulo.Text;
            objDTO.Experiencia = cbExperiencia.ToString();
            objDTO.Registro = cbRegistro.ToString();
            objDTO.Descricao = txtdescricao.Text;
            objDTO.Sexo = cbSexo.ToString();
            objDTO.Validade = cbValidade.Text;
            objDTO.DataPublicacao = DateTime.Now;
            objDTO.FKEmpresa = Convert.ToInt32(Sessao.IdEmpresa);



            objCadastrarVaga.CadastrarVaga(objDTO);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        public void Limpar()
        {

            txtTitulo.Text = string.Empty;
            txtdescricao.Text = string.Empty;
            cbExperiencia.SelectedItem = null;
            cbRegistro.SelectedItem = null;
            cbSexo.SelectedItem = null;
            cbValidade.SelectedItem = null;
        }

        private void btnCadastrarVagas_Click(object sender, EventArgs e)
        {
            txtTitulo.Focus();

            gbCandidatos.Visible = false;
            gbPerfil.Visible = false;
            gbCadastroV.Visible = true;




        }

        private void gbCandidatos_Enter(object sender, EventArgs e)
        {
            gbPerfil.Visible = false;
            gbCadastroV.Visible = false;
            gbCandidatos.Visible = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnPerfil_Click(object sender, EventArgs e)
        {
            gbCadastroV.Visible = false;
            gbCandidatos.Visible = false;
            gbPerfil.Visible = true;
        }

        private void BtnCandidatos_Click(object sender, EventArgs e)
        {

        }

        private void MainEmpresa_Load(object sender, EventArgs e)
        {

        }
    }
}
