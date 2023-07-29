<%@ Page Title="" Language="C#" MasterPageFile="~/IE_Kaizen/Admin/IE_Kaizen_Admin_Master_Page.Master" AutoEventWireup="true" CodeBehind="ADMIN_PAGE.aspx.cs" Inherits="Industrial_Engineering.IE_Kaizen.Admin.ADMIN_PAGE" EnableViewState="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <div class="card shadow">
        <div class="card-header shadow">Register User</div>
        <div class="card-body shadow">
            <div class="mb-3">
                <div class="row mb-3 form-group">
                    <asp:Label ID="Employee_Number_label" class="col-sm-2 col-form-label" runat="server" Text="Label"><h5>Employee Number</h5></asp:Label>
                    <div class="col">
                        <asp:TextBox ID="Employee_Number" runat="server" class="form-control" placeholder="Enter Your Employee Number"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3 form-group">
                    <asp:Label ID="FIRSTNAME_label" class="col-sm-2 col-form-label" runat="server" Text="Label">
                        <h5>FIRSTNAME</h5></asp:Label>
                    <div class="col">
                        <asp:TextBox ID="FIRSTNAME" runat="server" class="form-control" placeholder="Enter Your FIRSTNAME"></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-3 form-group">
                    <asp:Label ID="LASTNAME_label" class="col-sm-2 col-form-label" runat="server" Text="Label">
                        <h5>LASTNAME</h5></asp:Label>


                    <div class="col">
                        <asp:TextBox ID="LASTNAME" runat="server" class="form-control" placeholder="Enter Your LASTNAME"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3 form-group">
                    <asp:Label ID="Department_label" class="col-sm-2 col-form-label" runat="server" Text="Label">
                        <h5>Department</h5></asp:Label>


                    <div class="col">
                        <asp:DropDownList ID="Department" class="form-control" placeholder="Select Department" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="row mb-3 form-group">
                    <asp:Label ID="Discipline_label" class="col-sm-2 col-form-label" runat="server" Text="Label">
                        <h5>Discipline</h5></asp:Label>


                    <div class="col">
                        <asp:DropDownList ID="Discipline" class="form-control" placeholder="Select Discipline" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="row mb-3 form-group">
                    <asp:Label ID="Role_label" class="col-sm-2 col-form-label" runat="server" Text="Label">
                        <h5>Role</h5></asp:Label>


                    <div class="col">
                        <asp:DropDownList ID="Role" class="form-control" placeholder="Select Role" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-10">
                        <asp:Button ID="Register_User" class="btn btn-primary shadow" runat="server" Text="Register" OnClick="Register_Click" />
                    </div>
                    <asp:Label ID="Register_User_label" runat="server" Text="" ForeColor="Green"></asp:Label>
                </div>

            </div>
        </div>

    </div>
    <br>
      <br>
      <br>
    <div class="card shadow">
        <div class="card-header shadow">Users and Roles</div>
        <div class="card-body shadow">
            <div class="mb-3">
                <div class="row mb-3 form-group">
                    <asp:GridView runat="server" ID="grdViewAdminPage" HeaderStyle-BackColor="#2C4A76" HeaderStyle-ForeColor="White" Width="676px" AlternatingRowStyle-BackColor="#A4BBDD" AutoGenerateColumns="false">
                       <Columns>
                           <asp:BoundField HeaderText="Employee Number" DataField="EMPLOYEE_NO" />
                            <asp:BoundField HeaderText="Firstname" DataField="FIRSTNAME" />
                            <asp:BoundField HeaderText="Lastname" DataField="LASTNAME" />
                           <asp:BoundField HeaderText="Department" DataField="DEPARTMENT" />
                           <asp:BoundField HeaderText="Discipline" DataField="DISCIPLINE" />
                           <asp:BoundField HeaderText="Role" DataField="ROLE" />
                           </Columns> 
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
