<%@ Page Title="" Language="C#" MasterPageFile="~/IE_Kaizen/Admin/IE_Kaizen_Admin_Master_Page.Master" AutoEventWireup="true" CodeBehind="Admin_Notification.aspx.cs" Inherits="Industrial_Engineering.IE_Kaizen.Admin.Admin_Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <div class="card shadow">
        <div class="card-header shadow">Add Notification</div>
        <div class="card-body shadow">
            <div class="mb-3">
                <div class="row mb-3 form-group">
                    <table>
                        <tbody>
                            <tr>
                                <td><b>Enter Notification</b></td>
                                <td></td>
                            </tr>
                            <tr class="col-sm-2 col-form-label">
                                <td><b>Notification</b></td>
                                <td style="top: 88px; left: 179px">
                                    <asp:TextBox runat="server" ID="txNotification"></asp:TextBox></td>
                            </tr>
                            <tr class="col-sm-2 col-form-label">
                                <td>
                                    <asp:Button ID="Submit" runat="server" Visible="true" class="btn btn-primary btn-user btn-block" Text="Submit" Width="163px" OnClick="Submit_Click" /></td>
                                    
                                
                                <td>
                                    <%--//--- Label to show alerts--%>
                                    <asp:Label ID="lblAlert" runat="server">
                                    </asp:Label></td>
                            </tr>
                            <tr>
                                <td><asp:Button ID="Update" runat="server" Visible="false" class="btn btn-primary btn-user btn-block" Text="Update" Width="163px" OnClick="Update_Click" /></td>
                                 <td>
                                    <%--//--- Label to show alerts--%>
                                    <asp:Label ID="LabelUpdate" runat="server">
                                    </asp:Label></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <br>
      <br>
      <br>
    <div class="card shadow">
        <div class="card-header shadow">Added Notifications</div>
        <div class="card-body shadow">
            <div class="mb-3">
                <div class="row mb-3 form-group">
                    <asp:GridView runat="server" ID="grdViewTest" HeaderStyle-BackColor="#2C4A76" HeaderStyle-ForeColor="White" Width="676px" AlternatingRowStyle-BackColor="#A4BBDD" AutoGenerateColumns="false" OnRowCommand="grdViewTest_RowCommand">
                        <Columns>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Literal ID="S_NO" runat="server" Visible="False" Text='<%# Eval("S_NO") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Serial NO" DataField="S_NO" />
                            <asp:BoundField HeaderText="Notification" DataField="NOTIFICATION" />
                            <asp:BoundField HeaderText="Date of Notification Published" DataField="NOTIFICATION_DATE" />
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="BtnEdit" CommandName="Change" ToolTip="Edit a record." Text="Edit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server"></asp:LinkButton>
                                    <asp:LinkButton ID="BtnDelete" CommandName="remove" ToolTip="Delete a record." Text="Delete" OnClientClick="return confirm('Are you sure you want to delete?');" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns> 
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
