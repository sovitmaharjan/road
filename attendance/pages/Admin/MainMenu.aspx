<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="attendance.pages.Admin.MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- Start content -->
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li>Super Admin
                            </li>

                            <li class="active">Main Menu 
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
                        <form class="form-horizontal" runat="server">
                            <div class="form-group">
                                <a class="btn btn-success waves-effect w-md waves-light clear" data-toggle="modal" data-target="#con-close-modal">
                                    <i class="mdi mdi-plus"></i>Add New 
                                </a>
                            </div>
                            <table id="datatable" class="table table-striped table-colored table-info">
                                <thead>
                                    <tr>
                                        <th>S.N </th>
                                        <th>Title </th>
                                        <th>Url </th>
                                        <th style="text-align: center">Icon Class </th>
                                        <th>Sub Menu </th>
                                        <th>Status </th>
                                        <th style="text-align: center">Actions </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="tableBody" runat="server"></asp:Literal>
                                </tbody>
                            </table>

                            <div id="con-close-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                            <h4 class="modal-title">Add New Menu List</h4>
                                        </div>

                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="panel panel-color panel-info">
                                                        <div class="panel-heading">
                                                            <h3 class="panel-title"><span class="text-danger">* </span>Denotes Mandatory Fields </h3>
                                                        </div>
                                                        <div class="panel-body">
                                                            <h4 class="m-t-0 header-title"></h4>
                                                            <p class="text-muted m-b-30 font-13"></p>
                                                            <div class="col-md-12">
                                                                <div class="form-group">
                                                                    <label class="col-md-3 control-label">Title <span class="text-danger">* </span></label>
                                                                    <div class="col-md-9">
                                                                        <input type="text" id="titleNameForm" class="form-control" value="" name="titleNameForm" required="required" runat="server" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label class="col-md-3 control-label">URL </label>
                                                                    <div class="col-md-9">
                                                                        <input type="text" id="urlNameForm" class="form-control" value="" name="urlNameForm" runat="server" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label class="col-md-3 control-label">Icon Name <span class="text-danger">* </span></label>
                                                                    <div class="col-md-9">
                                                                        <input type="text" id="iconNameForm" class="form-control" value="" name="iconNameForm" required="required" runat="server" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label class="col-md-3 control-label">Sort Order <span class="text-danger">* </span></label>
                                                                    <div class="col-md-9">
                                                                        <input type="text" id="sortOrderForm" class="form-control number" value="" name="sortOrderForm" required="required" runat="server" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label class="col-md-3 control-label">Sub Menu <span class="text-danger">* </span></label>
                                                                    <div class="col-md-9">
                                                                        <div class="radio col-md-6">
                                                                            <input type="radio" name="subMenuStatus" id="subMenuYesForm" value="1" runat="server" />
                                                                            <label for="statusYesForm">Yes </label>
                                                                        </div>
                                                                        <div class="radio col-md-6">
                                                                            <input type="radio" name="subMenuStatus" id="subMenuNoForm" value="0" runat="server" checked="" />
                                                                            <label for="statusNoForm">No </label>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label class="col-md-3 control-label">Status <span class="text-danger">* </span></label>
                                                                    <div class="col-md-9">
                                                                        <div class="radio col-md-6">
                                                                            <input type="radio" name="status" id="statusYesForm" value="1" runat="server" checked="" />
                                                                            <label for="statusYesForm">Active </label>
                                                                        </div>
                                                                        <div class="radio col-md-6">
                                                                            <input type="radio" name="status" id="stausNoForm" value="0" runat="server" />
                                                                            <label for="statusNoForm">Inactive </label>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="modal-footer">
                                            <asp:Button ID="saveButton" Text="Save" CssClass="btn btn-success btn-bordered w-md btn-bordered" OnClick="saveButton_Click" runat="server" />
                                            <button type="button" class="btn btn-danger btn-bordered w-md btn-bordered waves-effect" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="con-close" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                                <div class="modal-dialog modal-lg modal-dialog-centered" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                            <h4 class="modal-title">SubMenu List of <span style="color: blue" id="qwerty"></span></h4>
                                        </div>

                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="panel panel-color panel-info">
                                                        <div class="panel-body">
                                                            <h4 class="m-t-0 header-title"></h4>
                                                            <p class="text-muted m-b-30 font-13"></p>
                                                            <div class="col-md-12">
                                                                <div class="form-group">
                                                                    <a class="btn btn-success waves-effect w-md waves-light" data-toggle="modal" data-target="#con">
                                                                        <i class="mdi mdi-plus"></i>Add New 
                                                                    </a>
                                                                </div>
                                                                <table id="" class="table table-striped table-colored table-info">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>S.N </th>
                                                                            <th>Title </th>
                                                                            <th>Url </th>
                                                                            <th style="text-align: center">Sort Order </th>
                                                                            <th>Sub Menu </th>
                                                                            <th>Menu </th>
                                                                            <th>Status </th>
                                                                            <th style="text-align: center">Actions </th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody id="qwe">
                                                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="con" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                            <h4 class="modal-title">Add New Sub Menu List of <span id="page_name"></span></h4>
                                        </div>

                                        <div class="modal-body">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="panel panel-color panel-info">
                                                        <div class="panel-heading">
                                                            <h3 class="panel-title"><span class="text-danger">* </span>Denotes Mandatory Fields </h3>
                                                        </div>
                                                        <div class="panel-body">
                                                            <h4 class="m-t-0 header-title"></h4>
                                                            <p class="text-muted m-b-30 font-13"></p>
                                                            <div class="col-md-12">
                                                                <div class="form-group">
                                                                    <label class="col-md-3 control-label">Title <span class="text-danger">* </span></label>
                                                                    <div class="col-md-9">
                                                                        <input type="text" id="Text1" class="form-control" value="" name="titleNameForm" required="required" runat="server" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label class="col-md-3 control-label">URL </label>
                                                                    <div class="col-md-9">
                                                                        <input type="text" id="Text2" class="form-control" value="" name="urlNameForm" runat="server" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label class="col-md-3 control-label">Icon Name <span class="text-danger">* </span></label>
                                                                    <div class="col-md-9">
                                                                        <input type="text" id="Text3" class="form-control" value="" name="iconNameForm" required="required" runat="server" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label class="col-md-3 control-label">Sort Order <span class="text-danger">* </span></label>
                                                                    <div class="col-md-9">
                                                                        <input type="text" id="Text4" class="form-control number" value="" name="sortOrderForm" required="required" runat="server" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label class="col-md-3 control-label">Sub Menu <span class="text-danger">* </span></label>
                                                                    <div class="col-md-9">
                                                                        <div class="radio col-md-6">
                                                                            <input type="radio" name="subMenuStatus" id="Radio1" value="1" runat="server" />
                                                                            <label for="statusYesForm">Yes </label>
                                                                        </div>
                                                                        <div class="radio col-md-6">
                                                                            <input type="radio" name="subMenuStatus" id="Radio2" value="0" runat="server" checked="" />
                                                                            <label for="statusNoForm">No </label>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <label class="col-md-3 control-label">Status <span class="text-danger">* </span></label>
                                                                    <div class="col-md-9">
                                                                        <div class="radio col-md-6">
                                                                            <input type="radio" name="status" id="Radio3" value="1" runat="server" checked="" />
                                                                            <label for="statusYesForm">Active </label>
                                                                        </div>
                                                                        <div class="radio col-md-6">
                                                                            <input type="radio" name="status" id="Radio4" value="0" runat="server" />
                                                                            <label for="statusNoForm">Inactive </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="modal-footer">
                                            <asp:Button ID="Button1" Text="Save" CssClass="btn btn-success btn-bordered w-md btn-bordered" OnClick="saveButton_Click" runat="server" />
                                            <button type="button" class="btn btn-danger btn-bordered w-md btn-bordered waves-effect" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </form>
                    </div>
                </div>
            </div>
            <!-- end row -->
        </div>
        <!-- container -->
    </div>
    <!-- content -->




    <%--For Status Changing--%>
    <script>
        $('.qwe').click(function () {

            var id = $(this).attr('id');
            console.log(id);
            $.ajax({

                method: 'post',
                data: JSON.stringify({
                    "id": id
                }),
                url: 'pages/Admin/MainMenu.aspx/Changestatus',
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {

                    window.location = window.location.href;
                }
            });
        });


    </script>


    <%--For Menu--%>
    <script>
        $('.edit').click(function () {

            var id = $(this).attr('id');
            //console.log(id);
            $.ajax({

                method: 'post',
                data: JSON.stringify({
                    "id": id
                }),
                url: 'pages/Admin/MainMenu.aspx/getMenuById',
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    //console.log(data);
                    var data = data.d;
                    data.forEach(function (e) {

                        var splitData = e.split('./.');
                        //console.log(splitData);
                        $('#<%=titleNameForm.ClientID%>').val(splitData[1]);
                        $('#<%=urlNameForm.ClientID%>').val(splitData[2]);
                        $('#<%=iconNameForm.ClientID%>').val(splitData[3]);
                        $('#<%=sortOrderForm.ClientID%>').val(splitData[4]);
                        if (splitData[5] == 1) {
                            $('#<%=subMenuYesForm.ClientID%>').prop('checked', true);
                        } else {
                            $('#<%=subMenuNoForm.ClientID%>').prop('checked', true);
                        }
                        if (splitData[6] == 1) {
                            $('#<%=statusYesForm.ClientID%>').prop('checked', true);
                        } else {
                            $('#<%=stausNoForm.ClientID%>').prop('checked', true);
                        }
                    })
                }
            });
        });
    </script>

    <%--For Sub Menu--%>
    <script>
        
    </script>


    <%--For Reseting Modal--%>
    <script>
        $('.clear').click(function () {
            $('form input[type="text"]').val('');
            $('#<%= subMenuYesForm.ClientID %>').prop('checked', true);
            $('#<%= statusYesForm.ClientID %>').prop('checked', true);
        })
    </script>

    <script>
        $('.submenu').click(function () {

            var id = $(this).attr('id');
            var menuname = $(this).attr('menuname');
            $('#qwerty').html(menuname);
            //console.log(id);
            //console.log(menuname);
            $.ajax({
                method: 'post',
                data: JSON.stringify({
                    "id": id
                }),
                url: 'pages/Admin/MainMenu.aspx/getSubMenuById',
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    $('#qwe tr').remove()
                    var data = data.d;
                    //console.log(data);
                    var j = 1;
                    var row;
                    data.forEach(function (e, i) {
                        //console.log(e.id);
                        row += "<tr>";
                        row += "<td>" + j + "</td>";
                        row += "<td>" + e.title + "</td>";
                        row += "<td>" + e.url + "</td>";
                        row += "<td>" + e.sortOrderNumber + "</td>";
                        if (e.subMenu == "1") {
                            row += "<td> Yes </td>";

                        } else {
                            row += "<td> No </td>";

                        }
                        row += "<td>" + e.Menu + "</td>";
                        if (e.status == "1") {
                            row += "<td> Active </td>";

                        } else {
                            row += "<td> Inactive </td>";
                        }
                        row += "<td><div class='button-list'><a ID='" + e.id + "' page_name='" + e.title + "' data-toggle='modal' data-target='#con' class='editsubmenu btn btn-warning btn-rounded w-xs waves-effect waves-light'><i class='mdi mdi-pencil'></i> <span>Edit </span></a>   <a ID='" + e.id + "'  data-toggle='modal' data-target='#con-close' class='submenu btn btn-primary btn-rounded w-xs waves-effect waves-light'> <span>Sub Menu </span></a></div></td>";

                        row += "</tr>";
                        j++;
                    })
                    $('#qwe').append(row);
                    //For Another Menu
                    $('.editsubmenu').click(function () {

                        var id = $(this).attr('id');
                        var page_name = $(this).attr('page_name');
                        console.log(id);
                        console.log(page_name);

                        $.ajax({

                            method: 'post',
                            data: JSON.stringify({
                                "id": id
                            }),
                            url: 'pages/Admin/MainMenu.aspx/sidebarSubMenu2',
                            contentType: "application/json; charset=utf-8",
                            dataType: 'json',
                            success: function (data) {
                                console.log(data);
                                var data = data.d;
                                data.forEach(function (e) {

                                    //var splitData = e.split('./.');
                                    //console.log(splitData);
                                    $('#<%=Text1.ClientID%>').val(e.title);
                                    $('#<%=Text2.ClientID%>').val(e.url);
                                    $('#<%=Text3.ClientID%>').val(e.sortOrderNumber);
                                    if (e.subMenu == 1) {
                                        $('#<%=Radio1.ClientID%>').prop('checked', true);
                                    } else {
                                        $('#<%=Radio2.ClientID%>').prop('checked', true);
                                    }
                                    if (e.status == 1) {
                                        $('#<%=Radio3.ClientID%>').prop('checked', true);
                                    } else {
                                        $('#<%=Radio4.ClientID%>').prop('checked', true);
                                    }
                                })
                            }
                        });
                    });
                },
                error: function () {
                    console.log('error');
                }
            });
        });
    </script>


    <%--For Modal Backdrop--%>
    <script>
        $(document).ready(function () {

            $('#openBtn').click(function () {
                $('#myModal').modal({
                    show: true
                })
            });

            $(document).on('show.bs.modal', '.modal', function (event) {
                var zIndex = 1040 + (10 * $('.modal:visible').length);
                $(this).css('z-index', zIndex);
                setTimeout(function () {
                    $('.modal-backdrop').not('.modal-stack').css('z-index', zIndex - 1).addClass('modal-stack');
                }, 0);
            });


        });
    </script>
</asp:Content>
