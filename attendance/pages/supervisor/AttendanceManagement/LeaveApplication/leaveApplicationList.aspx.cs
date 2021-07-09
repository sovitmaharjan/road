using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.supervisor.AttendanceManagement.LeaveApplication
{
    public partial class leaveApplicationList : System.Web.UI.Page
    {
        attendance blu = new attendance();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = blu.getLeaveApplication();
                GridView.DataSource = dt;
                GridView.DataBind();
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("leaveApplication");
        }
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                e.Row.Cells[1].Visible = false;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView dRow = (DataRowView)e.Row.DataItem;

                    if (dRow.Row["LEAVETYPE"].ToString() == "N")

                        if (dRow.Row["LEAVETYPE"].ToString() == "N")
                        {
                            e.Row.Cells[9].ForeColor = System.Drawing.Color.Green;
                            e.Row.Cells[9].Text = "Normal Leave";
                        }
                        else if (dRow.Row["LEAVETYPE"].ToString() == "F")
                        {
                            e.Row.Cells[9].ForeColor = System.Drawing.Color.Blue;
                            e.Row.Cells[9].Text = "Force Leave";
                        }
                        else if (dRow.Row["LEAVETYPE"].ToString() == "G")
                        {
                            e.Row.Cells[9].ForeColor = System.Drawing.Color.Yellow;
                            e.Row.Cells[9].Text = "Negative Leave";
                        }
                        else
                        {
                            e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
                            e.Row.Cells[9].Text = "Urgent Leave";
                        }

                    if (dRow.Row["status"].ToString() == "1")
                    {
                        e.Row.Cells[11].ForeColor = System.Drawing.Color.Blue;
                        e.Row.Cells[11].Text = "Pending";
                    }
                    else if (dRow.Row["status"].ToString() == "2")
                    {
                        e.Row.Cells[11].ForeColor = System.Drawing.Color.Green;
                        e.Row.Cells[11].Text = "Approved";
                    }
                    else
                    {
                        e.Row.Cells[11].ForeColor = System.Drawing.Color.Red;
                        e.Row.Cells[11].Text = "DisApproved";
                    }
                }
            }
            else
            {

            }
        }

        protected void GridView_Merge_Header_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //Build custom header.
                GridView oGridView = (GridView)sender;
                GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell oTableCell = new TableCell();
                oTableCell.Text = "S.No";
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Employee";
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Date";
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Leave Name";
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Taken";
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Remarks";
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Approved By";
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Regular";
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Leave Type";
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Day Part";
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Status";
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Actions";
                oTableCell.ColumnSpan = 2;
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell.Attributes.Add("class", "header");
                oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);
            }
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView.Rows[index];
                TableCell id = selectedRow.Cells[1];
                int sNO = int.Parse(id.Text);
                int status = 2;
                int i = blu.updateLeaveApplication(status, sNO);
                if (i > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Leave Approved Successfully','success').then((value) => { window.location ='leaveApplicationList'; });", true);
                }
            }
            else
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView.Rows[index];
                TableCell id = selectedRow.Cells[1];
                int sNO = int.Parse(id.Text);
                int status = 3;
                int i = blu.updateLeaveApplication(status, sNO);
                if (i > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Good job!','Leave DisApproved Successfully','success').then((value) => { window.location ='leaveApplicationList='; });", true);
                }
            }
        }
    }
}