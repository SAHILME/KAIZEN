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
    public partial class responsepage : System.Web.UI.Page
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            String username = (string)(Session["username"]);
            String role = (string)(Session["role"]); //String.IsNullOrEmpty(role) should be empty
            if (String.IsNullOrEmpty(username) || !String.IsNullOrEmpty(role))
            {
                HttpContext.Current.Response.Redirect("~/IE_Central_Logout.aspx");
            }
            responsemessage();
            
        }

        private string getstatus()
        {
            string temp = string.Empty;
            
                    try
                    {
                       
                        string k_id_t = (string)Session["kaizen_Id_1"];

                        string selectQuery = "SELECT Status_of_Kaizen FROM IE_USERS_KAIZEN_DETAILS WHERE Kaizen_ID = @KaizenId";
                        SqlCommand cmd = new SqlCommand(selectQuery, connection);
                        cmd.Parameters.AddWithValue("KaizenId", k_id_t);
                        connection.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                       
                        if (dr.HasRows)
                        {
                            dr.Read();
                       
                        }
                        int status = Convert.ToInt32(dr.GetValue(0).ToString());
                       
                        if (0 == status)
                        {
                            temp = "saved as draft";
                        }
                        else if ((1 == status))
                        {
                            temp = "submitted";
                        }
                       
                        dr.Dispose();
                        connection.Close();
                        return temp;
                }
                catch (Exception ex)
                {
                   Response.Write(ex.Message);
                    
                }
                finally
                {
                    connection.Close();
                }
                    return temp;
        }

        private void responsemessage()
        {
            string temp = getstatus();
            string k_id_t = (string)Session["kaizen_Id_1"];
            string display = "Your Kaizen is "+ temp +" successfully with KaizenId: " + k_id_t;
            response.Text = display;
        }
        
    }
}