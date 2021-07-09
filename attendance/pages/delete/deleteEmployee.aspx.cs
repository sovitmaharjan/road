using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.delete
{
    public partial class deleteEmployee : System.Web.UI.Page
    {
        attendance blu = new attendance();
        int branch_id, dept_id, emp_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBranch();
                CmbBranch.Items[0].Attributes["disabled"] = "disabled";
                CmbEmployee.Enabled = false;
                txtEmpId.Text = "";
                BtnDelete.Visible = false;
                BtnReset.Visible = false;

                //DataTable dt = blu.getBranch_DepartmentList(1);
                //if (dt.Rows.Count > 0)
                //{
                //    CmbDepartment.DataSource = dt;
                //    CmbDepartment.DataTextField = "DEPT_NAME";
                //    CmbDepartment.DataValueField = "DEPT_ID";
                //    CmbDepartment.DataBind();
                //    CmbDepartment.Items.Insert(0, "Select Department");
                //    CmbDepartment.Items[0].Attributes["disabled"] = "disabled";


                //    CmbEmployee.Items.Clear();
                //    txtEmpId.Text = " ";

                //    CmbEmployee.Enabled = true;
                //    txtEmpId.Enabled = true;
                //}
                //else
                //{
                //    loadBranch();
                //    CmbDepartment.Items.Clear();
                //    CmbEmployee.Items.Clear();
                //    txtEmpId.Text = " ";
                //    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available!!!!','warning')", true);
                //}
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
            CmbEmployee.DataTextField = "emp_fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");
        }
        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDepartment.Enabled = true;
            CmbEmployee.Enabled = false;
            CmbBranch.Items[0].Attributes["disabled"] = "disabled";

            branch_id = Convert.ToInt32(CmbBranch.SelectedValue);
            DataTable dt = blu.getBranch_DepartmentList(branch_id);
            if (dt.Rows.Count > 0)
            {
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";


                CmbEmployee.Items.Clear();
                txtEmpId.Text = " ";

                CmbEmployee.Enabled = true;
                txtEmpId.Enabled = true;
            }
            else
            {
                loadBranch();
                CmbDepartment.Items.Clear();
                CmbEmployee.Items.Clear();
                txtEmpId.Text = " ";
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available!!!!','warning')", true);
            }
        }
        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbEmployee.Enabled = true;
            CmbBranch.Items[0].Attributes["disabled"] = "disabled";
            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";

            if (CmbBranch.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First  !!!!','warning')", true);
                loadDepartment();
                return;
            }
            else
            {
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
            }

        }
        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbBranch.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First  !!!!','warning')", true);
                loadBranch();
                return;
            }
            else if (CmbDepartment.SelectedIndex == 0)
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
            loadBranch();
            loadDepartment();
            CmbDepartment.Enabled = true;
            loadEmployee();
            CmbEmployee.Enabled = true;
            emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
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
                loadBranch();
                loadDepartment();
                loadEmployee();
                txtEmpId.Text = "";
                CmbDepartment.Enabled = false;
                CmbEmployee.Enabled = false;
            }
        }

        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (CmbBranch.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First  !!!!','warning')", true);
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

            ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Alert!!!','Employee will be Deleted with its all Attendance.','warning')", true);
            
            int emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAll_Info(emp_id);
            GridView.DataSource = dt;
            GridView.DataBind();
            BtnDelete.Visible = true;
            BtnReset.Visible = true;
            
        }

        int j;
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView.Rows)
            {
                string emp_id = (row.Cells[1].FindControl("EMP_ID") as Label).Text;

                j = blu.deleteEmployee(emp_id);
            }
            if (j > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done. !!!','Employee has been successfully Deleted.','success').then((value) => { window.location ='DeleteEmployee'; });", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Error!','Employee Cannot be Deleted.!!!','warning')", true);
            }
                
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteEmployee");
        }
    }
}