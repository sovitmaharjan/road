using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.grade {
    public partial class gradeList : System.Web.UI.Page {

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

            DataTable dtBranchList = attendanceObject.grade(0);
            string tableBodyRow = "";
            int i = 1;
            foreach (DataRow value in dtBranchList.Rows) {

                tableBodyRow += "<tr>";
                tableBodyRow += "<td>" + i + "</td>";
                tableBodyRow += "<td>" + value["GRADE_NAME"] + "</td>";
                tableBodyRow += "<td>" + value["GRADE_TYPE"] + "</td>";
                if (Convert.ToInt32(value["status"]) == 0) {

                    tableBodyRow += "<td>Inactive </td>";
                } else {

                    tableBodyRow += "<td>Active </td>";
                }
                tableBodyRow += "<td><div class='button-list'><a href='grade?b80bb7740288fda1f201890375a60c8f=" + value["GRADE_ID"] + "' class='btn btn-warning w-xs waves-effect waves-light btn-xs'><i class='mdi mdi-pencil'></i> <span>Edit </span></a></div></td>";
                tableBodyRow += "</tr>";
                i++;
            }
            tableBody.Text = tableBodyRow;
        }
    }
}