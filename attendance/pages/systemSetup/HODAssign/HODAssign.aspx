<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="HODAssign.aspx.cs" Inherits="attendance.pages.systemSetup.HODAssign.HODAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">System Setup</h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                            <li class="active">HOD Assign
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
                            <div class="form-group">
                                <label class="col-md-2 control-label">Department <span class="text-danger">* </span></label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" ToolTip="Department List">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-2 control-label">Employee <span class="text-danger">* </span></label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="CmbEmployee" CssClass="form-control" AutoPostBack="true" runat="server" ToolTip="Employee List" OnSelectedIndexChanged="CmbEmployee_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <label class="col-md-2 control-label">Employee Id </label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtEmpId" CssClass="form-control" AutoComplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtEmpId_TextChanged"></asp:TextBox>
                                </div>
                            </div>

                            &nbsp;
                            &nbsp;

                            <div class="form-group row">
                                <div class="col-sm-9 col-sm-offset-2">
                                    <div class="button-list">
                                        <asp:Button ID="BtnSave" Text="Save" CssClass="btn btn-success btn-bordered w-md btn-bordered col-md-1" OnClick="BtnSave_Click" runat="server" />
                                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger btn-bordered btn-bordered w-md waves-light col-md-1" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="table-responsive">
                            <asp:GridView ID="GridView" runat="server"
                                Font-Size="Small" ShowHeaderWhenEmpty="true"
                                AutoGenerateColumns="False"
                                CssClass="table table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Records has been added." BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S.N" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="dept_name" HeaderText="Department Name" />
                                    <asp:BoundField DataField="emp_name" HeaderText="Employee Name" />
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
