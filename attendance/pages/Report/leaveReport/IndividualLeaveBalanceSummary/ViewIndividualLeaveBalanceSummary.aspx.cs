using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.leaveReport.IndividualLeaveBalanceSummary
{
    public partial class IndividualLeaveBalanceSummaryReport : System.Web.UI.Page
    {
        attendance blu = new attendance();
        string headerSdate, headerEdate;

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime sdate = Convert.ToDateTime(Request.Params["startDate"]);
            headerSdate = sdate.ToString("yyyy-MM-dd");
            DateTime edate = Convert.ToDateTime(Request.Params["endDate"]);
            headerEdate = edate.ToString("yyyy-MM-dd");
            string dept_id = Request.Params["dept_id"];


            int i = 1;

            DataTable dt = blu.IndividualLeaveBalanceSummary(sdate, edate, dept_id);
            if(dt.Rows.Count > 0)
            {

           
            string[] testArray = new string[20];
            DataTable employeeList = blu.getEmployeeListByDepartmentId(dept_id);
            string tempEmpId = dt.Rows[0]["emp_id"].ToString();
            DataTable dt2 = new DataTable();
            dt2 = dt.Clone();
            string annualGiven;
            string annualTaken;
            string annualBalance;
            string sickGiven;
            string sickTaken;
            string sickBalance;
            string casualGiven;
            string casualTaken;
            string casualBalance;
            string mourningTaken;
            string officialTaken;
            string maternityTaken;
            string withoutPayTaken;
            string substituteTaken;
            string phTaken;

            DataTable dtFinal = new DataTable();
            dtFinal.Columns.Add("sno", typeof(String));
            dtFinal.Columns.Add("employeeName", typeof(String));
            dtFinal.Columns.Add("pno", typeof(String));
            dtFinal.Columns.Add("department", typeof(String));
            dtFinal.Columns.Add("annuaLGiven", typeof(String));
            dtFinal.Columns.Add("casualGiven", typeof(String));
            dtFinal.Columns.Add("sickGiven", typeof(String));
            dtFinal.Columns.Add("annualTaken", typeof(String));
            dtFinal.Columns.Add("casualTaken", typeof(String));
            dtFinal.Columns.Add("sickTaken", typeof(String));
            dtFinal.Columns.Add("annualBalance", typeof(String));
            dtFinal.Columns.Add("casualBalance", typeof(String));
            dtFinal.Columns.Add("sickBalance", typeof(String));
            dtFinal.Columns.Add("leaveWithout", typeof(String));
            dtFinal.Columns.Add("maternityLeave", typeof(String));
            dtFinal.Columns.Add("mourningLeave", typeof(String));
            dtFinal.Columns.Add("officialLeave", typeof(String));
            dtFinal.Columns.Add("phLeave", typeof(String));
            dtFinal.Columns.Add("sustituteLeave", typeof(String));
            dtFinal.Columns.Add("remarks", typeof(String));

            foreach (DataRow value in employeeList.Rows)
            {

                annualGiven = "N/A";
                annualTaken = "N/A";
                annualBalance = "N/A";
                sickGiven = "N/A";
                sickTaken = "N/A";
                sickBalance = "N/A";
                casualGiven = "N/A";
                casualTaken = "N/A";
                casualBalance = "N/A";
                mourningTaken = "N/A";
                officialTaken = "N/A";
                maternityTaken = "N/A";
                withoutPayTaken = "N/A";
                substituteTaken = "N/A";
                phTaken = "N/A";

                foreach (DataRow value2 in dt.Rows)
                {
                    if (value2["emp_id"].ToString() == value["EMP_ID"].ToString())
                    {
                        dt2.ImportRow(value2);
                    }
                }

                foreach (DataRow value3 in dt2.Rows)
                {
                    if (Convert.ToInt32(value3["leavE_id"]) == 3)
                    {

                        annualGiven = value3["given"].ToString();
                        annualTaken = value3["taken"].ToString();
                        annualBalance = value3["balance"].ToString();
                    }
                    else if (Convert.ToInt32(value3["leavE_id"]) == 4)
                    {
                        sickGiven = value3["given"].ToString();
                        sickTaken = value3["taken"].ToString();
                        sickBalance = value3["balance"].ToString();
                    }
                    else if (Convert.ToInt32(value3["leavE_id"]) == 5)
                    {
                        casualGiven = value3["given"].ToString();
                        casualTaken = value3["taken"].ToString();
                        casualBalance = value3["balance"].ToString();
                    }
                    else if (Convert.ToInt32(value3["leavE_id"]) == 6)
                    {
                        mourningTaken = value3["taken"].ToString();
                    }
                    else if (Convert.ToInt32(value3["leavE_id"]) == 7)
                    {
                        officialTaken = value3["taken"].ToString();
                    }
                    else if (Convert.ToInt32(value3["leavE_id"]) == 8)
                    {
                        maternityTaken = value3["taken"].ToString();
                    }
                    else if (Convert.ToInt32(value3["leavE_id"]) == 9)
                    {
                        withoutPayTaken = value3["taken"].ToString();
                    }
                    else if (Convert.ToInt32(value3["leavE_id"]) == 10)
                    {
                        substituteTaken = value3["taken"].ToString();
                    }
                    else if (Convert.ToInt32(value3["leavE_id"]) == 12)
                    {
                        phTaken = value3["taken"].ToString();
                    }
                }
                dtFinal.Rows.Add(new object[] { i, value["EMP_FULLNAME"], value["EMP_ID"], value["DEPT_NAME"], annualGiven, casualGiven, sickGiven, annualTaken, casualTaken, sickTaken, annualBalance, casualBalance, sickBalance, withoutPayTaken, maternityTaken, mourningTaken, officialTaken, phTaken, substituteTaken, "" });

                i++;
            }
            lblStartDate.Text = sdate.ToString("yyyy-MM-dd");
            lblEndDate.Text = edate.ToString("yyyy-MM-dd");
            GridView.DataSource = dtFinal;
            GridView.DataBind();
            }
            else
            {
                lblStartDate.Text = sdate.ToString("yyyy-MM-dd");
                lblEndDate.Text = edate.ToString("yyyy-MM-dd");
                GridView.DataSource = null;
                GridView.DataBind();
            }
        }
        
        protected void gvEmployee_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow HeaderRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell1 = new TableCell();
                HeaderCell1.Text = "";
                HeaderCell1.ColumnSpan = 1;
                HeaderRow1.Cells.Add(HeaderCell1);

                HeaderCell1 = new TableCell();
                HeaderCell1.Text = "";
                HeaderCell1.ColumnSpan = 1;
                HeaderRow1.Cells.Add(HeaderCell1);

                HeaderCell1 = new TableCell();
                HeaderCell1.Text = "";
                HeaderCell1.ColumnSpan = 1;
                HeaderRow1.Cells.Add(HeaderCell1);

                HeaderCell1 = new TableCell();
                HeaderCell1.Text = "";
                HeaderCell1.ColumnSpan = 1;
                HeaderRow1.Cells.Add(HeaderCell1);

                HeaderCell1 = new TableCell();
                HeaderCell1.Text = "Opening Leave As On" + " " + headerSdate;
                HeaderCell1.ColumnSpan = 3;
                HeaderRow1.Cells.Add(HeaderCell1);

                HeaderCell1 = new TableCell();
                HeaderCell1.Text = "Leave Taken From" + " " + headerSdate + " To " +  headerEdate;
                HeaderCell1.ColumnSpan = 3;
                HeaderRow1.Cells.Add(HeaderCell1);

                HeaderCell1 = new TableCell();
                HeaderCell1.Text = "Leave Balance On" + " " + headerEdate;
                HeaderCell1.ColumnSpan = 3;
                HeaderRow1.Cells.Add(HeaderCell1);

                HeaderCell1 = new TableCell();
                HeaderCell1.Text = "Leave Taken From" + " " + headerSdate + " To " + headerEdate;
                HeaderCell1.ColumnSpan = 6;
                HeaderRow1.Cells.Add(HeaderCell1);

                HeaderCell1 = new TableCell();
                HeaderCell1.Text = "";
                HeaderCell1.ColumnSpan = 1;
                HeaderRow1.Cells.Add(HeaderCell1);

                GridView.Controls[0].Controls.AddAt(0, HeaderRow1);



                GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "S.N";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Employee Name";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "P No";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Department";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Annual Leave";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Casual Leave";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Sick Leave";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Annual Leave";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Casual Leave";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Sick Leave";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Annual Leave";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Casual Leave";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Sick Leave";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Leave Without Pay";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Maternity Leave";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Mourning Leave";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Official Leave";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PH Leave";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Subsitute Leave";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Remarks";
                HeaderRow.Cells.Add(HeaderCell);

                GridView.Controls[0].Controls.AddAt(1, HeaderRow);




                HeaderRow.Attributes.Add("class", "header");
                HeaderRow1.Attributes.Add("class", "header");

            }
        }
        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndividualLeaveBalanceSummary");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=IndividualLeaveBalanceSummary.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
            Panel1.RenderControl(htw);
            Panel2.RenderControl(htw);
            Panel3.RenderControl(htw);
            GridView.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}