using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.hrManagement.transfer {
    public partial class addTransfer : System.Web.UI.Page {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                loadBranch();
                //loadDepartment();
                //TxtDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                DataTable dt = blu.getBranch_DepartmentList(1);
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
            }
            CmbBranch.Items[0].Attributes["disabled"] = "disabled";

        }
        public void loadBranch() {
            DataTable dt = blu.getBranch();
            CmbBranch.DataSource = dt;
            CmbBranch.DataTextField = "BRANCH_Name";
            CmbBranch.DataValueField = "BRANCH_ID";
            CmbBranch.DataBind();
            //CmbBranch.Items.Insert(0, "Select Branch");
        }

        //public void loadDepartment()
        //{
        //    DataTable dt = blu.getDepartment();
        //    CmbDepartment.DataSource = dt;
        //    CmbDepartment.DataTextField = "DEPT_NAME";
        //    CmbDepartment.DataValueField = "DEPT_ID";
        //    CmbDepartment.DataBind();
        //    CmbDepartment.Items.Insert(0, "Select Department");
        //}

        protected void txtEmpId_TextChanged(object sender, EventArgs e) {
            int emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);

            if (dt.Rows.Count > 0) {
                txtName.Text = dt.Rows[0]["emp_fullname"].ToString();
                TxtBranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                TxtBranchId.Text = dt.Rows[0]["BRANCH_ID"].ToString();
                TxtDepartment.Text = dt.Rows[0]["DEPT_NAME"].ToString();
                TxtDepartmentID.Text = dt.Rows[0]["BRANCH_ID"].ToString();
            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee Available with that ID !!!','warning')", true);
                txtEmpId.Text = " ";
                TxtBranch.Text = "";
                TxtDepartment.Text = "";
            }
        }

        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e) {
            string branchname = (CmbBranch.SelectedItem).ToString();
            int branchid = Convert.ToInt32(CmbBranch.SelectedValue);

            DataTable dt = blu.getBranch_DepartmentList(branchid);
            CmbDepartment.DataSource = dt;
            CmbDepartment.DataTextField = "DEPT_NAME";
            CmbDepartment.DataValueField = "DEPT_ID";
            CmbDepartment.DataBind();
            CmbDepartment.Items.Insert(0, "Select Department");
            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
        }

        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e) {
            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
        }

        protected void BtnSave_Click(object sender, EventArgs e) {
            int j = blu.CreateTransfer(Convert.ToDateTime(TxtDate.Text), txtDescription.Text, chkTransfer.Checked ? 1 : 0, txtEmpId.Text, Convert.ToInt32(CmbBranch.SelectedValue), Convert.ToInt32(CmbDepartment.SelectedValue), 0, 0, Convert.ToInt32(TxtBranchId.Text), 0, 0);
            if (j > 0) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done !!!','Transfer saved Successfully','success').then((value) => { window.location ='transferList'; });", true);
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("addTransfer");
        }
    }
}