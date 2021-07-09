using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.leaveReport.leaveTakenDetail {
    public partial class leaveTakenDetail : System.Web.UI.Page {
        attendance blu = new attendance();
        int branch_id, dept_id, emp_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBranch();
                CmbBranch.Items[0].Attributes.Add("disabled", "disabled");
                CmbEmployee.Enabled = false;
                loadLeave();
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

        public void loadEmployee()
        {
            DataTable dt = blu.getEmployees();
            CmbEmployee.DataSource = dt;
            CmbEmployee.DataTextField = "EMP_FULLNAME";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Department");
        }

        public void loadLeave() {
            DataTable dt = blu.getLeaveList();
            CmbLeave.DataSource = dt;
            CmbLeave.DataTextField = "LEAVE_NAME";
            CmbLeave.DataValueField = "LEAVE_ID";
            CmbLeave.DataBind();
            CmbLeave.Items.Insert(0, "Select Leave");
        }

        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e) {
            branch_id = Convert.ToInt32(CmbBranch.SelectedValue);
            DataTable dt = blu.getBranch_DepartmentList(branch_id);
            if (dt.Rows.Count > 0) {
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");

                CmbEmployee.Items.Clear();
                txtEmpId.Text = " ";

                CmbEmployee.Enabled = true;
                txtEmpId.Enabled = true;
            } else {
                CmbDepartment.Items.Clear();
                CmbEmployee.Items.Clear();
                txtEmpId.Text = " ";
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available!!!!','warning')", true);
            }

        }

        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e) {
            CmbEmployee.Enabled = true;
            branch_id = Convert.ToInt32(CmbBranch.SelectedValue);
            dept_id = Convert.ToInt32(CmbDepartment.SelectedValue);
            DataTable dt1 = blu.getDept_EmployeeList(dept_id, branch_id);
            CmbEmployee.DataSource = dt1;
            CmbEmployee.DataTextField = "emp_fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");

        }

        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e) {
            txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
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

                CmbDepartment.Enabled = true;
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();

                CmbEmployee.Enabled = true;
                CmbEmployee.DataSource = dt;
                CmbEmployee.DataTextField = "emp_fullname";
                CmbEmployee.DataValueField = "EMP_ID";
                CmbEmployee.DataBind();
            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID !!!!','warning')", true);
            }
        }

        

        protected void BtnLoad_Click(object sender, EventArgs e) {

            int eid = 0, leave_id = 0, dept_id; DateTime sdate, edate;

            if (txtStartDate.Text == "" || txtEndDate.Text == "") {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Date Field cannot be emptied !!!','warning')</script>");
                return;
            }

            if(ChkDept.Checked)
            {
                dept_id = 0;
            }
            else
            {
                if (CmbDepartment.SelectedItem.Text == "Select Department")
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department First !!!!','warning')", true);
                    return;
                }
                dept_id = Convert.ToInt32(CmbDepartment.SelectedValue.ToString());
                if (chkEmployee.Checked)
                {
                    eid = 0;
                }
                else
                {
                    if (CmbEmployee.SelectedItem.Text == "Select Employee")
                    {
                        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Employee !!!!','warning')", true);
                        return;
                    }
                    chkEmployee.Checked = false;
                    eid = int.Parse(txtEmpId.Text);
                }
            }   
            
            

            sdate = Convert.ToDateTime(txtStartDate.Text);
            edate = Convert.ToDateTime(txtEndDate.Text);
            if (chkLeave.Checked)
            {

                leave_id = 0;
            }
            else
            {

                if (CmbLeave.SelectedItem.Text == "Select Leave" || CmbLeave.SelectedItem.Text == "")
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','PlZ Select Leave !!!!','warning')", true);
                    return;
                }
                leave_id = Convert.ToInt32(CmbLeave.SelectedValue);
            }

            Response.Redirect(String.Format("leaveTakenDetailList?sdate={0}&edate={1}&eid={2}&dept_id={3}&leave_id={4}", Server.UrlEncode(sdate.ToString()), Server.UrlEncode(edate.ToString()), Server.UrlEncode(eid.ToString()), Server.UrlEncode(dept_id.ToString()), Server.UrlEncode(leave_id.ToString())));
        }

        protected void BtnReset_Click(object sender, EventArgs e) {
            Response.Redirect("leaveTakenDetail");
        }

        protected void chkLeave_CheckedChanged(object sender, EventArgs e){

            if (chkLeave.Checked)
            {
                CmbLeave.Enabled = false;
                CmbLeave.Items.Clear();
            }
            else
            {
                CmbLeave.Enabled = true;
                loadLeave();
            }
        }

        protected void chkEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEmployee.Checked)
            {
                CmbEmployee.Enabled = false;
                CmbEmployee.Items.Clear();
                if (CmbDepartment.SelectedItem.Text == "Select Department")
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department First !!!!','warning')", true);
                    return;
                }
            }else
            {
                CmbEmployee.Enabled = true;
                loadEmployee();
            }
        }

        protected void ChkDept_CheckedChanged(object sender, EventArgs e)
        {
            if(ChkDept.Checked)
            {
                CmbDepartment.Enabled = false;
                CmbDepartment.Items.Clear();

                CmbEmployee.Enabled = false;
                CmbEmployee.Items.Clear();

                txtEmpId.Enabled = false;
                txtEmpId.Text = "";
                chkEmployee.Enabled = false;
            }
            else
            {
                CmbDepartment.Enabled = true;
                loadDepartment();
                txtEmpId.Enabled = true;
                chkEmployee.Enabled = true;
            }
        }
    }
}