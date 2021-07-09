using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.attendanceManagement.forceAttendanceBatch {
    public partial class forceAttendanceBatch : System.Web.UI.Page {
        attendance blu = new attendance();

        int branch;
        protected void Page_Load(object sender, EventArgs e) {
            BtnSave.Visible = false;

            if (!IsPostBack)
            {
                loadBranch();
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
        public void loadBranch()
        {
            dt = blu.getList("tbl_comp_branch", "", 0);
            if (dt.Rows.Count == 1)
            {
                string branch_id = dt.Rows[0]["BRANCH_ID"].ToString();
                CmbBranch.DataSource = dt;
                CmbBranch.DataTextField = "BRANCH_NAME";
                CmbBranch.DataValueField = "BRANCH_ID";
                CmbBranch.SelectedValue = branch_id;
                CmbBranch.DataBind();
                CmbBranch.Items.Insert(0, "Select Branch");
                CmbBranch.Items[0].Attributes["disabled"] = "disabled";
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

        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e) {
            CmbBranch.Items[0].Attributes.Add("disabled", "disabled");

            if (CmbBranch.SelectedValue == "Select Branch") {
                CmbDepartment.Items.Clear();
                CmbBranch.Focus();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Select Branch !!!','warning')</script>");
            } else {
                branch = Convert.ToInt32(CmbBranch.SelectedValue);
                DataTable dt = blu.getDepartmentList(branch);
                if (dt.Rows.Count > 0) {
                    CmbDepartment.DataSource = dt;
                    CmbDepartment.DataTextField = "DEPT_NAME";
                    CmbDepartment.DataValueField = "DEPT_ID";
                    CmbDepartment.DataBind();
                    // CmbDepartment.Items.Insert(0, "Select Department");
                    //  CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");

                } else {
                    CmbDepartment.Items.Clear();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','No Department Available!','warning')</script>");
                    AllDept.Checked = true;
                    CmbDepartment.Enabled = false;
                }
            }
        }

        protected void AllDept_CheckedChanged(object sender, EventArgs e) {
            if (AllDept.Checked) {
                CmbDepartment.Enabled = false;
                CmbDepartment.Items.Clear();
                int branchid = Convert.ToInt32(CmbBranch.SelectedValue);
                DataTable dt = blu.getEmployeeByBranch(branchid);
            } else {
                CmbDepartment.Enabled = true;
                CmbBranch.Focus();
            }
        }

        protected void DefTime_CheckedChanged(object sender, EventArgs e) {
            if (DefTime.Checked) {
                TxtTime.Enabled = false;
                TxtTime.Text = "";
            } else {
                TxtTime.Enabled = true;
                TxtTime.Focus();
            }
        }
        DataTable dt, dtt;
        protected void BtnLoad_Click(object sender, EventArgs e) {
            BtnSave.Visible = true;
            if (rbsta.Checked != true && rbsta1.Checked != true) {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Select Type !!!','warning')</script>");
                return;
            }
            if (CmbBranch.SelectedItem.Text == "Select Branch") {
                CmbDepartment.Items.Clear();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Select Branch First !!!','warning')</script>");
                return;
            }



            if (txtEndDate.Text == " ") {
                CmbDepartment.Items.Clear();
                return;
            }

            if (TxtTime.Text == " " && DefTime.Checked != true) {
                CmbDepartment.Items.Clear();
                return;
            }

            if (TxtRemarks.Text == " ") {
                CmbDepartment.Items.Clear();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Remarks cannot be emptied !!!','warning')</script>");
                return;
            }


            string time;

            DateTime date = Convert.ToDateTime(txtEndDate.Text);
            int mode = rbsta.Checked ? 1 : 0;
            string branch = CmbBranch.SelectedItem.ToString();
            time = TxtTime.Text;

            if (AllDept.Checked != true && DefTime.Checked != true) {
                DataTable dt = blu.proc_forcebatch(date, branch, CmbDepartment.SelectedItem.ToString(), time, mode);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            } else if (AllDept.Checked && DefTime.Checked != true) {
                DataTable dt1 = blu.proc_AllDepartment(date, branch, time, mode);
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            } else if (AllDept.Checked && DefTime.Checked) {
                DataTable dt1 = blu.proc_AllDepartment(date, branch, time, mode);
                int counter = dt1.Rows.Count;
                for (int j = 0; j < counter; j++) {
                    string ID = dt1.Rows[j]["emp_id"].ToString();
                    int EMP_ID = int.Parse(ID);

                    dtt = blu.Proc_Get_Default_Time(EMP_ID, date);
                    time = dtt.Rows[j]["IN_START"].ToString();
                }
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            } else {
                dt = blu.proc_forcebatch(date, branch, CmbDepartment.SelectedItem.ToString(), time, mode);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e) {
            int empid = 0;
            string date = txtEndDate.Text;
            string Status = string.Empty;
            string time = "";
            string remark = TxtRemarks.Text;
            int mode = rbsta.Checked ? 1 : 0;

            for (int j = 0; j < GridView1.Rows.Count; j++) {
                CheckBox chk = (CheckBox)GridView1.Rows[j].Cells[0].FindControl("chk");
                if (chk.Checked) {
                    empid = Convert.ToInt32(GridView1.Rows[j].Cells[1].Text);
                    int i = blu.proc_Getworkid(empid, Convert.ToDateTime(txtEndDate.Text), time, remark, mode);
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Force Attendacne Batch saved Successfully').then((value) => { window.location ='forceAttendanceBatch'; });", true);
        }
        protected void BtnReset_Click(object sender, EventArgs e) {
            Response.Redirect("forceAttendanceBatch");
        }
    }
}