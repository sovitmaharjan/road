using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.outstation {
    public partial class outstationList : System.Web.UI.Page {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                DataTable dt = blu.getOutstation();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e) {
            Response.Redirect("outstation");
        }
    }
}