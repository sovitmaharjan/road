<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="deleteAttn.aspx.cs" Inherits="attendance.pages.delete.deleteAttn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Delete</li>
                            <li class="active">Attendance
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
                                <label class="control-label col-md-2">Start Date <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="TxtStartDate" CssClass="form-control englishDate7" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                        <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="TxtNepaliDate" AutoComplete="off" CssClass="form-control nepaliDate7" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                        <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                        </span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-2 control-label">End Date <span class="text-danger">* </span></label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="TxtEndDate" CssClass="form-control englishDate8" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                        <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate8" Autocomplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                        <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Branch <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbBranch" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List" AutoPostBack="true"
                                        EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbBranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Department <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List" AutoPostBack="true"
                                        EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbDepartment_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Employee <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbEmployee" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbEmployee_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <label class="control-label col-md-2">Employee ID <span style="color: red">*</span></label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtEmpId" CssClass="form-control" AutoComplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtEmpId_TextChanged"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-8 col-md-offset-4">
                                <div class="col-md-3">
                                    <asp:Button ID="BtnLoad" CssClass="btn btn-success col-md-12" runat="server" Text="Load" OnClick="BtnLoad_Click" />
                                </div>
                            </div>
                        </div>

                        <%--&nbsp;--%>
                        <div class="from-group">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridView" runat="server"
                                            ShowHeader="True"
                                            Font-Size="Small"
                                            AutoGenerateColumns="false"
                                            CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                            EmptyDataText="No records has been added.">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkdetails" runat="server" onclick="checkAll(this);" />
                                                        All
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk2" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Employee">
                                                    <ItemTemplate>
                                                        <asp:Label ID="emp_name" runat="server" Text='<%# Eval("emp_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="EMP_ID" runat="server" Text='<%# Eval("EMP_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="IN Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="InDate" runat="server" Text='<%# Eval("TDATE","{0:yyyy-MM-dd}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="INTIME">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Intime" runat="server" Text='<%# Eval("INTIME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="INMODE">
                                                    <ItemTemplate>
                                                        <asp:Label ID="InMode" runat="server" Text='<%# Eval("INMODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="INREMARKS">
                                                    <ItemTemplate>
                                                        <asp:Label ID="InRemarks" runat="server" Text='<%# Eval("INREMARKS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="OUT Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="outDate" runat="server" Text='<%# Eval("TDATE_OUT","{0:yyyy-MM-dd}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="OUTTIME">
                                                    <ItemTemplate>
                                                        <asp:Label ID="outTime" runat="server" Text='<%# Eval("OUTTIME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="OUTMODE">
                                                    <ItemTemplate>
                                                        <asp:Label ID="outMode" runat="server" Text='<%# Eval("OUTMODE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="OUTREMARKS">
                                                    <ItemTemplate>
                                                        <asp:Label ID="outRemarks" runat="server" Text='<%# Eval("OUTREMARKS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Counter">
                                                    <ItemTemplate>
                                                        <asp:Label ID="shift" runat="server" Text='<%# Eval("Shift") %>'></asp:Label>
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
                                <asp:Button ID="BtnDelete" CssClass="btn btn-success col-md-12" runat="server" Text="Delete" OnClick="BtnDelete_Click" />
                            </div>

                            <div class="col-md-3">
                                <asp:Button ID="BtnReset" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnReset_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
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
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
