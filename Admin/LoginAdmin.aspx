<%@ Page Title="" Language="C#" MasterPageFile="~/IE_Kaizen/Admin/IE_Kaizen_AdminLogin_Master.Master" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="Industrial_Engineering.IE_Kaizen.Admin.LoginAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <!--// <h4 class="card-title" style="text-align:center">Grievance Management System</h4>
   // <h5 class="card-title" style="text-align:center">Vigilance Department</h5>
    <div class="rcfth-filter">
        <div class="rcfth-col">
            <div class="form-group">
                <label for="">Enter Your Email Address</label>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text"><i class="fa fa-envelope"></i></span>
                    </div>
                    <asp:TextBox ID="txtUsername" runat="server" TextMode="Email"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>-->
    <div class="container">

        <!-- Outer Row -->
        <div class="row justify-content-center">

            <div class="col-xl-10 col-lg-12 col-md-9">

                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-block" style="background-repeat: no-repeat;">
                                <img class="rounded-circle" src="../../img/RCFLogo.png" height="400px" /></div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                                    </div>
                                    <div class="user">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtEmployeeNo" runat="server" TextMode="SingleLine" class="form-control form-control-user" Style="overflow: hidden;"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-user" TextMode="Password" Style="overflow: hidden;"></asp:TextBox>
                                        </div>


                                        <div style="text-align: center">
                                            <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-primary btn-user btn-block" OnClick="btnLogin_Click" />
                                        </div>
                                        <hr>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>


</asp:Content>
