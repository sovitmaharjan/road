using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace attendance.pages.outstation {
    public partial class outstation : System.Web.UI.Page {
        static attendance attendanceObject = new attendance();

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
            pageNamePlace1.Text = "Branch Setup";
            pageNamePlace2.Text = "Branch Setup";
            if (!IsPostBack)
            {
                DataTable dtEmployeeList = attendanceObject.employeeList(0);
                employee.DataSource = dtEmployeeList;
                employee.DataTextField = "EMP_FULLNAME";
                employee.DataValueField = "EMP_ID";
                employee.DataBind();
                employee.Items.Insert(0, new ListItem("Select Employee", ""));

                DataTable dtTableData = attendanceObject.queryFunction("select * from Tbl_Emp_Outstation join view_Emp_Info on Tbl_Emp_Outstation.EMP_ID = view_Emp_Info.EMP_ID");
                string tableBodyRow = "";
                foreach (DataRow value in dtTableData.Rows)
                {
                    tableBodyRow += "<tr>";
                    tableBodyRow += "<td>" + value["EMP_ID"] + "</td>";
                    tableBodyRow += "<td>" + value["emp_Fullname"] + "</td>";
                    tableBodyRow += "<td>" + value["DEPT_NAME"] + "</td>";
                    tableBodyRow += "<td>" + value["DEG_NAME"] + "</td>";
                    tableBodyRow += "<td>" + value["STATION"] + "</td>";
                    tableBodyRow += "<td>" + Convert.ToDateTime(value["SDATE"]).ToString("yyyy-MM-dd") + "</td>";
                    tableBodyRow += "<td>" + Convert.ToDateTime(value["EDATE"]).ToString("yyyy-MM-dd") + "</td>";
                    if (Convert.ToInt32(value["status"]) == 0)
                    {
                        tableBodyRow += "<td>Inactive</td>";
                    }
                    else
                    {
                        tableBodyRow += "<td>Active</td>";
                    }
                    tableBodyRow += "</tr>";
                }
                tableBody.Text = tableBodyRow;
            }
        }

        protected void saveClick(object sender, EventArgs e)
        {
            string table = "Tbl_Emp_Outstation";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("EMP_ID", employee.SelectedValue);
            data.Add("TDATE", date.Value);
            data.Add("STATION", location.Value);
            data.Add("SDATE", startDate.Value);
            data.Add("EDATE", endDate.Value);
            data.Add("DAYS", days.Value);
            data.Add("PURPOSE", description.Value);
            if (statusYes.Checked)
            {
                data.Add("status", "1");
            }
            if (statusNo.Checked)
            {
                data.Add("status", "0");
            }
            if (string.IsNullOrEmpty(id.Value))
            {
                attendanceObject.insertTableData(table, data);
            }
            else
            {
                //dictionary<string, object> condition = new dictionary<string, object>();
                //condition.add("branch_id", id.value);
                //attendanceobject.updatetabledata(table, data, condition);
            }
            Response.Redirect(baseUrl + "/outstationList");
        }

        [WebMethod]
        public static List<Dictionary<string, object>> getData(string id)
        {
            List<string> field = new List<string>();
            field.Add("*");
            string table = "Tbl_Comp_Branch";
            Dictionary<string, object> condition = new Dictionary<string, object>();
            condition.Add("BRANCH_ID", "1");
            DataTable dtTableDataById = attendanceObject.getTableData(field, table, condition);

            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (DataRow dataTableRow in dtTableDataById.Rows)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (DataColumn tableColumn in dtTableDataById.Columns)
                {
                    dic.Add(tableColumn.ColumnName, dataTableRow[tableColumn]);
                }
                data.Add(dic);
            }
            return data;
        }
    }
}