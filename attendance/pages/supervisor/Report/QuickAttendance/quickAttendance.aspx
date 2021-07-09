 <%@ Page Title="" Language="C#" MasterPageFile="~/pages/supervisor/supervisor.Master" AutoEventWireup="true" CodeBehind="quickAttendance.aspx.cs" Inherits="attendance.pages.supervisor.Report.QuickAttendance.quickAttendance" %>
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
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">Start Date <span class="text-danger">* </span></label>
                                        <div class="col-md-5">
                                            <div class="input-group">
                                                <asp:TextBox ID="TxtNepaliDate" AutoComplete="off" CssClass="form-control nepaliDate7" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                                <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="input-group">
                                                <asp:TextBox ID="TxtStartDate" CssClass="form-control englishDate7" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                                <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                            </div>
                                        </div>
                                        
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-2 control-label">End Date <span class="text-danger">* </span></label>
                                        <div class="col-md-5">
                                            <div class="input-group">
                                                <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate8" Autocomplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                                <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="input-group">
                                                <asp:TextBox ID="TxtEndDate" CssClass="form-control englishDate8" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                                <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                            </div>
                                        </div>
                                    </div>

                                    <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <label class="control-label col-md-2">Branch <span class="text-danger">* </span></label>
                                                <div class="col-md-5">
                                                    <asp:DropDownList ID="CmbBranch" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List" AutoPostBack="true"
                                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbBranch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Department <span class="text-danger">* </span></label>
                                                <div class="col-md-5">
                                                    <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List" AutoPostBack="true"
                                                        EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbDepartment_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Employee <span class="text-danger">* </span></label>
                                                <div class="col-md-5">
                                                    <asp:DropDownList ID="CmbEmployee" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List" AutoPostBack="true"
                                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbEmployee_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                               
                                                <label class="col-md-2 control-label">Employee Id </label>
                                                <div class="col-md-2">
                                                    <asp:TextBox ID="txtEmpId" CssClass="form-control onlyNumber" AutoComplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtEmpId_TextChanged"></asp:TextBox>
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

                                &nbsp;
                                &nbsp;

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
                                    <asp:Panel ID="Panel4" runat="server">
                                        <div class="col-md-12 form-group">
                                            <div class="col-md-6">
                                                Employee :
                                                <asp:Label ID="lblEmployee" runat="server" Text=""></asp:Label>
                                                (<asp:Label ID="lblEmployeeID" runat="server" Text=""></asp:Label>)
                                            </div>
                                            <div class="col-md-6">
                                                Designation :
                                                <asp:Label ID="lblDesignation" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 form-group">
                                            <div class="col-md-6">
                                                Department :
                                                <asp:Label ID="lblDept" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="col-md-6">
                                                Branch :
                                                <asp:Label ID="lblBranch" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" runat="server"
                                                OnRowCreated="gvEmployee_RowCreated"
                                                ShowHeader="False"
                                                Font-Size="small"
                                                
                                                AutoGenerateColumns="False"
                                                CssClass="table table-bordered table-responsive table-colored table-info"
                                                EmptyDataText="No records has been added."
                                                OnRowDataBound="GridView1_RowDataBound">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                <asp:BoundField DataField="flag" HeaderText="Flag" />
                                                <%--<asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("tdate","{0:MM-dd}")+ "<br>" + Eval("Shift")+ "<br>" + Eval("nepaliDate")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:BoundField DataField="nepaliDate" />
                                                <asp:BoundField DataField="Shift" />
                                                <asp:BoundField DataField="Duty_roster" />

                                                <asp:BoundField DataField="InTime" />
                                                <asp:TemplateField HeaderText="InRemarks">
                                                    <HeaderTemplate>
                                                        Remarks
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Inremark") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Indiff" HeaderText="Difference" />
                                                <asp:BoundField DataField="INMode" HeaderText="In Mode" />

                                                <asp:BoundField DataField="OutTime" HeaderText="Out Time" />
                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOutRemarks" runat="server" Text='<%#Eval("Outremark") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="nepaliDate" HeaderText="nepaliDate" />
                                                <%--<asp:BoundField DataField="nepaliDate" HeaderText="Out Date" DataFormatString="{0:MM/dd}" />--%>
                                                <asp:BoundField DataField="Outdiff" HeaderText="Difference" />
                                                <asp:BoundField DataField="OUTMode" HeaderText="Out Mode" />
                                                <asp:BoundField DataField="worked_hrs" HeaderText="Worked Hour" />
                                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" />

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

                                        &nbsp;

                                        <asp:Panel ID="Panel5" runat="server">
                                            <div class="col-md-12 form-group" style="font-weight: bold;">
                                                <div class="col-md-4">
                                                    Total Days :
                                                <asp:Label ID="LblTotalDays" runat="server" Text=""></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    PresentDays :
                                                <asp:Label ID="LblPresentDays" runat="server" Text=""></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    Weekend :
                                                <asp:Label ID="LblWeekend" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 form-group" style="font-weight: bold;">
                                                <div class="col-md-4">
                                                    Worked on Weekend :
                                                <asp:Label ID="LblWOW" runat="server" Text=""></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    Public Holiday :
                                                <asp:Label ID="LblPH" runat="server" Text=""></asp:Label>
                                                </div>
                                                <div class="col-md-4">
                                                    Worked on Public Holiday :
                                                <asp:Label ID="LblWOPH" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 form-group" style="font-weight: bold;">
                                                <div class="col-md-3">
                                                    Leave :
                                                <asp:Label ID="LblLeaveCount" runat="server" Text=""></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    Absent :
                                                <asp:Label ID="LblAbsentDays" runat="server" Text=""></asp:Label>
                                                </div>
                                                <div class="col-md-3">
                                                    LWOP :
                                                <asp:Label ID="LblLWOP" runat="server" Text=""></asp:Label>
                                                </div>

                                                <div class="col-md-3">
                                                    Total Payble Days :
                                                <asp:Label ID="LblTotalPaybleDays" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                        </asp:Panel>

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
                                    </div>
                                </div>

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
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
