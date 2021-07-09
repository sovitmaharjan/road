<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="forceAttendance.aspx.cs" Inherits="attendance.pages.attendanceManagement.forceAttendance.forceAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Attendance Management</li>
                            <li class="active">Force Attendance
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->

            <div class="panel-heading">
                <h3 class="panel-title" style="color: red;">* Denotes Mandatory Fields</h3>
            </div>

            <form runat="server" role="form" class="form-horizontal">
                <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                <div>
                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div>
                                <div class="well">
                                    <div class="form-group">
                                        <label class="control-label col-md-6">Employee ID <span style="color: red">*</span></label>
                                        <div class="col-md-1">
                                            <div class="input-group">
                                                <asp:TextBox ID="TxtId" CssClass="form-control" AutoComplete="off" AutoPostBack="true" runat="server" OnTextChanged="TxtId_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label CssClass="control-label col-md-2" runat="server">Employee Name</asp:Label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="TxtEmp" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <asp:Label CssClass="control-label col-md-2" runat="server">Designation</asp:Label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="TxtDesignation" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label CssClass="control-label col-md-2" runat="server">Department</asp:Label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="TxtDept" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <asp:Label CssClass="control-label col-md-2" runat="server">Branch</asp:Label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="TxtBranch" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                        <%--</ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>--%>
                            <div class="well">

                                <div class="form-group">
                                    <label class="control-label col-md-2">Shift <span style="color: red">*</span></label>
                                    <div class="col-md-5">
                                        <asp:DropDownList ID="shiftForm" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="1">First </asp:ListItem>
                                            <asp:ListItem Value="2">Second</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-2">Start Date <span style="color: red">*</span></label>
                                    <div class="col-md-5 ">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtStartDate" CssClass="form-control englishDate7" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                            <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtNepaliDate" CssClass="form-control nepaliDate7" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                            <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="control-label col-md-2">Till Date <span style="color: red">*</span></label>
                                    <div class="col-md-5 ">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtEndDate" CssClass="form-control englishDate8" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                            <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="input-group">
                                            <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate8" Autocomplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                            <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="Label1" CssClass="control-label col-md-2" runat="server" Text="Label"> Attendance Type <span style="color: red">*</span> </asp:Label>
                                    <div class="col-md-3">

                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
                                        <asp:RadioButton ID="SignIn" GroupName="AttendanceType" runat="server" AutoPostBack="true" />
                                        Sign In
                                    <asp:RadioButton ID="SignOut" GroupName="AttendanceType" runat="server" AutoPostBack="true" />
                                        Sign Out
                                    <asp:RadioButton ID="Both" GroupName="AttendanceType" Checked="true" runat="server" AutoPostBack="true" />
                                        Both
                                    </div>

                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-2 col-md-offset-10">
                                    <asp:Button ID="plus" class="btn btn-info" runat="server" Text="+" OnClick="plus_Click" />
                                </div>
                            </div>

                
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" runat="server"
                                                OnRowDataBound="GridView_RowBound"
                                                ShowHeader="True"
                                                Font-Size="Small"
                                                AutoGenerateColumns="false"
                                                CssClass="table table-striped table-bordered table-hover table-responsive  table-info"
                                                EmptyDataText="No records has been added.">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="chkdetails" runat="server" onclick="checkAll(this);" />
                                                            All
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chk2" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtStartDate" CssClass="form-control englishDate8" runat="server" Text='<%# Eval("Tdate","{0:yyyy-MM-dd}") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="InDay" HeaderText="Day" />

                                                    <asp:TemplateField HeaderText="Duty Roster">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtRooster" runat="server" Text='<%# Eval("Duty_roster") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="In Time">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtInTime" CssClass="form-control timePicker2" runat="server" Text='<%# Eval("Intime") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="In Remarks">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TextInRemark" CssClass="form-control" runat="server">Admin</asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Out Date">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtEndDate" CssClass="form-control englishDate7" runat="server" Text='<%# Eval("Tdate_Out","{0:yyyy-MM-dd}") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="OutDay" HeaderText="Day" />


                                                    <asp:TemplateField HeaderText="Out Time">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtOutTime" CssClass="form-control timePicker2" runat="server" Text='<%# Eval("Outtime") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Out Remarks">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="TextOutRemark" CssClass="form-control" runat="server">Admin</asp:TextBox>
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
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8 col-md-offset-4">
                                <div class="col-md-3">
                                    <asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSave_Click" />
                                </div>

                                <div class="col-md-3">
                                    <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
            </form>

            <!-- container -->
        </div>
    </div>
    <!-- content -->
    <script type="text/javascript">
        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        inputList[i].checked = true;

                    }

                    else {
                        inputList[i].checked = false;

                    }

                }

            }

        }

    </script>
</asp:Content>
