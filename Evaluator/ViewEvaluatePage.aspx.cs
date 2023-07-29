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

namespace Industrial_Engineering.IE_Kaizen.Evaluator
{
    public partial class ViewEvaluatePage : System.Web.UI.Page
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            //String username = (string)(Session["username"]);
            string Kz_ID = (string)Session["Kaizen_ID"];
            kazienidlabel.Text = (string)Session["Kaizen_ID"];
            String role = (string)(Session["role"]); //String.IsNullOrEmpty(role) should be empty

            if (String.IsNullOrEmpty(Kz_ID) || !String.IsNullOrEmpty(role))
            {
                HttpContext.Current.Response.Redirect("~/IE_Central_Logout.aspx");
            }

            // Fetch the record from the database based on the ID
            if (!IsPostBack) { 
            GetDataFromDatabaseAndDisplay(Kz_ID);
            ClearControls();
            pageleveLabel1.Text = string.Empty;
            }
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
                }


                dr2.Dispose();
                connection.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
            finally
            {
                connection.Close();
            }


        }

        private int getS_No(SqlConnection conn)
        {
            Int32 s_no = 0;

            string selectQuery = "SELECT MAX(SrNo) FROM IE_EVALUATOR_ACTIONS_DETAILS";
            SqlCommand cmd = new SqlCommand(selectQuery, connection);

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

        protected void insertfunction()
        {

            using (connection)
            {

                connection.Open();
                try
                {
                    DateTime? Accepteddate = null;
                    DateTime? rejecteddate = null;
                    DateTime? Dcategorydate = null;

                    string evaluatorAction = string.Empty;

                    if (ACCEPTEDCheckBox.Checked)
                    {
                        evaluatorAction = "Accepted";
                        Accepteddate = DateTime.Now;
                    }
                    if (REJECTEDCheckBox.Checked)
                    {
                        evaluatorAction = "rejected";
                        rejecteddate = DateTime.Now;
                    }
                    if (ACCEPTEDhoweverCheckBox.Checked)
                    {
                        evaluatorAction = "D category";
                        Dcategorydate = DateTime.Now;
                    }
                    
                    string evaluatorComment = string.Empty;

                    evaluatorComment = txtEvaluatorComments.Text;

                    string Productivityvar = string.Empty;
                    string Qualityvar = string.Empty;
                    string CostReductionvar = string.Empty;
                    string Deliveryvar = string.Empty;
                    string Safetyvar = string.Empty;
                    string Moralevar = string.Empty;
                    string InnovativeIdeavar = string.Empty; 

                    if (ProductivityCheckBox1.Checked)
                    {
                        Productivityvar = "p";
                    }
                    if (QualityCheckBox1.Checked)
                    {
                        Qualityvar = "q";
                    }
                    if (CostReductionCheckBox2.Checked)
                    {
                        CostReductionvar = "c";
                    }
                    if (DeliveryCheckBox3.Checked)
                    {
                        Deliveryvar = "d";
                    }
                    if (SafetyCheckBox4.Checked)
                    {
                        Safetyvar = "s";
                    }
                    if (MoraleCheckBox5.Checked)
                    {
                        Moralevar = "m";
                    }
                    else if (InnovativeIdeaCheckBox1.Checked)
                    {
                        InnovativeIdeavar = "i";
                    }


                    decimal savingByImplementation = 0;
                    savingByImplementation = Convert.ToDecimal(savingTextBox1.Text);

                    string savingIs = string.Empty;

                    if (onetimeCheckBox1.Checked)
                    {
                        savingIs = "One Time";
                    }
                    if (PerYearCheckBox2.Checked)
                    {
                        savingIs = "Per Year";
                    }

                    string detailcalculationOfSaving = string.Empty;

                    detailcalculationOfSaving = DetailcalculationofsavingsTextBox1.Text;

                    decimal costOfImplementation = 0;
                    costOfImplementation = Convert.ToDecimal(CostofImplementationTextBox1.Text);

                    string pfactor = string.Empty;

                    if (ActiveRoleCheckBox1.Checked)
                    {
                        pfactor = "ActiveRole";
                    }
                    if (SuggestorhastakenCheckBox2.Checked)
                    {
                        pfactor = "takenhelp";
                    }

                    int serialNo = getS_No(connection);
                    string Kz_ID = (string)Session["Kaizen_ID"];
                   

                    string ipAddress = HttpContext.Current.Request.UserHostAddress;
                    string evaluatorUserID = (string)Session["username"];

                    string insertQuery = "INSERT INTO IE_EVALUATOR_ACTIONS_DETAILS (SrNo, Kaizen_ID, EvaluatorAction, ForwardedtoOMDate, RejectedbyEvaluatorDate, AcceptedThirdOptionEvaluatorDate, CommentByEvaluator, Productivity, Quality, CostReduction, Delivery, Safety, Morale, InnovativeIdea, SavingByImplementation, SavingIs, DetailCalculationofSavings, CostofImplementation, pfactor, Ipaddress,EvaluatoruserID) " +
                         "VALUES (@SrNo, @Kaizen_ID, @EvaluatorAction, @ForwardedtoOMDate, @RejectedbyEvaluatorDate, @AcceptedThirdOptionEvaluatorDate, @CommentByEvaluator, @Produc, @Qual, @CostReduction, @Deli, @Safe, @Moral, @InnovativeIdea, @SavingByImplementation, @SavingIs, @DetailCalculationofSavings, @CostofImplementation, @pfactors, @Ipaddress, @EvaluatorID)";

                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("SrNo", serialNo);
                    command.Parameters.AddWithValue("Kaizen_ID", Kz_ID);
                    if (ACCEPTEDCheckBox.Checked)
                    {
                        command.Parameters.AddWithValue("EvaluatorAction", evaluatorAction);
                        command.Parameters.AddWithValue("ForwardedtoOMDate", Accepteddate);

                    }
                    else
                    {
                        command.Parameters.AddWithValue("ForwardedtoOMDate", Accepteddate.HasValue ? (object)Accepteddate.Value : DBNull.Value);
                    }
                    if (REJECTEDCheckBox.Checked)
                    {
                        command.Parameters.AddWithValue("EvaluatorAction", evaluatorAction);
                        command.Parameters.AddWithValue("RejectedbyEvaluatorDate", rejecteddate);

                    }
                    else
                    {
                        command.Parameters.AddWithValue("RejectedbyEvaluatorDate", rejecteddate.HasValue ? (object)rejecteddate.Value : DBNull.Value);
                    }
                    if (ACCEPTEDhoweverCheckBox.Checked)
                    {
                        command.Parameters.AddWithValue("EvaluatorAction", evaluatorAction);
                        command.Parameters.AddWithValue("AcceptedThirdOptionEvaluatorDate", Dcategorydate);

                    }
                    else
                    {
                        command.Parameters.AddWithValue("AcceptedThirdOptionEvaluatorDate", Dcategorydate.HasValue ? (object)Dcategorydate.Value : DBNull.Value);
                    }

                    command.Parameters.AddWithValue("CommentByEvaluator", evaluatorComment);
                    command.Parameters.AddWithValue("Produc", Productivityvar);
                    command.Parameters.AddWithValue("Qual", Qualityvar);
                    command.Parameters.AddWithValue("CostReduction", CostReductionvar);
                    command.Parameters.AddWithValue("Deli", Deliveryvar);
                    command.Parameters.AddWithValue("Safe", Safetyvar);
                    command.Parameters.AddWithValue("Moral", Moralevar);
                    command.Parameters.AddWithValue("InnovativeIdea", InnovativeIdeavar);
                    command.Parameters.AddWithValue("SavingByImplementation", savingByImplementation);
                    command.Parameters.AddWithValue("SavingIs", savingIs);
                    command.Parameters.AddWithValue("DetailCalculationofSavings", detailcalculationOfSaving);
                    command.Parameters.AddWithValue("CostofImplementation", costOfImplementation);
                    command.Parameters.AddWithValue("pfactors", pfactor);
                    command.Parameters.AddWithValue("Ipaddress", ipAddress);
                    command.Parameters.AddWithValue("EvaluatorID", "175129");
                    

                    command.ExecuteNonQuery();

                    Session["Kaizen_Id_1"] = Kz_ID;
                    ClearControls();
                    pageleveLabel1.Text = "Kaizen is evaluated.";
                    connection.Close();
                    Response.Redirect("AllotmarkstoKaizen.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    
                }
                catch(Exception e)
                {
                    pageleveLabel1.Text = "Errors in the field.";
                    pageleveLabel1.ForeColor = Color.Red;
                    ClearControls();
                }
                finally
                {
                    connection.Close();
                    ClearControls();
                }
            }



        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ACCEPTEDCheckBox.Checked && !REJECTEDCheckBox.Checked && !ACCEPTEDhoweverCheckBox.Checked)
            {
                Kaizenis_label.Text="Please select the action before submit";
                return;
            }
            if (!onetimeCheckBox1.Checked && !PerYearCheckBox2.Checked)
            {
                SavingisLLabel2.Text = "Please select the action before submit";
                return;
            }
            if (!ActiveRoleCheckBox1.Checked && !SuggestorhastakenCheckBox2.Checked)
            {
                ParticipationfactorLabel2.Text = "Please select the action before submit";
                return;
            }
            if (txtEvaluatorComments.Text == string.Empty)
            {
                txtEvaluatorCommentsLabel1s.Text = "Please enter comments.";
                return;
            }
            if (!ProductivityCheckBox1.Checked && !QualityCheckBox1.Checked && !CostReductionCheckBox2.Checked && !DeliveryCheckBox3.Checked &&
                !SafetyCheckBox4.Checked && !MoraleCheckBox5.Checked &&!InnovativeIdeaCheckBox1.Checked)
            {
                checkboxlabel.Text = "Please check atleast one checkboxes";
                return;
            }
            if (savingTextBox1.Text == string.Empty && savingTextBox1.Text.Length > 15)
            {
                savingLabel.Text = "Please enter saving and it should not be greater than 15 digits";
                return;
            }
            if (DetailcalculationofsavingsTextBox1.Text == string.Empty)
            {
                DetailcalculationofsavingsLabel2.Text = "Please enter detail calculation of saving.";
                return;
            }
            if (CostofImplementationTextBox1.Text == string.Empty && CostofImplementationTextBox1.Text.Length > 15)
            {
                CostofImplementationLabel2.Text = "Please enter Cost of Implementation and it should not be greater than 15 digits";
                return;
            }
            if ((!ACCEPTEDCheckBox.Checked && !REJECTEDCheckBox.Checked && !ACCEPTEDhoweverCheckBox.Checked) || (!onetimeCheckBox1.Checked && !PerYearCheckBox2.Checked)
                || (!ActiveRoleCheckBox1.Checked && !SuggestorhastakenCheckBox2.Checked) || txtEvaluatorComments.Text == string.Empty || (!ProductivityCheckBox1.Checked && !QualityCheckBox1.Checked && !CostReductionCheckBox2.Checked && !DeliveryCheckBox3.Checked &&
                !SafetyCheckBox4.Checked && !MoraleCheckBox5.Checked && !InnovativeIdeaCheckBox1.Checked) || savingTextBox1.Text == string.Empty
                || DetailcalculationofsavingsTextBox1.Text == string.Empty || CostofImplementationTextBox1.Text == string.Empty)
                
            {
                pageleveLabel1.Text = "Please fill in all details before submitting.";
                return;
            }
            else
            {
                insertfunction();

            }
        }

        private void ClearControls()
        {
            Kaizenis_label.Text = string.Empty;
            SavingisLLabel2.Text = string.Empty;
            ParticipationfactorLabel2.Text = string.Empty;
            txtEvaluatorCommentsLabel1s.Text = string.Empty;
            checkboxlabel.Text = string.Empty;
            savingLabel.Text = string.Empty;
            DetailcalculationofsavingsLabel2.Text = string.Empty;
            CostofImplementationLabel2.Text = string.Empty;
           
        }
    }
}