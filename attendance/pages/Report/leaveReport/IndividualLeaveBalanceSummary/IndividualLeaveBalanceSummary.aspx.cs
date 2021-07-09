using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.leaveReport.IndividualLeaveBalanceSummary
{
    public partial class IndividualLeaveBalanceSummary : System.Web.UI.Page
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
                GridView.Visible = true;
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

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }
        int flag = 0;
        string dept_name,  tdept_id;
        string dept_id = "";
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if(TxtStartDate.Text == "" )
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Start Date. !!!','warning')", true);
            }
            else if (TxtEndDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select End Date. !!!','warning')", true);
            }else if (CmbBranch.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch. !!!','warning')", true);
            }
            else
            {
                DateTime sdate = Convert.ToDateTime(TxtStartDate.Text);
                DateTime edate = Convert.ToDateTime(TxtEndDate.Text);
                if(chkDepartment.Checked){
                    foreach (GridViewRow row in GridView.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("chk2") as CheckBox);
                            if (chkRow.Checked)
                            {
                                dept_name = ((row.Cells[1].FindControl("DEPT_NAME") as Label).Text);
                                tdept_id = ((row.Cells[1].FindControl("DEPT_ID") as Label).Text);
                                if(dept_id == "")
                                {
                                    dept_id += tdept_id;
                                }
                                else
                                {
                                    dept_id += ", " + tdept_id;

                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Select atlest one of the checkbox!!!','warning')", true);
                            }
                        }
                    }
                }
                else
                {
                    if(CmbDepartment.SelectedValue == "0"){
                        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department. !!!','warning')", true);
                    }
                    else
                    {
                        dept_id = CmbDepartment.SelectedValue.ToString();
                    }
                }
                Response.Redirect("ViewIndividualLeaveBalanceSummary?startDate=" + sdate + "&endDate=" + edate + "&dept_id=" + dept_id);
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndividualLeaveBalanceSummary");
        }
    }
}