<%@ Page Title="" Language="C#" MasterPageFile="~/IE_Kaizen/IE_Kaizen_Central_Master.Master" AutoEventWireup="true" CodeBehind="userLogout.aspx.cs" Inherits="Industrial_Engineering.IE_Kaizen.User.userLogout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
        <script type="text/javascript">
            function preventBack() { window.history.forward(); }
            setTimeout("preventBack()", 0);
            window.onunload = function () { null };
    </script>
    <meta http-equiv="pragma" content="no-cache" />
</asp:Content>
