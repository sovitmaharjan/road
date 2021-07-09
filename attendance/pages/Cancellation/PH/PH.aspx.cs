using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Cancellation.PH
{
    public partial class PH : System.Web.UI.Page
    {
        attendance blu = new attendance();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

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

                dt = blu.getSubsitutedHolidays(emp_id);
                if (dt.Rows.Count > 0)
                {
                    DDLHolidayList.DataSource = dt;
                    DDLHolidayList.DataTextField = "HoliDay_NAME";
                    DDLHolidayList.DataValueField = "HoliDay_NAME";
                    DDLHolidayList.DataBind();
                    DDLHolidayList.Items.Insert(0, "Select Holiday");
                    DDLHolidayList.Items[0].Selected = true;
                    DDLHolidayList.Items[0].Attributes["disabled"] = "disabled";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops. !!!','No Records Found for Subsituted Holiday For Selected Employee. !!!','warning')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' No Employee Record Found With This ID !!!','warning')", true);
                return;
            }
        }

        protected void DDLHolidayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLHolidayList.Items[0].Attributes["disabled"] = "disabled";

            string holiday_name = DDLHolidayList.SelectedValue;
            int EMP_ID = Convert.ToInt32((TxtId.Text).ToString());
            dt = blu.getSubsitutedHolidaysName(holiday_name, EMP_ID);
            txtHolidayDate.Text = Convert.ToDateTime(dt.Rows[0]["PHDate"].ToString()).ToString("yyyy-MM-dd");
            txtSubsitutedDate.Text = Convert.ToDateTime(dt.Rows[0]["OnDate"].ToString()).ToString("yyyy-MM-dd");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (TxtId.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Employee Id Cannot Be  Blank !!!','warning')", true);
                return;
            }
            else if (DDLHolidayList.SelectedValue == "Select Holiday" || DDLHolidayList.SelectedValue == "" )
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Select Holiday Name. !!!','warning')", true);
                return;
            }
            else
            {
                int j = blu.cancelPhSubsitute(int.Parse(TxtId.Text), txtHolidayDate.Text);
                if(j > 0)
                {
                    //***************** For System Log ******************//
                    string remarks = "Subsituted PH Cancelled of " + ',' + txtHolidayDate.Text;
                    string event_info = "Subsituted PH Cancelled";
                    string event_type = "6";
                    string event_date = DateTime.Now.ToString();
                    int login_id = int.Parse(Session["userId"].ToString());
                    blu.systemLog(remarks, int.Parse(TxtId.Text), event_info, event_date, event_type, login_id);
                    //***************** For System Log ******************//

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done.','Subsituted PH Cancelled Successfully','success').then((value) => { window.location ='SubsitutedPHCancellation'; });", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Oops!','Subsituted PH Cancellation Unsuccessful !!!','warning')", true);
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubsitutedPHCancellation");
        }

        
    }
}