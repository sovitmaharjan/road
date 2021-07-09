<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="attendance.pages.Admin.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title"><asp:Literal ID="pageNamePlace1" runat="server"></asp:Literal> </h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li>
                                <%=this.AdminName%> 
                            </li>
                            <li>
                                Super Admin
                            </li>
                            <li class="active">
                                About 
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
                                            Name
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-5">
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
                                            <input type="text" id="address2Form" class="form-control" value="" name="address2Form" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Telephone 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-3">
                                            <input type="text" id="telephone1Form" class="form-control" value="" name="telephoneForm" runat="server" />
                                        </div>
                                        <div class="col-md-3">
                                            <input type="text" id="telephone2Form" class="form-control" value="" name="telephone2Form" runat="server" />
                                        </div>
                                        <div class="col-md-4">
                                            <input type="text" id="telephone3Form" class="form-control" value="" name="telephone3Form" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Fax 
                                        </label>
                                        <div class="col-md-5">
                                            <input type="text" id="faxForm" class="form-control" value="" name="telephoneForm"  runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Email 
                                        </label>
                                        <div class="col-md-5">
                                            <input type="text" id="email1Form" class="form-control" value="" name="email1Form" runat="server" />
                                        </div>
                                        <div class="col-md-5">
                                            <input type="text" id="email2Form" class="form-control" value="" name="email2Form" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Website 
                                        </label>
                                        <div class="col-md-5">
                                            <input type="text" id="websiteForm" class="form-control" value="" name="websiteForm" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Full Name 
                                        </label>
                                        <div class="col-md-5">
                                            <input type="text" id="fullNameForm" class="form-control" value="" name="fullNameForm" runat="server" />
                                        </div>
                                    </div>
                                    <br /><br />
                                    <div class="form-group row">
                                        <div class="col-sm-9 col-sm-offset-2">
                                            <div class="button-list">
                                                <asp:Button ID="saveButton" text="Save" CssClass="btn btn-success btn-bordered w-md btn-bordered col-md-1" OnClick="saveClick" runat="server" />
                                                <a class="btn btn-danger btn-bordered waves-effect w-md waves-light col-md-1" href="~/About" runat="server">Cancel </a>
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
