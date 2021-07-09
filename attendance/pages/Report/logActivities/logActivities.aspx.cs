using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.logActivities
{
    public partial class logActivities : System.Web.UI.Page
    {
        attendance blu = new attendance();
        DataTable dt;
        string login_id;
        string event_type;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadLogItems();
                loadEmployee();
            }
            else
            {

            }
        }
        public void loadLogItems()
        {
            dt = blu.getLogItems();
            if (dt.Rows.Count > 0)
            {
                DDLlogItems.DataSource = dt;
                DDLlogItems.DataTextField = "logItem_name";
                DDLlogItems.DataValueField = "logItem_id";
                DDLlogItems.DataBind();
                DDLlogItems.Items.Insert(0, "Select Log Item");
            }
        }

        protected void DDLlogItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLlogItems.Items[0].Attributes["disabled"] = "disabled";
        }
        protected void chkLogItems_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLogItems.Checked)
            {
                DDLlogItems.Enabled = false;
                DDLlogItems.Items.Clear();
            }
            else
            {
                loadLogItems();
                DDLlogItems.Enabled = true;
            }
        }

        public void loadEmployee()
        {
            dt = blu.getEmployees();
            if (dt.Rows.Count > 0)
            {
                CmbEmployee.DataSource = dt;
                CmbEmployee.DataTextField = "emp_fullname";
                CmbEmployee.DataValueField = "EMP_ID";
                CmbEmployee.DataBind();
                CmbEmployee.Items.Insert(0, "Select Employee");
            }
        }

        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
        }

        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            int emp_id = int.Parse(txtEmpId.Text);
            dt = blu.getAll_Info(emp_id);
            if (dt.Rows.Count > 0)
            {
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID !!!!','warning')", true);
                CmbEmployee.Enabled = false;
                CmbEmployee.Items.Clear();
                txtEmpId.Text = "";
            }
        }

        protected void Chkemp_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkemp.Checked)
            {
                CmbEmployee.Enabled = false;
                CmbEmployee.Items.Clear();
                txtEmpId.Enabled = false;
                txtEmpId.Text = "";
            }
            else
            {
                loadEmployee();
                CmbEmployee.Enabled = true;
                txtEmpId.Enabled = true;
            }
        }

        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (TxtStartDate.Text == "" || TxtEndDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Invalid Date. !!!','warning')", true);
                return;
            }
            else if (DDLlogItems.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Log Items. !!!','warning')", true);
                return;
            }
            else
            {
                if (Chkemp.Checked)
                {
                    login_id = "0";
                }
                else
                {
                    if (txtEmpId.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Employee. !!!','warning')", true);
                        return;
                    }
                    else
                    {
                        login_id = CmbEmployee.SelectedValue;
                    }
                }
            }
            DateTime Startdate = Convert.ToDateTime(TxtStartDate.Text);
            DateTime Enddate = Convert.ToDateTime(TxtEndDate.Text);
            if (chkLogItems.Checked)
            {
                event_type = "0";
            }
            else
            {
                event_type = DDLlogItems.SelectedValue;
            }

            Response.Redirect(String.Format("LogActivitiesView?Startdate={0}&Enddate={1}&event_type={2}&login_id={3}", Server.UrlEncode(Startdate.ToString()), Server.UrlEncode(Enddate.ToString()), Server.UrlEncode(event_type.ToString()), Server.UrlEncode(login_id.ToString())));
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogActivities");
        }
    }
}