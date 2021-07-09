using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Admin
{
    public partial class SubMenu : System.Web.UI.Page
    {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int menuid = Convert.ToInt32(Request.QueryString["b80bb7740288fda1f201890375a60c8f"].ToString());
                DataTable dtname = blu.getMenuName(menuid);
                page_name.Text = dtname.Rows[0]["title"].ToString();
                DataTable dt = blu.getSubMenu(menuid);
                if(dt.Rows.Count > 0)
                {                    
                    string tableBodyRow = "";
                    int j = 1;
                    foreach (DataRow value in dt.Rows)
                    {

                        tableBodyRow += "<tr>";
                        tableBodyRow += "<td>" + j + "</td>";
                        tableBodyRow += "<td>" + value["title"] + "</td>";
                        tableBodyRow += "<td>" + value["url"] + "</td>";
                       
                        if (Convert.ToInt32(value["subMenu"]) == 0)
                        {
                            tableBodyRow += "<td> NO </td>";
                        }
                        else
                        {
                            tableBodyRow += "<td> YES </td>";
                        }
                        tableBodyRow += "<td style='text-align:center'><div class='button-list'><a href='SubMenuEdit?b80bb7740288fda1f201890375a60c8f=" + value["id"] + "' class='btn btn-warning w-xs waves-effect waves-light btn-xs'><i class='mdi mdi-pencil'></i> <span>Edit </span></a> <a href='SubSubMenu?b80bb7740288fda1f201890375a60c8f=" + value["id"] + "' class='btn btn-primary w-xs waves-effect waves-light btn-xs'> <span>Sub Menu </span></a></div></td>";
                        tableBodyRow += "</tr>";
                        j++;
                    }
                    tableBody.Text = tableBodyRow;
                }                
            }
        }
    }
}