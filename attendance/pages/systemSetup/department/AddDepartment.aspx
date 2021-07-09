<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="AddDepartment.aspx.cs" Inherits="attendance.pages.systemSetup.department.AddDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">System Setup</h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                            <li class="blue"><a href="DepartmentList.aspx">Department List</a></li>
                            <li class="active">Add New Department
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
                <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="well">
                            <asp:TextBox ID="DEPT_ID" CssClass="form-control hidden" runat="server"></asp:TextBox>
                            <div class="form-group">
                                <label class="control-label col-md-3">Department / Section Name <span style="color: red">*</span></label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtDeptname" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group col-md-12">
                                <label class="control-label col-md-3">Group Under <span style="color: red">*</span></label>
                                <div class="col-md-1">
                                    <asp:CheckBox ID="chkbxGroup" runat="server" AutoPostBack="true" OnCheckedChanged="chkbxGroup_CheckedChanged1" />
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Department List"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true">
                                    </asp:DropDownList>
                                    </>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Create Default Section <span style="color: red">*</span></label>
                                <div class="col-md-1">
                                    <asp:CheckBox ID="chkbxSection" runat="server" AutoPostBack="true" OnCheckedChanged="chkbxSection_CheckedChanged" />
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtSecname" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">Status <span style="color: red">*</span></label>
                                <div class="col-md-5">
                                    <asp:RadioButton ID="rbStatus" Checked="true" GroupName="rbStatus" runat="server"/>
                                    Active
                            <asp:RadioButton ID="rbStatus1" GroupName="rbStatus" runat="server" />
                                    InActive
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSave_Click" />
                    </div>
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
