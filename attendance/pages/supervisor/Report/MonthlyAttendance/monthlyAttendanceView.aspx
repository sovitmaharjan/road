<%@ Page Title="" Language="C#" MasterPageFile="~/pages/supervisor/supervisor.Master" AutoEventWireup="true" CodeBehind="monthlyAttendanceView.aspx.cs" Inherits="attendance.pages.supervisor.Report.MonthlyAttendance.monthlyAttendanceView" %>
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
                            <li class="blue">Monthly Attendance Report</li>
                            <li class="active">View Monthly Attendance Report
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

                    <asp:Panel ID="Panel1" runat="server">
                        <div style="font-weight: bold;" class="col-md-6 form-group">
                            From :
                            <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>
                            To :
                            <asp:Label ID="lblEndDate" runat="server" Text="Label"></asp:Label>
                        </div>
                    </asp:Panel>

                </div>
                <asp:Panel ID="Panel2" runat="server">
                    <div style="font-weight: bold;" class="col-md-12 form-group">
                        <div class="col-md-6 hidden">
                            Project : <asp:Label ID="lblBranch" CssClass="control-label" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-md-6">
                            Department : <asp:Label ID="lblDept" CssClass="control-label" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </asp:Panel>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server"
                                Font-Size="Small" ShowHeader="False"
                                AutoGenerateColumns="False"
                                CssClass="table table-bordered table-responsive table-colored table-info"
                                EmptyDataText="No records has been added." OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Employee (ID)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("emp_Fullname")+ " " +"("+ Eval("EMP_ID") +")"%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TotalDays" HeaderText="TotalDays" />
                                    <asp:BoundField DataField="Weekend" HeaderText="Weekend" />
                                    <asp:BoundField DataField="PH" HeaderText="Public Holiday" />
                                    <asp:BoundField DataField="WorkingDay" HeaderText="WorkingDay" />
                                    <asp:BoundField DataField="AbsentDays" HeaderText="Absent Days" />

                                    <asp:BoundField DataField="SL" HeaderText="Sick" />
                                    <asp:BoundField DataField="CL" HeaderText="Casual" />
                                    <asp:BoundField DataField="HL" HeaderText="Home" />
                                    <asp:BoundField DataField="SUBL" HeaderText="Subtitution" />
                                    <asp:BoundField DataField="KL" HeaderText="Kriya" />
                                    <asp:BoundField DataField="ML" HeaderText="Maternity" />
                                    <asp:BoundField DataField="PL" HeaderText="Paternity" />

                                    <asp:BoundField DataField="PresentDays" HeaderText="Present Days" />
                                    <asp:BoundField DataField="WOW" HeaderText="Worked On Weekend" />
                                    <asp:BoundField DataField="WOPH" HeaderText="Worked On PH" />
                                    <asp:BoundField DataField="TotalPresentDays" HeaderText="Total Present Days" />

                                    <asp:BoundField DataField="Early_In" HeaderText="Early In" />
                                    <asp:BoundField DataField="Ontime" HeaderText="On Time" />
                                    <asp:BoundField DataField="Late_In_By15" HeaderText="Late by 15" />
                                    <asp:BoundField DataField="Late_In_By30" HeaderText="Late by 30" />
                                    <asp:BoundField DataField="Late_In_Beyond30" HeaderText="After 30" />

                                    <asp:BoundField DataField="TotalWHrs" HeaderText="Worked Hours" />
                                    <asp:BoundField DataField="assigned_Hrs" HeaderText="Assigned Hours" />
                                    <asp:BoundField DataField="OT" HeaderText="Difference" />
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
                        &nbsp;
                        <asp:Panel ID="pnlNote" runat="server">
                            <div class="form-group">
                                <div class="col-md-12">
                                    Total Days - Weekends - Public Holiday = Working Days
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12">
                                    Working Days - Absent Days - Total Leave = Present Days
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12">
                                    Present Days + Worked on Weekends + Worked on Public Holidays = Total Present Days
                                </div>
                            </div>
                        </asp:Panel>
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
