using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.leaveReport.leaveTakenDetail {
    public partial class leaveTakenDetailList : System.Web.UI.Page {
        attendance blu = new attendance();
        int eid;
        DateTime sdate, edate;
        protected void Page_Load(object sender, EventArgs e) {
            eid = int.Parse(Server.UrlDecode(Request.QueryString["eid"].ToString()));
            sdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["sdate"].ToString()));
            edate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["edate"].ToString()));
            int branchid = 0;
            int deptid = int.Parse(Server.UrlDecode(Request.QueryString["dept_id"].ToString()));
            int leaveid = int.Parse(Server.UrlDecode(Request.QueryString["leave_id"].ToString()));

            DataTable dt = blu.LeaveTakenDetail(sdate, edate, eid, leaveid, branchid, deptid);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            string emp_branch = Server.UrlDecode(Request.QueryString["emp_branch"]);
            string emp_dept = Server.UrlDecode(Request.QueryString["emp_dept"]);
            string emp_name = Server.UrlDecode(Request.QueryString["emp_name"]);
            string leave_name = Server.UrlDecode(Request.QueryString["leave_name"]);

            lblStartDate.Text = sdate.ToString("yyyy-MM-dd");
            lblEndDate.Text = edate.ToString("yyyy-MM-dd");
        }

        protected void BtnExport_Click(object sender, EventArgs e) {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewLeaveTaken.xls");
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

        protected void BtnNew_Click(object sender, EventArgs e) {
            Response.Redirect("leaveTakenDetail");
        }
    }
}