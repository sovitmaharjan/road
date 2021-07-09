using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.exportToIDS
{
    public partial class exportToIDS : System.Web.UI.Page
    {
        attendance blu = new attendance();
        int branch_id, dept_id, emp_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDepartment();
                CmbEmployee.Enabled = false;
            }
        }


        public void loadDepartment()
        {
            DataTable dt = blu.getDepartment();
            CmbDepartment.DataSource = dt;
            CmbDepartment.DataTextField = "DEPT_NAME";
            CmbDepartment.DataValueField = "DEPT_ID";
            CmbDepartment.DataBind();
            CmbDepartment.Items.Insert(0, "Select Department");
        }

        public void loadEmployee()
        {
            DataTable dt = blu.getEmployees();
            CmbEmployee.DataSource = dt;
            CmbEmployee.DataTextField = "emp_fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");
        }



        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbEmployee.Enabled = true;
            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";

            if (CmbBranch.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Branch First  !!!!','warning')", true);
                loadDepartment();
                return;
            }
            else
            {
                txtEmpId.Text = " ";
                dept_id = Convert.ToInt32(CmbDepartment.SelectedValue);
                DataTable dt1 = blu.getDept_EmployeeList(dept_id, 1);
                CmbEmployee.DataSource = dt1;
                CmbEmployee.DataTextField = "emp_fullname";
                CmbEmployee.DataValueField = "EMP_ID";
                CmbEmployee.DataBind();
                CmbEmployee.Items.Insert(0, "Select Employee");
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
                Chkemp.Checked = false;
                CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");
            }
        }

        protected void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDepartment.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Select Department First !!!!','warning')", true);
                loadDepartment();
                return;
            }
            else
            {
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
                txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
            }
        }

        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAllInfo(emp_id);
            if (dt.Rows.Count > 0)
            {
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();

                CmbBranch.DataSource = dt;
                CmbBranch.DataTextField = "BRANCH_Name";
                CmbBranch.DataValueField = "BRANCH_ID";
                CmbBranch.DataBind();

                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();

                CmbEmployee.DataSource = dt;
                CmbEmployee.DataTextField = "emp_fullname";
                CmbEmployee.DataValueField = "EMP_ID";
                CmbEmployee.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Branch and Department Available with This Id !!!','warning')", true);
            }
            chkAllEmployees.Visible = false;
            Chkemp.Enabled = false;
        }

        protected void Chkemp_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkemp.Checked)
            {
                CmbEmployee.Enabled = false;
                CmbEmployee.Items.Clear();
                CmbBranch.Enabled = false;
                CmbBranch.Items.Clear();
                CmbDepartment.Enabled = false;
                CmbDepartment.Items.Clear();

                DataTable dt = blu.getWorkingEmployees();

                txtEmpId.Enabled = false;
                txtEmpId.Text = "";


            }
            else
            {
                CmbBranch.Enabled = true;
            }
        }

        protected void chkAllEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            DateTime Startdate = Convert.ToDateTime(TxtStartDate.Text);
            DateTime Enddate = Convert.ToDateTime(TxtEndDate.Text);

            DateTime datevalue = (Convert.ToDateTime(Enddate.ToString()));
            String mon1 = datevalue.Month.ToString();
            string year = datevalue.ToString("yy");
            int mth = Convert.ToInt32(datevalue.Month.ToString());
            string mon = string.Format("{0:00}", mth);

            int eid = 0;
            int flag = 0;
            if (Chkemp.Checked)
            {
                DataTable dt = blu.getWorkingEmployees();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    eid = int.Parse(dt.Rows[i]["EMP_ID"].ToString());
                    blu.ExportIDS(eid, Startdate, Enddate, flag);
                    flag = 1;
                }
                DataTable dt1 = blu.getExportData();
                MemoryStream ms = new MemoryStream();
                TextWriter tw = new StreamWriter(ms);
                string date = Convert.ToDateTime(dt1.Rows[0]["tdate"]).ToString("yyyy-MM-dd");
                string[] splitDate = date.Split('-');
                string yy = splitDate[0];
                string month = splitDate[1];
                foreach (DataRow value in dt1.Rows)
                {

                    string tdate = Convert.ToDateTime(value["tdate"]).ToString("yyyy-MM-dd");
                    string[] splitTdate = tdate.Split('-');
                    string finalTdate = splitTdate[0] + splitTdate[1] + splitTdate[2];
                    string status;
                    string time;
                    if (value["flag"].ToString() == "abs")
                    {
                        status = "ABS";
                        time = "-1.5";
                    }
                    else if (value["flag"].ToString() == "lwop")
                    {
                        status = "LWOP";
                        time = "0";
                    }
                    else if (value["flag"].ToString() == "half")
                    {
                        status = "WRK";
                        time = "0.5";
                    }
                    else
                    {
                        status = "WRK";
                        time = "1";
                    }


                    tw.WriteLine(value["Emp_id"] + "," + finalTdate + "," + status + "," + time);
                }
                tw.Flush();
                byte[] bytes = ms.ToArray();
                ms.Close();

                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=PYAT" + year + mon + ".dat");
                Response.BinaryWrite(bytes);
                Response.End();
            }
            else
            {
                string emp_dept = CmbDepartment.SelectedItem.Text;
                dept_id = int.Parse(CmbDepartment.SelectedValue);

                if (CmbDepartment.SelectedItem.Text == "Select Department")
                {
                    ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Plz Select Department !!!','warning')", true);
                    return;
                }
                string emp_name = CmbEmployee.SelectedItem.Text;
                eid = Convert.ToInt32(txtEmpId.Text);
                blu.ExportIDS(eid, Startdate, Enddate, flag);
                DataTable dt1 = blu.getExportData();
                MemoryStream ms = new MemoryStream();
                TextWriter tw = new StreamWriter(ms);
                string date = Convert.ToDateTime(dt1.Rows[0]["tdate"]).ToString("yyyy-MM-dd");
                string[] splitDate = date.Split('-');
                string yy = splitDate[0];
                string month = splitDate[1];
                foreach (DataRow value in dt1.Rows)
                {

                    string tdate = Convert.ToDateTime(value["tdate"]).ToString("yyyy-MM-dd");
                    string[] splitTdate = tdate.Split('-');
                    string finalTdate = splitTdate[0] + splitTdate[1] + splitTdate[2];
                    string status;
                    string time;

                    if (value["flag"].ToString() == "abs")
                    {
                        status = "ABS";
                        time = "-1.5";
                    }
                    else if (value["flag"].ToString() == "lwop")
                    {
                        status = "LWOP";
                        time = "0";
                    }
                    else if (value["flag"].ToString() == "half")
                    {
                        status = "WRK";
                        time = "0.5";
                    }
                    else
                    {
                        status = "WRK";
                        time = "1";
                    }

                    tw.WriteLine(value["Emp_id"] + "," + finalTdate + "," + status + "," + time);
                }
                tw.Flush();
                byte[] bytes = ms.ToArray();
                ms.Close();

                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=PYAT" + year + mon + ".dat");
                Response.BinaryWrite(bytes);
                Response.End();
            }
        }



        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExportToIDS");
        }
    }
}