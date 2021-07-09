using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.supervisor
{
    public partial class supervisor : System.Web.UI.MasterPage
    {
        supervisorAttendance attendanceObject = new supervisorAttendance();

        static supervisorAttendance staticAttendanceObject = new supervisorAttendance();
        DataTable dt;

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
            string status = "2";
            DataTable ntf = attendanceObject.getNotification(status);
            string count = ntf.Rows.Count.ToString();
            //lblcount.Text = count;

            var stack = "";
            var foreachloopStack = "";
            TimeSpan time;
            string newtime;
            foreach (DataRow row in ntf.Rows)
            {
                newtime = ntf.Rows[0]["date"].ToString();
                int id = int.Parse(row["id"].ToString());
                string emp_name = row["emp_name"].ToString();
                string remarks = ntf.Rows[0]["remarks"].ToString();
                foreachloopStack = "<li><a href='javascript:void(0);' id='" + id + "' class='user-list-item notificationId'><div class='icon bg-info'><i class='mdi mdi-account'></i></div><div class='user-desc'><span class='name'>" + emp_name + "</span><span class='time'>5 hours ago</span></div></a></li>";
                stack = stack + foreachloopStack;
            }
            //notifi.Text = stack;



            if (Convert.ToInt32(Session["userId"]) == 0)
            {
                //logouts();
            }
            else
            {
                string emp_id = Session["userId"].ToString();
                string emp_password = Session["password"].ToString();
                

                
            }
            
            
            

            //******************* footer date display *************************** //
            lblDate.Text = DateTime.Now.Year.ToString();
            //******************* Admin Info display *************************** //
            dt = attendanceObject.getAdmininfo();
            lblEmail1.Text = dt.Rows[0]["email1"].ToString();
            lblEmail2.Text = dt.Rows[0]["email2"].ToString();
            lblConatct1.Text = dt.Rows[0]["contact1"].ToString();
            lblConatct2.Text = dt.Rows[0]["contact2"].ToString();
            HyperLinkAdmin.Text = dt.Rows[0]["fullname"].ToString();
            HyperLinkAdmin.Attributes["href"] = "http://" + dt.Rows[0]["website"].ToString();
            lblDate.Text = DateTime.Now.Year.ToString();

            //******************* Client Info display *************************** //
            dt = attendanceObject.GetAllOrg();
            HyperLink.Text = dt.Rows[0]["Org_Name"].ToString();
            HyperLink.Attributes["href"] = "http://" + dt.Rows[0]["Org_Website"].ToString();



        }

        public void logout(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect(baseUrl);
        }

        public void logouts()
        {
            Session.Clear();
            Response.Redirect("Login");
        }

        [WebMethod]
        public static void changeNotificationStatus(string id)
        {
            staticAttendanceObject.changeNotificationStatus(id);
        }
    }
}