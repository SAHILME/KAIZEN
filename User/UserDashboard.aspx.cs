using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.IO;


namespace Industrial_Engineering.IE_Kaizen.User
{
    public partial class UserDashboard : System.Web.UI.Page
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

        string saveasdraft;
        DateTime? saveasdraftdate = null;
        int statusofkaizen;
        DateTime? Date_of_Kaizen_Submission = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            String username = (string)(Session["username"]);
            String role = (string)(Session["role"]); //String.IsNullOrEmpty(role) should be empty
            if (String.IsNullOrEmpty(username) || !String.IsNullOrEmpty(role))
            {
                HttpContext.Current.Response.Redirect("~/IE_Central_Logout.aspx");
            }
            

            fileAfterImplementationLabel1.Text = string.Empty;
            fileBeforeImplementationlabel.Text = string.Empty;
            TxtimplementationdateLabel1.Text = string.Empty;
            ImplementationcostLabel1.Text = string.Empty;
            SavingLabel1.Text = string.Empty;
            kaizencategoryLabel1.Text = string.Empty;
            TxtMobileNumberLabel2.Text = string.Empty;
            txtBenefitLabel2.Text = string.Empty;
            txtSolutionLabel1.Text = string.Empty;
            teamMember3empidLabel2.Text = string.Empty;
            teamMember2empidLabel2.Text = string.Empty;
            teamMember1empidLabel2.Text = string.Empty;
            Discipline_label.Text = string.Empty;
            Plant_Department_label.Text = string.Empty;
            txtRootCausesLabel1.Text = string.Empty;
            txtProblemDescriptionLabel1.Text = string.Empty;
            Titleofkaizen_label.Text = string.Empty;
            finalmsglabel.Text = string.Empty;
            
