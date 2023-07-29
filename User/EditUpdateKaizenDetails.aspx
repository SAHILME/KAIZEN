<%@ Page Title="" Language="C#" MasterPageFile="~/IE_Kaizen/User/IE_Kaizen_User_Central_Mater.Master" AutoEventWireup="true" CodeBehind="EditUpdateKaizenDetails.aspx.cs" Inherits="Industrial_Engineering.IE_Kaizen.User.EditUpdateKaizenDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
    <div id="username" class="align-content-center font-weight-bold bg-gradient-info"></div>

    <div class="card shadow">
        <div class="card-header font-weight-bold shadow">Edit Kaizen Details</div>
        <div class="card-body shadow">
            <div class="col">
                <div class="mb-3">
                    <div class="row mb-3 form-group">
                        <asp:Label ID="Titleofkaizen_labelSTATIC" class="col-form-label"  runat="server" Text="Title of Kaizen*">Title of Kaizen* :</asp:Label>
                        <div class="col">
                            <asp:TextBox ID="TextTitleofkaizen" runat="server" CssClass="form-control" placeholder="Enter Title of Kaizen" />
                        </div>
                        <asp:Label ID="Titleofkaizen_label" class="col-form-label"  ForeColor="Red" runat="server" ></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-md-5">
                            <div class="row mb-3 form-group">
                                <asp:Label ID="Plant_Department_labelSTATIC" runat="server"   class="col-form-label" Text="Plant/Department">Plant/Department* :</asp:Label>
                                <div class="col">
                                    <asp:DropDownList ID="ddlPlantDepartment" runat="server" CssClass="form-control">
                                       
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
                                <asp:DropDownList ID="ddlDiscipline" runat="server" CssClass="form-control">
                                   
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
                                        <asp:TextBox ID="txtteamMember1Name" runat="server" CssClass="form-control" />
                                         <asp:Label ID="teamMember1NameLabel1" runat="server"  ForeColor="Red" class="col-form-label" ></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="teamMember1empidLabel2STATIC"  runat="server" class="col-form-label" Text="">Employee Id :</asp:Label>
                                        <asp:TextBox ID="txtteamMember1empid" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event)"/>
                                        <asp:Label ID="teamMember1empidLabel2"  ForeColor="Red" runat="server" class="col-form-label" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="teamMember2NameLabel1STATIC" runat="server" class="col-form-label"  Text="">2. Name :</asp:Label>
                                        <asp:TextBox ID="txtteamMember2Name" runat="server" CssClass="form-control" />
                                        <asp:Label ID="teamMember2NameLabel1"  ForeColor="Red" runat="server" class="col-form-label" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="teamMember2empidLabel2STATIC" runat="server" class="col-form-label"   Text="">Employee Id :</asp:Label>
                                        <asp:TextBox ID="txtteamMember2empid" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event)"/>
                                        <asp:Label ID="teamMember2empidLabel2"  ForeColor="Red" runat="server" class="col-form-label" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="teamMember3NameLabel1STATIC" runat="server" class="col-form-label"  Text="">3. Name :</asp:Label>
                                        <asp:TextBox ID="txtteamMember3Name" runat="server" CssClass="form-control" />
                                        <asp:Label ID="teamMember3NameLabel1"  ForeColor="Red" runat="server" class="col-form-label" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="teamMember3empidLabel2STATIC" runat="server" class="col-form-label"  Text="">Employee Id :</asp:Label>
                                        <asp:TextBox ID="txtteamMember3empid" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event)"/>
                                        <asp:Label ID="teamMember3empidLabel2"  ForeColor="Red" runat="server" class="col-form-label" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <table class="table">
                          
                            <tbody>
                                <tr>
                                    
                                    <td>
<asp:Label ID="txtProblemDescriptionLabel1STATIC" runat="server" class="col-form-label"   Text="txtProblemDescription">Description of Problem* :</asp:Label>
                         <asp:Label ID="txtProblemDescriptionLabel1" runat="server" class="col-form-label"  ForeColor="Red" Text=""></asp:Label>
                                               
                                    </td>
                                    <td>
                            <asp:TextBox ID="txtProblemDescription" runat="server" CssClass="form-control" TextMode="MultiLine" />
                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td>
