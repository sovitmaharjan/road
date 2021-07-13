<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="attendance.pages.dashboard.dashboard" %>
<asp:Content id="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">Dashboard</h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li class="active">Dashboard
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->
            <div class="row">
                <div class="col-lg-3 col-md-6">
                    <div class="card-box widget-box-two widget-two-info">
                        <i class="mdi mdi-bank widget-two-icon"></i>
                        <div class="wigdet-two-content text-white">
                            <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="Branch">Branches</p>
                            <h2 class="text-white"><span data-plugin="counterup">
                                <asp:Label ID="countBranch" runat="server"></asp:Label></span></h2>
                            <p class="m-0">
                                <b>In valley :</b>
                                <asp:Label ID="countInBranch" runat="server"></asp:Label>
                            </p>
                            <p class="m-0">
                                <b>Outside valley :</b>
                                <asp:Label ID="countOutBranch" runat="server"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <!-- end col -->

                <div class="col-lg-3 col-md-6">
                    <div class="card-box widget-box-two widget-two-primary">
                        <i class="mdi mdi-layers widget-two-icon"></i>
                        <div class="wigdet-two-content text-white">
                            <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="User This Month">Departments</p>
                            <h2 class="text-white"><span data-plugin="counterup">
                                <asp:Label ID="countDepartment" runat="server"></asp:Label></span></h2>
                            <p class="m-0">
                                <b>Active :</b>
                                <asp:Label ID="countActiveDepartment" runat="server"></asp:Label>
                            </p>
                            <p class="m-0">
                                <b>InActive :</b>
                                <asp:Label ID="countInactiveDepartment" runat="server"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <!-- end col -->

                <div class="col-lg-3 col-md-6">
                    <div class="card-box widget-box-two widget-two-danger">
                        <i class="mdi mdi-dns widget-two-icon"></i>
                        <div class="wigdet-two-content text-white">
                            <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="Statistics">Sections </p>
                            <h2 class="text-white"><span data-plugin="counterup">
                                <asp:Label ID="countSection" runat="server"></asp:Label></span></h2>
                            <p class="m-0">
                                <b>Active :</b>
                                <asp:Label ID="countActiveSection" runat="server"></asp:Label>
                            </p>
                            <p class="m-0">
                                <b>InActive :</b>
                                <asp:Label ID="countInactiveSection" runat="server"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <!-- end col -->

                <div class="col-lg-3 col-md-6">
                    <div class="card-box widget-box-two widget-two-success">
                        <i class="mdi mdi-gender-male-female widget-two-icon"></i>
                        <div class="wigdet-two-content text-white">
                            <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="User Today">Employees</p>
                            <h2 class="text-white"><span data-plugin="counterup">
                                <asp:Label ID="countEmployee" runat="server"></asp:Label>
                            </span></h2>
                            <p class="m-0">
                                <b>Female :</b>
                                <asp:Label ID="countEmployeeFemale" runat="server"></asp:Label>
                            </p>
                            <p class="m-0">
                                <b>Male :</b>
                                <asp:Label ID="countEmployeeMale" runat="server"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
                <!-- end col -->
            </div>

            &nbsp;
            <div class="row">
                <div class="col-md-4">
                    <div class="panel panel-color panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title">Birthdays</h3>
                        </div>
                        <div class="panel-body">
                            <div class="inbox-widget slimscroll-alt" style="min-height: 327px;">
                                <asp:Label ID="birthdays" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <!-- end panel -->
                </div>
                <!-- end col -->

                <div class="col-md-4">
                    <div class="panel panel-color panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title">Contract</h3>
                        </div>
                        <div class="panel-body">

                            <div class="inbox-widget slimscroll-alt" style="min-height: 327px;">
                                <asp:Label ID="tblContract" runat="server"></asp:Label>
                            </div>
                            <!-- table-responsive -->
                        </div>
                        <!-- end panel body -->
                    </div>
                    <!-- end panel -->
                </div>
                <!-- end col -->

                <div class="col-md-4">
                    <div class="panel panel-color panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title">Probation</h3>
                        </div>
                        <div class="panel-body">
                            <div class="inbox-widget slimscroll-alt" style="min-height: 327px;">
                                <asp:Label ID="tblProbabtion" runat="server"></asp:Label>
                            </div>
                        </div>
                        <!-- end panel body -->
                    </div>
                    <!-- end panel -->
                </div>
                <!-- end col -->

            </div>
            <!-- end row -->
        </div>
        <!-- container -->
    </div>
    <!-- content -->

    <%--<!-- Modal -->
    <div id="noticeModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="custom-width-modalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog" style="width:65%;">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title">Notice Topics</h4>
                </div>
                <div class="modal-body">
                    <ul>
                        <asp:Literal ID="noticeList" runat="server"></asp:Literal>
                    </ul>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger waves-effect" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div><!-- /.modal -->

    <script>
        $(document).ready(function () {
            setTimeout(function () {
                $('#noticeModal').modal('show');
            }, 2000);
        })
    </script>--%>
</asp:Content>