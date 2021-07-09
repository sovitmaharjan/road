using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace attendance.pages.Report.rosterShiftInfo {
    public partial class rosterShiftInfoList : System.Web.UI.Page {
        attendance blu = new attendance();
        int empid, Aflag;
        DateTime startdate, tilldate;
        protected void Page_Load(object sender, EventArgs e) {
            empid = int.Parse(Server.UrlDecode(Request.QueryString["eid"].ToString()));
            startdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["startdate"].ToString()));
            tilldate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["tilldate"].ToString()));
            Aflag = 0;

            blu.Report_RoosterShift(startdate, tilldate, empid, Aflag);
            DataTable dt = blu.GetRoosterData();
            GridView1.DataSource = dt;
            GridView1.DataBind();

            string emp_branch = Server.UrlDecode(Request.QueryString["emp_branch"]);
            string emp_dept = Server.UrlDecode(Request.QueryString["emp_dept"]);
            string emp_name = Server.UrlDecode(Request.QueryString["emp_name"]);

            lblEmployee.Text = emp_name.ToString();
            lblEmployeeID.Text = empid.ToString();
            lblBranch.Text = emp_branch.ToString();
            lblDept.Text = emp_dept.ToString();
            lblStartDate.Text = startdate.ToString("yyyy-MM-dd");
            lblEndDate.Text = tilldate.ToString("yyyy-MM-dd");
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                if (e.Row.Cells[5].Text.CompareTo("Weekned") == 0) {
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Attributes.Add("colspan", "5");
                    e.Row.Cells[5].BackColor = Color.FromName("#4CA543");
                    e.Row.Cells[5].Font.Size = 16;
                    e.Row.Cells[5].Text = "Weekend Holiday";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
            }
        }
        protected void BtnNew_Click(object sender, EventArgs e) {
            Response.Redirect("rosterShiftInfo");
        }
        protected void BtnExport_Click(object sender, EventArgs e) {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=RoosterShiftInfo Report.xls");
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