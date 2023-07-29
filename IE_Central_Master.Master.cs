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

namespace Industrial_Engineering
{
    public partial class IE_Central_Master : System.Web.UI.MasterPage
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void generateLog(string user, string page, string currentevent, Label label)
        {
            try
            {
                string currUser = user;
                string currpage = page;
                string currevent = currentevent;

                string ipAddress = HttpContext.Current.Request.UserHostAddress;
                DateTime datetime = DateTime.Now;

                connection.Open();
                string queryloginsert = "INSERT INTO IE_LOG_DETAILS (Username, Pagename, Ipaddress, datetimeofevent, userevent) VALUES (@Username,@Page,@Ipaddress,@datetime,@event)";
                SqlCommand cmd = new SqlCommand(queryloginsert, connection);


                cmd.Parameters.AddWithValue("Username", currUser);
                cmd.Parameters.AddWithValue("Page", currpage);
                cmd.Parameters.AddWithValue("Ipaddress", ipAddress);
                cmd.Parameters.AddWithValue("datetime", datetime);
                cmd.Parameters.AddWithValue("event", currevent);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {

                label.Text = "Errors in the field.";
                label.ForeColor = Color.Red;
                connection.Close();

            }
            finally
            {
                connection.Close();
            }
        }
       
    }
}