<%@ Page Title="" Language="C#" MasterPageFile="~/attendanceMaster.Master" AutoEventWireup="true" CodeBehind="BackupDatabase.aspx.cs" Inherits="attendance.pages.Backup.BackupDatabase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <style type="text/css">
            .col-md-2 {
                margin-left: 107px;
            }
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="col-md-12 form-group">
                <div class="col-md-6 button-list">
                    <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" Font-Size="Large" ForeColor="#0033CC"></asp:Label>
                    <div class="col-md-6 button-list">
                        <asp:Button ID="btnBack" CssClass="btn btn-primary col-md-2" runat="server" Text="Back" BackColor="#9900FF" Width="104px"/>--%>
                    </div>
                </div>
            </div>
        </form>
    </body>
    </html>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
