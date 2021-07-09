using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.attendanceManagement.leaveAdjustement
{
    public partial class leaveAdjustement : System.Web.UI.Page
    {
        attendance blu = new attendance();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BtnSave.Visible = false;
                BtnCancel.Visible = false;
            }
        }

        protected void TxtId_TextChanged(object sender, EventArgs e)
        {
            int emp_id = Convert.ToInt32(TxtId.Text);
            dt = blu.getAll_Info(emp_id);
            if (dt.Rows.Count > 0)
            {
                TxtEmp.Text = dt.Rows[0]["emp_fullname"].ToString();
                TxtDesignation.Text = dt.Rows[0]["DEG_NAME"].ToString();
                TxtDept.Text = dt.Rows[0]["DEPT_NAME"].ToString();
                TxtBranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();

                dt = blu.getleave_emp(emp_id);
                if (dt.Rows.Count > 0)
                {
                    DDLLeaveList.DataSource = dt;
                    DDLLeaveList.DataTextField = "LEAVE_NAME";
                    DDLLeaveList.DataValueField = "LEAVE_ID";
                    DDLLeaveList.DataBind();
                    DDLLeaveList.Items.Insert(0, "Select Leave");
                    DDLLeaveList.Items[0].Selected = true;
                    DDLLeaveList.Items[0].Attributes["disabled"] = "disabled";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave Assigned. !!!','warning')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID !!!!','warning')", true);
            }
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            if (TxtId.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Employee Id Cannot Be  Blank !!!','warning')", true);
                return;
            }
            else if (DDLLeaveList.SelectedItem.Text == "Select Leave" || DDLLeaveList.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Select Leave Name From the List !!!','warning')", true);
                return;
            }
            else if (txtdays.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Leave Days Cannot Be Blank !!!','warning')", true);
                return;
            }
            else
            {
                DataTable dt = blu.getLeaveCancellation(Convert.ToInt32(TxtId.Text), Convert.ToInt32(DDLLeaveList.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {
                    GridView.DataSource = dt;
                    GridView.DataBind();
                    BtnSave.Visible = true;
                    BtnCancel.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Records Found For Selected Employee !!!','warning')", true);
                    return;
                }
            }
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (TxtId.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Employee Id Cannot Be  Blank !!!','warning')", true);
                return;
            }
            else if (DDLLeaveList.SelectedItem.Text == "Select Leave" || DDLLeaveList.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Select Leave Name From the List !!!','warning')", true);
                return;
            }
            else if (txtdays.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Leave Days Cannot Be Blank !!!','warning')", true);
                return;
            }
            else
            {
                foreach (GridViewRow row in GridView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chk2") as CheckBox);
                        if (chkRow.Checked)
                        {
                            string days = txtdays.Text;
                            string flag = DDLLeave.SelectedValue;
                            int SNo = Convert.ToInt32(row.Cells[1].Text);
                            blu.LeaveAdjustment(days, Convert.ToInt32(SNo), flag);
                            //***************** For System Log ******************//
                            int emp_id = Convert.ToInt32(TxtId.Text);
                            string remarks = "Leave Adjustment" + ',' + DDLLeaveList.SelectedItem + ',' + DDLLeave.SelectedItem;
                            string event_info = "Leave Adjustment";
                            string event_type = "8";
                            string event_date = DateTime.Now.ToString();
                            int login_id = int.Parse(Session["userId"].ToString());

                            blu.systemLog(remarks, emp_id, event_info, event_date, event_type, login_id);
                            //***************** For System Log ******************//
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Leave Adjustment Successful').then((value) => { window.location ='LeaveAdjustment'; });", true);
                    }
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveAdjustment");
        }
    }
}