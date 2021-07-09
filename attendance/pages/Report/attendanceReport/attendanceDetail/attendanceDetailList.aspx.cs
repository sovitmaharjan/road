using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.attendanceReport.attendanceDetail
{
    public partial class attendanceDetailList : System.Web.UI.Page
    {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e)
        {
            int branch = int.Parse(Server.UrlDecode(Request.QueryString["branch"].ToString()));
            DateTime date_from = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["date_from"].ToString()));
            DateTime date_to = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["date_to"].ToString()));
            int condition = int.Parse(Server.UrlDecode(Request.QueryString["con"].ToString()));
            int department = int.Parse(Server.UrlDecode(Request.QueryString["department"].ToString()));

            DataTable dt = blu.Report_LateAttendance(branch, department, date_from, date_to, condition);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            string emp_branch = Server.UrlDecode(Request.QueryString["branch_name"]);
            string emp_dept = Server.UrlDecode(Request.QueryString["dept_name"]);


            if (condition == 0)
            {
                report.Text = "Early Sign In Records";
            }
            else if (condition == 1)
            {
                report.Text = "Late Sign In Records";
            }
            else if (condition == 0)
            {
                report.Text = "Early Sign Out Records";
            }
            else
            {
                report.Text = "Late Sign Out Records";
            }


            lblStartDate.Text = date_from.ToString("yyyy-MM-dd");
            lblEndDate.Text = date_to.ToString("yyyy-MM-dd");
        }
        protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dRow = (DataRowView)e.Row.DataItem;
                int condition = int.Parse(Server.UrlDecode(Request.QueryString["con"].ToString()));

                if (condition == 0)
                {
                    e.Row.Cells[6].Text = dRow.Row["intime"].ToString();
                    e.Row.Cells[7].Text = dRow.Row["Indiff_Hour"].ToString();
                    e.Row.Cells[8].Text = "Early Sign In Records";
                }
                if (condition == 1)
                {
                    e.Row.Cells[6].Text = dRow.Row["intime"].ToString();
                    e.Row.Cells[7].Text = dRow.Row["latein_Hour"].ToString();
                    e.Row.Cells[8].Text = "Late Sign In Records";
                }
                if (condition == 2)
                {
                    e.Row.Cells[6].Text = dRow.Row["outtime"].ToString();
                    e.Row.Cells[7].Text = dRow.Row["Out_diffHrs"].ToString();
                    e.Row.Cells[8].Text = "Early Sign Out Records";
                }
                if (condition == 3)
                {
                    e.Row.Cells[6].Text = dRow.Row["outtime"].ToString();
                    e.Row.Cells[7].Text = dRow.Row["lateout_Hour"].ToString();
                    e.Row.Cells[8].Text = "Late Sign Out Records";
                }
            }
        }

        protected void GV_DataBound(object sender, System.EventArgs e)
        {
            for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow gvRow = GridView1.Rows[rowIndex];
                GridViewRow gvPreviousRow = GridView1.Rows[rowIndex + 1];
                if (gvRow.Cells[0].Text == gvPreviousRow.Cells[0].Text)
                {
                    if (gvPreviousRow.Cells[0].RowSpan < 2)
                    {
                        gvRow.Cells[0].RowSpan = 2;
                    }
                    else
                    {
                        gvRow.Cells[0].RowSpan = gvPreviousRow.Cells[0].RowSpan + 1;
                    }
                    gvPreviousRow.Cells[0].Visible = false;
                }
            }
        }
        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AttendanceDetail");
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AppendHeader("content-disposition", "attachment; filename=Late Attendance Report.xlsx");


            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            string style = @"<style> TD { mso-number-format:\@; } </style> ";
            Response.Write(style);
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 10px; PADDING-LEFT: 10px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");

            Panel1.RenderControl(htw);
            Panel2.RenderControl(htw);
            Panel3.RenderControl(htw);
            GridView1.RenderControl(htw);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(stringWriter.ToString());
            Response.Flush();
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}