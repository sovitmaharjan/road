using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.hrManagement.transfer {
    public partial class transferList : System.Web.UI.Page {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                DataTable dt = blu.getTransferList();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void BtnNew_Click(object sender, EventArgs e) {
            Response.Redirect("addTransfer");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) {
            GridViewRow gr = GridView1.SelectedRow;
            Response.Redirect("transferDetails?Emp_id=" + gr.Cells[7].Text);
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
            //e.Row.Cells[7].Visible = false;
        }
    }
}