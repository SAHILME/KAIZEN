<%@ Page Title="" Language="C#" MasterPageFile="~/IE_Kaizen/IE_Kaizen_Central_Master.Master" AutoEventWireup="true" CodeBehind="Role_Dashboard.aspx.cs" Inherits="Industrial_Engineering.IE_Kaizen.Role_Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">

    <!-- Page Heading -->
    <div class="card shadow">
        <div class="card-body">
            <div class="d-sm-flex align-items-center justify-content-between mb-4">
                <h1 class="h3 mb-0 text-gray-800">Select Scheme</h1>
            </div>
            <!-- Content Row -->
            <div class="row">


                <div>
                    <asp:Button ID="Button1" runat="server" Visible="false" Text="User_Dashboard" OnClick="Button1_Click" Height="74px" Width="270px" BackColor="#993366" ForeColor="White" />
                </div>

                <div>
                    <asp:Button ID="Button2" runat="server" Visible="false" Text="Coordinator_Dashboard" Height="74px" Width="270px" BackColor="#006666" ForeColor="White" OnClick="Button2_Click" />
                </div>

                <div></div>

                <div>
                    <asp:Button ID="Button3" runat="server" Visible="false" Text="Evaluator_Dashboard" Height="74px" Width="270px" BackColor="#336699" ForeColor="White" OnClick="Button3_Click" />
                </div>

                <div></div>

                <div>
                    <asp:Button ID="Button4" runat="server" Visible="false" Text="OM_Dashboard" Height="74px" Width="270px" BackColor="#3366cc" ForeColor="White" OnClick="Button4_Click" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>