<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="weekendSubstitute.aspx.cs" Inherits="attendance.pages.attendanceManagement.weekendSubstitute.weekendSubstitute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Attendance Management</li>
                            <li class="active">Weekend Subsitute
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
                <div class="well">
                    <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>

                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="form-group">
                                <label class="control-label col-md-2">Employee ID <span style="color: red">*</span></label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtEmpId" oninput="this.value=this.value.replace(/[^0-9.]/g,'');this.value=this.value.replace(/(\..*)\./g,'$1');" CssClass="form-control" AutoComplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtEmpId_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-md-3"></div>
                                <label class="control-label col-md-2">Employee <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbEmployee" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Employee List" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbEmployee_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Designation <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtDesg" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                                <label class="control-label col-md-2">Status <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtSts" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Department <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtDept" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>

                                </div>
                                <label class="control-label col-md-2">Branch <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtBranch" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Country <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TextCountry" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="form-group">
                        <label class="control-label col-md-2">Weekend Date <span style="color: red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtStartDate" CssClass="form-control englishDate1" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtNepaliDate" AutoComplete="off" CssClass="form-control nepaliDate1" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-2">Subtitute Date <span style="color: red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtEndDate" CssClass="form-control englishDate2" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate2" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>

                            <div class="table-responsive">
                                <asp:GridView ID="GridView2" runat="server" Visible="true"
                                    Font-Size="Small"
                                    AutoGenerateColumns="False"
                                    CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                    EmptyDataText="No Employees Records has been added." BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="emp_name" HeaderText="Employee" />
                                        <asp:BoundField DataField="INTIME" HeaderText="IN TIME" />
                                        <asp:BoundField DataField="INMODE" HeaderText="IN MODE" />
                                        <asp:BoundField DataField="OUTTIME" HeaderText="OUT TIME" />
                                        <asp:BoundField DataField="OUTMODE" HeaderText="OUT MODE" />
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

                            <div class="col-md-8 col-md-offset-4">
                                <div class="col-md-3">
                                    <asp:Button ID="BtnLoad" CssClass="btn btn-success col-md-12" runat="server" Text="Load" OnClick="BtnLoad_Click" />
                                </div>

                                <div class="col-md-3">
                                    <asp:Button ID="BtnReset" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnReset_Click" />
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="form-group">
                                <asp:Label CssClass="control-label col-md-2" ID="approver" runat="server">Approved By <span style="color:red">*</span></asp:Label>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="CmbApprover" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" AutoPostBack="true" OnSelectedIndexChanged="CmbApprover_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <asp:TextBox ID="Txtapprover" oninput="this.value=this.value.replace(/[^0-9.]/g,'');this.value=this.value.replace(/(\..*)\./g,'$1');" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="Txtapprover_TextChanged"></asp:TextBox>
                                </div>

                                <asp:Label CssClass="control-label col-md-2" ID="Remarks" runat="server">Remarks <span style="color:red">*</span></asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtRemarks" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                    
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="col-md-8 col-md-offset-4">
                                <div class="col-md-3">
                                    <asp:Button ID="BtnSve" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSve_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </form>
                    
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>
