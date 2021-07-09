<%@ Page Title="" Language="C#" MasterPageFile="~/pages/supervisor/supervisor.Master" AutoEventWireup="true" CodeBehind="leaveApplicationList.aspx.cs" Inherits="attendance.pages.supervisor.AttendanceManagement.LeaveApplication.leaveApplicationList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="dashboard">Home</a></li>
                            <li class="blue">Attendance Management</li>
                            <li class="active">Leave List
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
                        <asp:Button ID="BtnNew" CssClass="btn btn-primary col-md-2" runat="server" Text="ADD" OnClick="BtnNew_Click" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView" runat="server" ShowHeader="false"
                                Font-Size="Small"
                                AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Leave Application Records has been added."
                                OnRowDataBound="GridView_RowDataBound" OnRowCreated="GridView_Merge_Header_RowCreated" OnRowCommand="GridView_RowCommand"
                                >
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SNo" />
                                    <asp:BoundField DataField="EmpName"/>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("LEAVE_DATE","{0:yyyy-MM-dd}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="LEAVE_NAME"/>
                                    <asp:BoundField DataField="TAKEN"/>
                                    <asp:BoundField DataField="REMARKS"/>
                                    <asp:BoundField DataField="ApprovedName"/>
                                    <asp:BoundField DataField="IsRegular"/>
                                    <asp:BoundField DataField="LEAVETYPE"/>
                                    <asp:BoundField DataField="DAYPART"/>
                                    <asp:BoundField DataField="STATUS"/>
                                    <asp:ButtonField HeaderText="" CommandName="Approve" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Approve">
                                    <ControlStyle CssClass=" btn btn-primary"></ControlStyle>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:ButtonField>
                                <asp:ButtonField HeaderText="" CommandName="DisApprove" Text="DisApprove" ControlStyle-CssClass="btn btn-green" ButtonType="Button">

                                    <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:ButtonField>
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
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
