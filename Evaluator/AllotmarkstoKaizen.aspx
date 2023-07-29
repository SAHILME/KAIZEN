<%@ Page Title="" Language="C#" MasterPageFile="~/IE_Kaizen/Evaluator/IE_Kaizen_Evaluator_Central_Master.Master" AutoEventWireup="true" CodeBehind="AllotmarkstoKaizen.aspx.cs" Inherits="Industrial_Engineering.IE_Kaizen.Evaluator.AllotmarkstoKaizen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder1" runat="server">
       <div class="card shadow">
        <div class="card-header font-weight-bold shadow">Allot Marks to Kaizen ID: <asp:Label ID="kaizenid" runat="server" Text=""></asp:Label></div>
           <div>
               <asp:Label ID="KaizenTitle" runat="server" Text=""></asp:Label><br />
               <asp:Label ID="dateofapproval" runat="server" Text=""></asp:Label>
           </div>
         <div class="card-body shadow">
            <div class="col">
                <div class="mb-3">
                    <div class="row mb-3 form-group">
                        <div class="col">
                            <table id="tableContent" class="table" border="1" runat="server"></table>
                            <br/>
                            <br/>
                            <br/>
                            <br/>
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Questionaire1Label1" runat="server" Text="1. Questionaire"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="ExcellentLabel1" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Excellent &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="Excellent1" runat="server" GroupName="Questionaire1"/> <br />
                                            <asp:Label ID="VeryGoodLabel1" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Very Good  &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="VeryGood1" runat="server" GroupName="Questionaire1"/><br />
                                            <asp:Label ID="ModerateLabel1" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Moderate  &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="Moderate1" runat="server" GroupName="Questionaire1"/><br />
                                            <asp:Label ID="LittleEffectLabel1" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Little Effect  &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="LittleEffect1" runat="server" GroupName="Questionaire1"/><br />
                                            <asp:Label ID="NotapplicableLabel1" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Not applicable  &nbsp&nbsp&nbsp&nbsp "></asp:Label> <asp:RadioButton ID="Notapplicable1" runat="server" GroupName="Questionaire1"/><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Questionaire2Label1" runat="server" Text="2. Questionaire"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="ExcellentLabel2" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Excellent &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="Excellent2" runat="server" GroupName="Questionaire2"/><br />
                                            <asp:Label ID="VeryGoodLabel2" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Very Good &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="VeryGood2" runat="server" GroupName="Questionaire2"/><br />
                                            <asp:Label ID="ModerateLabel2" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Moderate &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="Moderate2" runat="server" GroupName="Questionaire2"/><br />
                                            <asp:Label ID="LittleEffectLabel2" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Little Effect &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="LittleEffect2" runat="server" GroupName="Questionaire2"/><br />
                                            <asp:Label ID="NotapplicableLabel2" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Not applicable &nbsp&nbsp&nbsp&nbsp "></asp:Label> <asp:RadioButton ID="Notapplicable2" runat="server" GroupName="Questionaire2"/><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Questionaire3Label1" runat="server" Text="3. Questionaire"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="ExcellentLabel3" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Excellent &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="Excellent3" runat="server" GroupName="Questionaire3"/><br />
                                            <asp:Label ID="VeryGoodLabel3" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Very Good &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="VeryGood3" runat="server" GroupName="Questionaire3"/><br />
                                            <asp:Label ID="ModerateLabel3" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Moderate &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="Moderate3" runat="server" GroupName="Questionaire3"/><br />
                                            <asp:Label ID="LittleEffectLabel3" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Little Effect &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="LittleEffect3" runat="server" GroupName="Questionaire3"/><br />
                                            <asp:Label ID="NotapplicableLabel3" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Not applicable &nbsp&nbsp&nbsp&nbsp "></asp:Label> <asp:RadioButton ID="Notapplicable3" runat="server" GroupName="Questionaire3"/><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Questionaire4Label1" runat="server" Text="4. Questionaire"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="ExcellentLabel4" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Excellent &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="Excellent4" runat="server" GroupName="Questionaire4"/><br />
                                            <asp:Label ID="VeryGoodLabel4" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Very Good &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="VeryGood4" runat="server" GroupName="Questionaire4"/><br />
                                            <asp:Label ID="ModerateLabel4" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Moderate &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="Moderate4" runat="server" GroupName="Questionaire4"/><br />
                                            <asp:Label ID="LittleEffectLabel4" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Little Effect &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="LittleEffect4" runat="server" GroupName="Questionaire4"/><br />
                                            <asp:Label ID="NotapplicableLabel4" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Not applicable &nbsp&nbsp&nbsp&nbsp "></asp:Label> <asp:RadioButton ID="Notapplicable4" runat="server" GroupName="Questionaire4"/><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Questionaire5Label1" runat="server" Text="5. Questionaire"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="ExcellentLabel5" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Excellent &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="Excellent5" runat="server" GroupName="Questionaire5"/><br />
                                            <asp:Label ID="VeryGoodLabel5" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Very Good &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="VeryGood5" runat="server" GroupName="Questionaire5"/><br />
                                            <asp:Label ID="ModerateLabel5" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Moderate &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="Moderate5" runat="server" GroupName="Questionaire5"/><br />
                                            <asp:Label ID="LittleEffectLabel5" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Little Effect &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="LittleEffect5" runat="server" GroupName="Questionaire5"/><br />
                                            <asp:Label ID="NotapplicableLabel5" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Not applicable &nbsp&nbsp&nbsp&nbsp "></asp:Label> <asp:RadioButton ID="Notapplicable5" runat="server" GroupName="Questionaire5"/><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Questionaire6Label1" runat="server" Text="6. Questionaire"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="ExcellentLabel6" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Excellent &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="Excellent6" runat="server" GroupName="Questionaire6"/><br />
                                            <asp:Label ID="VeryGoodLabel6" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Very Good &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="VeryGood6" runat="server" GroupName="Questionaire6"/><br />
                                            <asp:Label ID="ModerateLabel6" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Moderate &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="Moderate6" runat="server" GroupName="Questionaire6"/><br />
                                            <asp:Label ID="LittleEffectLabel6" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Little Effect &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="LittleEffect6" runat="server" GroupName="Questionaire6"/><br />
                                            <asp:Label ID="NotapplicableLabel6" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Not applicable &nbsp&nbsp&nbsp&nbsp "></asp:Label> <asp:RadioButton ID="Notapplicable6" runat="server" GroupName="Questionaire6"/><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Questionaire7Label1" runat="server" Text="7. Questionaire"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="ExcellentLabel7" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Excellent &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="Excellent7" runat="server" GroupName="Questionaire7"/><br />
                                            <asp:Label ID="VeryGoodLabel7" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Very Good &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="VeryGood7" runat="server" GroupName="Questionaire7"/><br />
                                            <asp:Label ID="ModerateLabel7" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Moderate &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="Moderate7" runat="server" GroupName="Questionaire7"/><br />
                                            <asp:Label ID="LittleEffectLabel7" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Little Effect &nbsp&nbsp&nbsp&nbsp "></asp:Label><asp:RadioButton ID="LittleEffect7" runat="server" GroupName="Questionaire7"/><br />
                                            <asp:Label ID="NotapplicableLabel7" runat="server" Text=" &nbsp&nbsp&nbsp&nbsp Not applicable &nbsp&nbsp&nbsp&nbsp "></asp:Label> <asp:RadioButton ID="Notapplicable7" runat="server" GroupName="Questionaire7"/><br />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        
                    </div>
                    <asp:Button ID="allotmarkssubmitbutton" runat="server" Text="Submit" CssClass="btn btn-success btn-primary"/>
                        <asp:Label ID="Kaizenis_label" class="col-form-label" ForeColor="Red" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
