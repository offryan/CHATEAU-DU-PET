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
    public partial class MainAdm : Form
    {
        public MainAdm()
        {
            
        }

        private void MainAdm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            gBox1.Visible = true;
            // checando preencimento do compo id
            int codigo;
            if (!int.TryParse(txtId.Text, out codigo))
            {
                MessageBox.Show("Digite o ID Do usuario");
                txtId.Focus();
                btnPesquisar.Enabled = true;
                return;

            }

            // chamando metodos 
            codigo = Convert.ToInt32(txtId.Text);
            ProfissionalDTO objPesquisa = new ProfissionalDTO(); // metodo
            ProfissionalBLL objPesqBLL = new ProfissionalBLL(); //metodo
            objPesquisa = objPesqBLL.SelecionarPro (codigo);
            if (objPesquisa.Nome != null)
            {
                //habilitando componentes 

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void gBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
