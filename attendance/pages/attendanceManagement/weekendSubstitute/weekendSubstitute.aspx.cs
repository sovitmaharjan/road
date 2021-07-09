using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.attendanceManagement.weekendSubstitute
{
    public partial class weekendSubstitute : System.Web.UI.Page
    {
        attendance blu = new attendance();
        int emp_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadEmployee();
                //TxtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //TxtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                BtnSve.Visible = false;
                approver.Visible = false;
                CmbApprover.Visible = false;
                Txtapprover.Visible = false;
                Remarks.Visible = false;
                TxtRemarks.Visible = false;

            }
        }

        public void loadEmployee()
        {
            DataTable dt = blu.getEmployees();
            CmbEmployee.DataSource = dt;
            CmbEmployee.DataTextField = "emp_fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");
        }
        public void loadApprover()
        {
            DataTable dt = blu.getEmployees();
            CmbApprover.DataSource = dt;
            CmbApprover.DataTextField = "emp_fullname";
            CmbApprover.DataValueField = "EMP_ID";
            CmbApprover.DataBind();
            CmbApprover.Items.Insert(0, "Select Employee");
        }

        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
            emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
            if (dt.Rows.Count > 0)
            {
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                TxtDesg.Text = dt.Rows[0]["DEG_NAME"].ToString();
                TxtDept.Text = dt.Rows[0]["DEPT_NAME"].ToString();
                TxtBranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                TxtSts.Text = dt.Rows[0]["STATUS_NAME"].ToString();
                TextCountry.Text = dt.Rows[0]["emp_pcountry"].ToString();
                CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID !!!!','warning')", true);
            }
        }
        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {

            emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
            if (dt.Rows.Count > 0)
            {
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                TxtDesg.Text = dt.Rows[0]["DEG_NAME"].ToString();
                TxtDept.Text = dt.Rows[0]["DEPT_NAME"].ToString();
                TxtDept.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                TxtBranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                TxtSts.Text = dt.Rows[0]["STATUS_NAME"].ToString();
                TextCountry.Text = dt.Rows[0]["emp_pcountry"].ToString();
                CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID !!!!','warning')", true);
                txtEmpId.Text = "";
                TxtDesg.Text = "";
                TxtDept.Text = "";
                TxtDept.Text = "";
                TxtSts.Text = "";
                loadEmployee();
            }
        }
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            emp_id = int.Parse(txtEmpId.Text);
            DateTime date = Convert.ToDateTime(TxtStartDate.Text);
            DateTime Week_day = Convert.ToDateTime(TxtStartDate.Text);

            if (TextCountry.Text == "Nepal")
            {
                DateTime newDate = Week_day.AddDays(90);
                int resdate = DateTime.Compare(newDate, DateTime.Now);
                if (resdate < 0)
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' 90 Days Over For Selected Weekend Subsitute. !!!','warning')", true);
                    return;
                }

            }
            else
            {
                BtnSve.Visible = true;

            }
            



            DataTable dt = blu.checkWeekend(emp_id, date);
            if (dt.Rows.Count > 0)
            {
                BtnLoad.Visible = false;
                BtnReset.Visible = false;

                DataTable dt1 = blu.checkAttendance(emp_id, date);
                if (dt1.Rows.Count > 0)
                {
                    GridView2.DataSource = dt1;
                    GridView2.DataBind();
                    loadApprover();
                    approver.Visible = true;
                    CmbApprover.Visible = true;
                    Txtapprover.Visible = true;
                    Remarks.Visible = true;
                    TxtRemarks.Visible = true;
                    BtnSve.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Selected Weekend is missing attendace for selected Employee','warning')", true);
                }
            }
            else
            {
                TxtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Selected date is not a weekend for selected Employee','warning')", true);
            }

        }
        protected void DDLEMP_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txtapprover.Text = CmbApprover.SelectedValue.ToString();
            CmbApprover.Items[0].Attributes["Disabled"] = "Disabled";
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("weekendSubstitute");
        }

        protected void CmbApprover_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txtapprover.Text = CmbApprover.SelectedValue.ToString();
        }

        protected void Txtapprover_TextChanged(object sender, EventArgs e)
        {
            emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
            CmbApprover.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();

        }
        protected void BtnSve_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(TxtEndDate.Text);
            string EMP_ID = txtEmpId.Text;
            int LEAVE_ID = 10;
            string TAKEN = "1";
            string REMARKS = TxtRemarks.Text;
            string Senior_EMP_ID = Txtapprover.Text;
            string DAYPART = "1";
            string LEAVETYPE = "";
            DateTime Week_day = Convert.ToDateTime(TxtStartDate.Text);

            DataTable dt = blu.getAll_Info(Convert.ToInt32(EMP_ID));
            string emp_country = dt.Rows[0]["emp_pcountry"].ToString();
            if (emp_country == "Nepal")
            {
                DateTime newDate = Week_day.AddDays(90);
                int resdate = DateTime.Compare(newDate, DateTime.Now);
                if (resdate < 0)
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' 90 Days Over For Selected Weekend Subsitute. !!!','warning')", true);
                    return;
                }
                else
                {
                    int i = blu.saveWeekendSubsitute(date, EMP_ID, LEAVE_ID, TAKEN, REMARKS, Senior_EMP_ID, DAYPART, LEAVETYPE, Week_day);
                    if (i > 0)
                    {
                        //***************** For System Log ******************//
                        string remarks = "Weekend Subsituted of " + ',' + Week_day + "to" + date;
                        string event_info = "Weekend Subsituted";
                        string event_type = "11";
                        string event_date = DateTime.Now.ToString();
                        int login_id = int.Parse(Session["userId"].ToString());
                        blu.systemLog(remarks, int.Parse(EMP_ID), event_info, event_date, event_type, login_id);
                        //***************** For System Log ******************//

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Weekend Subsitute Saved Successfully').then((value) => { window.location ='weekendSubstitute'; });", true);
                    }
                }
            }
            else
            {
                int i = blu.saveWeekendSubsitute(date, EMP_ID, LEAVE_ID, TAKEN, REMARKS, Senior_EMP_ID, DAYPART, LEAVETYPE, Week_day);
                if (i > 0)
                {
                    //***************** For System Log ******************//
                    string remarks = "Weekend Subsituted of " + ',' + Week_day + "to" + date;
                    string event_info = "Weekend Subsituted";
                    string event_type = "11";
                    string event_date = DateTime.Now.ToString();
                    int login_id = int.Parse(Session["userId"].ToString());
                    blu.systemLog(remarks, int.Parse(EMP_ID), event_info, event_date, event_type, login_id);
                    //***************** For System Log ******************//

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Weekend Subsitute Saved Successfully').then((value) => { window.location ='weekendSubstitute'; });", true);
                }
            }
        }
    }
}