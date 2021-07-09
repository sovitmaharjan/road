using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.otherReport.promotionReport {
    public partial class promotionReport : System.Web.UI.Page {
        attendance blu = new attendance();
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
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops !!!','No Department Available.','warning')", true);
                }
            }
            CmbBranch.Items[0].Attributes.Add("disabled", "disabled");
        }
        int branch_id;
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
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops !!!','No Department Available.','warning')", true);
            }
        }

        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e) {
            CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");
        }

        DateTime sdate, edate;
        protected void BtnLoad_Click(object sender, EventArgs e) {
            if (CmbBranch.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Project Field cannot be emptied!!!!','warning')", true);
                return;
            }
            if (CmbDepartment.SelectedIndex == 0) {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Department Field cannot be emptied !!!!','warning')", true);
                return;
            }

            sdate = Convert.ToDateTime(TxtStartDate.Text);
            edate = Convert.ToDateTime(TxtEndDate.Text);
            string branch_name = CmbBranch.SelectedItem.Text;
            int branch_id = int.Parse(CmbBranch.SelectedValue);
            string dept_name = CmbDepartment.SelectedItem.Text;
            int dept_id = int.Parse(CmbDepartment.SelectedValue);
            Response.Redirect(String.Format("promotionReportList?sdate={0}&edate={1}&branch_id={2}&branch_name={3}&dept_id={4}&dept_name={5}", Server.UrlEncode(sdate.ToString()), Server.UrlEncode(edate.ToString()), Server.UrlEncode(branch_id.ToString()), Server.UrlEncode(branch_name.ToString()), Server.UrlEncode(dept_id.ToString()), Server.UrlEncode(dept_name.ToString())));

        }
        protected void BtnReset_Click(object sender, EventArgs e) {
            Response.Redirect("promotionReport");
        }
    }
}