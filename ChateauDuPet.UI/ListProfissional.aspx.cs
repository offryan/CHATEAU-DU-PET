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
    public partial class ListProfissional : System.Web.UI.Page
    {

        ProfissionalDTO objModelo = new ProfissionalDTO();
        ProfissionalBLL objBLL = new ProfissionalBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopularGV();
            }

            rptListPro.DataSource = objBLL.FiltarP();
            rptListPro.DataBind();

        } 

        protected void btnPerfil_Click(object sender, ImageClickEventArgs e)
        {

        }
        public void PopularGV()
        {
            gv2.DataSource = objBLL.ListaProfissional();
            gv2.DataBind();
            lblMessage.Text = string.Empty;
        }

       

        

        //edit
        protected void gv2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv2.EditIndex = e.NewEditIndex;
            PopularGV();
        }

        //cancel
        protected void gv2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv2.EditIndex = -1;
            PopularGV();
        }

        protected void gv2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            objModelo.IdProfissional = Convert.ToInt32(gv2.Rows[e.RowIndex].FindControl("idProfissional") as Label);
            objModelo.Nome = (gv2.Rows[e.RowIndex].FindControl("Nome") as TextBox).Text.Trim();
            objModelo.Email = (gv2.Rows[e.RowIndex].FindControl("Email") as TextBox).Text.Trim();
            objModelo.User = (gv2.Rows[e.RowIndex].FindControl("User") as TextBox).Text.Trim();

            //saving image
            if ((gv2.Rows[e.RowIndex].FindControl("fUp1") as FileUpload).HasFile)
            {
                var str = (gv2.Rows[e.RowIndex].FindControl("fUp1") as FileUpload).FileName.Trim();

                (gv2.Rows[e.RowIndex].FindControl("fUp1") as FileUpload).PostedFile.SaveAs(Server.MapPath("~/Images" + "/" + str));
                string CaminhoImg = "~/Images" + "/" + str.ToString();
                objModelo.UrlImage = CaminhoImg;

            }



            objModelo.IdProfissional = Convert.ToInt32(gv2.DataKeys[e.RowIndex].Value.ToString());

            //chamando o metodo
            objBLL.EditarPro(objModelo);

            gv2.EditIndex = -1;
            PopularGV();
            lblMessage.Text = "O Profissional" + objModelo.Nome + " foi editado com sucesso!!";
        }

        protected void gv2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objModelo.IdProfissional = Convert.ToInt32(gv2.DataKeys[e.RowIndex].Value.ToString());
            objBLL.ExcluirProfissional(objModelo.IdProfissional);
            PopularGV();
            (gv2.FooterRow.FindControl("lblIDProfissonalFooter") as TextBox).Focus();

            lblMessage.Text = "O Profissional " + objModelo.Nome + " foi eliminado com sucesso!!";
        }

        protected void gv2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv2.PageIndex = e.NewPageIndex;
            this.PopularGV();
        }
    }
}
