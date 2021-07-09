using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.department {
    public partial class AddDepartment : System.Web.UI.Page {

        attendance blu = new attendance();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                CmbDepartment.Visible = false;
                txtSecname.Visible = false;
                loadDepartment();
            }
        }

        public void loadDepartment() {
            DataTable dt = blu.getDepartment();
            CmbDepartment.DataSource = dt;
            CmbDepartment.DataTextField = "DEPT_NAME";
            CmbDepartment.DataValueField = "DEPT_ID";
            CmbDepartment.DataBind();
            CmbDepartment.Items.Insert(0, "Select Department");
            CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");
        }
        //int Flag = 0;
        protected void chkbxGroup_CheckedChanged1(object sender, EventArgs e) {
            if (chkbxGroup.Checked == true) {
                CmbDepartment.Visible = true;
                txtDeptname.Text = txtDeptname.Text + " Sec";
                chkbxSection.Enabled = false;
            } else {
                CmbDepartment.Visible = false;
                chkbxSection.Enabled = true;
            }
        }

        protected void chkbxSection_CheckedChanged(object sender, EventArgs e) {
            if (chkbxSection.Checked == true) {
                txtSecname.Visible = true;
                txtSecname.Text = txtDeptname.Text + " Sec ";
                chkbxGroup.Enabled = false;
            } else {
                txtSecname.Visible = false;
                chkbxGroup.Enabled = true;
            }


        }
        //DataTable dt;
        string olddept = "";
        int stat = 0;
        protected void BtnSave_Click(object sender, EventArgs e) {
            if (chkbxSection.Checked == true) {
                blu.AddDepartment(txtDeptname.Text, txtSecname.Text, 2, olddept, rbStatus.Checked ? 1 : 0);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Department saved Successfully').then((value) => { window.location ='DepartmentList'; });", true);
            } else if (chkbxGroup.Checked == true) {
                string cmbdeptname = CmbDepartment.SelectedItem.ToString();
                blu.AddDepartment(cmbdeptname, txtDeptname.Text, 1, olddept, rbStatus.Checked ? 1 : 0);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Department saved Successfully').then((value) => { window.location ='DepartmentList'; });", true);

            } else {
                blu.AddDepartment("Main", txtDeptname.Text, 0, olddept, stat);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Department saved Successfully').then((value) => { window.location ='DepartmentList'; });", true);
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("AddDepartment");
        }
    }
}