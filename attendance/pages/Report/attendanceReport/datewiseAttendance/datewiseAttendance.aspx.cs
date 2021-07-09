using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.attendanceReport.datewiseAttendance
{
    public partial class datewiseAttendance : System.Web.UI.Page
    {
        attendance blu = new attendance();
        int branch;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBranch();
            }
            CmbBranch.Items[0].Attributes.Add("disabled", "disabled");
        }

        public void loadBranch()
        {
            DataTable dt = blu.getBranchList();
            if (dt.Rows.Count == 1)
            {
                string branch_id = dt.Rows[0]["BRANCH_ID"].ToString();
                CmbBranch.DataSource = dt;
                CmbBranch.DataTextField = "BRANCH_NAME";
                CmbBranch.DataValueField = "BRANCH_ID";
                CmbBranch.SelectedValue = branch_id;
                CmbBranch.DataBind();
                CmbBranch.Items.Insert(0, "Select Branch");

                loadDepartment();
                CmbDepartment.Enabled = true;
            }
            else
            {
                CmbBranch.DataSource = dt;
                CmbBranch.DataTextField = "BRANCH_Name";
                CmbBranch.DataValueField = "BRANCH_ID";
                CmbBranch.DataBind();
                CmbBranch.Items.Insert(0, "Select Branch");
                CmbDepartment.Enabled = false;
            }
        }
        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDepartment.Enabled = true;
            CmbBranch.Items[0].Attributes["disabled"] = "disabled";

            branch = Convert.ToInt32(CmbBranch.SelectedValue);
            dt = blu.getDepartmentList(branch);
            if (dt.Rows.Count > 0)
            {
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available!!!!','warning')", true);
            }
        }
        public void loadDepartment()
        {
            DataTable dt = blu.getDepartment();
            CmbDepartment.DataSource = dt;
            CmbDepartment.DataTextField = "DEPT_NAME";
            CmbDepartment.DataValueField = "DEPT_ID";
            CmbDepartment.DataBind();
            CmbDepartment.Items.Insert(0, "Select Department");
        }

        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";

            if (CmbBranch.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First  !!!!','warning')", true);
                loadDepartment();
                return;
            }
        }



        protected void chkDepartment_CheckedChanged(object sender, EventArgs e)
        {
            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";

            if (CmbBranch.SelectedItem.Text == "Select Branch")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First!!!!','warning')", true);
                chkDepartment.Checked = false;

                return;
            }
            if (chkDepartment.Checked)
            {
                CmbDepartment.Items.Clear();
                CmbDepartment.Enabled = false;
                branch = Convert.ToInt32(CmbBranch.SelectedValue);
                dt = blu.getDepartmentList(branch);
                GridView.Visible = true;
                GridView.DataSource = dt;
                GridView.DataBind();

            }
            else
            {
                GridView.Visible = false;
                loadDepartment();
                CmbDepartment.Enabled = true;
            }

        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }


        string dept_name, tdept_id;
        string dept_id = "";
        DateTime start_date, end_date;
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (TxtStartDate.Text == "" || TxtEndDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Invalid Date. !!!','warning')", true);
                return;
            }

            if (CmbBranch.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First!!!!','warning')", true);
                return;
            }
            start_date = Convert.ToDateTime(TxtStartDate.Text);
            end_date = Convert.ToDateTime(TxtEndDate.Text);
            string branch_name = CmbBranch.SelectedItem.ToString();
            int branch_id = Convert.ToInt16(CmbBranch.SelectedValue);

            if (chkDepartment.Checked)
            {
                foreach (GridViewRow row in GridView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chk2") as CheckBox);
                        if (chkRow.Checked)
                        {
                            dept_name = ((row.Cells[1].FindControl("DEPT_NAME") as Label).Text);
                            tdept_id = ((row.Cells[1].FindControl("DEPT_ID") as Label).Text);
                            if (dept_id == "")
                            {
                                dept_id += tdept_id;
                            }
                            else
                            {
                                dept_id += ", " + tdept_id;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Select atlest one of the checkbox!!!','warning')", true);
                        }
                    }
                }
            }
            else
            {
                dept_id = CmbDepartment.SelectedValue;
            }
            Response.Redirect("dateWiseAttendanceList?startDate=" + start_date + "&endDate=" + end_date + "&dept_id=" + dept_id);
        }
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("dateWiseAttendanceList");
        }
    }
}