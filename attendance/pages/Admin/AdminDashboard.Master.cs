using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Admin
{
    public partial class AdminDashboard : System.Web.UI.MasterPage
    {
        DataTable dt;
        attendance blu = new attendance();

        public string baseUrl
        {

            get
            {

                return blu.baseUrl();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // ************** Session Validation ******************* //
                if (Session["username"] as string == "" || Session["username"] as string == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Oops !!!','Session Expired. !!! please Login Again. ','warning',{}).then((value) => { window.location ='Login'; });", true);
                }
                else
                {
                    int userId = int.Parse(Session["userId"].ToString());
                    dt = blu.getList("tbl_Userlist", "userId", userId);
                    //username2Form.Text = dt.Rows[0]["FullName"].ToString();
                    //usernameForm.Text = dt.Rows[0]["FullName"].ToString();

                    // ************** Admin Info ******************* //
                    dt = blu.getList("Tbl_admin_info", "", 0);
                    lblEmail1.Text = dt.Rows[0]["email1"].ToString();
                    lblEmail2.Text = dt.Rows[0]["email2"].ToString();
                    lblConatct1.Text = dt.Rows[0]["contact1"].ToString();
                    lblConatct2.Text = dt.Rows[0]["contact2"].ToString();
                    HyperLinkAdmin.Text = dt.Rows[0]["fullname"].ToString();
                    HyperLinkAdmin.Attributes["href"] = "http://" + dt.Rows[0]["website"].ToString();
                    lblDate.Text = DateTime.Now.Year.ToString();

                    // ************** Client Info ******************* //
                    dt = blu.getOrgInfo();
                    HyperLink.Text = dt.Rows[0]["Org_Name"].ToString();
                    HyperLink.Attributes["href"] = "http://" + dt.Rows[0]["Org_Website"].ToString();
                }
            }
        }

        public void logout()
        {

            Session.Clear();
            Response.Redirect(baseUrl);
        }
    }
}