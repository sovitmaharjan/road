<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="ViewMissingPunch.aspx.cs" Inherits="attendance.pages.Report.inOutInfo.inOutInfoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="active">View Out Missing Report
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->
            <form runat="server" role="form" class="form-horizontal">
                <div class="col-md-12 form-group">
                    <div class="col-md-6 button-list">
                        <asp:Button ID="BtnNew" CssClass="btn btn-primary col-md-2" runat="server" Text="New" OnClick="BtnNew_Click1" />
                        <asp:Button ID="BtnExport" CssClass="btn btn-success col-md-2" runat="server" Text="Excel" OnClick="BtnExport_Click1" />
                    </div>
                </div>

                <div class="col-md-12 form-group">
                    <div style="font-weight: bold; text-align: center" class="form-group">
                        <asp:Panel ID="Panel3" runat="server">
                            From :
                                <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>
                            To :
                                <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label>
                        </asp:Panel>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Records To Show."
                                OnRowDataBound="GridView_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="TDATE" HeaderText="Date" DataFormatString="{0:yyyy/MM/dd}" />
                                    <asp:TemplateField HeaderText="Employee (ID)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("emp_fullname")+ " " +"("+ Eval("EMP_ID") +")"%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="InTime" HeaderText="In Time" />
                                    <asp:BoundField DataField="OutTime" HeaderText="Out Time" />
                                    <asp:BoundField DataField="InTime1" HeaderText="In Time" />
                                    <asp:BoundField DataField="OutTime1" HeaderText="Out Time" />
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

                <div class="col-md-12 form-group" style="font-weight: bold;">
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="col-md-12" hidden="">
                            <asp:Label ID="lblOrgName" runat="server" Text="Your Company Name"></asp:Label>
                        </div>
                        <div class="col-md-12" hidden="">
                            <asp:Label ID="lblOrgFullAddress" runat="server" Text="Your Company Address"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="col-md-12 form-group" style="font-weight: bold;">
                    <asp:Panel ID="Panel2" runat="server">
                        <div class="col-md-12" hidden="">
                            <asp:Label ID="Label1" runat="server" Text="Missing Punch"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>
