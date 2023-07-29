<%@ Page Title="" Language="C#" MasterPageFile="~/IE_Kaizen/User/IE_Kaizen_User_Central_Mater.Master" AutoEventWireup="true" CodeBehind="ViewKaizenDetails.aspx.cs" Inherits="Industrial_Engineering.IE_Kaizen.User.ViewKaizenDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <div id="username" class="align-content-center font-weight-bold bg-gradient-info"></div>

    <div class="card shadow">
        <div class="card-header font-weight-bold shadow">View Kaizen Details</div>
        <div class="card-body shadow">
            <div class="col">
                <div class="mb-3">
                    <div class="row mb-3 form-group">
                        <asp:Label ID="Titleofkaizen_labelSTATIC" class="col-form-label"  runat="server" Text="Title of Kaizen*">Title of Kaizen* :</asp:Label>
                        <div class="col">
                            <asp:TextBox ID="TextTitleofkaizen" ReadOnly="true" runat="server" CssClass="form-control" placeholder="Enter Title of Kaizen" />
                        </div>
                        <asp:Label ID="Titleofkaizen_label" class="col-form-label"  ForeColor="Red" runat="server" ></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-5">
                            <div class="row mb-3 form-group">
                                <asp:Label ID="Plant_Department_labelSTATIC" runat="server"   class="col-form-label" Text="Plant/Department">Plant/Department* :</asp:Label>
                                <div class="col">
                                    <asp:DropDownList ID="ddlPlantDepartment" runat="server" ReadOnly="true" CssClass="form-control">
                                        <asp:ListItem>--select one--</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                 <asp:Label ID="Plant_Department_label" runat="server"  ForeColor="Red" class="col-form-label"></asp:Label>
                                
                            </div>
                        </div>
                        &nbsp &nbsp
                    <div class="col-md-5">
                        <div class="row mb-3 form-group">
                            <asp:Label ID="Discipline_labelSTATIC" runat="server"  class="col-form-label" Text="discipline">Discipline* :</asp:Label>
                            <div class="col">
                                <asp:DropDownList ID="ddlDiscipline" runat="server" ReadOnly="true"  CssClass="form-control">
                                    <asp:ListItem>--select one--</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:Label ID="Discipline_label" runat="server"  ForeColor="Red" class="col-form-label" ></asp:Label>
                            
                        </div>
                    </div>
                    </div>
                    <div class="row mb-3 form-group">
                        <label id="TeamMembers"   class="font-weight-bold">Enter Team Members Details (optional)</label>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Member's Name</th>
                                    <th>Member's Employee Number</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="teamMember1NameLabel1STATIC" runat="server"  class="col-form-label" Text="">1. Name :</asp:Label>
                                        <asp:TextBox ID="txtteamMember1Name" runat="server" ReadOnly="true"  CssClass="form-control" />
                                         <asp:Label ID="teamMember1NameLabel1" runat="server"  ForeColor="Red" class="col-form-label" ></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="teamMember1empidLabel2STATIC"  runat="server" class="col-form-label" Text="">Employee Id :</asp:Label>
                                        <asp:TextBox ID="txtteamMember1empid" runat="server" ReadOnly="true"  CssClass="form-control" onkeypress="return isNumberKey(event)"/>
                                        <asp:Label ID="teamMember1empidLabel2"  ForeColor="Red" runat="server" class="col-form-label" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="teamMember2NameLabel1STATIC" runat="server" class="col-form-label"  Text="">2. Name :</asp:Label>
                                        <asp:TextBox ID="txtteamMember2Name" runat="server"  ReadOnly="true" CssClass="form-control" />
                                        <asp:Label ID="teamMember2NameLabel1"  ForeColor="Red" runat="server" class="col-form-label" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="teamMember2empidLabel2STATIC" runat="server" class="col-form-label"   Text="">Employee Id :</asp:Label>
                                        <asp:TextBox ID="txtteamMember2empid" runat="server" ReadOnly="true"  CssClass="form-control" onkeypress="return isNumberKey(event)"/>
                                        <asp:Label ID="teamMember2empidLabel2"  ForeColor="Red" runat="server" class="col-form-label" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="teamMember3NameLabel1STATIC" runat="server" class="col-form-label"  Text="">3. Name :</asp:Label>
                                        <asp:TextBox ID="txtteamMember3Name" runat="server"  ReadOnly="true" CssClass="form-control" />
                                        <asp:Label ID="teamMember3NameLabel1"  ForeColor="Red" runat="server" class="col-form-label" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="teamMember3empidLabel2STATIC" runat="server" class="col-form-label"  Text="">Employee Id :</asp:Label>
                                        <asp:TextBox ID="txtteamMember3empid" runat="server"  ReadOnly="true" CssClass="form-control" onkeypress="return isNumberKey(event)"/>
                                        <asp:Label ID="teamMember3empidLabel2"  ForeColor="Red" runat="server" class="col-form-label" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                     <div class="row mb-3 form-group">
                      <table class="table">
                        <tbody>
                            <tr>

                                <td>
                                    <asp:Label ID="txtProblemDescriptionLabel1STATIC" runat="server" class="col-form-label" Text="txtProblemDescription">Description of Problem* :</asp:Label><br />
                                    <asp:Label ID="txtProblemDescriptionLabel1" runat="server" class="col-form-label" ForeColor="Red" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtProblemDescription" runat="server"   ReadOnly="true" CssClass="form-control" TextMode="MultiLine" />
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="txtRootCausesLabel1sSTATIC" runat="server" class="col-form-label" Text="txtRootCauses">Root Causes* :</asp:Label><br />
                                    <asp:Label ID="txtRootCausesLabel1" runat="server" class="col-form-label" ForeColor="Red" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtRootCauses" runat="server"   ReadOnly="true" CssClass="form-control" TextMode="MultiLine" />
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="txtSolutionLabel1STATIC" runat="server" class="col-form-label" Text="txtSolution">Solution* :</asp:Label><br />
                                    <asp:Label ID="txtSolutionLabel1" runat="server" class="col-form-label" ForeColor="Red" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtSolution" runat="server"   ReadOnly="true" CssClass="form-control" TextMode="MultiLine" />
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="txtBenefitLabel2STATIC" runat="server" class="col-form-label" Text="txtBenefit">Benefit* :</asp:Label><br />
                                    <asp:Label ID="txtBenefitLabel2" runat="server" class="col-form-label" ForeColor="Red" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtBenefit" runat="server"   ReadOnly="true" CssClass="form-control" TextMode="MultiLine" />
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="TxtimplementationdateLabel1STATIC" runat="server" class="col-form-label" Text="Txtimplementationdate">Implementation Date* :</asp:Label><br />
                                    <asp:Label ID="TxtimplementationdateLabel1" runat="server" class="col-form-label" ForeColor="Red" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="Txtimplementationdate" runat="server"   ReadOnly="true" TextMode="Date" CssClass="form-control" />
                                </td>
                            </tr>
                            
									<tr>

                                        <td>
                                            <asp:Label ID="TxtEmployeeNoLabel1STATIC" runat="server" class="col-form-label" Text="txtEmployee">Employee No.*:</asp:Label><br />
                                            <asp:Label ID="TxtEmployeeNoLabel1" runat="server" class="col-form-label" ForeColor="Red" Text=""></asp:Label>

                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtEmployeeNo" runat="server"   ReadOnly="true" CssClass="form-control" />
                                        </td>
                                    </tr>
                            
									<tr>

                                        <td>
                                            <asp:Label ID="TxtMobileNumberLabel2STATIC" runat="server" class="col-form-label" Text="txtMobile">Mobile Number* :</asp:Label><br />
                                            <asp:Label ID="TxtMobileNumberLabel2" runat="server" class="col-form-label" ForeColor="Red" Text=""></asp:Label>

                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtMobileNumber" runat="server"   ReadOnly="true" CssClass="form-control" onkeypress="return isNumberKey(event)" />
                                        </td>
                                    </tr>
                          
								<tr>
                                    <td>
                                        <asp:Label ID="kaizencategoryLabel1STATIC" runat="server" Text="Label">Kaizen Category* :&nbsp &nbsp</asp:Label><br />
                                        <asp:Label ID="kaizencategoryLabel1" runat="server" class="col-form-label" ForeColor="Red" Text=""></asp:Label>
                                    </td>
                                    <td>
                                            Productivity: &nbsp &nbsp<asp:CheckBox ID="Productivity" runat="server" Enabled="false" />&nbsp &nbsp
                                            Quality: &nbsp &nbsp<asp:CheckBox ID="Quality" runat="server" Enabled="false" />&nbsp &nbsp 
                                            Cost: &nbsp &nbsp<asp:CheckBox ID="Cost" runat="server" Enabled="false" />&nbsp &nbsp
                                        <br />
                                            Safety: &nbsp &nbsp<asp:CheckBox ID="Safety" runat="server" Enabled="false" />&nbsp &nbsp
                                            Environment: &nbsp &nbsp<asp:CheckBox ID="Environment" runat="server" Enabled="false" />&nbsp &nbsp
                                            Morale: &nbsp &nbsp<asp:CheckBox ID="Morale" runat="server" Enabled="false" />&nbsp &nbsp

                                    </td>
                                </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="SavingLabel1STATIC" runat="server" class="col-form-label" Text="txtSaving">Saving* : (Enter 0 if no savings...)</asp:Label><br />
                                    <asp:Label ID="SavingLabel1" runat="server" class="col-form-label" ForeColor="Red" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtSaving" runat="server" CssClass="form-control"  ReadOnly="true"  onkeypress="return isNumberKey(event)" />
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="ImplementationcostLabel1STATIC" runat="server" class="col-form-label" Text="Implementationcost">Cost of Implementation* :</asp:Label><br />
                                    <asp:Label ID="ImplementationcostLabel1" runat="server" class="col-form-label" ForeColor="Red" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="TxtImplementationcost" runat="server"  ReadOnly="true"  CssClass="form-control" onkeypress="return isNumberKey(event)" />
                                </td>
                            </tr>

                        </tbody>
                    </table>
                         </div>
                    <hr />
                     <div>

                   <div class="row mb-3 form-group font-italic">
                        
                    <div> Upload Before and after implementaion images.</div>
                     <div> Note : Only images are allowed and image extension should be any of ( ".jpg" , ".jpeg" , ".png" , ".gif") and Image size should be less than 10 MB.

                     </div>
                    
                         </div>
                          </div>
                    <hr />
                    <div >
                        <div class="col-md-6">
                            <!--<div class="form-group">
                                 </div>-->
                            <div class="form-group">
                                <asp:Label ID="fileBeforeImplementationlabelSTATIC" runat="server"  Text="Before Implementation* :"></asp:Label>
                               <!--<asp:FileUpload ID="fileBeforeImplementationlabelFileUpload1"  ReadOnly="true" runat="server" class="form-control-file" onchange="previewImage(this, 'previewImage1')" accept="image/*" />-->
                                <asp:Label ID="BeforeImplementationlabelLabel1" runat="server" Text=""></asp:Label>
                                 <br />
                                <div>
                                    <img id="previewImage1" style="display: none;" alt="Preview Image 1" />
                                    <asp:Image ID="Image1" runat="server" />
                                    <!--<asp:Button ID="btnDeleteBeforeImage" runat="server" visible="false" CssClass="btn btn-danger" Text="Delete" OnClientClick="clearFileUpload('fileUpload1', 'previewImage1'); return false;" ClientIDMode="Static" /> -->   
                                <asp:Label ID="fileBeforeImplementationlabel" runat="server"  ForeColor="Red" Text=""></asp:Label>
                                </div>
                            </div>
                                
