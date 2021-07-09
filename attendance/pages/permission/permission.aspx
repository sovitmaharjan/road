<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="permission.aspx.cs" Inherits="attendance.pages.permission.permission" %>
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
                                Permission 
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
                                            Employee 
                                            <span class="text-danger">* </span>
                                        </label>
                                        <div class="col-md-4">
                                            <asp:DropDownList ID="empForm" CssClass="form-control" runat="server" required="required"></asp:DropDownList>
                                        </div>
                                        <label class="col-md-2 control-label">
                                            Employee Id 
                                        </label>
                                        <div class="col-md-2">
                                            <input type="text" id="empIdForm" class="form-control onlyNumber" required="required" />
                                        </div>
                                        <div class="col-md-2">
                                            <div class="checkbox">
                                                <input type="checkbox" id="allEmployeeForm" value="0" />
                                                <label for="allEmployeeForm">All Employee </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" id="menuListDiv">
                                        <asp:Literal ID="menuList" runat="server"></asp:Literal>
                                    </div>
                                    <br /><br />
                                    <div class="form-group row">
                                        <div class="col-sm-9 col-sm-offset-2">
                                            <div class="button-list">
                                                <%--<asp:Button ID="saveButton" text="Save" CssClass="btn btn-success btn-bordered w-md btn-bordered col-md-1" OnClick="saveClick" runat="server" />--%>
                                                <a id="save" class="btn btn-success btn-bordered waves-effect w-md waves-light col-md-1">Save </a>
                                                <a class="btn btn-danger btn-bordered waves-effect w-md waves-light col-md-1" href="~/permission" runat="server">Cancel </a>
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

            $('input[type=checkbox]').click(function () {
                // For child cb
                let $this = $(this);
                $this.parents('li:first').find('ul input[type=checkbox]').prop('checked', this.checked);

                // For parent cb
                let $siblings = $this.parents('ul:first').children('li');
                let $checked = $siblings.find('input[type=checkbox]:checked');
                let $checkbox = $siblings.find('input[type=checkbox]');
                // console.log($siblings);
                // console.log($checked.length);
                // console.log($this.parents('ul').parents('li').parents('ul').siblings().html());

                $this.parents('ul:first').siblings('div.checkbox').find('input[type=checkbox]').prop('checked', $checked.length >= 1);
                $this.parents('ul').parents('li').parents('ul').siblings('div.checkbox').find('input[type=checkbox]').prop('checked', $checked.length >= 1);
            });

            $('#<%=empForm.ClientID%>').on('change', function () {

                $('#menuListDiv').empty();
                $('#allEmployeeForm').prop('checked', false);
                var empId = $('#<%=empForm.ClientID%>').val();
                console.log(empId);
                $('#empIdForm').val(empId);
                if (empId) {

                    //do nothing
                } else {

                    empId = 0;
                }
                $.ajax({

                    method: 'post',
                    data: JSON.stringify({
                        "empId": empId
                    }),
                    url: 'pages/permission/permission.aspx/getPermissionById',
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    success: function (data) {

                        var data = data.d;
                        //console.log(data);
                        $('#menuListDiv').append(data);

                        $('input[type=checkbox]').click(function () {
                            // For child cb
                            let $this = $(this);
                            $this.parents('li:first').find('ul input[type=checkbox]').prop('checked', this.checked);

                            // For parent cb
                            let $siblings = $this.parents('ul:first').children('li');
                            let $checked = $siblings.find('input[type=checkbox]:checked');
                            let $checkbox = $siblings.find('input[type=checkbox]');
                            // console.log($siblings);
                            // console.log($checked.length);
                            // console.log($this.parents('ul').parents('li').parents('ul').siblings().html());

                            $this.parents('ul:first').siblings('div.checkbox').find('input[type=checkbox]').prop('checked', $checked.length >= 1);
                            $this.parents('ul').parents('li').parents('ul').siblings('div.checkbox').find('input[type=checkbox]').prop('checked', $checked.length >= 1);
                        });
                    }
                });
            });

            $('#allEmployeeForm').click(function () {

                if ($('#allEmployeeForm').is(":checked")) {

                    $('#empIdForm').val('0');
                }
            })

            var timer;
            $('#empIdForm').keyup(function () {

                clearTimeout(timer);
                var typedId = $(this).val();
                var listId;
                $('#allEmployeeForm').prop('checked', false);
                var empId = $('#empIdForm').val();
                //console.log(empId);
                if (empId) {

                    //do nothing
                } else {

                    empId = 0;
                }
                timer = setTimeout(function () {

                    $('#menuListDiv').empty();
                    $('#<%=empForm.ClientID%> option').each(function () {

                        listId = $(this).val();
                        if (typedId == listId) {

                            $(this).attr("selected", "selected");
                        }
                    })

                    $.ajax({

                        method: 'post',
                        data: JSON.stringify({
                            "empId": empId
                        }),
                        url: 'pages/permission/permission.aspx/getPermissionById',
                        contentType: "application/json; charset=utf-8",
                        dataType: 'json',
                        success: function (data) {

                            var data = data.d;
                            //console.log(data);
                            $('#menuListDiv').append(data);

                            $('input[type=checkbox]').click(function () {
                                // For child cb
                                let $this = $(this);
                                $this.parents('li:first').find('ul input[type=checkbox]').prop('checked', this.checked);

                                // For parent cb
                                let $siblings = $this.parents('ul:first').children('li');
                                let $checked = $siblings.find('input[type=checkbox]:checked');
                                let $checkbox = $siblings.find('input[type=checkbox]');
                                // console.log($siblings);
                                // console.log($checked.length);
                                // console.log($this.parents('ul').parents('li').parents('ul').siblings().html());

                                $this.parents('ul:first').siblings('div.checkbox').find('input[type=checkbox]').prop('checked', $checked.length >= 1);
                                $this.parents('ul').parents('li').parents('ul').siblings('div.checkbox').find('input[type=checkbox]').prop('checked', $checked.length >= 1);
                            });
                        }
                    });
                }, 1000);
            })


            $('#save').on('click', function () {

                var empId;
                if ($('#allEmployeeForm').is(":checked")) {

                    empId = 0;
                } else {

                    empId = $('#<%=empForm.ClientID%>').val();
            }
                var menuid, onOff;
                var permission = '';
                $(".checkbox").children('input[type=checkbox]').each(function () {
                    var $this = $(this);
                    menuId = $this.attr('id');
                    if ($this.is(":checked")) {

                        onOff = 'on';
                    } else {

                        onOff = 'off';
                    }

                    if (permission == "") {

                        permission += menuId + '=' + onOff;
                    } else {

                        permission += '/' + menuId + '=' + onOff;
                    }
                });
                console.log($(".checkbox").children('input[type=checkbox]'));
                console.log(permission);

                //save code here
                var obj = empId + "+" + permission;
                console.log(obj);
                $.ajax({

                    method: 'post',
                    data: JSON.stringify({
                        "obj": obj
                    }),
                    url: 'pages/permission/permission.aspx/savePermission',
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
            });
        })
    </script>
</asp:Content>
