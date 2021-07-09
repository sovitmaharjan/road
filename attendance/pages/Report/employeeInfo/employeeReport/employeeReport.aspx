<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="employeeReport.aspx.cs" Inherits="attendance.pages.Report.employeeInfo.employeeReport.employeeReport" %>

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
                            <li class="blue">Employee </li>
                            <li class="active">Employee Information Report
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
                                    <asp:DropDownList ID="CmbDepartment" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Department List" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" SelectedIndexChanged="CmbDepartment_SelectedIndexChanged" OnSelectedIndexChanged="CmbDepartment_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:CheckBox ID="ChkDept" AutoPostBack="True" runat="server" OnCheckedChanged="ChkDept_CheckedChanged" /><span class="lbl"> All </span>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Status <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbStatus" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Status List" AutoPostBack="true" OnSelectedIndexChanged="CmbStatus_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Type <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbType" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Type List" AutoPostBack="true" OnSelectedIndexChanged="CmbType_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Sort <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbSort" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Sort List" AutoPostBack="true" OnSelectedIndexChanged="CmbSort_SelectedIndexChanged">
                                        <asp:ListItem Value="1" Text="Sort By Name" />
                                        <asp:ListItem Value="2" Text="Sort By EMP ID" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-8 col-md-offset-4">
                            <div class="col-md-3">
                                <asp:Button ID="BtnLoad" CssClass="btn btn-success col-md-12" runat="server" Text="Load" OnClick="BtnLoad_Click" />
                            </div>

                            <div class="col-md-3">
                                <asp:Button ID="BtnReset" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnReset_Click" />
                            </div>
                        </div>
                        </div>
                        <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView"
                                runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No records has been added."
                                >
                                <RowStyle HorizontalAlign="center" BackColor="White" ForeColor="#000000" />
                                <RowStyle VerticalAlign="Bottom" />

                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee (ID)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("emp_fullname")+ " " +"("+ Eval("EMP_ID") +")"%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="GENDER" HeaderText="gender" />
                                    <asp:BoundField DataField="MARITALSTATUS" HeaderText="Marital Status" />
                                    <asp:BoundField DataField="EMP_DOB" HeaderText="DOB" DataFormatString="{0:yyyy/MM/dd}" />
                                    <asp:BoundField DataField="EMP_JOINDATE" HeaderText="JOD" DataFormatString="{0:yyyy/MM/dd}" />
                                    <asp:BoundField DataField="DEG_NAME" HeaderText="Designation" />
                                    <asp:BoundField DataField="GRADE_NAME" HeaderText="Grade" />
                                    <asp:BoundField DataField="DEPT_NAME" HeaderText="Department" />
                                    <asp:BoundField DataField="MODE_NAME" HeaderText="Type" />
                                    <asp:BoundField DataField="STATUS_NAME" HeaderText="Status" />
                                    <asp:BoundField DataField="HOD_NAME" HeaderText="HOD" />
                                    <asp:BoundField DataField="TypeName" HeaderText="USer Type" />
                                    
                                </Columns>
                                <FooterStyle BackColor="#99CCCC" ForeColor="White" />
                                <HeaderStyle BackColor="#6274CF" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="White" HorizontalAlign="Left" />
                                <RowStyle BackColor="#EFF3FB" />

                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />
                            </asp:GridView>
                        </div>
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
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>