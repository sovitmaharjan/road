using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.Report.inOutInfo {
    public partial class inOutInfo : System.Web.UI.Page {
        attendance blu = new attendance();
        DateTime sdate, edate;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                loadBranch();                
                CmbBranch.Items[0].Attributes.Add("disabled", "disabled");
            }
        }
        public void loadBranch()
        {
            DataTable dt = blu.getBranchList();
            if (dt.Rows.Count == 1)
            {
                string branch_id = dt.Rows[0]["BRANCH_ID"].ToString();
                CmbBranch.DataSource = dt;
                CmbBranch.DataTextField = "BRANCH_NAME";
                CmbBranch.DataValueField = "BRANCH_ID";
                CmbBranch.SelectedValue = branch_id;
                CmbBranch.DataBind();
                CmbBranch.Items.Insert(0, "Select Branch");
                CmbBranch.SelectedIndex = 1;
            }
            else
            {
                CmbBranch.DataSource = dt;
                CmbBranch.DataTextField = "BRANCH_Name";
                CmbBranch.DataValueField = "BRANCH_ID";
                CmbBranch.DataBind();
                CmbBranch.Items.Insert(0, "Select Branch");
            }
        }
        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e) {
            CmbBranch.Items[0].Attributes.Add("disabled", "disabled");
        }
        protected void BtnLoad_Click(object sender, EventArgs e) {
            if (CmbBranch.SelectedItem.Text == "Select Branch") {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First  !!!!','warning')", true);
                return;
            }
            if (TxtStartDate.Text == "" || TxtEndDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Invalid Date. !!!','warning')", true);
                return;
            }
            sdate = Convert.ToDateTime(TxtStartDate.Text);
            edate = Convert.ToDateTime(TxtEndDate.Text);
            string branch_name = CmbBranch.SelectedItem.Text;
            int branch_id = int.Parse(CmbBranch.SelectedValue);
            Response.Redirect(String.Format("ViewMissingPunch?sdate={0}&edate={1}&branch_id={2}&branch_name={3}", Server.UrlEncode(sdate.ToString()), Server.UrlEncode(edate.ToString()), Server.UrlEncode(branch_id.ToString()), Server.UrlEncode(branch_name.ToString())));

        }
        protected void BtnReset_Click(object sender, EventArgs e) {
            Response.Redirect("MissingPunch");
        }
    }
}