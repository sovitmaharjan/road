using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.hrManagement.promotion {
    public partial class addPromotion : System.Web.UI.Page {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                loadBranch();
                loadDesignation();

            }
            CmbBranch.Items[0].Attributes["disabled"] = "disabled";
            CmbDesignation.Items[0].Attributes["disabled"] = "disabled";
        }

        public void loadBranch() {
            DataTable dt = blu.getBranch();
            CmbBranch.DataSource = dt;
            CmbBranch.DataTextField = "BRANCH_Name";
            CmbBranch.DataValueField = "BRANCH_ID";
            CmbBranch.DataBind();
            //CmbBranch.Items.Insert(0, "Select Branch");
            CmbBranch.Items[0].Attributes["disabled"] = "disabled";
        }

        public void loadDesignation() {
            DataTable dt = blu.getDesignationList();
            CmbDesignation.DataSource = dt;
            CmbDesignation.DataTextField = "DEG_NAME";
            CmbDesignation.DataValueField = "DEG_ID";
            CmbDesignation.DataBind();
            CmbDesignation.Items.Insert(0, "Select Designation");
            CmbDesignation.Items[0].Attributes["disabled"] = "disabled";

        }

        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e) {
            string projectname = (CmbBranch.SelectedItem).ToString();
            int projectid = int.Parse(CmbBranch.SelectedValue);

            CmbBranch.Items[0].Attributes["disabled"] = "disabled";
        }

        protected void TxtEmpId_TextChanged(object sender, EventArgs e) {
            int emp_id = int.Parse(TxtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);

            if (dt.Rows.Count > 0) {
                TxtName.Text = dt.Rows[0]["emp_fullname"].ToString();
                TxtBranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
                TxtBranchid.Text = dt.Rows[0]["BRANCH_ID"].ToString();
                TxtDesignation.Text = dt.Rows[0]["DEG_NAME"].ToString();
                TxtDegid.Text = dt.Rows[0]["DEG_ID"].ToString();
                TxtOldSalary.Text = dt.Rows[0]["BSALARY"].ToString();

                DateTime result = Convert.ToDateTime(dt.Rows[0]["EMP_JOINDATE"].ToString());
                TxtStartDate.Text = result.ToString("yyyy-MM-dd");
            } else {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Oops!!!','No Employee with Provided ID.','warning')", true);
                TxtEmpId.Text = "";
            }
        }

        protected void CmbDesignation_SelectedIndexChanged(object sender, EventArgs e) {
            CmbDesignation.Items[0].Attributes["disabled"] = "disabled";
            txtnewdegid.Text = CmbDesignation.SelectedValue.ToString();

        }

        int Iscurrent;
        protected void BtnSave_Click(object sender, EventArgs e) {
            string emp_id = TxtEmpId.Text;
            DateTime date = Convert.ToDateTime(TxtEnglishDate.Text);

            int old_branchid = Convert.ToInt32(TxtBranchid.Text);
            int old_desgid = Convert.ToInt32(TxtDegid.Text);
            int old_salary = Convert.ToInt32(TxtOldSalary.Text);

            int new_branchid = Convert.ToInt32(CmbBranch.SelectedValue.ToString());
            int new_desgid = Convert.ToInt32(CmbDesignation.SelectedValue.ToString());
            int new_salary = Convert.ToInt32(TxtNewSalary.Text);

            string description = txtDescription.Text;
            string PromotionalTitle = txtDescription.Text;
            if (chkPromotion.Checked) {
                Iscurrent = 1;
            } else {
                Iscurrent = 0;
            }

            int j = blu.EmployeePromotion(emp_id, date, description, 1, old_desgid, Iscurrent, 1, new_desgid, old_salary, new_salary);
            if (j > 0) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done. !!!','Promotion saved Successfully','success').then((value) => { window.location ='promotionList'; });", true);
            } else {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Oops. !!!','Promotion Not saved, Try Again','warning').then((value) => { window.location ='promotionList'; });", true);
            }

        }
        protected void BtnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("promotionList");
        }
    }
}