<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="EditDepartment.aspx.cs" Inherits="attendance.pages.systemSetup.department.EditDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">System Setup</h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                            <li class="blue"><a href="Department.aspx">Department List</a></li>
                            <li class="active">Edit Department
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
                    <asp:TextBox ID="DEPT_ID" runat="server" Visible="False"></asp:TextBox>
                    <div class="form-group">
                        <label class="control-label col-md-3">Department Name <span style="color: red">*</span></label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtDeptname" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-3">Status <span style="color: red">*</span></label>
                        <div class="col-md-5">
                            <asp:RadioButton ID="rbStatus" GroupName="rbStatus" runat="server" />
                            Active
                            <asp:RadioButton ID="rbStatus1" GroupName="rbStatus" runat="server" />
                            InActive
                        </div>
                    </div>
                </div>

                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <asp:Button ID="BtnUpdate" CssClass="btn btn-success col-md-12" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
                    </div>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <div class="col-md-3">
                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
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
