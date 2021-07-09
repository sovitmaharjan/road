using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.attendanceReport.ForceAttendance
{
    public partial class ForceAttendanceList : System.Web.UI.Page
    {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DateTime Startdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["startDate"].ToString()));
                DateTime Enddate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["endDate"].ToString()));
                string dept_id = Server.UrlDecode(Request.QueryString["dept_id"].ToString());
                int emp_id = int.Parse(Server.UrlDecode(Request.QueryString["emp_id"].ToString()));

                lblStartDate.Text = Startdate.ToString("yyyy-MM-dd");
                lblEndDate.Text = Enddate.ToString("yyyy-MM-dd"); 

                DataTable dt = blu.ForceAttendance(Startdate, Enddate, dept_id, emp_id);
                GridView.DataSource = dt;
                GridView.DataBind();
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForceAttendanceForm");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = blu.GetAllOrg();
            lblOrgName.Text = dt.Rows[0]["Org_Name"].ToString();
            lblOrgFullAddress.Text = dt.Rows[0]["Full_Address"].ToString();
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Force Attendance Report.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
            Panel1.RenderControl(htw);
            Panel2.RenderControl(htw);
            Panel3.RenderControl(htw);

            GridView.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}