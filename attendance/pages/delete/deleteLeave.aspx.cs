using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.delete
{
    public partial class deleteLeave : System.Web.UI.Page
    {
        attendance blu = new attendance();
        int emp_id;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                loadEmployee();
                //loadLeave();
                BtnDelete.Visible = false;
                BtnReset.Visible = false;
            }
            else
            {
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            }
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
            CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            txtEmpId.Text = CmbEmployee.SelectedValue.ToString();

            emp_id = int.Parse(txtEmpId.Text);

            dt = blu.getleave_emp(emp_id);
            if (dt.Rows.Count > 0)
            {
                CmbLeave.DataSource = dt;
                CmbLeave.DataTextField = "LEAVE_NAME";
                CmbLeave.DataValueField = "LEAVE_ID";
                CmbLeave.DataBind();
                CmbLeave.Items.Insert(0, "Select Leave");
                CmbLeave.Items[0].Selected = true;
                CmbLeave.Items[0].Attributes["disabled"] = "disabled";
            }
            else
            {
                loadEmployee();
                txtEmpId.Text = "";
                CmbLeave.Items.Clear();
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave Assigned To Selected Employee. !!!','warning')", true);
            }
        }

        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            loadEmployee();
            CmbEmployee.Enabled = true;
            emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
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
            }

            dt = blu.getleave_emp(emp_id);
            if (dt.Rows.Count > 0)
            {
                CmbLeave.DataSource = dt;
                CmbLeave.DataTextField = "LEAVE_NAME";
                CmbLeave.DataValueField = "LEAVE_ID";
                CmbLeave.DataBind();
                CmbLeave.Items.Insert(0, "Select Leave");
                CmbLeave.Items[0].Selected = true;
                CmbLeave.Items[0].Attributes["disabled"] = "disabled";
            }
            else
            {
                loadEmployee();
                txtEmpId.Text = "";
                CmbLeave.Items.Clear();
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Leave Assigned To Selected Empoloyee. !!!','warning')", true);
            }
        }

        protected void CmbLeave_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbLeave.Items[0].Attributes["disabled"] = "disabled";
        }

        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            if (txtEmpId.Text == " ")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Employee. !!!','warning')", true);
                return;
            }
            else if (CmbLeave.SelectedItem.Text == "Select Leave")
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Leave Name !!!','warning')", true);
                return;
            }
            else
            {
                GridView.DataSource = null;
                GridView.DataBind();
                BtnDelete.Visible = false;
                BtnReset.Visible = false;
                string emp_id = txtEmpId.Text;
                string leave_id = CmbLeave.SelectedValue;
                string isOpening;
                if(ChkOpen.Checked)
                {
                    isOpening = "1";
                }
                else
                {
                    isOpening = "0";
                }
                DataTable dt = blu.getLeaveForDelete(emp_id, leave_id, isOpening);
                if(dt.Rows.Count > 0 )
                {
                    GridView.DataSource = dt;
                    GridView.DataBind();
                    BtnDelete.Visible = true;
                    BtnReset.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops !!!',' Selected Leave Not Found For Selected Employee.!!!','warning')", true);
                    return;
                }
            }
        }
        int j;
        string leave_name;

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string emp_id = (row.Cells[1].FindControl("EMP_ID") as Label).Text;
                    string leave_id = (row.Cells[2].FindControl("LEAVE_ID") as Label).Text;
                    leave_name = (row.Cells[2].FindControl("LEAVE_NAME") as Label).Text;
                    string is_opening = (row.Cells[9].FindControl("OP_FLAG") as Label).Text;
                    j = blu.deleteLeave(emp_id, leave_id, is_opening);
                }

            }
            if (j > 0)
            {
                //***************** For System Log ******************//
                string remarks = "Delete Leave Days - " + leave_name;
                string event_info = "Delete Leave ";
                string event_type = "2";
                string event_date = DateTime.Now.ToString();
                int login_id = int.Parse(Session["userId"].ToString());
                blu.systemLog(remarks, int.Parse(txtEmpId.Text), event_info, event_date, event_type, login_id);
                //***************** For System Log ******************//
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Leave Deleted Successfully').then((value) => { window.location ='DeleteLeave'; });", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Error While Deleting!!!','warning')", true);
            }

        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("deleteLeave");
        }
    }
}