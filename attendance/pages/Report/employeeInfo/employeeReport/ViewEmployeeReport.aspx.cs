using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.employeeInfo.employeeReport {
    public partial class employeeReportList: System.Web.UI.Page {
        attendance blu = new attendance();
        string query;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                int status_id = int.Parse(Server.UrlDecode(Request.QueryString["status_id"].ToString()));
                string status_name = Server.UrlDecode(Request.QueryString["status_name"].ToString());
                int dept_id = int.Parse(Server.UrlDecode(Request.QueryString["dept_id"].ToString()));
                string dept_name = Server.UrlDecode(Request.QueryString["dept_name"].ToString());
                if (dept_id == 0) {
                    query = "SELECT * FROM view_emp_info where STATUS_ID = " + status_id;
                    lblDept.Text = dept_name;
                    
                } else {
                    query = "SELECT * FROM view_emp_info where STATUS_ID = " + status_id + " and DEPT_ID = " + dept_id;
                    lblDept.Text = "ALL";
                    
                }
                lblStatus.Text = status_name;
                DataTable dt = blu.EmployeeReport(query);
                GridView.DataSource = dt;
                GridView.DataBind();
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e) {
            Response.Redirect("Reports_EmployeeInformation");
        }

        protected void BtnExport_Click(object sender, EventArgs e) {

        }
    }
}