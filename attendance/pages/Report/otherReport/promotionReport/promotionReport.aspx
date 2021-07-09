<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="promotionReport.aspx.cs" Inherits="attendance.pages.Report.otherReport.promotionReport.promotionReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="active">Promotion  Report
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
                <div class="well">
                    <div class="form-group">
                        <label class="control-label col-md-2">Start Date <span style="color: red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtStartDate" CssClass="form-control englishDate1" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtNepaliDate" CssClass="form-control nepaliDate1" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>

                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-2">End Date <span style="color: red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtEndDate" CssClass="form-control englishDate2" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate2" Autocomplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="form-group hidden">
                                <label class="control-label col-md-2">Branch <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbBranch" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbBranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Department <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbDepartment_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>


                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <asp:Button ID="BtnLoad" CssClass="btn btn-success col-md-12" runat="server" Text="Load" OnClick="BtnLoad_Click" />
                    </div>

                    <div class="col-md-3">
                        <asp:Button ID="BtnReset" CssClass="btn btn-danger col-md-12" runat="server" Text="Reset" OnClick="BtnReset_Click" />
                    </div>
                </div>
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>