</div>
                        <div class="col-md-6">
                           <!-- <div class="form-group">

                                </div>-->
                            <div class="form-group">
                                <asp:Label ID="fileAfterImplementationLabel1STATIC" runat="server"   Text="After Implementation* :"></asp:Label>

                                <!--<asp:FileUpload ID="fileAfterImplementationFileUpload1"  ReadOnly="true" runat="server" class="form-control-file" onchange="previewImage(this, 'previewImage2')" accept="image/*" />-->
                                <asp:Label ID="AfterImplementationLabel1" runat="server" Text="Label"></asp:Label>
                                <br />
                                <div>
                                    <img id="previewImage2" style="display: none;" alt="Preview Image 2" />
                                    <asp:Image ID="Image2" runat="server" />
                                    <!--<asp:Button ID="btnDeleteAfterImage" runat="server" visible="false" CssClass="btn btn-danger" Text="Delete" OnClientClick="clearFileUpload('fileUpload1', 'previewImage2'); return false;" ClientIDMode="Static" /> -->   
                                 <asp:Label ID="fileAfterImplementationLabel1" runat="server"  ForeColor="Red" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    
                        </div>
                    <hr />
                    <div class=" row">

                      
                        &nbsp&nbsp&nbsp&nbsp&nbsp  <br /> 

                        </div>
                       <div> &nbsp&nbsp&nbsp<asp:Label ID="finalmsglabel" ForeColor="Red" runat="server"></asp:Label>
                           </div>
                    

                    <!-- Include Bootstrap JS -->
                    <script src="../../js/bootstrapimageuploadpreview.min.js"></script>
                    <script>
                        function previewImage(fileUpload, previewImageId) {

                            if (fileUpload.files && fileUpload.files[0]) {
                                var selectedFile = fileUpload.files[0];
                                var previewImage = document.getElementById(previewImageId);

                                var reader = new FileReader();
                                reader.onload = function (e) {
                                    previewImage.src = e.target.result;
                                    previewImage.style.display = 'block';
                                };
                                reader.readAsDataURL(selectedFile);
                            }

                        }

                        function clearFileUpload(fileUploadId, previewImageId) {
                            var fileUpload = document.getElementById(fileUploadId);
                            fileUpload.value = '';
                            console.log("clearFileUpload");
                            var previewImage = document.getElementById(previewImageId);
                            previewImage.src = '';
                            previewImage.style.display = 'none';

                            deleteButton.style.display = 'none';
                        }
                        function isNumberKey(evt) {
                            var charCode = (evt.which) ? evt.which : event.keyCode;
                            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                                return false;
                            return true;
                        }


                    </script>
                </div>
            </div>


        </div>
    </div>


</asp:Content>
