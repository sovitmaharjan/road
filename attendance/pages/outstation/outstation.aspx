<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="outstation.aspx.cs" Inherits="attendance.pages.outstation.outstation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">
                    <asp:Literal ID="pageNamePlace1" runat="server"></asp:Literal></h4>
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
            <div class="card-box table-responsive">
                <div class="form-group">
                    <button type="button" id="add" class="btn btn-success w-xs waves-effect waves-light" data-toggle="modal" data-target="#addContent">
                        <i class="mdi mdi-plus"></i> Add Content
                    </button>
                </div>
                <table id="datatables" class="table table-striped  table-colored table-info">
                    <thead>
                        <tr>
                            <th> Employee ID </th>
							<th> Employee Name </th>
							<th> Department </th>
							<th> Designation</th>
							<th> Station </th>
							<th> Date From </th>
							<th> Date To </th>
							<th> No of Days </th>
							<th>  </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Literal ID="tableBody" runat="server"></asp:Literal>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <!-- end row -->

    <div id="addContent" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="custom-width-modalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog" style="width:65%;">
            <div class="modal-content">
                <form id="form" class="form-horizontal" runat="server">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">Denotes Mandatory Fields (<span class="text-danger">*</span>)</h4>
                    </div>
                    <div class="modal-body">
                        <input type="hidden" id="id" runat="server" />
                        <div class="form-group row">
                            <label class="col-md-2 control-label">
                                Employee 
                                <span class="text-danger">* </span>
                            </label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="employee" CssClass="form-control employee" runat="server" required="required"></asp:DropDownList>
                            </div>
                            <label class="col-md-2 control-label">
                                Employee Id
                            </label>
                            <div class="col-md-2">
                                <input type="text" id="empId" class="form-control onlyNumber" required="required" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-2 control-label">
                                Date
                                <span class="text-danger">* </span>
                            </label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <input autocomplete="off" type="text" id="date" name="date" class="form-control englishDate3" placeholder="English Date" required="required" runat="server" />
                                    <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                </div>
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <input autocomplete="off" type="text" id="nepaliDate" name="nepaliDate" class="form-control nepaliDate3" placeholder="Nepali Date" required="required" runat="server" />
                                    <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-2 control-label">
                                Start Date
                                <span class="text-danger">* </span>
                            </label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <input autocomplete="off" type="text" id="startDate" name="startDate" class="form-control englishDate1" placeholder="English Date" required="required" runat="server" />
                                    <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                </div>
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <input autocomplete="off" type="text" id="startNepaliDate" name="startNepaliDate" class="form-control nepaliDate1" placeholder="Nepali Date" required="required" runat="server" />
                                    <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-2 control-label">
                                End Date
                                <span class="text-danger">* </span>
                            </label>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <input autocomplete="off" type="text" id="endDate" name="endDate" class="form-control englishDate2" placeholder="English Date" required="required" runat="server" />
                                    <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                </div>
                            </div>
                            <div class="col-md-1"></div>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <input autocomplete="off" type="text" id="endNepaliDate" name="endNepaliDate" class="form-control nepaliDate2" placeholder="Nepali Date" required="required" runat="server" />
                                    <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-2 control-label">
                                Days 
                                <span class="text-danger">* </span>
                            </label>
                            <div class="col-md-2">
                                <input type="text" id="days" class="form-control onlyNumber" required="required" runat="server" readonly="readonly"/>
                            </div>
                            <div class="col-md-1"></div>
                            <label class="col-md-2 control-label">
                                Location
                                <span class="text-danger">* </span>
                            </label>
                            <div class="col-md-4">
                                <input type="text" id="location" class="form-control" required="required" runat="server"/>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-2 control-label">Text area</label>
                            <div class="col-md-9">
                                <textarea id="description" class="form-control" rows="5" required="required" runat="server"></textarea>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-2 control-label">
                                Status 
                                <span class="text-danger">* </span>
                            </label>
                            <div class="col-md-9">
                                <div class="radio">
                                    <input type="radio" name="status" id="statusYes" value="yes" runat="server" checked />
                                    <label for="statusYes">
                                        Yes 
                                    </label>
                                </div>
                                <div class="radio">
                                    <input type="radio" name="status" id="statusNo" value="no" runat="server" />
                                    <label for="statusNo">
                                        No 
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button id="clear" type="button" class="btn btn-default waves-effect">Clear</button>
                        <asp:Button ID="saveButton" text="Save" CssClass="btn btn-success" OnClick="saveClick" runat="server" />
                    </div>
                </form>
            </div>
        </div>
    </div><!-- /.modal -->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
    <script>
        $(document).ready(function () {
            dataTableFunction(function () {
                $('.edit').on('click', function () {
                    var id = $(this).attr('id');
                    $.ajax({
                        method: 'post',
                        url: '<%=this.baseUrl%>/pages/outstation/outstation.aspx/getData',
                        data: '{ "id": ' + id + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: 'json',
                        success: function (result) {
                            result = result.d[0];
                            $('#<%=id.ClientID%>').val(result['VNO']);
                            $('.employee option[value="' + result['EMP_ID '] + '"]').prop('selected', true);
                            $('#empId').val(result['EMP_ID']);
                            if (result['status'] == 1) {
                                $('#<%=statusYes.ClientID%>').prop('checked', true);
                                $('#<%=statusNo.ClientID%>').prop('checked', false);
                            } else {
                                $('#<%=statusYes.ClientID%>').prop('checked', false);
                                $('#<%=statusNo.ClientID%>').prop('checked', true);
                            }
                            $('#<%=date.ClientID%>').val(formatDate(Date(result['TDATE'])));
                            $('#<%=nepaliDate.ClientID%>').val(AD2BS(formatDate(Date(result['}']))));
                            $('#<%=startDate.ClientID%>').val(formatDate(Date(result['SDATE'])));
                            $('#<%=startNepaliDate.ClientID%>').val(AD2BS(formatDate(Date(result['SDATE']))));
                            $('#<%=endDate.ClientID%>').val(formatDate(Date(result['EDATE'])));
                            $('#<%=endNepaliDate.ClientID%>').val(AD2BS(formatDate(Date(result['EDATE']))));
                            $('#<%=days.ClientID%>').val(result['DAYS']);
                            $('#<%=location.ClientID%>').val(result['STATION']);
                            $('#<%=description.ClientID%>').val(result['PURPOSE']);
                        }
                    })
                })
            });

            $(document).on('change', '#<%=employee.ClientID%>', function () {
                // Does some stuff and logs the event to the console
                var empId = $('#<%=employee.ClientID%>').val();
                $('#empId').val(empId);
            });
            <%--$('#<%=employee.ClientID%>').on('change', function () {
                var empId = $('#<%=employee.ClientID%>').val();
                $('#empId').val(empId);
            });--%>

            $(document).on('keyup', '#empId', function () {
                console.log($(this).val());
                clearTimeout(timer);
                var typedId = $(this).val();
                $('#<%=employee.ClientID%>  option[value="' + typedId + '"]').prop('selected', true);
            })
            $(document).on('change', '#<%=endDate.ClientID%>, #<%=startDate.ClientID%>', function () {
                if ($('#<%=startDate.ClientID%>').val() && $('#<%=endDate.ClientID%>').val()) {
                    var diff = $('#<%=startDate.ClientID%>').datepicker("getDate") - $('#<%=endDate.ClientID%>').datepicker("getDate");
                    $('#<%=days.ClientID%>').val(diff / (1000 * 60 * 60 * 24) * -1);
                }
            });

            $(document).on('click', '#add',  function () {
                $('#<%=id.ClientID%>').val('');
                $('#<%=employee.ClientID%>').val('');
                $('#empId').val('');
                $('#<%=date.ClientID%>').val('');
                $('#<%=nepaliDate.ClientID%>').val('');
                $('#<%=startDate.ClientID%>').val('');
                $('#<%=startNepaliDate.ClientID%>').val('');
                $('#<%=endDate.ClientID%>').val('');
                $('#<%=endNepaliDate.ClientID%>').val('');
                $('#<%=days.ClientID%>').val('');
                $('#<%=location.ClientID%>').val('');
                $('#<%=description.ClientID%>').val('');
                $('#<%=statusYes.ClientID%>').prop('checked', true);
                $('#<%=statusNo.ClientID%>').prop('checked', false);
            })

            $(document).on('click', '#clear',  function () {
                $('#<%=employee.ClientID%>').val('');
                $('#empId').val('');
                $('#<%=date.ClientID%>').val('');
                $('#<%=nepaliDate.ClientID%>').val('');
                $('#<%=startDate.ClientID%>').val('');
                $('#<%=startNepaliDate.ClientID%>').val('');
                $('#<%=endDate.ClientID%>').val('');
                $('#<%=endNepaliDate.ClientID%>').val('');
                $('#<%=days.ClientID%>').val('');
                $('#<%=location.ClientID%>').val('');
                $('#<%=description.ClientID%>').val('');
                $('#<%=statusYes.ClientID%>').prop('checked', true);
                $('#<%=statusNo.ClientID%>').prop('checked', false);
            })
        })
    </script>
</asp:Content>