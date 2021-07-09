using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Cancellation.Weekend
{
    public partial class weekend : System.Web.UI.Page
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

                dt = blu.getSubsitutedWeekend(emp_id);
                if (dt.Rows.Count > 0)
                {
                    DDLWeekendList.DataSource = dt;
                    DDLWeekendList.DataTextField = "week_day";
                    DDLWeekendList.DataValueField = "week_day";
                    DDLWeekendList.DataBind();
                    DDLWeekendList.Items.Insert(0, "Select Weekend");
                    DDLWeekendList.Items[0].Selected = true;
                    DDLWeekendList.Items[0].Attributes["disabled"] = "disabled";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops. !!!','No Records Found for Subsituted Weekend For Selected Employee. !!!','warning')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' No Employee Record Found With This ID !!!','warning')", true);
                return;
            }
        }
        protected void DDLWeekendList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLWeekendList.Items[0].Attributes["disabled"] = "disabled";
            string week_day = DDLWeekendList.SelectedValue;
            int EMP_ID = Convert.ToInt32((TxtId.Text).ToString());
            dt = blu.getSubsitutedWeekendDate(EMP_ID, week_day);
            txtSubsitutedDate.Text = Convert.ToDateTime(dt.Rows[0]["sub_Day"].ToString()).ToString("yyyy-MM-dd");
            txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (TxtId.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Employee Id Cannot Be  Blank !!!','warning')", true);
                return;
            }
            else if (DDLWeekendList.SelectedValue == "" || DDLWeekendList.SelectedValue == "Select Weekend")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Weekend Date Not Selected !!!','warning')", true);
                return;
            }
            else
            {
                int j = blu.cancelWeekendSubsitute(txtSubsitutedDate.Text, int.Parse(TxtId.Text));
                if (j > 0)
                {
                    //***************** For System Log ******************//
                    string remarks = "Subsituted Weekend Cancelled of " + ',' + txtSubsitutedDate.Text;
                    string event_info = "Subsituted Weekend Cancelled";
                    string event_type = "7";
                    string event_date = DateTime.Now.ToString();
                    int login_id = int.Parse(Session["userId"].ToString());
                    blu.systemLog(remarks, int.Parse(TxtId.Text), event_info, event_date, event_type, login_id);
                    //***************** For System Log ******************//

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done.','Subsituted PH Cancelled Successfully','success').then((value) => { window.location ='SubsitutedWeekendCancellation'; });", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Oops!','Subsituted Weekend Cancellation Unsuccessful !!!','warning')", true);
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubsitutedWeekendCancellation");
        }
    }
}