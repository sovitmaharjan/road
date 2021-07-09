using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.holiday.setup {
    public partial class holidayList : System.Web.UI.Page {

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

            DataTable dtHolidayList = attendanceObject.holiday(0);
            string tableBodyRow = "";
            int i = 1;
            foreach (DataRow value in dtHolidayList.Rows) {

                tableBodyRow += "<tr>";
                tableBodyRow += "<td>" + i + "</td>";
                tableBodyRow += "<td>" + value["HOLIDAY_NAME"] + "</td>";
                tableBodyRow += "<td>" + Convert.ToDateTime(value["HOLIDAY_DATE"]).ToString("yyyy-MM-dd") + "</td>";
                tableBodyRow += "<td>" + value["HOLIDAY_QTY"] + "</td>";
                tableBodyRow += "<td>" + value["holidayType"] + "</td>";
                if (Convert.ToInt32(value["Female_Only"]) == 0) {

                    tableBodyRow += "<td>No </td>";
                } else {

                    tableBodyRow += "<td>Yes </td>";
                }
                if (Convert.ToInt32(value["status"]) == 0) {

                    tableBodyRow += "<td>Inactive </td>";
                } else {

                    tableBodyRow += "<td>Active </td>";
                }
                tableBodyRow += "<td><div class='button-list'><a href='holiday?b80bb7740288fda1f201890375a60c8f=" + value["HOLIDAY_ID"] + "' class='btn btn-warning w-xs waves-effect waves-light btn-xs'><i class='mdi mdi-pencil'></i> <span>Edit </span></a></div></td>";
                tableBodyRow += "</tr>";
                i++;
            }
            tableBody.Text = tableBodyRow;
        }
    }
}