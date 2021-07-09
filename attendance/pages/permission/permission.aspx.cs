using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

namespace attendance.pages.permission {
    public partial class permission : System.Web.UI.Page {

        attendance attendanceObject = new attendance();
        static attendance staticAttendanceObject = new attendance();

        public string baseUrl {

            get {

                return attendanceObject.baseUrl();
            }
        }

        public string projectName {

            get {

                return attendanceObject.projectName();
            }
        }

        protected void Page_Load(object sender, EventArgs e) {

            pageNamePlace1.Text = "Edit Permission";
            pageNamePlace2.Text = "Edit Permission";
            if (!IsPostBack) {

                DataTable dtEmployeeList = attendanceObject.employeeList(0);

                empForm.DataSource = dtEmployeeList;
                empForm.DataTextField = "EMP_FULLNAME";
                empForm.DataValueField = "EMP_ID";
                empForm.DataBind();
                empForm.Items.Insert(0, new ListItem("Select Employee", ""));

                DataTable dataTableMenuList = attendanceObject.menuList();
                string menuDiv = "<div class='col-sm-offset-2 col-sm-10'><ul class='list-unstyled'>";
                foreach (DataRow value in dataTableMenuList.Rows) {

                    if (Convert.ToInt32(value["subMenu"]) == 1) {

                        menuDiv += "<li class='has_sub'>";
                        menuDiv += "<div class='checkbox'><input id='" + value["id"] + "' type='checkbox' class='parent'><label for='" + value["id"] + "'>" + value["title"] + "</label></div>";
                        DataTable dataTableSubMenu1 = attendanceObject.subMenu1(Convert.ToInt32(value["id"]));
                        menuDiv += "<ul class='list-unstyled'>";
                        foreach (DataRow value2 in dataTableSubMenu1.Rows) {

                            if (Convert.ToInt32(value2["subMenu"]) == 1) {

                                menuDiv += "<li class='has_sub'>";
                                menuDiv += "<div class='checkbox' style='margin-left: 25px;'><input id='" + value["id"] + '.' + value2["id"] + "' type='checkbox' class='child1Gen'><label for='" + value["id"] + '.' + value2["id"] + "'>" + value2["title"] + "</label></div>";
                                DataTable dataTableSubMenu2 = attendanceObject.sidebarSubMenu2(Convert.ToInt32(value2["id"]));
                                menuDiv += "<ul class='list-unstyled'>";
                                foreach (DataRow value3 in dataTableSubMenu2.Rows) {

                                    menuDiv += "<li><div class='checkbox' style='margin-left: 50px;'><input id='" + value["id"] + '.' + value2["id"] + '.' + value3["id"] + "' type='checkbox' class='child2Gen'><label for='" + value["id"] + '.' + value2["id"] + '.' + value3["id"] + "'>" + value3["title"] + "</label></div></li>";
                                }
                                menuDiv += "</ul></li>";
                            } else {

                                menuDiv += "<li><div class='checkbox' style='margin-left: 25px;'><input id='" + value["id"] + '.' + value2["id"] + "' type='checkbox' class='child1Gen'><label for='" + value["id"] + '.' + value2["id"] + "'>" + value2["title"] + "</label></div></li>";
                            }
                        }
                        menuDiv += "</ul></li>";
                    } else {

                        menuDiv += "<li><div class='checkbox'><input id='" + value["id"] + "' type='checkbox'><label for='" + value["id"] + "'>" + value["title"] + "</label></div></li>";
                    }
                }
                menuDiv += "</ul></li><ul></div>";
                menuList.Text = menuDiv;
            }
        }

        protected void saveClick(object sender, EventArgs e) {

        }

