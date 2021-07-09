<%@ Page Title="" Language="C#" MasterPageFile="~/pages/supervisor/supervisor.Master" AutoEventWireup="true" CodeBehind="employeeList.aspx.cs" Inherits="attendance.pages.supervisor.HRM.employeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">HR Management </h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="active">Employees List
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->
            <form runat="server" role="form" class="form-horizontal">

                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <table id="datatable" class="table table-striped table-bordered table-hover table-responsive table-colored table-info">
                                <thead>
                                    <tr>
                                        <th>S.N </th>
                                        <th>Full Name (ID) </th>
                                        <th>Designation </th>
                                        <th>Grade </th>
                                        <th>Department </th>
                                        <th>Branch</th>
                                        <th>Status </th>
                                        <th>Actions </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="tableBody" runat="server"></asp:Literal>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
