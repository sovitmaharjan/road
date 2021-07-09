<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="company.aspx.cs" Inherits="attendance.pages.systemSetup.company.company" %>
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
                                            Company Name
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <input type="text" id="companyNameForm" class="form-control" value="" name="companyNameForm" required="required" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Address 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-5">
                                            <input type="text" id="address1Form" class="form-control" value="" name="address1Form" required="required" runat="server" />
                                        </div>
                                        <div class="col-md-5">
                                            <input type="text" id="address2Form" class="form-control" value="" name="address2Form" required="required" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Telephone 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <input type="text" id="telephoneForm" class="form-control" value="" name="telephoneForm" required="required" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Fax 
                                        </label>
                                        <div class="col-md-10">
                                            <input type="text" id="faxForm" class="form-control" value="" name="telephoneForm"  runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Email 
                                        </label>
                                        <div class="col-md-10">
                                            <input type="text" id="emailForm" class="form-control" value="" name="telephoneForm" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Website 
                                        </label>
                                        <div class="col-md-10">
                                            <input type="text" id="websiteForm" class="form-control" value="" name="telephoneForm" runat="server" />
                                        </div>
                                    </div>
                                    <br /><br />
                                    <div class="form-group row">
                                        <div class="col-sm-9 col-sm-offset-2">
                                            <div class="button-list">
                                                <asp:Button ID="saveButton" text="Save" CssClass="btn btn-success btn-bordered w-md btn-bordered col-md-1" OnClick="saveClick" runat="server" />
                                                <a class="btn btn-danger btn-bordered waves-effect w-md waves-light col-md-1" href="~/company" runat="server">Cancel </a>
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
