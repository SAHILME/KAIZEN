<%@ Page Title="" Language="C#" MasterPageFile="~/IE_Kaizen/User/IE_Kaizen_User_Central_Mater.Master" AutoEventWireup="true" CodeBehind="abcd.aspx.cs" Inherits="Industrial_Engineering.IE_Kaizen.User.My_Kaizens" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">

       

       <!-- DataTales Example -->
    <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">DataTables Example</h6>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <table class="table table-bordered" id="myTable" width="100%" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Kaizen ID</th>

                            <th>Kaizen Title</th>
                            <th>Plant Department</th>
                            <th>Discipline</th>

                            <th>Savings</th>

                            <th>Date of Kaizen Submission</th>
                            <th>Kaizen Status</th>
                            <th>Savings</th>

                        </tr>
                    </thead>

                    <tbody>
                        <% foreach (var kaizen in MyKaizenDataList)
                           { %>
                        <tr>
                            <td><%= kaizen.KaizenID %></td>

                            <td><%= kaizen.Title %></td>
                            <td><%= kaizen.Dept %></td>
                            <td><%= kaizen.Discipline %></td>

                            <td><%= kaizen.Savings %></td>

                            <td><%= kaizen.Dateofsubmission %></td>
                            <td><%= kaizen.Status %></td>
                            <td><%= kaizen.Savings %></td>

                        </tr>
                        <% } %>
                    </tbody>
                </table>
            </div>
        </div>
    </div>



    <script>
        $(document).ready(function () {
            $('#myTable').DataTable();
        });
    </script>
</asp:Content>
