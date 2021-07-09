<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="leave.aspx.cs" Inherits="attendance.pages.systemSetup.leave.leave" %>
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
                                            Leave Name 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <input type="text" id="leaveNameForm" class="form-control" value="" name="leaveNameForm" required="required" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Leave Type 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <div class="radio col-md-2">
                                                <input type="radio" name="leaveType" id="expireYearlyForm" value="yes" runat="server" checked />
                                                <label for="statusYesForm">
                                                    Expire Yearly 
                                                </label>
                                            </div>
                                            <div class="radio col-md-2">
                                                <input type="radio" name="leaveType"  id="accumulativeForm" value="no" runat="server" />
                                                <label for="statusNoForm">
                                                    Accumulative 
                                                </label>
                                            </div>
                                            <div class="radio col-md-2">
                                                <input type="radio" name="leaveType"  id="servicePeriodForm" value="no" runat="server" />
                                                <label for="statusNoForm">
                                                    Service Period 
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Cashable 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <div class="radio col-md-2">
                                                <input type="radio" name="cashable" id="cashableYesForm" value="yes" runat="server" checked />
                                                <label for="cashableYesForm">
                                                    Yes 
                                                </label>
                                            </div>
                                            <div class="radio col-md-2">
                                                <input type="radio" name="cashable" id="cashableNoForm" value="no" runat="server" />
                                                <label for="cashableNoForm">
                                                    No 
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Days (Anually) 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <input type="text" id="daysAnuallyForm" class="form-control onlyNumber" value="" name="daysAnuallyForm" required="required" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Max Days At a Time 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <input type="text" id="maxDaysAtATimeForm" class="form-control onlyNumber" value="" name="maxDaysAtATimeForm" required="required" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Max Accumulation Days 
                                        </label>
                                        <div class="col-md-10">
                                            <input type="text" id="maxAccumulationDaysForm" class="form-control onlyNumber" value="" name="maxAccumulationDaysForm" runat="server" disabled="disabled" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Entire Service Period 
                                        </label>
                                        <div class="col-md-10">
                                            <input type="text" id="entireServicePeriodForm" class="form-control onlyNumber" value="" name="entireServicePeriodForm" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Other 
                                        </label>
                                        <div class="col-md-10">
                                            <div class="checkbox col-md-2">
                                                <input type="checkbox" id="monthlyEarningForm" value="1" runat="server" />
                                                <label for="monthlyEarningForm">Monthly Earning </label>
                                            </div>
                                            <div class="checkbox col-md-3">
                                                <input type="checkbox" id="mustExhaustAllLeavesForm" value="1" runat="server" />
                                                <label for="mustExhaustAllLeavesForm">Must Exhaust All Leaves </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Status 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <div class="radio col-md-2">
                                                <input type="radio" name="status" id="statusYesForm" value="yes" runat="server" checked />
                                                <label for="statusYesForm">
                                                    Yes 
                                                </label>
                                            </div>
                                            <div class="radio col-md-2">
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
                                                <a class="btn btn-danger btn-bordered waves-effect w-md waves-light col-md-1" href="~/leaveList" runat="server">Cancel </a>
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
    <script>
        $(document).ready(function () {

            $('#<%=accumulativeForm.ClientID%>').on('click', function () {

                if ($('#<%=accumulativeForm.ClientID%>').is(':checked')) {

                    $('#<%=maxAccumulationDaysForm.ClientID%>').removeAttr('disabled');
                }
            });
            $('#<%=expireYearlyForm.ClientID%>').on('click', function () {

                if ($('#<%=expireYearlyForm.ClientID%>').is(':checked')) {

                    $('#<%=maxAccumulationDaysForm.ClientID%>').attr('disabled', 'disabled');
                    $('#<%=maxAccumulationDaysForm.ClientID%>').val('');
                }
            });
            $('#<%=servicePeriodForm.ClientID%>').on('click', function () {

                if ($('#<%=servicePeriodForm.ClientID%>').is(':checked')) {

                    $('#<%=maxAccumulationDaysForm.ClientID%>').attr('disabled', 'disabled');
                    $('#<%=maxAccumulationDaysForm.ClientID%>').val('');
                }
            });
        })
    </script>
</asp:Content>
