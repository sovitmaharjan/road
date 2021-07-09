using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.logHistory
{
    public partial class logHistoryList : System.Web.UI.Page
    {

        attendance attendanceObject = new attendance();
        static attendance staticAttendanceObject = new attendance();

        public string baseUrl
        {

            get
            {

                return attendanceObject.baseUrl();
            }
        }

        public string projectName
        {

            get
            {

                return attendanceObject.projectName();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            int empId = Convert.ToInt32(Request.Params["empId"]);
            string fromDate = Request.Params["fromDate"];
            string toDate = Request.Params["toDate"];
            DataTable dtLogHistoryList = attendanceObject.logHistoryList(empId, fromDate, toDate);
            string tableBodyRow = "";
            int i = 1;
            foreach (DataRow value in dtLogHistoryList.Rows)
            {

                tableBodyRow += "<tr>";
                tableBodyRow += "<td>" + i + "</td>";
                tableBodyRow += "<td>" + value["Emp_ID"] + "</td>";
                if (Convert.ToInt32(value["VerifyMode"]) == 15)
                {

                    tableBodyRow += "<td>Facial </td>";
                }
                else
                {

                    tableBodyRow += "<td>Finger </td>";
                }
                if (Convert.ToInt32(value["InOutMode"]) == 0)
                {

                    tableBodyRow += "<td>In </td>";
                }
                else
                {

                    tableBodyRow += "<td>Out </td>";
                }
                tableBodyRow += "<td>" + Convert.ToDateTime(value["LD"]).ToString("yyyy-MM-dd") + "</td>";
                tableBodyRow += "<td>" + value["LogTime"] + "</td>";
                tableBodyRow += "<td><div class='button-list'><a id='" + value["indx"] + "' data-index='" + value["indx"] + "' data-empid='" + value["Emp_ID"] + "' data-logdate='" + Convert.ToDateTime(value["LD"]).ToString("yyyy-MM-dd") + "' class='btn btn-warning waves-effect w-xs waves-light  btn-sm update'  data-toggle='modal' data-target='#custom-width-modal'><i class='mdi mdi-pencil'></i> <span>Update </span>  </a></div></td>";
                i++;
            }
            tableBody.Text = tableBodyRow;
        }

        [WebMethod]
        public static void modalUpdate(string data)
        {

            string dateTime = DateTime.Now.ToString();
            string[] splitObj = data.Split('|');
            string indexId = splitObj[0];
            int empId = Convert.ToInt32(splitObj[1]);
            string logDate = Convert.ToDateTime(splitObj[2]).ToString("yyyy-MM-dd");
            string date = Convert.ToDateTime(splitObj[3]).ToString("yyyy-MM-dd");
            DataTable dtGetAttendanceLog = staticAttendanceObject.getAttendanceLog(empId, date);
            if (dtGetAttendanceLog.Rows.Count > 1)
            {

                string inTime1 = dtGetAttendanceLog.Rows[0]["INTIME"].ToString();
                string outTime1 = dtGetAttendanceLog.Rows[0]["OUTTIME"].ToString();
                string dateOut2 = Convert.ToDateTime(dtGetAttendanceLog.Rows[1]["TDATE_OUT"]).ToString("yyyy-MM-dd");
                string inTime2 = dtGetAttendanceLog.Rows[1]["INTIME"].ToString();
                string inMode2 = dtGetAttendanceLog.Rows[1]["INMODE"].ToString();
                string inRemarks2 = dtGetAttendanceLog.Rows[1]["INREMARKS"].ToString();
                string outTime2 = dtGetAttendanceLog.Rows[1]["OUTTIME"].ToString();
                string outMode2 = dtGetAttendanceLog.Rows[1]["OUTMODE"].ToString();
                string outRemarks2 = dtGetAttendanceLog.Rows[1]["OUTREMARKS"].ToString();
                if (string.IsNullOrEmpty(outTime1) && string.IsNullOrEmpty(outTime2))
                {

                    staticAttendanceObject.updateLogHistory(indexId);
                    staticAttendanceObject.updateAttendanceLog(inTime2, inMode2, inRemarks2, empId, date, dateOut2);
                    staticAttendanceObject.deleteAttendanceLog(empId, date);
                }
                else if (string.IsNullOrEmpty(outTime1) && !string.IsNullOrEmpty(outTime2))
                {

                    string[] splitInTime1 = inTime1.Split(':');
                    string[] splitInTime2 = inTime2.Split(':');
                    if (splitInTime1[0] != splitInTime2[0])
                    {

                        string time = Convert.ToDateTime(inTime2).ToString("hh:mm:ss tt");
                        staticAttendanceObject.updateAttendanceLog(outTime2, outMode2, outRemarks2, empId, date, dateOut2);
                        staticAttendanceObject.deleteAttendanceLog(empId, date);
                        staticAttendanceObject.deleteDeviceAttendanceLog(time);
                    }
                }
            }
        }        
    }
}