using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.holiday.setup {
    public partial class holiday : System.Web.UI.Page {

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

                pageNamePlace1.Text = "Add Holiday";
                pageNamePlace2.Text = "Add Holiday";
            } else {

                pageNamePlace1.Text = "Edit Holiday";
                pageNamePlace2.Text = "Edit Holiday";
                if (!IsPostBack) {

                    DataTable dtHoliday = attendanceObject.holiday(id);
                    holidayEnglishDateForm.Value = Convert.ToDateTime(dtHoliday.Rows[0]["HOLIDAY_DATE"]).ToString("yyyy-MM-dd");
                    holidayNameForm.Value = dtHoliday.Rows[0]["HOLIDAY_NAME"].ToString();
                    if (Convert.ToInt32(dtHoliday.Rows[0]["holidayType"]) == 1) {

                        standardForm.Checked = true;
                    } else if (Convert.ToInt32(dtHoliday.Rows[0]["holidayType"]) == 2) {

                        specificForm.Checked = true;
                    } else {

                        unofficialForm.Checked = true;
                    }
                    if (Convert.ToInt32(dtHoliday.Rows[0]["Female_only"]) == 1) {

                        femaleOnlyForm.Checked = true;
                    }
                    holidayQuantityForm.Value = dtHoliday.Rows[0]["HOLIDAY_QTY"].ToString();
                    if (Convert.ToInt32(dtHoliday.Rows[0]["status"]) == 1) {

                        statusYesForm.Checked = true;
                    } else {

                        statusNoForm.Checked = true;
                    }
                }
            }
        }

        protected void saveClick(object sender, EventArgs e) {

            int id = Convert.ToInt32(Request.Params["b80bb7740288fda1f201890375a60c8f"]);
            string holidayEnglishDate = holidayEnglishDateForm.Value;
            string holidayName = holidayNameForm.Value;
            int holidayType;
            if (standardForm.Checked) {

                holidayType = 1;
            } else if (specificForm.Checked) {

                holidayType = 2;
            } else {

                holidayType = 0;
            }
            int femaleOnly;
            if (femaleOnlyForm.Checked) {

                femaleOnly = 1;
            } else {

                femaleOnly = 0;
            }
            int holidayQuantity = Convert.ToInt32(holidayQuantityForm.Value);
            int status;
            if (statusYesForm.Checked) {

                status = 1;
            } else {

                status = 0;
            }
            attendanceObject.manageHoliday(id, holidayEnglishDate, holidayName, holidayType, femaleOnly, holidayQuantity, status);
            Response.Redirect("holidayList");
        }
    }
}