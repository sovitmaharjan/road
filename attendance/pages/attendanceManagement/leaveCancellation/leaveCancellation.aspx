<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="leaveCancellation.aspx.cs" Inherits="attendance.pages.attendanceManagement.leaveCancellation.leaveCancellation" %>

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
                    <button type="button" id="load" class="btn btn-success w-xs waves-effect waves-light" data-toggle="modal" data-target="#loadContent">
                        <i class="mdi mdi-plus"></i>Load Content
                    </button>
                    <button type="button" id="delete" class="btn btn-danger w-xs waves-effect waves-light">
                        <i class="mdi mdi-cross"></i>Delete
                    </button>
                </div>
                <table id="datatable" class="table table-striped  table-colored table-info">
                    <thead>
                        <tr>
                            <th>
                                <div class='checkbox'>
                                    <input id='checkAll' type='checkbox' class='input-mini'>
                                    <label for='checkAll'></label>
                                </div>
                            </th>
                            <th>Employee</th>
                            <th>Leave Name</th>
                            <th>Taken Date</th>
                            <th>Leave</th>
                            <th>Remarks</th>
                            <th>Approved By</th>
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

    <div id="loadContent" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="custom-width-modalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog" style="width: 65%;">
            <div class="modal-content">
                <form id="form" class="form-horizontal" runat="server">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">Denotes Mandatory Fields (<span class="text-danger">*</span>)</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group row">
                            <label class="col-md-2 control-label">
                                Department <span class="text-danger">*</span>
                            </label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="department" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-2 control-label">
                                Year <span class="text-danger">*</span>
                            </label>
                            <div class="col-md-3">
                                <input id="year" class="form-control" type="number" value="2021" runat="server" />
                            </div>
                            <div class="col-md-1"></div>
                            <label class="col-md-2 control-label">
                                Month <span class="text-danger">*</span>
                            </label>
                            <div class="col-md-3">
                                <asp:DropDownList ID="month" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">Febuary</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button id="clear" type="button" class="btn btn-default waves-effect">Clear</button>
                        <asp:Button ID="loadButton" Text="Load" CssClass="btn btn-success" OnClick="loadClick" runat="server" />
                    </div>
                </form>
            </div>
        </div>
    </div>
    <!-- /.modal -->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
    <script>
        $(document).ready(function () {
            $('#checkAll').on('click', function () {
                if ($(this).is(':checked')) {
                    $('.checkboxes').prop('checked', true);
                } else {
                    $('.checkboxes').prop('checked', false);
                }
            })
            $('#delete').on('click', function () {
                var arr = "";
                $('.checkboxes').each(function () {
                    if ($(this).is(':checked')) {
                        if (arr == "") {
                            arr += $(this).val();
                        } else {
                            arr += ',' + $(this).val();
                        }
                    }
                })
                console.log(arr);
                $.ajax({
                    method: 'post',
                    url: '<%=this.baseUrl%>/pages/attendanceManagement/leaveCancellation/leaveCancellation.aspx/deleteLeaveCancellation',
                    data: '{ "sNo": "' + arr + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    success: function (result) {
                        location.reload();
                    }
                })
            })
        })
    </script>
</asp:Content>
