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
    public partial class DefultADM : System.Web.UI.MasterPage
    {

        AdministrativoBLL objSelecionarBLL = new AdministrativoBLL();
        AdministrativoDTO objSelecionarDTO = new AdministrativoDTO();
        int idOperador = Sessao.IdAdministrativo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sessao.IdAdministrativo != 0)
            {
                AdministrativoBLL objSelecionarBLL = new AdministrativoBLL();
                AdministrativoDTO objSelecionarDTO = new AdministrativoDTO();
                rptMenu.DataSource = objSelecionarBLL.FiltrarAdministrativoID(Sessao.IdAdministrativo);


                if(!IsPostBack) 
                {
                    MenuPro();
                }
            }



        }
        public void MenuPro()
        {

            rptMenu.DataSource = objSelecionarBLL.FiltrarAdministrativoID(idOperador);
            rptMenu.DataBind();
        }

        protected void Sair_Click(object sender, EventArgs e)
        {
            if (Sessao.IdAdministrativo > 0)
            {
                Sessao.IdAdministrativo = 0;
                Sessao.EmailUser = null;
                Response.Redirect("~/index.aspx");
            }
        }
    }
}