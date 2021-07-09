<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="viewDetail.aspx.cs" Inherits="attendance.pages.hrManagement.employee.viewDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-xs-12">
                    <div class="page-title-box">

                        <ol class="breadcrumb p-0 m-0">
                            <li class="blue"><a href="dashboard">Home</a></li>
                            <li class="blue"><a href="EmployeeList">Employee List</a></li>
                            <li class="active">View Details
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
                        <asp:Button ID="btnBack" CssClass="btn btn-success col-md-2" runat="server" Text="Back" OnClick="btnBack_Click" />
                        <asp:Button ID="btnEdit" CssClass="btn btn-primary col-md-2" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-5">
                        <asp:Image ID="PersImage" CssClass="thumbnail" runat="server" Style="height: 150px; width: 150px; border-style: ridge; border-width: 5px;" />
                    </div>

                </div>
                <div class="col-md-12 well">
                    <div class="col-md-6">
                        <h3 style="color: darkblue;">General Information</h3>
                        <div class="form-group">
                            <asp:Label ID="Label1" CssClass="col-md-4" runat="server" Text="Employee Id :-"></asp:Label>
                            <div class="col-md-5">
                                <asp:Label ID="lblid" runat="server"></asp:Label>
                            </div>

                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label2" CssClass="col-md-4" runat="server" Text="Full Name :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblname" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label3" CssClass="col-md-4" runat="server" Text="Gender :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblgender" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label13" CssClass="col-md-4" runat="server" Text="Relationship :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label15" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label5" CssClass="col-md-4" runat="server" Text="Date Of Birth :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lbldob" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label4" CssClass="col-md-4" runat="server" Text="Join Date :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lbldate" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label17" CssClass="col-md-4" runat="server" Text="Mobile :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label19" runat="server"></asp:Label>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <asp:Label ID="Label21" CssClass="col-md-4" runat="server" Text="Telephone :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label23" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label6" CssClass="col-md-4" runat="server" Text="Nationality :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label7" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label25" CssClass="col-md-4" runat="server" Text="Blood Group :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label26" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label27" CssClass="col-md-4" runat="server" Text="Mother's Name :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label28" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label29" CssClass="col-md-4" runat="server" Text="Father's Name :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label30" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label31" CssClass="col-md-4" runat="server" Text="Spouse Name :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label32" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label33" CssClass="col-md-4" runat="server" Text="Grand Father's Name :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label34" runat="server"></asp:Label>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <asp:Label ID="Label37" CssClass="col-md-4" runat="server" Text="Children 1 :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label38" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label39" CssClass="col-md-4" runat="server" Text="Children 2 :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label40" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-md-4" style="color: #3AC9D6;">Emergency Contacts </label>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label41" CssClass="col-md-4" runat="server" Text="Name :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label42" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label43" CssClass="col-md-4" runat="server" Text="Relation :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label44" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label45" CssClass="col-md-4" runat="server" Text="Contact :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label46" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-md-4" style="color: #3AC9D6;">Residential Address </label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label47" CssClass="col-md-4" runat="server" Text="State :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label48" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label49" CssClass="col-md-4" runat="server" Text="District :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label50" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label51" CssClass="col-md-4" runat="server" Text="City :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label52" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label53" CssClass="col-md-4" runat="server" Text="VDC/muncipality :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label54" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label55" CssClass="col-md-4" runat="server" Text="Ward No. :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label56" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label57" CssClass="col-md-4" runat="server" Text="Village/Tole  :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label58" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-md-4" style="color: #3AC9D6;">Permanent Address </label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label59" CssClass="col-md-4" runat="server" Text="State :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label60" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label61" CssClass="col-md-4" runat="server" Text="District :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label62" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label63" CssClass="col-md-4" runat="server" Text="City :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label64" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label65" CssClass="col-md-4" runat="server" Text="VDC/muncipality :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label66" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label67" CssClass="col-md-4" runat="server" Text="Ward No. :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label68" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label69" CssClass="col-md-4" runat="server" Text="Village/Tole  :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label70" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label8" CssClass="col-md-4" runat="server" Text="Email :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblemail" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label71" CssClass="col-md-4" runat="server" Text="Document Type  :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label72" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label73" CssClass="col-md-4" runat="server" Text=""></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label74" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label75" CssClass="col-md-4" runat="server" Text=""></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label76" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label77" CssClass="col-md-4" runat="server" Text=""></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label78" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label79" CssClass="col-md-4" runat="server" Text=""></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label80" runat="server"></asp:Label>
                            </div>
                        </div>
                        
                        
                        
                        
                    </div>
                    <div class="col-md-6">
                        <h3 style="color: darkblue;">Official Information</h3>
                        <div class="form-group">
                            <asp:Label ID="Label20" CssClass="col-md-4" runat="server" Text="Branch :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblbranch" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label18" CssClass="col-md-4" runat="server" Text="Department :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lbldept" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label9" CssClass="col-md-4" runat="server" Text="Login Id :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblusrid" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label22" CssClass="col-md-4" runat="server" Text="User Type :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblUsertype" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label11" CssClass="col-md-4" runat="server" Text="Supervisor :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblSupervisor" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label10" CssClass="col-md-4" runat="server" Text="Password :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblpassword" runat="server">******</asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label12" CssClass="col-md-4" runat="server" Text="Designation :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblDeg" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label14" CssClass="col-md-4" runat="server" Text="Type :-"></asp:Label>
                            <div class="col-md-3">
                                <asp:Label ID="lblType" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label16" CssClass="col-md-4" runat="server" Text="Status :-"></asp:Label>
                            <div class="col-md-3">
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label24" CssClass="col-md-4" runat="server" Text="Grade :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="lblgrade" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label81" CssClass="col-md-4" runat="server" Text="P.F :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label82" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label83" CssClass="col-md-4" runat="server" Text="C.I.T :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label84" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label85" CssClass="col-md-4" runat="server" Text="S.S :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label86" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label87" CssClass="col-md-4" runat="server" Text="PAN :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label88" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label89" CssClass="col-md-4" runat="server" Text="Bank A/c Number :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label90" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label91" CssClass="col-md-4" runat="server" Text="Official Email :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label92" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label35" CssClass="col-md-4" runat="server" Text="Web Login :-"></asp:Label>
                            <div class="col-md-8">
                                <asp:Label ID="Label36" runat="server"></asp:Label>
                            </div>
                        </div>

                    </div>
                </div>

                <div class="col-md-12">
                    <h3 style="color: darkblue;">Leave Management</h3>
                    <asp:GridView ID="grvLeave" runat="server"
                        Font-Size="Small"
                        AutoGenerateColumns="False"
                        EmptyDataText="No Records has been added."
                        CssClass="table table-striped table-bordered table-hover table-responsive table-colored table-info">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="LEAVE_NAME" HeaderText="Leave Name" />
                            <%--<asp:BoundField DataField="DAYS" HeaderText="Days" />
                            <asp:BoundField DataField="MAXDAYS" HeaderText="Max Days" />
                            <asp:BoundField DataField="status" HeaderText="status" />--%>
                            <asp:TemplateField HeaderText="Status" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("Status").ToString() == "1" ? "Assigned" : "Not Assigned" %>'
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
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

            </form>
        </div>
        <!-- container -->
    </div>
</asp:Content>
