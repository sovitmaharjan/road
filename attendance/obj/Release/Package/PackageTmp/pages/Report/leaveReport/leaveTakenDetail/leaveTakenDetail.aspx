<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="leaveTakenDetail.aspx.cs" Inherits="attendance.pages.Report.leaveReport.leaveTakenDetail.leaveTakenDetail" %>

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
        Loading. Please wait.
        <br />
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
                            <li class="blue">Leave Reports</li>
                            <li class="active">Leave Taken Monthly Report
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
                        <div class="col-md-5">
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
                        <label class="control-label col-md-2">End Date <span style="color: red">*</span></label>
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
                                <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate2" Autocomplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <asp:ScriptManager ID="scrManager" runat="server">
                    </asp:ScriptManager>

                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="form-group">
                                <label class="control-label col-md-2">Branch <span style="color: red">*</span></label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="CmbBranch" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbBranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Department <span style="color: red">*</span></label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbDepartment_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:CheckBox ID="ChkDept" AutoPostBack="True" runat="server" OnCheckedChanged="ChkDept_CheckedChanged" /><span class="lbl"> All Department</span>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Employee <span style="color: red">*</span></label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="CmbEmployee" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbEmployee_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <label class="control-label col-md-2">Employee ID <span style="color: red">*</span></label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtEmpId" CssClass="form-control" AutoComplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtEmpId_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-sm-2">
                                    <asp:CheckBox ID="chkEmployee" AutoPostBack="True" runat="server" OnCheckedChanged="chkEmployee_CheckedChanged" /><span class="lbl"> All Employee</span>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Leave <span style="color: red">*</span></label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="CmbLeave" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Branch List"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:CheckBox ID="chkLeave" AutoPostBack="True" runat="server" OnCheckedChanged="chkLeave_CheckedChanged" /><span class="lbl"> All Leave</span>
                                </div>
                            </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="col-md-8 col-md-offset-4">
                        <div class="col-md-3">
                            <asp:Button ID="BtnLoad" CssClass="btn btn-success col-md-12" runat="server" Text="Load" OnClick="BtnLoad_Click" />
                        </div>

                        <div class="col-md-3">
                            <asp:Button ID="BtnReset" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnReset_Click" />
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>