<asp:Label ID="txtRootCausesLabel1sSTATIC" runat="server" class="col-form-label"  Text="txtRootCauses">Root Causes* :</asp:Label>       
                         <asp:Label ID="txtRootCausesLabel1" runat="server" class="col-form-label"  ForeColor="Red" Text=""></asp:Label>
                 
                                    </td>
                                    <td>
                            <asp:TextBox ID="txtRootCauses" runat="server" CssClass="form-control" TextMode="MultiLine" />
                                    </td>
                                </tr>
								<tr>
                                    
                                    <td>
                        <asp:Label ID="txtSolutionLabel1STATIC" runat="server" class="col-form-label"   Text="txtSolution">Solution* :</asp:Label>
                         <asp:Label ID="txtSolutionLabel1" runat="server" class="col-form-label"  ForeColor="Red" Text=""></asp:Label>
                 
                                    </td>
                                    <td>
                            <asp:TextBox ID="txtSolution" runat="server" CssClass="form-control" TextMode="MultiLine" />
                                    </td>
                                </tr>
									<tr>
                                    
                                    <td>
                        <asp:Label ID="txtBenefitLabel2STATIC" runat="server" class="col-form-label"   Text="txtBenefit">Benefit* :</asp:Label>
                         <asp:Label ID="txtBenefitLabel2" runat="server" class="col-form-label"  ForeColor="Red" Text=""></asp:Label>
                 
                                    </td>
                                    <td>
                            <asp:TextBox ID="txtBenefit" runat="server" CssClass="form-control" TextMode="MultiLine" />
                                    </td>
                                </tr>
									<tr>
                                    
                                    <td>
                        <asp:Label ID="TxtimplementationdateLabel1STATIC" runat="server" class="col-form-label"   Text="Txtimplementationdate">Implementation Date* :</asp:Label>
                         <asp:Label ID="TxtimplementationdateLabel1" runat="server" class="col-form-label"  ForeColor="Red" Text=""></asp:Label>
                 
                                    </td>
                                    <td>
                            <asp:TextBox ID="Txtimplementationdate" runat="server" TextMode="Date" CssClass="form-control" />
                                    </td>
                                </tr>
								</tr>
									<tr>
                                    
                                    <td>
                        <asp:Label ID="TxtEmployeeNoLabel1STATIC" runat="server" class="col-form-label"  Text="txtEmployee">Employee No.*:</asp:Label>
                        <asp:Label ID="TxtEmployeeNoLabel1" runat="server" class="col-form-label"  ForeColor="Red" Text=""></asp:Label>
                 
                                    </td>
                                    <td>
                            <asp:TextBox ID="TxtEmployeeNo" runat="server" CssClass="form-control" ReadOnly="true" />
                                    </td>
                                </tr>
								</tr>
									<tr>
                                    
                                    <td>
                        <asp:Label ID="TxtMobileNumberLabel2STATIC" runat="server" class="col-form-label"  Text="txtMobile">Mobile Number* :</asp:Label>
                        <asp:Label ID="TxtMobileNumberLabel2" runat="server" class="col-form-label"  ForeColor="Red" Text=""></asp:Label>
                 
                                    </td>
                                    <td>
                            <asp:TextBox ID="TxtMobileNumber" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event)"/>
                                    </td>
                                </tr>
								</tr>
								<tr>
                                    <td>
                                        <asp:Label ID="kaizencategoryLabel1STATIC" runat="server"  Text="Label">Kaizen Category* :&nbsp &nbsp</asp:Label>
                                    </td>
                                    <td>
                                    Productivity: &nbsp &nbsp<asp:CheckBox ID="Productivity" runat="server" />&nbsp &nbsp
                                    Quality: &nbsp &nbsp<asp:CheckBox ID="Quality" runat="server" />&nbsp &nbsp
                                    Cost: &nbsp &nbsp<asp:CheckBox ID="Cost" runat="server" />&nbsp &nbsp
                                        <br />
                                    Safety: &nbsp &nbsp<asp:CheckBox ID="Safety" runat="server" />&nbsp &nbsp
                                    Environment: &nbsp &nbsp<asp:CheckBox ID="Environment" runat="server" />&nbsp &nbsp
                                    Morale: &nbsp &nbsp<asp:CheckBox ID="Morale" runat="server" />&nbsp &nbsp
                          <asp:Label ID="kaizencategoryLabel1" runat="server" class="col-form-label"  ForeColor="Red" Text=""></asp:Label>
                                </td>
                                </tr>
									<tr>
                                    
                                    <td>
                        <asp:Label ID="SavingLabel1STATIC" runat="server" class="col-form-label"   Text="txtSaving">Saving* : (Enter 0 if no savings...)</asp:Label>
                        <asp:Label ID="SavingLabel1" runat="server" class="col-form-label"  ForeColor="Red" Text=""></asp:Label>
                 
                                    </td>
                                    <td>
                            <asp:TextBox ID="txtSaving" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event)"/>
                                    </td>
                                </tr>
								<tr>
                                    
                                    <td>
                        <asp:Label ID="ImplementationcostLabel1STATIC" runat="server" class="col-form-label"  Text="Implementationcost">Cost of Implementation* :</asp:Label>
                        <asp:Label ID="ImplementationcostLabel1" runat="server" class="col-form-label"  ForeColor="Red" Text=""></asp:Label>
                 
                                    </td>
                                    <td>
                            <asp:TextBox ID="TxtImplementationcost" runat="server" CssClass="form-control" onkeypress="return isNumberKey(event)" />
                                    </td>
                                </tr>
                                
                                </tbody>
                         </table>
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
                                <div>
                                   <asp:Label ID="BeforeImplementationlabelLabel2" runat="server" Text="Old before image "></asp:Label>
                                <asp:Image ID="Image1" runat="server" />
                                   <asp:Label ID="BeforeImplementationlabelLabel1" runat="server" Text="Before Implementation Old Image"></asp:Label>
                                   </div> 
                                <br />

                                <asp:Label ID="fileBeforeImplementationlabelSTATIC" runat="server"  Text="Before Implementation* :"></asp:Label>
                                <br />
                                <asp:FileUpload ID="fileBeforeImplementationFileUpload1" runat="server" class="form-control-file" onchange="previewImage(this, 'previewImage1')" accept="image/*" />  
                                 <br />
                                <div>
                                    <img id="previewImage1" style="display: none;" alt="Preview Image 1" />
                                    
                                    <asp:Button ID="btnDeleteBeforeImage" runat="server" CssClass="btn btn-danger" Text="Delete" OnClientClick="clearFileUpload('fileUpload1', 'previewImage1'); return false;" ClientIDMode="Static" />    
                                <asp:Label ID="fileBeforeImplementationlabel" runat="server"  ForeColor="Red" Text=""></asp:Label>
                                </div>
                            </div>
                                
