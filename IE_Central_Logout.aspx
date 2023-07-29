<%@ Page Title="" Language="C#" MasterPageFile="~/IE_Central_Master.Master" AutoEventWireup="true" CodeBehind="IE_Central_Logout.aspx.cs" Inherits="Industrial_Engineering.IE_Central_Logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
            <script type="text/javascript">
                function preventBack() { window.history.forward(); }
                setTimeout("preventBack()", 0);
                window.onunload = function () { null };
    </script>
    <meta http-equiv="pragma" content="no-cache" />
    <div>Logout
        </div>
</asp:Content>
