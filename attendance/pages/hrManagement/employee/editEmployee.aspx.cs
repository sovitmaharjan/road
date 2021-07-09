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
    public partial class editEmployee : System.Web.UI.Page
    {
        attendance blu = new attendance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string encryptedId = Request.QueryString["EMP_ID"].ToString();
                encryptedId = encryptedId.Replace(" ", "+");
                string asdsa = blu.DecryptString(encryptedId);
                int empid = Convert.ToInt32(asdsa);
                //int empid = Convert.ToInt32( asdsa.Split('@')[1]);
                DataTable dta = blu.getAllInfo(empid);

                DataSet ds = blu.LoadPhoto(empid);////for image
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
                            ImgPersonal.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);
                        }
                        else
                        {
                            ImgPersonal.ImageUrl = null;
                        }
                    }
                    else
                    {
                        ImgPersonal.ImageUrl = null;
                    }
                }
                ds.Tables.Clear();

                txtEmployeeId.Text = empid.ToString();
                CmbSalutation.SelectedValue = dta.Rows[0]["title_id"].ToString();
                EMP_MIDDLENAME.Text = dta.Rows[0]["EMP_MIDDLENAME"].ToString();
                EMP_FIRSTNAME.Text = dta.Rows[0]["EMP_FIRSTNAME"].ToString();
                EMP_LASTNAME.Text = dta.Rows[0]["EMP_LASTNAME"].ToString();
                //txtStartDate.Text = dta.Rows[0]["EMP_DOB"].ToString();
                //txtJoindate.Text = dta.Rows[0]["EMP_JOINDATE"].ToString();
                txtMobile.Text = dta.Rows[0]["EMP_MOBILE"].ToString();
                txtTelephone.Text = dta.Rows[0]["EMP_PHONE"].ToString();
                CmbNationality.SelectedValue = dta.Rows[0]["EMP_PCOUNTRY"].ToString();
                CmbBloodGroup.SelectedValue = dta.Rows[0]["BLOOD_GROUP"].ToString();
                txtMotherName.Text = dta.Rows[0]["EMP_MOTHER"].ToString();
                txtFatherName.Text = dta.Rows[0]["EMP_FATHER"].ToString();
                txtSpouse.Text = dta.Rows[0]["EMP_SPOUSE"].ToString();
                txtGrandFather.Text = dta.Rows[0]["EMP_GRANDFATHER"].ToString();
                txtChildren1.Text = dta.Rows[0]["EMP_CHILDREN1"].ToString();
                txtChildren2.Text = dta.Rows[0]["EMP_CHILDREN2"].ToString();
                txtEmergName.Text = dta.Rows[0]["NAME"].ToString();
                txtEmergRelation.Text = dta.Rows[0]["RELATION"].ToString();
                txtEmergContact.Text = dta.Rows[0]["CONTACT"].ToString();
                CmbPState.SelectedValue = dta.Rows[0]["EMP_PSTATE"].ToString();

                DataTable dtPD = blu.getDistrict(Convert.ToInt32(dta.Rows[0]["EMP_PSTATE"].ToString()));
                CmbPDistrict.DataSource = dtPD;
                CmbPDistrict.DataTextField = "DistrictName";
                CmbPDistrict.DataValueField = "DistrictId";
                CmbPDistrict.DataBind();
                CmbPDistrict.SelectedValue = dta.Rows[0]["EMP_PDISTRICT"].ToString();
                txtPStreet.Text = dta.Rows[0]["EMP_PCITY"].ToString();
                txtPMuncipality.Text = dta.Rows[0]["EMP_PMUNICIPALTY"].ToString();
                txtPWARD.Text = dta.Rows[0]["EMP_PWARD"].ToString();
                txtPTOLE.Text = dta.Rows[0]["EMP_PTOLE"].ToString();
                CmbTState.SelectedValue = dta.Rows[0]["EMP_TSTATE"].ToString();

                string emp_tzone = dta.Rows[0]["EMP_TSTATE"].ToString();
                string emp_tdistrict = dta.Rows[0]["EMP_TDISTRICT"].ToString();
                DataTable dtTD = blu.getDistrict(Convert.ToInt32(dta.Rows[0]["EMP_TSTATE"].ToString()));
                CmbTDistrict.DataSource = dtTD;
                CmbTDistrict.DataTextField = "DistrictName";
                CmbTDistrict.DataValueField = "DistrictId";
                CmbTDistrict.DataBind();
                CmbTDistrict.SelectedValue = dta.Rows[0]["EMP_TDISTRICT"].ToString();
                txtTStreet.Text = dta.Rows[0]["EMP_TCITY"].ToString();
                txtTMuncipality.Text = dta.Rows[0]["EMP_TMUNICIPALTY"].ToString();
                txtTWard.Text = dta.Rows[0]["EMP_TWARD"].ToString();
                TxtTTOLE.Text = dta.Rows[0]["EMP_TTOLE"].ToString();

                if (dta.Rows[0]["EMP_DOCTYPE"].ToString() == "C")
                {
                    citizenship.Checked = true;
                    passport.Checked = false;
                    none.Checked = false;

                    lblCNumber.Visible = true;
                    txtCNumber.Visible = true;
                    txtCNumber.Text = dta.Rows[0]["EMP_CITIZENSHIPNO"].ToString();
                    lblDateIssued.Visible = true;
                    txtDateIssued.Visible = true;
                    txtDateIssued.Text = dta.Rows[0]["EMP_CITIZENSHIPDATE"].ToString();
                    lblPlaceIssued.Visible = true;
                    txtPlaceIssued.Visible = true;
                    txtPlaceIssued.Text = dta.Rows[0]["EMP_CITIZENSHIP_ISSUED"].ToString();

                    lblPNumber.Visible = false;
                    txtPNumber.Visible = false;
                    lblPIssued.Visible = false;
                    txtPIssued.Visible = false;
                    lblPIDate.Visible = false;
                    txtPIDate.Visible = false;
                    lblPEDate.Visible = false;
                    txtPEDate.Visible = false;
                }
                else if (dta.Rows[0]["EMP_DOCTYPE"].ToString() == "P")
                {
                    citizenship.Checked = false;
                    passport.Checked = true;
                    none.Checked = false;

                    lblCNumber.Visible = false;
                    txtCNumber.Visible = false;
                    lblDateIssued.Visible = false;
                    txtDateIssued.Visible = false;
                    lblPlaceIssued.Visible = false;
                    txtPlaceIssued.Visible = false;

                    lblPNumber.Visible = true;
                    txtPNumber.Visible = true;
                    txtPNumber.Text = dta.Rows[0]["EMP_PASSPORT_NO"].ToString();
                    lblPIssued.Visible = true;
                    txtPIssued.Visible = true;
                    txtPIssued.Text = dta.Rows[0]["EMP_PASSPORT_ISSUED"].ToString();
                    lblPIDate.Visible = true;
                    txtPIDate.Visible = true;
                    txtPIDate.Text = dta.Rows[0]["EMP_PASSPORT_ISSUED_DATE"].ToString();
                    lblPEDate.Visible = true;
                    txtPEDate.Visible = true;
                    txtPEDate.Text = dta.Rows[0]["EMP_PASSPORT_EXPIRY_DATE"].ToString();
                }
                else
                {
                    none.Checked = true;
                    lblCNumber.Visible = false;
                    txtCNumber.Visible = false;
                    lblDateIssued.Visible = false;
                    txtDateIssued.Visible = false;
                    lblPlaceIssued.Visible = false;
                    txtPlaceIssued.Visible = false;

                    lblPNumber.Visible = false;
                    txtPNumber.Visible = false;
                    lblPIssued.Visible = false;
                    txtPIssued.Visible = false;
                    lblPIDate.Visible = false;
                    txtPIDate.Visible = false;
                    lblPEDate.Visible = false;
                    txtPEDate.Visible = false;
                }

                DateTime result = Convert.ToDateTime(dta.Rows[0]["EMP_DOB"].ToString());
                txtStartDate.Text = result.ToString("yyyy-MM-dd");

                DateTime result1 = Convert.ToDateTime(dta.Rows[0]["EMP_JOINDATE"].ToString());
                txtJoindate.Text = result1.ToString("yyyy-MM-dd");

                CmbNationality.SelectedValue = dta.Rows[0]["EMP_Pcountry"].ToString();
                txtPemail.Text = dta.Rows[0]["EMP_PEMAIL"].ToString();

                txtUserid.Text = dta.Rows[0]["login_id"].ToString();
                EMP_PASSWORD.Text = dta.Rows[0]["login_password"].ToString();
                CmbBranch.SelectedValue = dta.Rows[0]["BRANCH_ID"].ToString();
                CmbDepartment.SelectedValue = dta.Rows[0]["DEPT_ID"].ToString();
                CmbUsertype.SelectedValue = dta.Rows[0]["UserTypeId"].ToString();
                string HOD_ID = dta.Rows[0]["HOD_ID"].ToString();
                DataTable dt11 = blu.checkHodStatus(HOD_ID);
                if (dt11.Rows.Count > 0)
                {
                    CmbHOD.SelectedValue = dta.Rows[0]["HOD_ID"].ToString();

                }
                else
                {

                }
                CmbStatus.SelectedValue = dta.Rows[0]["STATUS_ID"].ToString();
                CmbGrade.SelectedValue = dta.Rows[0]["GRADE_ID"].ToString();
                CmbDesignation.SelectedValue = dta.Rows[0]["DEG_ID"].ToString();
                txtPf.Text = dta.Rows[0]["pf_number"].ToString();
                txtCit.Text = dta.Rows[0]["cit_number"].ToString();
                txtSs.Text = dta.Rows[0]["Social_Security"].ToString();
                txtPan.Text = dta.Rows[0]["epan_number"].ToString();
                txtBankNumber.Text = dta.Rows[0]["bankAC"].ToString();
                txtOfcEmail.Text = dta.Rows[0]["OFFEMAIL"].ToString();
               

                if (dta.Rows[0]["MARITALSTATUS"].ToString() == "Single")
                {
                    Relationship1.Checked = true;
                    Relationship2.Checked = false;
                    Relationship3.Checked = false;
                }
                else if (dta.Rows[0]["MARITALSTATUS"].ToString() == "Married")
                {
                    Relationship1.Checked = false;
                    Relationship2.Checked = true;
                    Relationship3.Checked = false;
                }
                else if (dta.Rows[0]["MARITALSTATUS"].ToString() == "Divorcee")
                {
                    Relationship1.Checked = false;
                    Relationship2.Checked = false;
                    Relationship3.Checked = true;
                }
                if (dta.Rows[0]["GENDER"].ToString() == "Male")
                {
                    Gender1.Checked = false;
                    Gender2.Checked = true;
                    Gender3.Checked = false;
                }
                else if (dta.Rows[0]["GENDER"].ToString() == "Female")
                {
                    Gender1.Checked = true;
                    Gender2.Checked = false;
                    Gender3.Checked = false;
                }
                else if (dta.Rows[0]["GENDER"].ToString() == "Others")
                {
                    Gender1.Checked = false;
                    Gender2.Checked = false;
                    Gender3.Checked = true;
                }

                if (dta.Rows[0]["enable_web_login"].ToString() == "1")
                {
                    webLoginRadioButton1.Checked = true;
                    webLoginRadioButton2.Checked = false;
                }
                else
                {
                    webLoginRadioButton1.Checked = false;
                    webLoginRadioButton2.Checked = true;
                }
                loadSalutation();
                loadBranch();
                loadDesignation();
                loadStatus();
                loadType();
                loadUsertype();
                loadGrade();
                loadDepartment();
                loadHOD();
                loadNationality();
                loadBloodGroup();
                loadPstate();
                loadTstate();

                DataTable dtP = blu.getPid(empid);
                int pid = Convert.ToInt32(dtP.Rows[0]["PID"].ToString());
                DataTable dt = blu.getEmpLeave(pid);
                GVLeave.DataSource = dt;
                GVLeave.DataBind();
            }
        }

        public void loadPstate()
        {
            DataTable dt = blu.getState();
            CmbPState.DataSource = dt;
            CmbPState.DataTextField = "StateName";
            CmbPState.DataValueField = "StateID";
            CmbPState.DataBind();
        }

        public void loadTstate()
        {
            DataTable dt = blu.getState();
            CmbTState.DataSource = dt;
            CmbTState.DataTextField = "StateName";
            CmbTState.DataValueField = "StateID";
            CmbTState.DataBind();
        }

        public void loadNationality()
        {
            DataTable dt = blu.getNationality();
            CmbNationality.DataSource = dt;
            CmbNationality.DataTextField = "nation_name";
            CmbNationality.DataValueField = "nation_name";
            CmbNationality.DataBind();
        }

        public void loadBloodGroup()
        {
            DataTable dt = blu.getBloodGroup();
            CmbBloodGroup.DataSource = dt;
            CmbBloodGroup.DataTextField = "Blood_Type";
            CmbBloodGroup.DataValueField = "Blood_Type";
            CmbBloodGroup.DataBind();
            CmbBloodGroup.Items[0].Attributes["disabled"] = "disabled";
        }

        public void loadSalutation()
        {
            DataTable dt = blu.getSalutationList();
            CmbSalutation.DataSource = dt;
            CmbSalutation.DataTextField = "salutation";
            CmbSalutation.DataValueField = "id";
            CmbSalutation.DataBind();
        }

        public void loadBranch()
        {
            DataTable dt = blu.getBranchList();
            CmbBranch.DataSource = dt;
            CmbBranch.DataTextField = "BRANCH_Name";
            CmbBranch.DataValueField = "BRANCH_ID";
            CmbBranch.DataBind();
        }

        public void loadDesignation()
        {
            DataTable dt = blu.getDesignation();
            CmbDesignation.DataSource = dt;
            CmbDesignation.DataTextField = "DEG_NAME";
            CmbDesignation.DataValueField = "DEG_ID";
            CmbDesignation.DataBind();
        }

        public void loadStatus()
        {
            DataTable dt = blu.Getstatus();
            CmbStatus.DataSource = dt;
            CmbStatus.DataTextField = "STATUS_NAME";
            CmbStatus.DataValueField = "STATUS_ID";
            CmbStatus.DataBind();
        }
        public void loadType()
        {
            DataTable dt = blu.GetType();
            CmbType.DataSource = dt;
            CmbType.DataTextField = "type_name";
            CmbType.DataValueField = "type_id";
            CmbType.DataBind();
            CmbType.SelectedValue = "2";
        }

        public void loadUsertype()
        {
            DataTable dt = blu.GetUserType();
            CmbUsertype.DataSource = dt;
            CmbUsertype.DataTextField = "TypeName";
            CmbUsertype.DataValueField = "id";
            CmbUsertype.DataBind();
        }

        public void loadGrade()
        {
            DataTable dt = blu.getGradeList();
            CmbGrade.DataSource = dt;
            CmbGrade.DataTextField = "GRADE_NAME";
            CmbGrade.DataValueField = "GRADE_ID";
            CmbGrade.DataBind();
        }
        public void loadDepartment()
        {
            DataTable dt = blu.getDepartment();//getDeptName();
            CmbDepartment.DataSource = dt;
            CmbDepartment.DataTextField = "DEPT_NAME";//"DEPT_PARENT";
            CmbDepartment.DataValueField = "DEPT_ID";
            CmbDepartment.DataBind();
        }

        public void loadHOD()
        {
            int UserTypeId = 3;
            DataTable dt = blu.getUserTypeList(UserTypeId);
            CmbHOD.DataSource = dt;
            CmbHOD.DataTextField = "emp_fullname";
            CmbHOD.DataValueField = "emp_id";
            CmbHOD.DataBind();
        }

        protected void GVLeave_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            int Empid = Convert.ToInt32(txtEmployeeId.Text);
            DataTable dtP = blu.getPid(Empid);
            int pid = Convert.ToInt32(dtP.Rows[0]["PID"].ToString());

            foreach (GridViewRow row in GVLeave.Rows)
            {
                string leaveid = ((row.Cells[0].FindControl("txtLeaveId") as Label).Text);
                DataTable dtL = blu.getLeavebyId(pid, int.Parse(leaveid));
                if (dtL.Rows.Count > 0)
                {
                    RadioButton rbRow = (row.Cells[2].FindControl("rbPer") as RadioButton);
                    rbRow.Checked = true;
                }
                else
                {
                    RadioButton rbRow1 = (row.Cells[2].FindControl("rbPer1") as RadioButton);
                    rbRow1.Checked = true;
                }
            }
        }



        protected void CmbSalutation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbSalutation.SelectedValue == "1")
            {
                Gender1.Checked = false;
                Gender2.Checked = true;
                Gender3.Checked = false;
            }
            else if (CmbSalutation.SelectedValue == "2")
            {
                Gender1.Checked = true;
                Gender2.Checked = false;
                Gender3.Checked = false;
            }
            else if (CmbSalutation.SelectedValue == "3")
            {
                Gender1.Checked = true;
                Gender2.Checked = false;
                Gender3.Checked = false;
            }
            else
            {
                Gender1.Checked = false;
                Gender2.Checked = false;
                Gender3.Checked = true;
            }
        }

        protected void CmbPState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stateId = CmbPState.SelectedValue;
            DataTable dt = blu.getDistrict(stateId);
            CmbPDistrict.DataSource = dt;
            CmbPDistrict.DataTextField = "DistrictName";
            CmbPDistrict.DataValueField = "DistrictId";
            CmbPDistrict.DataBind();
            CmbPDistrict.Items.Insert(0, "Select District");
            CmbPDistrict.Items[0].Selected = true;
            CmbPState.Items[0].Attributes.Add("disabled", "disabled");
        }

        protected void CmbTState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stateId = CmbTState.SelectedValue;
            DataTable dt = blu.getDistrict(stateId);
            CmbTDistrict.DataSource = dt;
            CmbTDistrict.DataTextField = "DistrictName";
            CmbTDistrict.DataValueField = "DistrictId";
            CmbTDistrict.DataBind();
            CmbTDistrict.Items.Insert(0, "Select District");
            CmbTDistrict.Items[0].Selected = true;
            CmbTState.Items[0].Attributes.Add("disabled", "disabled");
        }

        protected void chkCopy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCopy.Checked)
            {
                if (CmbPState.SelectedItem.Text == "Select")
                {
                    chkCopy.Checked = false;
                    ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','PLz Select State of Permanent Address !!!','warning')", true);
                    return;
                }
                else if (CmbPDistrict.SelectedItem.Text == "Select District")
                {
                    chkCopy.Checked = false;
                    ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','PLz Select District of Permanent Address !!!','warning')", true);
                    return;
                }
                else
                {
                    txtTStreet.Text = txtPStreet.Text;
                    txtTMuncipality.Text = txtPMuncipality.Text;
                    txtTWard.Text = txtPWARD.Text;
                    TxtTTOLE.Text = txtPTOLE.Text;
                    CmbTState.SelectedValue = CmbPState.SelectedValue;
                    int StateId = Convert.ToInt32(CmbPState.SelectedValue);
                    DataTable dt = blu.getDistrict(StateId);
                    CmbTDistrict.DataSource = dt;
                    CmbTDistrict.DataTextField = "DistrictName";
                    CmbTDistrict.DataValueField = "DistrictId";
                    CmbTDistrict.DataBind();

                    CmbTDistrict.SelectedValue = CmbPDistrict.SelectedValue;

                    CmbTState.Enabled = false;
                    CmbTDistrict.Enabled = false;
                }
            }
            else
            {
                txtTStreet.Text = "";
                txtTMuncipality.Text = "";
                txtTWard.Text = "";
                TxtTTOLE.Text = "";
                CmbTState.SelectedItem.Text = "Select";
                CmbTDistrict.Items.Clear();

                CmbTState.Enabled = true;
                CmbTDistrict.Enabled = true;
            }
        }

        protected void citizenship_CheckedChanged(object sender, EventArgs e)
        {
            lblCNumber.Visible = true;
            txtCNumber.Visible = true;
            lblDateIssued.Visible = true;
            txtDateIssued.Visible = true;
            lblPlaceIssued.Visible = true;
            txtPlaceIssued.Visible = true;

            lblPNumber.Visible = false;
            txtPNumber.Visible = false;
            lblPIssued.Visible = false;
            txtPIssued.Visible = false;
            lblPIDate.Visible = false;
            txtPIDate.Visible = false;
            lblPEDate.Visible = false;
            txtPEDate.Visible = false;
        }

        protected void passport_CheckedChanged(object sender, EventArgs e)
        {
            lblCNumber.Visible = false;
            txtCNumber.Visible = false;
            lblDateIssued.Visible = false;
            txtDateIssued.Visible = false;
            lblPlaceIssued.Visible = false;
            txtPlaceIssued.Visible = false;

            lblPNumber.Visible = true;
            txtPNumber.Visible = true;
            lblPIssued.Visible = true;
            txtPIssued.Visible = true;
            lblPIDate.Visible = true;
            txtPIDate.Visible = true;
            lblPEDate.Visible = true;
            txtPEDate.Visible = true;
        }

        protected void none_CheckedChanged(object sender, EventArgs e)
        {
            lblCNumber.Visible = false;
            txtCNumber.Visible = false;
            lblDateIssued.Visible = false;
            txtDateIssued.Visible = false;
            lblPlaceIssued.Visible = false;
            txtPlaceIssued.Visible = false;

            lblPNumber.Visible = false;
            txtPNumber.Visible = false;
            lblPIssued.Visible = false;
            txtPIssued.Visible = false;
            lblPIDate.Visible = false;
            txtPIDate.Visible = false;
            lblPEDate.Visible = false;
            txtPEDate.Visible = false;
        }

        int modeid = 0;
        int Pid;
        string pid = "";
        string docType, cNumber, cDateIssued, cPlaceIssued, pNumber, PIssued, pIDate, pEDate;
        string Pstate, PDistrict, Pstreet, PMUN, PWard, PTole, Tstate, TDistrict, Tstreet, TMUN, TWard, TTole;

        protected void BtnSave_Click1(object sender, EventArgs e)
        {
            if (EMP_FIRSTNAME.Text == "" || EMP_LASTNAME.Text == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','Please Fill Full Name!!!','warning')", true);
                return;
            }

            if (txtStartDate.Text == "" || txtJoindate.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Oops!',' Please Date Field Select!','warning')</script>");
                return;
            }

            DateTime cardExpirydate = DateTime.Now;
            DateTime licenceexpirydate = DateTime.Now;

            DateTime suspensionFrom = DateTime.Now;
            DateTime suspensionTo = DateTime.Now;
            DateTime dischargeDate = DateTime.Now;
            DateTime dissmissDate = DateTime.Now;

            int branchid = Convert.ToInt32(CmbBranch.SelectedValue);
            int deptid = Convert.ToInt32(CmbDepartment.SelectedValue);
            int statid = Convert.ToInt32(CmbStatus.SelectedValue);

            int gradeid = Convert.ToInt32(CmbGrade.SelectedValue);

            DataTable dt = blu.getPid(int.Parse(txtEmployeeId.Text));
            if (dt.Rows[0]["PID"].ToString() == "")
            {
                blu.CreateOfcInfo(Convert.ToDateTime(txtJoindate.Text), txtEmployeeId.Text, pid);
            }
            else
            {
                txtpid.Text = dt.Rows[0]["PID"].ToString();
                pid = (txtpid.Text);
                Pid = Convert.ToInt32(pid);
                blu.CreateOfcInfo(Convert.ToDateTime(txtJoindate.Text), txtEmployeeId.Text, pid);
            }
            if (file.HasFile)
            {
                HttpPostedFile postedFile = file.PostedFile;
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);
                int fileSize = postedFile.ContentLength;
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                Byte[] bytes = binaryReader.ReadBytes((Int32)stream.Length);
                blu.imageUpdate(bytes, Convert.ToInt32(txtEmployeeId.Text));
            }
            else
            {
                //lblErrorMsg.Visible = true;
                //lblErrorMsg.Text = "Couldn't upload the file! Please try latter.";
            }



            string UserTypeId = (CmbUsertype.SelectedValue).ToString();

            string title = CmbSalutation.SelectedValue.ToString();
            string emp_pcountry = CmbNationality.SelectedValue.ToString();
            string gender = "";
            if (Gender1.Checked)
            {
                gender = "F";
            }
            else
            {
                gender = "M";
            }
            string Mstatus = "";
            if (Relationship1.Checked)
            {
                Mstatus = "S";
            }
            else if (Relationship2.Checked)
            {
                Mstatus = "M";
            }
            else if (Relationship3.Checked)
            {
                Mstatus = "D";
            }
            else
            {
                Mstatus = "Sep";
            }

            if (citizenship.Checked)
            {
                docType = "C";
                cNumber = txtCNumber.Text;
                cDateIssued = txtDateIssued.Text;
                cPlaceIssued = txtPlaceIssued.Text;
                pNumber = " ";
                PIssued = " ";
                pIDate = " ";
                pEDate = " ";
            }
            else if (passport.Checked)
            {
                docType = "P";
                cNumber = " ";
                cDateIssued = " ";
                cPlaceIssued = " ";
                pNumber = txtPNumber.Text;
                PIssued = txtPlaceIssued.Text;
                pIDate = txtPIDate.Text;
                pEDate = txtPEDate.Text;
            }
            else
            {
                docType = "N";
                cNumber = " ";
                cDateIssued = " ";
                cPlaceIssued = " ";
                pNumber = " ";
                PIssued = " ";
                pIDate = " ";
                pEDate = " ";
            }

            if (chkCopy.Checked)
            {
                Pstate = CmbPState.SelectedValue;
                PDistrict = CmbPDistrict.SelectedValue;
                Pstreet = txtPStreet.Text;
                PMUN = txtPMuncipality.Text;
                PWard = txtPWARD.Text;
                PTole = txtPTOLE.Text;

                Tstate = CmbPState.SelectedValue;
                TDistrict = CmbPDistrict.SelectedValue;
                Tstreet = txtPStreet.Text;
                TMUN = txtPMuncipality.Text;
                TWard = txtPWARD.Text;
                TTole = txtPTOLE.Text;
            }
            else
            {
                Pstate = CmbPState.SelectedValue;
                PDistrict = CmbPDistrict.SelectedValue;
                Pstreet = txtPStreet.Text;
                PMUN = txtPMuncipality.Text;
                PWard = txtPWARD.Text;
                PTole = txtPTOLE.Text;

                Tstate = CmbTState.SelectedValue;
                TDistrict = CmbTDistrict.SelectedValue;
                Tstreet = txtTStreet.Text;
                TMUN = txtTMuncipality.Text;
                TWard = txtTWard.Text;
                TTole = TxtTTOLE.Text;
            }


            blu.CreateEmpGeneralInfo(
                txtEmployeeId.Text,
                ImgPersonal.ImageUrl,
                title,
                EMP_FIRSTNAME.Text,
                EMP_MIDDLENAME.Text,
                EMP_LASTNAME.Text,
                Convert.ToDateTime(txtStartDate.Text),
                Convert.ToDateTime(txtJoindate.Text),
                gender,
                Mstatus,
                txtMobile.Text,
                txtTelephone.Text,
                CmbNationality.SelectedValue,
                CmbBloodGroup.SelectedValue,
                txtMotherName.Text,
                txtFatherName.Text,
                txtSpouse.Text,
                txtGrandFather.Text,
                txtChildren1.Text,
                txtChildren2.Text,
                CmbPState.SelectedValue,
                CmbPDistrict.SelectedValue,
                txtPStreet.Text,
                txtPMuncipality.Text,
                txtPWARD.Text,
                txtPTOLE.Text,
                Tstate,
                TDistrict,
                txtTStreet.Text,
                txtTMuncipality.Text,
                txtTWard.Text,
                TxtTTOLE.Text,
                docType,
                cNumber,
                cDateIssued,
                cPlaceIssued,
                pNumber,
                PIssued,
                pIDate,
                pEDate,
                txtPemail.Text
                );


            string emergName = txtEmergName.Text;
            string ADDRESS = "";
            string emergRelation = txtEmergRelation.Text;
            string emergContact = txtEmergContact.Text;
            string IMAGE = "";
            string MOBILE = "";
            blu.InsertEmpRelativeInfo(txtEmployeeId.Text, emergName, ADDRESS, emergRelation, emergContact, IMAGE, MOBILE);


            int emp_id = Convert.ToInt32(txtEmployeeId.Text);
            int modeid = Convert.ToInt32(CmbType.SelectedValue);
            int degid = Convert.ToInt32(CmbDesignation.SelectedValue);
            int HOD_ID = Convert.ToInt16(CmbHOD.SelectedValue);
            int usertypeid = Convert.ToInt32(CmbUsertype.SelectedValue.ToString());
            int login_id = Convert.ToInt32(txtEmployeeId.Text);
            string login_password = EMP_PASSWORD.Text;
            string pf = txtPf.Text;
            string cit = txtCit.Text;
            string ss = txtSs.Text;
            string pan = txtPan.Text;
            string bankAc = txtBankNumber.Text;
            string offEmail = txtOfcEmail.Text;
            int webLogin;
            if (webLoginRadioButton1.Checked)
            {
                webLogin = 1;
            }
            else
            {
                webLogin = 0;

            }

            blu.CreateOfficialInfo(
                degid,
                HOD_ID,
                modeid,
                deptid,
                branchid,
                statid,
                gradeid,
                emp_id,
                Pid,
                usertypeid,
                login_id,
                login_password,
                pf,
                cit,
                ss,
                pan,
                bankAc,
                offEmail,
                webLogin);

            foreach (GridViewRow row in GVLeave.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    RadioButton rbRow = (row.Cells[2].FindControl("rbPer") as RadioButton);
                    int flag = 0;
                    int id;
                    string leaveid;
                    if (rbRow.Checked)
                    {
                        leaveid = ((row.Cells[0].FindControl("txtLeaveId") as Label).Text);
                        id = Convert.ToInt32(leaveid);
                        flag = 1;
                        blu.insertLeaveManagement(Pid, id, 0, 0, flag);
                    }
                    else
                    {
                        leaveid = ((row.Cells[0].FindControl("txtLeaveId") as Label).Text);
                        id = Convert.ToInt32(leaveid);
                        flag = 0;
                        blu.insertLeaveManagement(Pid, id, 0, 0, flag);
                    }
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Employee Updated Successfully').then((value) => { window.location ='employeeList'; });", true);

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("employeeList");
        }


    }
}