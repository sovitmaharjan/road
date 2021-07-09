<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="changePassword.aspx.cs" Inherits="attendance.pages.changePassword.changePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <!-- Start content -->
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <%--<li class="blue">Attendance Management</li>--%>
                            <li class="active">Change Password
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
                <div class="col-xs-12">
                    <div class="card-box">
                        <div class="form-group">
                            <asp:Label CssClass="control-label col-md-2" runat="server">Old Password <span style="color:red">*</span></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="TxtOldPass" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label CssClass="control-label col-md-2" runat="server">New Password  <span style="color:red">*</span></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="TxtNewPass" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label CssClass="control-label col-md-2" runat="server">Confirm Password <span style="color:red">*</span></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="TxtConPass" CssClass="form-control" AutoComplete="off" onchange="confirmpassword()" runat="server"></asp:TextBox>
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
                    </div>
                </div>
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
    
</asp:Content>
