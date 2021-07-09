using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.attendanceReport.subsituteLeave
{
    public partial class subsituteLeave : System.Web.UI.Page
    {
        attendance blu = new attendance();
        DataTable dt;
        int dept_id, emp_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDepartment();
                CmbEmployee.Enabled = false;
                Chkemp.Enabled = false;
            }
        }

        public void loadDepartment()
        {
            dt = blu.getDepartment();
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

        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            dept_id = Convert.ToInt32(CmbDepartment.SelectedValue);
            dt = blu.getDept_EmployeeList(dept_id, 1);
            if (dt.Rows.Count > 0)
            {
                CmbEmployee.DataSource = dt;
                CmbEmployee.DataTextField = "emp_fullname";
                CmbEmployee.DataValueField = "EMP_ID";
                CmbEmployee.DataBind();
                CmbEmployee.Items.Insert(0, "Select Employee");
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
                txtEmpId.Text = "";
                Chkemp.Enabled = true;
                CmbEmployee.Enabled = true;

            }
            else
            {
                CmbEmployee.Enabled = false;
                txtEmpId.Text = "";
                Chkemp.Enabled = false;
                Chkemp.Checked = false;
                loadDepartment();
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Found in Selected Department. !!!','warning')", true);
                return;
            }
        }

        protected void chkDept_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDept.Checked)
            {
                CmbDepartment.Items.Clear();
                CmbDepartment.Items.Insert(0, "All Departments");
                CmbDepartment.Enabled = false;
                CmbEmployee.Items.Clear();
                CmbEmployee.Items.Insert(0, "All Employees");
                CmbEmployee.Enabled = false;
                txtEmpId.Text = "";
                txtEmpId.Enabled = false;
                Chkemp.Enabled = false;
            }
            else
            {
                loadDepartment();
                CmbDepartment.Enabled = true;
                CmbEmployee.Items.Clear();
                txtEmpId.Enabled = true;
            }
        }

        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            txtEmpId.Text = CmbEmployee.SelectedValue;
        }

        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            loadDepartment();
            CmbDepartment.Enabled = true;
            CmbEmployee.Enabled = true;
            emp_id = int.Parse(txtEmpId.Text);
            dt = blu.getAll_Info(emp_id);
            if (dt.Rows.Count > 0)
            {
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                CmbDepartment.SelectedValue = dt.Rows[0]["DEPT_ID"].ToString();
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
                CmbEmployee.Enabled = true;
                CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID !!!!','warning')", true);
                CmbDepartment.Enabled = false;
                CmbEmployee.Enabled = false;
            }
        }

        protected void Chkemp_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkemp.Checked)
            {
                CmbEmployee.Items.Clear();
                CmbDepartment.Items.Insert(0, "All Employees");
                CmbEmployee.Enabled = false;
                txtEmpId.Text = "";
                txtEmpId.Enabled = false;
            }
            else
            {
                if (CmbDepartment.Text == "Select Department")
                {
                    loadDepartment();
                    CmbEmployee.Enabled = false;
                    Chkemp.Enabled = false;

                }
                else
                {
                    dept_id = Convert.ToInt32(CmbDepartment.SelectedValue);
                    dt = blu.getDept_EmployeeList(dept_id, 1);
                    if (dt.Rows.Count > 0)
                    {
                        CmbEmployee.DataSource = dt;
                        CmbEmployee.DataTextField = "emp_fullname";
                        CmbEmployee.DataValueField = "EMP_ID";
                        CmbEmployee.DataBind();
                        CmbEmployee.Items.Insert(0, "Select Employee");
                        CmbEmployee.Items[0].Attributes["disabled"] = "disabled";

                        Chkemp.Enabled = true;
                    }
                    else
                    {
                        CmbEmployee.Enabled = false;
                        txtEmpId.Text = "";
                        Chkemp.Enabled = false;
                        Chkemp.Checked = false;
                        loadDepartment();
                        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Found in Selected Department. !!!','warning')", true);
                        return;
                    }
                }

            }
            
        }

        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            //if (TxtStartDate.Text == "" || TxtEndDate.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Invalid Date. !!!','warning')", true);
            //    return;
            //}
            //DateTime startDate = Convert.ToDateTime(TxtStartDate.Text);
            //DateTime endDate = Convert.ToDateTime(TxtEndDate.Text);
            //int result = DateTime.Compare(startDate, endDate);
            //if (result > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','End Date Greater than Start Date !!!','warning')", true);
            //    return;
            //}
            if (chkDept.Checked)
            {
                dept_id = 0;
                emp_id = 0;
            }
            else if (Chkemp.Checked)
            {
                dept_id = Convert.ToInt16(CmbDepartment.SelectedValue);
                emp_id = 0;
            }
            else
            {
                dept_id = Convert.ToInt16(CmbDepartment.SelectedValue);
                emp_id = Convert.ToInt16(txtEmpId.Text);
            }
            Response.Redirect("subsituteLeaveLapseList?startDate=" + "&dept_id=" + dept_id + "&emp_id=" + emp_id);
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubsituteLeaveLapse");
        }
    }
}