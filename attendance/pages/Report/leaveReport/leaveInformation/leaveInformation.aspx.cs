using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.leaveReport.leaveInformation {
    public partial class leaveInformation : System.Web.UI.Page {
        attendance blu = new attendance();
        int branch, department, empid;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                loadBranch();
                CmbBranch.Items[0].Attributes.Add("disabled", "disabled");
                CmbEmployee.Enabled = false;
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
                CmbBranch.SelectedIndex = 1;
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
        public void loadDepartment()
        {
            DataTable dt = blu.getDepartment();
            CmbDepartment.DataSource = dt;
            CmbDepartment.DataTextField = "DEPT_NAME";
            CmbDepartment.DataValueField = "DEPT_ID";
            CmbDepartment.DataBind();
            CmbDepartment.Items.Insert(0, "Select Department");
        }

        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e) {
            txtbr_id.Text = CmbBranch.SelectedValue.ToString();
            branch = Convert.ToInt32(CmbBranch.SelectedValue);
            dt = blu.getDepartmentList(branch);
            if (dt.Rows.Count > 0) {
                CmbDepartment.Enabled = true;

                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");
                CmbDepartment.Items[0].Selected = true;

                txtdept_id.Text = " ";
                CmbEmployee.Items.Clear();
                txtEmpId.Text = " ";
            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available!!!!','warning')", true);
            }
        }

        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e) {
            CmbEmployee.Enabled = true;
            txtdept_id.Text = CmbDepartment.SelectedValue.ToString();
            branch = Convert.ToInt32(CmbBranch.SelectedValue);
            department = Convert.ToInt32(CmbDepartment.SelectedValue);
            dt = blu.getDept_EmployeeList(department, branch);
            if (dt.Rows.Count > 0) {
                CmbEmployee.DataSource = dt;
                CmbEmployee.DataTextField = "emp_fullname";
                CmbEmployee.DataValueField = "EMP_ID";
                CmbEmployee.DataBind();
                CmbEmployee.Items.Insert(0, "Select Employee");

                txtEmpId.Text = " ";
            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Available!!!!','warning')", true);
            }
        }

        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e) {
            txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
        }

        protected void txtEmpId_TextChanged(object sender, EventArgs e) {
            empid = int.Parse(txtEmpId.Text);
            dt = blu.getAllInfo(empid);
            if (dt.Rows.Count > 0) {
                CmbBranch.DataSource = dt;
                CmbBranch.DataTextField = "BRANCH_Name";
                CmbBranch.DataBind();
                txtbr_id.Text = dt.Rows[0]["BRANCH_ID"].ToString();

                CmbDepartment.Enabled = true;
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataBind();
                txtdept_id.Text = dt.Rows[0]["DEPT_ID"].ToString();

                CmbEmployee.Enabled = true;
                CmbEmployee.DataSource = dt;
                CmbEmployee.DataTextField = "emp_fullname";
                CmbEmployee.DataBind();
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();

            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Available with this ID!!!!','warning')", true);
            }
        }

        int EMPID = 0;
        string emp_name = "";
        protected void BtnLoadMonthlyAttendance_Click(object sender, EventArgs e) {
            if (CmbBranch.SelectedItem.Text == "Select Branch") {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First!!!!','warning')", true);
                return;
            }
            if (CmbDepartment.SelectedItem.Text == "Select Department") {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department!!!!','warning')", true);
                return;
            }
            if (CmbEmployee.SelectedItem.Text == "Select Employee") {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','PlZ Select Employee!!!!','warning')", true);
                return;
            }
            int BRANCHID = Convert.ToInt32(CmbBranch.SelectedValue);
            int DEPTID = Convert.ToInt32(CmbDepartment.SelectedValue);
            string emp_branch = CmbBranch.SelectedItem.Text;
            string emp_dept = CmbDepartment.SelectedItem.Text;
            EMPID = Convert.ToInt32(txtEmpId.Text);
            emp_name = CmbEmployee.SelectedItem.Text;



            Response.Redirect(String.Format("leaveInformationList?BRANCHID={0}&DEPTID={1}&EMPID={2}&emp_branch={3}&emp_dept={4}&emp_name={5}", Server.UrlEncode(BRANCHID.ToString()), Server.UrlEncode(DEPTID.ToString()), Server.UrlEncode(EMPID.ToString()), Server.UrlEncode(emp_branch.ToString()), Server.UrlEncode(emp_dept.ToString()), Server.UrlEncode(emp_name.ToString())));
        }

        protected void BtnCancelMonthlyAttendance_Click(object sender, EventArgs e) {
            Response.Redirect("leaveInformation");

        }
    }
}