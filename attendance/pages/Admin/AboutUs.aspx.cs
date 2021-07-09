using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance.pages.Admin
{
    public partial class AboutUs : System.Web.UI.Page
    {
        attendance blu = new attendance();
        public string AdminName
        {
            get
            {
                return blu.AdminName();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable dt = blu.getAdmininfo();
                companyNameForm.Value = dt.Rows[0]["name"].ToString();
                address1Form.Value = dt.Rows[0]["address1"].ToString();
                address2Form.Value = dt.Rows[0]["address2"].ToString();
                telephone1Form.Value = dt.Rows[0]["contact1"].ToString();
                telephone2Form.Value = dt.Rows[0]["contact2"].ToString();
                telephone3Form.Value = dt.Rows[0]["contact3"].ToString();
                email1Form.Value = dt.Rows[0]["email1"].ToString();
                email2Form.Value = dt.Rows[0]["email2"].ToString();
                faxForm.Value = dt.Rows[0]["fax"].ToString();
                websiteForm.Value = dt.Rows[0]["website"].ToString();
                fullNameForm.Value = dt.Rows[0]["fullname"].ToString();

            }
        }

        protected void saveClick(object sender, EventArgs e)
        {
            string name = companyNameForm.Value;
            string address1 = address1Form.Value;
            string address2 = address2Form.Value;
            string contact1 = telephone1Form.Value;
            string contact2 = telephone2Form.Value;
            string contact3 = telephone3Form.Value;
            string fax = faxForm.Value;
            string email1 = email1Form.Value;
            string email2 = email2Form.Value;
            string website = websiteForm.Value;
            string fullName = fullNameForm.Value;
            blu.saveAdminInfo(name, address1, address2, contact1, contact2, contact3, fax, email1, email2, website, fullName);
        }
    }
}