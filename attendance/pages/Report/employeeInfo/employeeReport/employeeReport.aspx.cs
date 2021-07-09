using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.employeeInfo.employeeReport {
    public partial class employeeReport : System.Web.UI.Page {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                loadBranch();
                loadDepartment();
                loadStatus();
                loadType();
                CmbBranch.Items[0].Attributes["disabled"] = "disabled";

                //GridViewHelper helper = new GridViewHelper(this.GridView);
                //helper.RegisterGroup("DEPT_NAME", true, true);                
            }
        }

        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            row.BackColor = Color.AliceBlue;
            row.Cells[0].Font.Bold = true;

        }

        public void loadBranch() {
            DataTable dt = blu.getBranchList();
            if (dt.Rows.Count == 1) {
                string branch_id = dt.Rows[0]["BRANCH_ID"].ToString();
                CmbBranch.DataSource = dt;
                CmbBranch.DataTextField = "BRANCH_NAME";
                CmbBranch.DataValueField = "BRANCH_ID";
                CmbBranch.SelectedValue = branch_id;
                CmbBranch.DataBind();
                CmbBranch.Items.Insert(0, "Select Branch");
                CmbBranch.SelectedIndex = 1;
                loadDepartment();
            } else {
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
        public void loadStatus() {
            DataTable dt = blu.Getstatus();
            CmbStatus.DataSource = dt;
            CmbStatus.DataTextField = "STATUS_NAME";
            CmbStatus.DataValueField = "STATUS_ID";
            CmbStatus.DataBind();
            CmbStatus.Items.Insert(0, "Select Status");
            CmbStatus.Items[0].Attributes["disabled"] = "disabled";
        }

        public void loadType()
        {
            DataTable dt = blu.GetType();
            CmbType.DataSource = dt;
            CmbType.DataTextField = "type_name";
            CmbType.DataValueField = "type_id";
            CmbType.DataBind();
            CmbType.Items.Insert(0, "Select Type");
        }

        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e) {
            CmbDepartment.Enabled = true;
            CmbBranch.Items[0].Attributes["disabled"] = "disabled";

            int branch_id = Convert.ToInt32(CmbBranch.SelectedValue);
            DataTable dt = blu.getBranch_DepartmentList(branch_id);
            if (dt.Rows.Count > 0) {
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
            } else {
                loadBranch();
                CmbDepartment.Items.Clear();
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available!!!!','warning')", true);
            }
        }
        
        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e) {
            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
            CmbStatus.Items[0].Attributes["disabled"] = "disabled";
            CmbType.Items[0].Attributes["disabled"] = "disabled";
        }

        protected void ChkDept_CheckedChanged(object sender, EventArgs e) {
            CmbStatus.Items[0].Attributes["disabled"] = "disabled";
            CmbType.Items[0].Attributes["disabled"] = "disabled";
            if (ChkDept.Checked) {
                CmbDepartment.Enabled = false;
                CmbDepartment.Items.Clear();
            } else {
                loadDepartment();
                CmbDepartment.Enabled = true;
            }
        }

        protected void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ChkDept.Checked){

            }
            else
            {
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
            }
            CmbStatus.Items[0].Attributes["disabled"] = "disabled";
            CmbType.Items[0].Attributes["disabled"] = "disabled";
        }

        protected void CmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChkDept.Checked)
            {

            }
            else
            {
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
            }
            CmbStatus.Items[0].Attributes["disabled"] = "disabled";
            CmbType.Items[0].Attributes["disabled"] = "disabled";
        }

        protected void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChkDept.Checked)
            {

            }
            else
            {
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
            }
            CmbStatus.Items[0].Attributes["disabled"] = "disabled";
            CmbType.Items[0].Attributes["disabled"] = "disabled";
        }

        string query;
        protected void BtnLoad_Click(object sender, EventArgs e) {
            if (ChkDept.Checked)
            {

            }
            else
            {
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
            }
            CmbStatus.Items[0].Attributes["disabled"] = "disabled";
            CmbType.Items[0].Attributes["disabled"] = "disabled";
            int dept_id = 0;
            
            string status_id = CmbStatus.SelectedValue.ToString();
            if (CmbStatus.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Status.!!!','warning')", true);
            }
            if (CmbType.SelectedValue == "Select Type")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Type.!!!','warning')", true);
            }
            string mode_id = CmbType.SelectedValue.ToString();
            string sort = CmbSort.SelectedValue;
            if (ChkDept.Checked)
            {
                if (sort == "1")
                {
                    query = "select T1.*,Tbl_Org_Dept.DEPT_NAME from view_Emp_info as T1 inner join Tbl_Org_Dept on T1.Dept_Name=Tbl_Org_Dept.Dept_name where T1.Status_id = " + status_id + " and T1.mode_id =" + mode_id + "order by Tbl_Org_Dept.dept_parent,Tbl_Org_Dept.dept_name,T1.EMP_FULLNAME";
                }
                else
                {
                    query = "select T1.*,Tbl_Org_Dept.DEPT_NAME from view_Emp_info as T1 inner join Tbl_Org_Dept on T1.Dept_Name=Tbl_Org_Dept.Dept_name where T1.Status_id = " + status_id + " and T1.mode_id =" + mode_id + "order by Tbl_Org_Dept.dept_parent,Tbl_Org_Dept.dept_name,T1.Emp_Id";

                }
            }
            else
            {
                if (CmbDepartment.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department.!!!','warning')", true);
                }
                else
                {
                    dept_id = int.Parse(CmbDepartment.SelectedValue.ToString());
                    if (sort == "1")
                    {
                        query = "select T1.*,Tbl_Org_Dept.DEPT_NAME from view_Emp_info as T1 inner join Tbl_Org_Dept on T1.Dept_Name=Tbl_Org_Dept.Dept_name where T1.DEPT_ID = "+ dept_id +" and T1.Status_id = "+ status_id +" and T1.mode_id=" + mode_id + "order by Tbl_Org_Dept.dept_parent,Tbl_Org_Dept.dept_name,T1.EMP_FULLNAME";
                    }
                    else
                    {
                        query = "select T1.*,Tbl_Org_Dept.DEPT_NAME from view_Emp_info as T1 inner join Tbl_Org_Dept on T1.Dept_Name=Tbl_Org_Dept.Dept_name where T1.DEPT_ID = " + dept_id + " and T1.Status_id = " + status_id + " and T1.mode_id=" + mode_id + "order by Tbl_Org_Dept.dept_parent,Tbl_Org_Dept.dept_name,T1.Emp_Id";

                    }
                }
            }

            
            GridView.DataSource = null;

            DataTable dt = blu.EmployeeReport(query);
            GridView.DataSource = dt;
            GridView.DataBind();      

            
        }

        protected void BtnReset_Click(object sender, EventArgs e) {
            Response.Redirect("employeeReportList");
        }

        
    }
}