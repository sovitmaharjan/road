using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.systemSetup.roster.workHour {
    public partial class workHourStatus : System.Web.UI.Page {
        
        attendance blu = new attendance();

        protected void Page_Load(object sender, EventArgs e) {

            int workId = Convert.ToInt32(Request.Params["b80bb7740288fda1f201890375a60c8f"]);
            blu.workHourStatus(workId);
            Response.Redirect("workHourList");
        }
    }
}