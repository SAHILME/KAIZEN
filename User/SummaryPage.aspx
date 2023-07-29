<%@ Page Title="" Language="C#" MasterPageFile="~/IE_Kaizen/User/IE_Kaizen_User_Central_Mater.Master" AutoEventWireup="true" CodeBehind="SummaryPage.aspx.cs" Inherits="Industrial_Engineering.IE_Kaizen.User.SummaryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <div class="card shadow">
        <div class="card-header font-weight-bold shadow">Fill Kaizen Details</div>
        <div class="card-body shadow">
            <div class="col">
                <div class="mb-3">
                    <div class="row mb-3 form-group">
    <table class="table table-striped align-content-center shadow">
        <thead>
            <div>
                <h3>Summary of Kaizens Of Employee</h3>
            </div>
            <tr>
                <th>Total Kaizens</th>
                <th>No. of Kaizen Submitted </th>
                <th>No. of Kaizen Drafted </th>
                <th>No. of Kaizen Rejected </th>
                <th>No. of Kaizen registered by Coordinator </th>
                <th>No. of Kaizen Evaluated by Evaluator</th>
                    <th>No. of kaizen Accepted by OM</th>
                    <th>Total Savings by Implementation</th>
            </tr>
        </thead>
        <tbody >
            <tr>
                
                <td>
                    <asp:Label ID="TotalKaizens" runat="server" Text="Label"></asp:Label>

                </td>
                <td>
                    <asp:Label ID="KaizenSubmitted" runat="server" Text="Label"></asp:Label>

                </td>
                <td> <asp:Label ID="KaizenDrafted" runat="server" Text="Label"></asp:Label>

                </td>
                <td> <asp:Label ID="KaizenRejected" runat="server" Text="Label"></asp:Label>

                </td>
                <td> <asp:Label ID="KaizenregisteredbyCoordinator" runat="server" Text="Label"></asp:Label>

                </td>
                <td> <asp:Label ID="KaizenEvaluatedbyEvaluator" runat="server" Text="Label"></asp:Label>

                </td>
                <td> <asp:Label ID="kaizenAcceptedbyOM" runat="server" Text="Label"></asp:Label>

                </td>
                <td> <asp:Label ID="TotalSavings" runat="server" Text="Label"></asp:Label>
                </td>
                </tr>
        </tbody>
    </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
