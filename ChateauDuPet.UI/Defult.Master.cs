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
    public partial class Defult : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Sessao.EmailUser == null)
            {
                Sessao.IdAdministrativo = 0;
                Sessao.IdProfissional = 0;
                Sessao.IdEmpresa = 0;
                Sessao.EmailUser = null;
            }

        }
          
        protected void BtnEntrar_Command(object sender, CommandEventArgs e)
        {

        }
         
        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
           
        }
    }
}