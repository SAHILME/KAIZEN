using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Industrial_Engineering.IE_Kaizen.User
{
    public partial class My_Kaizens : System.Web.UI.Page
    {
        protected List<MyKaizenDataItem> MyKaizenDataList { get; set; }
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

        public class MyKaizenDataItem
        {
            // public int SrNo { get; set; }
            public string KaizenID { get; set; }
            public string Title { get; set; }
            public string Dept { get; set; }
            public string Discipline { get; set; }
            public string Dateofsubmission { get; set; }
            //public string DateofRegistration { get; set; }
            //public string DateofEvaluated { get; set; }
            //public string DateofApprovalByOM { get; set; }
            //public string DateofPresentation { get; set; }
            public string Status { get; set; }
            // public string DateofPresentation { get; set; }
            // public string RewardStatus { get; set; }
            public string Savings { get; set; }
            // public string ViewDetails { get; set; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve data from the database and populate YourDataList
            MyKaizenDataList = GetDataFromDatabase();
            if (!IsPostBack)
            {
                // Retrieve data from the database and populate KaizenList
                MyKaizenDataList = GetDataFromDatabase();
            }
        }


        // Method to retrieve data from the database
        private List<MyKaizenDataItem> GetDataFromDatabase()
        {
            List<MyKaizenDataItem> kaizenList = new List<MyKaizenDataItem>();

           // string empID = (string)Session["username"];

            string empID = "175129";

            string query = "SELECT S_no, Kaizen_ID, Ticket_no_kaizen_submitter, Kaizen_title, Plant_Department, Discipline,Date_of_Kaizen_Submission ,Status_of_Kaizen,Savings FROM IE_USERS_KAIZEN_DETAILS WHERE Ticket_no_kaizen_submitter = @EMP_ID";

           
                try
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("EMP_ID", empID);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MyKaizenDataItem kaizen = new MyKaizenDataItem
                        {
                            KaizenID = reader["Kaizen_ID"].ToString(),
                            Title = reader["Kaizen_title"].ToString(),
                            Dept = reader["Plant_Department"].ToString(),
                            Discipline = reader["Discipline"].ToString(),
                            Dateofsubmission = reader["Date_of_Kaizen_Submission"].ToString(),
                            Savings = reader["Savings"].ToString(),
                            Status = reader["Status_of_Kaizen"].ToString(),

                        };

                        kaizenList.Add(kaizen);
                    }
                    reader.Dispose();
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

                return kaizenList;

            }
        }
    }