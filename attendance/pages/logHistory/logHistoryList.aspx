<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="logHistoryList.aspx.cs" Inherits="attendance.pages.logHistory.logHistoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">Branch List </h4>
                        <ol class="breadcrumb p-0 m-0">
                            <li>
                                <%=this.projectName%> 
                            </li>
                            <li>
                                System Setup 
                            </li>
                            <li class="active">
                                Log History List
                            </li>
                        </ol>
                        <div class="clearfix"> </div>    
                    </div>
                </div>
            </div>
            <!-- end row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="card-box table-responsive">
                        <form runat="server">
                            <div class="form-group">
                                <a href="~/logHistory" class="btn btn-success waves-effect w-md waves-light" runat="server">
                                    <i class="mdi mdi mdi-autorenew"></i> New 
                                </a>
                            </div>
                            <table id="datatable" class="table table-striped  table-colored table-info">
                                <thead>
                                    <tr>
                                        <th>S.N </th>
                                        <th>Employee Id </th>
                                        <th>Verify Mode </th>
                                        <th>Mode </th>
                                        <th>Log Date </th>
                                        <th>Log Time </th>
                                        <th>Actions</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="tableBody" runat="server"></asp:Literal>
                                </tbody>
                            </table>
                            <div id="custom-width-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="custom-width-modalLabel" aria-hidden="true" style="display: none;">
                                <div class="modal-dialog" style="width:25%;">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                            <h4 class="modal-title">Update </h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="field-3" class="control-label">
                                                            Shift 
                                                        </label>
                                                        <select class="form-control">
                                                            <option value="1">Shift 1 </option>
                                                            <option value="2">Shift 2 </option>
                                                        </select>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="field-1" class="control-label">
                                                            Date 
                                                        </label>
                                                        <div class="input-group">
                                                            <input autocomplete="off" type="text" id="englishDateForm" name="englishDateForm" class="form-control datePickerForAll" placeholder="English Date" required="required" />
                                                            <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                                            <input autocomplete="off" type="text" id="nepaliDateForm" name="nepaliDateForm" class="form-control nepaliDatePickerForAll" placeholder="Nepali Date" required="required" />
                                                            <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <input type="hidden" id="data" />
                                        </div>
                                        <div class="modal-footer">
                                            <a class="btn btn-default waves-effect" data-dismiss="modal">Close </a>
                                            <a id="modalUpdate" class="btn btn-info waves-effect waves-light">Update </a>
                                        </div>
                                    </div>
                                </div><!-- /.modal-dialog -->
                            </div><!-- /.modal -->
                        </form>
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

            $('#englishDateForm').on('change', function () {

                console.log($(this).val());
                if ($(this)) {

                    $('#nepaliDateForm').val(AD2BS($(this).val()));
                }
            });
            $('#nepaliDateForm').nepaliDatePicker({
                npdMonth: true,
                npdYear: true,
                npdYearCount: 10,
                onChange: function () {

                    $('#englishDateForm').val(BS2AD($('#nepaliDateForm').val()));
                }
            });

            $('.update').on('click', function () {

                var indexId = $(this).data("index");
                var empId = $(this).data("empid");
                var logDate = $(this).data("logdate");
                var data = indexId + '|' + empId + '|' + logDate;
                console.log(data);
                $('#englishDateForm').val(logDate);
                $('#nepaliDateForm').val(AD2BS(logDate));
                $('#data').val(data);
            })

            $('#modalUpdate').on('click', function () {

                var tempdata = $('#data').val();
                var shift = $('#shift').val();
                var date = $('#englishDateForm').val();
                var data = tempdata + '|' + date;
                console.log(data);
                $.ajax({

                    method: 'post',
                    data: JSON.stringify({

                        "data": data
                    }),
                    url: 'pages/logHistory/logHistoryList.aspx/modalUpdate',
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    success: function (data) {

                        swal("Done. !!!", "Updated Successfully!", "success")

                        location.reload();
                    },
                    error: function (error) {
                        alert('error');
                    }
                })
            })
        })
    </script>
</asp:Content>