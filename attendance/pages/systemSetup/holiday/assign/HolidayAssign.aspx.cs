using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.holiday.assign {
    public partial class HolidayAssign : System.Web.UI.Page {

        attendance blu = new attendance();
        int flag = 0;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                chkFemale.Attributes["onclick"] = "return false";
                DataTable dt = blu.getDepartmentList(1);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                loadHoliday();
                if (chkFemale.Checked) {
                    flag = 1;
                } else {
                    flag = 0;
                }
                //lblmsg.Visible = false;
                BtnSave.Visible = false;
                BtnCancel.Visible = false;
            }
        }
        public void loadHoliday() {
            CmbHolidayName.Enabled = true;
            DataTable dt = blu.getHolidayList();
            CmbHolidayName.DataSource = dt;
            CmbHolidayName.DataBind();
            CmbHolidayName.DataTextField = "HOLIDAY_NAME";
            CmbHolidayName.DataValueField = "HOLIDAY_ID";
            CmbHolidayName.DataBind();
            CmbHolidayName.Items.Insert(0, "Select Holiday");
            CmbHolidayName.Items[0].Attributes.Add("disabled", "disabled");

        }

        int holidayid;
        protected void CmbHolidayName_SelectedIndexChanged(object sender, EventArgs e) {
            CmbHolidayName.Items[0].Attributes.Add("disabled", "disabled");
            holidayid = Convert.ToInt32(CmbHolidayName.SelectedValue);
            string Holidayid = CmbHolidayName.SelectedItem.Text;
            DataTable dt = blu.GetAllHoliday(holidayid);

            DateTime result = Convert.ToDateTime(dt.Rows[0]["HOLIDAY_DATE"].ToString());
            txtStartDate.Text = result.ToShortDateString();

            txtDays.Text = dt.Rows[0]["HOLIDAY_QTY"].ToString();
            txtHolidayType.Text = dt.Rows[0]["holidayType"].ToString();
            if (txtHolidayType.Text == "0") {
                txtHolidayType.Text = "Unofficial";
            } else if (txtHolidayType.Text == "1") {
                txtHolidayType.Text = "Standard";
            } else if (txtHolidayType.Text == "2") {
                txtHolidayType.Text = "Specific";
            }

            lblFem.Text = dt.Rows[0]["Female_Only"].ToString();
            if (lblFem.Text == "1") {
                chkFemale.Checked = true;
            } else {
                chkFemale.Checked = false;
            }
            txtDays.Enabled = false;
            txtHolidayType.Enabled = false;
            txtStartDate.Enabled = false;
        }

        DataTable dt1;
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) {
            Label1.Text = GridView1.SelectedRow.Cells[1].Text;
            Label2.Text = GridView1.SelectedRow.Cells[2].Text;
            if (chkFemale.Checked) {
                flag = 1;

            } else {
                flag = 0;

            }
            dt1 = blu.getEmployeeIdByGender(int.Parse(Label1.Text), flag);
            grvDetails.DataSource = dt1;
            grvDetails.DataBind();
            //foreach (GridViewRow gvRow in grvDetails.Rows)
            //{
            //    CheckBox chk2 = (CheckBox)gvRow.FindControl("ChkBox2");
            //    chk2.Checked = true;
            //}
            //lblmsg.Visible = true;
            grvDetails.Visible = true;
            BtnSave.Visible = true;
            BtnCancel.Visible = true;
        }
        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e) {
            e.Row.Cells[1].Visible = false;
        }
        string remark = "";
        int chkflag;
        string Flag = "";
        protected void BtnSave_Click(object sender, EventArgs e) {
            string oldholiday = CmbHolidayName.SelectedItem.Text;
            string holidayname = CmbHolidayName.SelectedItem.Text;
            DateTime holidaydate = Convert.ToDateTime(txtStartDate.Text);
            int branchid = int.Parse(Label1.Text);
            int holidayid = int.Parse(CmbHolidayName.SelectedValue);
            string holidaytype = txtHolidayType.Text;
            if (chkFemale.Checked == true) {
                Flag = "F";
            } else {

            }
            foreach (GridViewRow row in grvDetails.Rows) {
                if (row.RowType == DataControlRowType.DataRow) {
                    CheckBox chkRow = (row.Cells[0].FindControl("chk2") as CheckBox);
                    if (chkRow.Checked) {
                        string empid = (row.Cells[1].Text);
                        int id = int.Parse(empid);
                        string empname = (row.Cells[2].Text);
                        int i = blu.HolidayAssign(Flag, oldholiday, holidayname, holidaydate, holidaytype, remark, branchid, chkflag, holidayid, id);
                    }
                }
            }
            ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Holiday Assign Saved Successfully')", true);
            loadHoliday();
            CmbHolidayName.SelectedItem.Text = "";
            txtHolidayType.Text = "";
            txtDays.Text = "";
            txtHolidayType.Text = "";
            grvDetails.Visible = false;
            //lblmsg.Visible = false;
            BtnSave.Visible = false;
            BtnCancel.Visible = false;
        }
        protected void BtnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("holidayAssign");
        }


    }
}