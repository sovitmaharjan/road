using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.leaveReport.Departmentwise
{
    public partial class DepartmentwiseLeaveReportView : System.Web.UI.Page
    {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e)
        {
           DateTime sdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["sdate"].ToString()));
           DateTime edate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["edate"].ToString()));
           lblStartDate.Text = sdate.ToString("yyyy-MM-dd");
           lblEndDate.Text = edate.ToString("yyyy-MM-dd");
           DataTable dt = blu.DepartmentwiseLeaveTakenSummary(sdate, edate);
           GridView.DataSource = dt;
           GridView.DataBind();
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentwiseLeaveTakenSummary");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=DepartmentwiseLeaveTakenSummary.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
            Panel1.RenderControl(htw);
            Panel2.RenderControl(htw);
            Panel3.RenderControl(htw);
            string style = @"<style> TD { mso-number-format:\@; } </style> ";
            Response.Write(style);

            GridView.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}