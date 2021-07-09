using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.leaveReport.IndividualLeaveTakenSummary
{
    public partial class ViewIndividualLeaveTakenSummary : System.Web.UI.Page
    {
        attendance blu = new attendance();


        protected void Page_Load(object sender, EventArgs e)
        {

            string emp_branch = Server.UrlDecode(Request.QueryString["branch_name"]);

            DateTime sdate = Convert.ToDateTime(Request.Params["startDate"]);
            DateTime edate = Convert.ToDateTime(Request.Params["endDate"]);
            string branch = Request.Params["branchName"];

            lblStartDate.Text = sdate.ToString("yyyy-MM-dd");
            lblEndDate.Text = edate.ToString("yyyy-MM-dd");

            DataTable dt = blu.IndividualLeaveTakenSummaryData();
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndividualLeaveTakenSummary");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=IndividualLeaveTakenSummary.xls");
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