using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.IO;

namespace attendance.pages.Report.attendanceReport.quickAttendance
{
    public partial class quickAttendance : System.Web.UI.Page
    {
        attendance blu = new attendance();
        int dept_id, emp_id;
        DateTime sdate, edate;
        DataTable dt;
        int Aflag;
        string strPreviousRowID = string.Empty;
        int intSubTotalIndex = 1;

        int sessionUserId, sessionDept_id;
        string sessionUserTypeId;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userId"] = 715;
            Session["userName"] = 715;
            Session["password"] = 123;
            Session["userTypeId"] = 2;
            Session["dept_id"] = 35;
            Session["message"] = 1;

            sessionUserId = Convert.ToInt32(Session["userId"].ToString());
            sessionUserTypeId = Session["userTypeId"].ToString();
            sessionDept_id = Convert.ToInt32(Session["DEPT_ID"].ToString());
            if (!IsPostBack)
            {
                loadDepartment();
                CmbEmployee.Enabled = false;
                Panel3.Visible = false;
                BtnExport.Visible = false;
                Panel5.Visible = false;
            }
        }
        public void loadDepartment()
        {
            if (sessionUserTypeId == "2")
            {
                dt = blu.getDepartment();
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");
            }
            else
            {
                dt = blu.getSupervisorDepartment(sessionUserId);
                CmbDepartment.DataSource = dt;
                CmbDepartment.DataTextField = "DEPT_NAME";
                CmbDepartment.DataValueField = "DEPT_ID";
                CmbDepartment.DataBind();
                CmbDepartment.Items.Insert(0, "Select Department");
            }
        }
        public void loadEmployee()
        {
            if (sessionUserTypeId == "2")
            {
                dt = blu.getEmployees();
                CmbEmployee.DataSource = dt;
                CmbEmployee.DataTextField = "emp_fullname";
                CmbEmployee.DataValueField = "EMP_ID";
                CmbEmployee.DataBind();
                CmbEmployee.Items.Insert(0, "Select Employee");
            }
            else
            {
                dt = blu.getSupervisorDepartment(dept_id);
                CmbEmployee.DataSource = dt;
                CmbEmployee.DataTextField = "emp_fullname";
                CmbEmployee.DataValueField = "EMP_ID";
                CmbEmployee.DataBind();
                CmbEmployee.Items.Insert(0, "Select Employee");
            }
            
        }
        protected void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbEmployee.Enabled = true;
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
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
                CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
                txtEmpId.Text = CmbEmployee.SelectedValue.ToString();
            }
        }
        protected void Chkemp_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkemp.Checked)
            {
                if (CmbDepartment.SelectedIndex == 0)
                {
                    Chkemp.Checked = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Select Department First !!!!','warning')", true);
                    return;
                }
                else
                {
                    CmbEmployee.Enabled = false;
                    CmbEmployee.Items.Clear();
                    txtEmpId.Enabled = false;
                    txtEmpId.Text = "";
                }
            }
            else
            {
                loadDepartment();
                txtEmpId.Text = "";
                CmbEmployee.Items.Clear();
            }
        }
        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            loadDepartment();
            CmbDepartment.Enabled = true;
            loadEmployee();
            CmbEmployee.Enabled = true;
            emp_id = int.Parse(txtEmpId.Text);
            dt = blu.getAll_Info(emp_id);
            if (dt.Rows.Count > 0)
            {
                dept_id = Convert.ToInt32( dt.Rows[0][dept_id].ToString());

                if (sessionUserTypeId == "2")
                {
                    txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                    CmbDepartment.SelectedValue = dt.Rows[0]["DEPT_ID"].ToString();
                    CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
                    CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
                    CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
                }
                else
                {
                    if (dept_id == sessionDept_id)
                    {
                        txtEmpId.Text = dt.Rows[0]["EMP_ID"].ToString();
                        CmbDepartment.SelectedValue = dt.Rows[0]["DEPT_ID"].ToString();
                        CmbDepartment.Items[0].Attributes["disabled"] = "disabled";
                        CmbEmployee.SelectedValue = dt.Rows[0]["EMP_ID"].ToString();
                        CmbEmployee.Items[0].Attributes["disabled"] = "disabled";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','Selected Employee Not Available.','warning')", true);
                        txtEmpId.Text = "";
                        loadDepartment();
                        CmbEmployee.Enabled = false;
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(upPnl, this.GetType(), "alertscipt", "swal('Ooops!','No Employee with this ID !!!!','warning')", true);
                CmbEmployee.Enabled = false;
            }
        }
        protected void BtnLoad_Click(object sender, EventArgs e)
        {
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
            int BranchId = 0;

            if (Chkemp.Checked)
            {
                dept_id = Convert.ToInt32(CmbDepartment.SelectedValue);
                emp_id = 0;
            }
            else
            {
                dept_id = 0;
                emp_id = int.Parse(txtEmpId.Text);
            }

            Aflag = 0;
            DataSet ds = blu.QuickAttnReport(emp_id, BranchId, dept_id, sdate, edate, Aflag);
            DataTable dt = ds.Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Panel3.Visible = true;
            Panel5.Visible = true;
            BtnExport.Visible = true;
            DataTable dt1 = ds.Tables[1];
            GridView2.DataSource = dt1;
            GridView2.DataBind();
            lblStartDate.Text = sdate.ToString("yyyy-MM-dd");
            lblEndDate.Text = edate.ToString("yyyy-MM-dd");
            //Clearing dataset
            ds.Clear();
        }
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuickAttendance");
        }
        protected void gvEmployee_RowCreated(object sender, GridViewRowEventArgs e)
        {
            bool RowNeedToAdd = false;
            if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "EMP_ID") != null))
                if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "EMP_ID").ToString())
                    RowNeedToAdd = true;
            if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "EMP_ID") == null))
            {
                RowNeedToAdd = true;
            }
            #region Inserting first Row and populating fist Group Header details
            if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "EMP_ID") != null))
            {
                GridView grdViewOrders = (GridView)sender;
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                TableCell cell = new TableCell();
                cell.Text = "Employee : " + DataBinder.Eval(e.Row.DataItem, "emp_fullname").ToString() + " (" + DataBinder.Eval(e.Row.DataItem, "EMP_ID").ToString() + ")" ;
                cell.ColumnSpan = 18;
                cell.CssClass = "name";
                row.Cells.Add(cell);
                grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                intSubTotalIndex++;
            }
            #endregion
            if (RowNeedToAdd)
            {
                #region Adding Sub Total Row
                GridView grdViewOrders = (GridView)sender;
                // Creating a Row          
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                //Adding Total Cell          
                TableCell cell = new TableCell();
                //Adding the Row at the RowIndex position in the Grid      
                grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                intSubTotalIndex++;
                #endregion
                #region Adding Next Group Header Details
                if (DataBinder.Eval(e.Row.DataItem, "EMP_ID") != null)
                {
                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    cell.Text = "Employee : " + DataBinder.Eval(e.Row.DataItem, "emp_fullname").ToString() + " (" + DataBinder.Eval(e.Row.DataItem, "EMP_ID").ToString() + ")";
                    cell.ColumnSpan = 18;
                    cell.CssClass = "name";
                    row.Cells.Add(cell);
                    grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;
                }
                #endregion
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = e.Row.Cells.Count;
            int j;
            e.Row.Cells[0].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "EMP_ID").ToString();

                if (e.Row.Cells[0].Text.CompareTo("wephsubon") == 0)
                {
                    e.Row.Cells[15].BackColor = Color.FromName("#4CA543");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("phsubon") == 0)
                {
                    e.Row.Cells[15].BackColor = Color.FromName("#35abd6");
                    e.Row.Cells[15].Font.Size = 16;
                }
                else if (e.Row.Cells[0].Text.CompareTo("wesubon") == 0)
                {
                    e.Row.Cells[15].BackColor = Color.FromName("#4CA543");
                    e.Row.Cells[15].Font.Size = 16;
                }
                else if (e.Row.Cells[0].Text.CompareTo("wesubof") == 0)
                {
                    for (j = 2; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#4CA543");
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[15].Font.Size = 16;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("wesubonphsubon") == 0)
                {
                    e.Row.Cells[15].BackColor = Color.FromName("#4CA543");
                    e.Row.Cells[15].Font.Size = 16;
                }
                else if (e.Row.Cells[0].Text.CompareTo("phsub") == 0)
                {
                    for (j = 2; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#35abd6");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("wephsub") == 0)
                {
                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#4CA543");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("wesubph") == 0)
                {
                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#4CA543");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("phl") == 0)
                {
                    for (j = 2; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#35abd6");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }

                else if (e.Row.Cells[0].Text.CompareTo("halfp") == 0)
                {
                    //e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#3d6");
                }



                else if (e.Row.Cells[0].Text.CompareTo("wophl") == 0)
                {
                    for (j = 2; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#e6c409");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("wel") == 0)
                {
                    for (j = 2; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#4CA543");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("wol") == 0)
                {
                    e.Row.Cells[15].BackColor = Color.FromName("#35abd6");
                    e.Row.Cells[15].Font.Size = 16;
                }

                else if (e.Row.Cells[0].Text.CompareTo("welph") == 0)
                {
                    for (j = 2; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#35abd6");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }

                else if (e.Row.Cells[0].Text.CompareTo("wowelph") == 0)
                {
                    if (e.Row.Cells[3].Text != "&nbsp;" && e.Row.Cells[7].Text == "&nbsp;")
                    {
                        e.Row.Cells[5].Font.Size = 16;
                        e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[5].Text = "Out Missing";
                        e.Row.Cells[5].Attributes.Add("colspan", "3");
                        e.Row.Cells[5].BackColor = Color.FromName("#35abd6");
                        e.Row.Cells[6].Visible = false;
                        e.Row.Cells[7].Visible = false;
                    }
                    if (e.Row.Cells[9].Text != "&nbsp;" && e.Row.Cells[13].Text == "&nbsp;")
                    {
                        e.Row.Cells[11].Font.Size = 16;
                        e.Row.Cells[11].Attributes.Add("colspan", "3");
                        e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[11].BackColor = Color.FromName("#35abd6");
                        e.Row.Cells[11].Text = "Out Missing";
                        e.Row.Cells[12].Visible = false;
                        e.Row.Cells[13].Visible = false;
                    }
                    e.Row.Cells[15].BackColor = Color.FromName("#35abd6");
                }
                else if (e.Row.Cells[0].Text.CompareTo("wowel") == 0)
                {
                    for (j = 2; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#35abd6");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("wee") == 0)
                {
                    for (j = 2; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#4CA543");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("wow") == 0)
                {
                    if (e.Row.Cells[3].Text != "&nbsp;" && e.Row.Cells[7].Text == "&nbsp;")
                    {
                        e.Row.Cells[6].Font.Size = 16;
                        e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[6].Text = "Out Missing";
                        e.Row.Cells[6].Attributes.Add("colspan", "3");
                        e.Row.Cells[6].BackColor = Color.FromName("#4CA543");
                        e.Row.Cells[7].Visible = false;
                        e.Row.Cells[8].Visible = false;
                    }
                    if (e.Row.Cells[9].Text != "&nbsp;" && e.Row.Cells[13].Text == "&nbsp;")
                    {
                        e.Row.Cells[11].Font.Size = 16;
                        e.Row.Cells[11].Attributes.Add("colspan", "3");
                        e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[11].BackColor = Color.FromName("#4CA543");
                        e.Row.Cells[12].Text = "Out Missing";
                        e.Row.Cells[12].Visible = false;
                        e.Row.Cells[13].Visible = false;
                    }
                    e.Row.Cells[15].BackColor = Color.FromName("#4CA543");
                }
                else if (e.Row.Cells[0].Text.CompareTo("abs") == 0)
                {
                    for (j = 2; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }

                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#ff8080");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("hol") == 0)
                {
                    for (j = 2; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#35abd6");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("phsubof") == 0)
                {
                    for (j = 2; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#35abd6");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("woph") == 0)
                {
                    if (e.Row.Cells[3].Text != "&nbsp;" && e.Row.Cells[7].Text == "&nbsp;")
                    {
                        e.Row.Cells[5].Font.Size = 16;
                        e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[5].Text = "Out Missing";
                        e.Row.Cells[5].Attributes.Add("colspan", "3");
                        e.Row.Cells[5].BackColor = Color.FromName("#35abd6");
                        e.Row.Cells[6].Visible = false;
                        e.Row.Cells[7].Visible = false;
                    }
                    if (e.Row.Cells[9].Text != "&nbsp;" && e.Row.Cells[13].Text == "&nbsp;")
                    {
                        e.Row.Cells[11].Font.Size = 16;
                        e.Row.Cells[11].Attributes.Add("colspan", "3");
                        e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                        e.Row.Cells[11].BackColor = Color.FromName("#35abd6");
                        e.Row.Cells[11].Text = "Out Missing";
                        e.Row.Cells[12].Visible = false;
                        e.Row.Cells[13].Visible = false;
                    }
                    e.Row.Cells[15].BackColor = Color.FromName("#35abd6");
                }
                else if (e.Row.Cells[0].Text.CompareTo("lev") == 0)
                {
                    if (e.Row.Cells[3].Text != "&nbsp;")
                    {
                        if (e.Row.Cells[3].Text != "&nbsp;" && e.Row.Cells[7].Text == "&nbsp;")
                        {
                            e.Row.Cells[5].Font.Size = 17;
                            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                            e.Row.Cells[5].Text = "Out Missing";
                            e.Row.Cells[5].Attributes.Add("colspan", "3");
                            e.Row.Cells[6].Visible = false;
                            e.Row.Cells[7].Visible = false;
                        }
                        if (e.Row.Cells[9].Text != "&nbsp;" && e.Row.Cells[13].Text == "&nbsp;")
                        {
                            e.Row.Cells[11].Attributes.Add("colspan", "3");
                            e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                            e.Row.Cells[11].Text = "Out Missing";
                            e.Row.Cells[12].Visible = false;
                            e.Row.Cells[13].Visible = false;
                        }
                        if (e.Row.Cells[7].Text == "&nbsp;")
                        {
                            e.Row.Cells[9].Text = "";
                            e.Row.Cells[10].Text = "";
                            e.Row.Cells[11].Text = "";
                        }
                        e.Row.Cells[15].BackColor = Color.FromName("#d68b0a");
                    }
                    else
                    {
                        for (j = 2; j <= 14; j++)
                        {
                            e.Row.Cells[j].Visible = false;
                        }
                        e.Row.Cells[15].Attributes.Add("colspan", "17");
                        e.Row.Cells[15].BackColor = Color.FromName("#d68b0a");
                        e.Row.Cells[15].Font.Size = 16;
                        e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                        for (j = 16; j <= 18; j++)
                        {
                            e.Row.Cells[j].Visible = false;
                        }
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("half") == 0)
                {
                    for (j = 9; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                    e.Row.Cells[15].BackColor = Color.FromName("#d68b0a");
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[15].Attributes.Add("colspan", "7");
                    e.Row.Cells[15].Font.Size = 16;
                }
                else if (e.Row.Cells[0].Text.CompareTo("dc") == 0)
                {
                    for (j = 2; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                    e.Row.Cells[15].Attributes.Add("colspan", "16");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("lwop") == 0)
                {
                    for (j = 2; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#d68b0a");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("weph") == 0)
                {
                    for (j = 2; j <= 14; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                    e.Row.Cells[15].Attributes.Add("colspan", "17");
                    e.Row.Cells[15].BackColor = Color.FromName("#00FFFF");
                    e.Row.Cells[15].Font.Size = 16;
                    e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                    for (j = 16; j <= 18; j++)
                    {
                        e.Row.Cells[j].Visible = false;
                    }
                }
                else if (e.Row.Cells[0].Text.CompareTo("woweph") == 0)
                {
                    if (e.Row.Cells[3].Text != "&nbsp;")
                    {
                        if (e.Row.Cells[3].Text != "&nbsp;" && e.Row.Cells[7].Text == "&nbsp;")
                        {
                            e.Row.Cells[5].Font.Size = 16;
                            e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                            e.Row.Cells[5].Text = "Out Missing";
                            e.Row.Cells[5].Attributes.Add("colspan", "3");
                            e.Row.Cells[6].Visible = false;
                            e.Row.Cells[7].Visible = false;
                        }
                        if (e.Row.Cells[9].Text != "&nbsp;" && e.Row.Cells[13].Text == "&nbsp;")
                        {
                            e.Row.Cells[11].Attributes.Add("colspan", "3");
                            e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                            e.Row.Cells[11].Text = "Out Missing";
                            e.Row.Cells[12].Visible = false;
                            e.Row.Cells[13].Visible = false;
                        }
                        if (e.Row.Cells[7].Text == "&nbsp;")
                        {
                            e.Row.Cells[9].Text = "";
                            e.Row.Cells[10].Text = "";
                            e.Row.Cells[11].Text = "";
                        }
                        e.Row.Cells[15].BackColor = Color.FromName("#00FFFF");
                    }
                    else
                    {
                        for (j = 2; j <= 14; j++)
                        {
                            e.Row.Cells[j].Visible = false;
                        }

                        e.Row.Cells[15].Attributes.Add("colspan", "17");
                        e.Row.Cells[15].BackColor = Color.FromName("#d68b0a");
                        e.Row.Cells[15].Font.Size = 16;
                        e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
                        for (j = 16; j <= 18; j++)
                        {
                            e.Row.Cells[j].Visible = false;
                        }
                    }
                }
                else
                {
                    if (e.Row.Cells[3].Text != "&nbsp;")
                    {
                        if (e.Row.Cells[3].Text != "&nbsp;" && e.Row.Cells[7].Text == "&nbsp;")
                        {
                            e.Row.Cells[6].Font.Size = 16;
                            e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                            e.Row.Cells[6].Text = "Out Missing";
                            e.Row.Cells[6].Attributes.Add("colspan", "3");
                            e.Row.Cells[6].BackColor = Color.FromName("#ff0000");
                            e.Row.Cells[7].Visible = false;
                            e.Row.Cells[8].Visible = false;
                        }
                        if (e.Row.Cells[9].Text != "&nbsp;" && e.Row.Cells[13].Text == "&nbsp;")
                        {
                            e.Row.Cells[12].Font.Size = 16;
                            e.Row.Cells[12].Attributes.Add("colspan", "3");
                            e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Center;
                            e.Row.Cells[12].BackColor = Color.FromName("#ff0000");
                            e.Row.Cells[12].Text = "Out Missing";
                            e.Row.Cells[13].Visible = false;
                            e.Row.Cells[14].Visible = false;
                        }
                    }
                }
                if (e.Row.Cells[9].Text == "&nbsp;")
                {
                    for (j = 9; j <= 14; j++)
                    {
                        e.Row.Cells[j].Text = "";
                    }
                }

                Label lblremark = (Label)e.Row.FindControl("lblRemarks");
                if (lblremark.Text != null)
                {
                    if (lblremark.Text == "Early In")
                    {
                        lblremark.Style.Add("Color", "Green");
                    }
                    else if (lblremark.Text == "Late In")
                    {
                        lblremark.Style.Add("Color", "Red");
                    }
                    if (e.Row.Cells[18].Text != "&nbsp;")
                    {
                        e.Row.Cells[18].BackColor = Color.FromName("#aaaeee");
                    }
                }
            }
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = blu.GetAllOrg();
            lblOrgName.Text = dt.Rows[0]["Org_Name"].ToString();
            lblOrgFullAddress.Text = dt.Rows[0]["Full_Address"].ToString();
            int BranchId = 0;
            sdate = Convert.ToDateTime(TxtStartDate.Text);
            edate = Convert.ToDateTime(TxtEndDate.Text);
            int emp_id;
            if (Chkemp.Checked)
            {
                dept_id = Convert.ToInt32(CmbDepartment.SelectedValue);
                emp_id = 0;
            }
            else
            {
                dept_id = 0;
                emp_id = int.Parse(txtEmpId.Text);
            }

            Aflag = 0;
            DataSet ds = blu.QuickAttnReport(emp_id, BranchId, dept_id, sdate, edate, Aflag);
            DataTable dt1 = ds.Tables[0];
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            emp_id = 1;
            string emp_fullname = "CKs";
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
            GridView1.RenderControl(htw);
            
            GridView2.RenderControl(htw);
            HtmlTextWriter htw1 = new HtmlTextWriter(stringWriter);
            htw1.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
            Panel5.RenderControl(htw1);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}