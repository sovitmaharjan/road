<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="promotionList.aspx.cs" Inherits="attendance.pages.hrManagement.promotion.promotionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="../Dashboard.aspx">Home</a></li>
                            <li class="active">Employee Promotion List
                            </li>
                        </ol>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <!-- end row -->
            <form runat="server" role="form" class="form-horizontal">
                <div class="col-md-12 form-group">
                    <div class="col-md-6 button-list">
                        <asp:Button ID="BtnNew" CssClass="btn btn-primary col-md-2" runat="server" Text="ADD" OnClick="BtnNew_Click" />
                    </div>
                    <%--  <div class="col-md-3 button-list">
                          <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server" Placeholder="Search First Name" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                        </div>--%>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server"
                                Font-Size="Small"
                                AutoGenerateColumns="False"
                                CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info"
                                EmptyDataText="No Employees Records has been added." OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TDate" HeaderText="Date" DataFormatString="{0:yyyy/MM/dd}" />
                                    <asp:TemplateField HeaderText="Full Name (ID)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("emp_Fullname")+ " " +"("+ Eval("Emp_Id") +")"%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Expr2" HeaderText="Previous Designation" />
                                    <asp:BoundField DataField="DEG_NAME" HeaderText=" Current Designation" />
                                    <%--<asp:BoundField DataField="Emp_Id" HeaderText="Id" />--%>
                                    <%--<asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="View" ControlStyle-CssClass="btn btn-primary" HeaderText="Action" />--%>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
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
            </form>
        </div>
        <!-- container -->
    </div>
    <!-- content -->
</asp:Content>
