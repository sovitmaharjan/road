using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.supervisor.Report.MonthlyAttendance
{
    public partial class monthlyAttendanceView : System.Web.UI.Page
    {
        attendance blu = new attendance();
        int eid, branch_id, dept_id;
        DateTime Startdate, Enddate;
        protected void Page_Load(object sender, EventArgs e)
        {
            eid = int.Parse(Server.UrlDecode(Request.QueryString["eid"].ToString()));
            Startdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["Startdate"].ToString()));
            Enddate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["Enddate"].ToString()));
            branch_id = int.Parse(Server.UrlDecode(Request.QueryString["branch_id"].ToString()));
            string emp_branch = Server.UrlDecode(Request.QueryString["emp_branch"]);
            string emp_dept = Server.UrlDecode(Request.QueryString["emp_dept"]);
            dept_id = int.Parse(Server.UrlDecode(Request.QueryString["dept_id"].ToString()));
            string emp_name = Server.UrlDecode(Request.QueryString["emp_name"]);

            lblStartDate.Text = Startdate.ToString("yyyy-MM-dd");
            lblEndDate.Text = Enddate.ToString("yyyy-MM-dd");
            lblBranch.Text = emp_branch.ToString();
            lblDept.Text = emp_dept.ToString();
            int Aflag = 0;
            DataSet ds = blu.Monthlyattendance(eid, branch_id,dept_id, Startdate, Enddate, Aflag);
            GridView1.DataSource = ds.Tables[1];
            GridView1.DataBind();
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell2 = new TableCell();
                HeaderCell2.Text = "";
                HeaderCell2.ColumnSpan = 6;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Leave Details";
                HeaderCell2.ColumnSpan = 7;
                HeaderCell2.Font.Size = 12;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "";
                HeaderCell2.ColumnSpan = 4;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Attendance Details";
                HeaderCell2.ColumnSpan = 5;
                HeaderCell2.Font.Size = 12;
                HeaderRow.Cells.Add(HeaderCell2);

                HeaderCell2 = new TableCell();
                HeaderCell2.Text = "";
                HeaderCell2.ColumnSpan = 3;
                HeaderRow.Cells.Add(HeaderCell2);

                GridView1.Controls[0].Controls.AddAt(0, HeaderRow);


                GridViewRow HeaderRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "Employee (ID)";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "TotalDays";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Weekend";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Public Holiday";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "WorkingDay";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Absent Days";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Sick";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Casual";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Home";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Subtitution";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Mourning";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Maternity";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Paternity";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Present Days";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Worked On Weekend";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Worked On PH";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total Present Days";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Early In";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "On Time";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Late by 15";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Late by 30";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "After 30";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Worked Hours";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Assigned Hours";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Difference";
                HeaderCell.Font.Size = 12;
                HeaderRow1.Cells.Add(HeaderCell);

                GridView1.Controls[0].Controls.AddAt(1, HeaderRow1);

                HeaderRow.Attributes.Add("class", "header");
                HeaderRow1.Attributes.Add("class", "header");

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string qwe = (e.Row.Cells[14].Text);
                //string asd = (e.Row.Cells[15].Text);
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("MonthlyAttendance");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewMonthlyAttendance.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");

            Panel1.RenderControl(htw);
            Panel2.RenderControl(htw);
            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:left; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
            GridView1.RenderControl(htw);
            pnlNote.RenderControl(htw);

            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}