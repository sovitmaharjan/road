using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace attendance.pages.attendanceManagement.leaveAssignment
{
    public partial class leaveAssignment : System.Web.UI.Page
    {

        attendance blu = new attendance();
        int branch_id, dept_id, emp_id;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.AddHeader("Refresh", "2");
            if (!IsPostBack)
            {
                loadBranch();
                loadEmployee();
                loadHOD();
                CmbBranch.Items[0].Attributes["disabled"] = "disabled";
                CmbEmployee.Enabled = false;
                btnSave.Visible = false;
                btnLoad.Visible = true;
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

        public void loadHOD()
        {
            DataTable dt = blu.getHODList();
            CmbApproved.DataSource = dt;
            CmbApproved.DataTextField = "emp_Fullname";
            CmbApproved.DataValueField = "EMP_ID";
            CmbApproved.DataBind();
            CmbApproved.Items.Insert(0, "Select HOD");
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
                txtEMPID.Text = " ";

                CmbEmployee.Enabled = true;
                txtEMPID.Enabled = true;
            }
            else
            {
                loadBranch();
                CmbDepartment.Items.Clear();
                CmbEmployee.Items.Clear();
                txtEMPID.Text = " ";
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
                txtEMPID.Text = " ";
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

        protected void txtEMPID_TextChanged(object sender, EventArgs e)
        {
            int emp_id = int.Parse(txtEMPID.Text);
            dt = blu.getAll_Info(emp_id);
            if (dt.Rows.Count > 0)
            {
                CmbDepartment.SelectedValue = dt.Rows[0]["DEPT_ID"].ToString();
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
                CmbEmployee.Enabled = true;
                CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' No Employee Record Found With This ID !!!','warning')", true);
                return;
            }

            dt = blu.getleave_emp(emp_id);
            if (dt.Rows.Count > 0)
            {
                CmbLeavename.DataSource = dt;
                CmbLeavename.DataTextField = "LEAVE_NAME";
                CmbLeavename.DataValueField = "LEAVE_ID";
                CmbLeavename.DataBind();
                CmbLeavename.Items.Insert(0, "Select Leave");
                CmbLeavename.Items[0].Selected = true;
                CmbLeavename.Items[0].Attributes["disabled"] = "disabled";
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave Assigned. !!!','warning')", true);
            }

            dt = blu.getHODbyID(emp_id);
            if (dt.Rows.Count > 0)
            {
                CmbApproved.SelectedValue = dt.Rows[0]["HOD_ID"].ToString();
            }
            else
            {
                dt = blu.getHODList();
                CmbApproved.DataSource = dt;
                CmbApproved.DataTextField = "HOD_NAME";
                CmbApproved.DataValueField = "HOD_ID";
                CmbApproved.DataBind();
                CmbApproved.Items.Insert(0, "NO HOD");
            }
        }



        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            emp_id = Convert.ToInt32(CmbEmployee.SelectedValue);
            txtEMPID.Text = CmbEmployee.SelectedValue;
            DataTable dt1 = blu.getHODbyID(emp_id);
            if (dt1.Rows.Count > 0)
            {
                CmbApproved.SelectedValue = dt1.Rows[0]["HOD_ID"].ToString();
            }
            else
            {
                dt = blu.getHODList();
                CmbApproved.DataSource = dt;
                CmbApproved.DataTextField = "HOD_NAME";
                CmbApproved.DataValueField = "HOD_ID";
                CmbApproved.DataBind();
                CmbApproved.Items.Insert(0, "NO HOD");
            }

            dt = blu.getleave_emp(emp_id);
            if (dt.Rows.Count > 0)
            {
                CmbLeavename.DataSource = dt;
                CmbLeavename.DataTextField = "LEAVE_NAME";
                CmbLeavename.DataValueField = "LEAVE_ID";
                CmbLeavename.DataBind();
                CmbLeavename.Items.Insert(0, "Select Leave");
                CmbLeavename.Items[0].Selected = true;
                CmbLeavename.Items[0].Attributes["disabled"] = "disabled";
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave Assigned. !!!','warning')", true);
            }

        }
        protected void CmbApproved_SelectedIndexChanged(object sender, EventArgs e)
        {
            int UserTypeId = 2;
            DataTable dt = blu.getUserTypeList(UserTypeId);

        }
        protected void btnLoad_Click(object sender, EventArgs e)
        {
            if (CmbBranch.SelectedItem.Text == "Select Branch")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Branch !!!','warning')", true);
                return;
            }
            if (CmbDepartment.SelectedItem.Text == "Select Department")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Department !!!','warning')", true);
                return;
            }

            if (CmbLeavename.SelectedItem.Text == "Select Leave")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Leave Name !!!','warning')", true);
                return;
            }
            if (txtDays.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Leave Days !!!','warning')", true);
                return;
            }

            if (CmbMonth.SelectedItem.Text == "Select Month")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Month!!!','warning')", true);
                return;
            }
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Employee Name");
            dt2.Columns.Add("Leave");
            dt2.Columns.Add("Year");
            dt2.Columns.Add("Month");
            dt2.Columns.Add("Qty");
            dt2.Columns.Add("Approved By");

            DataRow dr = null;
            if (ViewState["emp"] != null)
            {
                for (int i = 0; i < 1; i++)
                {
                    dt2 = (DataTable)ViewState["emp"];
                    if (dt2.Rows.Count > 0)
                    {
                        dr = dt2.NewRow();
                        dr["Employee Name"] = CmbEmployee.SelectedItem;
                        dr["Leave"] = CmbLeavename.SelectedItem;
                        dr["Year"] = txtDate.Text;
                        dr["Month"] = CmbMonth.SelectedItem;
                        dr["Qty"] = txtDays.Text;
                        dr["Approved By"] = CmbApproved.SelectedItem;
                        dt2.Rows.Add(dr);
                        GridView1.DataSource = dt2;
                        GridView1.DataBind();
                    }
                }
            }
            else
            {
                dr = dt2.NewRow();
                dr["Employee Name"] = CmbEmployee.SelectedItem;
                dr["Leave"] = CmbLeavename.SelectedItem;
                dr["Year"] = txtDate.Text;
                dr["Month"] = CmbMonth.SelectedItem;
                dr["Qty"] = txtDays.Text;
                dr["Approved By"] = CmbApproved.SelectedItem;
                dt2.Rows.Add(dr);
                GridView1.DataSource = dt2;
                GridView1.DataBind();
                btnSave.Visible = true;
            }
            ViewState["emp"] = dt2;
            btnLoad.Visible = false;
        }
        int Actionflag = 0;
        int sno = 0;
        decimal given = 0;
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int empid = Convert.ToInt32(CmbEmployee.SelectedValue);
            given = Convert.ToDecimal(txtDays.Text);
            int leaveid = Convert.ToInt32(CmbLeavename.SelectedValue);
            int month = Convert.ToInt32(CmbMonth.SelectedValue);
            int ApprovedBy = Convert.ToInt32(CmbApproved.SelectedValue);
            int date = Convert.ToInt32(txtDate.Text);

            blu.ForceLeaveAssign(Actionflag, sno, leaveid, Convert.ToDecimal(given), month, date, ApprovedBy, ChkOpen.Checked ? "true" : "false", empid);

            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Leave Assignment Save Successfully').then((value) => { window.location ='leaveAssignment'; });", true);
            }
        }



        protected void DDLLeaveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLLeaveType.SelectedIndex == 1)
            {
                DataTable dt = blu.getMonthList();
                CmbMonth.DataSource = dt;
                CmbMonth.DataTextField = "MONTH_Name";
                CmbMonth.DataValueField = "MONTH_ID";
                CmbMonth.DataBind();
                CmbMonth.Items.Insert(0, "Select Month");

            }
            if (DDLLeaveType.SelectedIndex == 2)
            {
                DataTable dt = blu.getNepaliMonthList();
                CmbMonth.DataSource = dt;
                CmbMonth.DataTextField = "MONTH_Name";
                CmbMonth.DataValueField = "MONTH_ID";
                CmbMonth.DataBind();
                CmbMonth.Items.Insert(0, "Select Month");
            }
        }

        protected void CmbLeavename_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
            CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            CmbLeavename.Items[0].Attributes["disabled"] = "disabled";

        }
    }
}