using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.department {
    public partial class department : System.Web.UI.Page {

        attendance attendanceObject = new attendance();
        static attendance staticAttendanceObject = new attendance();

        public string baseUrl {

            get {

                return attendanceObject.baseUrl();
            }
        }

        public string projectName {

            get {

                return attendanceObject.projectName();
            }
        }

        protected void Page_Load(object sender, EventArgs e) {

            //int id = Convert.ToInt32(Request.Params["b80bb7740288fda1f201890375a60c8f"]);
            //if (id == 0) {

            //    pageNamePlace1.Text = "Add Branch";
            //    pageNamePlace2.Text = "Add Branch";
            //} else {

            //    pageNamePlace1.Text = "Edit Branch";
            //    pageNamePlace2.Text = "Edit Branch";
            //    if (!IsPostBack) {

            //        DataTable dtbranch = attendanceObject.branch(id);
            //        branchCodeForm.Value = dtbranch.Rows[0]["BRANCH_CODE"].ToString();
            //        branchNameForm.Value = dtbranch.Rows[0]["BRANCH_NAME"].ToString();
            //        if (Convert.ToInt32(dtbranch.Rows[0]["ISOUTBRANCH"]) == 1) {

            //            isOutBranchForm.Checked = true;
            //        }
            //        if (Convert.ToInt32(dtbranch.Rows[0]["status"]) == 1) {

            //            statusYesForm.Checked = true;
            //        } else {

            //            statusNoForm.Checked = true;
            //        }
            //    }
            //}
        }

        protected void saveClick(object sender, EventArgs e) {

            //int id = Convert.ToInt32(Request.Params["b80bb7740288fda1f201890375a60c8f"]);
            //string dmlOption;
            //if (id == 0) {

            //    dmlOption = "I";
            //} else {

            //    dmlOption = "U";
            //}
            //string branchCode = branchCodeForm.Value;
            //string branchName = branchNameForm.Value;
            //int serialNo = 0;
            //int isOutBranch;
            //if (isOutBranchForm.Checked) {

            //    isOutBranch = 1;
            //} else {

            //    isOutBranch = 0;
            //}
            //int status;
            //if (statusYesForm.Checked) {

            //    status = 1;
            //} else {

            //    status = 0;
            //}
            //attendanceObject.saveBranch(id, branchCode, branchName, serialNo, dmlOption, isOutBranch, status);
            //Response.Redirect("BranchList");
        }
    }
}