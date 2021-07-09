using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.logActivities
{
    public partial class logActivitiesView : System.Web.UI.Page
    {

        attendance blu = new attendance();
        int emp_id;
        DateTime Startdate, Enddate;
        DataTable dt;
        string query, event_type;


        public string baseUrl
        {
            get
            {
                return blu.baseUrl();
            }
        }

        public string projectName
        {
            get
            {
                return blu.projectName();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string login_id = Server.UrlDecode(Request.QueryString["login_id"].ToString());
                Startdate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["Startdate"].ToString()));
                Enddate = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["Enddate"].ToString()));
                event_type = Server.UrlDecode(Request.QueryString["event_type"].ToString());



                lblStartDate.Text = Startdate.ToString("yyyy-MM-dd");
                lblEndDate.Text = Enddate.ToString("yyyy-MM-dd");

                if (event_type == "1")
                {
                    logItemLiteral.Text = "Leave Application";
                }
                else if (event_type == "2")
                {
                    logItemLiteral.Text = "Leave Cancellation";
                }
                else if (event_type == "3")
                {
                    logItemLiteral.Text = "Force Attendance";
                }
                else if (event_type == "4")
                {
                    logItemLiteral.Text = "Over Time Management";
                }
                else if (event_type == "5")
                {
                    logItemLiteral.Text = "Employee Mangement";
                }
                else if (event_type == "6")
                {
                    logItemLiteral.Text = "Roster Management";
                }
                else
                {
                    logItemLiteral.Text = "All Items";
                }

                if (login_id == "0")
                {
                    logNameLiteral.Text = "All";
                }
                else
                {
                    dt = blu.employeeList(int.Parse(login_id));
                    string logName = dt.Rows[0]["emp_fullname"].ToString();
                    logNameLiteral.Text = logName;
                }

                if (login_id == "0" && event_type == "0")
                {
                    query = "SELECT log_time, log_date, remarks, dbo.fn_GetNAMEBYID(EMP_ID) as Employee, event_info, event_date,(CASE WHEN event_type = '1' THEN 'Leave Application' WHEN event_type = '2' THEN 'Leave Cancellation' WHEN event_type = '3' THEN 'Force Attendance' WHEN event_type = '4' THEN 'OverTime Management' WHEN event_type = '5' THEN 'Employee Management' ELSE  'Roster Management'END) as event_type,dbo.fn_GetNAMEBYID(login_id) as login_name FROM Tbl_System_Log WHERE log_date BETWEEN '" + @Startdate + "' and '" + @Enddate + "'";
                }
                else if (login_id == "0" && event_type != "0")
                {
                    query = "SELECT log_time, log_date, remarks, dbo.fn_GetNAMEBYID(EMP_ID) as Employee, event_info, event_date,(CASE WHEN event_type = '1' THEN 'Leave Application' WHEN event_type = '2' THEN 'Leave Cancellation' WHEN event_type = '3' THEN 'Force Attendance' WHEN event_type = '4' THEN 'OverTime Management' WHEN event_type = '5' THEN 'Employee Management' ELSE  'Roster Management'END) as event_type,dbo.fn_GetNAMEBYID(login_id) as login_name FROM Tbl_System_Log WHERE event_type = " + @event_type + " and log_date BETWEEN '" + @Startdate + "' and '" + @Enddate + "'";
                }
                else
                {
                    emp_id = int.Parse(login_id);
                    query = "SELECT log_time, log_date, remarks, dbo.fn_GetNAMEBYID(EMP_ID) as Employee, event_info, event_date,(CASE WHEN event_type = '1' THEN 'Leave Application' WHEN event_type = '2' THEN 'Leave Cancellation' WHEN event_type = '3' THEN 'Force Attendance' WHEN event_type = '4' THEN 'OverTime Management' WHEN event_type = '5' THEN 'Employee Management' ELSE  'Roster Management'END) as event_type,dbo.fn_GetNAMEBYID(login_id) as login_name FROM Tbl_System_Log WHERE event_type = " + @event_type + " and Login_ID =" + @login_id + "and log_date BETWEEN '" + @Startdate + "' and '" + @Enddate + "'";
                }

                dt = blu.queryFunction(query);


                string tableBodyRow = "";
                int i = 1;
                foreach (DataRow value in dt.Rows)
                {
                    tableBodyRow += "<tr>";
                    tableBodyRow += "<td>" + i + "</td>";
                    tableBodyRow += "<td>" + Convert.ToDateTime(value["log_date"]).ToString("yyyy-MM-dd") + "</td>";
                    tableBodyRow += "<td>" + value["log_time"] + "</td>";
                    tableBodyRow += "<td>" + value["remarks"] + "</td>";
                    tableBodyRow += "<td>" + value["Employee"] + "</td>";
                    tableBodyRow += "<td>" + value["event_info"] + "</td>";
                    tableBodyRow += "<td>" + Convert.ToDateTime(value["event_date"]).ToString("yyyy-MM-dd") + "</td>";
                    tableBodyRow += "<td>" + value["event_type"] + "</td>";
                    tableBodyRow += "<td>" + value["login_name"] + "</td>";
                    i++;
                }
                tableBody.Text = tableBodyRow;
            }
        }
    }
}