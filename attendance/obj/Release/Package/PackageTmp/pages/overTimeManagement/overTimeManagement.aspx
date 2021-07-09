<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="overTimeManagement.aspx.cs" Inherits="attendance.pages.overTimeManagement.overTimeManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="active">OverTime Management</li>
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

                    <div class="form-group">
                        <label class="control-label col-md-2">Date <span style="color: red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtStartDate" CssClass="form-control englishDate7" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtNepaliDate" AutoComplete="off" CssClass="form-control nepaliDate7" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>

                    <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="upPnl" UpdateMode="Conditional" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="form-group">
                                <label class="control-label col-md-2">Branch <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbBranch" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbBranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Department <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" ToolTip="Department List">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:CheckBox ID="ChkDept" AutoPostBack="True" runat="server" OnCheckedChanged="ChkDept_CheckedChanged" /><span class="lbl"> All Department</span>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView" runat="server"
                                                ShowHeader="True"
                                                Font-Size="Small"
                                                AutoGenerateColumns="false"
                                                OnRowDataBound="GridView_RowDataBound"
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

                                                    <asp:TemplateField HeaderText="Department">
                                                        <ItemTemplate>
                                                            <asp:Label ID="DEPT_NAME" runat="server" Text='<%# Eval("DEPT_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="id">
                                                        <ItemTemplate>
                                                            <asp:Label ID="DEPT_ID" runat="server" Text='<%# Eval("DEPT_ID") %>'></asp:Label>
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

                            <div class="col-md-12 col-md-offset-5">
                                <asp:Button ID="btnLoad" class="btn btn-info" runat="server" Text="Load" OnClick="btnLoad_Click" />
                            </div>

                            &nbsp;
                            &nbsp;
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridView1" runat="server"
                                            ShowHeader="true"
                                            Font-Size="Small"
                                            AutoGenerateColumns="False"
                                            CssClass="table table-bordered table-responsive table-colored table-info"
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
                                                <asp:TemplateField HeaderText="P ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="EMPID" runat="server" Text='<%# Eval("EMPID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="EMP_FULLNAME" HeaderText="Employee" />
                                                <asp:BoundField DataField="DEPT_NAME" HeaderText="Department" />

                                                <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="tdate" runat="server" Text='<%#Eval("tdate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Worked Hour">
                                                    <ItemTemplate>
                                                        <asp:Label ID="HrsMin" runat="server" Text='<%# Eval("HrsMin") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Approved OT">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtOT" CssClass="form-control" runat="server" Text=''></asp:TextBox>
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

                            &nbsp;
                            &nbsp;
                            <div class="col-md-12 col-md-offset-5">
                                <asp:Button ID="btnSave" class="btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click" />
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
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
