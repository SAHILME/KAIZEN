using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Industrial_Engineering.IE_Kaizen.Admin
{
    public partial class IE_Kaizen_Admin_Master_Page : System.Web.UI.MasterPage
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            showNotification();
        }
        protected void LogOut(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Central_Logout.aspx");
        }
        public void showNotification()
        {

            

            connection.Open();

            String queryRetrive = "SELECT * FROM IE_ADMIN_NOTIFICATION ORDER BY S_NO ASC";

            SqlCommand cmd = new SqlCommand(queryRetrive, connection);
            
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Dispose();
            SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            dataadapter.Fill(dataset);

            //readerRetrive.Close();
            
            connection.Close();
            Notification.InnerHtml = string.Empty;
            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                Notification.InnerHtml += row["NOTIFICATION"] + "<br />";
            }
        }
    }
}