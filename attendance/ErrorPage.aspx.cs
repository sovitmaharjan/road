using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance
{
    public partial class ErrorPage : System.Web.UI.Page
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

        }
    }
}