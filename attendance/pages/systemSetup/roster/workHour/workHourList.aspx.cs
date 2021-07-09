using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.roster.workHour {
    public partial class workHourList : System.Web.UI.Page {

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

            DataTable dtWorkHourList = attendanceObject.workHourList(0);
            string tableBodyRow = "";
            int i = 1;
            foreach (DataRow value in dtWorkHourList.Rows) {

                tableBodyRow += "<tr>";
                tableBodyRow += "<td>" + i + "</td>";
                tableBodyRow += "<td>" + value["Group_Name"] + "</td>";
                tableBodyRow += "<td>" + value["IN_START"] + "</td>";
                tableBodyRow += "<td>" + value["IN_END"] + "</td>";
                tableBodyRow += "<td>" + value["WORK_HOUR"] + "</td>";
                tableBodyRow += "<td>" + value["LUNCHTIME"] + "</td>";
                tableBodyRow += "<td>" + value["OUT_START"] + "</td>";
                tableBodyRow += "<td>" + value["OUT_END"] + "</td>";
                //if (value["IS_DEFAULTSHIFT"] == null) {

                //    if (Convert.ToInt32(value["IS_DEFAULTSHIFT"]) == 1) {

                //        tableBodyRow += "<td>Default </td>";
                //    } else {

                //        tableBodyRow += "<td> </td>";
                //    }
                //} else {

                //    tableBodyRow += "<td> </td>";
                //}
                if (Convert.ToInt32(value["IS_NIGHTSHIFT"]) == 1) {

                    tableBodyRow += "<td>Night </td>";
                } else {

                    tableBodyRow += "<td>Day </td>";
                }
                if (Convert.ToInt32(value["status"]) == 1) {

                    tableBodyRow += "<td><div class='button-list'><a href='workHourStatus?b80bb7740288fda1f201890375a60c8f=" + value["WORK_ID"] + "' class='btn btn-success w-xs waves-effect waves-light btn-xs'><i class='mdi mdi-pencil'></i> <span>Active </span></a></div> </td>";
                } else {

                    tableBodyRow += "<td><div class='button-list'><a href='workHourStatus?b80bb7740288fda1f201890375a60c8f=" + value["WORK_ID"] + "' class='btn btn-warning w-xs waves-effect waves-light btn-xs'><i class='mdi mdi-pencil'></i> <span>Inactive </span></a></div> </td>";
                }
                tableBodyRow += "<td><div class='button-list'><a href='workHourDelete?b80bb7740288fda1f201890375a60c8f=" + value["WORK_ID"] + "' class='btn btn-danger w-xs waves-effect waves-light btn-xs'><i class='mdi mdi-delete'></i> <span>Delete </span></a></div> </td>";
                i++;
            }
            tableBody.Text = tableBodyRow;
        }
    }
}