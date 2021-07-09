using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.rosterShiftInfo
{
    public partial class rosterShiftInfo : System.Web.UI.Page
    {
        attendance blu = new attendance();
        int branch_id, dept_id, emp_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBranch();
                CmbBranch.Items[0].Attributes.Add("disabled", "disabled");
                DataTable dt = blu.getBranch_DepartmentList(1);
                if (dt.Rows.Count > 0) {
                    CmbDepartment.DataSource = dt;
                    CmbDepartment.DataTextField = "DEPT_NAME";
                    CmbDepartment.DataValueField = "DEPT_ID";
                    CmbDepartment.DataBind();
                    CmbDepartment.Items.Insert(0, "Select Department");

                    CmbDepartment.Enabled = false;
                    CmbEmployee.Enabled = false;
                    CmbDepartment.Items.Clear();
                    CmbEmployee.Items.Clear();
                    txtEmpId.Text = " ";

                } else {
                    CmbDepartment.Items.Clear();
                    CmbEmployee.Items.Clear();
                    txtEmpId.Text = " ";
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available!!!!','warning')", true);
                }
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

        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            branch_id = Convert.ToInt32(CmbBranch.SelectedValue);
            DataTable dt = blu.getBranch_DepartmentList(branch_id);
            if (dt.Rows.Count > 0)
            {
                CmbDepartment.Enabled = true;
                CmbDepartment.Enabled = true;
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");

                CmbEmployee.Items.Clear();
                txtEmpId.Text = " ";

                CmbEmployee.Enabled = true;
                txtEmpId.Enabled = true;
            }
            else
            {
                CmbDepartment.Items.Clear();
                CmbEmployee.Items.Clear();
                txtEmpId.Text = " ";
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available!!!!','warning')", true);
            }

        }

        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            branch_id = Convert.ToInt32(CmbBranch.SelectedValue);
            dept_id = Convert.ToInt32(CmbDepartment.SelectedValue);
            DataTable dt1 = blu.getDept_EmployeeList(dept_id, branch_id);
            CmbEmployee.DataSource = dt1;
            CmbEmployee.DataTextField = "emp_fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");

        }

        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmpId.Text = CmbEmployee.SelectedValue.ToString();

        }

        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
            if (dt.Rows.Count > 0)
            {
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();

                CmbBranch.DataSource = dt;
                CmbBranch.DataTextField = "BRANCH_Name";
                CmbBranch.DataValueField = "BRANCH_ID";
                CmbBranch.DataBind();

                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();

                CmbEmployee.DataSource = dt;
                CmbEmployee.DataTextField = "emp_fullname";
                CmbEmployee.DataValueField = "EMP_ID";
                CmbEmployee.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID!!!!','warning')", true);
            }
        }

        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (txtNepaliDate.Text == "" || nepaliDate2.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Date Field cannot be emptied !!!','warning')</script>");
                return;
            }

            if (CmbBranch.SelectedItem.Text == "Select Project")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Project First!!!!','warning')", true);
                return;
            }
            if (CmbDepartment.SelectedItem.Text == "Select Department")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department!!!!','warning')", true);
                return;
            }
            if (CmbEmployee.SelectedItem.Text == "Select Employee")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','PlZ Select Employee!!!!','warning')", true);
                return;
            }
            DateTime startdate = Convert.ToDateTime(txtStartDate.Text);
            DateTime tilldate = Convert.ToDateTime(txtEndDate.Text);
            string emp_branch = CmbBranch.SelectedItem.Text;
            string emp_dept = CmbDepartment.SelectedItem.Text;
            string emp_name = CmbEmployee.SelectedItem.Text;

            int eid = int.Parse(txtEmpId.Text);

            Response.Redirect(String.Format("rosterShiftInfoList?startdate={0}&tilldate={1}&eid={2}&emp_branch={3}&emp_dept={4}&emp_name={5}", Server.UrlEncode(startdate.ToString()), Server.UrlEncode(tilldate.ToString()), Server.UrlEncode(eid.ToString()), Server.UrlEncode(emp_branch.ToString()), Server.UrlEncode(emp_dept.ToString()), Server.UrlEncode(emp_name.ToString())));
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("rosterShiftInfo");

        }
    }
}