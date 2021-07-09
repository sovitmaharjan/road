using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.branch {
    public partial class branch : System.Web.UI.Page {

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

            int id = Convert.ToInt32(Request.Params["b80bb7740288fda1f201890375a60c8f"]);
            if (id == 0) {

                pageNamePlace1.Text = "Add Branch";
                pageNamePlace2.Text = "Add Branch";
            } else {

                pageNamePlace1.Text = "Edit Branch";
                pageNamePlace2.Text = "Edit Branch";
                if (!IsPostBack) {

                    DataTable dtBranch = attendanceObject.branch(id);
                    branchCodeForm.Value = dtBranch.Rows[0]["BRANCH_CODE"].ToString();
                    branchNameForm.Value = dtBranch.Rows[0]["BRANCH_NAME"].ToString();
                    if (Convert.ToInt32(dtBranch.Rows[0]["ISOUTBRANCH"]) == 1) {

                        isOutBranchForm.Checked = true;
                    }
                    if (Convert.ToInt32(dtBranch.Rows[0]["status"]) == 1) {

                        statusYesForm.Checked = true;
                    } else {

                        statusNoForm.Checked = true;
                    }
                }
            }
        }

        protected void saveClick(object sender, EventArgs e) {

            int id = Convert.ToInt32(Request.Params["b80bb7740288fda1f201890375a60c8f"]);
            string branchCode = branchCodeForm.Value;
            string branchName = branchNameForm.Value;
            int isOutBranch;
            if (isOutBranchForm.Checked) {

                isOutBranch = 1;
            } else {

                isOutBranch = 0;
            }
            int status;
            if (statusYesForm.Checked) {

                status = 1;
            } else {

                status = 0;
            }
            attendanceObject.manageBranch(id, branchCode, branchName, isOutBranch, status);
            Response.Redirect("branchList");
        }
    }
}