using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace attendance.pages.systemSetup.company {
    public partial class company : System.Web.UI.Page {

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

            pageNamePlace1.Text = "Company";
            pageNamePlace2.Text = "Company";
            if (!IsPostBack) {

                DataTable dtCompany = attendanceObject.company();
                companyNameForm.Value = dtCompany.Rows[0]["Org_Name"].ToString();
                address1Form.Value = dtCompany.Rows[0]["Org_Address"].ToString();
                address2Form.Value = dtCompany.Rows[0]["Org_Address2"].ToString();
                telephoneForm.Value = dtCompany.Rows[0]["Org_Phone"].ToString();
                faxForm.Value = dtCompany.Rows[0]["Org_Fax"].ToString();
                emailForm.Value = dtCompany.Rows[0]["Org_Email"].ToString();
                websiteForm.Value = dtCompany.Rows[0]["Org_Website"].ToString();
            }
        }

        protected void saveClick(object sender, EventArgs e) {

            string companyName = companyNameForm.Value;
            string address1 = address1Form.Value;
            string address2 = address2Form.Value;
            string telephone = telephoneForm.Value;
            string fax = faxForm.Value;
            string email = emailForm.Value;
            string website = websiteForm.Value;
            attendanceObject.saveCompany(companyName, address1, address2, telephone, fax, email, website);
        }
    }
}