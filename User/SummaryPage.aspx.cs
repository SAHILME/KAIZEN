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
    public partial class SummaryPage : System.Web.UI.Page
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string empID = (string)Session["username"];
            String username = (string)(Session["username"]);
            String role = (string)(Session["role"]); //String.IsNullOrEmpty(role) should be empty
            if (String.IsNullOrEmpty(username) || !String.IsNullOrEmpty(role))
            {
                HttpContext.Current.Response.Redirect("~/IE_Central_Logout.aspx");
            }
            // Fetch the record from the database based on the ID
            GetDataFromDatabaseAndDisplay(empID);

        }
        private void GetDataFromDatabaseAndDisplay(string EMPID)
        {

            try
            {
                string selectQuery = "SELECT Kaizen_ID,Status_of_Kaizen,Savings FROM IE_USERS_KAIZEN_DETAILS WHERE Ticket_no_kaizen_submitter = @EMPLOYEEID";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                cmd.Parameters.AddWithValue("EMPLOYEEID", EMPID);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                int totalKaizen = 0;
                int submittedkaizen = 0;
                int Rejectedkaizen = 0;
                int draftkaizen = 0;
                int forwardtoevaluator = 0;
                int totalsaving = 0;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (0 == Convert.ToInt32(dr["Status_of_Kaizen"]))
                        {
                            draftkaizen++;
                        }
                        else if (1 == Convert.ToInt32(dr["Status_of_Kaizen"]))
                        {
                            submittedkaizen++;
                        }
                        else if (-1 == Convert.ToInt32(dr["Status_of_Kaizen"]))
                        {
                            Rejectedkaizen++;
                        }
                        else if (2 == Convert.ToInt32(dr["Status_of_Kaizen"]))
                        {
                            forwardtoevaluator++;
                        }
                        totalKaizen++;

                        if (1 == Convert.ToInt32(dr["Status_of_Kaizen"]))
                        {
                            totalsaving += Convert.ToInt32(dr["Savings"]);
                        }
                    }  
                }

                

                dr.Dispose();

                string selectQueryfrommembers = "SELECT Kaizen_ID,statusofKaizen FROM IE_USERS_KAIZEN_MEMBERS_DETAILS WHERE TicketNo1 = @EMPLOYEEID OR TicketNo2 = @EMPLOYEEID OR TicketNo3 = @EMPLOYEEID";
                SqlCommand cmd2 = new SqlCommand(selectQueryfrommembers, connection);
                cmd2.Parameters.AddWithValue("EMPLOYEEID", EMPID);

                SqlDataReader dr2 = cmd2.ExecuteReader();

                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        if (0 == Convert.ToInt32(dr["statusofKaizen"]))
                        {
                            draftkaizen++;
                        }
                        else if (1 == Convert.ToInt32(dr["statusofKaizen"]))
                        {
                            submittedkaizen++;
                        }
                        else if (-1 == Convert.ToInt32(dr["Status_of_Kaizen"]))
                        {
                            Rejectedkaizen++;
                        }
                        totalKaizen++;

                        //totalsaving += Convert.ToInt32(dr["Savings"]);
                    }
                }

                TotalKaizens.Text = totalKaizen.ToString();
                KaizenSubmitted.Text = submittedkaizen.ToString();
                KaizenDrafted.Text = draftkaizen.ToString();
                TotalSavings.Text = totalsaving.ToString();
                KaizenRejected.Text = Rejectedkaizen.ToString();
                KaizenregisteredbyCoordinator.Text = Rejectedkaizen.ToString();

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