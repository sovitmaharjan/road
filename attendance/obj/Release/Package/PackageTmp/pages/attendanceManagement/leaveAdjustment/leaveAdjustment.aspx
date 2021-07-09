<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="leaveAdjustment.aspx.cs" Inherits="attendance.pages.attendanceManagement.leaveAdjustement.leaveAdjustement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Attendance Management</li>
                            <li class="active">Leave Adjustement
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
                <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="well">
                            <div class="form-group">
                                <label class="control-label col-md-2">Employee ID <span style="color: red">*</span></label>
                                <div class="col-md-2">
                                    <div class="input-group">
                                        <asp:TextBox ID="TxtId" CssClass="form-control" AutoComplete="off" AutoPostBack="true" runat="server" OnTextChanged="TxtId_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label CssClass="control-label col-md-2" runat="server">Employee Name</asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtEmp" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <asp:Label CssClass="control-label col-md-2" runat="server">Designation</asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtDesignation" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label CssClass="control-label col-md-2" runat="server">Department</asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtDept" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                                <asp:Label CssClass="control-label col-md-2" runat="server">Branch</asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtBranch" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Leave <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="DDLLeave" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="A">Add </asp:ListItem>
                                        <asp:ListItem Value="L">Less</asp:ListItem>
                                        <asp:ListItem Value="C">Cancel</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Leave Name <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="DDLLeaveList" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <label class="control-label col-md-2">Leave Days <span style="color: red">*</span></label>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtdays" oninput="this.value=this.value.replace(/[^0-9.]/g,'');this.value=this.value.replace(/(\..*)\./g,'$1');" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            &nbsp;
                            &nbsp;
                            &nbsp;
                            &nbsp;
                            &nbsp;
                            <div class="form-group row">

                                <div class="col-sm-9 col-sm-offset-2">
                                    <div class="col-md-3">
                                        <asp:Button ID="btnLoad" CssClass="btn btn-success col-md-12" runat="server" Text="Load" OnClick="btnLoad_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:GridView ID="GridView" runat="server"
                                    Font-Size="Small"
                                    AutoGenerateColumns="False"
                                    CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                    EmptyDataText="No Employees Records has been added." OnRowDataBound="GridView_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="All">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" /> All
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk2" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="SNo" HeaderText="S.N" />
                                        <asp:BoundField DataField="EMP_ID" HeaderText="EMP_ID" />
                                        
                                        <asp:TemplateField HeaderText="Employee Name">
                                            <ItemTemplate>
                                                <asp:Label ID="emp_name" runat="server" Text='<%# Eval("emp_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Leave Name">
                                            <ItemTemplate>
                                                <asp:Label ID="leave_name" runat="server" Text='<%# Eval("leave_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GIVEN">
                                            <ItemTemplate>
                                                <asp:Label ID="GIVEN" runat="server" Text='<%# Eval("GIVEN") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="txtRemarks" runat="server" Text='<%# Eval("REMARKS") %>'></asp:Label>
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

                        <div class="col-sm-9 col-sm-offset-2">
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

            <!-- container -->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">
        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        inputList[i].checked = true;

                    }

                    else {
                        inputList[i].checked = false;

                    }

                }

            }

        }

    </script>
</asp:Content>
