using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.otherReport.transferReport {
    public partial class transferReport : System.Web.UI.Page {
        attendance blu = new attendance();
        int branch_id;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                loadBranch();
                //TxtStartDate.Text = DateTime.Now.ToString("yyyy-MM-01");
                //TxtEndDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                DataTable dt = blu.getBranch_DepartmentList(1);
                if (dt.Rows.Count > 0) {
                    CmbDepartment.DataSource = dt;
                    CmbDepartment.DataTextField = "DEPT_NAME";
                    CmbDepartment.DataValueField = "DEPT_ID";
                    CmbDepartment.DataBind();
                    CmbDepartment.Items.Insert(0, "Select Department");
                    CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");
                } else {
                    CmbDepartment.Items.Clear();
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available!!!!','warning')", true);
                }
            }
            CmbBranch.Items[0].Attributes.Add("disabled", "disabled");

        }
        public void loadBranch() {
            DataTable dt = blu.getBranchList();
            CmbBranch.DataSource = dt;
            CmbBranch.DataTextField = "BRANCH_Name";
            CmbBranch.DataValueField = "BRANCH_ID";
            CmbBranch.DataBind();
            CmbBranch.Items.Insert(0, "Select Branch");
            CmbBranch.SelectedIndex = 1;
        }
        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e) {
            branch_id = Convert.ToInt32(CmbBranch.SelectedValue);
            DataTable dt = blu.getBranch_DepartmentList(branch_id);
            if (dt.Rows.Count > 0) {
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");
                CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");
            } else {
                CmbDepartment.Items.Clear();
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available!!!!','warning')", true);
            }
        }
        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e) {
            CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");
        }
        protected void BtnLoad_Click(object sender, EventArgs e) {
            if (CmbBranch.SelectedIndex == 0) {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Select Project First !!!','warning')</script>");
                return;
            }
            if (CmbDepartment.SelectedIndex == 0) {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','Select Department!!!','warning')</script>");
                return;
            }

            DateTime sdate = Convert.ToDateTime(TxtStartDate.Text);
            DateTime edate = Convert.ToDateTime(TxtEndDate.Text);
            string branch_name = CmbBranch.SelectedItem.Text;
            int branch_id = Convert.ToInt32(CmbBranch.SelectedValue);
            string dept_name = CmbDepartment.SelectedItem.Text;
            int dept_id = Convert.ToInt32(CmbDepartment.SelectedValue);
            Response.Redirect(String.Format("transferReportList?sdate={0}&edate={1}&branch_name={2}&branch_id={3}&dept_name={4}&dept_id{5}", Server.UrlEncode(sdate.ToString()), Server.UrlEncode(edate.ToString()), Server.UrlEncode(branch_name.ToString()), Server.UrlEncode(branch_id.ToString()), Server.UrlEncode(sdate.ToString()), Server.UrlEncode(dept_id.ToString())));


        }
        protected void BtnReset_Click(object sender, EventArgs e) {
            Response.Redirect("transferReport");
        }
    }
}