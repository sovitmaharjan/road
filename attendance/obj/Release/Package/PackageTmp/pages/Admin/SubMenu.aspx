<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="SubMenu.aspx.cs" Inherits="attendance.pages.Admin.SubMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- Start content -->
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li>
                                Super Admin
                            </li>
                            <li>
                                Main Menu 
                            </li>
                            <li class="active">
                                Sub Menu 
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
                                <div class="button-list">
                                    <a href="~/designation" class="btn btn-success waves-effect w-md waves-light" runat="server">
                                        <i class="mdi mdi-plus"></i>Add New 
                                    </a>
                                    <a href="~/MainMenu" class="btn btn-primary waves-effect w-md waves-light" runat="server">
                                        <i class="mdi mdi-arrow-left"></i>Back
                                    </a>
                                </div>
                            </div>
                            <div class="form-group">
                                <div style="text-align:center; font-size:large;">
                                    <label class="control-label">Menu Name :  </label>
                                    <asp:Label ID="page_name" runat="server" Text="N/A"></asp:Label>
                                </div>
                            </div>
                            &nbsp;
                            
                            <table id="datatable" class="table table-striped  table-colored table-info">
                                <thead>
                                    <tr>
                                        <th> S.N </th>
                                        <th> Title </th>
                                        <th> Url </th>
                                        <th> Sub Menu </th>
                                        <th style="text-align: center">Actions </th>
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
