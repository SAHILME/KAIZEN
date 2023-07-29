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
    public partial class CO_view_details_of_action : System.Web.UI.Page
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
                //FillCoordinatorAction();
                //FillDepartment();
                //FillDiscipline();
                //FillDepartmentddlco();
                //FillDisciplineddlco();
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

        /*private void FillCoordinatorAction()
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

        }*/

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

       /* private void FillDisciplineddlco()
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

        }*/

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

        /*private void FillDepartmentddlco()
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
        }*/

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
                }
                string dept = dr2["Plant_Department"].ToString();
                string discipline = dr2["Discipline"].ToString();

                dr2.Dispose();

                string selectQueryforCotable = "SELECT * FROM IE_COORDINATOR_ACTIONS_DETAILS WHERE Kaizen_ID = @id";
                SqlCommand cmd3 = new SqlCommand(selectQueryforCotable, connection);
                cmd3.Parameters.AddWithValue("id", KID);

                SqlDataReader dr3 = cmd3.ExecuteReader();

                if (dr3.HasRows)
                {
                    dr3.Read();
                    ddlforwared_reject.SelectedItem.Text = dr3["CoordinatorAction"].ToString();

                    if ("Forward to Evaluator" == dr3["CoordinatorAction"].ToString()) 
                    {
                        DateTime forwardedDate = (DateTime)dr3["ForwardedtoEvaluatorDate"];
                        Txtregistrationdate.Text = forwardedDate.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        Txtregistrationdate.Text = "Kaizen is rejected by coordinator";
                    }

                    TextEmail.Text = dr3["COsendemailto"].ToString();
                    TextRemarks.Text = dr3["CO_remark"].ToString();
                }
                dr3.Dispose();

                string getevaluatorQuery = "SELECT * FROM IE_DEPT_DISCI_OM_EV_DETAILS WHERE Plant_Department = @dept AND Discipline = @disci";
                SqlCommand cmd4 = new SqlCommand(getevaluatorQuery, connection);
                cmd4.Parameters.AddWithValue("dept", dept);
                cmd4.Parameters.AddWithValue("disci", discipline);


                SqlDataReader dr4 = cmd4.ExecuteReader();
                if (dr4.HasRows)
                {
                    dr4.Read();
                    TextEvaluator.Text = dr4["EV_Email"].ToString();

                }
                dr4.Dispose();

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
    }
}