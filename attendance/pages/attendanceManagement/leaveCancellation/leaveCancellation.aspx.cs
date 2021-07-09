using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace attendance.pages.attendanceManagement.leaveCancellation
{
    public partial class leaveCancellation : System.Web.UI.Page
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
            pageNamePlace1.Text = "Test";
            pageNamePlace2.Text = "Test";
            if (!IsPostBack)
            {
                DataTable dtDepartment = attendanceObject.queryFunction("select * from Tbl_Org_Dept where LEVEL = 1");
                department.DataSource = dtDepartment;
                department.DataTextField = "DEPT_NAME";
                department.DataValueField = "DEPT_ID";
                department.DataBind();
                department.Items.Insert(0, "Select Department");
                if (string.IsNullOrEmpty(Request.Params["month"]) == false)
                {
                    DataTable dtTableData = attendanceObject.queryFunction("exec proc_LeaveShow @empid=0, @year=" + Request.Params["year"] + ",@month=" + Request.Params["month"] + ", @date_type=0");
                    if (dtTableData.Rows.Count > 0)
                    {
                        string tableBodyRow = "";
                        int i = 1;
                        foreach (DataRow value in dtTableData.Rows)
                        {
                            tableBodyRow += "<tr>";
                            tableBodyRow += "<td><div class='checkbox controls'><input id='" + value["SNo"] + "' type='checkbox' value='" + value["SNo"] + "' class='input-mini checkboxes'><label for='" + value["SNo"] + "5'></label></div></td>";
                            tableBodyRow += "<td>" + value["EMP_ID"] + "</td>";
                            tableBodyRow += "<td>" + value["LEAVE_ID"] + "</td>";
                            tableBodyRow += "<td>" + value["Leave_Date"] + "</td>";
                            tableBodyRow += "<td>" + value["TAKEN"] + "</td>";
                            tableBodyRow += "<td>" + value["REMARKS"] + "</td>";
                            tableBodyRow += "<td>" + value["ApprovedBy"] + "</td>";
                            tableBodyRow += "</tr>";
                            i++;
                        }
                        tableBody.Text = tableBodyRow;
                    }
                }
            }
        }

        protected void loadClick(object sender, EventArgs e)
        {
            Response.Redirect(baseUrl + "/leaveCancellation?department=" + department.SelectedValue + "&year=" + year.Value + "&month=" + month.SelectedValue);
        }

        [WebMethod]
        public static bool deleteLeaveCancellation(string sNo)
        {
            staticAttendanceObject.queryFunction("delete from Tbl_Org_Leave_Log where SNo in (" + sNo + ")");
            return true;
        }
    }
}