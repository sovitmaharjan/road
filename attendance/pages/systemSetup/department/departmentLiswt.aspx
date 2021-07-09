<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="departmentLiswt.aspx.cs" Inherits="attendance.pages.systemSetup.department.departmentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <!-- Start content -->
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">Department List </h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li>
                                <%=this.projectName%> 
                            </li>
                            <li>
                                System Setup 
                            </li>
                            <li class="active">
                                Department List 
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
                                <a href="~/department" class="btn btn-success waves-effect w-md waves-light" runat="server">
                                    <i class="mdi mdi-plus"></i> Add New Department 
                                </a>
                            </div>
                            <table id="datatable" class="table table-striped  table-colored table-info">
                                <thead>
                                    <tr>
                                        <th>S. No. </th>
                                        <th>Department Name </th>
                                        <th>Status </th>
                                        <th> </th>
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
