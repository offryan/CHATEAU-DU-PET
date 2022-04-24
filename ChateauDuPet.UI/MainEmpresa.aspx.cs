using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChateauDuPet.BLL;
using ChateauDuPet.DTO;

namespace ChateauDuPet.UI
{
    public partial class MainEmpre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            int idProfissional = Convert.ToInt32(Request.QueryString["id"]);

            ProfissionalBLL objProPefil = new ProfissionalBLL();

            ProfissionalDTO profissionalDTO = new ProfissionalDTO();
            rptPro.DataSource = objProPefil.FiltarP();
            
            rptPro.DataBind();



            int idVagaM = Convert.ToInt32(Request.QueryString["id"]);
            VagaBLL objVagaBLL = new VagaBLL();

            VagaDTO objDTO = new VagaDTO();

            rptVaga1.DataSource = objVagaBLL.FiltrarVaga();
            rptVaga1.DataBind();

        }
    }
}