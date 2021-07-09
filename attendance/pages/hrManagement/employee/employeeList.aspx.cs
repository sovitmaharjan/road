using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.hrManagement.employee
{
    public partial class employeeList : System.Web.UI.Page
    {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable employeeList = blu.getAllEmployeesList();
            string tableRow = "";
            int i = 1;
            foreach (DataRow value in employeeList.Rows)
            {

                tableRow += "<tr>";
                tableRow += "<td>" + i + "</td>";
                tableRow += "<td>" + value["emp_Fullname"] + " " + "(" + value["EMP_ID"] + ")" + "</td>";
                tableRow += "<td>" + value["DEG_NAME"] + "</td>";
                tableRow += "<td>" + value["GRADE_NAME"] + "</td>";
                tableRow += "<td>" + value["DEPT_NAME"] + "</td>";
                tableRow += "<td>" + value["BRANCH_NAME"] + "</td>";
                tableRow += "<td>" + value["STATUS_NAME"] + "</td>";
                string emp_id = value["EMP_ID"].ToString();
                var encrytptedId = HttpUtility.UrlEncode(blu.EncryptString(emp_id));
                tableRow += "<td><div class='button-list'><a href='viewDetail?EMP_ID=" + encrytptedId + "' onserverclick='' runat='server' class='btn btn-info waves-effect w-md waves-light' >View Details </a></div></td>";
                tableRow += "</tr>";
                i++;
            }
            tableBody.Text = tableRow;
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("addEmployee");
        }
    }
}