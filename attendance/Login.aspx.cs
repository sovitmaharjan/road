using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance
{
    public partial class Login : System.Web.UI.Page
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
            if (Session["message"] != null)
            {
                if (Session["message"].ToString() == "0")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Error.!!!','Check Login Credentials','warning');", true);
                }
                else if (Session["message"].ToString() == "1")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Expired.!!!','Session Expired.','warning');", true);
                }
                else if (Session["message"].ToString() == "3")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Error.!!!','Not Authorized For Web Login','warning');", true);
                }
                else
                {
                    string userId = Session["userId"].ToString();
                    string password = Session["password"].ToString();
                    if (userId == "admin" && password == "superadmin")
                    {
                        Response.Redirect("MainDashboard");
                    }
                    else
                    {
                        DataTable dataTable = attendanceObject.getLoginData(userId, password);
                        if (dataTable.Rows.Count > 0)
                        {
                            string sessionUserId = dataTable.Rows[0]["login_id"].ToString();
                            string sessionPassword = dataTable.Rows[0]["login_password"].ToString();
                            int sessionType = Convert.ToInt32(dataTable.Rows[0]["usertypeid"]);
                            Session["userId"] = sessionUserId;
                            Session["password"] = sessionPassword;
                            Session["userType"] = sessionType;
                            Session["message"] = 1;
                            Response.Redirect("Dashboard");
                        }
                        else
                        {
                            Session["message"] = 0;
                            Response.Redirect("Default");
                        }
                    }
                }
            }
        }

        public void loginClick(object sender, System.EventArgs e)
        {
            string userId = userIdForm.Value;
            string password = passwordForm.Value;
            if (userId == "admin")
            {
                if (password == "superadmin")
                {
                    Session["userId"] = 99999;
                    Session["userName"] = "Admin";
                    Session["password"] = "superadmin";
                    Session["userTypeId"] = "1";
                    Session["message"] = 1;
                    Response.Redirect("AdminDashboard");
                }
                Session["message"] = 0;
                Response.Redirect("Default");
            }
            else
            {
                DataTable dtloginData = attendanceObject.getLoginData(userId, password);
                DataTable dtEmployee = attendanceObject.employeeList(Convert.ToInt32(userId));
                if (dtloginData.Rows.Count > 0)
                {
                    DataTable dt12 = attendanceObject.checkWebLoginStatus(Convert.ToInt32(userId));

                    if (dt12.Rows[0]["enable_web_login"].ToString() == "1")
                    {


                        //***************** Begin Activation Check *********************************//
                        DataTable dt11 = attendanceObject.checkActivation();


                        if (dt11.Rows.Count <= 0)
                        {
                            Session["info"] = 1;
                            Response.Redirect("ActivationErrorPage");
                        }
                        else
                        {
                            string macAddress = attendanceObject.GetMACAddress();
                            string encryptMacAddress = attendanceObject.EncryptString(macAddress);
                            string ActivationId = dt11.Rows[0]["ActivationId"].ToString();
                            ActivationId = ActivationId.Replace(" ", String.Empty);
                            if (encryptMacAddress != ActivationId)
                            {
                                Session["info"] = 3;
                                Response.Redirect("ActivationErrorPage");
                            }
                            else
                            {
                                DateTime encryptDate = Convert.ToDateTime(attendanceObject.DecryptString(dt11.Rows[0]["L_Date"].ToString()));
                                DateTime curdate = DateTime.Now;
                                int remday = Convert.ToInt32((curdate - encryptDate).TotalDays);
                                int encryptDay = Convert.ToInt32(attendanceObject.DecryptString(dt11.Rows[0]["L_D"].ToString()));
                                if (remday > encryptDay)
                                {
                                    Session["info"] = 2;
                                    Response.Redirect("ActivationErrorPage");
                                }
                            }
                        }

                        //***************** End Activation Check *********************************//

                        string sessionUserId = dtloginData.Rows[0]["login_id"].ToString();
                        string sessionUserName = dtEmployee.Rows[0]["EMP_FULLNAME"].ToString();
                        string sessionPassword = dtloginData.Rows[0]["login_password"].ToString();
                        int sessionDeptId = Convert.ToInt32(dtloginData.Rows[0]["dept_id"].ToString());
                        int sessionType = Convert.ToInt32(dtloginData.Rows[0]["usertypeid"]);
                        Session["userId"] = sessionUserId;
                        Session["userName"] = sessionUserName;
                        Session["password"] = sessionPassword;
                        Session["userTypeId"] = sessionType;
                        Session["dept_id"] = sessionDeptId;
                        Session["message"] = 1;
                        Response.Redirect("Dashboard");
                    }
                    else
                    {
                        Session["message"] = 3;
                        Response.Redirect("Default");
                    }
                }
                else
                {
                    Session["message"] = 0;
                    Response.Redirect("Default");
                }
            }
        }
    }
}