using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.attendanceReport.datewiseAttendance
{
    public partial class datewiseAttendanceList : System.Web.UI.Page
    {

        attendance blu = new attendance();
        DateTime sdate, edate;
        DataTable dt;
        string strPreviousRowID = string.Empty;
        int intSubTotalIndex = 1;


        protected void Page_Load(object sender, EventArgs e)
        {
            sdate = Convert.ToDateTime(Request.Params["startDate"]);
            edate = Convert.ToDateTime(Request.Params["endDate"]);
            string dept_id = Request.Params["dept_id"];
            lblStartDate.Text = sdate.ToString("yyyy-MM-dd");
            lblEndDate.Text = edate.ToString("yyyy-MM-dd");
            dt = blu.DatewiseAttendance(sdate, edate, dept_id);
            GridView.DataSource = dt;
            GridView.DataBind();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            bool RowNeedToAdd = false;
            if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "tdate") != null))
                if (strPreviousRowID != DataBinder.Eval(e.Row.DataItem, "tdate").ToString())
                    RowNeedToAdd = true;
            if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "tdate") == null))
            {
                RowNeedToAdd = true;
            }
            #region Inserting first Row and populating fist Group Header details
            if ((strPreviousRowID == string.Empty) && (DataBinder.Eval(e.Row.DataItem, "tdate") != null))
            {
                GridView grdViewOrders = (GridView)sender;
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                TableCell cell = new TableCell();
                cell.Text = "Date : " + DataBinder.Eval(e.Row.DataItem, "tdate").ToString();
                cell.ColumnSpan = 9;
                cell.CssClass = "header";
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
                if (DataBinder.Eval(e.Row.DataItem, "tdate") != null)
                {
                    row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    cell.Text = "Date : " + DataBinder.Eval(e.Row.DataItem, "tdate").ToString();
                    cell.ColumnSpan = 9;
                    cell.CssClass = "header";
                    row.Cells.Add(cell);
                    grdViewOrders.Controls[0].Controls.AddAt(e.Row.RowIndex + intSubTotalIndex, row);
                    intSubTotalIndex++;
                }
                #endregion
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.DataRow)
            {
                strPreviousRowID = DataBinder.Eval(e.Row.DataItem, "tdate").ToString();


                if (e.Row.Cells[0].Text.CompareTo("wee") == 0)
                {
                    e.Row.Cells[6].Text = "Weekend";
                    e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("woph") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[8].Text = "Holiday";
                    e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;

                }
                else if (e.Row.Cells[0].Text.CompareTo("hol") == 0)
                {
                    e.Row.Cells[8].Text = "Holiday";
                    e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;

                }
                else if (e.Row.Cells[0].Text.CompareTo("lev") == 0)
                {
                    e.Row.Cells[7].Text = "Leave";
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;

                }
                else if (e.Row.Cells[0].Text.CompareTo("Pre") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;

                }
                else if (e.Row.Cells[0].Text.CompareTo("dc") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;

                }
                else if (e.Row.Cells[0].Text.CompareTo("lwop") == 0)
                {
                    e.Row.Cells[7].Text = "LWOP";
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;

                }
                else if (e.Row.Cells[0].Text.CompareTo("wow") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[6].Text = "Weekend";
                    e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;

                }
                else if (e.Row.Cells[0].Text.CompareTo("abs") == 0)
                {
                    e.Row.Cells[4].Text = "Absent";
                    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("weph") == 0)
                {
                    e.Row.Cells[6].Text = "Weekend";
                    e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[8].Text = "Holiday";
                    e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("wowph") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[6].Text = "Weekend";
                    e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[8].Text = "Holiday";
                    e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("halflev") == 0)
                {
                    e.Row.Cells[5].Text = "Half Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[7].Text = "Half Leave";
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("halfabs") == 0)
                {
                    e.Row.Cells[5].Text = "Absent";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[7].Text = "Half Leave";
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("halfpre") == 0)
                {
                    e.Row.Cells[5].Text = "Half Absent";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[7].Text = "Half Present";
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("phsubon") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("phsubof") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("wephsubon") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("phsubon") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("wesubon") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("wesubof") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("wesubonphsubon") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("phsub") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("wephsub") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("wesubph") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("phl") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("wophl") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("wel") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("wol") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("welph") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("wowelph") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
                else if (e.Row.Cells[0].Text.CompareTo("wowel") == 0)
                {
                    e.Row.Cells[5].Text = "Present";
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                }
            }
        }
        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("DateWiseAttendance");
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = blu.GetAllOrg();
            lblOrgName.Text = dt.Rows[0]["Org_Name"].ToString();
            lblOrgFullAddress.Text = dt.Rows[0]["Full_Address"].ToString();
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_ViewDateWiseAttendance.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            string style = @"<style> TD { mso-number-format:\@; } </style> ";
            Response.Write(style);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
            Panel1.RenderControl(htw);
            Panel2.RenderControl(htw);
            Panel3.RenderControl(htw);
            GridView.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}