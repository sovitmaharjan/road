using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.leaveReport.DepartmentwiseLeaveBalanceSummary
{
    public partial class DepartmentwiseLeaveTakenSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if(TxtStartDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Select Start Date. !!!','warning')", true);
            }else if(TxtEndDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Select End Date. !!!','warning')", true);
            }
            else
            {
                DateTime sdate = Convert.ToDateTime(TxtStartDate.Text);
                DateTime edate = Convert.ToDateTime(TxtEndDate.Text);
                Response.Redirect(String.Format("ViewDepartmentwiseLeaveBalanceSummary?sdate={0}&edate={1}", Server.UrlEncode(sdate.ToString()), Server.UrlEncode(edate.ToString())));
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentwiseLeaveBalanceSummary");
        }
    }
}