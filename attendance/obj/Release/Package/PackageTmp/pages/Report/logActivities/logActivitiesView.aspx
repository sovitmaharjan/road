<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="logActivitiesView.aspx.cs" Inherits="attendance.pages.Report.logActivities.logActivitiesView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <!-- Start content -->
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">Log Activities List </h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li>
                                <%=this.projectName%> 
                            </li>
                            <li>Report
                            </li>
                            <li class="active">Log Activities List
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="card-box table-responsive">
                        <div class="form-group">
                            <a href="~/LogActivities" class="btn btn-success waves-effect w-md waves-light" runat="server">
                                <i class="mdi mdi mdi-autorenew"></i>New 
                            </a>
                            <a href="~/LogActivities" class="btn btn-warning waves-effect w-md waves-light" runat="server">
                                <i class="mdi mdi mdi-keyboard-backspace"></i>Back 
                            </a>
                        </div>
                        <div class="form-group col-md-12" style="text-align: center; font-weight: bold;">
                            From :
                            <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>
                            To :
                            <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group col-md-6" style="text-align: left; font-weight: bold;">
                            Log Item :
                            <asp:Literal ID="logItemLiteral" runat="server"></asp:Literal>
                        </div>
                        <div class="form-group col-md-6" style="text-align: right; font-weight: bold;">
                            Log Name :
                            <asp:Literal ID="logNameLiteral" runat="server"></asp:Literal>
                        </div>
                        <form runat="server">
                            <table id="datatable" class="table table-striped  table-colored table-info">
                                <thead>
                                    <tr>
                                        <th>S.N </th>
                                        <th>Log Date </th>
                                        <th>Log Time </th>
                                        <th>Remarks </th>
                                        <th>Employee </th>
                                        <th>Event Info </th>
                                        <th>Event Date </th>
                                        <th>Event Type </th>
                                        <th>Login Name </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="tableBody" runat="server"></asp:Literal>
                                </tbody>
                            </table>
                        </form>
                    </div>
                </div>
            </div>
            <!-- end row -->
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
