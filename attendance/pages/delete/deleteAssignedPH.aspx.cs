using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.delete
{
    public partial class deleteAssignedPH : System.Web.UI.Page
    {
        attendance blu = new attendance();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadEmployee();
                BtnDelete.Visible = false;
                BtnReset.Visible = false;
            }
            CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
        }

        public void loadEmployee()
        {
            dt = blu.getEmployees();
            CmbEmployee.DataSource = dt;
            CmbEmployee.DataTextField = "emp_fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");
        }
        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmpId.Text = CmbEmployee.SelectedValue;
            int emp_id = Convert.ToInt32(CmbEmployee.SelectedValue);
            dt = blu.getAssignedPH(emp_id);
            if (dt.Rows.Count > 0)
            {
                CmbPH.DataSource = dt;
                CmbPH.DataTextField = "HoliDay_Name";
                CmbPH.DataValueField = "fduty_id";
                CmbPH.DataBind();
                CmbPH.Items.Insert(0, "Select HoliDay");
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Holiday Assigned to Selected Employee. !!!','warning')", true);
            }
        }

        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            int emp_id = Convert.ToInt32(txtEmpId.Text);
            dt = blu.getAll_Info(emp_id);
            if (dt.Rows.Count > 0)
            {
                CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
                dt = blu.getAssignedPH(emp_id);
                if (dt.Rows.Count > 0)
                {
                    CmbPH.DataSource = dt;
                    CmbPH.DataTextField = "HoliDay_Name";
                    CmbPH.DataValueField = "fduty_id";
                    CmbPH.DataBind();
                    CmbPH.Items.Insert(0, "Select HoliDay");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Holiday Assigned to Selected Employee. !!!','warning')", true);
                }
            }
            else
            {
                txtEmpId.Text = "";
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID !!!!','warning')", true);
            }
        }
        protected void CmbPH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string phName = CmbPH.SelectedItem.ToString();
            int emp_id = Convert.ToInt32(CmbEmployee.SelectedValue);
            dt = blu.getSubsitutedHolidaysName(phName, emp_id);
            txtPHDate.Text = Convert.ToDateTime(dt.Rows[0]["PHDate"].ToString()).ToString("yyyy-MM-dd");
        }

        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            string phName = CmbPH.SelectedItem.ToString();
            int emp_id = Convert.ToInt32(CmbEmployee.SelectedValue);
            dt = blu.getSubsitutedHolidaysName(phName, emp_id);
            if (dt.Rows.Count > 0)
            {
                GridView.DataSource = dt;
                GridView.DataBind();
                BtnDelete.Visible = true;
                BtnReset.Visible = true;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string fDutyId = CmbPH.SelectedValue;
            int j = blu.deleteAssignedPh(fDutyId);
            if (j > 0)
            {
                //***************** For System Log ******************//
                string remarks = "Delete PH Assigned of  " + txtPHDate;
                string event_info = "PH Assigned Deleted";
                string event_type = "9";
                string event_date = DateTime.Now.ToString();
                int login_id = int.Parse(Session["userId"].ToString());
                blu.systemLog(remarks, int.Parse(txtEmpId.Text), event_info, event_date, event_type, login_id);
                //***************** For System Log ******************//

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done.','Assigned PH Cancelled Successfully','success').then((value) => { window.location ='DeleteAssignedPH'; });", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Error While Deleting Assigned PH. !!!','warning')", true);
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteAssignedPH");
        }
    }
}