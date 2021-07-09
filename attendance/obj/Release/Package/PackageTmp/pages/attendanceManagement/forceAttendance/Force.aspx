<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="Force.aspx.cs" Inherits="attendance.pages.attendanceManagement.forceAttendance.Force" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Attendance Management</li>
                            <li class="active">Force Attendance
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->

            <div class="panel-heading">
                <h3 class="panel-title" style="color: red;">* Denotes Mandatory Fields</h3>
            </div>

            <form runat="server" role="form" class="form-horizontal">
                <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                <div>
                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div>
                                <div class="well">
                                    <div class="form-group">
                                        <label class="control-label col-md-6">Employee ID <span style="color: red">*</span></label>
                                        <div class="col-md-1">
                                            <div class="input-group">
                                                <asp:TextBox ID="TxtId" CssClass="form-control" AutoComplete="off" AutoPostBack="true" runat="server" OnTextChanged="TxtId_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label CssClass="control-label col-md-2" runat="server">Employee Name</asp:Label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="TxtEmp" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <asp:Label CssClass="control-label col-md-2" runat="server">Designation</asp:Label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="TxtDesignation" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label CssClass="control-label col-md-2" runat="server">Department</asp:Label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="TxtDept" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <asp:Label CssClass="control-label col-md-2" runat="server">Branch</asp:Label>
                                        <div class="col-md-4">
                                            <asp:TextBox ID="TxtBranch" CssClass="form-control" AutoComplete="off" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="well col-md-6">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="form-group">
                                <asp:Label ID="Label1" CssClass="control-label col-md-4" runat="server" Text="Label"> Attendance Type <span style="color: red">*</span> </asp:Label>
                                <div class="col-md-8">

                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
                                    <asp:RadioButton ID="SignIn" GroupName="AttendanceType" runat="server" AutoPostBack="true" OnCheckedChanged="SignIn_CheckedChanged" />
                                    Sign In
                                    <asp:RadioButton ID="SignOut" GroupName="AttendanceType" runat="server" AutoPostBack="true" OnCheckedChanged="SignOut_CheckedChanged" />
                                    Sign Out
                                    <asp:RadioButton ID="Both" GroupName="AttendanceType" Checked="true" runat="server" AutoPostBack="true" OnCheckedChanged="Both_CheckedChanged" />
                                    Both
                                </div>

                            </div>
                    <div class="form-group">
                        <label class="control-label col-md-4">Shift <span style="color: red">*</span></label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="shiftForm" CssClass="form-control" runat="server">
                                <asp:ListItem Value="1">First </asp:ListItem>
                                <asp:ListItem Value="2">Second</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-4">Effective Date <span style="color: red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtStartDate" CssClass="form-control englishDate7" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtNepaliDate" CssClass="form-control nepaliDate7" AutoComplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>

                            </div>
                        </div>
                        
                    </div>

                    <div class="form-group">
                        <label class="control-label col-md-4"> Date <span style="color: red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="txtEndDate" CssClass="form-control englishDate8" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate8" Autocomplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        
                    </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="form-group">
                        <div class="col-md-2 col-md-offset-10">
                            <asp:Button ID="plus" class="btn btn-info" runat="server" Text="+" OnClick="plus_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-md-1"></div>
                <div class="col-md-5 well">
                    <table id="" class="table table-striped  table-colored table-info">
                        <thead>
                            <tr>
                                <th>In/Out Mode </th>
                                <th>Shift 1 </th>
                                <th>Shift 2 </th>
                                <th>Shift 3 </th>
                                <th>Shift 4 </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>In Date </td>
                                <td id="shift1InDate" runat="server"></td>
                                <td id="shift2InDate" runat="server"></td>
                                <td id="shift3InDate" runat="server"></td>
                                <td id="shift4InDate" runat="server"></td>
                            </tr>
                            <tr>
                                <td>Out Date </td>
                                <td id="shift1OutDate" runat="server"></td>
                                <td id="shift2OutDate" runat="server"></td>
                                <td id="shift3OutDate" runat="server"></td>
                                <td id="shift4OutDate" runat="server"></td>
                            </tr>
                            <tr>
                                <td>Sign In </td>
                                <td id="shift1InTime" runat="server"></td>
                                <td id="shift2InTime" runat="server"></td>
                                <td id="shift3InTime" runat="server"></td>
                                <td id="shift4InTime" runat="server"></td>
                            </tr>
                            <tr>
                                <td>Sign Out </td>
                                <td id="shift1OutTime" runat="server"></td>
                                <td id="shift2OutTime" runat="server"></td>
                                <td id="shift3OutTime" runat="server"></td>
                                <td id="shift4OutTime" runat="server"></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridView1" runat="server"
                                            OnRowDataBound="GridView_RowDataBound"
                                            ShowHeader="True"
                                            Font-Size="Small"
                                            AutoGenerateColumns="false"
                                            CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                            EmptyDataText="No records has been added.">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkdetails" runat="server" onclick="checkAll(this);" />
                                                        All
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk2" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="txtStartDate" runat="server" Text='<%# Eval("Tdate","{0:yyyy-MM-dd}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Duty Roster">
                                                    <ItemTemplate>
                                                        <asp:Label ID="txtRooster" runat="server" Text='<%# Eval("Duty_roster") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="In Time">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtInTime" CssClass="form-control timePicker1" runat="server" Text='<%# Eval("Intime") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="In Remarks">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextInRemark" CssClass="form-control" runat="server">admin</asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Out Date">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtEndDate" CssClass="form-control englishDate7" runat="server" Text='<%# Eval("Tdate_Out","{0:yyyy-MM-dd}") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Out Time">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtOutTime" CssClass="form-control timePicker1" runat="server" Text='<%# Eval("Outtime") %>'>17:00:00</asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Out Remarks">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextOutRemark" CssClass="form-control" runat="server">admin</asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                        <asp:Label ID="txtRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            </Columns>
                                            <EditRowStyle />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EFF3FB" />

                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                        </asp:GridView>
                                    </div>
                                    <div class="col-md-8 col-md-offset-4">
                                        <div class="col-md-3">
                                            <asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSave_Click" />
                                        </div>

                                        <div class="col-md-3">
                                            <asp:Button ID="BtnCancel" CssClass="btn btn-danger col-md-12" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </form>

            <!-- container -->
        </div>
    </div>
    <!-- content -->
    <script type="text/javascript">
        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        inputList[i].checked = true;

                    }

                    else {
                        inputList[i].checked = false;

                    }

                }

            }

        }

        $(document).ready(function () {

            $('.nepaliDate1').nepaliDatePicker({
                npdMonth: true,
                npdYear: true,
                npdYearCount: 10,
                onChange: function () {
                    var a = BS2AD($('.nepaliDate1').val());
                    $('.englishDate1').val(a);
                    $('.englishDate2').val(a);
                    $('.nepaliDate2').val($('.nepaliDate1').val());

                    $('#<%=shift1InDate.ClientID%>').html('');
                    $('#<%=shift1OutDate.ClientID%>').html('');
                    $('#<%=shift1InTime.ClientID%>').html('');
                    $('#<%=shift1OutTime.ClientID%>').html('');

                    $('#<%=shift2InDate.ClientID%>').html('');
                    $('#<%=shift2OutDate.ClientID%>').html('');
                    $('#<%=shift2InTime.ClientID%>').html('');
                    $('#<%=shift2OutTime.ClientID%>').html('');

                    $('#<%=shift3InDate.ClientID%>').html('');
                    $('#<%=shift3OutDate.ClientID%>').html('');
                    $('#<%=shift3InTime.ClientID%>').html('');
                    $('#<%=shift3OutTime.ClientID%>').html('');

                    $('#<%=shift4InDate.ClientID%>').html('');
                    $('#<%=shift4OutDate.ClientID%>').html('');
                    $('#<%=shift4InTime.ClientID%>').html('');
                    $('#<%=shift4OutTime.ClientID%>').html('');

                    var effectiveDate = a;
                    var empId = $('#<%=TxtId.ClientID%>').val();
                    var sData = effectiveDate + "+" + empId;
                    console.log(effectiveDate);
                    console.log(empId);
                    console.log(sData);
                    $.ajax({

                        method: 'post',
                        data: JSON.stringify({
                            "sData": sData,
                        }),
                        url: 'pages/attendanceManagement/forceAttendance/force.aspx/getForceData',
                        contentType: "application/json; charset=utf-8",
                        dataType: 'json',
                        success: function (data) {

                            var data = data.d;
                            console.log(data);
                            var splitData = data.split('./.');
                            console.log(splitData);
                            if (splitData[0] != null) {

                                $('#<%=shift1InDate.ClientID%>').html(splitData[0]);
                                $('#<%=shift1OutDate.ClientID%>').html(splitData[1]);
                                $('#<%=shift1InTime.ClientID%>').html(splitData[2]);
                                $('#<%=shift1OutTime.ClientID%>').html(splitData[3]);
                            }
                            if (splitData[4] != null) {

                                $('#<%=shift2InDate.ClientID%>').html(splitData[4]);
                                $('#<%=shift2OutDate.ClientID%>').html(splitData[5]);
                                $('#<%=shift2InTime.ClientID%>').html(splitData[6]);
                                $('#<%=shift2OutTime.ClientID%>').html(splitData[7]);
                            }
                            if (splitData[8] != null) {

                                $('#<%=shift3InDate.ClientID%>').html(splitData[8]);
                                $('#<%=shift3OutDate.ClientID%>').html(splitData[9]);
                                $('#<%=shift3InTime.ClientID%>').html(splitData[10]);
                                $('#<%=shift3OutTime.ClientID%>').html(splitData[11]);
                            }
                            if (splitData[12] != null) {

                                $('#<%=shift4InDate.ClientID%>').html(splitData[12]);
                                $('#<%=shift4OutDate.ClientID%>').html(splitData[13]);
                                $('#<%=shift4InTime.ClientID%>').html(splitData[14]);
                                $('#<%=shift4OutTime.ClientID%>').html(splitData[15]);
                            }
                        }
                    });
                }
            });

            $('#<%=txtStartDate.ClientID%>').change(function () {

                $('#<%=shift1InDate.ClientID%>').html('');
                $('#<%=shift1OutDate.ClientID%>').html('');
                $('#<%=shift1InTime.ClientID%>').html('');
                $('#<%=shift1OutTime.ClientID%>').html('');

                $('#<%=shift2InDate.ClientID%>').html('');
                $('#<%=shift2OutDate.ClientID%>').html('');
                $('#<%=shift2InTime.ClientID%>').html('');
                $('#<%=shift2OutTime.ClientID%>').html('');

                $('#<%=shift3InDate.ClientID%>').html('');
                $('#<%=shift3OutDate.ClientID%>').html('');
                $('#<%=shift3InTime.ClientID%>').html('');
                $('#<%=shift3OutTime.ClientID%>').html('');

                $('#<%=shift4InDate.ClientID%>').html('');
                $('#<%=shift4OutDate.ClientID%>').html('');
                $('#<%=shift4InTime.ClientID%>').html('');
                $('#<%=shift4OutTime.ClientID%>').html('');

                var effectiveDate = $(this).val();
                var empId = $('#<%=TxtId.ClientID%>').val();
                var sData = effectiveDate + "+" + empId;
                console.log(effectiveDate);
                console.log(empId);
                console.log(sData);
                $.ajax({

                    method: 'post',
                    data: JSON.stringify({
                        "sData": sData,
                    }),
                    url: 'pages/attendanceManagement/forceAttendance/force.aspx/getForceData',
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    success: function (data) {

                        var data = data.d;
                        console.log(data);
                        var splitData = data.split('./.');
                        console.log(splitData);
                        if (splitData[0] != null) {

                            $('#<%=shift1InDate.ClientID%>').html(splitData[0]);
                            $('#<%=shift1OutDate.ClientID%>').html(splitData[1]);
                            $('#<%=shift1InTime.ClientID%>').html(splitData[2]);
                            $('#<%=shift1OutTime.ClientID%>').html(splitData[3]);
                        }
                        if (splitData[4] != null) {

                            $('#<%=shift2InDate.ClientID%>').html(splitData[4]);
                            $('#<%=shift2OutDate.ClientID%>').html(splitData[5]);
                            $('#<%=shift2InTime.ClientID%>').html(splitData[6]);
                            $('#<%=shift2OutTime.ClientID%>').html(splitData[7]);
                        }
                        if (splitData[8] != null) {

                            $('#<%=shift3InDate.ClientID%>').html(splitData[8]);
                            $('#<%=shift3OutDate.ClientID%>').html(splitData[9]);
                            $('#<%=shift3InTime.ClientID%>').html(splitData[10]);
                            $('#<%=shift3OutTime.ClientID%>').html(splitData[11]);
                        }
                        if (splitData[12] != null) {

                            $('#<%=shift4InDate.ClientID%>').html(splitData[12]);
                            $('#<%=shift4OutDate.ClientID%>').html(splitData[13]);
                            $('#<%=shift4InTime.ClientID%>').html(splitData[14]);
                            $('#<%=shift4OutTime.ClientID%>').html(splitData[15]);
                        }
                    }
                });
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
