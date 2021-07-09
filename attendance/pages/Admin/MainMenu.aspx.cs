using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Admin
{
    public partial class MainMenu : System.Web.UI.Page
    {
        attendance blu = new attendance();
        static attendance staticblu = new attendance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable dt = blu.getMainMenu();
                string tableBodyRow = "";
                int i = 1;
                foreach (DataRow value in dt.Rows)
                {

                    tableBodyRow += "<tr>";
                    tableBodyRow += "<td>" + i + "</td>";
                    tableBodyRow += "<td>" + value["title"] + "</td>";
                    tableBodyRow += "<td>" + value["url"] + "</td>";
                    tableBodyRow += "<td>" + value["iconclass"] + "</td>";

                    if (Convert.ToInt32(value["subMenu"]) == 0)
                    {

                        tableBodyRow += "<td> NO </td>";
                    }
                    else
                    {

                        tableBodyRow += "<td> YES </td>";
                    }
                    if (Convert.ToInt32(value["status"]) == 0)
                    {
                        tableBodyRow += "<td><div class='button-list'><a ID='" + value["id"] + "' class='qwe btn btn-danger btn-rounded waves-effect w-md waves-light'> <span>Inactive </span></a></div></td>";
                    }
                    else
                    {
                        tableBodyRow += "<td><div class='button-list'><a ID='" + value["id"] + "' class='qwe btn btn-success btn-rounded w-md waves-effect waves-light'> <span>Active </span></a></div></td>";
                    }
                    tableBodyRow +=
                        "<td><div class='button-list'><a ID='" + value["id"] + "' menuname ='" + value["title"] + "' data-toggle='modal' data-target='#con-close-modal' class='edit btn btn-warning btn-rounded w-xs waves-effect waves-light'><i class='mdi mdi-pencil'></i> <span>Edit </span></a>   <a ID='" + value["id"] + "' menuname ='" + value["title"] + "' data-toggle='modal' data-target='#con-close' class='submenu btn btn-primary btn-rounded w-xs waves-effect waves-light'> <span>Sub Menu </span></a></div></td>";
                    tableBodyRow += "</tr>";
                    i++;
                }
                tableBody.Text = tableBodyRow;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (titleNameForm.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!',' Field Cannot be Blanked.','warning')", true);
            }
            else if (iconNameForm.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Icon Field Cannot be Blanked.','warning')", true);
            }
            else if (subMenuYesForm.Checked)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','URL Field Cannot be Blanked.','warning')", true);
            }
            else
            {
                int id = 1;
                string titleName = titleNameForm.Value;
                string url = urlNameForm.Value;
                string iconName = iconNameForm.Value;
                int subMenu;
                if (subMenuYesForm.Checked)
                {
                    subMenu = 1;
                }
                else
                {
                    subMenu = 0;
                }
                int sortOrder = Convert.ToInt16(sortOrderForm.Value);
                int status;
                if (statusYesForm.Checked)
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                int j = blu.mainMenu(id, titleName, url, iconName, sortOrder, subMenu, status);
                if (j > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done. !!!','Menu List Added Successful.','success').then((value) => { window.location ='MainMenu'; });", true);
                }
            }

        }

        [WebMethod]
        public static int changeStatus(int id)
        {
            DataTable dt = staticblu.changestatus(id);
            return 1;
        }

        [WebMethod]
        public static string[] getMenuById(int id)
        {
            DataTable dt = staticblu.getMenuById(id);
            int count = dt.Rows.Count;
            string[] array = new string[count];
            int i = 0;
            foreach (DataRow value in dt.Rows)
            {

                array[i] = value["id"] + "./." + value["title"] + "./." + value["url"] + "./." + value["iconClass"] + "./." + value["sortOrderNumber"] + "./." + value["subMenu"] + "./." + value["status"];
                i++;
            }
            return array;
        }

        

        [WebMethod]
        public static List<Dictionary<string, object>> getSubMenuById(int id)
        {
            DataTable dtTableDataById = staticblu.sidebarSubMenu1(id);

            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (DataRow dataTableRow in dtTableDataById.Rows)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (DataColumn tableColumn in dtTableDataById.Columns)
                {
                    dic.Add(tableColumn.ColumnName, dataTableRow[tableColumn]);
                }
                data.Add(dic);
            }
            return data;
        }

        [WebMethod]
        public static List<Dictionary<string, object>> sidebarSubMenu2(int id)
        {
            DataTable dtTableDataById = staticblu.subMenu2(id);

            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            foreach (DataRow dataTableRow in dtTableDataById.Rows)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                foreach (DataColumn tableColumn in dtTableDataById.Columns)
                {
                    dic.Add(tableColumn.ColumnName, dataTableRow[tableColumn]);
                }
                data.Add(dic);
            }
            return data;
        }
    }
}