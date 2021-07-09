using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.hrManagement.promotion {
    public partial class promotionList : System.Web.UI.Page {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                DataTable dt = blu.getPromotionList();
                //if (dt.Rows.Count == 0)
                //{
                //    Response.Redirect("AddPromotion.aspx");
                //}
                //else
                //{
                GridView1.DataSource = dt;
                GridView1.DataBind();
                //}
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e) {
            Response.Redirect("addPromotion");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) {
            GridViewRow gr = GridView1.SelectedRow;
            Response.Redirect("promotionDetails?EMP_ID=" + gr.Cells[5].Text);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
            //e.Row.Cells[5].Visible = true;
        }
    }
}