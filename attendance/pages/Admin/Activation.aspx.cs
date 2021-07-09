using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Admin
{
    public partial class Activation : System.Web.UI.Page
    {
        attendance blu = new attendance();
        string dt;
        string encryptDate;
        string decryptDate;
        string encryptAddress;

        public string baseUrl
        {
            get
            {
                return blu.baseUrl();
            }
        }

        public string projectName
        {
            get
            {
                return blu.projectName();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtActivate = blu.checkActivation();
            if (dtActivate.Rows.Count > 0)
            {
                string macAddress = blu.GetMACAddress();
                string HardwareId = dtActivate.Rows[0]["HardwareId"].ToString();
                HardwareId = HardwareId.Replace(" ", String.Empty);
                if (macAddress == HardwareId)
                {
                    btnActivate.Visible = false;
                    txtHardwareId.Text = dtActivate.Rows[0]["HardwareID"].ToString();
                    txtserialKey.Text = dtActivate.Rows[0]["ActivationID"].ToString();
                    LicenseDate.Text = blu.DecryptString(dtActivate.Rows[0]["L_Date"].ToString());

                    double days = Convert.ToDouble(blu.DecryptString(dtActivate.Rows[0]["L_D"].ToString()));
                    if (days == 0.0)
                    {
                        expiryDate.Text = LicenseDate.Text;
                    }
                    else
                    {
                        expiryDate.Text = DateTime.Now.AddDays(days).ToString("yyyy-MM-dd");
                    }

                    string activationPeriod = blu.DecryptString(dtActivate.Rows[0]["LID"].ToString());

                    if (activationPeriod == "1")
                    {
                        demo.Checked = true;
                        one.Disabled = true;
                        two.Disabled = true;
                        four.Disabled = true;
                    }
                    else if (activationPeriod == "2")
                    {
                        demo.Disabled = true;
                        one.Checked = true;
                        two.Disabled = true;
                        four.Disabled = true;
                    }
                    else if (activationPeriod == "3")
                    {
                        demo.Disabled = true;
                        one.Disabled = true;
                        two.Checked = true;
                        four.Disabled = true;
                    }
                    else
                    {
                        demo.Disabled = true;
                        one.Disabled = true;
                        two.Disabled = true;
                        four.Checked = true;
                    }
                }
                else
                {
                    dt = blu.GetMACAddress();
                    txtHardwareId.Text = dt;
                    encryptAddress = blu.EncryptString(dt);
                    txtserialKey.Text = encryptAddress;


                    DateTime tdate = DateTime.Now;
                    string date = tdate.ToShortDateString();
                    LicenseDate.Text = date;

                    encryptDate = blu.EncryptString(date);
                    decryptDate = blu.DecryptString(encryptDate);

                    expiryDate.Visible = false;
                    lblexp.Visible = false;
                }
            }
            else
            {
                dt = blu.GetMACAddress();
                txtHardwareId.Text = dt;
                encryptAddress = blu.EncryptString(dt);
                txtserialKey.Text = encryptAddress;


                DateTime tdate = DateTime.Now;
                string date = tdate.ToShortDateString();
                LicenseDate.Text = date;

                encryptDate = blu.EncryptString(date);
                decryptDate = blu.DecryptString(encryptDate);

                expiryDate.Visible = false;
                lblexp.Visible = false;
            }
        }


        string period;
        string day;
        protected void Activate_Click(object sender, EventArgs e)
        {
            string macAddress = txtHardwareId.Text;
            string serialkey = txtserialKey.Text;

            if (demo.Checked)
            {
                period = "1";
                day = "30";
            }
            else if (one.Checked)
            {
                period = "2";
                day = "90";
            }
            else if (two.Checked)
            {
                period = "3";
                day = "180";
            }
            else
            {
                period = "0";
                day = "365";
            }
            string encryptPeriod = blu.EncryptString(period);
            string encryptDay = blu.EncryptString(day);

            int j = blu.Activate(dt, serialkey, encryptPeriod, encryptDate, encryptDay);
            if (j > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Software Activated Successfully').then((value) => { window.location ='Activation'; });", true);
            }


        }
    }
}