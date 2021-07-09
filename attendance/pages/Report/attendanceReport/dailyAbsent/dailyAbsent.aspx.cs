using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.attendanceReport.dailyAbsent
{
    public partial class dailyAbsent : System.Web.UI.Page
    {

        attendance blu = new attendance();
        int emp_id;
        int branch;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBranch();
                CmbBranch.Items[0].Attributes.Add("disabled", "disabled");
            }
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
        public void loadDepartment()
        {
            DataTable dt = blu.getDepartment();
            CmbDepartment.DataSource = dt;
            CmbDepartment.DataTextField = "DEPT_NAME";
            CmbDepartment.DataValueField = "DEPT_ID";
            CmbDepartment.DataBind();
            CmbDepartment.Items.Insert(0, "Select Department");
        }
        public void loadEmployee()
        {
            DataTable dt = blu.getEmployees();
            CmbEmployee.DataSource = dt;
            CmbEmployee.DataTextField = "emp_fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");
        }

        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            branch = Convert.ToInt32(CmbBranch.SelectedValue);
            dt = blu.getDepartmentList(branch);
            if (dt.Rows.Count > 0)
            {
                CmbDepartment.Enabled = true;
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");
                CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");

            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available!!!!','warning')", true);
            }
        }

        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbEmployee.Enabled = true;
            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
            txtEmpId.Text = " ";
            int deptid = Convert.ToInt32(CmbDepartment.SelectedValue);
            DataTable dt1 = blu.getDept_EmployeeList(deptid, 1);
            CmbEmployee.DataSource = dt1;
            CmbEmployee.DataTextField = "emp_fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");
            CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
        }

        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDepartment.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department First !!!!','warning')", true);
                loadDepartment();
                return;
            }
            else
            {
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
                txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
            }
        }

        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            loadDepartment();
            CmbDepartment.Enabled = true;
            loadEmployee();
            CmbEmployee.Enabled = true;
            emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAll_Info(emp_id);
            if (dt.Rows.Count > 0)
            {
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                CmbDepartment.SelectedValue = dt.Rows[0]["DEPT_ID"].ToString();
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
                CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID !!!!','warning')", true);
                CmbDepartment.Enabled = false;
                CmbEmployee.Enabled = false;
            }
        }

        protected void chkDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (CmbBranch.SelectedItem.Text == "Select Branch")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First!!!!','warning')", true);
                chkDepartment.Checked = false;

                return;
            }
            if (chkDepartment.Checked)
            {
                GridView.Visible = true;
                CmbDepartment.Items.Clear();
                CmbDepartment.Enabled = false;
                CmbEmployee.Items.Clear();
                CmbEmployee.Enabled = false;
                txtEmpId.Text = "";
                txtEmpId.Enabled = false;
                branch = Convert.ToInt32(CmbBranch.SelectedValue);
                dt = blu.getDepartmentList(branch);
                GridView.DataSource = dt;
                GridView.DataBind();
            }
            else
            {
                GridView.Visible = false;
                loadDepartment();
                CmbDepartment.Enabled = true;
                txtEmpId.Enabled = true;
            }

        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }


        DateTime startDate, endDate;
        int flag;
        string tdept_id, dept_id;
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (TxtNepaliDate.Text == "" || TxtStartDate.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Date Field cannot be emptied !!!','warning')</script>");
                return;
            }
            if (CmbBranch.SelectedItem.Text == "Select Branch")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First!!!!','warning')", true);
                return;
            }
            startDate = Convert.ToDateTime(TxtStartDate.Text);
            endDate = Convert.ToDateTime(TxtEndDate.Text);
            string branchName = CmbBranch.SelectedValue;
            int branch = Convert.ToInt32(CmbBranch.SelectedValue);
            flag = 0;

            if (chkDepartment.Checked)
            {
                emp_id = 0;
                foreach (GridViewRow row in GridView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chk2") as CheckBox);
                        if (chkRow.Checked)
                        {
                            string dept_name = ((row.Cells[1].FindControl("DEPT_NAME") as Label).Text);
                            tdept_id = ((row.Cells[2].FindControl("DEPT_ID") as Label).Text);
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
                if (CmbDepartment.SelectedItem.Text == "Select Department")
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department!!!!','warning')", true);
                    return;
                }
                if (CmbEmployee.SelectedItem.Text == "Select Employee")
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Employee!!!!','warning')", true);
                    return;
                }
                dept_id = CmbDepartment.SelectedValue.ToString();
                emp_id = Convert.ToInt32(CmbEmployee.SelectedValue.ToString());
            }
            Response.Redirect("dailyAbsentList?startDate=" + startDate + "&endDate=" + endDate + "&dept_id=" + dept_id + "&emp_id=" + emp_id);
        }
    }
}