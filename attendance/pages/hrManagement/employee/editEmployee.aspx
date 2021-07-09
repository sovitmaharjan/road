<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="editEmployee.aspx.cs" Inherits="attendance.pages.hrManagement.employee.editEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">HR Management </h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li>
                                <a href="dashboard">Dashboard</a>
                            </li>
                            <li>
                                <a href="employeeList">Employees List</a>
                            </li>
                            <li class="active">Edit Employees
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->
            <div class="row">
                <div class="col-md-12">
                    <div class="card-box">
                        <form id="form1" class="form-horizontal" runat="server">
                            <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <h3 class="panel-title" style="color: red;">* Denotes Mandatory Fields</h3>
                            <div class="well">
                                <h3 style="color: darkblue;">1. Personal Information</h3>
                                <div class="form-group">
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtpid" Visible="false" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-5 pull-right">
                                        <asp:Image ID="ImgPersonal" class="asdasdasd" runat="server" Style="height: 150px; width: 150px; border-style: ridge; border-width: 5px;" />
                                        <asp:FileUpload ID="file" onchange="asdasdasd(this);" runat="server" Height="22px" accept=".png,.jpg,.jpeg,.gif" /><br />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-14">
                                        <label class="control-label col-md-5">Employee ID <span style="color: red">*</span></label>
                                        <div class="col-md-1">
                                            <asp:TextBox ID="txtEmployeeId" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>


                                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <label class="control-label col-md-2">Full Name <span style="color: red">*</span></label>
                                            <div class="col-md-2">
                                                <asp:DropDownList ID="CmbSalutation" AutoPostBack="true" CssClass="form-control" runat="server" ToolTip="Salutation List" OnSelectedIndexChanged="CmbSalutation_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="EMP_FIRSTNAME" CssClass="form-control" placeholder="FIRSTNAME" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="EMP_MIDDLENAME" CssClass="form-control" placeholder="MIDDLENAME" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="EMP_LASTNAME" CssClass="form-control" placeholder="LASTNAME" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">DOB <span style="color: red">*</span></label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtNepaliDate" CssClass="form-control nepaliDate4" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtStartDate" CssClass="form-control englishDate4" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                            </div>

                                            <label class="control-label col-md-2">Join Date <span style="color: red">*</span></label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtjoin" CssClass="form-control nepaliDate5" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtJoindate" CssClass="form-control englishDate5" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">Gender <span style="color: red">*</span></label>
                                            <div class="col-md-3">
                                                <asp:RadioButton GroupName="Gender" ID="Gender1" value="F" runat="server" />
                                                Female
                                                <asp:RadioButton GroupName="Gender" ID="Gender2" Checked="true" value="M" runat="server" />
                                                Male
                                                <asp:RadioButton GroupName="Gender" ID="Gender3" value="Oth" runat="server" />
                                                Others
                                            </div>
                                            <label class="control-label col-md-2">Relationship <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:RadioButton GroupName="Relationship" Checked="true" ID="Relationship1" value="S" runat="server" />
                                                Single
                                        <asp:RadioButton GroupName="Relationship" ID="Relationship2" value="M" runat="server" />
                                                Married
                                        <asp:RadioButton GroupName="Relationship" ID="RadioButton4" value="Sep" runat="server" />
                                                Separated
                                        <asp:RadioButton GroupName="Relationship" ID="Relationship3" value="D" runat="server" />
                                                Divorced
                                            </div>

                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">Mobile </label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtMobile" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="control-label col-md-2">Telephone </label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtTelephone" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">Nationality </label>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="CmbNationality" CssClass="form-control" runat="server" ToolTip="Branch List"></asp:DropDownList>
                                            </div>
                                            <label class="control-label col-md-2">Blood Group </label>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="CmbBloodGroup" CssClass="form-control" runat="server" ToolTip="Blood Group List"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">Mother's Name <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtMotherName" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="control-label col-md-2">Father's Name <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtFatherName" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">Spouse's Name <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtSpouse" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="control-label col-md-2">GrandFather's Name <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtGrandFather" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">Children <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtChildren1" placeHolder="Name Of Children 1" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtChildren2" placeHolder="Name Of Children 2" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2" style="color: #3AC9D6;">Emergency Contacts <span style="color: red">*</span> </label>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">Name</label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtEmergName" autocomplete="off" CssClass="form-control" Placeholder="Contact Person" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="control-label col-md-2">Relation</label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtEmergRelation" autocomplete="off" CssClass="form-control" Placeholder="Relation" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="control-label col-md-2">Contact</label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtEmergContact" autocomplete="off" CssClass="form-control" Placeholder="Contact" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2" style="color: #3AC9D6;">Permanent Address <span style="color: red">*</span> </label>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">State <span style="color: red">*</span></label>
                                            <div class="col-md-2">
                                                <asp:DropDownList ID="CmbPState" CssClass="form-control" runat="server" ToolTip="Provinces List" AutoPostBack="true" OnSelectedIndexChanged="CmbPState_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                            <label class="control-label col-md-2">District </label>
                                            <div class="col-md-2">
                                                <asp:DropDownList ID="CmbPDistrict" CssClass="form-control" runat="server" ToolTip="District List"></asp:DropDownList>
                                            </div>
                                            <label class="control-label col-md-2">City</label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtPStreet" autocomplete="off" CssClass="form-control" Placeholder="City" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">VDC/muncipality </label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtPMuncipality" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="control-label col-md-2">Ward No.</label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtPWARD" CssClass="form-control" Type="number" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="control-label col-md-2">Village/Tole </label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtPTOLE" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2" style="color: #3AC9D6;">Residential Address</label>
                                            <label class="control-label col-md-2">Copy Address</label>
                                            <div class="col-md-1">
                                                <asp:CheckBox ID="chkCopy" runat="server" AutoPostBack="true" OnCheckedChanged="chkCopy_CheckedChanged" />
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">State </label>
                                            <div class="col-md-2">
                                                <asp:DropDownList ID="CmbTState" CssClass="form-control" runat="server" ToolTip="State List" AutoPostBack="true" OnSelectedIndexChanged="CmbTState_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                            <label class="control-label col-md-2">District </label>
                                            <div class="col-md-2">
                                                <asp:DropDownList ID="CmbTDistrict" CssClass="form-control" runat="server" ToolTip="District List"></asp:DropDownList>
                                            </div>
                                            <label class="control-label col-md-2">City</label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtTStreet" autocomplete="off" CssClass="form-control" Placeholder="City" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">VDC/muncipality </label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtTMuncipality" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="control-label col-md-2">Ward No.</label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtTWard" CssClass="form-control" Type="number" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="control-label col-md-2">Village/Tole </label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="TxtTTOLE" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">Document Type <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:RadioButton GroupName="documentType" ID="citizenship" value="C" runat="server" AutoPostBack="true" OnCheckedChanged="citizenship_CheckedChanged" />
                                                Citizenship
                                                <asp:RadioButton GroupName="documentType" ID="passport" value="P" runat="server" AutoPostBack="true" OnCheckedChanged="passport_CheckedChanged" />
                                                Passport
                                                <asp:RadioButton GroupName="documentType" ID="none" Checked="true" value="N" runat="server" AutoPostBack="true" OnCheckedChanged="none_CheckedChanged" />
                                                None
                                            </div>
                                            <label class="control-label col-md-2">Personal E mail </label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtPemail" Autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="lblCNumber" CssClass="control-label col-md-2" runat="server" Text="Label"> Number</asp:Label>
                                            <div class=" col-md-2">
                                                <asp:TextBox ID="txtCNumber" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <asp:Label ID="lblDateIssued" CssClass="control-label col-md-2" runat="server" Text="Label"> Date Issued</asp:Label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtDateIssued" CssClass="form-control englishDate7 " runat="server"></asp:TextBox>
                                            </div>

                                            <asp:Label ID="lblPlaceIssued" CssClass="control-label col-md-2" runat="server" Text="Label"> Place Issued</asp:Label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtPlaceIssued" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="lblPNumber" CssClass="control-label col-md-2" runat="server" Text="Label"> Number</asp:Label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtPNumber" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <asp:Label ID="lblPIssued" CssClass="control-label col-md-2" runat="server" Text="Label"> Issued From</asp:Label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtPIssued" CssClass="form-control " runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="lblPIDate" CssClass="control-label col-md-2" runat="server" Text="Label"> Issued Date</asp:Label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtPIDate" CssClass="form-control englishDate7" runat="server"></asp:TextBox>
                                            </div>
                                            <asp:Label ID="lblPEDate" CssClass="control-label col-md-2" runat="server" Text="Label"> Expiry Date</asp:Label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtPEDate" CssClass="form-control englishDate8" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>

                            <div class="well">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <h3 style="color: darkblue">2. Official Information</h3>
                                        <div class="form-group">
                                            <label class="control-label col-md-2">Branch <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="CmbBranch" CssClass="form-control" runat="server" ToolTip="Branch List" AutoPostBack="true"></asp:DropDownList>
                                            </div>

                                            <label class="control-label col-md-2">Department <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" ToolTip="Department List"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2" for="userName">User ID</label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtUserid" ReadOnly="true" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="control-label col-md-2">Password <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="EMP_PASSWORD" Autocomplete="off" value="123" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-2">User Type <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="CmbUsertype" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <label class="control-label col-md-2">Supervisor</label>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="CmbHOD" CssClass="form-control" runat="server">
                                                    <asp:ListItem Text="No HOD" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-2">Designation <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="CmbDesignation" CssClass="form-control" runat="server" ToolTip="Designation List"></asp:DropDownList>
                                            </div>
                                            <label class="control-label col-md-2">Grade <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="CmbGrade" CssClass="form-control" runat="server" ToolTip="Grade List"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">Status <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="CmbStatus" CssClass="form-control" runat="server" ToolTip="Status List"></asp:DropDownList>
                                            </div>
                                            <label class="control-label col-md-2">Type <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:DropDownList ID="CmbType" CssClass="form-control" runat="server" ToolTip="Type List"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">P.F <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtPf" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="control-label col-md-2">C.I.T <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtCit" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">S.S <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtSs" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="control-label col-md-2">PAN <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtPan" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">Bank A/C Number <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtBankNumber" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <label class="control-label col-md-2">Official Email</label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtOfcEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-2">Web Login <span style="color: red">*</span></label>
                                            <div class="col-md-4">
                                                <asp:RadioButton GroupName="webLogin" ID="webLoginRadioButton1" value="E" runat="server" />
                                                Enable
                                                <asp:RadioButton GroupName="webLogin" ID="webLoginRadioButton2" value="D" runat="server" />
                                                Disable
                                            </div>
                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="well">
                                <div class="table-responsive">
                                    <h3 style="color: darkblue;">3. Leave Management</h3>
                                    <asp:GridView ID="GVLeave" runat="server"
                                        Font-Size="Small"
                                        AutoGenerateColumns="False"
                                        OnRowDataBound="GVLeave_RowDataBound"
                                        CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                        EmptyDataText="No Records has been added.">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.N" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>

                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Leave Id">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtLeaveId" runat="server" Text='<%# Eval("LEAVEID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Leave Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="txtLeaveName" runat="server" Text='<%# Eval("LEAVE_NAME") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Permission">
                                                <ItemTemplate>
                                                    <asp:RadioButton ID="rbPer" Checked="true" GroupName="rbPer" runat="server" />
                                                    Yes
                                                        <asp:RadioButton ID="rbPer1" GroupName="rbPer" runat="server" />
                                                    No
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EditRowStyle />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />

                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                </div>

                                <div class="col-md-8 col-md-offset-4">
                                    <div class="col-md-3">
                                        <asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Update" OnClick="BtnSave_Click1" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.blah')
                    .attr('src', e.target.result)
                    .width(150)
                    .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
        function Relative(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.Emergency')
                    .attr('src', e.target.result)
                    .width(150)
                    .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
        function Digital(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.Signature')
                    .attr('src', e.target.result)
                    .width(150)
                    .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
        function asdasdasd(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.asdasdasd')
                    .attr('src', e.target.result)
                    .width(150)
                    .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
