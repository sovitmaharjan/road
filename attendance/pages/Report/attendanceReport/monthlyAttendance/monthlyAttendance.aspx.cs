using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.attendanceReport.monthlyAttendance {
    public partial class monthlyAttendance : System.Web.UI.Page {
        attendance blu = new attendance();
        int branch_id, dept_id, emp_id;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                CmbEmployee.Enabled = false;
                loadBranch();
                CmbBranch.Items[0].Attributes["disabled"] = "disabled";
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
        public void loadDepartment() {
            DataTable dt = blu.getDepartment();
            CmbDepartment.DataSource = dt;
            CmbDepartment.DataTextField = "DEPT_NAME";
            CmbDepartment.DataValueField = "DEPT_ID";
            CmbDepartment.DataBind();
            CmbDepartment.Items.Insert(0, "Select Department");
        }

        public void loadEmployee() {
            DataTable dt = blu.getEmployees();
            CmbEmployee.DataSource = dt;
            CmbEmployee.DataTextField = "emp_fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");
        }

        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e) {
            CmbDepartment.Enabled = true;
            CmbEmployee.Enabled = false;
            CmbBranch.Items[0].Attributes["disabled"] = "disabled";

            branch_id = Convert.ToInt32(CmbBranch.SelectedValue);
            DataTable dt = blu.getBranch_DepartmentList(branch_id);
            if (dt.Rows.Count > 0) {
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");
                CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");

                CmbEmployee.Items.Clear();
                txtEmpId.Text = " ";
                Chkemp.Checked = false;
                txtEmpId.Enabled = true;
            } else {
                CmbDepartment.Items.Clear();
                CmbEmployee.Items.Clear();
                txtEmpId.Text = " ";
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available !!!','warning')", true);
            }
        }

        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e) {
            CmbEmployee.Enabled = true;
            CmbBranch.Items[0].Attributes["disabled"] = "disabled";
            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";

            if (CmbBranch.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First  !!!!','warning')", true);
                loadDepartment();
                return;
            } else {
                txtEmpId.Text = " ";
                branch_id = Convert.ToInt32(CmbBranch.SelectedValue);
                dept_id = Convert.ToInt32(CmbDepartment.SelectedValue);
                DataTable dt1 = blu.getDept_EmployeeList(dept_id, branch_id);
                CmbEmployee.DataSource = dt1;
                CmbEmployee.DataTextField = "emp_fullname";
                CmbEmployee.DataValueField = "EMP_ID";
                CmbEmployee.DataBind();
                CmbEmployee.Items.Insert(0, "Select Employee");
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
                Chkemp.Checked = false;
                CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");
            }
        }

        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e) {
            if (CmbBranch.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First  !!!!','warning')", true);
                loadBranch();
                return;
            } else if (CmbDepartment.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department First !!!!','warning')", true);
                loadDepartment();
                return;
            } else {
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
                txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
            }
        }

        protected void txtEmpId_TextChanged(object sender, EventArgs e) {
            emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
            if (dt.Rows.Count > 0) {
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();

                CmbBranch.DataSource = dt;
                CmbBranch.DataTextField = "BRANCH_Name";
                CmbBranch.DataValueField = "BRANCH_ID";
                CmbBranch.DataBind();

                CmbDepartment.DataSource = dt;
                CmbDepartment.Enabled = true;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();

                CmbEmployee.DataSource = dt;
                CmbEmployee.Enabled = true;
                CmbEmployee.DataTextField = "emp_fullname";
                CmbEmployee.DataValueField = "EMP_ID";
                CmbEmployee.DataBind();
            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Branch and Department Available with This Id !!!','warning')", true);
            }
            chkAllEmployees.Visible = false;
            Chkemp.Enabled = false;
        }

        protected void Chkemp_CheckedChanged(object sender, EventArgs e) {
            if (CmbBranch.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch !!!','warning')", true);
                Chkemp.Checked = false;
                return;
            }
            if (CmbDepartment.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department !!!','warning')", true);
                Chkemp.Checked = false;
                return;
            }
            int deptid = Convert.ToInt32(CmbDepartment.SelectedValue);

            if (Chkemp.Checked) {
                if (CmbDepartment.SelectedIndex == 0) {

                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department First !!!','warning')", true);
                    Chkemp.Checked = false;
                } else {
                    chkAllEmployees.Visible = true;
                    CmbEmployee.Enabled = false;

                    DataTable dt = blu.getDept_EmployeeList(deptid, branch_id);
                    CmbEmployee.DataSource = dt;
                    CmbEmployee.DataBind();
                    txtEmpId.Enabled = false;
                    txtEmpId.Text = "";

                }
            } else if (!Chkemp.Checked) {
                chkAllEmployees.Visible = false;
                dept_id = Convert.ToInt32(CmbDepartment.SelectedValue);
                DataTable dt = blu.getDept_EmployeeList(dept_id, branch_id);
                CmbEmployee.DataSource = dt;
                CmbEmployee.DataTextField = "emp_fullname";
                CmbEmployee.DataBind();

                txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
            }
        }

        protected void chkAllEmployees_SelectedIndexChanged(object sender, EventArgs e) {

        }

        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (CmbBranch.SelectedItem.Text == "Select Branch")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Project !!!','warning')", true);
                return;
            }
            if (CmbDepartment.SelectedItem.Text == "Select Department")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Plz Select Department !!!','warning')", true);
                return;
            }

            chkAllEmployees.Visible = false;
            DateTime Startdate = Convert.ToDateTime(TxtStartDate.Text);
            DateTime Enddate = Convert.ToDateTime(TxtEndDate.Text);
            string emp_branch = CmbBranch.SelectedItem.Text;
            branch_id = int.Parse(CmbBranch.SelectedValue);
            string emp_dept = CmbDepartment.SelectedItem.Text;
            dept_id = int.Parse(CmbDepartment.SelectedValue);
            DataTable dt = blu.getDept_EmployeeList(dept_id, branch_id);
            
            if (Chkemp.Checked)
            {
                branch_id = 0;
                dept_id = int.Parse(CmbDepartment.SelectedValue);
                emp_id = 0;
            }
            else
            {
                branch_id = 0;
                dept_id = 0;
                emp_id = int.Parse(CmbEmployee.SelectedValue);
            }

            Response.Redirect(String.Format("monthlyAttendanceList?Startdate={0}&Enddate={1}&emp_id={2}&emp_dept={3}&branch_id={4}&dept_id={5}", Server.UrlEncode(Startdate.ToString()), Server.UrlEncode(Enddate.ToString()), Server.UrlEncode(emp_id.ToString()), Server.UrlEncode(emp_dept.ToString()), Server.UrlEncode(branch_id.ToString()), Server.UrlEncode(dept_id.ToString())));
        }

        protected void BtnReset_Click(object sender, EventArgs e) {
            Response.Redirect("monthlyAttendance");
        }
    }
}