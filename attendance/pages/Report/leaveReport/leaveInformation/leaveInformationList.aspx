<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="leaveInformationList.aspx.cs" Inherits="attendance.pages.Report.leaveReport.leaveInformation.leaveInformationList" %>
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
                            <li class="active">View Leave Information Report
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
                        <asp:Button ID="BtnExport" CssClass="btn btn-success col-md-2 " runat="server" Text="Excel" OnClick="BtnExport_Click" />
                    </div>
                </div>
                <div class="col-md-12 form-group" style="font-weight: bold;">
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="col-md-6">
                            Employee :
                            <asp:Label ID="lblBranch" CssClass="control-label" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-md-6">
                            Department :
                            <asp:Label ID="lblDept" CssClass="control-label" runat="server" Text=""></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1"
                                runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No records has been added."
                                OnDataBound="GridView1_DataBound" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                <RowStyle HorizontalAlign="center" BackColor="White" ForeColor="#000000" />
                                <RowStyle VerticalAlign="Bottom" />
                                <Columns>
                                    <asp:BoundField DataField="LEAVE_NAME" HeaderText="Leave Name" />
                                    <asp:BoundField DataField="OP" HeaderText="Last Year" SortExpression="OutTime" />
                                    <asp:BoundField DataField="Given" HeaderText="Given" />
                                    <asp:BoundField DataField="Taken" HeaderText="Taken" />


                                    <asp:TemplateField HeaderText="Balance">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%#Convert.ToDouble(Eval("OP")) + Convert.ToDouble(Eval("Given")) - Convert.ToDouble(Eval("Taken")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="LEAVE_DATE" HeaderText="Taken Date" DataFormatString="{0:yyyy/MM/dd}" />

                                    <asp:BoundField DataField="APPROVEDBY" HeaderText="Approved By" />
                                    <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" />
                                </Columns>
                                <FooterStyle BackColor="#99CCCC" ForeColor="White" />
                                <HeaderStyle BackColor="#6274CF" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="White" HorizontalAlign="Left" />
                                <RowStyle BackColor="#EFF3FB" />

                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />
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
