using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.attendanceManagement.forceAttendance
{
    public partial class forceAttendance : System.Web.UI.Page
    {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                BtnSave.Visible = false;
                BtnCancel.Visible = false;
            }
        }
        DataTable dt;
        protected void TxtId_TextChanged(object sender, EventArgs e)
        {
            int emp_id = int.Parse(TxtId.Text);
            dt = blu.getAllInfo(emp_id);
            if (dt.Rows.Count > 0)
            {
                TxtEmp.Text = dt.Rows[0]["emp_Fullname"].ToString();
                TxtDesignation.Text = dt.Rows[0]["DEG_NAME"].ToString();
                TxtDept.Text = dt.Rows[0]["DEPT_NAME"].ToString();
                TxtBranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Available with that ID !!!','warning')", true);

                TxtId.Text = " ";
                TxtEmp.Text = "";
                TxtDesignation.Text = "";
                TxtDept.Text = "";
                TxtBranch.Text = "";
            }
        }
        protected void SignIn_CheckedChanged(object sender, EventArgs e)
        {
            //Label4.Enabled = false;
            //TextOutRemark.Enabled = false;
            //TextOutRemark.Text = "";
            //Label3.Enabled = true;
            //TextInRemark.Enabled = true;

        }

        protected void SignOut_CheckedChanged(object sender, EventArgs e)
        {
            //Label3.Enabled = false;
            //TextInRemark.Enabled = false;
            //TextInRemark.Text = "";
            //Label4.Enabled = true;
            //TextOutRemark.Enabled = true;
        }

        protected void Both_CheckedChanged(object sender, EventArgs e)
        {
            //Label4.Enabled = true;
            //TextOutRemark.Enabled = true;
            //Label3.Enabled = true;
            //TextInRemark.Enabled = true;
        }


        protected void plus_Click(object sender, EventArgs e)
        {
            if (TxtId.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Selected !!!','warning')", true);
            }
            else if (txtStartDate.Text == "" || txtEndDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Invalid Date !!!','warning')", true);

            }
            else if (SignOut.Checked)
            {
                DateTime StartDate = Convert.ToDateTime(txtStartDate.Text);
                DateTime EndDate = Convert.ToDateTime(txtEndDate.Text);
                int emp_id = Convert.ToInt32(TxtId.Text);
                int counter = int.Parse(shiftForm.SelectedValue.ToString());
                int flag = 0;
                int diff = int.Parse((EndDate - StartDate).Days.ToString()) + 1;
                for (int j = 0; j < diff; j++)
                {
                    StartDate = StartDate.AddDays(flag);

                    DataTable dt = blu.checkAttendance(int.Parse(TxtId.Text), StartDate);
                    int count = dt.Rows.Count;
                    if (dt.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Date : " + StartDate.ToShortDateString() + " has No Sign In Data!!!','warning')", true);
                        return;
                    }
                    flag = 1;
                }
                DataTable dt1 = blu.getForceAttendanceRooster(emp_id, StartDate, EndDate, counter);
                if (dt1.Rows.Count > 0)
                {
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();

                    BtnSave.Visible = true;
                    BtnCancel.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Rooster  Assigned for selected Employee in selected Dates !!!','warning')", true);
                }

            }
            else
            {
                DateTime Startdate = Convert.ToDateTime(txtStartDate.Text);
                DateTime Enddate = Convert.ToDateTime(txtEndDate.Text);
                if (Startdate > Enddate)
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Start Date : ' + Startdate + 'Cannot be greater than End Date : ' + Enddate + '!!!','warning')", true);
                }

                else
                {
                    int emp_id = Convert.ToInt32(TxtId.Text);
                    int counter = int.Parse(shiftForm.SelectedValue.ToString());
                    dt = blu.getForceAttendanceRooster(emp_id, Startdate, Enddate, counter);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                        BtnSave.Visible = true;
                        BtnCancel.Visible = true;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Rooster  Assigned for selected Employee in selected Dates !!!','warning')", true);
                    }
                }
            }
        }
        protected void GridView_RowBound(object sender, GridViewRowEventArgs e)
        {
            if (SignIn.Checked)
            {
                e.Row.Cells[6].Enabled = false;
                e.Row.Cells[7].Enabled = false;
                e.Row.Cells[8].Enabled = false;
                e.Row.Cells[9].Enabled = false;

            }
            else if (SignOut.Checked)
            {
                e.Row.Cells[1].Enabled = false;
                e.Row.Cells[2].Enabled = false;
                e.Row.Cells[3].Enabled = false;
                e.Row.Cells[4].Enabled = false;
                e.Row.Cells[5].Enabled = false;
            }
        }


        int flag = 0;



        string startdate, TextInRemark, outdate, TextOutRemark, INMODE, OUTMODE, outtime, intime;
        protected void BtnSave_Click(object sender, EventArgs e)
        {

            int counter = Convert.ToInt32(shiftForm.SelectedValue);
            string user = Session["username"].ToString();
            if (SignIn.Checked)
            {

                flag = 0;//Sign In only
            }
            else if (SignOut.Checked)
            {
                flag = 1; //Sign Out only
                intime = "00:00:00";
            }
            else
            {
                flag = 2; //Sign in and Sign Out 
            }

            string User = Session["userId"].ToString();//  "admin";
            string Admin = "";
            DataTable dtt = blu.getSessionIDtoEmpName(int.Parse(User));
            foreach (DataRow rw in dtt.Rows)
            {
                if (dtt.Rows.Count > 0)
                {
                    Admin = rw["EMP_FULLNAME"].ToString();
                }
            }
            int totalCount = GridView1.Rows.Cast<GridViewRow>().Count(r => ((CheckBox)r.FindControl("chk2")).Checked);
            if (totalCount == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Select atlest one of the checkbox. !!!','warning')", true);
                return;
            }

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk2") as CheckBox);
                    if (chkRow.Checked)
                    {
                        int emp_id = int.Parse(TxtId.Text);
                        string event_info = "Force";
                        string event_type = "3";
                        int login_id = int.Parse(Session["userId"].ToString());
                        if (SignIn.Checked)
                        {
                            startdate = ((row.Cells[1].FindControl("txtStartDate") as TextBox).Text);
                            intime = (row.Cells[2].FindControl("txtInTime") as TextBox).Text;
                            TextInRemark = (row.Cells[3].FindControl("TextInRemark") as TextBox).Text;
                            INMODE = "Forced" + "(" + TextInRemark +  ")";
                            outdate = startdate;
                            TextOutRemark = "";
                            outtime = "00:00:00";
                            OUTMODE = "test";
                            flag = 0;
                            blu.ForceAttendance((TxtId.Text).ToString(), Convert.ToDateTime(startdate), Convert.ToDateTime(intime), TextInRemark, INMODE, Convert.ToDateTime(outdate), Convert.ToDateTime(outtime), OUTMODE, TextOutRemark, flag, 0, 0, counter);
                            //***************** For System Log ******************//
                            string remarks = "Force Attendance" + ',' + "SignIn" + ',' + intime;
                            string event_date = startdate;

                            blu.systemLog(remarks, emp_id, event_info, event_date, event_type, login_id);
                        }
                        else if (SignOut.Checked)
                        {
                            startdate = ((row.Cells[1].FindControl("txtStartDate") as TextBox).Text);
                            INMODE = "test";
                            intime = "00:00:00";
                            TextInRemark = "";
                            TextOutRemark = (row.Cells[5].FindControl("TextOutRemark") as TextBox).Text;
                            outdate = ((row.Cells[4].FindControl("txtEndDate") as TextBox).Text);
                            OUTMODE = "Forced" + "(" + TextOutRemark + ")";
                            outtime = (row.Cells[6].FindControl("txtOutTime") as TextBox).Text;
                            flag = 1;
                            blu.ForceAttendance((TxtId.Text).ToString(), Convert.ToDateTime(startdate), Convert.ToDateTime(intime), TextInRemark, INMODE, Convert.ToDateTime(outdate), Convert.ToDateTime(outtime), OUTMODE, TextOutRemark, flag, 0, 0, counter);

                            //***************** For System Log ******************//
                            string remarks = "Force Attendance" + ',' + "SignOut" + ',' + outtime;
                            string event_date = startdate;

                            blu.systemLog(remarks, emp_id, event_info, event_date, event_type, login_id);
                        }
                        else
                        {
                            startdate = ((row.Cells[1].FindControl("txtStartDate") as TextBox).Text);
                            intime = (row.Cells[2].FindControl("txtInTime") as TextBox).Text;
                            TextInRemark = (row.Cells[3].FindControl("TextInRemark") as TextBox).Text;
                            INMODE = "Forced" + "(" + TextInRemark + ")";
                            outdate = ((row.Cells[4].FindControl("txtEndDate") as TextBox).Text);
                            TextOutRemark = (row.Cells[5].FindControl("TextOutRemark") as TextBox).Text;
                            outtime = (row.Cells[6].FindControl("txtOutTime") as TextBox).Text;
                            OUTMODE = "Forced" + "(" + TextOutRemark + ")";
                            TextOutRemark = (row.Cells[5].FindControl("TextOutRemark") as TextBox).Text;
                            flag = 2;

                            DateTime date1 = Convert.ToDateTime(startdate);
                            DateTime date2 = Convert.ToDateTime(outdate);
                            if (date1 > date2)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Start Date' + date1 'Cannot be greater than End Date' +  '!!!','warning')", true);
                                return;
                            }
                            else if (date1 == date2)
                            {
                                intime = (row.Cells[2].FindControl("txtInTime") as TextBox).Text;
                                outtime = (row.Cells[6].FindControl("txtOutTime") as TextBox).Text;
                                TimeSpan time1 = TimeSpan.Parse(intime);
                                TimeSpan time2 = TimeSpan.Parse(outtime);
                                if (time1 > time2)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','InTime Cannot be greater than OutTime!!!','warning')", true);
                                    return;
                                }
                                else
                                {
                                    blu.ForceAttendance((TxtId.Text).ToString(), Convert.ToDateTime(startdate), Convert.ToDateTime(intime), TextInRemark, INMODE, Convert.ToDateTime(outdate), Convert.ToDateTime(outtime), OUTMODE, TextOutRemark, flag, 0, 0, counter);
                                    //***************** For System Log ******************//
                                    string remarks = "Force Attendance" + ',' + "SignIN/Out" + ',' + intime + ',' + outtime;
                                    string event_date = startdate;

                                    blu.systemLog(remarks, emp_id, event_info, event_date, event_type, login_id);
                                }
                            }
                            else
                            {
                                blu.ForceAttendance((TxtId.Text).ToString(), Convert.ToDateTime(startdate), Convert.ToDateTime(intime), TextInRemark, INMODE, Convert.ToDateTime(outdate), Convert.ToDateTime(outtime), OUTMODE, TextOutRemark, flag, 0, 0, counter);
                                //***************** For System Log ******************//
                                string remarks = "Force Attendance" + ',' + "SignIN/Out" + ',' + intime + ',' + outtime;
                                string event_date = startdate;
                                blu.systemLog(remarks, emp_id, event_info, event_date, event_type, login_id);
                                //***************** For System Log ******************//

                            }
                        }
                    }

                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Force Attendance Saved Successfully').then((value) => { window.location ='forceAttendance'; });", true);
        }



        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForceAttendance");
        }
    }
}