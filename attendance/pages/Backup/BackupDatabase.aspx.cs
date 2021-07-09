using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Backup
{
    public partial class BackupDatabase : System.Web.UI.Page
    {
        attendance blu = new attendance();
        public string dbName
        {

            get
            {

                return blu.dbName();
            }
        }
        public string backupPath
        {

            get
            {

                return blu.backupPath();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            string backupDestination = backupPath;
            string backUpInfo = "Database BackUp To" + " " + backupDestination;
            string dbNAme = dbName;
            int j = blu.BackupDatabase(backupDestination, dbNAme);
            if (j > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done. !!!',' " + backUpInfo + "','success').then((value) => { window.location ='Dashboard'; });", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Error!','Database Backup Failed.','warning')", true);
            }
        }
    }
}