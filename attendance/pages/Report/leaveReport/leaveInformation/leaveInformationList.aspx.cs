using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.leaveReport.leaveInformation {
    public partial class leaveInformationList : System.Web.UI.Page {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e) {

            int BRANCHID = int.Parse(Server.UrlDecode(Request.QueryString["BRANCHID"].ToString()));
            int DEPTID = int.Parse(Server.UrlDecode(Request.QueryString["DEPTID"].ToString()));
            int EMPID = int.Parse(Server.UrlDecode(Request.QueryString["EMPID"].ToString()));

            DataTable dt = blu.LeaveInformation(BRANCHID, DEPTID, EMPID);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            string emp_branch = Server.UrlDecode(Request.QueryString["emp_branch"]);
            string emp_dept = Server.UrlDecode(Request.QueryString["emp_dept"]);
            string emp_name = Server.UrlDecode(Request.QueryString["emp_name"]);

            lblBranch.Text = emp_name.ToString() + "(" + EMPID + ")";
            lblDept.Text = emp_dept.ToString();
        }
        protected void GridView1_DataBound(object sender, System.EventArgs e) {
            for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--) {
                GridViewRow gvRow = GridView1.Rows[rowIndex];
                GridViewRow gvPreviousRow = GridView1.Rows[rowIndex + 1];
                //for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
                // { 
                if (gvRow.Cells[0].Text == gvPreviousRow.Cells[0].Text) {
                    if (gvPreviousRow.Cells[0].RowSpan < 2) {
                        gvRow.Cells[0].RowSpan = 2;
                    } else {
                        gvRow.Cells[0].RowSpan = gvPreviousRow.Cells[0].RowSpan + 1;
                    }
                    gvPreviousRow.Cells[0].Visible = false;
                }
                //}
            }
        }
        protected void BtnNew_Click(object sender, EventArgs e) {
            Response.Redirect("leaveInformation");
        }

        protected void BtnExport_Click(object sender, EventArgs e) {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewLeaveInformation.xls");
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