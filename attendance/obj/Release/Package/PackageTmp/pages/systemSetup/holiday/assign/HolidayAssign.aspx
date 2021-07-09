<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="HolidayAssign.aspx.cs" Inherits="attendance.pages.systemSetup.holiday.assign.HolidayAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">System Setup</h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                            <li class="active">Holiday Assign
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->

            <form runat="server" role="form" class="form-horizontal">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <div class="well">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtHolidayid" runat="server" Visible="false"></asp:TextBox>
                                        <label class="control-label col-md-3">Holiday Name <span style="color: red">*</span></label>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="CmbHolidayName" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Holiday List" AutoPostBack="true"
                                                EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbHolidayName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-3">Holiday Date</label>
                                        <div class="col-md-5">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtStartDate" CssClass="form-control englishDate1" DataFormatString="{0:d}" runat="server"></asp:TextBox>
                                                <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                        <label class="control-label col-md-2">Days</label>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtDays" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-3">Holiday Type</label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtHolidayType" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <label class="control-label col-md-3">Female only </label>
                                        <div class="col-md-2">
                                            <asp:CheckBox ID="chkFemale" runat="server" />
                                        </div>
                                    </div>
                                </div>

                                <asp:Label ID="lblFem" runat="server" Visible="false" Text="Label"></asp:Label>

                                <asp:GridView ID="GridView1" runat="server"
                                    Font-Size="Small"
                                    AutoGenerateColumns="False"
                                    CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                    EmptyDataText="No Employees Records has been added."
                                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound1">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="All">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" Text="All" onclick="checkAll(this);" />

                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox2" runat="server" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DEPT_ID" HeaderText="Branch ID" />
                                        <asp:BoundField DataField="DEPT_NAME" HeaderText="Department Name" />
                                        <asp:CommandField ShowSelectButton="True" SelectText="View Details" ControlStyle-CssClass="btn btn-primary" HeaderText="Action" />

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
                                <asp:Label ID="Label1" Visible="false" runat="server"></asp:Label>
                                <asp:Label ID="Label2" Visible="false" runat="server"></asp:Label>
                            </div>

                            <div class="col-md-6">
                                <%--<div class="header">
                                    <div class="col-md-8 col-md-offset-4">
                                        <div class="col-md-3">
                                            <asp:Label ID="lblmsg" runat="server" Text="Details"></asp:Label>
                                        </div>
                                    </div>
                                </div>--%>
                                <div class="body">
                                    <asp:GridView ID="grvDetails" runat="server"
                                        Font-Size="Small"
                                        AutoGenerateColumns="False"
                                        CssClass="datatable-fixed-col datatable-fixed-header table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                        EmptyDataText="No Employees Records has been added.">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select All">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkdetails" runat="server" Text=" All" onclick="checkAll(this);" />

                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk2" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="EMP_ID" HeaderText="P No" />
                                            <asp:BoundField DataField="emp_fullname" HeaderText="Employee" />
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
                                    <div class="col-md-5">
                                        <asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSave_Click" />
                                    </div>
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <div class="col-md-5">
                                        <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--<div class="col-md-6">
                        </div>--%>
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

                //Get the Cell To find out ColumnIndex

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        //If the header checkbox is checked

                        //check all checkboxes

                        //and highlight all rows

                        // row.style.backgroundColor = "aqua";

                        inputList[i].checked = true;

                    }

                    else {

                        //If the header checkbox is checked

                        //uncheck all checkboxes

                        //and change rowcolor back to original

                        if (row.rowIndex % 2 == 0) {

                            //Alternating Row Color

                            //row.style.backgroundColor = "#C2D69B";

                        }

                        else {

                            // row.style.backgroundColor = "white";

                        }

                        inputList[i].checked = false;

                    }

                }

            }

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
