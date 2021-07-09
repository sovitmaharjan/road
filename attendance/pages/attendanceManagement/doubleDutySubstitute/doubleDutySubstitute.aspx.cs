using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.attendanceManagement.doubleDutySubstitute {
    public partial class doubleDutySubstitute : System.Web.UI.Page {
        attendance blu = new attendance();
        int emp_id;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                loadEmployee();
                //TxtSDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //TxtSubDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                BtnSave.Visible = false;

            }
        }
        public void loadEmployee() {
            DataTable dt = blu.getEmployees();
            CmbEmployee.DataSource = dt;
            CmbEmployee.DataTextField = "emp_fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");
        }


        protected void txtEmpId_TextChanged(object sender, EventArgs e) {
            CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
            if (dt.Rows.Count > 0) {
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                TxtDesg.Text = dt.Rows[0]["DEG_NAME"].ToString();
                TxtDept.Text = dt.Rows[0]["DEPT_NAME"].ToString();
                TxtBranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                TxtSts.Text = dt.Rows[0]["STATUS_NAME"].ToString();
                CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID !!!!','warning')", true);
                txtEmpId.Text = "";
                TxtDesg.Text = "";
                TxtDept.Text = "";
                TxtDept.Text = "";
                TxtSts.Text = "";
                loadEmployee();
            }

        }
        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e) {
            txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
            emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
            if (dt.Rows.Count > 0) {
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                TxtDesg.Text = dt.Rows[0]["DEG_NAME"].ToString();
                TxtDept.Text = dt.Rows[0]["DEPT_NAME"].ToString();
                TxtBranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                TxtSts.Text = dt.Rows[0]["STATUS_NAME"].ToString();
                CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID !!!!','warning')", true);
            }
        }

        protected void BtnLoad_Click(object sender, EventArgs e) {
            GridView.DataSource = null;
            GridView.DataBind();
            if (txtEmpId.Text == "") {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Enter EmployeeId!!!','warning')", true);
                return;
            } else if (TxtSDate.Text == "") {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Select Valid Date. !!!','warning')", true);
                return;
            } else {
                int emp_id = int.Parse(txtEmpId.Text);
                DateTime startdate = Convert.ToDateTime(TxtSDate.Text);
                DateTime enddate = Convert.ToDateTime(TxtSDate.Text);
                DataTable chksub = blu.CheckDoubleDuty(emp_id, startdate);
                if (chksub.Rows.Count > 0) {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Double Duty Subsitute has already been Done. !!!','warning')", true);
                } else {
                    int BranchId = 0;
                    int DeptId = 0;
                    blu.QuickAttnReport(emp_id, BranchId, DeptId, startdate, enddate, 0);
                    DataTable dt = blu.getQuickAttendanceData();
                    if (dt.Rows.Count > 0) {
                        if (dt.Rows[0]["InTime"].ToString() == "") {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','No Attendance on Selected Date of selected ID. !!!','warning')", true);
                        } else {
                            int totalOt = int.Parse(dt.Rows[0]["OT_Values"].ToString());
                            if (totalOt < 240) {
                                BtnSave.Visible = false;
                                GridView.DataSource = dt;
                                GridView.DataBind();
                                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Not Applicable for Double Duty Subsitute.!!!','warning')", true);
                            } else {
                                GridView.DataSource = dt;
                                GridView.DataBind();

                                BtnLoad.Visible = false;
                                BtnReset.Visible = false;
                                BtnSave.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e) {
            Response.Redirect("doubleDutySubstitute");
        }

        protected void BtnSave_Click(object sender, EventArgs e) {
            if (txtEmpId.Text == "") {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Enter EmployeeId!!!','warning')", true);
                return;
            } else if (TxtSDate.Text == "") {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Enter Double Duty Date!!!','warning')", true);
                return;
            } else if (TxtSubDate.Text == "") {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!',' Plz Enter Double Duty Date!!!','warning')", true);
                return;
            } else {
                string emp_id = txtEmpId.Text;
                DateTime DDate = Convert.ToDateTime(TxtSDate.Text);
                DateTime SubDate = Convert.ToDateTime(TxtSubDate.Text);

                int i = blu.saveDoubleDutysSubsitute(DDate, emp_id, SubDate);
                if (i > 0) {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Double Duty Substitute Saved Successfully').then((value) => { window.location ='doubleDutySubstitute'; });", true);
                } else {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Error!','Double Duty Substitute wasnt Saved','warning').then((value) => { window.location ='doubleDutySubstitute'; });", true);
                }
            }
        }
    }
}