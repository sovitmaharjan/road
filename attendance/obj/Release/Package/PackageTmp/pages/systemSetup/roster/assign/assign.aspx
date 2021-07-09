<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="assign.aspx.cs" Inherits="attendance.pages.systemSetup.roster.assign.assign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">System Setup</h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Roster Mgmt</li>
                            <li class="active">Rooster Assign
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->

            <form runat="server" role="form" class="form-horizontal">
                <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                <div class="col-md-6">
                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="well">
                                <div class="form-group">
                                    <label class="control-label col-md-3">Department <span style="color: red">*</span></label>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List" AutoPostBack="true"
                                            EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbDepartment_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="table-responsive">
                                    <asp:GridView ID="GridView2" runat="server"
                                        Font-Size="Small"
                                        AutoGenerateColumns="False"
                                        CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                        EmptyDataText="No Employees Records has been added." BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
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

                                            <asp:BoundField DataField="emp_fullname" HeaderText="Employee" />
                                            <asp:BoundField DataField="EMP_ID" HeaderText="ID" />
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

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-6">
                    <div class="well clearfix">
                        <div class="form-group">
                            <label class="control-label col-md-2">From <span style="color: red">*</span></label>
                            <div class="col-md-5 ">
                                <div class="input-group">
                                    <asp:TextBox ID="txtStartDate" CssClass="form-control englishDate1" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="input-group">
                                    <asp:TextBox ID="txtNepaliDate" CssClass="form-control nepaliDate1" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-md-2">TO <span style="color: red">*</span></label>
                            <div class="col-md-5 ">
                                <div class="input-group">
                                    <asp:TextBox ID="txtEndDate" CssClass="form-control englishDate2" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="input-group">
                                    <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate2" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                            </div>
                        </div>


                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                            <ContentTemplate>

                                <div class="form-group">
                                    <label class="control-label col-md-4">Default Shift Group <span style="color: red">*</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="CmbDefaultSG" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="CmbDefaultSG_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <asp:CheckBoxList ID="chkAllEmployees" Visible="true" CssClass="table table-striped table-bordered table-hover table-responsive table-info" runat="server"></asp:CheckBoxList>

                                <div class="table-responsive">
                                    <asp:GridView ID="GVShift" runat="server" OnRowDataBound="GVShift_RowDataBound"
                                        Font-Size="Small"
                                        AutoGenerateColumns="False"
                                        CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                        EmptyDataText="No Employees Records has been added." BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField HeaderText="WorkingId" DataField="working_id" Visible="False">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Date" DataField="WeekDate"/>
                                            <asp:BoundField HeaderText="Week Day" DataField="Week_days" />
                                            <asp:TemplateField HeaderText="Assigned Group">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="CmbAssignedG" CssClass="form-control" runat="server">
                                                        <asp:ListItem>Day-off</asp:ListItem>
                                                    </asp:DropDownList>
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

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="col-md-12 col-md-offset-4">
                            <div class="col-md-3">
                                <asp:Button ID="BtnSaveRoosterMgmt" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSaveRoosterMgmt_Click" />
                            </div>

                            <div class="col-md-3">
                                <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
                            </div>
                        </div>
                    </div>
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
