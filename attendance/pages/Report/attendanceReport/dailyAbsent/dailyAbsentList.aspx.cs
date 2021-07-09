using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace attendance.pages.Report.attendanceReport.dailyAbsent {
    public partial class dailyAbsentList : System.Web.UI.Page {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e)
        {

            DateTime sdate = Convert.ToDateTime(Request.Params["startDate"]);
            DateTime edate = Convert.ToDateTime(Request.Params["endDate"]);
            string dept_id = Request.Params["dept_id"];
            int emp_id = Convert.ToInt32(Request.Params["emp_id"]);

            DataTable dt = blu.DailyAbsent(sdate, edate, dept_id, 0, emp_id);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int j;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string flag = e.Row.Cells[9].Text;
                string duty_roster = e.Row.Cells[5].Text;
                string remarks = e.Row.Cells[9].Text;
                if (remarks.CompareTo("Absent") == 0)
                {
                    for (j = 6; j <= 8; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                    e.Row.Cells[9].Attributes.Add("colspan", "4");
                    e.Row.Cells[9].BackColor = Color.FromName("#ff8080");
                    e.Row.Cells[9].Font.Size = 14;
                    e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Center;
                }
                if (remarks.CompareTo("Absent (Forgot to signout)") == 0)
                {
                    for (j = 7; j <= 8; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                    e.Row.Cells[9].Attributes.Add("colspan", "3");
                    e.Row.Cells[9].BackColor = Color.FromName("#ff8080");
                    e.Row.Cells[9].Font.Size = 14;
                    e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Center;
                }
                if (duty_roster.CompareTo("&nbsp;") == 0)
                {
                    e.Row.Cells[5].Text = "No Roster";
                }
                if (remarks.CompareTo("Short Duty") == 0)
                {
                    e.Row.Cells[9].BackColor = Color.FromName("#FF0000");
                    e.Row.Cells[9].Font.Size = 14;
                }
                if (remarks.CompareTo("Worked Half Day") == 0)
                {
                    e.Row.Cells[9].BackColor = Color.FromName("#00FF00");
                    e.Row.Cells[9].Font.Size = 14;
                }
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("dailyAbsent");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = blu.GetAllOrg();
            lblOrgName.Text = dt.Rows[0]["Org_Name"].ToString();
            lblOrgFullAddress.Text = dt.Rows[0]["Full_Address"].ToString();
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewDailyAbsent.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
            Panel1.RenderControl(htw);
            Panel2.RenderControl(htw);
            GridView1.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control) {
        }
    }
}