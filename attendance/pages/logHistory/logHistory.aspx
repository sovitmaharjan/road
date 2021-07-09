<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="logHistory.aspx.cs" Inherits="attendance.pages.logHistory.logHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
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
                                            Start Date
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-5">
                                            <div class="input-group">
                                                <input autocomplete="off" type="text" id="fromEnglishDateForm" name="fromEnglishDateForm" class="form-control datePickerForAll" placeholder="English Date" required="required" runat="server" />
                                                <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                            </div>
                                        </div>
                                        
                                        <div class="col-md-5">
                                            <div class="input-group">
                                                <input autocomplete="off" type="text" id="fromNepaliDateForm" name="fromNepaliDateForm" class="form-control nepaliDatePickerForAll" placeholder="Nepali Date" required="required" runat="server" />
                                                <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            End Date
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-5">
                                            <div class="input-group">
                                                <input autocomplete="off" type="text" id="toEnglishDateForm" name="toEnglishDateForm" class="form-control datePickerForAll" placeholder="English Date" required="required" runat="server" />
                                                <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                            </div>
                                        </div>
                                        
                                        <div class="col-md-5">
                                            <div class="input-group">
                                                <input autocomplete="off" type="text" id="toNepaliDateForm" name="toNepaliDateForm" class="form-control nepaliDatePickerForAll" placeholder="Nepali Date" required="required" runat="server" />
                                                <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-2 control-label">
                                            Employee 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-5">
                                            <asp:DropDownList ID="empForm" CssClass="form-control" runat="server" required="required"></asp:DropDownList>
                                        </div>
                                        <label class="col-md-2 control-label">
                                            Employee Id 
                                        </label>
                                        <div class="col-md-2">
                                            <input type="text" id="empIdForm" class="form-control onlyNumber" required="required" />
                                        </div>
                                        <%--<div class="col-md-2">
                                            <div class="checkbox">
                                                <input type="checkbox" id="allEmployeeForm" value="0" />
                                                <label for="allEmployeeForm">All Employee </label>
                                            </div>
                                        </div>--%>
                                    </div>
                                    <br /><br />
                                    <div class="form-group row">
                                        <div class="col-sm-9 col-sm-offset-2">
                                            <div class="button-list">
                                                <asp:Button ID="loadButton" text="Load" CssClass="btn btn-success btn-bordered w-md btn-bordered col-md-1" OnClick="loadClick" runat="server" />
                                                <a class="btn btn-danger btn-bordered waves-effect w-md waves-light col-md-1" href="~/logHistory" runat="server">Cancel </a>
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

            $('#<%=empForm.ClientID%>').on('change', function () {

                //$('#allEmployeeForm').prop('checked', false);
                var empId = $('#<%=empForm.ClientID%>').val();
                console.log(empId);
                $('#empIdForm').val(empId);
            });

            var timer;
            $('#empIdForm').keyup(function () {

                var typedId = $(this).val();
                var listId;

                timer = setTimeout(function () {

                    $('#<%=empForm.ClientID%> option').each(function () {

                        listId = $(this).val();
                        if (typedId == listId) {

                            $(this).attr("selected", "selected");
                        }
                    })
                }, 1000);
            })

            $('#<%=fromEnglishDateForm.ClientID%>').on('change', function () {

                console.log($(this).val());
                if ($(this)) {

                    $('#<%=fromNepaliDateForm.ClientID%>').val(AD2BS($(this).val()));
                }
            });
            $('#<%=toEnglishDateForm.ClientID%>').on('change', function () {

                if ($(this)) {

                    $('#<%=toNepaliDateForm.ClientID%>').val(AD2BS($(this).val()));
                }
            });
            $('#<%=fromNepaliDateForm.ClientID%>').nepaliDatePicker({
                npdMonth: true,
                npdYear: true,
                npdYearCount: 10,
                onChange: function () {

                    $('#<%=fromEnglishDateForm.ClientID%>').val(BS2AD($('#<%=fromNepaliDateForm.ClientID%>').val()));
                }
            });
            $('#<%=toNepaliDateForm.ClientID%>').nepaliDatePicker({
                npdMonth: true,
                npdYear: true,
                npdYearCount: 10,
                onChange: function () {

                    $('#<%=toEnglishDateForm.ClientID%>').val(BS2AD($('#<%=toNepaliDateForm.ClientID%>').val()));
                }
            });
        })
    </script>
</asp:Content>
