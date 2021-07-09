using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.attendanceManagement.leaveApplication {
    public partial class leaveApplication : System.Web.UI.Page {

        attendance blu = new attendance();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                loadEmployee();
                BtnSave.Enabled = false;
            }
        }
        public void loadEmployee() {
            DataTable dt = blu.getHODList2();
            DDLEMP.DataSource = dt;
            DDLEMP.DataTextField = "emp_fullname";
            DDLEMP.DataValueField = "EMP_ID";
            DDLEMP.DataBind();

            DDLEMP.Items.Insert(0, "Select Approver");
            DDLEMP.Items[0].Selected = true;
            DDLEMP.Items[0].Attributes["Disabled"] = "Disabled";
            //Txtemp_id.Text = "10001";
        }

        protected void TxtEmpId_TextChanged(object sender, EventArgs e) {
            int emp_id = int.Parse(TxtId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
            if (dt.Rows.Count > 0) {
                TxtBranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                TxtDept.Text = dt.Rows[0]["DEPT_NAME"].ToString();
                TxtEmp.Text = dt.Rows[0]["emp_Fullname"].ToString();
                TxtDesignation.Text = dt.Rows[0]["DEG_NAME"].ToString();
                //if (dt.Rows[0]["HOD_ID"].ToString() == "") {
                //    loadEmployee();
                //} else {
                //    DDLEMP.SelectedValue = dt.Rows[0]["HOD_ID"].ToString();
                //    Txtemp_id.Text = dt.Rows[0]["HOD_ID"].ToString();
                //}

                DataTable dt1 = blu.getleave_emp(emp_id);
                if (dt1.Rows.Count == 0) {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave Assigned to this ID !!!','warning')", true);
                    TxtId.Text = " ";
                    TxtBranch.Text = "";
                    TxtDept.Text = "";
                    TxtDesignation.Text = "";
                    TxtEmp.Text = "";
                }

                DDLLeaveName.DataSource = dt1;
                DDLLeaveName.DataTextField = "LEAVE_NAME";
                DDLLeaveName.DataValueField = "LEAVE_ID";
                DDLLeaveName.DataBind();

                DDLLeaveName.Items.Insert(0, "Select Type");
                DDLLeaveName.Items[0].Selected = true;
                DDLLeaveName.Items[0].Attributes["Disabled"] = "Disabled";
            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Available with that ID !!!','warning')", true);
                TxtId.Text = " ";
                TxtBranch.Text = "";
                TxtDept.Text = "";
                TxtDesignation.Text = "";
                TxtEmp.Text = "";
            }
        }

        protected void DDLLeaveName_SelectedIndexChanged(object sender, EventArgs e) {
            int empid = Convert.ToInt32(TxtId.Text);
            if (DDLLeaveName.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Leave First !!!','warning')", true);
                DDLLeaveName.Items.Clear();
                DDLLeaveName.Focus();
            }
            int LvType = Convert.ToInt32(DDLLeaveName.SelectedValue);
            dt = blu.proc_Pay_LeaveLog_web(empid, LvType);
            if (dt.Rows.Count > 0) {
                leaveApproved.Text = dt.Rows[0]["Given"].ToString();
                leaveUsed.Text = dt.Rows[0]["Taken"].ToString();
                available.Text = dt.Rows[0]["bal"].ToString();
            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave Approved,Used and Available !!!','warning')", true);
                return;
            }
        }

        protected void DDLEMP_SelectedIndexChanged(object sender, EventArgs e) {
            Txtemp_id.Text = DDLEMP.SelectedValue.ToString();
            DDLEMP.Items[0].Attributes["Disabled"] = "Disabled";
        }
        //int balance;
        protected void btnLoad_Click(object sender, EventArgs e) {
            if (TxtId.Text == "") {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Enter EmployeeId!!!','warning')", true);
                return;
            }
            if (DDLLeaveName.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave Selected !!!','warning')", true);
                return;
            }

            if (DDLLeaveType.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave Type Selected !!!','warning')", true);
                return;
            }

            if (DDLDAy.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave Day Selected !!!','warning')", true);
                return;
            }

            if (DDLEMP.SelectedValue == "Select Approver") {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Leave Approver Not Selected !!!','warning')", true);
                return;
            }
            if (DDLEMP.Text == "") {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Remarks Cannot be blank !!!','warning')", true);
                return;
            }
            if (DDLDAy.SelectedValue == "1") {
                if (txtNepaliDate.Text == "" || nepaliDate2.Text == "") {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Date Field cannot be emptied !!!','warning')", true);
                    return;
                }
            } else {

                if (txtNepaliDate.Text == "") {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Date Field cannot be emptied !!!','warning')", true);
                    return;
                }
            }
            if (DDLEMP.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Plz Select Approver !!!','warning')", true);
                return;
            }

            DateTime Startdate;
            DateTime Enddate;
            if (DDLDAy.SelectedValue == "1") {
                Startdate = Convert.ToDateTime(txtStartDate.Text);
                Enddate = Convert.ToDateTime(txtEndDate.Text);
            } else {
                Startdate = Convert.ToDateTime(txtStartDate.Text);
                Enddate = Convert.ToDateTime(txtStartDate.Text);

                if (txtNepaliDate.Text == "") {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Date Field cannot be emptied !!!','warning')", true);
                    return;
                }
            }
       
            TimeSpan ts = Enddate - Startdate;
          
            int numberOfDays = (ts.Days) + 1;
            decimal leave = 0;
            string asas = (available.Text);

            if (DDLDAy.SelectedValue.ToString()=="1") {
                leaveApplied.Text = numberOfDays.ToString();
                leave = decimal.Parse(leaveApplied.Text);
            } else {
                leaveApplied.Text = "0.50";
                leave = decimal.Parse(leaveApplied.Text);
            }
           
            

            decimal balance = Convert.ToDecimal(available.Text);

            if (leave > balance) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Leave Applied is greater than leave balance Available !!!','warning')", true);
                return;
            } else {
                DateTime currentDate;
                for (int j = 0; j <= numberOfDays - 1; j++) {
                    DataTable dt2 = new DataTable();
                    dt2.Columns.Add("Date");
                    dt2.Columns.Add("LEAVE_NAME");
                    dt2.Columns.Add("Remarks");
                    DataRow dr = null;
                    if (ViewState["emp"] != null) {
                        for (int i = 0; i < 1; i++) {
                            dt2 = (DataTable)ViewState["emp"];
                            if (dt2.Rows.Count > 0) {
                                dr = dt2.NewRow();
                                currentDate = Convert.ToDateTime(txtStartDate.Text);
                                currentDate = currentDate.AddDays(1);
                                txtStartDate.Text = currentDate.ToString("yyyy-MM-dd");
                                dr["Date"] = txtStartDate.Text;
                                dr["LEAVE_NAME"] = DDLLeaveName.SelectedItem.ToString();
                                dr["Remarks"] = Remarks.Text;

                                dt2.Rows.Add(dr);
                                GridView1.DataSource = dt2;
                                GridView1.DataBind();
                            }
                        }
                    } else {
                        dr = dt2.NewRow();
                        dr["Date"] = txtStartDate.Text;
                        dr["LEAVE_NAME"] = DDLLeaveName.SelectedItem.ToString();
                        dr["Remarks"] = Remarks.Text;
                        dt2.Rows.Add(dr);

                        GridView1.DataSource = dt2;
                        GridView1.DataBind();
                    }
                    ViewState["emp"] = dt2;
                    BtnSave.Enabled = true;
                }
                ViewState.Remove("emp");
            }
        }

        int empid;
        int leave_id;
        
        decimal availablevalue = 0;
        string Taken;
        protected void BtnSave_Click(object sender, EventArgs e) {
            empid = int.Parse(TxtId.Text);//for check available and leave used
            string Id = TxtId.Text;//for save
            leave_id = Convert.ToInt32(DDLLeaveName.SelectedValue);
            if (DDLDAy.SelectedItem.ToString() == "Half Day") {
                Taken = "0.5";
            } else {
                Taken = "1.00";
            }
            string Seniorid = (DDLEMP.SelectedValue);
            DateTime date1 = Convert.ToDateTime(txtStartDate.Text);
            string day = (DDLDAy.SelectedValue);
            string leavename = (DDLLeaveName.SelectedValue);
            int LvType = Convert.ToInt32(DDLLeaveName.SelectedValue);
            int status = 2;

            DataTable dt = blu.proc_Pay_LeaveLog_web(empid, LvType);
            int empid1 = int.Parse(TxtId.Text);
            DataTable dt2 = blu.getLeaveDate(empid1);
            int count = dt2.Rows.Count;

            for (int i = 0; i < dt2.Rows.Count; i++) {
                string dtItem = (dt2.Rows[i]["Leave_Date"].ToString());
                DateTime aa = Convert.ToDateTime(dtItem);
                dtItem = aa.ToString("yyyy-MM-dd");
                DateTime currentDate = Convert.ToDateTime(txtStartDate.Text);

                txtStartDate.Text = currentDate.ToString("yyyy-MM-dd");

                if (dtItem == txtStartDate.Text) {
                    ScriptManager.RegisterStartupScript(upPnl1, this.GetType(), "alertscipt", "swal('Ooops!','No leave day Available in same day please select another date !!!','warning')", true);
                    txtNepaliDate.Text = string.Empty;
                    txtStartDate.Text = string.Empty;
                    nepaliDate2.Text = string.Empty;
                    txtEndDate.Text = string.Empty;
                    return;
                }
            }
            foreach (GridViewRow row in GridView1.Rows) {
                string date = ((row.Cells[1].FindControl("gvdate") as Label).Text);
                blu.LeaveApplication(Convert.ToDateTime(date), Id, leave_id, Taken, Remarks.Text, Seniorid, day, leavename, status);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Leave Application saved Successfully').then((value) => { window.location ='leaveApplication'; });", true);
            return;
        }


        protected void BtnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("leaveApplicationList");
        }

        protected void DDLDAy_SelectedIndexChanged(object sender, EventArgs e) {
            DDLDAy.Items[0].Attributes["Disabled"] = "Disabled";
            string day = DDLDAy.SelectedValue;

            if (day == "2") {
                nepaliDate2.Enabled = false;
                txtEndDate.Enabled = false;
            }
            else
            {
                nepaliDate2.Enabled = true;
                txtEndDate.Enabled = true;
            }
        }
    }
}