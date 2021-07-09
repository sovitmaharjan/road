using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.overTimeManagement {
    public partial class overTimeManagement : System.Web.UI.Page {

        attendance blu = new attendance();
        int branch_id;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack)
            {
                loadBranch();
            }
            btnSave.Visible = false;
        }
        public void loadBranch()
        {
            dt = blu.getBranchList();
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
        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            branch_id = Convert.ToInt32(CmbBranch.SelectedValue);
            dt = blu.getDepartmentList(branch_id);
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
        public void loadDepartment()
        {
            DataTable dt = blu.getDepartment();
            CmbDepartment.DataSource = dt;
            CmbDepartment.DataTextField = "DEPT_NAME";
            CmbDepartment.DataValueField = "DEPT_ID";
            CmbDepartment.DataBind();
            CmbDepartment.Items.Insert(0, "Select Department");
        }



        string dept;
        string dept_name, tdept;
        protected void btnLoad_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = "";
            DateTime date = Convert.ToDateTime(TxtStartDate.Text);
            if (ChkDept.Checked)
            {
                foreach (GridViewRow row in GridView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chk2") as CheckBox);
                        if (chkRow.Checked)
                        {
                            dept_name = ((row.Cells[1].FindControl("DEPT_NAME") as Label).Text);
                            tdept = ((row.Cells[1].FindControl("DEPT_ID") as Label).Text);
                            if (dept == "")
                            {
                                dept += tdept;
                            }
                            else
                            {
                                dept += ", " + tdept;

                            }
                        }
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Select atlest one of the checkbox!!!','warning')", true);
                        //}
                    }
                }
            }
            else
            {
                dept = CmbDepartment.SelectedValue.ToString();
            }


            DataTable dt = blu.loadOt(date, dept);
            if(dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                btnSave.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','No Recrods to Display. !!!','warning')", true);
            }
        }

        protected void ChkDept_CheckedChanged(object sender, EventArgs e)
        {
            if(ChkDept.Checked)
            {
                CmbDepartment.Items.Clear();
                CmbDepartment.Enabled = false;
                DataTable dt = blu.getDepartment();
                GridView.Visible = true;
                GridView.DataSource = dt;
                GridView.DataBind();
            }
            else
            {
                CmbDepartment.Enabled = true;
                GridView.Visible = false;
            }
        }
        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk2") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string emp_id = ((row.Cells[1].FindControl("EMPID") as Label).Text);
                        int empid = int.Parse(emp_id);
                        string date = ((row.Cells[4].FindControl("tdate") as Label).Text);
                        DateTime tdate = Convert.ToDateTime(date);
                        string HrsMin = ((row.Cells[5].FindControl("HrsMin") as Label).Text);
                        string ApproveOt = ((row.Cells[6].FindControl("txtOT") as TextBox).Text);
                        string approver_id = Session["userid"] as string;
                        int approver = int.Parse(approver_id);


                        blu.manageOverTime(empid, tdate, HrsMin, ApproveOt, approver);
                    }
                    Response.Redirect("overTimeManagement");
                }
            }
        }
    }
}