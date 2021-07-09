<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="holiday.aspx.cs" Inherits="attendance.pages.systemSetup.holiday.setup.holiday" %>
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
                                Holiday 
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
                                            Holiday Date 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-4">
                                            <div class="input-group">
                                                <input autocomplete="off" type="text" id="holidayEnglishDateForm" name="holidayEnglishDateForm" class="form-control datePickerForAll" placeholder="yyyy-mm-dd" required="required" runat="server" />
                                                <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                            </div>
                                        </div>
                                        <label class="col-md-2 control-label">
                                            Nepali Date 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-4">
                                            <div class="input-group">
                                                <input autocomplete="off" type="text" id="holidayNepaliDateForm" name="holidayNepaliDateForm" class="form-control nepaliDatePickerForAll" placeholder="yyyy-mm-dd" required="required" runat="server" />
                                                <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Holiday Name 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-4">
                                            <input type="text" id="holidayNameForm" onkeypress="return /[0-9a-zA-Z]/i.test(event.key)" class="form-control" value="" name="holidayNameForm" required="required" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Holiday Type 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <div class="radio col-md-2">
                                                <input type="radio" name="holidayType" id="standardForm" value="yes" runat="server" checked="" />
                                                <label for="standardForm">
                                                    Standard 
                                                </label>
                                            </div>
                                            <div class="radio col-md-2">
                                                <input type="radio" name="holidayType"  id="specificForm" value="no" runat="server" />
                                                <label for="specificForm">
                                                    Specific 
                                                </label>
                                            </div>
                                            <div class="radio col-md-2">
                                                <input type="radio" name="holidayType"  id="unofficialForm" value="no" runat="server" />
                                                <label for="unofficialForm">
                                                    Unofficial 
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Female Only 
                                        </label>
                                        <div class="col-md-10">
                                            <div class="checkbox">
                                                <input type="checkbox" id="femaleOnlyForm" value="1" runat="server" />
                                                <label for="femaleOnlyForm"> </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Holiday Quantity 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-2">
                                            <input type="text" id="holidayQuantityForm" class="form-control onlyNumber" value="" name="holidayQuantityForm" required="required" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Status 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-10">
                                            <div class="radio col-md-2">
                                                <input type="radio" name="status" id="statusYesForm" value="yes" runat="server" checked="" />
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
    <script>
        $().ready(function () {

            if ($('#<%=holidayEnglishDateForm.ClientID%>').val()) {

                $('#<%=holidayNepaliDateForm.ClientID%>').val(AD2BS($('#<%=holidayEnglishDateForm.ClientID%>').val()));
            }
            $('#<%=holidayEnglishDateForm.ClientID%>').on('change', function () {
                if ($(this)) {

                    $('#<%=holidayNepaliDateForm.ClientID%>').val(AD2BS($(this).val()));
                }
            });
        })
    </script>
        
    <%--<script>
        $("#holidayNameForm").keypress(function (event) {
            var character = String.fromCharCode(event.keyCode);
            return isValid(character);
        });

        function isValid(str) {
            return !/[~`!@#$%\^&*()+=\-\[\]\\';,/{}|\\":<>\?]/g.test(str);
        }
    </script>--%>
</asp:Content>
