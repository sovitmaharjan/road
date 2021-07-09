using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.roster.workHour {
    public partial class workHour : System.Web.UI.Page {

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

            pageNamePlace1.Text = "Add WorkHour";
            pageNamePlace2.Text = "Add WorkHour";
        }

        protected void saveClick(object sender, EventArgs e) {

            int id = Convert.ToInt32(Request.Params["b80bb7740288fda1f201890375a60c8f"]);
            string groupName = groupNameForm.Value;
            string inTime = inTimeForm.Value;
            string inTime2 = inTime2Form.Value;
            string outTime = outTimeForm.Value;
            string outTime2 = outTime2Form.Value;
            string hour = hourForm.Value;
            string minute = minuteForm.Value;
            string lunchTime = lunchTimeForm.Value;
            int nightShift;
            if (nightShiftYesForm.Checked) {

                nightShift = 1;
            } else {

                nightShift = 0;
            }
            int defaultForAllWeekend;
            if (defaultForAllWeekendYesForm.Checked) {

                defaultForAllWeekend = 1;
            } else {

                defaultForAllWeekend = 0;
            }
            int status;
            if (statusYesForm.Checked) {

                status = 1;
            } else {

                status = 0;
            }
            attendanceObject.manageWorkHour(id, groupName, inTime, inTime2, outTime, outTime2, hour, minute, lunchTime, nightShift, defaultForAllWeekend, status);
            Response.Redirect("workHourList");
        }
    }
}