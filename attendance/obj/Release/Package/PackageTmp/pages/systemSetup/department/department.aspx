<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="department.aspx.cs" Inherits="attendance.pages.systemSetup.department.department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <!-- Start content -->
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title"><asp:Literal ID="pageNamePlace1" runat="server"></asp:Literal> </h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li>
                                <%=this.projectName%> 
                            </li>
                            <li>
                                System Setup 
                            </li>
                            <li class="active">
                                <asp:Literal ID="pageNamePlace2" runat="server"></asp:Literal> 
                            </li>
                        </ol>
                        <div class="clearfix"></div>    
                    </div>
                </div>
            </div>
            <!-- end row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-color panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title"><span class="text-danger">* </span>Denotes Mandatory Fields </h3>
                        </div>
                        <div class="panel-body">
                            <h4 class="m-t-0 header-title"></h4>
                            <p class="text-muted m-b-30 font-13">
                            </p>
                            <form class="form-horizontal" runat="server">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Department/Section Name 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <input type="text" id="departmentSectionNameForm" class="form-control" value="" name="departmentSectionNameForm" required="required" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Group Under 
                                        </label>
                                        <div class="col-md-10">
                                            <div class="checkbox">
                                                <input type="checkbox" id="groupUnderForm" value="1" runat="server" />
                                                <label for="groupUnderForm"> </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Create Default Section 
                                        </label>
                                        <div class="col-md-10">
                                            <div class="checkbox">
                                                <input type="checkbox" id="createDefaultSectionForm" value="1" runat="server" />
                                                <label for="createDefaultSectionForm"> </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Status 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <div class="radio col-md-1">
                                                <input type="radio" name="status" id="statusYesForm" value="yes" runat="server" checked />
                                                <label for="statusYesForm">
                                                    Yes 
                                                </label>
                                            </div>
                                            <div class="radio col-md-1">
                                                <input type="radio" name="status" id="statusNoForm" value="no" runat="server" />
                                                <label for="statusNoForm">
                                                    No 
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <br /><br />
                                    <div class="form-group row">
                                        <div class="col-sm-9 col-sm-offset-2">
                                            <div class="button-list">
                                                <asp:Button ID="saveButton" text="Save" CssClass="btn btn-success btn-bordered w-md btn-bordered col-md-1" OnClick="saveClick" runat="server" />
                                                <a class="btn btn-danger btn-bordered waves-effect w-md waves-light col-md-1" href="~/departmentList" runat="server">Cancel </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end row -->
        </div> <!-- container -->
    </div> <!-- content -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
