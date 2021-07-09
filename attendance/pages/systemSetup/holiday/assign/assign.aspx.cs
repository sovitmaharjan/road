using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

namespace attendance.pages.systemSetup.holiday.assign {
    public partial class assign : System.Web.UI.Page {

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

            DataTable dtBranchList = attendanceObject.branch(0);
            string tableBodyRow = "";
            int i = 1;
            foreach (DataRow value in dtBranchList.Rows) {

                tableBodyRow += "<tr>";
                tableBodyRow += "<td><div class='checkbox'><input type='checkbox' id='" + value["BRANCH_ID"] + "' /><label for ='" + value["BRANCH_ID"] + "'></label></div></td>";
                tableBodyRow += "<td>" + value["BRANCH_NAME"] + "</td>";
                tableBodyRow += "<td><div class='button-list'><a id='" + value["BRANCH_ID"] + "' class='btn btn-warning w-xs waves-effect waves-light btn-xs detail'><i class='mdi mdi-pencil'></i> <span>Detail </span></a></div></td>";
                tableBodyRow += "</tr>";
                i++;
            }
            tableBody.Text = tableBodyRow;

            DataTable dtHolidayList = attendanceObject.holiday(0);

            holidayNameForm.DataSource = dtHolidayList;
            holidayNameForm.DataTextField = "HOLIDAY_NAME";
            holidayNameForm.DataValueField = "HOLIDAY_ID";
            holidayNameForm.DataBind();
            holidayNameForm.Items.Insert(0, new ListItem("Select Holiday", ""));
        }

        [WebMethod]
        public static string[] getEmployeeByBranchId(int id) {

            DataTable dtEmployeeList = staticAttendanceObject.employeeByBranchId(id);
            int count = dtEmployeeList.Rows.Count;
            string[] array = new string[count];
            int i = 0;
            foreach (DataRow value in dtEmployeeList.Rows) {

                array[i] = value["EMP_ID"] + "./." + value["EMP_FULLNAME"];
                i++;
            }
            return array;
        }

        [WebMethod]
        public static string[] getHolidayById(int id) {

            DataTable dtHoliday = staticAttendanceObject.holiday(id);
            int count = dtHoliday.Rows.Count;
            string[] array = new string[count];
            int i = 0;
            foreach (DataRow value in dtHoliday.Rows) {

                array[i] = value["HOLIDAY_ID"] + "./." + value["HOLIDAY_NAME"] + "./." + Convert.ToDateTime(value["HOLIDAY_DATE"]).ToString("yyyy-MM-dd") + "./." + value["HOLIDAY_QTY"] + "./." + value["holidayType"] + "./." + value["Female_Only"];
                i++;
            }
            return array;
        }
    }
}