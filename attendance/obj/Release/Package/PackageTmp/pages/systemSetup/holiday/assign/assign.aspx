<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="assign.aspx.cs" Inherits="attendance.pages.systemSetup.holiday.assign.assign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <!-- Start content -->
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <h4 class="page-title">Assign </h4>
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
                                Assign 
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
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="col-md-4 control-label">
                                            Holiday Name 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="holidayNameForm" CssClass="form-control" runat="server" required="required"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-4 control-label">
                                            Holiday Date 
                                        </label>
                                        <div class="col-md-4">
                                            <div class="input-group">
                                                <input autocomplete="off" type="text" id="holidayDateForm" name="holidayDateForm" class="form-control datePickerForAll" placeholder="yyyy-mm-dd" required="required" runat="server" />
                                                <span class="input-group-addon bg-custom b-0"><i class="mdi mdi-calendar text-white"></i></span>
                                            </div>
                                        </div>
                                        <label class="col-md-2 control-label">
                                            Quantity 
                                        </label>
                                        <div class="col-md-2">
                                            <input type="text" id="quantityForm" class="form-control" value="" name="quantityForm" required="required" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-4 control-label">
                                            Holiday Type 
                                        </label>
                                        <div class="col-md-4">
                                            <input type="text" id="holidayTypeForm" class="form-control" value="" name="holidayTypeForm" required="required" runat="server" />
                                        </div>
                                        <label class="col-md-2 control-label">
                                            Female Only 
                                        </label>
                                        <div class="col-md-2">
                                            <div class="checkbox">
                                                <input type="checkbox" id="femaleOnlyForm" value="1" runat="server" />
                                                <label for="femaleOnlyForm"> </label>
                                            </div>
                                        </div>
                                    </div>
                                    <br /><br />
                                    <table id="" class="table table-striped table-colored table-info">
                                        <thead>
                                            <tr>
                                                <th>
                                                    <div class="checkbox">
                                                        <input type="checkbox" id="allBranch" class="checkHead" />
                                                        <label for="allBranch"> </label>
                                                    </div>
                                                </th>
                                                <th>Branch Name </th>
                                                <th> </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Literal ID="tableBody" runat="server"></asp:Literal>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="col-md-6">
                                    <%--<div class="form-group row">
                                        <%--<div class="col-sm-9 col-sm-offset-4">--%>
                                            <div class="button-list">
                                                <asp:Button ID="saveButton" text="Save" CssClass="btn btn-success btn-bordered w-md btn-bordered col-md-1" runat="server" />
                                                <a class="btn btn-danger btn-bordered waves-effect w-md waves-light col-md-1" href="~/assign" runat="server">Cancel </a>
                                            </div>
                                        <%--</div>--%>
                                    <%--</div>--%>
                                    <br />
                                    <table id="" class="table table-striped table-colored table-info">
                                        <thead>
                                            <tr>
                                                <th>
                                                    <div class="checkbox">
                                                        <input type="checkbox" id="allEmployee" class="checkHead" />
                                                        <label for="allEmployee"> </label>
                                                    </div>
                                                </th>
                                                <th>Emp Id</th>
                                                <th>Emp Name </th>
                                            </tr>
                                        </thead>
                                        <tbody id="allEmployeeTbody">
                                        </tbody>
                                    </table>
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
        $(document).ready(function() {
            
            $('.detail').click(function () {

                var id = $(this).attr('id');
                $.ajax({

                    method: 'post',
                    data: JSON.stringify({
                        "id": id
                    }),
                    url: 'pages/systemSetup/holiday/assign/assign.aspx/getEmployeeByBranchId',
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    success: function (data) {

                        var data = data.d;
                        var tbody = '';
                        data.forEach(function (e) {

                            var splitData = e.split('./.');
                            tbody += '<tr><td><div class="checkbox"><input type="checkbox" id="' + splitData[0] + '" /><label for ="' + splitData[0] + '"></label></div></td><td>' + splitData[0] + '</td><td>' + splitData[1] + '</td></tr>';
                        })
                        $('#allEmployeeTbody').html(tbody);
                    }
                });
            });

            $('#<%=holidayNameForm.ClientID%>').click(function () {

                var id = $(this).val();
                $.ajax({

                    method: 'post',
                    data: JSON.stringify({
                        "id": id
                    }),
                    url: 'pages/systemSetup/holiday/assign/assign.aspx/getHolidayById',
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    success: function (data) {

                        var data = data.d;
                        //console.log(data);
                        data.forEach(function (e) {

                            var splitData = e.split('./.');
                            console.log(splitData);
                            $('#<%=holidayDateForm.ClientID%>').val(splitData[2]);
                            $('#<%=quantityForm.ClientID%>').val(splitData[3]);
                            if(splitData[4] == 1){

                                $('#<%=holidayTypeForm.ClientID%>').val('Standard');
                            } else if (splitData[4] == 2) {

                                $('#<%=holidayTypeForm.ClientID%>').val('Specific');
                            } else {

                                $('#<%=holidayTypeForm.ClientID%>').val('Unofficial');
                            }
                            if (splitData[5] == 1) {

                                $('#<%=femaleOnlyForm.ClientID%>').prop('checked', true);
                            } else {

                                $('#<%=femaleOnlyForm.ClientID%>').prop('checked', false);
                            }

                        })
                    }
                });
            });
        })
    </script>
</asp:Content>
