using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace attendance.pages.hrManagement.employee
{
    public partial class viewDetail : System.Web.UI.Page
    {
        attendance blu = new attendance();
        string encryptedId;
        protected void Page_Load(object sender, EventArgs e)
        {
            encryptedId = Request.QueryString["EMP_ID"].ToString();
            string asdsa = blu.DecryptString(encryptedId);
            int empIdd = int.Parse(asdsa);
            DataTable dt6 = blu.getAllInfo(empIdd);
            DataSet ds = blu.LoadPhoto(empIdd);
            int c = ds.Tables[0].Rows.Count;
            foreach (DataRow row in ds.Tables["Photo"].Rows)
            {
                if (ds.Tables["Photo"].Rows.Count > 0)
                {
                    byte[] bytedata = new byte[0];
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                        bytedata = (byte[])(ds.Tables[0].Rows[0][0]);
                        MemoryStream stmphoto = new MemoryStream(bytedata);
                        string PROFILE_PIC = Convert.ToBase64String(bytedata);
                        PersImage.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);
                    }
                    else
                    {
                        PersImage.ImageUrl = "http://avighnatechnology.com/images/dummy.jpg";
                    }
                }
                else
                {
                    PersImage.ImageUrl = null;
                }
            }
            ds.Tables.Clear();

            DataTable dt = blu.getPid(empIdd);
            int pid = Convert.ToInt32(dt.Rows[0]["PID"].ToString());

            DataTable dtl = blu.getEmpLeave(pid);//for leave management
            grvLeave.DataSource = dtl;
            grvLeave.DataBind();


            lblname.Text = dt6.Rows[0]["emp_Fullname"].ToString();
            lblgender.Text = dt6.Rows[0]["GENDER"].ToString();
            Label15.Text = dt6.Rows[0]["maritalstatus"].ToString();
            Label7.Text = dt6.Rows[0]["EMP_PCOUNTRY"].ToString();
            if (dt6.Rows[0]["EMP_PEMAIL"].ToString() == "")
            {
                lblemail.Text = "N/A";
            }
            else
            {

                lblemail.Text = dt6.Rows[0]["EMP_PEMAIL"].ToString();
            }
            DateTime result = Convert.ToDateTime(dt6.Rows[0]["EMP_DOB"].ToString());
            lbldob.Text = result.ToString("yyyy-MM-dd");
            DateTime result1 = Convert.ToDateTime(dt6.Rows[0]["EMP_JOINDATE"].ToString());
            lbldate.Text = result1.ToString("yyyy-MM-dd");
            Label19.Text = dt6.Rows[0]["EMP_MOBILE"].ToString();
            Label23.Text = dt6.Rows[0]["EMP_PHONE"].ToString();
            Label26.Text = dt6.Rows[0]["BLOOD_GROUP"].ToString();
            Label28.Text = dt6.Rows[0]["EMP_MOTHER"].ToString();
            Label30.Text = dt6.Rows[0]["EMP_FATHER"].ToString();
            Label32.Text = dt6.Rows[0]["EMP_SPOUSE"].ToString();
            Label34.Text = dt6.Rows[0]["EMP_GRANDFATHER"].ToString();
            Label38.Text = dt6.Rows[0]["EMP_CHILDREN1"].ToString();
            Label40.Text = dt6.Rows[0]["EMP_CHILDREN2"].ToString();
            Label42.Text = dt6.Rows[0]["NAME"].ToString();
            Label44.Text = dt6.Rows[0]["RELATION"].ToString();
            Label46.Text = dt6.Rows[0]["CONTACT"].ToString();
            Label48.Text = dt6.Rows[0]["PStateName"].ToString();
            Label50.Text = dt6.Rows[0]["PDistrictName"].ToString();
            Label52.Text = dt6.Rows[0]["emp_pcity"].ToString();
            Label54.Text = dt6.Rows[0]["EMP_PMUNICIPALTY"].ToString();
            Label56.Text = dt6.Rows[0]["EMP_PWARD"].ToString();
            Label58.Text = dt6.Rows[0]["EMP_PTOLE"].ToString();
            Label60.Text = dt6.Rows[0]["TStateName"].ToString();
            Label62.Text = dt6.Rows[0]["TDistrictName"].ToString();
            Label64.Text = dt6.Rows[0]["emp_Tcity"].ToString();
            Label66.Text = dt6.Rows[0]["EMP_TMUNICIPALTY"].ToString();
            Label68.Text = dt6.Rows[0]["EMP_TWARD"].ToString();
            Label70.Text = dt6.Rows[0]["EMP_TTOLE"].ToString();
            string doc_type = dt6.Rows[0]["EMP_DOCTYPE"].ToString();
            if (doc_type == "C")
            {
                Label72.Text = "Citizenship";
                Label73.Text = "Number";
                Label74.Text = dt6.Rows[0]["EMP_CITIZENSHIPNO"].ToString();
                Label75.Text = "Place Issued";
                Label76.Text = dt6.Rows[0]["EMP_CITIZENSHIP_ISSUED"].ToString();
                Label77.Text = "Issued Date";
                Label78.Text = dt6.Rows[0]["EMP_CITIZENSHIPDATE"].ToString();
            }
            else if (doc_type == "P")
            {
                Label72.Text = "Passport";
                Label73.Text = "Number";
                Label74.Text = dt6.Rows[0]["EMP_PASSPORT_NO"].ToString();
                Label75.Text = "Place Issued";
                Label76.Text = dt6.Rows[0]["EMP_PASSPORT_ISSUED"].ToString();
                Label77.Text = "Issued Date";
                Label78.Text = dt6.Rows[0]["EMP_PASSPORT_ISSUED_DATE"].ToString();
                Label79.Text = "Expiry Date";
                Label80.Text = dt6.Rows[0]["EMP_PASSPORT_EXPIRY_DATE"].ToString();
            }
            else
            {
                Label72.Text = "None";
            }


            lblusrid.Text = dt6.Rows[0]["login_id"].ToString();
            lblDeg.Text = dt6.Rows[0]["DEG_NAME"].ToString();
            lblType.Text = dt6.Rows[0]["MODE_NAME"].ToString();
            lblStatus.Text = dt6.Rows[0]["STATUS_NAME"].ToString();
            lbldept.Text = dt6.Rows[0]["DEPT_NAME"].ToString();
            lblbranch.Text = dt6.Rows[0]["BRANCH_NAME"].ToString();
            lblUsertype.Text = dt6.Rows[0]["TypeName"].ToString();
            lblSupervisor.Text = dt6.Rows[0]["HOD_NAME"].ToString();
            lblgrade.Text = dt6.Rows[0]["GRADE_NAME"].ToString();
            Label82.Text = dt6.Rows[0]["pf_number"].ToString();
            Label84.Text = dt6.Rows[0]["cit_number"].ToString();
            Label86.Text = dt6.Rows[0]["Social_Security"].ToString();
            Label88.Text = dt6.Rows[0]["epan_number"].ToString();
            Label90.Text = dt6.Rows[0]["bankAC"].ToString();
            Label92.Text = dt6.Rows[0]["OFFEMAIL"].ToString();
            if (dt6.Rows[0]["enable_web_login"].ToString() == "1")
            {
                Label36.Text = "Enabled";
            }
            else
            {
                Label36.Text = "Disabled";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("employeeList");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("editEmployee?EMP_ID=" + encryptedId);
        }
    }
}