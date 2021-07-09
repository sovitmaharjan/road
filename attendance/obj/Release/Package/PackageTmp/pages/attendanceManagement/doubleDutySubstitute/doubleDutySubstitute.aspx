<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="doubleDutySubstitute.aspx.cs" Inherits="attendance.pages.attendanceManagement.doubleDutySubstitute.doubleDutySubstitute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">
                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue">Home</li>
                            <li class="blue">Attendance Management</li>
                            <li class="active">Double Duty Subsitute
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->

            <form runat="server" role="form" class="form-horizontal">
                <asp:ScriptManager ID="scrManager" runat="server"></asp:ScriptManager>
                <div class="well">
                    <asp:UpdatePanel ID="upPnl" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="form-group">
                                <label class="control-label col-md-2">Employee ID <span style="color: red">*</span></label>
                                <div class="col-md-1">
                                    <asp:TextBox ID="txtEmpId" oninput="this.value=this.value.replace(/[^0-9.]/g,'');this.value=this.value.replace(/(\..*)\./g,'$1');" CssClass="form-control" AutoComplete="off" runat="server" AutoPostBack="True" OnTextChanged="txtEmpId_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-md-3"></div>
                                <label class="control-label col-md-2">Employee <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="CmbEmployee" CssClass="form-control" runat="server" CausesValidation="True" ToolTip="Employee List" AutoPostBack="true"
                                        EnableLoadOnDemand="true" EnableVirtualScrolling="true" AutoValidate="true" AllowCustomText="true" OnSelectedIndexChanged="CmbEmployee_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Designation <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtDesg" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                                <label class="control-label col-md-2">Status <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtSts" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-2">Department <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtDept" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>

                                </div>
                                <label class="control-label col-md-2">Branch <span style="color: red">*</span></label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="TxtBranch" CssClass="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="form-group">
                        <label class="control-label col-md-2">Double Duty Date <span style="color: red">*</span></label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtSDate" CssClass="form-control englishDate1" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TextBox1" AutoComplete="off" CssClass="form-control nepaliDate1" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">                  
                        <label class="control-label col-md-2">Subsitute Date <span style="color: red">*</span></label>

                        <div class="col-md-4">
                            <div class="input-group">
                                <asp:TextBox ID="TxtSubDate" CssClass="form-control englishDate2" AutoComplete="off" placeholder="English Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group">
                            <asp:TextBox ID="nepaliDate2" CssClass="form-control nepaliDate2" Autocomplete="off" placeholder="Nepali Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>

                <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="col-md-8 col-md-offset-4">
                            <div class="col-md-3">
                                <asp:Button ID="BtnLoad" CssClass="btn btn-success col-md-12" runat="server" Text="Load" OnClick="BtnLoad_Click" />
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="BtnReset" CssClass="btn btn-danger col-md-12" runat="server" Text="Reset" OnClick="BtnReset_Click" />
                            </div>
                        </div>

                        <div class="form-group"></div>

                        <div class="col-md-12">
                            <div class="row">
                                <div class="table-responsive">
                                    <asp:GridView ID="GridView" runat="server"
                                        ShowHeader="True"
                                        Font-Size="Small"
                                        AutoGenerateColumns="False"
                                        CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                        EmptyDataText="No records has been added.">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <%--<asp:TemplateField HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("tdate","{0:yyyy-MM-dd}")+ "<br> " + Eval("Shift")+ "<br>" + Eval("nepaliDate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="HrsMin" HeaderText="Worked Hrs" />
                                            <asp:BoundField DataField="InTime" HeaderText="In Time" />
                                            <asp:TemplateField HeaderText="Remarks">
                                                <HeaderTemplate>
                                                    Remarks
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("INREMARKS") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="TDate_Out" HeaderText="Out Date" DataFormatString="{0:yyyy/MM/dd}" />
                                            <asp:BoundField DataField="OutTime" HeaderText="Out Time" />
                                            <asp:BoundField DataField="OUTREMARKS" HeaderText="Remarks" />
                                            <asp:BoundField DataField="InTime1" HeaderText="In Time" />
                                            <asp:BoundField DataField="INREMARKS1" HeaderText="Remarks" />
                                            <asp:BoundField DataField="TDate_Out1" HeaderText="Out Date" DataFormatString="{0:yyyy/MM/dd}" />
                                            <asp:BoundField DataField="OutTime1" HeaderText="Out Time" />
                                            <asp:BoundField DataField="OUTREMARKS" HeaderText="Remarks" />
                                            <asp:BoundField DataField="TotalOT" HeaderText="OT" />
                                            <asp:BoundField DataField="Remark" HeaderText="Status" />
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
                            </div>
                        </div>

                        <div class="form-group"></div>

                        <div class="col-md-8 col-md-offset-4">
                            <div class="col-md-3">
                                <asp:Button ID="BtnSave" CssClass="btn btn-success col-md-12" runat="server" Text="Save" OnClick="BtnSave_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </form>
        </div>
        <!-- container -->
    </div>
</asp:Content>
