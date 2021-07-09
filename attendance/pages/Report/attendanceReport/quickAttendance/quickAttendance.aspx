<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="quickAttendance.aspx.cs" Inherits="attendance.pages.Report.attendanceReport.quickAttendance.quickAttendance" EnableEventValidation="false" %>

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
                            <li class="active">QuickAttendance Report</li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-color panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title"><span class="text-danger">* </span>Denotes Mandatory Fields </h3>
                        </div>
                        <div class="panel-body">
                            <h4 class="m-t-0 header-title"></h4>
                            <p class="text-muted m-b-30 font-13"></p>
                            <form class="form-horizontal" runat="server">
                                <div class="col-md-12">
                                    <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Start Date <span class="text-danger">* </span></label>
                                                <div class="col-md-5">
                                                    <div class="input-group">
                                                        <asp:TextBox ID="TxtStartDate" CssClass="form-control englishDate7" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                                        <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                                    </div>
                                                </div>

                                                <div class="col-md-5">
                                                    <div class="input-group">
                                                        <asp:TextBox ID="TxtNepaliDate" AutoComplete="off" CssClass="form-control nepaliDate7" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                                        <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">End Date <span class="text-danger">* </span></label>
                                                <div class="col-md-5">
                                                    <div class="input-group">
                                                        <asp:TextBox ID="TxtEndDate" CssClass="form-control englishDate8" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                                        <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                                    </div>
                                                </div>

                                                <div class="col-md-5">
                                                    <div class="input-group">
                                                        <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate8" Autocomplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                                        <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Department <span class="text-danger">* </span></label>
                                                <div class="col-md-5">
                                                    <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Department List" AutoPostBack="true"
                                                        EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbDepartment_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Employee <span class="text-danger">* </span></label>
                                                <div class="col-md-5">
                                                    <asp:DropDownList ID="CmbEmployee" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Employee List" AutoPostBack="true"
                                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbEmployee_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                                <label class="col-md-2 control-label">Employee Id </label>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txtEmpId" CssClass="form-control onlyNumber" AutoComplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtEmpId_TextChanged"></asp:TextBox>
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:CheckBox ID="Chkemp" AutoPostBack="True" runat="server" OnCheckedChanged="Chkemp_CheckedChanged" /><span class="lbl"> All</span>
                                                </div>
                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                &nbsp;
                                &nbsp;

                                <div class="form-group row">
                                    <div class="col-sm-9 col-sm-offset-2">
                                        <div class="button-list">
                                            <asp:Button ID="BtnLoad" Text="Load" CssClass="btn btn-success btn-bordered w-md btn-bordered col-md-1" OnClick="BtnLoad_Click" runat="server" />
                                            <asp:Button ID="BtnReset" CssClass="btn btn-danger btn-bordered btn-bordered w-md waves-light col-md-1" runat="server" Text="Cancel" OnClick="BtnReset_Click" />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 form-group">
                                    <div class="col-md-6 button-list">
                                        <asp:Button ID="BtnExport" CssClass="btn btn-success col-md-2" runat="server" Text="Excel" OnClick="BtnExport_Click" CausesValidation="false" />
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
                                            <asp:Label ID="Label1" runat="server" Text="Quick Attendance Report"></asp:Label>
                                        </div>
                                    </asp:Panel>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" runat="server"
                                                ShowHeader="true"
                                                Font-Size="small"
                                                Font-color="black"
                                                AutoGenerateColumns="False"
                                                CssClass="table table-bordered table-responsive table-colored table-info"
                                                EmptyDataText="No records has been added."
                                                OnRowDataBound="GridView1_RowDataBound"
                                                OnRowCreated="gvEmployee_RowCreated">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="flag" HeaderText="Flag" />
                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("tdate","{0:MM-dd}")+ "<br>" + Eval("Shift")+ "<br>" + Eval("nepaliDate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField DataField="Duty_roster" HeaderText="Duty Roster" />--%>

                                                    <asp:BoundField DataField="InTime" HeaderText="In Time" HeaderStyle-CssClass="header1" />
                                                    <asp:TemplateField HeaderText="InRemarks" HeaderStyle-CssClass="header1">
                                                        <HeaderTemplate>
                                                            Remarks
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("INREMARKS") %>' HeaderStyle-CssClass="header1"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="INMode" HeaderText="In Mode" HeaderStyle-CssClass="header1" />
                                                    <asp:TemplateField HeaderText="Out Date" HeaderStyle-CssClass="header1">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("TDate_Out","{0:MM-dd}")%>' HeaderStyle-CssClass="header1"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="OutTime" HeaderText="Out Time" HeaderStyle-CssClass="header1" />
                                                    <asp:BoundField DataField="OUTMode" HeaderText="Out Mode" HeaderStyle-CssClass="header1" />

                                                    <asp:BoundField DataField="InTime1" HeaderText="In Time" HeaderStyle-CssClass="header2" />
                                                    <asp:BoundField DataField="INREMARKS1" HeaderText="Remarks" HeaderStyle-CssClass="header2" />
                                                    <asp:BoundField DataField="INMode1" HeaderText="In Mode" HeaderStyle-CssClass="header2" />
                                                    <asp:BoundField DataField="TDate_Out1" HeaderText="Out Date" DataFormatString="{0:yyyy/MM/dd}" HeaderStyle-CssClass="header2" />
                                                    <asp:BoundField DataField="OutTime1" HeaderText="Out Time" HeaderStyle-CssClass="header2" />
                                                    <asp:BoundField DataField="OUTREMARKS1" HeaderText="Remarks" />

                                                    <asp:BoundField DataField="Remark" HeaderText="Status" />
                                                    <asp:BoundField DataField="HrsMin" HeaderText="Worked Hour" />
                                                    <asp:BoundField DataField="TotalOT" HeaderText="Diff" />
                                                    <asp:BoundField DataField="GEnOT" HeaderText="Approved OT" />
                                                </Columns>
                                                <EditRowStyle />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" Font-Bold="True" />

                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView2" runat="server"
                                                ShowHeader="true"
                                                Font-Size="small"
                                                Font-color="black"
                                                AutoGenerateColumns="False"
                                                CssClass="table table-bordered table-responsive table-colored table-info"
                                                EmptyDataText="No records has been added.">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="emp_fullname" HeaderText="Employee" />
                                                    <asp:BoundField DataField="EMP_ID" HeaderText="ID" />
                                                    <asp:BoundField DataField="totaldays" HeaderText="Total" />
                                                    <asp:BoundField DataField="presentdays" HeaderText="Present" />
                                                    <asp:BoundField DataField="FullPresentDays" HeaderText="FULL Present" />
                                                    <asp:BoundField DataField="HalfPresentDays" HeaderText="Half Present" />

                                                    <asp:BoundField DataField="weekend" HeaderText="Weekend" />
                                                    <asp:BoundField DataField="WorkedOnWeekend" HeaderText="wow" />
                                                    <asp:BoundField DataField="WeekendSubon" HeaderText="WeSubon" />
                                                    <asp:BoundField DataField="WeekendSubof" HeaderText="WeSubof" />
                                                    <asp:BoundField DataField="PH" HeaderText="PH" />
                                                    <asp:BoundField DataField="WorkedOnPH" HeaderText="WOPH" />
                                                    <asp:BoundField DataField="phSubon" HeaderText="phSubon" />
                                                    <asp:BoundField DataField="phSubof" HeaderText="phSubof" />
                                                    <%--<asp:BoundField DataField="PHSub" HeaderText="PHSub" />--%>
                                                    <asp:BoundField DataField="WorkingDay" HeaderText="Worked" />
                                                    <asp:BoundField DataField="absentdays" HeaderText="Absent" />
                                                    <asp:BoundField DataField="Paid_leave" HeaderText="Paid leave" />
                                                    <asp:BoundField DataField="LWOP" HeaderText="LWOP" />
                                                    <asp:BoundField DataField="totalpayable" HeaderText="Payable" />
                                                    <asp:BoundField DataField="TotalWHrs" HeaderText="WHRS" />
                                                </Columns>
                                                <EditRowStyle />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" Font-Bold="True" />

                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>

                                <asp:Panel ID="Panel5" runat="server">
                                    <div class="col-md-12 form-group" style="font-weight: bold;">
                                        <div class="col-md-4">
                                            WOW : Worked On Weekend
                                        </div>
                                        <div class="col-md-4">
                                            WeSubon: Weekend Subsitute On
                                        </div>
                                        <div class="col-md-4">
                                            WeSubof: Weekend Subsitute Of
                                        </div>
                                        
                                    </div>

                                    <div class="col-md-12 form-group" style="font-weight: bold;">
                                        <div class="col-md-3">
                                            PH : Public HOliday
                                        </div>
                                        <div class="col-md-3">
                                            WOPH : Worked On Public HOliday
                                        </div>
                                        <div class="col-md-3">
                                            PHSubof : Public HOliday Subsitute Of
                                        </div>
                                        <div class="col-md-3">
                                            PHSubon : Public HOliday Subsitute On
                                        </div>
                                    </div>

                                    <div class="col-md-12 form-group" style="font-weight: bold;">
                                        <div class="col-md-4">
                                            LWOP : Leave Without Pay
                                        </div>
                                        <div class="col-md-4">
                                            Payable : Total Payable Days
                                        </div>
                                        <div class="col-md-4">
                                            WHRS : Total Worked hours
                                        </div>
                                    </div>
                                </asp:Panel>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end row -->
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>
