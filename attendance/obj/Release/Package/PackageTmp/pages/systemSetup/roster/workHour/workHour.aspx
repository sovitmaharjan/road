<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="workHour.aspx.cs" Inherits="attendance.pages.systemSetup.roster.workHour.workHour" %>
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
                            <li>
                                Roster 
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
                                            Group Name 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <input type="text" id="groupNameForm" class="form-control" value="" name="groupNameForm" required="required" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            In Time 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-5">
                                            <div class="input-group">
                                                <input id="inTimeForm" type="text" class="form-control timePickerForAll" runat="server" />
                                                <span class="input-group-addon"><i class="mdi mdi-clock"></i></span>
                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="input-group">
                                                <input id="inTime2Form" type="text" class="form-control timePickerForAll" runat="server" />
                                                <span class="input-group-addon"><i class="mdi mdi-clock"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Out Time 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-5">
                                            <div class="input-group">
                                                <input id="outTimeForm" type="text" class="form-control timePickerForAll" runat="server" />
                                                <span class="input-group-addon"><i class="mdi mdi-clock"></i></span>
                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="input-group">
                                                <input id="outTime2Form" type="text" class="form-control timePickerForAll" runat="server" />
                                                <span class="input-group-addon"><i class="mdi mdi-clock"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Hour 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-2">
                                            <input type="text" id="hourForm" class="form-control" value="" name="hourForm" required="required" runat="server" readonly="" />
                                        </div>
                                        <label class="col-md-2 control-label">
                                            Minute 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-2">
                                            <input type="text" id="minuteForm" class="form-control" value="" name="minuteForm" required="required" runat="server" readonly="" />
                                        </div>
                                        <label class="col-md-2 control-label">
                                            Lunch Time 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-2">
                                            <input type="text" id="lunchTimeForm" class="form-control" value="" name="lunchTimeForm" required="required" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Night Shift 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <div class="radio col-md-1">
                                                <input type="radio" name="nightShift" id="nightShiftYesForm" value="yes" runat="server" />
                                                <label for="nightShiftYesForm">
                                                    Yes 
                                                </label>
                                            </div>
                                            <div class="radio col-md-1">
                                                <input type="radio" name="nightShift" id="nightShiftNoForm" value="no" runat="server" checked="" />
                                                <label for="nightShiftNoForm">
                                                    No 
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Default for all weekend 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <div class="radio col-md-1">
                                                <input type="radio" name="defaultForAllWeekend" id="defaultForAllWeekendYesForm" value="yes" runat="server" />
                                                <label for="defaultForAllWeekendYesForm">
                                                    Yes 
                                                </label>
                                            </div>
                                            <div class="radio col-md-1">
                                                <input type="radio" name="defaultForAllWeekend" id="defaultForAllWeekendNoForm" value="no" runat="server" checked="" />
                                                <label for="defaultForAllWeekendNoForm">
                                                    No 
                                                </label>
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
                                                <input type="radio" name="status" id="statusYesForm" value="yes" runat="server" checked="" />
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
                                                <a class="btn btn-danger btn-bordered waves-effect w-md waves-light col-md-1" href="~/holidayList" runat="server">Cancel </a>
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
    <script type="text/javascript">
        $('#<%=inTimeForm.ClientID%>,#<%=outTimeForm.ClientID%>').change(function () {

            var inTime = $('#<%=inTimeForm.ClientID%>').val();
            var outTime = $('#<%=outTimeForm.ClientID%>').val();


            var inSplit = inTime.split(':');
            var inSeconds = (+inSplit[0]) * 60 * 60 + (+inSplit[1]) * 60;

            var outSplit = outTime.split(':');
            var outSeconds = (+outSplit[0]) * 60 * 60 + (+outSplit[1]) * 60;

            var difference = outSeconds - inSeconds;

            if (difference > 0) {
                var hours = Math.floor(difference / 3600);
                difference %= 3600;
                var minutes = difference / 60;
            } else {

                var changeDifference = difference + 86400;
                var hours = Math.floor(changeDifference / 3600);
                changeDifference %= 3600;
                var minutes = changeDifference / 60;
            }
            var result = hours + ":" + minutes;
            $('#<%=hourForm.ClientID%>').val(hours);
            $('#<%=minuteForm.ClientID%>').val(minutes);
        });
    </script>
</asp:Content>
