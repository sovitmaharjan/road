<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="workHourList.aspx.cs" Inherits="attendance.pages.systemSetup.roster.workHour.workHourList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <!-- Start content -->
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">Holiday List </h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li>
                                <%=this.projectName%> 
                            </li>
                            <li>
                                System Setup 
                            </li>
                            <li class="active">
                                Roster 
                            </li>
                            <li class="active">
                                Work Hour List 
                            </li>
                        </ol>
                        <div class="clearfix"> </div>    
                    </div>
                </div>
            </div>
            <!-- end row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="card-box table-responsive">
                        <form runat="server">
                            <div class="form-group">
                                <a href="~/workHour" class="btn btn-success waves-effect w-md waves-light" runat="server">
                                    <i class="mdi mdi-plus"></i> Add New Work Hour 
                                </a>
                            </div>
                            <table id="datatable" class="table table-striped  table-colored table-info">
                                <thead>
                                    <tr>
                                        <th> S.N </th>
                                        <th> Group Name</th>
                                        <th> Start Time </th>
                                        <th> Late In By </th>
                                        <th> Total Hour </th>
                                        <th> Lunch Time </th>
                                        <th> End Time </th>
                                        <th> Late Out By </th>
                                        <th> Shift </th>
                                        <th> Status </th>
                                        <th> Delete </th>
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
        </div> <!-- container -->
    </div> <!-- content -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
