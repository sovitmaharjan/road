using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Report.subsituteLeave
{
    public partial class SubsituteLeaveLapseList : System.Web.UI.Page
    {
        attendance blu = new attendance();
        DateTime sdate, edate;
        int dept_id, emp_id;
        DataTable dt; 

        protected void Page_Load(object sender, EventArgs e)
        {
            dept_id = Convert.ToInt32(Request.Params["dept_id"]);
            emp_id = Convert.ToInt32(Request.Params["emp_id"]);
            dt = blu.SubsituteLeaveLapse(dept_id, emp_id);
            GridView.DataSource = dt;
            GridView.DataBind();
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubsituteLeaveLapse");
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            dt = blu.GetAllOrg();
            lblOrgName.Text = dt.Rows[0]["Org_Name"].ToString();
            lblOrgFullAddress.Text = dt.Rows[0]["Full_Address"].ToString();
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Reports_SubsituteLeaveLapse.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            string style = @"<style> TD { mso-number-format:\@; } </style> ";
            Response.Write(style);

            htw.Write("<div style='PADDING-RIGHT: 5px; PADDING-LEFT: 5px; text-align:center; PADDING-BOTTOM: 0px; PADDING-TOP: 0px'>");
            Panel1.RenderControl(htw);
            Panel2.RenderControl(htw);
            GridView.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}