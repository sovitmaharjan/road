<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="PH.aspx.cs" Inherits="attendance.pages.Cancellation.PH.PH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Subsitute Cancellation</li>
                            <li class="active">PH Subsitute Cancellation</li>
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
                <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="well">
                            <div class="form-group">
                                <label class="control-label col-md-2">Employee ID <span style="color: red">*</span></label>
                                <div class="col-md-2">
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

                            <div class="form-group">
                                <label class="control-label col-md-2">Holiday Name <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="DDLHolidayList" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDLHolidayList_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-2">Holiday Date <span style="color: red">*</span></label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtHolidayDate" CssClass="form-control" ReadOnly="true" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                                <label class="control-label col-md-2">Subsituted Date <span style="color: red">*</span></label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtSubsitutedDate" CssClass="form-control" ReadOnly="true" AutoComplete="off" runat="server"></asp:TextBox>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>