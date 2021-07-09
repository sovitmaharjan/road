using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.logHistory
{
    public partial class logHistory : System.Web.UI.Page
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

            pageNamePlace1.Text = "Log History";
            pageNamePlace2.Text = "Log History";

            if (!IsPostBack)
            {
                DataTable dtEmployeeList = attendanceObject.employeeList(0);
                empForm.DataSource = dtEmployeeList;
                empForm.DataTextField = "EMP_FULLNAME";
                empForm.DataValueField = "EMP_ID";
                empForm.DataBind();
                empForm.Items.Insert(0, new ListItem("Select Employee", ""));
            }
        }

        protected void loadClick(object sender, EventArgs e)
        {

            string fromDate = fromEnglishDateForm.Value;
            string toDate = toEnglishDateForm.Value;
            string empId = empForm.SelectedValue;
            Response.Redirect("logHistoryList?empId=" + empId + "&fromDate=" + fromDate + "&toDate=" + toDate);
        }
    }
}