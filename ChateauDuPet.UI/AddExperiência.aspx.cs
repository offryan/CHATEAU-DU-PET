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
    public partial class AddExperiência : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idProfissional = Convert.ToInt32(Request.QueryString["id"]);

            ExperienciaBLL objExpBLL = new ExperienciaBLL();
            ExperienciaDTO objExpDTO = new ExperienciaDTO();
            objExpDTO = objExpBLL.SelecionaExperiencia(idProfissional);

             

        }
    }
}