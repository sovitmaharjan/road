using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.supervisor.AttendanceManagement.LeaveCancellation
{
    public partial class leaveCancellation : System.Web.UI.Page
    {
        attendance blu = new attendance();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadMonth();
                btnDelete.Visible = false;
                TxtYear.Text = DateTime.Now.Year.ToString();
                DDLMonth.SelectedIndex = DateTime.Now.Month;
            }
            DDLMonth.Items[0].Attributes["Disabled"] = "Disabled";
        }
        public void loadMonth()
        {
            dt = blu.getMonthList();
            DDLMonth.DataSource = dt;
            DDLMonth.DataTextField = "MONTH_NAME";
            DDLMonth.DataValueField = "MONTH_ID";
            DDLMonth.DataBind();
            DDLMonth.Items.Insert(0, "Select Month");
        }
        protected void TxtId_TextChanged(object sender, EventArgs e)
        {
            int emp_id = int.Parse(TxtId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
            if (dt.Rows.Count > 0)
            {
                TxtBranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                TxtDept.Text = dt.Rows[0]["DEPT_NAME"].ToString();
                TxtEmp.Text = dt.Rows[0]["emp_Fullname"].ToString();
                TxtDesg.Text = dt.Rows[0]["DEG_NAME"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Available with that ID !!!','warning')", true);
                TxtId.Text = " ";
            }
        }
        int emp_id, year, month;
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (TxtId.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Employee ID Cannot Be Emptied.!!!','warning')", true);

            }
            else if (DDLMonth.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Month first.!!!','warning')", true);
                return;
            }
            else
            {
                emp_id = Convert.ToInt32(TxtId.Text);
                year = Convert.ToInt32(TxtYear.Text);
                month = Convert.ToInt32(DDLMonth.SelectedValue);
                int date_type = 0;

                DataTable dt1 = blu.proc_LeaveShow(emp_id, year, month, date_type);
                if (dt1.Rows.Count > 0)
                {
                    GridView1.DataSource = null;
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    btnDelete.Visible = true;

                    GridView1.Visible = true;
                }
                else
                {
                    GridView1.DataSource = null;
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave with this Employee in Given Month and Year.!!!','warning')", true);
                }
            }

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    int SNo = Convert.ToInt32(row.Cells[1].Text);

                    CheckBox chkRow = (row.Cells[0].FindControl("CheckBox2") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string leavename = ((row.Cells[2].FindControl("txtLeaveName") as Label).Text);
                        string takendate = (row.Cells[3].FindControl("txtDate") as Label).Text;
                        string remarks = (row.Cells[4].FindControl("txtRemarks") as Label).Text;
                        string approvedby = (row.Cells[5].FindControl("txtApproved") as Label).Text;
                        blu.deleterow(SNo);

                        emp_id = Convert.ToInt32(TxtId.Text);
                        year = Convert.ToInt32(TxtYear.Text);
                        month = Convert.ToInt32(DDLMonth.SelectedValue);
                        int date_type = 0;

                        DataTable dt1 = blu.proc_LeaveShow(emp_id, year, month, date_type);
                        if (dt1.Rows.Count > 0)
                        {
                            GridView1.DataSource = null;
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                        }
                        else
                        {
                            GridView1.Visible = false;
                            btnDelete.Visible = false;
                            TxtId.Text = "";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','All Leave Deleted !!!','warning')</script>");
                        }
                    }
                }
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','select deleted !!!','warning')</script>");
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("leaveCancellation");
        }
    }
}