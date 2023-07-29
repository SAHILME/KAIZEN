<%@ Page Title="" Language="C#" MasterPageFile="~/IE_Central_Navigation_Master.Master" AutoEventWireup="true" CodeBehind="Project_Navigation.aspx.cs" Inherits="Industrial_Engineering.Project_Navigation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <!-- Page Heading -->
    <div class="card shadow">
        <div class="card-body">
            <div class="d-sm-flex align-items-center justify-content-between mb-4">
                <h1 class="h3 mb-0 text-gray-800">Select Scheme</h1>
            </div>
            <!-- Content Row -->
            <div class="row">

                <!-- Earnings (Monthly) Card Example -->

                <div class="col-xl-3 col-md-6 mb-4 shadow">
                    <div class="card border-left-primary shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div>
                                    <asp:Button ID="Button1" class="row btn btn-green" Style="margin-bottom: 16px" runat="server" Text="Kaizen" OnClick="Button1_Click" Height="74px" Width="170px" BackColor="#993366" ForeColor="White" />
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-calendar fa-2x text-gray-500"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Earnings (Monthly) Card Example -->
                <div class="col-xl-3 col-md-6 mb-4 shadow">
                    <div class="card border-left-success shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div>
                                    <asp:Button ID="Button2" class="row btn btn-green" Style="margin-bottom: 16px" runat="server" Text="Suggestion" Height="74px" Width="170px" BackColor="#006666" ForeColor="White" />
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-dollar-sign fa-2x text-gray-500"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Earnings (Monthly) Card Example -->
                <div class="col-xl-3 col-md-6 mb-4 shadow">
                    <div class="card border-left-info shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div>
                                    <asp:Button ID="Button3" class="row btn btn-green" Style="margin-bottom: 16px" runat="server" Text="Button" Height="74px" Width="170px" BackColor="#336699" ForeColor="White" />
                                </div>
                                <div class="col-auto">
                                    <i class="fas fa-clipboard-list fa-2x text-gray-500"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
