using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace attendance.pages.Report.inOutInfo
{
    public partial class inOutInfoList : System.Web.UI.Page
    {
        attendance blu = new attendance();
        DateTime StartDate, EndDate;
        int branch_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            branch_id = int.Parse(Server.UrlDecode(Request.QueryString["branch_id"].ToString()));
            StartDate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["sdate"].ToString()));
            EndDate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["edate"].ToString()));
            string branch_name = Server.UrlDecode(Request.QueryString["branch_name"]);
            //lblBranch.Text = branch_name.ToString();
            lblStartDate.Text = StartDate.ToString("yyyy-MM-dd");
            lblEndDate.Text = EndDate.ToString("yyyy-MM-dd");

            DataTable dt = blu.Reports_InOutInfo(branch_id, StartDate, EndDate);
            GridView.DataSource = dt;
            GridView.DataBind();
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell inTimeCell = e.Row.Cells[2];
                TableCell OutTimeCell = e.Row.Cells[3];
                if (inTimeCell.Text != "&nbsp;" && OutTimeCell.Text == "&nbsp;")
                {
                    OutTimeCell.Text = "Missing Out";
                    OutTimeCell.ForeColor = Color.FromName("#FF0000");
                }
                if (e.Row.Cells[4].Text != "&nbsp;" && e.Row.Cells[5].Text == "&nbsp;")
                {
                    e.Row.Cells[5].Text = "Missing Out";
                }
            }
        }
        protected void BtnNew_Click1(object sender, EventArgs e)
        {
            Response.Redirect("MissingPunch");
        }

        protected void BtnExport_Click1(object sender, EventArgs e)
        {
            DataTable dt = blu.GetAllOrg();
            lblOrgName.Text = dt.Rows[0]["Org_Name"].ToString();
            lblOrgFullAddress.Text = dt.Rows[0]["Full_Address"].ToString();
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=MissingPunch.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");

            Panel1.RenderControl(htw);
            Panel2.RenderControl(htw);
            GridView.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}