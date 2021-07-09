<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="dailyAbsentList.aspx.cs" Inherits="attendance.pages.Report.attendanceReport.dailyAbsent.dailyAbsentList" %>

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
                            <li class="active">View DailyAbsent Report
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
                        <asp:Button ID="BtnExport" CssClass="btn btn-success col-md-2   " runat="server" Text="Excel" OnClick="BtnExport_Click" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"
                                OnRowDataBound="GridView1_RowDataBound"
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No records has been added.">
                                <AlternatingRowStyle BackColor="White" />

                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="emp_name" HeaderText="Employee" />
                                    <asp:BoundField DataField="emp_id" HeaderText="EMP ID" />   
                                    <asp:BoundField DataField="tdate" HeaderText="Date" DataFormatString="{0:yyyy/MM/dd}" />
                                    <asp:BoundField DataField="dept_name" HeaderText="Department" />
                                    <asp:BoundField DataField="duty_roster" HeaderText="Duty Roster" />
                                    <asp:BoundField DataField="intime" HeaderText="In Time" />
                                    <asp:BoundField DataField="outtime" HeaderText="Out Time" />
                                    <asp:BoundField DataField="worked" HeaderText="Worked Hour" />
                                    <asp:BoundField DataField="remarks" HeaderText="Remarks" />
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
                                        <asp:Label ID="Label1" runat="server" Text="Daily Absent Report"></asp:Label>
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
