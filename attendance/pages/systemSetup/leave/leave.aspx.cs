using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.leave {
    public partial class leave : System.Web.UI.Page {
        
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

                pageNamePlace1.Text = "Add Leave";
                pageNamePlace2.Text = "Add Leave";
            } else {

                pageNamePlace1.Text = "Edit Leave";
                pageNamePlace2.Text = "Edit Leave";
                if (!IsPostBack) {

                    DataTable dtLeave = attendanceObject.leave(id);
                    leaveNameForm.Value = dtLeave.Rows[0]["LEAVE_NAME"].ToString();
                    if (Convert.ToInt32(dtLeave.Rows[0]["LEAVE_TYPE"]) == 1) {

                        accumulativeForm.Checked = true;
                    }
                    if (Convert.ToInt32(dtLeave.Rows[0]["LEAVE_TYPE"]) == 2) {

                        servicePeriodForm.Checked = true;
                    }
                    if (Convert.ToInt32(dtLeave.Rows[0]["LEAVE_TYPE"]) == 0) {

                        expireYearlyForm.Checked = true;
                    }
                    if (Convert.ToInt32(dtLeave.Rows[0]["ISCashable"]) == 1) {

                        cashableYesForm.Checked = true;
                    }
                    daysAnuallyForm.Value = dtLeave.Rows[0]["LEAVE_DAYS"].ToString();
                    maxDaysAtATimeForm.Value = dtLeave.Rows[0]["MAX_DAYS_AT_A_TIME"].ToString();
                    maxAccumulationDaysForm.Value = dtLeave.Rows[0]["LEAVE_MAX"].ToString();

                    entireServicePeriodForm.Value = dtLeave.Rows[0]["service_period"].ToString();

                    if (Convert.ToInt32(dtLeave.Rows[0]["ISPAIDLEAVE"]) == 1) {

                        monthlyEarningForm.Checked = true;
                    }
                    if (Convert.ToInt32(dtLeave.Rows[0]["mustexhaustotherleaves"]) == 1) {

                        mustExhaustAllLeavesForm.Checked = true;
                    }

                    if (Convert.ToInt32(dtLeave.Rows[0]["status"]) == 1) {

                        statusYesForm.Checked = true;
                    } else {

                        statusNoForm.Checked = true;
                    }
                }
            }
        }

        protected void saveClick(object sender, EventArgs e) {

            int id = Convert.ToInt32(Request.Params["b80bb7740288fda1f201890375a60c8f"]);
            string leaveName = leaveNameForm.Value;
            
            int cashable;
            if (cashableYesForm.Checked) {

                cashable = 1;
            } else {

                cashable = 0;
            }
            
            int daysAnually = Convert.ToInt32(daysAnuallyForm.Value);
            int maxDaysAtATime = Convert.ToInt32(maxDaysAtATimeForm.Value);
            
            int leaveType;
            int maxAccumulationDays;
            if (accumulativeForm.Checked) {

                maxAccumulationDays = Convert.ToInt32(maxAccumulationDaysForm.Value);
                leaveType = 1;
            } else if (expireYearlyForm.Checked) {

                maxAccumulationDays = 0;
                leaveType = 0;
            }else{

                maxAccumulationDays = 0;
                leaveType = 2;
            }

            int entireServicePeriod = Convert.ToInt32(entireServicePeriodForm.Value);
            
            int monthlyEarning;
            int mustExhaustAllLeaves;
            if (monthlyEarningForm.Checked) {

                monthlyEarning = 1;
            } else {

                monthlyEarning = 0;
            }
            if (mustExhaustAllLeavesForm.Checked) {

                mustExhaustAllLeaves = 1;
            } else {

                mustExhaustAllLeaves = 0;
            }

            int status;
            if (statusYesForm.Checked) {

                status = 1;
            } else {

                status = 0;
            }

            attendanceObject.manageLeave(leaveName, leaveType, daysAnually, maxAccumulationDays, monthlyEarning, maxDaysAtATime, cashable, mustExhaustAllLeaves, id, status);
            Response.Redirect("leaveList");
        }
    }
}