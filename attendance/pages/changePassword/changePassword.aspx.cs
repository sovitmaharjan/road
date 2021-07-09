using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.changePassword {
    public partial class changePassword : System.Web.UI.Page {

        attendance blu = new attendance();
        int EMP_ID = 0;
        string password, oldPassword, newPassword, confirmPassword;
        protected void Page_Load(object sender, EventArgs e) {

            EMP_ID = Convert.ToInt32(Session["userId"].ToString());
            password = Session["password"].ToString();

        }

        protected void BtnSave_Click(object sender, EventArgs e) {
            oldPassword = TxtOldPass.Text;
            newPassword = TxtNewPass.Text;
            confirmPassword = TxtConPass.Text;
            if (oldPassword == "") {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Old Password cannot be Emptied, Try Again !!!','warning')", true);
            } else if (password != oldPassword) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Wrong  Old Password, Try Again !!!','warning')", true);

            } else if (newPassword == "") {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','New Password cannot be Emptied, Try Again !!!','warning')", true);

            } else if (newPassword == oldPassword) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','New Password cannot be same as Old, Try Again !!!','warning')", true);
            } else if (confirmPassword == "") {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Confirm Password cannot be Emptied, Try Again !!!','warning')", true);
            } else if (newPassword != confirmPassword) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscipt", "swal('Ooops!','Passwords dont match, Try Again !!!','warning')", true);
            } else {
                int j = blu.updatePassword(EMP_ID, newPassword);
                if (j > 0) {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Done','Password Updated Successfully','success').then((value) => { window.location ='Login'; });", true);
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e) {
            Response.Redirect("changePassword");
        }
    }
}