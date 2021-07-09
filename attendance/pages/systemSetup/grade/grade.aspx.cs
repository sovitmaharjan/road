using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.grade {
    public partial class grade : System.Web.UI.Page {

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

                pageNamePlace1.Text = "Add Grade";
                pageNamePlace2.Text = "Add Grade";
            } else {

                pageNamePlace1.Text = "Edit Grade";
                pageNamePlace2.Text = "Edit Grade";
                if (!IsPostBack) {

                    DataTable dtGrade = attendanceObject.grade(id);
                    gradeNameForm.Value = dtGrade.Rows[0]["GRADE_NAME"].ToString();
                    gradeTypeForm.Value = dtGrade.Rows[0]["GRADE_TYPE"].ToString();
                    if (Convert.ToInt32(dtGrade.Rows[0]["status"]) == 1) {

                        statusYesForm.Checked = true;
                    } else {

                        statusNoForm.Checked = true;
                    }
                }
            }
        }

        protected void saveClick(object sender, EventArgs e) {

            int id = Convert.ToInt32(Request.Params["b80bb7740288fda1f201890375a60c8f"]);
            string gradeName = gradeNameForm.Value;
            string gradeType = gradeTypeForm.Value;
            int status;
            if (statusYesForm.Checked) {

                status = 1;
            } else {

                status = 0;
            }
            attendanceObject.manageGrade(id, gradeName, gradeType, status);
            Response.Redirect("gradeList");
        }
    }
}