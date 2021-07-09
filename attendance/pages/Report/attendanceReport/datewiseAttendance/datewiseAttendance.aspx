<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="datewiseAttendance.aspx.cs" Inherits="attendance.pages.Report.attendanceReport.datewiseAttendance.datewiseAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <%--//Preloading Function--%>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });
    </script>
    <div class="loading" align="center">
        Loading. Please wait.<br />
        <br />
        <div class="spinner">
            <div class="spinner-wrapper">
                <div class="rotator">
                    <div class="inner-spin"></div>
                    <div class="inner-spin"></div>
                </div>
            </div>
        </div>
    </div>
    System.Threading.Thread.Sleep(5000);
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="blue">Attendance Reports</li>
                            <li class="active">Datewise Attendance Report
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
                    <div class="form-group">
                        <label class="control-label col-md-2">Start Date <span style="color: red">*</span></label>
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
                                <asp:TextBox ID="TxtNepaliDate" CssClass="form-control nepaliDate1" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>

                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-2">End Date <span style="color: red">*</span></label>
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
                                <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate2" autocomplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>

                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
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
                                    <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Department List" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbDepartment_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:CheckBox ID="chkDepartment" AutoPostBack="True" runat="server" OnCheckedChanged="chkDepartment_CheckedChanged" /><span class="lbl"> All Department</span>
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
                                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                                EmptyDataText="No records has been added."
                                                OnRowDataBound="GridView_RowDataBound">
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

                                                    <asp:TemplateField HeaderText="Dept">
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

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="form-group row">
                        <div class="col-sm-9 col-sm-offset-2">
                            <div class="button-list">
                                <asp:Button ID="BtnLoad" Text="Load" CssClass="btn btn-success btn-bordered w-md btn-bordered col-md-1" OnClick="BtnLoad_Click" runat="server" />
                                <asp:Button ID="BtnCancel" CssClass="btn btn-danger btn-bordered btn-bordered w-md waves-light col-md-1" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
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
