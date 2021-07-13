using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace attendance.pages.dashboard
{
    public partial class dashboard : System.Web.UI.Page
    {
        static attendance attendanceObject = new attendance();

        attendance blu = new attendance();
        DataTable dt;
        int hour;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string list = "";
                //list += "<li style='list-style-type: none; color: #3AC9D6; font-size:x-large;'>Contract</li>";
                DataTable dtTableData = blu.queryFunction("SELECT EMP_ID, emp_photo, emp_Fullname, EMP_PCOUNTRY, EMP_JOINDATE,(case when EMP_PCOUNTRY='India' then DATEADD(day,365, EMP_JOINDATE) else DATEADD(day,730, EMP_JOINDATE) end) as contractExpiryDate,DATEDIFF(day,  GETDATE(), (case when EMP_PCOUNTRY='India' then DATEADD(day,365, EMP_JOINDATE)else DATEADD(day,730, EMP_JOINDATE) end)) as Datedifference FROM view_emp_info where STATUS_ID = 1 and MODE_ID = 3 ORDER BY Datedifference ASC");
                //foreach (DataRow value in dtTableData.Rows)
                //{
                //    if (Convert.ToInt32(value["Datedifference"]) < 0)
                //    {
                //        list += "<li style='color: red;'>" + value["emp_Fullname"] + " Contract Has Expired " + Convert.ToInt32( value["Datedifference"] ) * -1 + " days ago</li>";
                //    }
                //    else
                //    {
                //        list += "<li>" + value["emp_Fullname"] + " Contract Will Expire in " + value["Datedifference"]+ " days </li>";
                //    }
                //}
                
                //list += "<br />";
                //list += "<li style='list-style-type: none; color: #3AC9D6; font-size:x-large;'>Probation</li>";
                dtTableData = blu.queryFunction("SELECT EMP_ID, emp_photo, emp_Fullname, EMP_PCOUNTRY, EMP_JOINDATE, DATEADD(day,180, EMP_JOINDATE) as probationDate, DATEDIFF(day,  GETDATE(), DATEADD(day,180, EMP_JOINDATE)) as Datedifference FROM view_emp_info where STATUS_ID = 1 and MODE_ID = 6 ORDER BY Datedifference ASC");
                //foreach (DataRow value in dtTableData.Rows)
                //{
                //    if (Convert.ToInt32(value["Datedifference"]) < 0)
                //    {
                //        list += "<li style='color: green;'>" + value["emp_Fullname"] + " Has Completed Probation " + Convert.ToInt32( value["Datedifference"]) * -1  + " days ago</li>";
                //    }
                //    else
                //    {
                //        list += "<li>" + value["emp_Fullname"] + " Probation will Be Completed in " + value["Datedifference"] + " days </li>";
                //    }
                //}
                //noticeList.Text = list;
                
                dt = blu.countBranch();
                string Branch = dt.Rows[0]["Branch"].ToString();
                countBranch.Text = Branch;

                dt = blu.countInBranch();
                string inBranch = dt.Rows[0]["Branch"].ToString();
                countInBranch.Text = inBranch;

                dt = blu.countOutBranch();
                string outBranch = dt.Rows[0]["Branch"].ToString();
                countOutBranch.Text = outBranch;

                dt = blu.countDepartment();
                string department = dt.Rows[0]["dept"].ToString();
                countDepartment.Text = department;

                dt = blu.countActiveDepartment();
                string activeDepartment = dt.Rows[0]["dept"].ToString();
                countActiveDepartment.Text = activeDepartment;

                dt = blu.countInactiveDepartment();
                string inactiveDepartment = dt.Rows[0]["dept"].ToString();
                countInactiveDepartment.Text = inactiveDepartment;

                dt = blu.countSection();
                string section = dt.Rows[0]["section"].ToString();
                countSection.Text = section;

                dt = blu.countActiveSection();
                string activeSection = dt.Rows[0]["section"].ToString();
                countActiveSection.Text = activeSection;

                dt = blu.countInactiveSection();
                string inactiveSection = dt.Rows[0]["section"].ToString();
                countInactiveSection.Text = inactiveSection;

                dt = blu.countEmployee();
                string employee = dt.Rows[0]["emp"].ToString();
                countEmployee.Text = employee;

                dt = blu.countEmployeeMale();
                string maleEmployee = dt.Rows[0]["emp"].ToString();
                countEmployeeMale.Text = maleEmployee;

                dt = blu.countEmployeeFemale();
                string femaleEmployee = dt.Rows[0]["emp"].ToString();
                countEmployeeFemale.Text = femaleEmployee;

                // ************************* Getting Events *********************************
                //int flag = 1;
                //DataTable dt13 = blu.getEvents(flag);
                //var stacks = "";
                //foreach (DataRow row in dt13.Rows) {
                //    string date = Convert.ToDateTime(row["Date"]).ToString("yyyy/MM/dd");
                //    var foreachloopStack = "<div class='inbox-item'><p class='inbox-item-author'>" + row["Title"].ToString() + "</p><p class='inbox-item-text'>" + row["Description"].ToString() + "</p><p class='inbox-item-date'>" + date + "</p></div>";
                //    stacks = stacks + foreachloopStack;
                //}
                //Events.Text = stacks;

                //********************************* Getting Birthdays *********************************
                string imageUrl;
                dt = blu.birthday();
                var stack = "";
                var todayDate = DateTime.Now.ToString("yyyy-mm-dd");
                var todayMonthOnly = DateTime.Now.ToString("MMMM");
                var todayDateOnly = DateTime.Now.ToString("dd");
                var happyBirthday = "";
                foreach (DataRow row in dt.Rows)
                {
                    if (string.IsNullOrEmpty(row["EMP_PHOTO"].ToString()) == true)
                    {
                        imageUrl = "http://avighnatechnology.com/images/shikesh.png";
                    }
                    else
                    {
                        byte[] bytes = (byte[])row["EMP_PHOTO"];
                        string strBase64 = Convert.ToBase64String(bytes);
                        imageUrl = "data:Image/png;base64," + strBase64;
                    }
                    var birth = Convert.ToDateTime(row["EMP_DOB"].ToString());
                    var birthMonth = birth.ToString("MMMM");
                    var birthDate = birth.ToString("dd");
                    var dayLeft = int.Parse(birthDate) - int.Parse(todayDateOnly);
                    if (todayMonthOnly == birthMonth)
                    {
                        if (todayDateOnly == birthDate)
                        {
                            happyBirthday = "Happy Birthday !!!";
                        }
                        else
                        {
                            if (dayLeft == 1)
                            {
                                happyBirthday = dayLeft + " day left";
                            }
                            else
                            {
                                happyBirthday = dayLeft + " days left";
                            }
                        }
                    }
                    var foreachloopStack = "<div class='inbox-item'><div class='inbox-item-img'><img src='" + imageUrl + "' class='img-circle' alt=''></div><p class='inbox-item-author'>" + row["emp_Fullname"].ToString() + "</p><p class='inbox-item-text'>" + happyBirthday + "</p><p class='inbox-item-date'>" + birthDate + " " + birthMonth + "</p></div>";
                    stack = stack + foreachloopStack;
                }
                birthdays.Text = stack;
                //********************************* Getting Birthdays *********************************

                //********************************* Getting Contract *********************************
                DataTable dt1 = blu.contractPeriod();
                var contractstack = "";
                var Datedif = "";

                foreach (DataRow row in dt1.Rows)
                {
                    if (string.IsNullOrEmpty(row["EMP_PHOTO"].ToString()) == true)
                    {
                        imageUrl = "http://avighnatechnology.com/images/shikesh.png";
                    }
                    else
                    {
                        byte[] bytes = (byte[])row["EMP_PHOTO"];
                        string strBase64 = Convert.ToBase64String(bytes);
                        imageUrl = "data:Image/png;base64," + strBase64;
                    }
                    var contractExpiryDate = row["contractExpiryDate"].ToString();
                    var date = Convert.ToDateTime(contractExpiryDate).ToShortDateString();
                    int dateDifference = Convert.ToInt32(row["Datedifference"].ToString());
                    if (dateDifference > 0)
                    {
                        Datedif = row["Datedifference"].ToString() + " " + "days left";
                    }
                    else
                    {
                        Datedif = Convert.ToInt32(row["Datedifference"].ToString()) * -1 + " " + "days Ago";
                    }
                    var foreachloopStack = "<div class='inbox-item'><div class='inbox-item-img'><img src='" + imageUrl + "' class='img-circle' alt=''></div><p class='inbox-item-author'>" + row["emp_Fullname"].ToString() + "</p><p class='inbox-item-text'>" + Datedif + "</p><p class='inbox-item-date'>" + date + "</p></div>";
                    contractstack = contractstack + foreachloopStack;
                }
                tblContract.Text = contractstack;
                //********************************* Getting Contract *********************************
                //********************************* Getting Probation *********************************

                dtTableData = blu.queryFunction("SELECT EMP_ID, emp_photo, emp_Fullname, EMP_PCOUNTRY, EMP_JOINDATE, DATEADD(day,180, EMP_JOINDATE) as probationDate, DATEDIFF(day,  GETDATE(), DATEADD(day,180, EMP_JOINDATE)) as Datedifference FROM view_emp_info where MODE_ID = 6 and status_id = 1 ORDER BY Datedifference ASC");
                var probationStack = "";
                var Datediff = "";

                foreach (DataRow row in dtTableData.Rows)
                {
                    if (string.IsNullOrEmpty(row["EMP_PHOTO"].ToString()) == true)
                    {
                        imageUrl = "http://avighnatechnology.com/images/shikesh.png";
                    }
                    else
                    {
                        byte[] bytes = (byte[])row["EMP_PHOTO"];
                        string strBase64 = Convert.ToBase64String(bytes);
                        imageUrl = "data:Image/png;base64," + strBase64;
                    }
                    var probationDate = row["EMP_JOINDATE"].ToString();
                    var date = Convert.ToDateTime(probationDate).ToShortDateString();
                    int dateDifference = Convert.ToInt32(row["Datedifference"].ToString());
                    if (dateDifference > 0)
                    {
                        Datediff = row["Datedifference"].ToString() + " " + "days left";
                    }
                    else
                    {
                        Datediff = Convert.ToInt32(row["Datedifference"].ToString()) * -1 + " " + "days Ago";
                    }
                    var foreachloopStack = "<div class='inbox-item'><div class='inbox-item-img'><img src='" + imageUrl + "' class='img-circle' alt=''></div><p class='inbox-item-author'>" + row["emp_Fullname"].ToString() + "</p><p class='inbox-item-text'>" + Datediff + "</p><p class='inbox-item-date'>" + date + "</p></div>";
                    probationStack = probationStack + foreachloopStack;
                }
                tblProbabtion.Text = probationStack;
            }

            //********************************* Getting Probation *********************************
        }

        [WebMethod]
        public static List<List<string>> pieChartData()
        {
            DataTable dtPieChartData = attendanceObject.queryFunction("EXECUTE Barchart_info B");
            int count = dtPieChartData.Rows.Count;
            List<string> name = new List<string>();
            List<string> quantity = new List<string>();
            foreach (DataRow value in dtPieChartData.Rows)
            {
                name.Add(value["branch_name"].ToString());
                quantity.Add(value["totalemp"].ToString());
            }
            List<List<string>> data = new List<List<string>>();
            data.Add(name);
            data.Add(quantity);
            return data;
        }
    }
}