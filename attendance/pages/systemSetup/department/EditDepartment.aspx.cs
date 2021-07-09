using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.department {
    public partial class EditDepartment : System.Web.UI.Page {

        attendance blu = new attendance();
        int status = 0;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                int departmentid = Convert.ToInt32(Request.QueryString["DEPT_ID"].ToString());
                HiddenField1.Value = departmentid.ToString();
                DataTable dta = blu.GetdepartmentbydepartmentId(departmentid);
                txtDeptname.Text = Request.QueryString["DEPT_NAME"].ToString();
                status = Convert.ToInt32(Request.QueryString["status"].ToString());
                if (status == 1) {
                    rbStatus.Checked = true;
                    rbStatus1.Checked = false;
                } else {
                    rbStatus.Checked = false;
                    rbStatus1.Checked = true;
                }
            }
        }

        string olddept = "";
        protected void BtnUpdate_Click(object sender, EventArgs e) {
            string sst = olddept;
            olddept = Request.QueryString["olddept"].ToString();
            blu.AddDepartment("Main", txtDeptname.Text, 0, olddept, rbStatus.Checked ? 1 : 0);
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Department Updated Successfully').then((value) => { window.location ='DepartmentList'; });", true);
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("DepartmentList");
        }
    }
}