using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.attendanceManagement.forceAttendance
{
    public partial class Force : System.Web.UI.Page
    {
        static attendance staticAttendanceObject = new attendance();
        attendance blu = new attendance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            txtStartDate.Enabled = false;
            txtStartDate.Text = "";
            txtNepaliDate.Enabled = false;
            txtNepaliDate.Text = "";

        }

        protected void SignOut_CheckedChanged(object sender, EventArgs e)
        {
            txtStartDate.Enabled = true;
            txtStartDate.Text = "";
            txtNepaliDate.Enabled = true;
            txtNepaliDate.Text = "";
        }

        protected void Both_CheckedChanged(object sender, EventArgs e)
        {
            txtStartDate.Enabled = true;
            txtStartDate.Text = "";
            txtNepaliDate.Enabled = true;
            txtNepaliDate.Text = "";
        }

        protected void plus_Click(object sender, EventArgs e)
        {

            if (TxtId.Text == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel2, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Selected !!!','warning')", true);
            }
            else
            {
                string effectiveDate = "";
                if(SignIn.Checked)
                {
                    effectiveDate = Convert.ToDateTime(txtEndDate.Text).ToString("yyyy-MM-dd");
                }
                else
                {
                    effectiveDate = Convert.ToDateTime(txtStartDate.Text).ToString("yyyy-MM-dd");

                }
                int empId = Convert.ToInt32(TxtId.Text);
                DataTable dtGetForceData = blu.getForceData(effectiveDate, empId);
                int count = dtGetForceData.Rows.Count;
                int i = 1;
                string attendanceData = "";
                string tdate, tdateOut;
                foreach (DataRow value in dtGetForceData.Rows)
                {

                    tdate = Convert.ToDateTime(value["TDATE"]).ToString("yyyy-MM-dd");
                    tdateOut = Convert.ToDateTime(value["TDATE_OUT"]).ToString("yyyy-MM-dd");
                    if (Convert.ToInt32(value["COUNTER"]) == i)
                    {

                        if (string.IsNullOrEmpty(attendanceData))
                        {

                            attendanceData += tdate + "|" + tdateOut + "|" + value["INTIME"] + "|" + value["OUTTIME"];
                        }
                        else
                        {

                            attendanceData += "|" + tdate + "|" + tdateOut + "|" + value["INTIME"] + "|" + value["OUTTIME"];
                        }
                    }
                    i++;
                }
                string[] splitData = attendanceData.Split('|');

                if (splitData.Length > 1)
                {

                    if (splitData.Length > 0)
                    {

                        shift1InDate.InnerText = splitData[0];
                        shift1OutDate.InnerText = splitData[1];
                        shift1InTime.InnerText = splitData[2];
                        shift1OutTime.InnerText = splitData[3];
                    }
                    if (splitData.Length > 4)
                    {

                        shift2InDate.InnerText = splitData[4];
                        shift2OutDate.InnerText = splitData[5];
                        shift2InTime.InnerText = splitData[6];
                        shift2OutTime.InnerText = splitData[7];
                    }
                    if (splitData.Length > 8)
                    {

                        shift3InDate.InnerText = splitData[8];
                        shift3OutDate.InnerText = splitData[9];
                        shift3InTime.InnerText = splitData[10];
                        shift3OutTime.InnerText = splitData[11];
                    }
                    if (splitData.Length > 12)
                    {

                        shift4InDate.InnerText = splitData[12];
                        shift4OutDate.InnerText = splitData[13];
                        shift4InTime.InnerText = splitData[14];
                        shift4OutTime.InnerText = splitData[15];
                    }
                }
                DateTime Startdate;
                if (SignIn.Checked)
                {
                    Startdate = Convert.ToDateTime(txtEndDate.Text);
                }
                else
                {
                    Startdate = Convert.ToDateTime(txtStartDate.Text);
                }
                DateTime Enddate = Convert.ToDateTime(txtEndDate.Text);
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

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (SignIn.Checked)
            {
                e.Row.Cells[5].Enabled = false;
                e.Row.Cells[6].Enabled = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;



            }
            else if (SignOut.Checked)
            {
                e.Row.Cells[3].Enabled = false;
                e.Row.Cells[4].Enabled = false;
            }
        }


        int flag = 0;
        string outtime, intime;
        protected void BtnSave_Click(object sender, EventArgs e)
        {

            int counter = Convert.ToInt32(shiftForm.SelectedValue);
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
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk2") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string startdate = ((row.Cells[1].FindControl("txtStartDate") as Label).Text);
                        if (SignOut.Checked)
                        {
                            intime = "00:00:00";
                        }
                        else
                        {
                            intime = (row.Cells[2].FindControl("txtInTime") as TextBox).Text;
                        }
                        string TextInRemark = (row.Cells[3].FindControl("TextInRemark") as TextBox).Text;
                        string outdate = ((row.Cells[4].FindControl("txtEndDate") as TextBox).Text);
                        string TextOutRemark = (row.Cells[5].FindControl("TextOutRemark") as TextBox).Text;
                        if (SignIn.Checked)
                        {
                            outtime = "00:00:00";
                        }
                        else
                        {
                            outtime = (row.Cells[6].FindControl("txtOutTime") as TextBox).Text;

                        }

                        blu.ForceAttendance((TxtId.Text).ToString(), Convert.ToDateTime(startdate), Convert.ToDateTime(intime), TextInRemark, Admin, Convert.ToDateTime(outdate), Convert.ToDateTime(outtime), Admin, TextOutRemark, flag, 0, 0, counter);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Select atlest one of the checkbox!!!','warning')", true);
                    }
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Force Attendance Saved Successfully').then((value) => { window.location ='forceAttendance'; });", true);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("forceAttendance");
        }

        [WebMethod]
        public static string getForceData(string sData)
        {

            string[] rData = sData.Split('+');
            string effectiveDate = rData[0].ToString();
            int empId = Convert.ToInt32(rData[1]);
            DataTable dtGetForceData = staticAttendanceObject.getForceData(effectiveDate, empId);
            int count = dtGetForceData.Rows.Count;
            int i = 1;
            string attendanceData = "";
            string tdate, tdateOut;
            foreach (DataRow value in dtGetForceData.Rows)
            {

                tdate = Convert.ToDateTime(value["TDATE"]).ToString("yyyy-MM-dd");
                tdateOut = Convert.ToDateTime(value["TDATE_OUT"]).ToString("yyyy-MM-dd");
                if (Convert.ToInt32(value["COUNTER"]) == i)
                {

                    if (string.IsNullOrEmpty(attendanceData))
                    {

                        attendanceData += tdate + "./." + tdateOut + "./." + value["INTIME"] + "./." + value["OUTTIME"];
                    }
                    else
                    {

                        attendanceData += "./." + tdate + "./." + tdateOut + "./." + value["INTIME"] + "./." + value["OUTTIME"];
                    }
                }
                i++;
            }
            return attendanceData;
        }
    }
}