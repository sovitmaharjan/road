<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="holidaySubstitute.aspx.cs" Inherits="attendance.pages.attendanceManagement.holidaySubstitute.holidaySubstitute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Attendance Management</li>
                            <li class="active">Substitution Holiday
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->

            <form runat="server" role="form" class="form-horizontal">
                <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                <div class="well">
                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="form-group">
                                <label class="control-label col-md-2">Employee ID <span style="color: red">*</span></label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtEmpId" oninput="this.value=this.value.replace(/[^0-9.]/g,'');this.value=this.value.replace(/(\..*)\./g,'$1');" CssClass="form-control" AutoComplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtEmpId_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-md-3"></div>
                                <label class="control-label col-md-2">Employee <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbEmployee" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Employee List" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbEmployee_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Designation <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtDesg" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                                <label class="control-label col-md-2">Status <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtSts" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Department <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtDept" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>

                                </div>
                                <label class="control-label col-md-2">Branch <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtBranch" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Holiday Name <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbHolidayname" CssClass="form-control" runat="server" CausesValidation="True" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbHolidayname_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <label class="control-label col-md-2">Date <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtDate" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                        <span class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                    <div class="form-group">
                        <label class="control-label col-md-2">Substitution Date <span style="color: red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtSDate" CssClass="form-control englishDate1" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TextBox1" AutoComplete="off" CssClass="form-control nepaliDate1" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="col-md-8 col-md-offset-4">
                            <div class="col-md-3">
                                <asp:Button ID="BtnSve" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSve_Click" />
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="BtnReset" CssClass="btn btn-danger col-md-12" runat="server" Text="Reset" OnClick="BtnReset_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </form>
        </div>
        <!-- container -->
    </div>
</asp:Content>
