using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance
{
    public partial class ActivationError : System.Web.UI.Page
    {
        attendance attendanceObject = new attendance();
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
            if (Session["info"] != null)
            {
                //string info = Session["info"];
                if (Session["info"].ToString() == "1")
                {
                    Label1.Text = "ACTIVATE";
                    Label2.Text = "Software Hasn't Been Activated.";
                }
                else if (Session["info"].ToString() == "2")
                {
                    Label1.Text = "ERROR";
                    Label2.Text = "The Activation Key Doesn't Match.";
                }
                else
                {
                    Label1.Text = "EXPIRED";
                    Label2.Text = "The Activation Period Of Software Has Been Expired.";
                }
                //******************* Admin Info display *************************** //
                DataTable dt = attendanceObject.getAdmininfo();
                lblfullName.Text = dt.Rows[0]["fullname"].ToString();
            }
        }
    }
}