using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.supervisor.Report.QuickAttendance
{
    public partial class quickAttendance : System.Web.UI.Page
    {
        attendance blu = new attendance();
        static attendance blustatic = new attendance();
        int branch_id, dept_id, emp_id;
        int Aflag;
        string nepStartdate, nepEnddate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadBranch();
                CmbEmployee.Enabled = false;

                Panel3.Visible = false;
                Panel4.Visible = false;
                BtnExport.Visible = false;
                Panel5.Visible = false;

                CmbBranch.Items[0].Attributes["disabled"] = "disabled";
            }
        }
        public void loadBranch()
        {
            DataTable dt = blu.getBranchList();
            if (dt.Rows.Count == 1)
            {
                string branch_id = dt.Rows[0]["BRANCH_ID"].ToString();
                CmbBranch.DataSource = dt;
                CmbBranch.DataTextField = "BRANCH_NAME";
                CmbBranch.DataValueField = "BRANCH_ID";
                CmbBranch.SelectedValue = branch_id;
                CmbBranch.DataBind();
                CmbBranch.Items.Insert(0, "Select Branch");
                loadDepartment();
            }
            else
            {
                CmbBranch.DataSource = dt;
                CmbBranch.DataTextField = "BRANCH_Name";
                CmbBranch.DataValueField = "BRANCH_ID";
                CmbBranch.DataBind();
                CmbBranch.Items.Insert(0, "Select Branch");
                CmbDepartment.Enabled = false;
            }
        }
        protected void CmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDepartment.Enabled = true;
            CmbEmployee.Enabled = false;
            CmbBranch.Items[0].Attributes["disabled"] = "disabled";

            branch_id = Convert.ToInt32(CmbBranch.SelectedValue);
            DataTable dt = blu.getBranch_DepartmentList(branch_id);
            if (dt.Rows.Count > 0)
            {
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");
                CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");

                CmbEmployee.Items.Clear();
                txtEmpId.Text = " ";
                txtEmpId.Enabled = true;
            }
            else
            {
                CmbDepartment.Items.Clear();
                CmbEmployee.Items.Clear();
                txtEmpId.Text = " ";
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Department Available !!!','warning')", true);
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
            CmbBranch.Items[0].Attributes["disabled"] = "disabled";
            CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
            txtEmpId.Text = " ";
            dept_id = Convert.ToInt32(CmbDepartment.SelectedValue);
            DataTable dt1 = blu.getDept_EmployeeList(dept_id, 1);
            CmbEmployee.DataSource = dt1;
            CmbEmployee.DataTextField = "emp_fullname";
            CmbEmployee.DataValueField = "EMP_ID";
            CmbEmployee.DataBind();
            CmbEmployee.Items.Insert(0, "Select Employee");
            CmbEmployee.Items[0].Attributes["disabled"] = "disabled";

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
                CmbBranch.Items[0].Attributes["disabled"] = "disabled";
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
                txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
            }
        }
        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            loadDepartment();
            CmbDepartment.Enabled = true;
            loadEmployee();
            CmbEmployee.Enabled = true;
            emp_id = int.Parse(txtEmpId.Text);
            DataTable dt = blu.getAll_Info(emp_id);
            if (dt.Rows.Count > 0)
            {
                txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                CmbBranch.SelectedValue = dt.Rows[0]["BRANCH_ID"].ToString();
                CmbBranch.Items[0].Attributes["disabled"] = "disabled";
                CmbDepartment.SelectedValue = dt.Rows[0]["DEPT_ID"].ToString();
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
                CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID !!!!','warning')", true);
                CmbDepartment.Enabled = false;
                CmbEmployee.Enabled = false;
            }
        }
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
            CmbBranch.Items[0].Attributes["disabled"] = "disabled";
            CmbBranch.Items[0].Attributes["disabled"] = "disabled";
            CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
            int eid = 0; DateTime sdate, edate;

            if (TxtStartDate.Text == "" || TxtEndDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Invalid Date. !!!','warning')", true);
                return;
            }
            if (CmbDepartment.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Select Department First !!!!','warning')", true);
                return;
            }
            if (CmbEmployee.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Select Employee !!!!','warning')", true);
                return;
            }
            sdate = Convert.ToDateTime(TxtStartDate.Text);
            edate = Convert.ToDateTime(TxtEndDate.Text);
            nepStartdate = TxtNepaliDate.Text;
            nepEnddate = nepaliDate2.Text;
            string emp_dept = CmbDepartment.SelectedItem.Text;
            string emp_name = CmbEmployee.SelectedItem.Text;
            string emp_branch = CmbBranch.SelectedItem.Text;
            eid = int.Parse(txtEmpId.Text);
            Aflag = 0;
            DataSet dt = blu.QuickAttnReport(eid, branch_id,dept_id, sdate, edate, Aflag);


            Panel3.Visible = true;
            Panel4.Visible = true;
            Panel5.Visible = true;
            BtnExport.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();

            DataTable dt1 = blu.countdays(eid, sdate, edate);
            LblTotalDays.Text = dt1.Rows[0]["totaldays"].ToString();
            LblPresentDays.Text = dt1.Rows[0]["presentdays"].ToString();
            LblWeekend.Text = dt1.Rows[0]["weekends"].ToString();
            LblLeaveCount.Text = dt1.Rows[0]["leavecount"].ToString();
            LblAbsentDays.Text = dt1.Rows[0]["absentdays"].ToString();
            LblLWOP.Text = dt1.Rows[0]["Lwop"].ToString();
            LblWOW.Text = dt1.Rows[0]["WOW"].ToString();
            LblPH.Text = dt1.Rows[0]["ph"].ToString();
            LblWOPH.Text = dt1.Rows[0]["wph"].ToString();
            LblTotalPaybleDays.Text = dt1.Rows[0]["totalpayabledays"].ToString();

             DataTable dt11 = blu.getAll_Info(eid);

            lblEmployeeID.Text = eid.ToString();
            lblEmployee.Text = dt11.Rows[0]["emp_fullname"].ToString();
            lblDesignation.Text = dt11.Rows[0]["DEG_NAME"].ToString();
            lblDept.Text = dt11.Rows[0]["DEPT_NAME"].ToString();
            lblBranch.Text = dt11.Rows[0]["BRANCH_NAME"].ToString();
            lblStartDate.Text = nepStartdate;
            lblEndDate.Text = nepEnddate;

        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuickAttendance");
        }
        protected void gvEmployee_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Date";
                HeaderRow.BackColor = Color.FromName("#00BCD4");
                HeaderRow.Font.Size = 14;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Day";
                HeaderRow.BackColor = Color.FromName("#00BCD4");
                HeaderRow.Font.Size = 14;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Roster";
                HeaderRow.BackColor = Color.FromName("#00BCD4");
                HeaderRow.Font.Size = 14;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "In Time";
                HeaderRow.BackColor = Color.FromName("#00BCD4");
                HeaderRow.Font.Size = 14;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Remarks";
                HeaderRow.BackColor = Color.FromName("#00BCD4");
                HeaderRow.Font.Size = 14;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Difference";
                HeaderRow.BackColor = Color.FromName("#00BCD4");
                HeaderRow.Font.Size = 14;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Mode";
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Out Time";
                HeaderRow.BackColor = Color.FromName("#00BCD4");
                HeaderRow.Font.Size = 14;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Remarks";
                HeaderRow.BackColor = Color.FromName("#00BCD4");
                HeaderRow.Font.Size = 14;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Out Date";
                HeaderRow.BackColor = Color.FromName("#00BCD4");
                HeaderRow.Font.Size = 14;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Difference";
                HeaderRow.BackColor = Color.FromName("#00BCD4");
                HeaderRow.Font.Size = 14;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Mode";
                HeaderRow.BackColor = Color.FromName("#00BCD4");
                HeaderRow.Font.Size = 14;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Worked Hour";
                HeaderRow.BackColor = Color.FromName("#00BCD4");
                HeaderRow.Font.Size = 14;
                HeaderRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Remarks";
                HeaderRow.BackColor = Color.FromName("#00BCD4");
                HeaderRow.Font.Size = 14;
                HeaderRow.Cells.Add(HeaderCell);


                GridView1.Controls[0].Controls.AddAt(0, HeaderRow);
                HeaderRow.Attributes.Add("class", "header");

            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int j;
            e.Row.Cells[0].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text.CompareTo("wee") == 0)
                {
                    for (j = 4; j <= 13; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                    e.Row.Cells[14].Attributes.Add("colspan", "11");
                    e.Row.Cells[14].BackColor = Color.FromName("#4CA543");
                    e.Row.Cells[14].Font.Size = 16;
                    e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("woh") == 0)
                {
                    if (e.Row.Cells[4].Text != "&nbsp;" && e.Row.Cells[8].Text == "&nbsp;")
                    {
                        e.Row.Cells[8].Font.Size = 14;
                        e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[8].Text = "Out Missing";
                        e.Row.Cells[8].Attributes.Add("colspan", "7");
                        e.Row.Cells[8].BackColor = Color.FromName("#ff0000");
                        for (j = 9; j <= 13; j++)
                        {
                            e.Row.Cells[j].Visible = false;
                        }
                    }
                    e.Row.Cells[14].BackColor = Color.FromName("#4CA543");
                }
                else if (e.Row.Cells[0].Text.CompareTo("abs") == 0)
                {
                    for (j = 4; j <= 13; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                    e.Row.Cells[14].Attributes.Add("colspan", "11");
                    e.Row.Cells[14].BackColor = Color.FromName("#ff8080");
                    e.Row.Cells[14].Font.Size = 16;
                    e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("hol") == 0)
                {
                    for (j = 4; j <= 13; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                    e.Row.Cells[14].Attributes.Add("colspan", "11");
                    e.Row.Cells[14].BackColor = Color.FromName("#35abd6");
                    e.Row.Cells[14].Font.Size = 16;
                    e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("woph") == 0)
                {
                    if (e.Row.Cells[4].Text != "&nbsp;" && e.Row.Cells[8].Text == "&nbsp;")
                    {
                        e.Row.Cells[8].Font.Size = 14;
                        e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[8].Text = "Out Missing";
                        e.Row.Cells[8].Attributes.Add("colspan", "6");
                        e.Row.Cells[8].BackColor = Color.FromName("#ff0000");
                    }
                    for (j = 9; j <= 13; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                    e.Row.Cells[14].BackColor = Color.FromName("#35abd6");
                }
                else if (e.Row.Cells[0].Text.CompareTo("lev") == 0)
                {
                    if (e.Row.Cells[4].Text != "&nbsp;")
                    {
                        if (e.Row.Cells[4].Text != "&nbsp;" && e.Row.Cells[8].Text == "&nbsp;")
                        {
                            e.Row.Cells[6].Font.Size = 16;
                            e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                            e.Row.Cells[6].Text = "Out Missing";
                            e.Row.Cells[6].Attributes.Add("colspan", "3");
                            e.Row.Cells[7].Visible = false;
                            e.Row.Cells[8].Visible = false;
                        }

                        if (e.Row.Cells[8].Text == "&nbsp;")
                        {
                            e.Row.Cells[10].Text = "";
                            e.Row.Cells[11].Text = "";
                            e.Row.Cells[12].Text = "";
                        }
                        e.Row.Cells[15].BackColor = Color.FromName("#d68b0a");
                    }
                    else
                    {

                        for (j = 4; j <= 13; j++)
                        {
                            e.Row.Cells[j].Visible = false;
                        }

                        e.Row.Cells[14].Attributes.Add("colspan", "11");
                        e.Row.Cells[14].BackColor = Color.FromName("#d68b0a");
                        e.Row.Cells[14].Font.Size = 16;
                        e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Center;

                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("Half") == 0)
                {
                    if (e.Row.Cells[4].Text == "&nbsp;")
                    {
                        for (j = 5; j <= 13; j++)
                        {
                            e.Row.Cells[j].Visible = false;
                        }
                        e.Row.Cells[4].Attributes.Add("colspan", "10");
                        e.Row.Cells[4].BackColor = Color.FromName("#ff8080");
                        e.Row.Cells[4].Text = "Half Absent";
                        e.Row.Cells[4].Font.Size = 16;
                        e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                    }
                    if (e.Row.Cells[4].Text != "&nbsp;" && e.Row.Cells[8].Text == "&nbsp;")
                    {
                        e.Row.Cells[8].Font.Size = 16;
                        e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[8].Text = "Out Missing";
                        e.Row.Cells[8].BackColor = Color.FromName("#ff0000");
                        e.Row.Cells[8].Attributes.Add("colspan", "6");
                        for (j = 9; j <= 13; j++)
                        {
                            e.Row.Cells[j].Visible = false;
                        }
                    }
                    e.Row.Cells[14].BackColor = Color.FromName("#d68b0a");
                    e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Center;
                    //e.Row.Cells[14].Attributes.Add("colspan", "7");
                    e.Row.Cells[14].Font.Size = 16;
                }
                else if (e.Row.Cells[0].Text.CompareTo("dc") == 0)
                {
                    for (j = 4; j <= 15; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                    e.Row.Cells[16].Attributes.Add("colspan", "11");
                    e.Row.Cells[16].Font.Size = 16;
                    e.Row.Cells[16].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                }
                else if (e.Row.Cells[0].Text.CompareTo("lwop") == 0)
                {
                    for (j = 4; j <= 11; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                    e.Row.Cells[15].Attributes.Add("colspan", "11");
                    e.Row.Cells[15].BackColor = Color.FromName("#d68b0a");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                }
                else if (e.Row.Cells[0].Text.CompareTo("wph") == 0)
                {
                    for (j = 4; j <= 15; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                    e.Row.Cells[16].Attributes.Add("colspan", "11");
                    e.Row.Cells[16].BackColor = Color.FromName("#00FFFF");
                    e.Row.Cells[16].Font.Size = 16;
                    e.Row.Cells[16].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 17; j <= 19; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("wowph") == 0)
                {
                    if (e.Row.Cells[4].Text != "&nbsp;")
                    {
                        if (e.Row.Cells[4].Text != "&nbsp;" && e.Row.Cells[8].Text == "&nbsp;")
                        {
                            e.Row.Cells[6].Font.Size = 16;
                            e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                            e.Row.Cells[6].Text = "Out Missing";
                            e.Row.Cells[6].Attributes.Add("colspan", "3");
                            e.Row.Cells[7].Visible = false;
                            e.Row.Cells[8].Visible = false;
                        }

                        if (e.Row.Cells[8].Text == "&nbsp;")
                        {
                            e.Row.Cells[10].Text = "";
                            e.Row.Cells[11].Text = "";
                            e.Row.Cells[12].Text = "";
                        }
                        e.Row.Cells[16].BackColor = Color.FromName("#00FFFF");
                    }
                    else
                    {

                        for (j = 3; j <= 15; j++)
                        {
                            e.Row.Cells[j].Visible = false;
                        }

                        e.Row.Cells[16].Attributes.Add("colspan", "11");
                        e.Row.Cells[16].BackColor = Color.FromName("#d68b0a");
                        e.Row.Cells[16].Font.Size = 16;
                        e.Row.Cells[16].HorizontalAlign = HorizontalAlign.Center;
                        for (j = 17; j <= 19; j++)
                        {
                            e.Row.Cells[j].Visible = false;
                        }
                    }
                }
                else
                {
                    if (e.Row.Cells[4].Text != "&nbsp;")
                    {
                        if (e.Row.Cells[4].Text != "&nbsp;" && e.Row.Cells[8].Text == "&nbsp;")
                        {
                            e.Row.Cells[8].Font.Size = 14;
                            e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                            e.Row.Cells[8].Text = "Out Missing";
                            e.Row.Cells[8].Attributes.Add("colspan", "6");
                            e.Row.Cells[8].BackColor = Color.FromName("#ff0000");
                            for (j = 9; j <= 13; j++)
                            {
                                e.Row.Cells[j].Visible = false;
                            }
                        }
                    }
                }


                Label lblremark = (Label)e.Row.FindControl("lblRemarks");
                if (lblremark.Text != null)
                {
                    if (lblremark.Text == "Late In")
                    {
                        lblremark.Style.Add("Color", "Red");
                    }
                    else
                    {
                        lblremark.Style.Add("Color", "Green");
                    }

                    Label lblOutRemark = (Label)e.Row.FindControl("lblOutRemarks");
                    if (lblOutRemark.Text == "Early Out")
                    {
                        lblOutRemark.Style.Add("Color", "Red");
                    }
                    else
                    {
                        lblOutRemark.Style.Add("Color", "Green");
                    }
                }
            }
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = blu.GetAllOrg();
            lblOrgName.Text = dt.Rows[0]["Org_Name"].ToString();
            lblOrgFullAddress.Text = dt.Rows[0]["Full_Address"].ToString();
            string emp_id = txtEmpId.Text;
            string emp_fullname = CmbEmployee.SelectedItem.ToString();
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_QuickAttendance of " + '_' + emp_fullname + '(' + emp_id + ')' + ".xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            string style = @"<style> TD { mso-number-format:\@; } </style> ";
            Response.Write(style);
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
            Panel1.RenderControl(htw);
            Panel2.RenderControl(htw);
            Panel3.RenderControl(htw);
            HtmlTextWriter htw1 = new HtmlTextWriter(stringWriter);
            htw1.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:left; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
            Panel4.RenderControl(htw1);
            GridView1.RenderControl(htw);
            Panel5.RenderControl(htw1);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        [WebMethod]
        public static string[] getBranch_DepartmentList(int id)
        {
            DataTable dt = blustatic.getBranch_DepartmentList(id);
            int count = dt.Rows.Count;
            string[] array = new string[count];
            int i = 0;
            foreach (DataRow value in dt.Rows)
            {
                array[i] = value["DEPT_ID"] + "./." + value["DEPT_NAME"];
                i++;
            }
            return array;
        }
    }
}