using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.otherReport.transferReport {
    public partial class transferReportList : System.Web.UI.Page {
        attendance blu = new attendance();
        DateTime StartDate, EndDate;
        int EMP_ID;
        protected void Page_Load(object sender, EventArgs e) {
            EMP_ID = int.Parse(Server.UrlDecode(Request.QueryString["EMP_ID"].ToString()));
            StartDate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["sdate"].ToString()));
            EndDate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["edate"].ToString()));
            string branch_name = Server.UrlDecode(Request.QueryString["branch_name"]);//dept_name

            string dept_name = Server.UrlDecode(Request.QueryString["dept_name"]);

            lblBranch.Text = branch_name.ToString();
            lbldept.Text = dept_name.ToString();
            lblStartDate.Text = StartDate.ToString("yyyy-MM-dd");
            lblEndDate.Text = EndDate.ToString("yyyy-MM-dd");

            //DataTable dt = blu.Report_Transfer(StartDate, EndDate, EMP_ID, deptFrom, deptTo, BranchFrom,BranchTo);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
        }

        protected void BtnNew_Click(object sender, EventArgs e) {
            Response.Redirect("Reports_Transfer.aspx");
        }

        protected void BtnExport_Click(object sender, EventArgs e) {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewTransfer.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");

            Panel1.RenderControl(htw);
            GridView1.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control) {
        }
    }
}