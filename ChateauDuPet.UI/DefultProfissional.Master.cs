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
    public partial class DefultProfissional : System.Web.UI.MasterPage
    {
        int idProfissional = Sessao.IdProfissional;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sessao.IdProfissional != 0)
            {
                int idProfissional = Sessao.IdProfissional;
                string EmailProfissional = Sessao.EmailUser;

                if (!IsPostBack)
                {
                    MenuPro();
                }
            }

             

        }
        public void MenuPro()
        { 
            ProfissionalBLL SelecionaBLL = new ProfissionalBLL();
            ProfissionalDTO SelecinaDTO = new ProfissionalDTO();

            rptMenu.DataSource = SelecionaBLL.FiltrarID(idProfissional);
            rptMenu.DataBind(); 
        }

        protected void btnVermais_Click(object sender, EventArgs e)
        {

        }

        protected void Sair_Click(object sender, EventArgs e)
        {
            if (Sessao.IdProfissional > 0 )
            {
                Sessao.IdProfissional = 0;
                Sessao.EmailUser = null;
                Response.Redirect("~/Index.aspx");
            }

        }
    }
}