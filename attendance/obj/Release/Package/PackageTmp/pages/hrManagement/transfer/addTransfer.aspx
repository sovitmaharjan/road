<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="addTransfer.aspx.cs" Inherits="attendance.pages.hrManagement.transfer.addTransfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="dashboard">Home</a></li>
                            <li class="blue"><a href="transferList">Transfer List</a></li>
                            <li class="active">Add New Transfer
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
                <asp:ScriptManager ID="scrManager" runat="server">
                </asp:ScriptManager>
                <div>
                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>

                            <div class="form-group">
                                <label class="control-label col-md-2">Employee ID <span style="color: red">*</span></label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtEmpId" CssClass="form-control" AutoComplete="off" AutoPostBack="true" runat="server" OnTextChanged="txtEmpId_TextChanged"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label CssClass="control-label col-md-2" runat="server">Employee Name <span style="color:red">*</span></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtName" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">Date <span style="color: red">*</span></label>
                    <div class="col-md-4">
                        <div class="input-group">
                            <asp:TextBox ID="TxtDate" CssClass="form-control englishDate2" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>

                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="input-group">
                            <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate2" Autocomplete="off" AutoPostBack="true" placeholder="Nepali Date" runat="server"></asp:TextBox>
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>

                </div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="col-md-6 well">
                            <h4>
                                <asp:Label CssClass="control-label" runat="server">Transfer From </asp:Label></h4>
                            <div class="form-group">
                                <asp:Label CssClass="control-label col-md-4" runat="server">Branch </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TxtBranch" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="TxtBranchId" Visible="false" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label CssClass="control-label col-md-4" runat="server"> Department </asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TxtDepartment" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="TxtDepartmentID" Visible="false" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="col-md-6 well">
                            <h4>
                                <asp:Label CssClass="control-label" runat="server">Transfer To </asp:Label></h4>
                            <div class="form-group">
                                <asp:Label CssClass="control-label col-md-4" runat="server"> Branch </asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="CmbBranch" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="District List" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item" AutoPostBack="true" OnSelectedIndexChanged="CmbBranch_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label CssClass="control-label col-md-4" runat="server"> Department </asp:Label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="District List" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" InitialValue="Unselectable Item" OnSelectedIndexChanged="CmbDepartment_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="form-group col-md-8">
                    <label class="control-label col-md-3">Latest Transfer</label>
                    <div class="col-md-1">
                        <asp:CheckBox ID="chkTransfer" runat="server" />
                    </div>
                </div>
                <div class="form-group col-md-8">
                    <label class="control-label col-md-3">Description</label>
                    <asp:TextBox ID="txtDescription" TextMode="multiline" Columns="50" Rows="5" runat="server" />
                </div>
                <div class="col-md-8 col-md-offset-4">
                    <div class="col-md-3">
                        <%--<asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSave_Click" />--%>
                        <asp:Button ID="Button1" CssClass="btn btn-success col-md-12" runat="server" Text="Save" />
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
