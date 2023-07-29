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
    public partial class ViewKaizenDetails : System.Web.UI.Page
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            String username = (string)(Session["username"]);
            string Kz_ID = (string)Session["Kaizen_ID"];
            
            String role = (string)(Session["role"]); //String.IsNullOrEmpty(role) should be empty
           
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(Kz_ID) || !String.IsNullOrEmpty(role))
            {
                HttpContext.Current.Response.Redirect("~/IE_Central_Logout.aspx");
            }
            
            // Fetch the record from the database based on the ID
            GetDataFromDatabaseAndDisplay(Kz_ID);


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

                    if (0 != Convert.ToInt32(dr["TicketNo1"])) {
                    txtteamMember1empid.Text = dr["TicketNo1"].ToString();
                    }
                    else{
                        txtteamMember1empid.Text="";
                    }
                      if (0 != Convert.ToInt32(dr["TicketNo2"])){
                    txtteamMember2empid.Text = dr["TicketNo2"].ToString();
                      }
                    else{
                        txtteamMember2empid.Text="";
                    }
                      if (0 != Convert.ToInt32(dr["TicketNo3"]))
                      {
                    txtteamMember3empid.Text = dr["TicketNo3"].ToString();
                      }
                    else{
                        txtteamMember3empid.Text="";
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

                    if ("p"==Productivitycheck)
                    {
                        Productivity.Checked = true;
                    }
                    if ("q"== (Qualitycheck))
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

    }
}