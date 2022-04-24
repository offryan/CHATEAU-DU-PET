using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChateauBanco.UI
{
    public partial class CadastroUser : Form
    {
        public CadastroUser()
        {
            InitializeComponent();
        }


        private void CadastroUser_Load(object sender, EventArgs e)
        {

            Box1.Visible = false;
            comboBox1.Focus();
        }
    }
}
