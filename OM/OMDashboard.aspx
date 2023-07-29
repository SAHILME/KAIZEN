<%@ Page Title="" Language="C#" MasterPageFile="~/IE_Kaizen/OM/IE_Kaizen_OM_Central_Master.Master" AutoEventWireup="true" CodeBehind="OMDashboard.aspx.cs" Inherits="Industrial_Engineering.IE_Kaizen.OM.OMDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <div class="card shadow">
        <div class="card-header font-weight-bold shadow">Search Kaizen</div>
        <div class="card-body shadow">
            <div class="col">
                <div class="mb-3">
                    <div class="row">
                        <div class="col-md-5">
                            <div class="row mb-3 form-group">
                                <asp:Label ID="TxtFromndateeLabel1STATIC" runat="server" class="col-form-label" Text="From Date :"></asp:Label>
                                <div class="col">

                                    <asp:TextBox ID="TxtFromndate" runat="server" TextMode="Date" CssClass="form-control" />

                                </div>
                                <asp:Label ID="TxtFromndatedateLabel1" runat="server" class="col-form-label" ForeColor="Red" Text=""></asp:Label>
                            </div>
                        </div>
                        &nbsp &nbsp &nbsp &nbsp
                        <div class="col-md-5">
                            <div class="row mb-3 form-group">
                                <asp:Label ID="TextToBox1Label1STATIC" runat="server" class="col-form-label" Text="To Date :"></asp:Label>
                                <div class="col">

                                    <asp:TextBox ID="TextTodate" runat="server" TextMode="Date" CssClass="form-control" />

                                </div>
                                <asp:Label ID="TextToBox1Label2" runat="server" class="col-form-label" ForeColor="Red" Text=""></asp:Label>

                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-5">
                            <div class="row mb-3 form-group">
                                <asp:Label ID="Plant_Department_labelSTATIC" runat="server" class="col-form-label" Text="Plant/Department">Plant/Department :</asp:Label>
                                <div class="col">
                                    <asp:DropDownList ID="ddlPlantDepartment" runat="server" CssClass="form-control"></asp:DropDownList>
                                    
                                    </div>
                                <asp:Label ID="Plant_Department_label" runat="server" ForeColor="Red" class="col-form-label"></asp:Label>

                            </div>
                        </div>
                        &nbsp &nbsp &nbsp &nbsp
                        <div class="col-md-5">
                            <div class="row mb-3 form-group">
                                <asp:Label ID="Discipline_labelSTATIC" runat="server" class="col-form-label" Text="discipline">Discipline :</asp:Label>
                                <div class="col">
                                    <asp:DropDownList ID="ddlDiscipline" runat="server" CssClass="form-control">  </asp:DropDownList>
                                    
                                </div>
                                <asp:Label ID="Discipline_label" runat="server" ForeColor="Red" class="col-form-label"></asp:Label>

                            </div>
                        </div>
                    </div>
                    <div> 
                <asp:Label ID="btnSearchlabel" runat="server"  class="font-italic" Text=""></asp:Label>
                          
               <asp:Button ID="btnSearch" runat="server" Text="Search"  CssClass="btn btn-success" OnClick="btnSearch_Click" />

           </div>
                </div>
            </div>
        </div>
    </div>



    <div class="card shadow">
        <div class="card-header shadow">Kaizen List Waiting for Approval</div>
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

                                <asp:BoundField DataField="Discipline" HeaderText="Discipline" SortExpression="Discipline" />

                                <asp:TemplateField HeaderText="Evaluate">
                                    <ItemTemplate>
                                        <asp:Button ID="btnView" runat="server" Text="View & Evaluate" CommandName="Evaluate" BackColor="#4e73df" ForeColor="White" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="2" FirstPageText="First" LastPageText="Last" />
                            <PagerStyle CssClass="gridview-pager" />
                        </asp:GridView>
                    </div>

                    <div>
                        <asp:Label ID="GridView1label" runat="server" Text=""></asp:Label>
                    </div>

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
