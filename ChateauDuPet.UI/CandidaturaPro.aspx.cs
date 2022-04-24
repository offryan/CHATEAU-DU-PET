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
    public partial class CandidaturaPro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idProfissional = Convert.ToInt32(Request.QueryString["id"]);

            ProfissionalBLL objProPefil = new ProfissionalBLL();

            ProfissionalDTO profissionalDTO = new ProfissionalDTO();

            CandidatosDTO CanditatoDTO = new CandidatosDTO();
            CandidatosBLL CanditatoBLL = new CandidatosBLL();
            //rptCandidatura.DataSource = objProPefil.FiltrarID(idProfissional);
            //rptCandidatura.DataBind();

            


        }
    }
}