<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="leaveApplication.aspx.cs" Inherits="attendance.pages.attendanceManagement.leaveApplication.leaveApplication" %>


<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Attendance Management</li>
                            <li class="active">Leave Application
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->

            <div class="panel-heading">
                <h3 class="panel-title" style="color: red;">* Denotes Mandatory Fields</h3>
            </div>

            <form runat="server" role="form" class="form-horizontal">
                <asp:ScriptManager ID="scrManager" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>

                        <div class="form-group">
                            <label class="control-label col-md-6">Employee ID <span style="color: red">*</span></label>
                            <div class="col-md-1">
                                <div class="input-group">
                                    <asp:TextBox ID="TxtId" oninput="this.value=this.value.replace(/[^0-9.]/g,'');this.value=this.value.replace(/(\..*)\./g,'$1');" CssClass="form-control" AutoComplete="off" AutoPostBack="true" runat="server" OnTextChanged="TxtEmpId_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label CssClass="control-label col-md-2" runat="server">Branch <span style="color:red">*</span></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="TxtBranch" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                            <asp:Label CssClass="control-label col-md-2" runat="server">Department  <span style="color:red">*</span></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="TxtDept" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label CssClass="control-label col-md-2" runat="server">Designation <span style="color:red">*</span></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="TxtDesignation" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                            <asp:Label CssClass="control-label col-md-2" runat="server">Applicant <span style="color:red">*</span></asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox ID="TxtEmp" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label CssClass="control-label col-md-2" runat="server">Leave Name <span style="color:red">*</span></asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="DDLLeaveName" CssClass="form-control col-md-12" runat="server" CausesValidation="True" ToolTip="Leave List" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoPostBack="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="DDLLeaveName_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <asp:Label CssClass="control-label col-md-2" runat="server">Leave Type <span style="color:red">*</span></asp:Label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="DDLLeaveType" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="">Select Type</asp:ListItem>
                                    <asp:ListItem Value="N">Normal Leave</asp:ListItem>
                                    <asp:ListItem Value="F">Force Leave</asp:ListItem>
                                    <asp:ListItem Value="G">Negative Leave</asp:ListItem>
                                    <asp:ListItem Value="U">Urgent Leave</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label CssClass="control-label col-md-2" runat="server">Approved By <span style="color:red">*</span></asp:Label>
                            <div class="col-md-3">
                                <asp:DropDownList ID="DDLEMP" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List"
                                    EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" AutoPostBack="true" OnSelectedIndexChanged="DDLEMP_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:TextBox ID="Txtemp_id" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <asp:Label CssClass="control-label col-md-2" runat="server">Day <span style="color:red">*</span></asp:Label>
                            <div class="col-md-2">
                                <asp:DropDownList ID="DDLDAy" CssClass="form-control" AutoPostBack="true" runat="server" EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="DDLDAy_SelectedIndexChanged">
                                    <asp:ListItem Value=" ">Select Day</asp:ListItem>
                                    <asp:ListItem Value="1">Full Day</asp:ListItem>
                                    <asp:ListItem Value="2">Half Day</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-md-2">Remarks <span style="color: red">*</span></label>
                            <div class="col-md-4">
                                <asp:TextBox ID="Remarks" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <h4>
                                <label class="control-label col-md-2">Leave From </label>
                            </h4>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-md-2">Nepali  Date <span style="color: red">*</span></label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="txtNepaliDate" CssClass="form-control nepaliDate7" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                            </div>
                            <label class="control-label col-md-2">English Date <span style="color: red">*</span></label>
                            <div class="col-md-4 ">
                                <div class="input-group">
                                    <asp:TextBox ID="txtStartDate" CssClass="form-control englishDate7" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <h4>
                                <label class="control-label col-md-2">Leave To </label>
                            </h4>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-md-2">Nepali Date <span style="color: red">*</span></label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate8" Autocomplete="off" AutoPostBack="true" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                            </div>
                            <label class="control-label col-md-2">English Date <span style="color: red">*</span></label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <asp:TextBox ID="txtEndDate" CssClass="form-control englishDate8" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>

                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="upPnl1" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="col-md-10 col-md-offset-10">
                            <div class="col-md-3">
                                <asp:Button ID="btnLoad" class="btn btn-info" runat="server" Text="+" OnClick="btnLoad_Click" />
                            </div>
                        </div>
                        <div class="form-group">
                            <h4>
                                <asp:Label CssClass="control-label col-md-offset-2" runat="server">Details on Selected Leave </asp:Label></h4>
                        </div>
                        <div class="col-md-6 well">
                            <div class="form-group">
                                <asp:Label CssClass="control-label col-md-4" runat="server">Leave Approved </asp:Label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="leaveApproved" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label CssClass="control-label col-md-4" runat="server">Leave Used </asp:Label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="leaveUsed" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label CssClass="control-label col-md-4" runat="server">Available </asp:Label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="available" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label CssClass="control-label col-md-4" runat="server">Leave Applied </asp:Label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="leaveApplied" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridView1" runat="server"
                                            ShowHeader="True"
                                            Font-Size="Small"
                                            AutoGenerateColumns="False"
                                            CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                            EmptyDataText="No records has been added.">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="gvdate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LEAVE_NAME">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("LEAVE_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="LEAVE">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("LEAVE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="REMARKS">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("REMARKS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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
                        </div>

                        <div class="col-md-8 col-md-offset-4">
                            <div class="col-md-3">
                                <asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSave_Click" />
                            </div>

                            <div class="col-md-3">
                                <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>
