using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.leave {
    public partial class leaveList : System.Web.UI.Page {

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

            DataTable dtLeaveList = attendanceObject.leave(0);
            string tableBodyRow = "";
            int i = 1;
            foreach (DataRow value in dtLeaveList.Rows) {

                tableBodyRow += "<tr>";
                tableBodyRow += "<td>" + i + "</td>";
                tableBodyRow += "<td>" + value["LEAVE_NAME"] + "</td>";
                if (value["LEAVE_TYPE"].ToString() == "0") {

                    tableBodyRow += "<td>Expire Yearly </td>";
                } else if (value["LEAVE_TYPE"].ToString() == "1") {

                    tableBodyRow += "<td>Accumulative </td>";
                } else if (value["LEAVE_TYPE"].ToString() == "2") {

                    tableBodyRow += "<td>Service Period </td>";
                } else {

                    tableBodyRow += "<td>N/A </td>";
                }
                tableBodyRow += "<td>" + value["LEAVE_DAYS"] + "</td>";
                tableBodyRow += "<td>" + value["mustexhaustotherleaves"] + "</td>";
                if (value["ISCashable"].ToString() == "1") {
                    
                    tableBodyRow += "<td>Yes </td>";
                } else {

                    tableBodyRow += "<td>No </td>";
                }
                tableBodyRow += "<td>" + value["MAX_DAYS_AT_A_TIME"] + "</td>";
                tableBodyRow += "<td>" + value["service_period"] + "</td>";
                if (value["others"].ToString() == "1") {

                    tableBodyRow += "<td>Monthly Earning </td>";
                } else {

                    tableBodyRow += "<td>Exhaust all Leaves </td>";
                }
                if (value["status"].ToString() == "1") {

                    tableBodyRow += "<td>Active </td>";
                } else {

                    tableBodyRow += "<td>Inactive </td>";
                }
                tableBodyRow += "<td><div class='button-list'><a href='leave?b80bb7740288fda1f201890375a60c8f=" + value["LEAVE_ID"] + "' class='btn btn-warning w-xs waves-effect waves-light btn-xs'><i class='mdi mdi-pencil'></i> <span>Edit </span></a></div></td>";
                tableBodyRow += "</tr>";
                i++;
            }
            tableBody.Text = tableBodyRow;
        }
    }
}