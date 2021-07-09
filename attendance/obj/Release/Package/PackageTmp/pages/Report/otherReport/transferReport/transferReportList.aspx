<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="transferReportList.aspx.cs" Inherits="attendance.pages.Report.otherReport.transferReport.transferReportList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="active">View Transfer Report
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

                        <div style="font-weight: bold;" class="col-md-12 form-group">
                            <div class="col-md-4">
                                Project :
                                <asp:Label ID="lblBranch" CssClass="control-label" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-md-4">
                                Department :
                                <asp:Label ID="lbldept" CssClass="control-label" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No records has been added.">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="EMP_ID" HeaderText="ID" />
                                    <asp:BoundField DataField="EMP_FULLNAME" HeaderText="Name" />
                                    <asp:BoundField DataField="SECTION_NAME" HeaderText="Section" />
                                    <asp:BoundField DataField="TDATE" HeaderText="Date" DataFormatString="{0:yyyy/MM/dd}" />
                                    <asp:BoundField DataField="Cur Branch" HeaderText="Current Branch" />
                                    <asp:BoundField DataField="Cur Dept" HeaderText="Current Department" />
                                    <asp:BoundField DataField="P_BRANCH_NAME" HeaderText="Promoted Branch" />
                                    <asp:BoundField DataField="P_DEPT_NAME" HeaderText="Promoted Department" />
                                    <asp:BoundField DataField="P_FNC_NAME" HeaderText="Promoted Name" />
                                    <asp:BoundField DataField="FNC_NAME" HeaderText="Name" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" />
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
