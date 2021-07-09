using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.attendanceManagement.holidaySubstitute
{
    public partial class holidaySubstitute : System.Web.UI.Page
    {
        attendance blu = new attendance();
        int emp_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadEmployee();
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


        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
            if (dt.Rows.Count > 0)
            {
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                TxtDesg.Text = dt.Rows[0]["DEG_NAME"].ToString();
                TxtDept.Text = dt.Rows[0]["DEPT_NAME"].ToString();
                TxtBranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                TxtSts.Text = dt.Rows[0]["STATUS_NAME"].ToString();
                CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
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
            DataTable dt1 = blu.getHolidayname(emp_id);
            if (dt1.Rows.Count > 0)
            {
                CmbHolidayname.DataSource = dt1;
                CmbHolidayname.DataTextField = "HOLIDAY_NAME";
                CmbHolidayname.DataValueField = "HOLIDAY_ID";
                CmbHolidayname.DataBind();
                CmbHolidayname.Items.Insert(0, "Select Holiday");
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Public Holiday to this ID !!!!','warning')", true);
                txtEmpId.Text = "";
                CmbEmployee.Items.Clear();

                return;
            }
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
                CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID !!!!','warning')", true);
            }
            DataTable dt1 = blu.getHolidayname(emp_id);
            if (dt1.Rows.Count > 0)
            {
                CmbHolidayname.DataSource = dt1;
                CmbHolidayname.DataTextField = "HOLIDAY_NAME";
                CmbHolidayname.DataValueField = "HOLIDAY_ID";
                CmbHolidayname.DataBind();
                CmbHolidayname.Items.Insert(0, "Select Holiday");
                CmbHolidayname.Items[0].Attributes["disabled"] = "disabled";

            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Public Holiday to this ID !!!!','warning')", true);
                txtEmpId.Text = "";
                CmbEmployee.Items.Clear();

                return;
            }
        }

        protected void CmbHolidayname_SelectedIndexChanged(object sender, EventArgs e)
        {
            emp_id = Convert.ToInt32(txtEmpId.Text);
            CmbHolidayname.Items[0].Attributes["disabled"] = "disabled";
            int holidayid = Convert.ToInt32(CmbHolidayname.SelectedValue);
            DataTable dt1 = blu.GetAllHoliday(holidayid);
            DateTime result = Convert.ToDateTime(dt1.Rows[0]["HOLIDAY_DATE"].ToString());
            txtDate.Text = result.ToString("yyyy-MM-dd");

            DataTable dt = blu.getAll_Info(emp_id);
            string emp_country = dt.Rows[0]["emp_pcountry"].ToString();
            if (emp_country == "Nepal")
            {
                DateTime newDate = result.AddDays(90);
                int resdate = DateTime.Compare(newDate, DateTime.Now);
                if (resdate < 0)
                {
                    DataTable dt11 = blu.getHolidayname(emp_id);
                    CmbHolidayname.DataSource = dt11;
                    CmbHolidayname.DataTextField = "HOLIDAY_NAME";
                    CmbHolidayname.DataValueField = "HOLIDAY_ID";
                    CmbHolidayname.DataBind();
                    CmbHolidayname.Items.Insert(0, "Select Holiday");

                    txtDate.Text = "";
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' 90 Days Over For Selected PH Subsitute. !!!','warning')", true);
                    return;
                }
            }
            
            DataTable dtt = blu.checkAttendance(emp_id, result);
            int count = dtt.Rows.Count;
            if (count == 0)
            {
                DataTable dtph = blu.checkWeekend(emp_id, result);
                {
                    if (dtph.Rows.Count == 0)
                    {
                        txtDate.Text = "";
                        CmbHolidayname.SelectedIndex = 0;
                        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Nothin Found in Selected holiday For subsitution. !!!','warning')", true);
                        return;
                    }
                }
            }
        }

        protected void BtnSve_Click(object sender, EventArgs e)
        {
            if (txtEmpId.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Enter EmployeeId!!!','warning')", true);
                return;
            }

            if (CmbHolidayname.SelectedItem.Text == "Select Holiday" || CmbHolidayname.SelectedItem.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Holiday Selected !!!','warning')", true);
                return;
            }

            int emp_id = Convert.ToInt32(txtEmpId.Text);
            DateTime HDate = Convert.ToDateTime(TxtSDate.Text);
            DateTime ADate = Convert.ToDateTime(txtDate.Text);
            string holidayname = (CmbHolidayname.SelectedItem).ToString();

            blu.InsertSubHoliday(emp_id, HDate, ADate, 0, holidayname);

            //***************** For System Log ******************//
            string remarks = "PH Subsituted of " + HDate + "to" + ADate;
            string event_info = "PH Subsituted";
            string event_type = "10";
            string event_date = DateTime.Now.ToString();
            int login_id = int.Parse(Session["userId"].ToString());
            blu.systemLog(remarks, emp_id, event_info, event_date, event_type, login_id);
            //***************** For System Log ******************//

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Substitution Holiday Save Successfully').then((value) => { window.location ='holidaySubstitute'; });", true);

        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("holidaySubstitute");
        }
    }
}