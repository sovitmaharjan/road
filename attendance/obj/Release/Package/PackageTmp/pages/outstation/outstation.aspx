<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="outstation.aspx.cs" Inherits="attendance.pages.outstation.outstation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
     <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">Outstation</h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue"><a href="OutStationList.aspx">Outstation List</a></li>
                            <li class="active">Add New Outstation
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
                        <label class="control-label col-md-2">Travel ID <span style="color: red">*</span></label>
                        <div class="col-md-1">
                            <asp:TextBox ID="TxtId" oninput="this.value=this.value.replace(/[^0-9.]/g,'');this.value=this.value.replace(/(\..*)\./g,'$1');" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

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
                                <asp:TextBox ID="TxtNepaliDate" AutoComplete="off" CssClass="form-control nepaliDate1" placeholder="Nepali Date" runat="server"></asp:TextBox>
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
                            <div class="form-group">
                                <label class="control-label col-md-2">Employee Name <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="DDLEmployee" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Employee List" AutoPostBack="true"
                                        EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="DDLEmployee_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="TxtEmpId" oninput="this.value=this.value.replace(/[^0-9.]/g,'');this.value=this.value.replace(/(\..*)\./g,'$1');" CssClass="form-control" AutoComplete="off" AutoPostBack="true" runat="server" OnTextChanged="TxtEmpId_TextChanged"></asp:TextBox>
                                </div>
                            </div>


                            <%--<div class="form-group">
                                <label class="control-label col-md-2">No of Days <span style="color: red">*</span></label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="TxtDays" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>--%>

                            <div class="form-group">
                                <label class="control-label col-md-2">Station<span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtStation" CssClass="form-control" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Description <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDescription" TextMode="multiline" Columns="40" Rows="5" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Approved By <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="DDLApprover" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Approver List" AutoPostBack="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="DDLApprover_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                    <div class="form-group">
                        <label class="control-label col-md-2">Status <span style="color: red">*</span></label>
                        <div class="col-md-5">
                            <asp:RadioButton ID="rbsta" Checked="true" GroupName="rbsta" runat="server" />
                            Active
                            <asp:RadioButton ID="rbsta1" GroupName="rbsta" runat="server" />
                            InActive
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
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>