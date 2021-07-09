<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="datewiseAttendanceList.aspx.cs" Inherits="attendance.pages.Report.attendanceReport.datewiseAttendance.datewiseAttendanceList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="blue">Attendance Reports</li>
                            <li class="active">Datewise Attendance Report
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
                        <asp:Button ID="BtnNew" CssClass="btn btn-primary col-md-2" runat="server" Text="New" OnClick="BtnNew_Click" />
                        <asp:Button ID="BtnExport" CssClass="btn btn-success col-md-2" runat="server" Text="Excel" OnClick="BtnExport_Click" />
                    </div>
                    <asp:Panel ID="Panel3" runat="server">
                        <div style="font-weight: bold;" class="col-md-6">
                            From :
                        <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>
                            To :
                        <asp:Label ID="lblEndDate" runat="server" Text="Label"></asp:Label>
                        </div>
                    </asp:Panel>

                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"
                                CssClass="table table-bordered table-responsive table-colored table-info"
                                EmptyDataText="No records has been added."
                                OnRowDataBound="GridView1_RowDataBound"
                                OnRowCreated="GridView1_RowCreated">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="flag" />
                                    <%--<asp:TemplateField HeaderText="Date" ItemStyle-Font-Bold="true">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("tdate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="emp_fullname" HeaderText="Employee Name" />
                                    <asp:BoundField DataField="Emp_id" HeaderText="Emp Id" />
                                    <asp:BoundField DataField="DEPT_NAME" HeaderText="DEPT" />
                                    <asp:BoundField DataField="" HeaderText="Absent" />
                                    <asp:BoundField DataField="" HeaderText="Present" />
                                    <asp:BoundField DataField="" HeaderText="Weekend" />
                                    <asp:BoundField DataField="" HeaderText="Leave" />
                                    <asp:BoundField DataField="" HeaderText="PH" />
                                    <asp:BoundField DataField="Remark" HeaderText="Remarks" />
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
                                        <asp:Label ID="Label1" runat="server" Text="Datewise Attendance Report"></asp:Label>
                                    </div>
                                </asp:Panel>
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
