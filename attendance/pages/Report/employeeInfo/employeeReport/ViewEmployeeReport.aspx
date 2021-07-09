<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="ViewEmployeeReport.aspx.cs" Inherits="attendance.pages.Report.employeeInfo.employeeReport.employeeReportList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="blue">Employee</li>
                            <li class="active">View Employee Information Report
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
                            Department :
                            <asp:Label ID="lblDept" CssClass="control-label" runat="server" Text=""></asp:Label>
                        </div>

                        <div class="col-md-6">
                            Status :
                            <asp:Label ID="lblStatus" CssClass="control-label" runat="server" Text=""></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView"
                                runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No records has been added."
                                >
                                <RowStyle HorizontalAlign="center" BackColor="White" ForeColor="#000000" />
                                <RowStyle VerticalAlign="Bottom" />

                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee (ID)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("emp_fullname")+ " " +"("+ Eval("EMP_ID") +")"%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="GENDER" HeaderText="gender" />
                                    <asp:BoundField DataField="MARITALSTATUS" HeaderText="Marital Status" />
                                    <asp:BoundField DataField="EMP_DOB" HeaderText="DOB" DataFormatString="{0:yyyy/MM/dd}" />
                                    <asp:BoundField DataField="EMP_JOINDATE" HeaderText="JOD" DataFormatString="{0:yyyy/MM/dd}" />
                                    <asp:BoundField DataField="DEG_NAME" HeaderText="Designation" />
                                    <asp:BoundField DataField="GRADE_NAME" HeaderText="Grade" />
                                    <asp:BoundField DataField="DEPT_NAME" HeaderText="Department" />
                                    <asp:BoundField DataField="MODE_NAME" HeaderText="Mode" />
                                    <asp:BoundField DataField="HOD_NAME" HeaderText="HOD" />
                                    <asp:BoundField DataField="TypeName" HeaderText="USer Type" />
                                    
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
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>