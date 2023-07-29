using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Industrial_Engineering.IE_Kaizen
{
    public partial class Role_Dashboard : System.Web.UI.Page
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            String username = (string)(Session["username"]);
            if (String.IsNullOrEmpty(username))
            {
                HttpContext.Current.Response.Redirect("~/IE_Central_Logout.aspx");
            }
           
            if (!IsPostBack)
            {
                getUser();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/User/UserDashboard.aspx");
        }

        public void getUser()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);
            try
            {
               
                string EMPLOYEE_NO = (string)Session["KaizenUser"];

                String queryGetUser = "SELECT * FROM IE_ADMIN WHERE EMPLOYEE_NO = '" + EMPLOYEE_NO + "'";

                SqlCommand cmd = new SqlCommand(queryGetUser, connection);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        String ROLE = Convert.ToString(dr["ROLE"]);

                        if (ROLE == "COORDINATOR")
                        {

                            Button2.Visible = true;
                            Session["role"] = ROLE;

                        }
                        else if (ROLE == "EVALUATOR")
                        {

                            Button3.Visible = true;
                            Session["role"] = ROLE;

                        }
                        else if (ROLE == "OM")
                        {

                            Button4.Visible = true;
                            Session["role"] = ROLE;

                        }
                        else if (ROLE == "OM & EVALUATOR")
                        {
                            Button3.Visible = true;
                            Button4.Visible = true;
                            Session["role"] = ROLE;

                        }

                    }
                }
                else
                {
                    Button1.Visible = true;
                }
                //readerGetUser.Close();
                dr.Dispose();
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Coordinator/CoordinatorDashboard.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Evaluator/EvaluatorDashboard.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/OM/OMDashboard.aspx");
        }
    }
}