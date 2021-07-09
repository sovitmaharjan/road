using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.systemSetup.HODAssign
{
    public partial class HODAssign : System.Web.UI.Page
    {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDepartment();
                loadEmployee();
                DataTable dt = blu.getHODAssigned();
                GridView.DataSource = dt;
                GridView.DataBind();

            }
            else
            {
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
                
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
            CmbDepartment.Items[0].Selected = true;
            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
        }
        public void loadEmployee()
        {
            DataTable dt = blu.getEmployees();
            CmbEmployee.DataSource = dt;
            CmbEmployee.DataTextField = "emp_fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");
            CmbEmployee.Items[0].Selected = true;
            CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
        }

        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmpId.Text = CmbEmployee.SelectedValue;
        }

        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            int emp_id = Convert.ToInt16(txtEmpId.Text);
            DataTable dt = blu.getAll_Info(emp_id);
            if (dt.Rows.Count > 0)
            {
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            }
            else
            {
                loadEmployee();
                txtEmpId.Text = "";
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID !!!!','warning')", true);
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (CmbDepartment.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Select Department First !!!!','warning')", true);
                return;
            }
            if (CmbEmployee.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Select Employee !!!!','warning')", true);
                return;
            }
            string emp_id = txtEmpId.Text;
            string dept_id = CmbDepartment.SelectedValue;
            int j = blu.manageHOD(dept_id, emp_id);
            if (j > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done.!','HOD Assigned Successfully','success').then((value) => { window.location ='HODAssign'; });", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Error While Saving. !!!','warning')", true);
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HODAssign");
        }
    }
}