</div>
                        <div class="col-md-6">
                           <!-- <div class="form-group">

                                </div>-->
                            <div class="form-group">
                                          <div>
                                    <asp:Label ID="AfterImplementationLabel2" runat="server" Text="Old after image "></asp:Label>
                                 <asp:Image ID="Image2" runat="server" />
                                <asp:Label ID="AfterImplementationLabel1" runat="server" Text="Before Implementation Old Image"></asp:Label>
                                     </div>
                                <br /> 

                                <asp:Label ID="fileAfterImplementationLabel1STATIC" runat="server"   Text="After Implementation* :"></asp:Label>
                      
                                <br />
                                <asp:FileUpload ID="fileAfterImplementationFileUpload1" runat="server" class="form-control-file" onchange="previewImage(this, 'previewImage2')" accept="image/*" />
                                
                                <br />
                                <div>
                                    <img id="previewImage2" style="display: none;" alt="Preview Image 2" />
                                   
                                    <asp:Button ID="btnDeleteAfterImage" runat="server" CssClass="btn btn-danger" Text="Delete" OnClientClick="clearFileUpload('fileUpload1', 'previewImage2'); return false;" ClientIDMode="Static" />    
                                 <asp:Label ID="fileAfterImplementationLabel1" runat="server"  ForeColor="Red" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    
                        </div>
                    <hr />
                    <div class=" row">

                        <div>
                            <asp:Label ID="btnupdatelabel" runat="server"  class="font-italic" Text=""><h5>Note : On clicking on Update button, kaizen will not get submitted, user can find it on save as draft section.</h5></asp:Label>

                            <asp:Button ID="Button1" runat="server" Text="Cancel Editing" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                             &nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:Button ID="Button2" runat="server" Text="Update" ValidationGroup="saveandsubmit" CssClass="btn btn-primary" OnClick="btnupdate_Click"/>

                        </div><br />
                        &nbsp&nbsp&nbsp&nbsp&nbsp  <br /> 
           <div> 
                <br /><asp:Label ID="btnSubmitkazien" runat="server"  class="font-italic" Text=""><h5>Note : To Submit kaizen for evaluation, click on 'Final submit' button, for that both before and after images are required.</h5></asp:Label>
                          
               <asp:Button ID="btnupdate" runat="server" Text="Final Submit" ValidationGroup="saveandsubmit" CssClass="btn btn-success" OnClick="btnfinalSuccess_Click"/>

           </div>
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

