using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.attendanceReport.attendanceDetail
{
    public partial class attendanceDetail : System.Web.UI.Page
    {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBranch();
                CmbBranch.Items[0].Attributes.Add("disabled", "disabled");

            }
        }
        int branch = 0;
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
            branch = Convert.ToInt32(CmbBranch.SelectedValue);
            DataTable dt = blu.getDepartmentList(branch);
            if (dt.Rows.Count > 0)
            {
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");
                CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");
            }
            else
            {
                CmbDepartment.Items.Clear();
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available!!!!','warning')", true);

            }
        }
        protected void chkDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (CmbBranch.SelectedItem.Text == "Select Branch")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First!!!!','warning')", true);
                chkDepartment.Checked = false;

                return;
            }
            if (chkDepartment.Checked)
            {
                CmbDepartment.Items.Clear();
                CmbDepartment.Enabled = false;
            }
            else
            {
                loadDepartment();
                CmbDepartment.Enabled = true;
            }
        }

        int department;
        string dept_name;
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (TxtNepaliDate.Text == "" || nepaliDate2.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Date Field cannot be emptied. !!!','warning')</script>");
                return;
            }
            if (condition.SelectedItem.Text == "Select Any" || condition.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Any Record from dropdown !!!!','warning')", true);
                return;
            }

            DateTime date_from = Convert.ToDateTime(TxtStartDate.Text);
            DateTime date_to = Convert.ToDateTime(TxtEndDate.Text);
            string branch_name = CmbBranch.SelectedItem.Text;
            int branch = Convert.ToInt32(CmbBranch.SelectedValue);
            
            int con = Convert.ToInt32(condition.SelectedValue);

            if(chkDepartment.Checked)
            {
                department = 0;
                dept_name = "All";
            }
            else
            {
                if (CmbDepartment.SelectedItem.Text == "Select Department")
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department First !!!!','warning')", true);
                    return;
                }
                dept_name = CmbDepartment.SelectedItem.Text;
                department = Convert.ToInt32(CmbDepartment.SelectedValue);
            }
                Response.Redirect(String.Format("attendanceDetailList?date_from={0}&date_to={1}&branch_name={2}&branch={3}&dept_name={4}&department={5}&con={6}", Server.UrlEncode(date_from.ToString()), Server.UrlEncode(date_to.ToString()), Server.UrlEncode(branch_name.ToString()), Server.UrlEncode(branch.ToString()), Server.UrlEncode(dept_name.ToString()), Server.UrlEncode(department.ToString()), Server.UrlEncode(con.ToString())));
        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("attendanceDetail");
        }
    }
}