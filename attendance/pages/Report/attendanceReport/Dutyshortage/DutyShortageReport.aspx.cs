using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.attendanceReport.Dutyshortage
{
    public partial class DutyShortageReport : System.Web.UI.Page
    {
        attendance attendanceObject = new attendance();
        static attendance staticAttendanceObject = new attendance();

        public string baseUrl
        {
            get
            {

                return attendanceObject.baseUrl();
            }
        }

        public string projectName
        {
            get
            {

                return attendanceObject.projectName();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(Request.Params["startDate"]);
            DateTime toDate = Convert.ToDateTime(Request.Params["endDate"]);
            string branchName = Request.Params["branchName"];
            string deptname = Request.Params["deptname"];
            DataTable dt = attendanceObject.DutyShortageData();
            GridView1.DataSource = dt;
            GridView1.DataBind();

            lblStartDate.Text = fromDate.ToString("yyyy-MM-dd");
            lblEndDate.Text = toDate.ToString("yyyy-MM-dd");
            //lblBranch.Text = branchName.ToString();
            //lblDept.Text = deptname.ToString();
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("DutyshortageForm");

        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = attendanceObject.GetAllOrg();
            lblBranch.Text = dt.Rows[0]["Org_Name"].ToString();
            lblDept.Text = dt.Rows[0]["Full_Address"].ToString();
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewDutyshortageReport.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
            Panel1.RenderControl(htw);
            Panel2.RenderControl(htw);
            Panel3.RenderControl(htw);

            GridView1.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}