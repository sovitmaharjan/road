<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="subsituteLeaveLapse.aspx.cs" Inherits="attendance.pages.Report.attendanceReport.subsituteLeave.subsituteLeave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="blue">Attendance Reports</li>
                            <li class="active">Subsitute Leave Report</li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-color panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title"><span class="text-danger">* </span>Denotes Mandatory Fields </h3>
                        </div>
                        <div class="panel-body">
                            <h4 class="m-t-0 header-title"></h4>
                            <p class="text-muted m-b-30 font-13"></p>
                            <form class="form-horizontal" runat="server">
                                <div class="col-md-12">
                                    <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Department <span class="text-danger">* </span></label>
                                                <div class="col-md-5">
                                                    <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Department List" AutoPostBack="true"
                                                        EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbDepartment_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-3"></div>
                                                <div class="col-md-1">
                                                    <asp:CheckBox ID="chkDept" AutoPostBack="True" runat="server" OnCheckedChanged="chkDept_CheckedChanged" /><span class="lbl"> All</span>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Employee <span class="text-danger">* </span></label>
                                                <div class="col-md-5">
                                                    <asp:DropDownList ID="CmbEmployee" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Employee List" AutoPostBack="true"
                                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbEmployee_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                                <label class="col-md-2 control-label">Employee Id </label>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txtEmpId" CssClass="form-control onlyNumber" AutoComplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtEmpId_TextChanged"></asp:TextBox>
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:CheckBox ID="Chkemp" AutoPostBack="True" runat="server" OnCheckedChanged="Chkemp_CheckedChanged" /><span class="lbl"> All</span>
                                                </div>
                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                &nbsp;
                                &nbsp;

                                <div class="form-group row">
                                    <div class="col-sm-9 col-sm-offset-2">
                                        <div class="button-list">
                                            <asp:Button ID="BtnLoad" Text="Load" CssClass="btn btn-success btn-bordered w-md btn-bordered col-md-1" OnClick="BtnLoad_Click" runat="server" />
                                            <asp:Button ID="BtnReset" CssClass="btn btn-danger btn-bordered btn-bordered w-md waves-light col-md-1" runat="server" Text="Cancel" OnClick="BtnReset_Click" />
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end row -->
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