        [WebMethod]
        public static string getPermissionById(int empId) {

            string menuDiv = "";
            DataTable dataTablePermission = staticAttendanceObject.permission(empId);
            int countPermission = dataTablePermission.Rows.Count;
            DataTable dataTableMenuList = staticAttendanceObject.menuList();
            string[] permission;
            string check = "";
            string dotValue;
            if (countPermission == 0) {

                menuDiv = "<div class='col-sm-offset-2 col-sm-10'><ul class='list-unstyled'>";
                foreach (DataRow value in dataTableMenuList.Rows) {

                    if (Convert.ToInt32(value["subMenu"]) == 1) {

                        menuDiv += "<li class='has_sub'>";
                        menuDiv += "<div class='checkbox'><input id='" + value["id"] + "' type='checkbox' class='parent'><label for='" + value["id"] + "'>" + value["title"] + "</label></div>";
                        DataTable dataTableSubMenu1 = staticAttendanceObject.subMenu1(Convert.ToInt32(value["id"]));
                        menuDiv += "<ul class='list-unstyled'>";
                        foreach (DataRow value2 in dataTableSubMenu1.Rows) {

                            if (Convert.ToInt32(value2["subMenu"]) == 1) {

                                menuDiv += "<li class='has_sub'>";
                                menuDiv += "<div class='checkbox' style='margin-left: 25px;'><input id='" + value["id"] + '.' + value2["id"] + "' type='checkbox' class='child1Gen'><label for='" + value["id"] + '.' + value2["id"] + "'>" + value2["title"] + "</label></div>";
                                DataTable dataTableSubMenu2 = staticAttendanceObject.sidebarSubMenu2(Convert.ToInt32(value2["id"]));
                                menuDiv += "<ul class='list-unstyled'>";
                                foreach (DataRow value3 in dataTableSubMenu2.Rows) {

                                    menuDiv += "<li><div class='checkbox' style='margin-left: 50px;'><input id='" + value["id"] + '.' + value2["id"] + '.' + value3["id"] + "' type='checkbox' class='child2Gen'><label for='" + value["id"] + '.' + value2["id"] + '.' + value3["id"] + "'>" + value3["title"] + "</label></div></li>";
                                }
                                menuDiv += "</ul></li>";
                            } else {

                                menuDiv += "<li><div class='checkbox' style='margin-left: 25px;'><input id='" + value["id"] + '.' + value2["id"] + "' type='checkbox' class='child1Gen'><label for='" + value["id"] + '.' + value2["id"] + "'>" + value2["title"] + "</label></div></li>";
                            }
                        }
                        menuDiv += "</ul></li>";
                    } else {

                        menuDiv += "<li><div class='checkbox'><input id='" + value["id"] + "' type='checkbox'><label for='" + value["id"] + "'>" + value["title"] + "</label></div></li>";
                    }
                }
                menuDiv += "</ul></li><ul></div>";
            } else {

                menuDiv = "<div class='col-sm-offset-2 col-sm-10'><ul class='list-unstyled'>";
                permission = dataTablePermission.Rows[0]["permission"].ToString().Split('/');
                foreach (DataRow value in dataTableMenuList.Rows) {

                    if (Convert.ToInt32(value["subMenu"]) == 1) {

                        foreach (string val in permission) {

                            string[] idOnOff = val.Split('=');
                            if (value["id"].ToString() == idOnOff[0]) {

                                if (idOnOff[1] == "on") {

                                    check = "checked='checked'";
                                }
                            }
                        }
                        menuDiv += "<li class='has_sub'>";
                        menuDiv += "<div class='checkbox'><input id='" + value["id"] + "' type='checkbox' " + check + "><label for='" + value["id"] + "'>" + value["title"] + "</label></div>";
                        check = "";
                        DataTable dataTableSubMenu1 = staticAttendanceObject.subMenu1(Convert.ToInt32(value["id"]));
                        menuDiv += "<ul class='list-unstyled'>";
                        foreach (DataRow value2 in dataTableSubMenu1.Rows) {

                            if (Convert.ToInt32(value2["subMenu"]) == 1) {

                                foreach (string val in permission) {

                                    string[] idOnOff = val.Split('=');
                                    dotValue = value["id"] + "." + value2["id"];
                                    if (dotValue == idOnOff[0]) {

                                        if (idOnOff[1] == "on") {

                                            check = "checked='checked'";
                                        }
                                    }
                                }
                                dotValue = "";
                                menuDiv += "<li class='has_sub'>";
                                menuDiv += "<div class='checkbox' style='margin-left: 25px;'><input id='" + value["id"] + '.' + value2["id"] + "' type='checkbox' " + check + "><label for='" + value["id"] + '.' + value2["id"] + "'>" + value2["title"] + "</label></div>";
                                check = "";
                                DataTable dataTableSubMenu2 = staticAttendanceObject.sidebarSubMenu2(Convert.ToInt32(value2["id"]));
                                menuDiv += "<ul class='list-unstyled'>";
                                foreach (DataRow value3 in dataTableSubMenu2.Rows) {

                                    foreach (string val in permission) {

                                        string[] idOnOff = val.Split('=');
                                        dotValue = value["id"] + "." + value2["id"] + "." + value3["id"];
                                        if (dotValue == idOnOff[0]) {

                                            if (idOnOff[1] == "on") {

                                                check = "checked='checked'";
                                            }
                                        }
                                    }
                                    dotValue = "";
                                    menuDiv += "<li><div class='checkbox' style='margin-left: 50px;'><input id='" + value["id"] + '.' + value2["id"] + '.' + value3["id"] + "' type='checkbox' " + check + "><label for='" + value["id"] + '.' + value2["id"] + '.' + value3["id"] + "'>" + value3["title"] + "</label></div></li>";
                                    check = "";
                                }
                                menuDiv += "</ul></li>";
                            } else {

                                foreach (string val in permission) {

                                    string[] idOnOff = val.Split('=');
                                    dotValue = value["id"] + "." + value2["id"];
                                    if (dotValue == idOnOff[0]) {

                                        if (idOnOff[1] == "on") {

                                            check = "checked='checked'";
                                        }
                                    }
                                }
                                dotValue = "";
                                menuDiv += "<li><div class='checkbox' style='margin-left: 25px;'><input id='" + value["id"] + '.' + value2["id"] + "' type='checkbox' " + check + "><label for='" + value["id"] + '.' + value2["id"] + "'>" + value2["title"] + "</label></div></li>";
                                check = "";
                            }
                        }
                        menuDiv += "</ul></li>";
                    } else {

                        foreach (string val in permission) {

                            string[] idOnOff = val.Split('=');
                            if (value["id"].ToString() == idOnOff[0]) {

                                if (idOnOff[1] == "on") {

                                    check = "checked='checked'";
                                }
                            }
                        }
                        menuDiv += "<li><div class='checkbox'><input id='" + value["id"] + "' type='checkbox' " + check + "><label for='" + value["id"] + "'>" + value["title"] + "</label></div></li>";
                        check = "";
                    }
                }
                menuDiv += "</ul></li><ul></div>";
            }
            return menuDiv;
        }

        [WebMethod]
        public static string[] getMenuList() {

            DataTable dataTableSidebarMenu = staticAttendanceObject.menuList();
            int count = dataTableSidebarMenu.Rows.Count;
            string[] array = new string[count];
            int i = 0;
            foreach (DataRow value in dataTableSidebarMenu.Rows) {

                array[i] = value["id"] + "./." + value["title"];
                i++;
            }
            return array;
        }

        [WebMethod]
        public static string savePermission(string obj) {
            int empId = Convert.ToInt32(HttpContext.Current.Session["userid"]);;
            string dateTime = DateTime.Now.ToString();
            string[] splitObj = obj.Split('+');
            string permission = splitObj[1].ToString();
            if (empId != 99999)
            {
                empId = Convert.ToInt32(splitObj[0]);
            }
            staticAttendanceObject.savePermission(permission, dateTime, empId);
            return dateTime;
        }
    }
}