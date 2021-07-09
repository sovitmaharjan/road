using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.attendanceReport.ForceAttendance
{
    public partial class ForceAttendance : System.Web.UI.Page
    {
        attendance blu = new attendance();
        int branch_id, emp_id;
        string dept_id, tdept_id;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBranch();
                CmbDepartment.Enabled = false;
                CmbEmployee.Enabled = false;

                //TxtStartDate.Text = DateTime.Now.ToString("yyyy-MM-01");
                //TxtEndDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
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
            branch_id = Convert.ToInt32(CmbBranch.SelectedValue);
            dt = blu.getDepartmentList(branch_id);
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
            dt = blu.getEmployees();
            CmbEmployee.DataSource = dt;
            CmbEmployee.DataTextField = "emp_fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");
        }        
        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbEmployee.Enabled = true;
            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
            txtEmpId.Text = " ";
            string dept = CmbDepartment.SelectedValue;
            DataTable dt = blu.getEmployeeListByDepartmentId(dept);
            CmbEmployee.DataSource = dt;
            CmbEmployee.DataTextField = "emp_fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");
            CmbEmployee.Items[0].Attributes["disabled"] = "disabled";

        }
        protected void chkDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDepartment.Checked)
            {
                if (CmbBranch.SelectedItem.Text == "Select Branch")
                {
                    chkDepartment.Checked = false;
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First!!!!','warning')", true);
                    return;
                }
                else
                {
                    CmbDepartment.Enabled = false;
                    CmbDepartment.Items.Clear();
                    CmbEmployee.Items.Clear();
                    CmbEmployee.Enabled = false;
                    txtEmpId.Text = "";
                    txtEmpId.Enabled = false;
                    dt = blu.getDepartment();
                    GridView.Visible = true;
                    GridView.DataSource = dt;
                    GridView.DataBind();
                }
            }
            else
            {
                txtEmpId.Enabled = true;
                GridView.Visible = false;
                loadDepartment();
                CmbDepartment.Enabled = true;
            }
        }
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
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
                CmbBranch.SelectedValue = dt.Rows[0]["BRANCH_ID"].ToString();
                CmbBranch.Items[0].Attributes["disabled"] = "disabled";
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
        int eid = 0; DateTime startDate, endDate;
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (TxtStartDate.Text == "" || TxtEndDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Invalid Date. !!!','warning')", true);
                return;
            }
            if (CmbDepartment.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department First !!!!','warning')", true);
                return;
            }
            if (CmbEmployee.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Employee !!!!','warning')", true);
                return;
            }
            startDate = Convert.ToDateTime(TxtStartDate.Text);
            endDate = Convert.ToDateTime(TxtEndDate.Text);
            if (chkDepartment.Checked)
            {
                foreach (GridViewRow row in GridView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chk2") as CheckBox);
                        if (chkRow.Checked)
                        {
                            string tdept_id = ((row.Cells[2].FindControl("DEPT_ID") as Label).Text);
                            if (dept_id == "")
                            {
                                dept_id += tdept_id;
                            }
                            else
                            {
                                dept_id += ", " + tdept_id;
                                emp_id = 0;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Select atlest one of the Department!!!','warning')", true);
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
                dept_id = "0";
                emp_id = int.Parse(txtEmpId.Text);
            }

            Response.Redirect("ForceAttendanceList?startDate=" + startDate + "&endDate=" + endDate + "&dept_id=" + dept_id +"&emp_id=" + emp_id);
        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForceAttendanceForm");
        }
    }
}