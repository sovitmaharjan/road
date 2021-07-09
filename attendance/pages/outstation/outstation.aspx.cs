using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.outstation {
    public partial class outstation : System.Web.UI.Page {
        attendance blu = new attendance();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                loadEmployee();
                loadApprover();

                DataTable dt = blu.getOutstandingId();
                TxtId.Text = dt.Rows[0]["travel_id"].ToString();

                //TxtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //TxtEndDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                DDLEmployee.Items[0].Attributes["Disabled"] = "Disabled";
                DDLApprover.Items[0].Attributes["Disabled"] = "Disabled";
            }
        }
        public void loadEmployee() {
            DataTable dt = blu.getEmployees();
            DDLEmployee.DataSource = dt;
            DDLEmployee.DataTextField = "emp_fullname";
            DDLEmployee.DataValueField = "EMP_ID";
            DDLEmployee.DataBind();
            DDLEmployee.Items.Insert(0, "Select Employee");
        }
        public void loadApprover() {
            DataTable dt = blu.getHODList();
            DDLApprover.DataSource = dt;
            DDLApprover.DataTextField = "emp_fullname";
            DDLApprover.DataValueField = "EMP_ID";
            DDLApprover.DataBind();
            DDLApprover.Items.Insert(0, "Select Approver");
        }
        protected void DDLEmployee_SelectedIndexChanged(object sender, EventArgs e) {
            DDLEmployee.Items[0].Attributes["Disabled"] = "Disabled";
            TxtEmpId.Text = DDLEmployee.SelectedValue;
            int emp_id = int.Parse(TxtEmpId.Text);
            DataTable dt = blu.getHODbyID(emp_id);
            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["HOD_ID"].ToString() == "0") {
                    DDLApprover.Items.Insert(0, "NO HOD");
                    DDLApprover.Items[1].Enabled = false;
                } else {
                    DDLApprover.SelectedValue = dt.Rows[0]["HOD_ID"].ToString();
                    DDLApprover.Items[0].Attributes["Disabled"] = "Disabled";
                }
            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with that ID !!!','warning')", true);
            }

        }
        protected void TxtEmpId_TextChanged(object sender, EventArgs e) {
            int emp_id = Convert.ToInt32(TxtEmpId.Text);

            dt = blu.getAllInfo(emp_id);
            if (dt.Rows.Count > 0) {
                DDLEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with that ID !!!','warning')", true);
            }

            DataTable dt1 = blu.getHODbyID(emp_id);
            if (dt1.Rows.Count > 0) {
                if (dt.Rows[0]["HOD_ID"].ToString() == "0") {
                    DDLApprover.Items.Insert(0, "NO HOD");
                    DDLApprover.Items[1].Enabled = false;
                } else {
                    DDLApprover.SelectedValue = dt.Rows[0]["HOD_ID"].ToString();
                    DDLApprover.Items[0].Attributes["Disabled"] = "Disabled";
                }
            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with that ID !!!','warning')", true);
            }
            DDLEmployee.Items[0].Attributes["Disabled"] = "Disabled";
        }
        protected void DDLApprover_SelectedIndexChanged(object sender, EventArgs e) {
            DDLApprover.Items[0].Attributes["Disabled"] = "Disabled";
        }

        int days;
        protected void BtnSave_Click(object sender, EventArgs e) {
            DateTime dt1 = Convert.ToDateTime(TxtStartDate.Text);
            DateTime dt2 = Convert.ToDateTime(TxtEndDate.Text);
            if (dt1 > dt2) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Strat Date cannot be greater than Endate !!!','warning')", true);
                TxtStartDate.Text = "";
                TxtEndDate.Text = "";
            } else {
                TimeSpan ts = dt2 - dt1;
                days = Convert.ToInt32((ts.Days + 1).ToString()); ;
            }
            if (TxtEmpId.Text == "") {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Employee Id cannot be Empty !!!','warning')", true);
            } else if (DDLEmployee.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Employee Name  cannot be Empty !!!','warning')", true);
            } else if (txtDescription.Text == "") {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Description cannot be Empty !!!','warning')", true);
            } else {
                int emp_id = Convert.ToInt32(TxtEmpId.Text);
                int user_id = int.Parse(Session["username"].ToString());
                dt = blu.getAllInfo(emp_id);
                int dept_id = int.Parse(dt.Rows[0]["DEPT_ID"].ToString());
                int deg_id = int.Parse(dt.Rows[0]["DEG_ID"].ToString());
                int j = blu.saveOutstation(int.Parse(TxtId.Text), int.Parse(TxtEmpId.Text), dept_id, deg_id, TxtStation.Text, Convert.ToDateTime(TxtStartDate.Text), Convert.ToDateTime(TxtEndDate.Text), days, txtDescription.Text, int.Parse(DDLApprover.SelectedValue.ToString()), user_id);
                if (j > 0) {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done. !!!','Branch saved Successfully','success').then((value) => { window.location ='outstationList.aspx'; });", true);
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("outstation");
        }
    }
}