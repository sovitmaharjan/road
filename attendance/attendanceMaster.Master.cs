using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.IO;

namespace attendance
{
    public partial class attendanceMaster : System.Web.UI.MasterPage
    {
        attendance attendanceObject = new attendance();
        static attendance staticAttendanceObject = new attendance();
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
            //DataTable ntf = attendanceObject.getNotification(status);
            //string count = ntf.Rows.Count.ToString();
            ////lblcount.Text = count;

            //var stack = "";
            //var foreachloopStack = "";
            //TimeSpan time;
            //string newtime;
            //foreach (DataRow row in ntf.Rows)
            //{
            //    newtime = ntf.Rows[0]["date"].ToString();
            //    int id = int.Parse(row["id"].ToString());
            //    string emp_name = row["emp_name"].ToString();
            //    string remarks = ntf.Rows[0]["remarks"].ToString();
            //    foreachloopStack = "<li><a href='javascript:void(0);' id='" + id + "' class='user-list-item notificationId'><div class='icon bg-info'><i class='mdi mdi-account'></i></div><div class='user-desc'><span class='name'>" + emp_name + "</span><span class='time'>5 hours ago</span></div></a></li>";
            //    stack = stack + foreachloopStack;
            //}
            ////notifi.Text = stack;

            string sidebar = "";
            if (Convert.ToInt32(Session["userId"]) == 0)
            {
                logouts();
            }
            else
            {
                string emp_id = Session["userId"].ToString();
                string emp_password = Session["password"].ToString();
                //string img;
                DataSet ds = attendanceObject.getPhoto(emp_id, "EMP_PHOTO", "Tbl_Emp_Info");
                int c = ds.Tables[0].Rows.Count;
                foreach (DataRow row in ds.Tables["Photo"].Rows)
                {
                    if (ds.Tables["Photo"].Rows.Count > 0)
                    {
                        byte[] bytedata = new byte[0];
                        if (ds.Tables[0].Rows[0][0].ToString() != "")
                        {
                            bytedata = (byte[])(ds.Tables[0].Rows[0][0]);
                            MemoryStream stmphoto = new MemoryStream(bytedata);
                            string PROFILE_PIC = Convert.ToBase64String(bytedata);
                            PersImage.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);
                            PersImage2.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);
                        }
                        else
                        {
                            PersImage.ImageUrl = null;
                            PersImage2.ImageUrl = null;
                        }
                    }
                    else
                    {
                        PersImage.ImageUrl = null;
                        PersImage2.ImageUrl = null;
                    }
                }
                ds.Tables.Clear();
                string Url = Request.Url.AbsoluteUri;
                string[] tokens = Url.Split('/');
                string last = tokens[tokens.Length - 1];
                string[] page_name = last.Split('.');
                string page = page_name[0];
                DataTable dt5 = attendanceObject.getPageId(page);
                string page_id = dt5.Rows[0]["page_id"].ToString();
                DataTable dt6 = attendanceObject.permission(int.Parse(emp_id));
                if (dt6.Rows.Count > 0)
                {

                    //foreach (string tete in tokensaa)
                    //{
                    //    string[] toks = tete.Split('=');
                    //    if (toks[0] == page_id)
                    //    {
                    //        if (toks[1] == "off")
                    //        {
                    //            Session.Clear();
                    //            Response.Redirect("ErrorPage");
                    //        }
                    //    }
                    //}
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("ErrorPage");
                }
                

                DataTable dt2 = attendanceObject.getLoginData(emp_id, emp_password);
                if (dt2.Rows.Count < 0)
                {
                    logouts();
                }
            }
            int empId = Convert.ToInt32(Session["userid"]);
            string empName = Session["username"].ToString();
            usernameForm.Text = empName;
            username2Form.Text = empName;
            DataTable dataTablePermission = attendanceObject.permission(empId);
            int countPermission = dataTablePermission.Rows.Count;
            DataTable dataTableMenuList = attendanceObject.menuList();
            string[] permission;
            string dotValue;
            if (countPermission == 0)
            {


            }
            else
            {
                permission = dataTablePermission.Rows[0]["permission"].ToString().Split('/');
                foreach (DataRow value in dataTableMenuList.Rows)
                {

                    if (Convert.ToInt32(value["subMenu"]) == 1)
                    {

                        sidebar += "<li class='has_sub'>";
                        foreach (string val in permission)
                        {

                            string[] idOnOff = val.Split('=');
                            if (value["id"].ToString() == idOnOff[0])
                            {

                                if (idOnOff[1] == "on")
                                {

                                    sidebar += "<a href='javascript:void(0);' class='wave-effect'><i class='" + value["iconClass"] + "'></i><span>" + value["title"] + " <span class='menu-arrow'></span></a>";
                                }
                            }
                        }
                        DataTable dataTableSubMenu1 = attendanceObject.subMenu1(Convert.ToInt32(value["id"]));
                        sidebar += "<ul class='list-unstyled'>";
                        foreach (DataRow value2 in dataTableSubMenu1.Rows)
                        {

                            if (Convert.ToInt32(value2["subMenu"]) == 1)
                            {

                                sidebar += "<li class='has_sub'>";
                                foreach (string val in permission)
                                {

                                    string[] idOnOff = val.Split('=');
                                    dotValue = value["id"] + "." + value2["id"];
                                    if (dotValue == idOnOff[0])
                                    {

                                        if (idOnOff[1] == "on")
                                        {

                                            sidebar += "<a href='javascript:void(0);'><span>" + value2["title"] + " <span class='menu-arrow'></span></a>";
                                        }
                                    }
                                }
                                dotValue = "";
                                DataTable dataTableSubMenu2 = attendanceObject.sidebarSubMenu2(Convert.ToInt32(value2["id"]));
                                sidebar += "<ul class='list-unstyled'>";
                                foreach (DataRow value3 in dataTableSubMenu2.Rows)
                                {

                                    foreach (string val in permission)
                                    {

                                        string[] idOnOff = val.Split('=');
                                        dotValue = value["id"] + "." + value2["id"] + "." + value3["id"];
                                        if (dotValue == idOnOff[0])
                                        {

                                            if (idOnOff[1] == "on")
                                            {

                                                sidebar += "<li><a href='" + value3["url"] + "'>" + value3["title"] + "</a></li>";
                                            }
                                        }
                                    }
                                    dotValue = "";
                                }
                                sidebar += "</ul></li>";
                            }
                            else
                            {

                                foreach (string val in permission)
                                {

                                    string[] idOnOff = val.Split('=');
                                    dotValue = value["id"] + "." + value2["id"];
                                    if (dotValue == idOnOff[0])
                                    {

                                        if (idOnOff[1] == "on")
                                        {

                                            sidebar += "<li><a href='" + value2["url"] + "'>" + value2["title"] + "</a></li>";
                                        }
                                    }
                                }
                                dotValue = "";
                            }
                        }
                        sidebar += "</ul></li>";
                    }
                    else
                    {

                        foreach (string val in permission)
                        {

                            string[] idOnOff = val.Split('=');
                            if (value["id"].ToString() == idOnOff[0])
                            {

                                if (idOnOff[1] == "on")
                                {

                                    sidebar += "<li><a href='" + value["url"] + "' class='waves-effect'><i class='" + value["iconClass"] + "'></i><span>" + value["title"] + " </span></a></li>";
                                }
                            }
                        }
                    }
                }
            }

            sidebarMenu.Text = sidebar;
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