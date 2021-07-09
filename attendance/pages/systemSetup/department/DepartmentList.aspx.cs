using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.department {
    public partial class DepartmentList : System.Web.UI.Page {

        attendance blu = new attendance();
        DataTable dt1;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                DataTable dt = blu.getDepartment();
                if (dt.Rows.Count > 0) {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                } else {
                    Response.Redirect("AddDepartment");
                }
            }
        }

        protected void GridView_Merge_Header_RowCreated(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.Header) {
                //Build custom header.
                GridView oGridView = (GridView)sender;
                GridViewRow oGridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell oTableCell = new TableCell();
                oTableCell.Text = "S.No";
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Department Name";
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Status";
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell = new TableCell();
                oTableCell.Text = "Actions";
                oTableCell.ColumnSpan = 2;
                oGridViewRow.Cells.Add(oTableCell);
                oTableCell.Attributes.Add("class", "header");

                oTableCell.Attributes.Add("class", "header");
                oGridView.Controls[0].Controls.AddAt(0, oGridViewRow);
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e) {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[3].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow) {
                DataRowView dRow = (DataRowView)e.Row.DataItem;

                if (dRow.Row["status"].ToString() == "0") {
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                } else {
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "Section") {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView2.Rows[index];
                TableCell id = selectedRow.Cells[1];
                TableCell Name = selectedRow.Cells[2];
                TableCell Status = selectedRow.Cells[3];
                string department = Name.Text;
                int status = int.Parse(Status.Text);

                dt1 = blu.getDepartmentInfo(department);
                if (dt1.Rows.Count > 0) {
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                    lblDept.Text = department.ToString() + " " + "Department";

                } else {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Ooops!','No section with this Department!','warning')</script>");
                }
            } else {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GridView2.Rows[index];
                TableCell id = selectedRow.Cells[1];
                TableCell Name = selectedRow.Cells[2];

                TableCell Status = selectedRow.Cells[3];
                int deptid = int.Parse(id.Text);
                string depname = Name.Text;
                int status = int.Parse(Status.Text);
                string olddept = Name.Text;
                Response.Redirect("EditDepartment?DEPT_ID=" + deptid + "&DEPT_NAME=" + depname + "&status=" + status + "&olddept=" + olddept);

            }
        }
        string olddept = "";
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) {
            GridViewRow gr = GridView1.SelectedRow;
            olddept = gr.Cells[3].Text;
            Response.Redirect("EditSection?DEPT_ID=" + gr.Cells[1].Text + "&DEPT_NAME=" + gr.Cells[2].Text + "&status=" + gr.Cells[4].Text + "&olddept=" + olddept);
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[4].Visible = false;
        }

        protected void BtnNew_Click(object sender, EventArgs e) {
            Response.Redirect("AddDepartment");
        }
    }
}