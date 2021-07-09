using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.roster.assign {
    public partial class assign: System.Web.UI.Page {

        attendance blu = new attendance();
        DataTable dt;
        int sessionUserId, sessionDept_id;
        string sessionUserTypeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionUserId = Convert.ToInt32(Session["userId"].ToString());
            sessionUserTypeId = Session["userTypeId"].ToString();
            sessionDept_id = Convert.ToInt32(Session["DEPT_ID"].ToString());
            if (!IsPostBack) {
                //txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                loadShift();
                loadDepartment();
            }
            CmbDefaultSG.Items[0].Attributes["disabled"] = "disabled";
        }

        public void loadDepartment()
        {
            if (sessionUserTypeId == "2")
            {
                dt = blu.getDepartment();
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");
            }
            else
            {
                dt = blu.getSupervisorDepartment(sessionUserId);
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");
            }
        }
        
        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e) {
            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
            string dept = CmbDepartment.SelectedValue;
            dt = blu.getEmployeeListByDepartmentId(dept);
            if (dt.Rows.Count > 0) {

                GridView2.DataSource = dt;
                GridView2.DataBind();
            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Available on selected Department !!!','warning')", true);
            }
        }

        public void loadShift() {
            CmbDefaultSG.Enabled = true;
            DataTable dt = blu.MgmtWorkingHour(0);
            CmbDefaultSG.DataSource = dt;
            CmbDefaultSG.DataBind();
            CmbDefaultSG.DataTextField = "Group_Name";
            CmbDefaultSG.DataValueField = "Group_ID";
            CmbDefaultSG.DataBind();
            CmbDefaultSG.Items.Insert(0, "Select Default Shift");
        }

        string weeks;
        protected void CmbDefaultSG_SelectedIndexChanged(object sender, EventArgs e) {
            BtnSaveRoosterMgmt.Visible = true;
            BtnCancel.Visible = true;

            if (CmbDefaultSG.SelectedIndex != 0)
            {
                DateTime start_date = Convert.ToDateTime(txtStartDate.Text);
                DateTime end_date = Convert.ToDateTime(txtEndDate.Text);
                DataTable dt = blu.getweekday(start_date, end_date);//weekdays data bind
                GVShift.DataSource = dt;
                GVShift.DataBind();
                CmbDefaultSG.DataTextField = "Group_Name";
                CmbDefaultSG.DataValueField = "Group_ID";

            }
        }


        protected void GVShift_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DropDownList CmbAssignedG = (DropDownList)e.Row.FindControl("CmbAssignedG");
                DataTable dt = blu.MgmtWorkingHour(0);
                CmbAssignedG.DataSource = dt;
                CmbAssignedG.DataBind();
                CmbAssignedG.DataTextField = "Group_Name";
                CmbAssignedG.DataValueField = "Group_ID";
                CmbAssignedG.DataBind();
                CmbAssignedG.ClearSelection();
                CmbAssignedG.SelectedValue = CmbDefaultSG.SelectedValue.ToString();
                CmbAssignedG.Items.Add("Day-off");

            }
        }

        int branch = 0;
        int dept = 0;
        string date1;
        protected void BtnSaveRoosterMgmt_Click(object sender, EventArgs e) {
            date1 = txtStartDate.Text;
            if (CmbDefaultSG.SelectedValue == "0") {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('oops!','Default Shift Group  cannot be emptied!')</script>");
                return;
            }
            int eid = 0;
            int groupid = 0;

            DateTime currentdate = DateTime.Parse(date1.ToString());
            bool result = false;
            if (CmbDefaultSG.SelectedValue == "Select Shift") {
                for (int i = 0; i < GVShift.Rows.Count; i++) {
                    if (Convert.ToInt32(GVShift.Rows[i].Cells[2].Text) == -1) {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Please select weekday shift').then((value) => { window.location ='RoostetMgmt.aspx'; });", true);
                        break;
                    }
                }

            }
            foreach (GridViewRow row in GridView2.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk2") as CheckBox);
                    if (chkRow.Checked) {
                        eid = int.Parse(row.Cells[2].Text);


                        int Flag = 0;
                        int i = 0;/*The Flag use in proc_ManageWeekend to delete 

                              * the existing weekend in the selected date interval*/
                        DateTime Date = Convert.ToDateTime(txtStartDate.Text);
                       // for ( Date <= Convert.ToDateTime(txtEndDate.Text) )
                        while (Date <= Convert.ToDateTime(txtEndDate.Text))
                        {
                          //  int i = (int)(Date.DayOfWeek);

                            //string tadday = (GVShift.Rows[i].FindControl("Week_days")).ToString();
                           // string tdays = tadday.ToString();
                            /*======================================================
                                 Group Id "0" value is used for None Group
                             ======================================================*/
                            string aa = GVShift.Rows[i].Cells[2].Text;

                            DropDownList CmbAssignedG = GVShift.Rows[i].FindControl("CmbAssignedG") as DropDownList;
                            string days = CmbAssignedG.SelectedValue;

                            if (days == "Day-off") {
                                groupid = Convert.ToInt32(CmbDefaultSG.SelectedValue);
                                blu.ManageWeekend(eid, Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text), Date, Flag);
                                blu.ManageOpenRoosteroff(eid, Date, groupid);
                                Flag = 1;
                            } else {
                                groupid = Convert.ToInt32(CmbAssignedG.SelectedValue);
                                blu.ManageOpenRooster(eid, Date, groupid);
                                result = true;
                            }
                            i++;
                            Date = Date.AddDays(1);
                        }
                    }
                }
            }
            if (result == true) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Roster Assigned Successfully').then((value) => { window.location ='RosterAssign'; });", true);
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("RosterAssign");
        }
    }
}