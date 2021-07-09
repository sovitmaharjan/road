using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace attendance.pages.hrManagement.employee
{
    public partial class addEmployee : System.Web.UI.Page
    {
        attendance blu = new attendance();
        static attendance staticblu = new attendance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadSalutation();
                loadBranch();
                loadDepartment();
                loadDesignation();
                loadStatus();
                loadType();
                loadGrade();
                loadUsertype();
                loadHOD();
                loadNationality();
                loadBloodGroup();
                loadPstate();
                loadTstate();


                txtEmployeeId.Attributes.Add("onchange", "this.value");

                DataTable dt = blu.getLeaveList();
                if (dt.Rows.Count > 0)
                {
                    GVLeave.DataSource = dt;
                    GVLeave.DataBind();
                }
                else
                {
                    GVLeave.DataSource = null;
                    GVLeave.DataBind();
                }
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
            else
            {
                CmbNationality.Items[0].Attributes["disabled"] = "disabled";
                CmbBloodGroup.Items[0].Attributes["disabled"] = "disabled";
                CmbBranch.Items[0].Attributes["disabled"] = "disabled";
                CmbDepartment.Items[0].Attributes["disabled"] = "disabled";

            }
        }

        public void loadPstate()
        {
            DataTable dt = blu.getState();
            CmbPState.DataSource = dt;
            CmbPState.DataTextField = "StateName";
            CmbPState.DataValueField = "StateID";
            CmbPState.DataBind();
            CmbPState.Items.Insert(0, "Select");
        }

        public void loadTstate()
        {
            DataTable dt = blu.getState();
            CmbTState.DataSource = dt;
            CmbTState.DataTextField = "StateName";
            CmbTState.DataValueField = "StateID";
            CmbTState.DataBind();
            CmbTState.Items.Insert(0, "Select");
        }
        public void loadNationality()
        {
            DataTable dt = blu.getNationality();
            CmbNationality.DataSource = dt;
            CmbNationality.DataTextField = "nation_name";
            CmbNationality.DataValueField = "nation_name";
            CmbNationality.DataBind();
            CmbNationality.Items.Insert(0, "Select");
            CmbNationality.Items[0].Selected = true;
            CmbNationality.Items[0].Attributes["disabled"] = "disabled";
        }
        public void loadBloodGroup()
        {
            DataTable dt = blu.getBloodGroup();
            CmbBloodGroup.DataSource = dt;
            CmbBloodGroup.DataTextField = "Blood_Type";
            CmbBloodGroup.DataValueField = "Blood_Type";
            CmbBloodGroup.DataBind();
            CmbBloodGroup.Items.Insert(0, "Select");
            CmbBloodGroup.Items[0].Selected = true;
            CmbBloodGroup.Items[0].Attributes.Add("disabled", "disabled");
        }

        public void loadSalutation()
        {
            DataTable dt = blu.getSalutationList();
            CmbSalutation.DataSource = dt;
            CmbSalutation.DataTextField = "salutation";
            CmbSalutation.DataValueField = "id";
            CmbSalutation.DataBind();
            CmbSalutation.Items.Insert(0, "Select");
            CmbSalutation.Items[0].Selected = true;
            CmbSalutation.Items[0].Attributes["disabled"] = "disabled";
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
        public void loadBranch()
        {
            DataTable dt = blu.getBranch();
            CmbBranch.DataSource = dt;
            CmbBranch.DataTextField = "BRANCH_Name";
            CmbBranch.DataValueField = "BRANCH_ID";
            CmbBranch.DataBind();
            CmbBranch.Items.Insert(0, "Select Branch");
            CmbBranch.Items[0].Selected = true;
            CmbBranch.Items[0].Attributes.Add("disabled", "disabled");
        }

        public void loadDepartment()
        {
            DataTable dt = blu.getDepartment();
            CmbDepartment.DataSource = dt;
            CmbDepartment.DataTextField = "DEPT_NAME";
            CmbDepartment.DataValueField = "DEPT_ID";
            CmbDepartment.DataBind();
            CmbDepartment.Items.Insert(0, "Select Department");
            CmbDepartment.Items[0].Selected = true;
            CmbDepartment.Items[0].Attributes.Add("disabled", "disabled");
        }

        public void loadUsertype()
        {
            DataTable dt = blu.GetUserType();
            CmbUsertype.DataSource = dt;
            CmbUsertype.DataTextField = "TypeName";
            CmbUsertype.DataValueField = "id";
            CmbUsertype.DataBind();
            CmbUsertype.Items.Insert(0, "Select");
            CmbUsertype.Items[0].Selected = true;
            CmbUsertype.Items[0].Attributes.Add("disabled", "disabled");
        }

        public void loadHOD()
        {
            int usertypeid = 3;
            DataTable dt = blu.getUserTypeList(usertypeid);
            CmbHOD.DataSource = dt;
            CmbHOD.DataTextField = "emp_fullname";
            CmbHOD.DataValueField = "emp_id";
            CmbHOD.DataBind();
            CmbHOD.Items.Insert(0, "Select");
            CmbHOD.Items[0].Selected = true;
            CmbHOD.Items[0].Attributes.Add("disabled", "disabled");
        }

        public void loadDesignation()
        {
            DataTable dt = blu.getDesignation();
            CmbDesignation.DataSource = dt;
            CmbDesignation.DataTextField = "DEG_NAME";
            CmbDesignation.DataValueField = "DEG_ID";
            CmbDesignation.DataBind();
            CmbDesignation.Items.Insert(0, "Select Designation");
            CmbDesignation.Items[0].Selected = true;
            CmbDesignation.Items[0].Attributes.Add("disabled", "disabled");
        }

        public void loadStatus()
        {
            DataTable dt = blu.Getstatus();
            CmbStatus.DataSource = dt;
            CmbStatus.DataTextField = "STATUS_NAME";
            CmbStatus.DataValueField = "STATUS_ID";
            CmbStatus.DataBind();
            CmbStatus.SelectedValue = "1";
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

        [WebMethod]
        public static int CheckDuplicate(int employeeId)
        {
            string emp_id = employeeId.ToString();
            int i = Convert.ToInt32(staticblu.CheckDuplicateEmpId(emp_id));

            return i;
        }
        public void loadGrade()
        {
            DataTable dt = blu.getGradeList();
            CmbGrade.DataSource = dt;
            CmbGrade.DataTextField = "GRADE_NAME";
            CmbGrade.DataValueField = "GRADE_ID";
            CmbGrade.DataBind();
            CmbGrade.Items.Insert(0, "Select Grade");
            CmbGrade.Items[0].Selected = true;
            CmbGrade.Items[0].Attributes.Add("disabled", "disabled");
        }



        protected void GVLeave_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }


        int Pid;
        string pid = "";

        string docType, cNumber, cDateIssued, cPlaceIssued, pNumber, PIssued, pIDate, pEDate;
        string Pstate, PDistrict, Pstreet, PMUN, PWard, PTole, Tstate, TDistrict, Tstreet, TMUN, TWard, TTole;

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtEmployeeId.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>swal('Oops!','Enter Employee Id!','warning')</script>");
                txtEmployeeId.Focus();
                return;
            }
            else if (CmbSalutation.SelectedItem.Text == "Select")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','Please Select  Salutation!!!','warning')", true);
                return;
            }
            else if (EMP_FIRSTNAME.Text == "" || EMP_LASTNAME.Text == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','Please Fill Full Name!!!','warning')", true);
                return;
            }
            else if (txtStartDate.Text == "" || txtJoindate.Text == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','Please Check Date !!!','warning')", true);
                return;
            }
            else if (CmbTState.SelectedValue == "Select")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','Please Select State in Residential Address !!!','warning')", true);
                return;
            }
            else if (CmbTDistrict.SelectedValue == "select District")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','Please Select District in Residential Address !!!','warning')", true);
                return;
            }
            else if (CmbPState.SelectedValue == "Select")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','Please Select State in Residential Address !!!','warning')", true);
                return;
            }
            else if (CmbPDistrict.SelectedValue == "Select District")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','Please Select District in Permanent Address !!!','warning')", true);
                return;
            }
            else if (CmbBranch.SelectedItem.Text == "Select Branch")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','Please Select required Branch in Official Information !!!','warning')", true);
                return;
            }
            else if (CmbDepartment.SelectedItem.Text == "Select Department")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','Please Select required Department in Official Information !!!','warning')", true);
                return;
            }
            else if (CmbUsertype.SelectedItem.Text == "Select")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','Please Select required UserType in Official Information !!!','warning')", true);
                return;
            }
            else if (CmbHOD.SelectedItem.Text == "Select")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','Please Select required HOD in Official Information !!!','warning')", true);
                return;
            }
            else if (CmbDesignation.SelectedItem.Text == "Select Designation")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','Please Select required Designation in Official Information !!!','warning')", true);
                return;
            }
            else if (CmbGrade.SelectedItem.Text == "Select Grade")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel8, this.GetType(), "alertscipt", "swal('Oops!','Please Select required Grade in Official Information !!!','warning')", true);
                return;
            }
            else
            {
                string title = (CmbSalutation.SelectedValue).ToString();
                if (file.HasFile)
                {
                    HttpPostedFile postedFile = file.PostedFile;
                    string filename = Path.GetFileName(postedFile.FileName);
                    string fileExtension = Path.GetExtension(filename);
                    int fileSize = postedFile.ContentLength;
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    Byte[] bytes = binaryReader.ReadBytes((Int32)stream.Length);
                    blu.imageSave(bytes, Convert.ToInt32(txtEmployeeId.Text));
                }
                else
                {
                    lblErrorMsg.Visible = true;
                    lblErrorMsg.Text = "Couldn't upload the file! Please try latter.";
                }
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
                string Mobile = txtMobile.Text;
                string Telephone = txtTelephone.Text;
                string emp_pcountry = CmbNationality.SelectedValue;
                string emp_bloodGroup = CmbBloodGroup.SelectedValue;
                string mName = txtMotherName.Text;
                string fName = txtFatherName.Text;
                string sName = txtSpouse.Text;
                string gName = txtGrandFather.Text;
                string cName1 = txtChildren1.Text;
                string cName2 = txtChildren2.Text;

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
                string pEmail = txtPemail.Text;

                blu.CreateEmpGeneralInfo(
                   txtEmployeeId.Text,
                   Image1.ImageUrl,
                   title,
                   EMP_FIRSTNAME.Text,
                   EMP_MIDDLENAME.Text,
                   EMP_LASTNAME.Text,
                   Convert.ToDateTime(txtStartDate.Text),
                   Convert.ToDateTime(txtJoindate.Text),
                   gender,
                   Mstatus,
                   Mobile,
                   Telephone,
                   emp_pcountry,
                   emp_bloodGroup,
                   mName,
                   fName,
                   sName,
                   gName,
                   cName1,
                   cName2,
                   Pstate,
                   PDistrict,
                   Pstreet,
                   PMUN,
                   PWard,
                   PTole,
                   Tstate,
                   TDistrict,
                   Tstreet,
                   TMUN,
                   TWard,
                   TTole,
                   docType,
                   cNumber,
                   cDateIssued,
                   cPlaceIssued,
                   pNumber,
                   PIssued,
                   pIDate,
                   pEDate,
                   pEmail
                   );

                string emergName = txtEmergName.Text;
                string ADDRESS = "";
                string emergRelation = txtEmergRelation.Text;
                string emergContact = txtEmergContact.Text;
                string IMAGE = "";
                string MOBILE = "";
                blu.InsertEmpRelativeInfo(txtEmployeeId.Text, emergName, ADDRESS, emergRelation, emergContact, IMAGE, MOBILE);


                int branchid = Convert.ToInt32(CmbBranch.SelectedValue);
                int deptid = Convert.ToInt32(CmbDepartment.SelectedValue);
                int login_id = Convert.ToInt32(txtEmployeeId.Text);
                string login_password = EMP_PASSWORD.Text;
                int usertypeid = Convert.ToInt32(CmbUsertype.SelectedValue.ToString());
                int hod_id = Convert.ToInt32(CmbHOD.SelectedValue);
                int degid = Convert.ToInt32(CmbDesignation.SelectedValue);
                int gradeid = Convert.ToInt32(CmbGrade.SelectedValue);
                int statid = Convert.ToInt32(CmbStatus.SelectedValue);
                int modeid = Convert.ToInt32(CmbType.SelectedValue);
                string pf = txtPf.Text;
                string cit = txtCit.Text;
                string ss = txtSs.Text;
                string pan = txtPan.Text;
                string bankAc = txtBankNumber.Text;
                string offEmail = txtOfcEmail.Text;
                int webLogin;
                if (RadioButton1.Checked)
                {
                    webLogin = 1;
                }
                else
                {
                    webLogin = 0;

                }

                int emp_id = Convert.ToInt32(txtEmployeeId.Text);
                DataTable dt = blu.getMaxPid();//for maxmium pid
                if (dt.Rows[0]["Column1"].ToString() == "")
                {
                    blu.CreateOfcInfo(Convert.ToDateTime(txtJoindate.Text), txtEmployeeId.Text, pid);
                }
                else
                {
                    txtpid.Text = dt.Rows[0]["Column1"].ToString();
                    pid = (txtpid.Text);
                    Pid = Convert.ToInt32(pid);
                    blu.CreateOfcInfo(Convert.ToDateTime(txtJoindate.Text), txtEmployeeId.Text, pid);
                }
                blu.CreateOfficialInfo(
                    degid,
                    hod_id,
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
                        if (rbRow.Checked)
                        {
                            string leaveid = ((row.Cells[0].FindControl("txtLeaveId") as Label).Text);
                            int id = Convert.ToInt32(leaveid);
                            int Days = 0;
                            int maxDays = 0;
                            blu.insertLeaveManagement(Pid, id, Days, maxDays, 1);
                        }
                    }
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swal('Employee saved Successfully').then((value) => { window.location ='employeeList'; });", true);
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
                    CmbTState.SelectedItem.Text = CmbPState.SelectedItem.ToString();
                    int StateId = Convert.ToInt32(CmbPState.SelectedValue);
                    DataTable dt = blu.getDistrict(StateId);
                    CmbTDistrict.DataSource = dt;
                    CmbTDistrict.DataTextField = "DistrictName";
                    CmbTDistrict.DataValueField = "DistrictId";
                    CmbTDistrict.DataBind();

                    CmbTDistrict.SelectedItem.Text = CmbPDistrict.SelectedItem.ToString();

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

        protected void CmbTDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbPDistrict.Items[0].Attributes["disabled"] = "disabled";
            CmbTDistrict.Items[0].Attributes["disabled"] = "disabled";

        }

        protected void CmbPDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbPDistrict.Items[0].Attributes["disabled"] = "disabled";
        }
    }
}