using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.leaveReport.DatewiseLeaveTakenSummary
{
    public partial class DatewiseLeaveTakenSummary : System.Web.UI.Page
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
        int branch;
        DataTable dt;
        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            branch = Convert.ToInt32(CmbBranch.SelectedValue);
            dt = blu.getDepartmentList(branch);
            if (dt.Rows.Count > 0)
            {
                CmbDepartment.Enabled = true;
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");
                CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");

            }
            else
            {
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
                branch = Convert.ToInt32(CmbBranch.SelectedValue);
                dt = blu.getDepartmentList(branch);
                GridView.DataSource = dt;
                GridView.DataBind();
            }
            else
            {
                GridView.Visible = false;
                loadDepartment();
                CmbDepartment.Enabled = true;
            }

        }
        DateTime startDate, endDate;
        int flag;
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (TxtNepaliDate.Text == "" || TxtStartDate.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Date Field cannot be emptied !!!','warning')</script>");
                return;
            }
            if (CmbBranch.SelectedItem.Text == "Select Branch")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First!!!!','warning')", true);

                return;
            }
            startDate = Convert.ToDateTime(TxtStartDate.Text);
            endDate = Convert.ToDateTime(TxtEndDate.Text);
            string branchName = CmbBranch.SelectedValue;
            int branch = Convert.ToInt32(CmbBranch.SelectedValue);
            flag = 0;

            if (chkDepartment.Checked)
            {
                foreach (GridViewRow row in GridView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chk2") as CheckBox);
                        if (chkRow.Checked)
                        {
                            string dept_name = ((row.Cells[1].FindControl("DEPT_NAME") as Label).Text);
                            blu.DatewiseLeaveTakenReport(startDate, endDate, dept_name, flag);
                            flag = 1;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Select atlest one of the Department!!!','warning')", true);
                        }
                    }
                }

            }
            else
            {

                if (CmbDepartment.SelectedItem.Text == "Select Department")
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department!!!!','warning')", true);

                    return;
                }
                string dept_name = CmbDepartment.SelectedItem.ToString();
                blu.DatewiseLeaveTakenReport(startDate, endDate, dept_name, flag);

            }

            Response.Redirect("ViewDatewiseLeaveTakenReport?startDate=" + startDate + "&endDate=" + endDate + "&branchName=" + branchName);
        }
    }
}