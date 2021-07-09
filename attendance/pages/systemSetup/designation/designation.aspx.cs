using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.designation {
    public partial class designation : System.Web.UI.Page {

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

                pageNamePlace1.Text = "Add Designation";
                pageNamePlace2.Text = "Add Designation";
            } else {

                pageNamePlace1.Text = "Edit Designation";
                pageNamePlace2.Text = "Edit Designation";
                if (!IsPostBack) {

                    DataTable dtDesignation = attendanceObject.designation(id);
                    designationNameForm.Value = dtDesignation.Rows[0]["DEG_NAME"].ToString();
                    if (Convert.ToInt32(dtDesignation.Rows[0]["status"]) == 1) {

                        statusYesForm.Checked = true;
                    } else {

                        statusNoForm.Checked = true;
                    }
                }
            }
        }

        protected void saveClick(object sender, EventArgs e) {

            int id = Convert.ToInt32(Request.Params["b80bb7740288fda1f201890375a60c8f"]);
            string designationName = designationNameForm.Value;
            int status;
            if (statusYesForm.Checked) {

                status = 1;
            } else {

                status = 0;
            }
            attendanceObject.manageDesignation(id, designationName, status);
            Response.Redirect("designationList");
        }
    }
}