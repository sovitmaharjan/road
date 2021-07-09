using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.employeeInfo.employeeDetailInfo
{
    public partial class ViewEmployeeDetailInfo : System.Web.UI.Page
    {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e)
        {
            int emp_id = Convert.ToInt32(Request.Params["emp_id"]);
            DataTable dt = blu.getEmployeeDataById(emp_id);
            lblid.Text = dt.Rows[0]["EMP_ID"].ToString();
            lblname.Text = dt.Rows[0]["emp_Fullname"].ToString();
            lblgender.Text = dt.Rows[0]["GENDER"].ToString();
            if (dt.Rows[0]["EMP_PEMAIL"].ToString() == "")
            {
                lblemail.Text = "N/A";
            }
            else
            {
                lblemail.Text = dt.Rows[0]["EMP_PEMAIL"].ToString();
            }
            DateTime result = Convert.ToDateTime(dt.Rows[0]["EMP_DOB"].ToString());
            lbldob.Text = result.ToString("yyyy-MM-dd");
            DateTime result1 = Convert.ToDateTime(dt.Rows[0]["EMP_JOINDATE"].ToString());
            lbldate.Text = result1.ToString("yyyy-MM-dd");
            lblusrid.Text = dt.Rows[0]["login_id"].ToString();
            lblDeg.Text = dt.Rows[0]["DEG_NAME"].ToString();
            lblType.Text = dt.Rows[0]["MODE_NAME"].ToString();
            lblStatus.Text = dt.Rows[0]["STATUS_NAME"].ToString();
            lbldept.Text = dt.Rows[0]["DEPT_NAME"].ToString();
            lblbranch.Text = dt.Rows[0]["BRANCH_NAME"].ToString();
            lblUsertype.Text = dt.Rows[0]["TypeName"].ToString();
            lblgrade.Text = dt.Rows[0]["GRADE_NAME"].ToString();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeDetailInfo");
        }
    }
}