<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="deleteEmployee.aspx.cs" Inherits="attendance.pages.delete.deleteEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <!-- Start content -->
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">
                            <asp:Literal ID="pageNamePlace1" runat="server"></asp:Literal>
                        </h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li> Delete </li>
                            <li class="active">
                                <asp:Literal ID="pageNamePlace2" Text="Delete Employee" runat="server"></asp:Literal>
                            </li>
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
                            <p class="text-muted m-b-30 font-13">
                            </p>
                            <form class="form-horizontal" runat="server">
                                <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>

                                <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                                    <ContentTemplate>
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Branch
                                            <span class="text-danger">* </span>
                                                </label>
                                                <div class="col-md-4">
                                                    <asp:DropDownList ID="CmbBranch" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List" AutoPostBack="true"
                                                        EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbBranch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Department
                                            <span class="text-danger">* </span>
                                                </label>
                                                <div class="col-md-4">
                                                    <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Department List" AutoPostBack="true"
                                                        EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbDepartment_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">
                                                    Employee
                                            <span class="text-danger">* </span>
                                                </label>
                                                <div class="col-md-4">
                                                    <asp:DropDownList ID="CmbEmployee" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Employee List" AutoPostBack="true"
                                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbEmployee_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                                <label class="control-label col-md-2">Employee ID <span style="color: red">*</span></label>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txtEmpId" CssClass="form-control" AutoComplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtEmpId_TextChanged"></asp:TextBox>
                                                </div>
                                            </div>

                                            <br />
                                            <br />
                                            <div class="form-group row">
                                                <div class="col-sm-9 col-sm-offset-2">
                                                    <div class="button-list">
                                                        <asp:Button ID="BtnLoad" Text="Load" CssClass="btn btn-success btn-bordered w-md btn-bordered col-md-1" OnClick="BtnLoad_Click" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="from-group">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="GridView" runat="server"
                                                            ShowHeader="True"
                                                            Font-Size="Small"
                                                            AutoGenerateColumns="false"
                                                            CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                                            EmptyDataText="No records has been added.">
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <Columns>

                                                                <asp:TemplateField HeaderText="Employee">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="emp_fullname" runat="server" Text='<%# Eval("emp_fullname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="EMP_ID" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="dept_name" HeaderText="Department" />
                                                                <asp:BoundField DataField="branch_name" HeaderText="Branch" />
                                                                <asp:BoundField DataField="deg_name" HeaderText="Designation" />
                                                                <asp:BoundField DataField="grade_name" HeaderText="Grade" />
                                                                <asp:BoundField DataField="mode_name" HeaderText="Type" />
                                                                <asp:BoundField DataField="status_name" HeaderText="Status" />

                                                                
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
                                                <asp:Button ID="BtnDelete" CssClass="btn btn-success col-md-12" runat="server" Text="Delete" OnClick="BtnDelete_Click" />
                                            </div>

                                            <div class="col-md-3">
                                                <asp:Button ID="BtnReset" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnReset_Click" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

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
