<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="ViewIndividualLeaveBalanceSummary.aspx.cs" Inherits="attendance.pages.Report.leaveReport.IndividualLeaveBalanceSummary.IndividualLeaveBalanceSummaryReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="blue">Leave Reports</li>
                            <li class="active">Individual Leave Balance Summary
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
                                ShowHeader="False"
                                OnRowCreated="gvEmployee_RowCreated"
                                AutoGenerateColumns="False"
                                CssClass="table table-bordered table-responsive table-colored table-info"
                                EmptyDataText="No records has been added.">
                                <AlternatingRowStyle BackColor="White" />

                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="employeeName" HeaderText="Employee Name" />
                                    <asp:BoundField DataField="pno" HeaderText="P NO" />
                                    <asp:BoundField DataField="department" HeaderText="Department" />
                                    <asp:BoundField DataField="annualGiven" HeaderText="Annual Given" />
                                    <asp:BoundField DataField="casualGiven" HeaderText="Casual Given" />
                                    <asp:BoundField DataField="sickGiven" HeaderText="Sick Given" />
                                    <asp:BoundField DataField="annualTaken" HeaderText="Annual Taken" />
                                    <asp:BoundField DataField="casualTaken" HeaderText="Casual Taken" />
                                    <asp:BoundField DataField="sickTaken" HeaderText="Sick Taken" />
                                    <asp:BoundField DataField="annualBalance" HeaderText="Annual Balance" />
                                    <asp:BoundField DataField="casualBalance" HeaderText="Casual Balance" />
                                    <asp:BoundField DataField="SickBalance" HeaderText="Sick Balance" />
                                    <asp:BoundField DataField="leavewithout" HeaderText="Leave Without Pay" />
                                    <asp:BoundField DataField="maternityLeave" HeaderText="Maternity Leave" />
                                    <asp:BoundField DataField="mourningLeave" HeaderText="Mourning Leave" />
                                    <asp:BoundField DataField="officialLeave" HeaderText="Official Leave" />
                                    <asp:BoundField DataField="phLeave" HeaderText="PH Leave" />
                                    <asp:BoundField DataField="sustituteLeave" HeaderText="Subsitute Leave" />
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
                        </div>
                    </div>
                </div>
                <div class="col-md-12 form-group" style="font-weight: bold;">
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="col-md-12" hidden="">
                            <asp:Label ID="lblBranch" runat="server" Text="THE HIMALAYAN HOTEL"></asp:Label>
                        </div>
                        <div class="col-md-12" hidden="">
                            <asp:Label ID="lblDept" runat="server" Text="Kupondol Height, Lalitpur, Nepal"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="col-md-12 form-group" style="font-weight: bold;">
                    <asp:Panel ID="Panel2" runat="server">
                        <div class="col-md-12" hidden="">
                            <asp:Label ID="Label1" runat="server" Text="Individual Leave Balance Summary"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
