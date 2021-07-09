<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="Activation.aspx.cs" Inherits="attendance.pages.Admin.Activation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- Start content -->
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">
                            <asp:Literal ID="pageNamePlace1" runat="server"></asp:Literal>
                        </h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li>
                                <%=this.projectName%> 
                            </li>
                            <li>Activation</li>
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
                                        <label class="col-md-2 control-label">Hardware ID </label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtHardwareId" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">Serial Key </label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="txtserialKey" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-2 control-label">License Date </label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="LicenseDate" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-2 control-label">Activation period </label>
                                        <div class="col-md-10">
                                            <div class="radio col-md-3">
                                                <input type="radio" name="status" id="demo" runat="server"/>
                                                <label for="statusYesForm">
                                                    Demo
                                                </label>
                                            </div>
                                            <div class="radio col-md-3">
                                                <input type="radio" name="status" id="one" runat="server" />
                                                <label for="statusYesForm">
                                                    3 Month
                                                </label>
                                            </div>


                                            <div class="radio col-md-3">
                                                <input type="radio" name="status" id="two" runat="server" />
                                                <label for="statusNoForm">
                                                    6 Month 
                                                </label>
                                            </div>
                                            <div class="radio col-md-3">
                                                <input type="radio" name="status" id="four" runat="server" checked/>
                                                <label for="statusNoForm">
                                                    1 year
                                                </label>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <%--<label id="lblexp" class="col-md-2 control-label">Expiry Date </label>--%>
                                        <asp:Label ID="lblexp" CssClass="col-md-2 control-label" runat="server" Text="Label">Expiry Date</asp:Label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="expiryDate" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>

                                    &nbsp;

                                    <div class="form-group row">
                                        <div class="col-sm-9 col-sm-offset-2">
                                            <div class="button-list">
                                                <asp:Button CssClass="btn w-md btn-bordered btn-danger waves-light" ID="btnActivate" runat="server" Text="Activate" OnClick="Activate_Click" />
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
        </div>
        <!-- container -->
    </div>
    <!-- content -->

    <%--<section>
        <div class="container-alt">
            <div class="row">
                <div class="col-sm-12">

                    <div class="wrapper-page1">
                        <asp:Literal ID="message" runat="server"></asp:Literal>
                        <div class="m-t-40 account-pages">
                            <div class="text-center account-logo-box">
                                <h2 class="text-uppercase">
                                    <a href="index.html" class="text-success">
                                        <span><img src="<%=this.baseUrl%>/assets/images/sm.png" alt="" height="36"/></span>
                                    </a>
                                </h2>
                            </div>
                            <div class="account-content">
                                <form class="form-horizontal" runat="server">

                                    <div class="form-group">
                                        <label class="col-md-4 control-label">Serial Key </label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtserialKey" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>                                        
                                    </div>

                                    <div class="form-group">
                                        <label class="col-md-4 control-label">Activation period </label>
                                        <div class="col-md-8">
                                            <div class="radio col-md-4">
                                                <input type="radio" name="status" id="demo" runat="server" checked />
                                                <label for="statusYesForm">
                                                    Demo
                                                </label>
                                            </div>
                                            <div class="radio col-md-4">
                                                <input type="radio" name="status" id="one" runat="server"/>
                                                <label for="statusYesForm">
                                                    1 Year
                                                </label>
                                            </div>
                                        </div>
                                        <div class="col-md-4"></div>
                                        <div class="col-md-8">
                                            <div class="radio col-md-4">
                                                <input type="radio" name="status" id="two" runat="server" />
                                                <label for="statusNoForm">
                                                    2 Year 
                                                </label>
                                            </div>
                                            <div class="radio col-md-4">
                                                <input type="radio" name="status" id="unlimited" runat="server" />
                                                <label for="statusNoForm">
                                                    Unlimited
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    &nbsp;

                                    <div class="form-group row">
                                        <div class="col-sm-9 col-sm-offset-4">
                                            <div class="button-list">
                                                <asp:Button CssClass="btn w-md btn-bordered btn-danger waves-light" ID="btnActivate" runat="server" Text="Activate" OnClick="Activate_Click" />

                                            </div>
                                        </div>
                                    </div>

                                    

                                    

                                </form>

                                <div class="clearfix"></div>

                            </div>
                        </div>
                    </div>
                    <!-- end wrapper -->

                </div>
            </div>
        </div>
        </section>--%>
</asp:Content>
