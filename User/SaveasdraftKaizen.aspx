<%@ Page Title="" Language="C#" MasterPageFile="~/IE_Kaizen/User/IE_Kaizen_User_Central_Mater.Master" AutoEventWireup="true" CodeBehind="SaveasdraftKaizen.aspx.cs" Inherits="Industrial_Engineering.IE_Kaizen.User.SaveasdraftKaizen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
        <div class="card shadow">
        <div class="card-header shadow">Save as Draft Kaizens List</div>
        <div class="card-body shadow">
            <div class="mb-3">
                <div class="row mb-3 form-group">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                            AllowPaging="True" PageSize="10"
                            AllowSorting="True" 
                            OnSorting="GridView1_Sorting"
                            OnPageIndexChanging="GridView1_PageIndexChanging"
                           
                            OnRowDataBound="GridView1_RowDataBound"
                            OnRowCommand="GridView1_RowCommand" HeaderStyle-BackColor="#2C4A76" HeaderStyle-ForeColor="White" Width="100%" AlternatingRowStyle-BackColor="#A4BBDD">

                            <Columns>
                                <asp:TemplateField HeaderText="S_no">
                                    <ItemTemplate>
                                        <asp:Literal ID="literalSNo" runat="server"></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Literal ID="Kaizen_ID" runat="server" Visible="False" Text='<%# Eval("Kaizen_ID") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Kaizen_ID" HeaderText="Kaizen ID" SortExpression="Kaizen_ID" />
                                <asp:BoundField DataField="Kaizen_title" HeaderText="Kaizen Title" SortExpression="Kaizen_title" />
                                <asp:BoundField DataField="Plant_Department" HeaderText="Dept" SortExpression="Plant_Department" />

                                <asp:BoundField DataField="Status_of_Kaizen" HeaderText="Status" SortExpression="Status_of_Kaizen" />

                                <asp:BoundField DataField="Savings" HeaderText="Savings" SortExpression="Savings" />

                                <asp:TemplateField HeaderText="View Details">
                                    <ItemTemplate>
                                        <asp:Button ID="btnView" runat="server" Text="View" CommandName="ViewDetails" BackColor="#4e73df" ForeColor="White" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditRow" BackColor="#4e73df" ForeColor="White" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Delete kaizen">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="remove" BackColor="#4e73df" ForeColor="White" OnClientClick="return confirm('Are you sure you want to delete?');" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last"/> 
                            <PagerStyle CssClass="gridview-pager" />
                        </asp:GridView>
                    </div>

                    <div>
                        <asp:Label ID="GridView1label" runat="server" Text=""></asp:Label></div>

                </div>
                 </div>
             </div>
             </div>
    
    <!-- <asp:BoundField DataField="DateOfRegistration" HeaderText="Date of Registration" SortExpression="DateOfRegistration" />
        <asp:BoundField DataField="DateOfEvaluated" HeaderText="Date of Evaluated" SortExpression="DateOfEvaluated" />
        <asp:BoundField DataField="DateOfApprovalByOM" HeaderText="Date of Approval By OM" SortExpression="DateOfApprovalByOM" />
        <asp:BoundField DataField="DateOfPresentation" HeaderText="Date of Presentation" SortExpression="DateOfPresentation" />-->
     <!--<asp:BoundField DataField="RewardStatus" HeaderText="Reward Status" SortExpression="RewardStatus" />-->
</asp:Content>