            TxtEmployeeNo.Text = (string)Session["KaizenUser"];
            if (!IsPostBack)
            {
                FillDiscipline();
                FillDepartment();
            }
            
        }

        private void FillDiscipline()
        {

            string disciplineListQuery = "select DISCIPLINE from IE_KAIZEN_PLANT_DISCIPLINE_CREDS";
            SqlCommand cmd = new SqlCommand(disciplineListQuery, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ddlDiscipline.DataSource = dr;
            ddlDiscipline.DataTextField = "DISCIPLINE";
            ddlDiscipline.DataValueField = "DISCIPLINE";
            ddlDiscipline.DataBind();
            //dr.Close();
            dr.Dispose();
            connection.Close();
            ddlDiscipline.Items.Insert(0, new ListItem("---Select One---", "---Select One---")); //updated code

        }
        private void FillDepartment()
        {

            string departmentListQuery = "select Department from IE_KAIZEN_PLANT_DEPARTMENT_CREDS";
            SqlCommand cmd = new SqlCommand(departmentListQuery, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ddlPlantDepartment.DataSource = dr;
            ddlPlantDepartment.DataTextField = "DEPARTMENT";
            ddlPlantDepartment.DataValueField = "DEPARTMENT";
            ddlPlantDepartment.DataBind();
            //dr.Close();
            dr.Dispose();
            connection.Close();
            ddlPlantDepartment.Items.Insert(0, new ListItem("---Select One---", "---Select One---")); //updated code

        }

        private string GetKaizenId(SqlConnection connection, SqlTransaction transaction)
        {
            {
                string kaizenId = string.Empty;
                
                try
                {
                    
                    // Get the latest Kaizen ID from the database
                    string selectQuery = "SELECT MAX(Kaizen_ID) AS CURRENT_ID FROM IE_USERS_KAIZEN_DETAILS";
                    SqlCommand cmd = new SqlCommand(selectQuery, connection, transaction);
                    SqlDataReader dr = cmd.ExecuteReader();

                    DateTime date = DateTime.Now;
                    string yearMonth = date.ToString("yyyy-MM");

                    if (dr.HasRows)
                    {
                        dr.Read();
                        string lastKaizenId = dr.GetValue(0).ToString();

                        if (lastKaizenId != "")
                        {
                            // Increment the Kaizen ID
                            int numericPart = int.Parse(lastKaizenId.Substring(8));
                            int incrementedValue = numericPart + 1;
                            kaizenId = yearMonth + "_" + incrementedValue.ToString("D9");
                        }
                        else
                        {
                            // No existing Kaizen IDs, start from KZ0001
                            kaizenId = yearMonth + "_" + "000000001";
                        }

                    }
                    else
                    {
                        // No existing Kaizen IDs, start from KZ0001
                        kaizenId = yearMonth + "_" + "000000001";
                    }
                    dr.Dispose();
                    return kaizenId;
                }
                catch(Exception ex)
                {

                    Response.Write(ex.Message);
                    
                }
                finally
                {
                    
                    //connection.Close();
                }
                return kaizenId;
            }

        }

        private int getS_No(SqlConnection conn, SqlTransaction transaction)
        {
            Int32 s_no = 0;

            string selectQuery = "SELECT MAX(S_NO) FROM IE_USERS_KAIZEN_DETAILS";
            SqlCommand cmd = new SqlCommand(selectQuery, connection, transaction);
           
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();

            }
            string SERIALNO = dr.GetValue(0).ToString();

            if (SERIALNO == "")
            {
                s_no = 1;
            }
            else
            {
                s_no = Convert.ToInt32(SERIALNO);
                s_no = s_no + 1;
            }

            dr.Dispose();
            return s_no;
        }

        private void InsertKaizenDetails(string buttonclickvalue)
        {
            using (connection)
            {
               
                string beforeimageName = string.Empty;
                string beforefilePath = string.Empty;
                string beforegetPath = string.Empty;
                string beforepathToStore = string.Empty;

                string afterimageName = string.Empty;
                string afterfilePath = string.Empty;
                string aftergetPath = string.Empty;
                string afterpathToStore = string.Empty;

                connection.Open();
                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();
                    string kaizenId = GetKaizenId(connection, transaction);

                    int serialno = getS_No(connection, transaction);
                    //string s_no = serialno.ToString();

                    int ticketno = Convert.ToInt32((string)Session["username"]);


                    string txtTextTitleofkaizen = TextTitleofkaizen.Text;

                    string department = ddlPlantDepartment.SelectedItem.Text;
                    string discipline = ddlDiscipline.SelectedItem.Text;

                    string teamMember1Name;
                    if (txtteamMember1Name.Text != "")
                    {
                        teamMember1Name = txtteamMember1Name.Text;
                    }
                    else
                    {
                        teamMember1Name = "";
                    }

                    string teamMember1empid;
                    if (txtteamMember1empid.Text != "")
                    {
                        teamMember1empid = txtteamMember1empid.Text;
                    }
                    else
                    {
                        teamMember1empid = "";
                    }

                    string teamMember2Name;
                    if (txtteamMember2Name.Text != "")
                    {
                        teamMember2Name = txtteamMember2Name.Text;
                    }
                    else
                    {
                        teamMember2Name = "";
                    }

                    string teamMember2empid;
                    if (txtteamMember2empid.Text != "")
                    {
                        teamMember2empid = txtteamMember2empid.Text;
                    }
                    else
                    {
                        teamMember2empid = "";
                    }

                    string teamMember3Name;
                    if (txtteamMember3Name.Text != "")
                    {
                        teamMember3Name = txtteamMember3Name.Text;
                    }
                    else
                    {
                        teamMember3Name = "";
                    }

                    string teamMember3empid;
                    if (txtteamMember3empid.Text != "")
                    {
                        teamMember3empid = txtteamMember3empid.Text;
                    }
                    else
                    {
                        teamMember3empid = "";
                    }
                    int totalMembers = 1; // Include the person filling out the form

                    if (!string.IsNullOrEmpty(txtteamMember1Name.Text))
                    {
                        totalMembers++;
                    }
                    if (!string.IsNullOrEmpty(txtteamMember2Name.Text))
                    {
                        totalMembers++;
                    }
                    if (!string.IsNullOrEmpty(txtteamMember3Name.Text))
                    {
                        totalMembers++;
                    }


                    string ProblemDescription = txtProblemDescription.Text;
                    string RootCauses = txtRootCauses.Text;
                    string Solution = txtSolution.Text;
                    string Benefit = txtBenefit.Text;
                    string Implementationdate = Txtimplementationdate.Text;
                    //string EmployeeNo = TxtEmployeeNo.Text;
                    string MobileNumber = TxtMobileNumber.Text;
                    int Saving = Convert.ToInt32(txtSaving.Text);
                    int Implementationcost = Convert.ToInt32(TxtImplementationcost.Text);
                    string ipAddress = HttpContext.Current.Request.UserHostAddress;

                    string varProductivity;
                    if (Productivity.Checked)
                    {
                        varProductivity = "p";
                    }
                    else
                    {
                        varProductivity = "";
                    }

                    string varQuality;
                    if (Quality.Checked)
                    {
                        varQuality = "q";
                    }
                    else
                    {
                        varQuality = "";
                    }

                    string varCost;
                    if (Cost.Checked)
                    {
                        varCost = "c";
                    }
                    else
                    {
                        varCost = "";
                    }

                    string varSafety;
                    if (Safety.Checked)
                    {
                        varSafety = "s";
                    }
                    else
                    {
                        varSafety = "";
                    }

                    string varEnvironment;
                    if (Environment.Checked)
                    {
                        varEnvironment = "e";
                    }
                    else
                    {
                        varEnvironment = "";
                    }

                    string varMorale;
                    if (Morale.Checked)
                    {
                        varMorale = "m";
                    }
                    else
                    {
                        varMorale = "";
                    }
                  
                    if (buttonclickvalue == "saveasdraft")
                    {
                        

                        saveasdraft = buttonclickvalue.ToString();
                        DateTime saveasdraftdatefromsys = DateTime.Now;
                        saveasdraftdate = saveasdraftdatefromsys;

                        statusofkaizen = 0;


                        if (fileBeforeImplementationFileUpload1.HasFile)
                        {
                            string fileExtension = Path.GetExtension(fileBeforeImplementationFileUpload1.FileName).ToLower();
                            if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif")
                            {
                                if (fileBeforeImplementationFileUpload1.PostedFile.ContentLength <= 5 * 1024 * 1024) // 10MB limit
                                {
                                    beforeimageName = kaizenId + "_" + fileBeforeImplementationFileUpload1.FileName;
                                    //beforefilePath = Server.MapPath("/kaizenbeforeimgs/" + System.Guid.NewGuid() + beforeimageName);
                                    beforefilePath = Server.MapPath("/kaizenbeforeimgs/" + beforeimageName);
                                    fileBeforeImplementationFileUpload1.SaveAs(beforefilePath);

                                    int getPos = beforefilePath.LastIndexOf("\\");
                                    int len = beforefilePath.Length;
                                    beforegetPath = beforefilePath.Substring(getPos, len - getPos);
                                    beforepathToStore = beforegetPath.Remove(0, 1);
                                }
                                else
                                {
                                    // File size exceeds the limit
                                    // Display an error message or take appropriate action
                                    fileBeforeImplementationlabel.Text = "File size exceeds the limit of 10MB.";
                                    return;
                                }

                            }
                            else
                            {

                                // Invalid file extension
                                // Display an error message or take appropriate action
                                fileBeforeImplementationlabel.Text = "Please select a valid image file (JPG, JPEG, PNG, GIF).";
                                return;
                            }
                        }
                        else
                        {
                            // No file selected
                            // Display an error message or take appropriate action
                            fileBeforeImplementationlabel.Text = "Please select a file.";
                            finalmsglabel.Text = "Please select BeforeImplementation image.";
                            return;
                        }

                     if (fileAfterImplementationFileUpload1.HasFile)
                        {
                            string fileExtension = Path.GetExtension(fileAfterImplementationFileUpload1.FileName).ToLower();
                            if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif")
                            {
                                if (fileAfterImplementationFileUpload1.PostedFile.ContentLength <= 5 * 1024 * 1024) // 10MB limit
                                {
                                    afterimageName = kaizenId + "_" + fileAfterImplementationFileUpload1.FileName;
                                    //afterfilePath = Server.MapPath("/kaizenafterimgs/" + System.Guid.NewGuid() + afterimageName);
                                    afterfilePath = Server.MapPath("/kaizenafterimgs/" + afterimageName);
                                    fileAfterImplementationFileUpload1.SaveAs(afterfilePath);

                                    int getPos = afterfilePath.LastIndexOf("\\");
                                    int len = afterfilePath.Length;
                                    aftergetPath = afterfilePath.Substring(getPos, len - getPos);
                                    afterpathToStore = aftergetPath.Remove(0, 1);
                                }
                                else
                                {
                                    // File size exceeds the limit
                                    // Display an error message or take appropriate action
                                    fileAfterImplementationLabel1.Text = "File size exceeds the limit of 10MB.";
                                    return;
                                }

                            }
                            else
                            {
                                // Invalid file extension
                                // Display an error message or take appropriate action
                                fileAfterImplementationLabel1.Text = "Please select a valid image file (JPG, JPEG, PNG, GIF).";
                                return;

                            }

                        }
                        else
                        {
                         afterimageName = null;
                         afterpathToStore = null;
                        }
                    }

                    if (buttonclickvalue == "kaizensubmit")
                    {


                        statusofkaizen = 1;
                        DateTime Date_of_Kaizen_Submissionfromsys = DateTime.Now;
                        Date_of_Kaizen_Submission = Date_of_Kaizen_Submissionfromsys;

                        saveasdraft = null;
                        saveasdraftdate = null;


                        if (fileBeforeImplementationFileUpload1.HasFile)
                        {
                            string fileExtension = Path.GetExtension(fileBeforeImplementationFileUpload1.FileName).ToLower();
                            if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif")
                            {
                                if (fileBeforeImplementationFileUpload1.PostedFile.ContentLength <= 5 * 1024 * 1024) // 10MB limit
                                {
                                    beforeimageName = kaizenId + "_" + fileBeforeImplementationFileUpload1.FileName;
                                    //beforefilePath = Server.MapPath("/kaizenbeforeimgs/" + System.Guid.NewGuid() + beforeimageName);
                                    beforefilePath = Server.MapPath("/kaizenbeforeimgs/" + beforeimageName);
                                    fileBeforeImplementationFileUpload1.SaveAs(beforefilePath);

                                    int getPos = beforefilePath.LastIndexOf("\\");
                                    int len = beforefilePath.Length;
                                    beforegetPath = beforefilePath.Substring(getPos, len - getPos);
                                    beforepathToStore = beforegetPath.Remove(0, 1);
                                }
                                else
                                {
                                    // File size exceeds the limit
                                    // Display an error message or take appropriate action
                                    fileBeforeImplementationlabel.Text = "File size exceeds the limit of 10MB.";
                                    return;
                                }

                            }
                            else
                            {

                                // Invalid file extension
                                // Display an error message or take appropriate action
                                fileBeforeImplementationlabel.Text = "Please select a valid image file (JPG, JPEG, PNG, GIF).";
                                return;
                            }
                        }
                        else
                        {
                            // No file selected
                            // Display an error message or take appropriate action
                            fileBeforeImplementationlabel.Text = "Please select a file.";
                            return;
                        }

                        if (fileAfterImplementationFileUpload1.HasFile)
                        {
                            string fileExtension = Path.GetExtension(fileAfterImplementationFileUpload1.FileName).ToLower();
                            if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif")
                            {
                                if (fileAfterImplementationFileUpload1.PostedFile.ContentLength <= 5 * 1024 * 1024) // 10MB limit
                                {
                                    afterimageName = kaizenId + "_" + fileAfterImplementationFileUpload1.FileName;
                                    //afterfilePath = Server.MapPath("/kaizenafterimgs/" + System.Guid.NewGuid() + afterimageName);
                                    afterfilePath = Server.MapPath("/kaizenafterimgs/" + afterimageName);
                                    fileAfterImplementationFileUpload1.SaveAs(afterfilePath);

                                    int getPos = afterfilePath.LastIndexOf("\\");
                                    int len = afterfilePath.Length;
                                    aftergetPath = afterfilePath.Substring(getPos, len - getPos);
                                    afterpathToStore = aftergetPath.Remove(0, 1);
                                }
                                else
                                {
                                    // File size exceeds the limit
                                    // Display an error message or take appropriate action
                                    fileAfterImplementationLabel1.Text = "File size exceeds the limit of 10MB.";
                                    return;
                                }

                            }
                            else
                            {
                                // Invalid file extension
                                // Display an error message or take appropriate action
                                fileAfterImplementationLabel1.Text = "Please select a valid image file (JPG, JPEG, PNG, GIF).";
                                return;

                            }

                        }
                        else
                        {
                            // No file selected
                            // Display an error message or take appropriate action
                            fileAfterImplementationLabel1.Text = "Please select a file.";
                            return;
                        }
                    }


                    string queryuserinsert = "INSERT INTO IE_USERS_KAIZEN_DETAILS (S_no, Kaizen_ID, Ticket_no_kaizen_submitter, Kaizen_title, Plant_Department, Discipline, Description_of_problem, Root_Causes, Solution, Benefit, ImplementationDate, Productivity, Quality, Cost, Safety, Environment, Morale, Cost_of_Implemetation, Savings, Before_Implementation_img_details, Save_as_Draft, Save_as_Draft_date, After_Implementation_Img_Details, Date_of_Kaizen_Submission, Status_of_Kaizen, beforeimgpath, afterimgpath, ownerMobileNumber, ipoflasttransaction) VALUES (@SERIAL_number, @Kaizen_ID, @Ticket_no_kaizen_submitter, @Kaizen_title, @Plant_Department, @Discipline, @Description_of_problem, @Root_Causes, @Solution, @Benefit, @ImplementationDate, @Productivity, @Quality, @Cost, @Safety, @Environment, @Morale, @Cost_of_Implemetation, @saving, @Before_Implementation_img_details, @Save_as_Draft, @Save_as_Draft_date, @After_Implementation_Img_Details, @Date_of_Kaizen_Submission, @Status_of_Kaizen, @beforepathToStore, @afterpathToStore , @MobileNumber, @ip)";
                    SqlCommand cmd = new SqlCommand(queryuserinsert, connection, transaction);


                    cmd.Parameters.AddWithValue("SERIAL_number", serialno);
                    cmd.Parameters.AddWithValue("Kaizen_ID", kaizenId);
                    cmd.Parameters.AddWithValue("Ticket_no_kaizen_submitter", ticketno);
                    cmd.Parameters.AddWithValue("Kaizen_title", txtTextTitleofkaizen);

                    cmd.Parameters.AddWithValue("Plant_Department", department);
                    cmd.Parameters.AddWithValue("Discipline", discipline);
                    cmd.Parameters.AddWithValue("Description_of_problem", ProblemDescription);

                    cmd.Parameters.AddWithValue("Root_Causes", RootCauses);
                    cmd.Parameters.AddWithValue("Solution", Solution);
                    cmd.Parameters.AddWithValue("Benefit", Benefit);

                    cmd.Parameters.AddWithValue("ImplementationDate", Implementationdate);
                    cmd.Parameters.AddWithValue("Productivity", varProductivity);
                    cmd.Parameters.AddWithValue("Quality", varQuality);

                    cmd.Parameters.AddWithValue("Cost", varCost);
                    cmd.Parameters.AddWithValue("Safety", varSafety);
                    cmd.Parameters.AddWithValue("Environment", varEnvironment);

                    cmd.Parameters.AddWithValue("Morale", varMorale);
                    cmd.Parameters.AddWithValue("Cost_of_Implemetation", Implementationcost);
                    cmd.Parameters.AddWithValue("saving", Saving);
                    cmd.Parameters.AddWithValue("ip", ipAddress);
                    


                   
                 

                    if (buttonclickvalue == "saveasdraft")
                    {
                        if (fileBeforeImplementationFileUpload1.HasFile)
                        {

                            cmd.Parameters.AddWithValue("Before_Implementation_img_details", beforeimageName);
                            cmd.Parameters.AddWithValue("beforepathToStore", beforepathToStore);
                        }
                        else
                        {

                            cmd.Parameters.AddWithValue("Before_Implementation_img_details", "");
                            cmd.Parameters.AddWithValue("beforepathToStore", "");
                        }
                        if (fileAfterImplementationFileUpload1.HasFile)
                        {
                            cmd.Parameters.AddWithValue("After_Implementation_Img_Details", afterimageName);
                            cmd.Parameters.AddWithValue("afterpathToStore", afterpathToStore);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("After_Implementation_Img_Details", "");
                            cmd.Parameters.AddWithValue("afterpathToStore", "");
                        }

                      cmd.Parameters.AddWithValue("Save_as_Draft", saveasdraft);
                      cmd.Parameters.AddWithValue("Save_as_Draft_date", saveasdraftdate);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Save_as_Draft", "");
                        cmd.Parameters.AddWithValue("Save_as_Draft_date", saveasdraftdate.HasValue ? (object)saveasdraftdate.Value : DBNull.Value);
                    }


                    if (buttonclickvalue == "kaizensubmit")
                    {
                        if (fileBeforeImplementationFileUpload1.HasFile)
                        {

                            cmd.Parameters.AddWithValue("Before_Implementation_img_details", beforeimageName);
                            cmd.Parameters.AddWithValue("beforepathToStore", beforepathToStore);
                        }
                        else
                        {

                            cmd.Parameters.AddWithValue("Before_Implementation_img_details", "");
                            cmd.Parameters.AddWithValue("beforepathToStore", "");
                        }
                        if (fileAfterImplementationFileUpload1.HasFile)
                        {
                            cmd.Parameters.AddWithValue("After_Implementation_Img_Details", afterimageName);
                            cmd.Parameters.AddWithValue("afterpathToStore", afterpathToStore);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("After_Implementation_Img_Details", "");
                            cmd.Parameters.AddWithValue("afterpathToStore", "");
                        }

                        cmd.Parameters.AddWithValue("Date_of_Kaizen_Submission", Date_of_Kaizen_Submission);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Date_of_Kaizen_Submission", Date_of_Kaizen_Submission.HasValue ? (object)Date_of_Kaizen_Submission.Value : DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("Status_of_Kaizen", statusofkaizen);
                    cmd.Parameters.AddWithValue("MobileNumber", MobileNumber);

                    cmd.ExecuteNonQuery();
                    //adding members to members table

                    string insertQuery = "INSERT INTO IE_USERS_KAIZEN_MEMBERS_DETAILS (SrNo, Kaizen_ID, TeamMember1, TicketNo1, TeamMember2, TicketNo2, TeamMember3, TicketNo3, PlantDepartment, Discipline, TokenGiftNumber, totalmembers, statusofKaizen) VALUES (@SrNo, @KaizenID, @TeamMember1, @TicketNo1, @TeamMember2, @TicketNo2, @TeamMember3, @TicketNo3, @PlantDepartment, @Discipline, @TokenGiftNumber, @TotalMembers, @statusofka)";

                    SqlCommand command = new SqlCommand(insertQuery, connection, transaction);
                    command.Parameters.AddWithValue("SrNo", serialno);
                    command.Parameters.AddWithValue("KaizenID", kaizenId);
                    command.Parameters.AddWithValue("TeamMember1", teamMember1Name);
                    command.Parameters.AddWithValue("TicketNo1", teamMember1empid);
                    command.Parameters.AddWithValue("TeamMember2", teamMember2Name);
                    command.Parameters.AddWithValue("TicketNo2", teamMember2empid);
                    command.Parameters.AddWithValue("TeamMember3", teamMember3Name);
                    command.Parameters.AddWithValue("TicketNo3", teamMember3empid);
                    command.Parameters.AddWithValue("PlantDepartment", department);
                    command.Parameters.AddWithValue("Discipline", discipline);
                    command.Parameters.AddWithValue("TokenGiftNumber", "");
                    command.Parameters.AddWithValue("TotalMembers", totalMembers);
                    command.Parameters.AddWithValue("statusofka", statusofkaizen);

                    command.ExecuteNonQuery();

                    // Commit the transaction
                    if (transaction != null) { 
                    transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }

                    //cmd.Dispose();
                    Session["Kaizen_Id_1"] = kaizenId;
                    ClearControls();
                   // Response.Redirect("responsepage.aspx");
                    finalmsglabel.Text = "Kaizen details is saved.";
                    connection.Close();
                    Response.Redirect("responsepage.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                   // Response.Write(ex.Message);
                    if (transaction == null)
                      {
                          transaction.Rollback();
                      }
                    finalmsglabel.Text = "Errors in the field.";
                    finalmsglabel.ForeColor = Color.Red;
                    ClearControls();
                }
                finally
                {
                    connection.Close();

                    beforeimageName = null;
                    beforefilePath = null;
                    beforegetPath = null;
                    beforepathToStore = null;

                    afterimageName = null;
                    afterfilePath = null;
                    aftergetPath = null;
                    afterpathToStore = null;
                    ClearControls();
                }

            }
        }

        private void ClearControls()
        {
            TextTitleofkaizen.Text = string.Empty;
            ddlPlantDepartment.SelectedIndex = 0;
            ddlDiscipline.SelectedIndex = 0;
            txtteamMember1Name.Text = string.Empty;
            txtteamMember1empid.Text = string.Empty;
            txtteamMember2Name.Text = string.Empty;
            txtteamMember2empid.Text = string.Empty;
            txtteamMember3Name.Text = string.Empty;
            txtteamMember3empid.Text = string.Empty;
            txtProblemDescription.Text = string.Empty;
            txtRootCauses.Text = string.Empty;
            txtSolution.Text = string.Empty;
            txtBenefit.Text = string.Empty;
            Txtimplementationdate.Text = string.Empty;
            //string EmployeeNo = TxtEmployeeNo.Text;
            TxtMobileNumber.Text = string.Empty;
            txtSaving.Text = string.Empty;
            TxtImplementationcost.Text = string.Empty;
            Productivity.Checked = false;
            Quality.Checked = false;
            Cost.Checked = false;
            Safety.Checked = false;
            Morale.Checked = false;
            Environment.Checked = false;
            fileBeforeImplementationFileUpload1.Dispose();
            fileAfterImplementationFileUpload1.Dispose();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (TextTitleofkaizen.Text == string.Empty)
            {
                Titleofkaizen_label.Text = "Please enter Title of Kaizen as it is mandatory field.";
            }
            if (txtProblemDescription.Text == string.Empty)
            {
                txtProblemDescriptionLabel1.Text = "Please enter description";
            }
            if (txtRootCauses.Text == string.Empty)
            {
                txtRootCausesLabel1.Text = "Please enter root casuse";
            }
            if (string.IsNullOrEmpty(ddlPlantDepartment.SelectedItem.Value))
            {
                Plant_Department_label.Text = "Please select your Plant/Department";
            }
            if (string.IsNullOrEmpty(ddlDiscipline.SelectedItem.Value))
            {
                Discipline_label.Text = "Please select your Discipline";
            }
            if (txtteamMember1Name.Text != string.Empty && txtteamMember1empid.Text == string.Empty)
            {
                teamMember1empidLabel2.Text = "Employee ID is required";
            }
            if (txtteamMember2Name.Text != string.Empty && txtteamMember2empid.Text == string.Empty)
            {
                teamMember2empidLabel2.Text = "Employee ID is required";
            }
            if (txtteamMember3Name.Text != string.Empty && txtteamMember3empid.Text == string.Empty)
            {
                teamMember3empidLabel2.Text = "Employee ID is required";
            }
            if (txtSolution.Text == string.Empty)
            {
                txtSolutionLabel1.Text = "Please enter solution";
            }
            if (txtBenefit.Text == string.Empty)
            {
                txtBenefitLabel2.Text = "Please enter benefits";
            }
            if (TxtMobileNumber.Text == string.Empty)
            {
                TxtMobileNumberLabel2.Text = "Please enter kaizen owner mobile number";
            }
            if (!Productivity.Checked && !Quality.Checked && !Cost.Checked && !Safety.Checked && !Environment.Checked && !Morale.Checked)
            {
                kaizencategoryLabel1.Text = "Please check atleast one checkbox";
            }
            if (txtSaving.Text == string.Empty)
            {
                SavingLabel1.Text = "Please enter savings details";
            }
            if (TxtImplementationcost.Text == string.Empty)
            {
                ImplementationcostLabel1.Text = "Please enter implementation cost details";
            }
            if (Txtimplementationdate.Text == string.Empty)
            {
                TxtimplementationdateLabel1.Text = "Please enter implementation date";
            }
            if (!fileBeforeImplementationFileUpload1.HasFile)
            {
                fileBeforeImplementationlabel.Text = "Please enter before implementation image";
            }


            if (string.IsNullOrEmpty(TextTitleofkaizen.Text) || string.IsNullOrEmpty(txtProblemDescription.Text) || string.IsNullOrEmpty(txtRootCauses.Text) || string.IsNullOrEmpty(Txtimplementationdate.Text)
                || string.IsNullOrEmpty(ddlPlantDepartment.SelectedItem.Value) || string.IsNullOrEmpty(ddlDiscipline.SelectedItem.Value) || string.IsNullOrEmpty(txtRootCauses.Text)
                || string.IsNullOrEmpty(txtSolution.Text) || string.IsNullOrEmpty(txtBenefit.Text) || string.IsNullOrEmpty(TxtMobileNumber.Text) || string.IsNullOrEmpty(txtSaving.Text)
                || (!Productivity.Checked && !Quality.Checked && !Cost.Checked && !Safety.Checked && !Environment.Checked && !Morale.Checked) || string.IsNullOrEmpty(TxtImplementationcost.Text)
                || (!fileBeforeImplementationFileUpload1.HasFile)
                )
            {
                finalmsglabel.Text = "Please fill in all details before submitting kaizen";
            }
            else
            {
                InsertKaizenDetails("saveasdraft");

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (TextTitleofkaizen.Text == string.Empty)
            {
                Titleofkaizen_label.Text = "Please enter Title of Kaizen as it is mandatory field.";
            }
            if (txtProblemDescription.Text == string.Empty)
            {
                txtProblemDescriptionLabel1.Text = "Please enter description";
            }
            if (txtRootCauses.Text == string.Empty)
            {
                txtRootCausesLabel1.Text = "Please enter root casuse";
            }
            if (string.IsNullOrEmpty(ddlPlantDepartment.SelectedItem.Value))
            {
                Plant_Department_label.Text = "Please select your Plant/Department";
            }
            if (string.IsNullOrEmpty(ddlDiscipline.SelectedItem.Value))
            {
                Discipline_label.Text = "Please select your Discipline";
            }
            if (txtteamMember1Name.Text != string.Empty && txtteamMember1empid.Text == string.Empty)
            {
                teamMember1empidLabel2.Text = "Employee ID is required";
            }
            if (txtteamMember2Name.Text != string.Empty && txtteamMember2empid.Text == string.Empty)
            {
                teamMember2empidLabel2.Text = "Employee ID is required";
            }
            if (txtteamMember3Name.Text != string.Empty && txtteamMember3empid.Text == string.Empty)
            {
                teamMember3empidLabel2.Text = "Employee ID is required";
            }
            if (txtSolution.Text == string.Empty)
            {
                txtSolutionLabel1.Text = "Please enter solution";
            }
            if (txtBenefit.Text == string.Empty)
            {
                txtBenefitLabel2.Text = "Please enter benefits";
            }
            if (TxtMobileNumber.Text == string.Empty)
            {
                TxtMobileNumberLabel2.Text = "Please enter kaizen owner mobile number";
            }
            if (!Productivity.Checked && !Quality.Checked && !Cost.Checked && !Safety.Checked && !Environment.Checked && !Morale.Checked)
            {
                kaizencategoryLabel1.Text = "Please check atleast one checkbox";
            }
            if (txtSaving.Text == string.Empty)
            {
                SavingLabel1.Text = "Please enter savings details";
            }
            if (TxtImplementationcost.Text == string.Empty)
            {
                ImplementationcostLabel1.Text = "Please enter implementation cost details";
            }
            if (Txtimplementationdate.Text == string.Empty)
            {
                TxtimplementationdateLabel1.Text = "Please enter implementation date";
            }
            if (!fileBeforeImplementationFileUpload1.HasFile)
            {
                fileBeforeImplementationlabel.Text = "Please enter before image";
            }
            if (!fileAfterImplementationFileUpload1.HasFile)
            {
                fileAfterImplementationLabel1.Text = "Please enter after image";
            }


            if (string.IsNullOrEmpty(TextTitleofkaizen.Text) || string.IsNullOrEmpty(txtProblemDescription.Text) || string.IsNullOrEmpty(txtRootCauses.Text) || string.IsNullOrEmpty(Txtimplementationdate.Text)
                || string.IsNullOrEmpty(ddlPlantDepartment.SelectedItem.Value) || string.IsNullOrEmpty(ddlDiscipline.SelectedItem.Value) || string.IsNullOrEmpty(txtRootCauses.Text)
                || string.IsNullOrEmpty(txtSolution.Text) || string.IsNullOrEmpty(txtBenefit.Text) || string.IsNullOrEmpty(TxtMobileNumber.Text) || string.IsNullOrEmpty(txtSaving.Text)
                || (!Productivity.Checked && !Quality.Checked && !Cost.Checked && !Safety.Checked && !Environment.Checked && !Morale.Checked) || string.IsNullOrEmpty(TxtImplementationcost.Text)
                || (!fileBeforeImplementationFileUpload1.HasFile) || (!fileAfterImplementationFileUpload1.HasFile)
                )
            {
                finalmsglabel.Text = "Please fill in all details before submitting kaizen";
            }
            else
            {
                InsertKaizenDetails("kaizensubmit");

            }
        }
    }
}
