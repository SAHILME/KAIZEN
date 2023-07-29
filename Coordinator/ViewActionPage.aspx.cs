using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;

namespace Industrial_Engineering.IE_Kaizen.Coordinator
{
    public partial class View_Action_Page : System.Web.UI.Page
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            String username = (string)(Session["username"]);
            string Kz_ID = (string)Session["Kaizen_ID"];
            //String role = (string)(Session["role"]); String.IsNullOrEmpty(role) should not be empty and = coordinator
           // if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(Kz_ID))
            {
            //    HttpContext.Current.Response.Redirect("~/IE_Central_Login.aspx");
            }
           
            if (!IsPostBack)
            {
                FillCoordinatorAction();
                //FillDepartment();
                //FillDiscipline();
                FillDepartmentddlco();
                FillDisciplineddlco();
                // Fetch the record from the database based on the ID
                GetDataFromDatabaseAndDisplay(Kz_ID);

            }

            TextkaizenID_label.Text = string.Empty;
            Plant_Department_labelco.Text = string.Empty;
            Discipline_labelco.Text = string.Empty;
            TxtregistrationdateLabel1.Text = string.Empty;
            TextEmailLabel4.Text = string.Empty;
            forwared_reject_label.Text = string.Empty;
            TextRemarksLabel2.Text = string.Empty;

        }

        private void GetDataFromDatabaseAndDisplay(string KID)
        {

            try
            {
                string selectQueryformembers = "SELECT * FROM IE_USERS_KAIZEN_MEMBERS_DETAILS WHERE Kaizen_ID = @KaizenId";
                SqlCommand cmd = new SqlCommand(selectQueryformembers, connection);
                cmd.Parameters.AddWithValue("KaizenId", KID);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    txtteamMember1Name.Text = dr["TeamMember1"].ToString();
                    txtteamMember2Name.Text = dr["TeamMember2"].ToString();
                    txtteamMember3Name.Text = dr["TeamMember3"].ToString();

                    if (0 != Convert.ToInt32(dr["TicketNo1"]))
                    {
                        txtteamMember1empid.Text = dr["TicketNo1"].ToString();
                    }
                    else
                    {
                        txtteamMember1empid.Text = "";
                    }
                    if (0 != Convert.ToInt32(dr["TicketNo2"]))
                    {
                        txtteamMember2empid.Text = dr["TicketNo2"].ToString();
                    }
                    else
                    {
                        txtteamMember2empid.Text = "";
                    }
                    if (0 != Convert.ToInt32(dr["TicketNo3"]))
                    {
                        txtteamMember3empid.Text = dr["TicketNo3"].ToString();
                    }
                    else
                    {
                        txtteamMember3empid.Text = "";
                    }

                }


                dr.Dispose();

                string selectQuery = "SELECT * FROM IE_USERS_KAIZEN_DETAILS WHERE Kaizen_ID = @id";
                SqlCommand cmd2 = new SqlCommand(selectQuery, connection);
                cmd2.Parameters.AddWithValue("id", KID);

                SqlDataReader dr2 = cmd2.ExecuteReader();

                if (dr2.HasRows)
                {
                    dr2.Read();


                    TextTitleofkaizen.Text = dr2["Kaizen_title"].ToString();
                    txtProblemDescription.Text = dr2["Description_of_problem"].ToString();
                    txtRootCauses.Text = dr2["Root_Causes"].ToString();
                    txtSolution.Text = dr2["Solution"].ToString();
                    txtBenefit.Text = dr2["Benefit"].ToString();
                    Txtimplementationdate.Text = dr2["ImplementationDate"].ToString();

                    TxtEmployeeNo.Text = dr2["Ticket_no_kaizen_submitter"].ToString();
                    TxtMobileNumber.Text = dr2["ownerMobileNumber"].ToString();
                    txtSaving.Text = dr2["Savings"].ToString();
                    TxtImplementationcost.Text = dr2["Cost_of_Implemetation"].ToString();
                    ddlPlantDepartment.SelectedItem.Text = dr2["Plant_Department"].ToString();
                    ddlDiscipline.SelectedItem.Text = dr2["Discipline"].ToString();

                    string Productivitycheck = dr2["Productivity"].ToString();
                    string Qualitycheck = dr2["Quality"].ToString();
                    string Costcheck = dr2["Cost"].ToString();
                    string Safetycheck = dr2["Safety"].ToString();
                    string Environmentcheck = dr2["Environment"].ToString();
                    string Moralecheck = dr2["Morale"].ToString();

                    if ("p" == Productivitycheck)
                    {
                        Productivity.Checked = true;
                    }
                    if ("q" == (Qualitycheck))
                    {
                        Quality.Checked = true;
                    }
                    if ("c" == (Costcheck))
                    {
                        Cost.Checked = true;
                    }
                    if ("s" == (Safetycheck))
                    {
                        Safety.Checked = true;
                    }
                    if ("e" == (Environmentcheck))
                    {
                        Environment.Checked = true;
                    }
                    if ("m" == (Moralecheck))
                    {
                        Morale.Checked = true;
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(dr2["beforeimgpath"])))
                    {
                        Image1.ImageUrl = "~/kaizenbeforeimgs/" + Convert.ToString(dr2["beforeimgpath"]);
                        BeforeImplementationlabelLabel1.Text = Convert.ToString(dr2["Before_Implementation_img_details"]);
                    }
                    else
                    {
                        BeforeImplementationlabelLabel1.Text = "No Image Uploaded";
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(dr2["afterimgpath"])))
                    {
                        Image2.ImageUrl = "~/kaizenafterimgs/" + Convert.ToString(dr2["afterimgpath"]);
                        AfterImplementationLabel1.Text = Convert.ToString(dr2["After_Implementation_Img_Details"]);
                    }
                    else
                    {
                        AfterImplementationLabel1.Text = "No Image Uploaded";
                    }
                    finalmsglabel.Text = "Your Kaizen record retrieved successfully";
                    finalmsglabel.ForeColor = Color.Green;

                    //polpulating  view and action div details

                    TextkaizenID.Text = (string)Session["Kaizen_ID"];
                    ddlPlantDepartmentco.SelectedItem.Text = dr2["Plant_Department"].ToString();
                    ddlDisciplineco.SelectedItem.Text = dr2["Discipline"].ToString();

                    //polpulated
                }
                string dept = dr2["Plant_Department"].ToString();
                string discipline = dr2["Discipline"].ToString();
                

                dr2.Dispose();

                string getevaluatorQuery = "SELECT * FROM IE_DEPT_DISCI_OM_EV_DETAILS WHERE Plant_Department = @dept AND Discipline = @disci";
                SqlCommand cmd3 = new SqlCommand(getevaluatorQuery, connection);
                cmd3.Parameters.AddWithValue("dept", dept);
                cmd3.Parameters.AddWithValue("disci", discipline);
                

                SqlDataReader dr3 = cmd3.ExecuteReader();
                if (dr3.HasRows)
                {
                    dr3.Read();
                    TextEvaluator.Text = dr3["EV_Email"].ToString();

                }
                dr3.Dispose();

                connection.Close();

            }
            catch (Exception ex)
            {
                pageleveLabel1.Text = "Error Occur!";
                pageleveLabel1.ForeColor = Color.Red;

            }
            finally
            {
                connection.Close();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextkaizenID.Text))
            {
                TextkaizenID_label.Text = "KaizenId cannot be blank";
            }
            if (string.IsNullOrEmpty(TextEmail.Text))
            {
                TextEmailLabel4.Text = "Please enter email address of kaizen owner ";
            }
            if (string.IsNullOrEmpty(TextRemarks.Text))
            {
                TextRemarksLabel2.Text = "Please enter remark of kaizen ";
            }
            if (string.IsNullOrEmpty(ddlPlantDepartmentco.SelectedItem.Value))
            {
                Plant_Department_labelco.Text = "Please select value in plant/department dropdown";
            }
            if (string.IsNullOrEmpty(ddlDisciplineco.SelectedItem.Value))
            {
                Discipline_labelco.Text = "Please select value in discipline dropdown";
            }
            if (string.IsNullOrEmpty(ddlforwared_reject.SelectedItem.Value))
            {
                forwared_reject_label.Text = "Please select value in action dropdown";
            }
            if ("Forward to Evaluator" == ddlforwared_reject.SelectedItem.Value.ToString() && string.IsNullOrEmpty(Txtregistrationdate.Text))
            {
                TxtregistrationdateLabel1.Text = "Please select value in Registration date dropdown";
            }

            if (string.IsNullOrEmpty(TextkaizenID.Text) || string.IsNullOrEmpty(ddlforwared_reject.SelectedItem.Value)
                || string.IsNullOrEmpty(ddlPlantDepartmentco.SelectedItem.Value) || string.IsNullOrEmpty(ddlDisciplineco.SelectedItem.Value)
                || string.IsNullOrEmpty(TextEmail.Text) || string.IsNullOrEmpty(TextRemarks.Text) || ("Forward to Evaluator" == ddlforwared_reject.SelectedItem.Value.ToString() && string.IsNullOrEmpty(Txtregistrationdate.Text))
                )
            {
                btnSubmitlabel.Text = "Please fill the above fields.";
                    btnSubmitlabel.ForeColor= Color.Red;
                return;
            }else{
                PopulateCoordinatorTable();
            }
            
        }

        protected void ddlforwared_reject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlforwared_reject.SelectedValue == "Rejected")
            {
                Txtregistrationdate.ReadOnly = true;
                // Or use the following line to hide the textbox
                // Txtregistrationdate.Visible = false;
            }
            else
            {
                Txtregistrationdate.ReadOnly = false;
                // Or use the following line to make the textbox visible
                // Txtregistrationdate.Visible = true;
            }
        }

        private void PopulateCoordinatorTable()
        {
            using (connection)
            {
                connection.Open();
                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();


                    string Kaizen_ID = (string)Session["Kaizen_ID"];
                    string department = ddlPlantDepartmentco.SelectedItem.Text;
                    string discipline = ddlDisciplineco.SelectedItem.Text;
                    
                    string emailofowner = TextEmail.Text;
                    string emailofevaluator = TextEvaluator.Text;
                    string remarks = TextRemarks.Text;
                    string co_action = ddlforwared_reject.SelectedItem.Text;

                    DateTime? rejectedByCODateValue = null;
                    if ("Rejected" == co_action)
                    {
                        rejectedByCODateValue = DateTime.Now;
                    }

                    DateTime? registrationdate = null; 
                    if (Txtregistrationdate.Text == "")
                    {
                        registrationdate = null;
                    }
                    else
                    {
                        registrationdate = DateTime.Parse(Txtregistrationdate.Text);
                    }

                    int kaizenstatusupdate = 1;
                    if ("Rejected" == co_action)
                    {
                        kaizenstatusupdate = -1;
                    }
                    else if ("Forward to Evaluator" == co_action)
                    {
                        kaizenstatusupdate = 2;
                    }

                    DateTime? presentationDate = null;
                    if (-1 == kaizenstatusupdate)
                    {
                        presentationDate = null;
                    }
                    else if (2 == kaizenstatusupdate)
                    {
                        presentationDate = null;
                    }

                    DateTime? closingDate = null;
                    if (-1 == kaizenstatusupdate)
                    {
                        closingDate = null;
                    }
                    else if (2 == kaizenstatusupdate)
                    {
                        closingDate = null;
                    }

                   // string employeeIDofCOValue = (string)(Session["username"]);
                    string employeeIDofCOValue = "175129";
                      
                    string emailSentFlagValue = isemailsent("itadmin@rcfltd.com", emailofowner, kaizenstatusupdate, Kaizen_ID);

                    string emailSentToEvaluatorFlagValue = isemailsenttoEvaluator("itadmin@rcfltd.com", emailofevaluator, kaizenstatusupdate, Kaizen_ID);

                    
                    string ipAddress = HttpContext.Current.Request.UserHostAddress;

                    string insertQuery = "INSERT INTO IE_COORDINATOR_ACTIONS_DETAILS (Kaizen_ID, CoordinatorAction, ForwardedtoEvaluatorDate, RejectedbyCODate, PresentationDate, ClosingDate, CO_remark, COsendemailto, Emailsentflag, employeeidofCO, ipoflasttransaction, Emailofevaluator, EmailtoEvaluatorFlag) " +
                     "VALUES (@Kaizen_ID, @CoordinatorAction, @ForwardedtoEvaluatorDate, @RejectedbyCODate, @PresentationDate, @ClosingDate, @CO_remark, @COsendemailto, @Emailsentflag, @employeeidofCO, @ipoflasttransaction, @Emailofev, @EmailtoEvFlag)";

                    SqlCommand command = new SqlCommand(insertQuery, connection, transaction);

                    // Set the parameter values
                    
                    command.Parameters.AddWithValue("@Kaizen_ID", Kaizen_ID);
                    command.Parameters.AddWithValue("@CoordinatorAction", co_action);

                    if (-1 == kaizenstatusupdate)
                    {
                        //if co fill the regsitration date while rejecting also, we are storing it in db.
                        if (Txtregistrationdate.Text == "") {
                            command.Parameters.AddWithValue("@ForwardedtoEvaluatorDate", registrationdate.HasValue ? (object)registrationdate.Value : DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ForwardedtoEvaluatorDate", registrationdate);
                        }

                        command.Parameters.AddWithValue("@RejectedbyCODate", rejectedByCODateValue);
                    }
                    else if (2 == kaizenstatusupdate)
                    {
                        command.Parameters.AddWithValue("@ForwardedtoEvaluatorDate", registrationdate);

                        command.Parameters.AddWithValue("@RejectedbyCODate", rejectedByCODateValue.HasValue ? (object)registrationdate.Value : DBNull.Value);
                    }

                    if (-1 == kaizenstatusupdate)
                    {
                        command.Parameters.AddWithValue("@PresentationDate", presentationDate.HasValue ? (object)registrationdate.Value : DBNull.Value);
                    }
                    else if(2 == kaizenstatusupdate)
                    {
                        command.Parameters.AddWithValue("@PresentationDate", presentationDate.HasValue ? (object)registrationdate.Value : DBNull.Value);
                    }

                    if (-1 == kaizenstatusupdate)
                    {
                        command.Parameters.AddWithValue("@ClosingDate", closingDate.HasValue ? (object)registrationdate.Value : DBNull.Value);
                    }
                    else if(2 == kaizenstatusupdate)
                    {
                        command.Parameters.AddWithValue("@ClosingDate", closingDate.HasValue ? (object)registrationdate.Value : DBNull.Value);
                    }


                    command.Parameters.AddWithValue("@CO_remark", remarks);
                    command.Parameters.AddWithValue("@COsendemailto", emailofowner);
                    command.Parameters.AddWithValue("@Emailsentflag", emailSentFlagValue);
                    command.Parameters.AddWithValue("@employeeidofCO", employeeIDofCOValue);
                    command.Parameters.AddWithValue("@ipoflasttransaction", ipAddress);
                    command.Parameters.AddWithValue("@Emailofev", emailofevaluator);
                    command.Parameters.AddWithValue("@EmailtoEvFlag", emailSentToEvaluatorFlagValue);
                   
                    command.ExecuteNonQuery();

                    // update status, plant/dept, discipline in IE_USERS_KAIZEN_DETAILS table
                    string updatequery = "UPDATE IE_USERS_KAIZEN_DETAILS " +
                    "SET Plant_Department = @Plant_Department, " +
                    "Discipline = @Discipline, " +

                    "Status_of_Kaizen = @Status_of_Kaizen " +

                    "WHERE Kaizen_ID = @kaiID";


                    SqlCommand cmd = new SqlCommand(updatequery, connection, transaction);


                    //cmd.Parameters.AddWithValue("SERIAL_number", serialno);
                    cmd.Parameters.AddWithValue("@kaiID", Kaizen_ID);
                    cmd.Parameters.AddWithValue("Status_of_Kaizen", kaizenstatusupdate);
                    cmd.Parameters.AddWithValue("Plant_Department", department);
                    cmd.Parameters.AddWithValue("Discipline", discipline);

                    cmd.ExecuteNonQuery();

                    // update status, in IE_USERS_KAIZEN_MEMBERS_DETAILS table
                    string updateMembersTablequery = "UPDATE IE_USERS_KAIZEN_MEMBERS_DETAILS " +
                    "SET PlantDepartment = @Plant_Department, " +
                    "Discipline = @Discipline, " +
                    "statusofKaizen = @Status_of_Kaizen " +
                    "WHERE Kaizen_ID = @kaiID";
                    
                    SqlCommand cmd2 = new SqlCommand(updateMembersTablequery, connection, transaction);


                    //cmd.Parameters.AddWithValue("SERIAL_number", serialno);
                    cmd2.Parameters.AddWithValue("@kaiID", Kaizen_ID);
                    cmd2.Parameters.AddWithValue("Status_of_Kaizen", kaizenstatusupdate);
                    cmd2.Parameters.AddWithValue("Plant_Department", department);
                    cmd2.Parameters.AddWithValue("Discipline", discipline);
                    

                    cmd2.ExecuteNonQuery();

                    if (transaction != null)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                    btnSubmitlabel.Text = "Kaizen has been "+co_action+".";
                    btnSubmitlabel.ForeColor = Color.Green;
                    connection.Close();
                    ClearControls();
                    Session.Remove("Kaizen_ID");
                }
                catch(Exception ex)
                {
                    if (transaction == null)
                    {
                        transaction.Rollback();
                    }
                    btnSubmitlabel.Text = "Errors in the field.";
                    finalmsglabel.ForeColor = Color.Red;

                }
                finally
                {
                    connection.Close();
                    ClearControls();

                }
            }
        }

        private void ClearControls()
        {
            TextEmail.Text = string.Empty;
            ddlPlantDepartmentco.SelectedIndex = 0;
            ddlDisciplineco.SelectedIndex = 0;
            ddlforwared_reject.SelectedIndex = 0;
            TextRemarks.Text = string.Empty;
            Txtregistrationdate.Text = string.Empty;
            btnSubmitlabel.Text = string.Empty;
        }
        /*Function for Email*/
        public string isemailsent(String FROMID, String TOID, int Status, String ID)
        {
            String EmailBody = "Dear User, <br/><br/> The status of Kaizen Id  " + ID + " is updated. <br/>Current status is " + Status + ".</br>This is system generated mail.<br/>Please do not reply.<br/><br/>Regards,<br/>RCF LTD";
            string returnvariable = "Not Sent";
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(FROMID);
                msg.To.Add(TOID);
                msg.Body = EmailBody;

                //msg.Bcc.Add("jkoshal@rcfltd.com");

                //Response.Write(msg.Body);
                msg.IsBodyHtml = true;
                msg.Subject = "Kaizen ID " + ID  + " status update";
                SmtpClient smt = new SmtpClient("172.14.2.34");
                smt.Port = 25;
                //smt.Credentials = new NetworkCredential("itadmin@rcfltd.com", "asdfgh@123");
                //smt.EnableSsl = true;

                //Production Setting
                smt.Send(msg);
                returnvariable = "Sent";
            }
            catch (Exception ex)
            {
                returnvariable = "Not Sent";
                Response.Write("Email Async Error!" + ex.Message);
            }
            finally
            {

            }
            return returnvariable;
        }

        public string isemailsenttoEvaluator(String FROMID, String TOID, int Status, String ID)
        {
            String EmailBody = "Dear User, <br/><br/> The status of Kaizen Id  " + ID + " is updated. <br/>Current status is " + Status + " Please evaluate it asap.</br>This is system generated mail.<br/>Please do not reply.<br/><br/>Regards,<br/>RCF LTD";
            string returnvariable = "Not Sent";
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(FROMID);
                msg.To.Add(TOID);
                msg.Body = EmailBody;

                //msg.Bcc.Add("jkoshal@rcfltd.com");

                //Response.Write(msg.Body);
                msg.IsBodyHtml = true;
                msg.Subject = "Kaizen ID " + ID + " status update";
                SmtpClient smt = new SmtpClient("172.14.2.34");
                smt.Port = 25;
                //smt.Credentials = new NetworkCredential("itadmin@rcfltd.com", "asdfgh@123");
                //smt.EnableSsl = true;

                //Production Setting
                smt.Send(msg);
                returnvariable = "Sent";
            }
            catch (Exception ex)
            {
                returnvariable = "Not Sent";
                Response.Write("Email Async Error!" + ex.Message);
            }
            finally
            {

            }
            return returnvariable;
        }
        /*End of Function for Email*/



        private void FillCoordinatorAction()
        {
            string actionListQuery = "select CoordinatorAction from IE_COORDINATOR_ACTION_EVENT";
            SqlCommand cmd = new SqlCommand(actionListQuery, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ddlforwared_reject.DataSource = dr;
            ddlforwared_reject.DataTextField = "CoordinatorAction";
            ddlforwared_reject.DataValueField = "CoordinatorAction";
            ddlforwared_reject.DataBind();
            //dr.Close();
            dr.Dispose();
            connection.Close();
            ddlforwared_reject.Items.Insert(0, new ListItem("---Select One---", "---Select One---")); //updated code

        }

        /*private void FillDiscipline()
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
           

        }*/

        private void FillDisciplineddlco()
        {

            string disciplineListQuery = "select DISCIPLINE from IE_KAIZEN_PLANT_DISCIPLINE_CREDS";
            SqlCommand cmd = new SqlCommand(disciplineListQuery, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //co dropdown
            ddlDisciplineco.DataSource = dr;
            ddlDisciplineco.DataTextField = "DISCIPLINE";
            ddlDisciplineco.DataValueField = "DISCIPLINE";
            ddlDisciplineco.DataBind();
            //dr.Close();
            dr.Dispose();
            connection.Close();
         
            ddlDisciplineco.Items.Insert(0, new ListItem("---Select One---", "---Select One---")); //updated code

        }

       /* private void FillDepartment()
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
          
        }*/

        private void FillDepartmentddlco()
        {

            string departmentListQuery = "select Department from IE_KAIZEN_PLANT_DEPARTMENT_CREDS";
            SqlCommand cmd = new SqlCommand(departmentListQuery, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //co dropdown
            ddlPlantDepartmentco.DataSource = dr;
            ddlPlantDepartmentco.DataTextField = "DEPARTMENT";
            ddlPlantDepartmentco.DataValueField = "DEPARTMENT";
            ddlPlantDepartmentco.DataBind();
            //dr.Close();
            dr.Dispose();
            connection.Close();
            
            ddlPlantDepartmentco.Items.Insert(0, new ListItem("---Select One---", "---Select One---")); //updated code
        }
    }
}