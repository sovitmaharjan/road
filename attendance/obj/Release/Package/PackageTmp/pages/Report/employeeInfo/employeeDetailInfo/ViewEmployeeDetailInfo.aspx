<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="ViewEmployeeDetailInfo.aspx.cs" Inherits="attendance.pages.Report.employeeInfo.employeeDetailInfo.ViewEmployeeDetailInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Reports</li>
                            <li class="active">View Employee Details Information Report
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->
            <form runat="server" role="form" class="form-horizontal">
                <div class="col-md-12 form-group">
                    <div class="col-md-6 button-list">
                        <asp:Button ID="btnBack" CssClass="btn btn-success col-md-2" runat="server" Text="New" OnClick="btnNew_Click" />
                        <%--  <asp:Button ID="BtnExport" CssClass="btn btn-success col-md-2" runat="server" Text="Excel" OnClick="BtnExport_Click"/>--%>
                    </div>
                </div>

                <%-- <div class="col-md-12 form-group">
                    <div class="col-md-6">
                        <asp:Label ID="Label58" CssClass="col-md-3" runat="server" Text=""></asp:Label>
                        <div class="col-md-8">
                            <asp:Image ID="PersImage" runat="server" Style="height: 150px; width: 150px; border-style: ridge; border-width: 5px;" />
                        </div>

                    </div>
                </div>--%>



                <div class="col-md-12 well">
                    <div class="col-md-6">
                        <h3 style="color: darkblue;">General Information</h3>
                        <div class="form-group">
                            <asp:Label ID="Label1" CssClass="col-md-4" runat="server" Text="Employee Id :-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblid" runat="server"></asp:Label>
                            </div>

                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label2" CssClass="col-md-4" runat="server" Text="Full Name :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblname" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label3" CssClass="col-md-4" runat="server" Text="Gender :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblgender" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label5" CssClass="col-md-4" runat="server" Text="Date Of Birth :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lbldob" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label4" CssClass="col-md-4" runat="server" Text="Join Date :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lbldate" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label8" CssClass="col-md-4" runat="server" Text="Email :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblemail" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <h3 style="color: darkblue;">Official Information</h3>
                        <div class="form-group">
                            <asp:Label ID="Label20" CssClass="col-md-4" runat="server" Text="Branch :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblbranch" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label18" CssClass="col-md-4" runat="server" Text="Department :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lbldept" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label9" CssClass="col-md-4" runat="server" Text="Login Id :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblusrid" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label10" CssClass="col-md-4" runat="server" Text="Password :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblpassword" runat="server">******</asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label12" CssClass="col-md-4" runat="server" Text="Designation :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblDeg" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label14" CssClass="col-md-4" runat="server" Text="Type :-"></asp:Label>
                            <div class="col-md-3">
                                <asp:Label ID="lblType" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label16" CssClass="col-md-4" runat="server" Text="Status :-"></asp:Label>
                            <div class="col-md-3">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label22" CssClass="col-md-4" runat="server" Text="User Type :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblUsertype" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label24" CssClass="col-md-4" runat="server" Text="Grade :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblgrade" runat="server"></asp:Label>
                            </div>
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
