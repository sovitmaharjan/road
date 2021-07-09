using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.logHistory
{
    public partial class test : System.Web.UI.Page
    {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e)
        {
            string index = Request.Params["indx"].ToString();
            int empId = Convert.ToInt32(Request.Params["empId"]);
            string fromDate = Request.Params["fromDate"];
            string toDate = Request.Params["toDate"];
            blu.updatelogHistory(index);
            Response.Redirect("logHistoryList?empId=" + empId + "&fromDate=" + fromDate + "&toDate=" + toDate);
        }
    }
}