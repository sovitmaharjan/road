<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="deleteAssignedPH.aspx.cs" Inherits="attendance.pages.delete.deleteAssignedPH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Delete</li>
                            <li class="active">Assigned PH
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
                                <label class="control-label col-md-2">Employee <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbEmployee" CssClass="form-control" runat="server" ToolTip="Employee List" AutoPostBack="true" OnSelectedIndexChanged="CmbEmployee_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <label class="control-label col-md-2">Employee ID <span style="color: red">*</span></label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtEmpId" CssClass="form-control" AutoComplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtEmpId_TextChanged"></asp:TextBox>
                                </div>

                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Public Holiday <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbPH" CssClass="form-control" runat="server" ToolTip="Employee List" AutoPostBack="true" OnSelectedIndexChanged="CmbPH_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtPHDate" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-8 col-md-offset-4">
                                <div class="col-md-3">
                                    <asp:Button ID="BtnLoad" CssClass="btn btn-success col-md-12" runat="server" Text="Load" OnClick="BtnLoad_Click" />
                                </div>
                            </div>
                        </div>

                        <%--&nbsp;--%>
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
                                                        <asp:Label ID="emp_name" runat="server" Text='<%# Eval("emp_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="EMP_ID" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Holiday Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Holiday_name" runat="server" Text='<%# Eval("Holiday_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Remarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="PH Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="PHDATE" runat="server" Text='<%# Eval("PHDATE","{0:yyyy-MM-dd}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

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
        <!-- container -->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
