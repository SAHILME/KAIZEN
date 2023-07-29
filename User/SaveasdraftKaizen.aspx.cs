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
using System.IO;

namespace Industrial_Engineering.IE_Kaizen.User
{
    public partial class SaveasdraftKaizen : System.Web.UI.Page
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

          public static string tempbeforeimagepath;
       public static string tempbeforeimagename;
       public static string tempafterimagepath;
       public static string tempafterimagename;

        protected void Page_Load(object sender, EventArgs e)
        {
            String username = (string)(Session["username"]);
            String role = (string)(Session["role"]); //String.IsNullOrEmpty(role) should be empty
            if (String.IsNullOrEmpty(username) || !String.IsNullOrEmpty(role))
            {
                HttpContext.Current.Response.Redirect("~/IE_Central_Logout.aspx");
            }
            GridView1label.Text = string.Empty;
            if (!IsPostBack)
            {
                BindGridView();
            }
        }
        private void BindGridView()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);
             string empID = (string)Session["username"];

            
            try
            {

                int StatusofKai = 0;
                String queryRetrive = "SELECT * FROM IE_USERS_KAIZEN_DETAILS WHERE Ticket_no_kaizen_submitter = @empID AND Status_of_Kaizen = @STATUSOFK ORDER BY Kaizen_ID ASC";

                SqlCommand cmd = new SqlCommand(queryRetrive, connection);
                cmd.Parameters.AddWithValue("empID", empID);
                cmd.Parameters.AddWithValue("STATUSOFK", StatusofKai);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Dispose();
                SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                dataadapter.Fill(dataset);


                GridView1.DataSource = dataset.Tables[0];
                GridView1.DataBind();
                connection.Close();
            }
            catch (Exception EX)
            {
                GridView1label.Text = "Error loading the data from DB";
            }
            finally
            {
                connection.Close();
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView();
        }


       

        /*protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            string abc = GridView1.Rows[e.RowIndex].Cells[1].ToString();
            string Kid = abc;


            string kaizen = Kid;
            // Delete the record from the database
            DeleteDataFromDatabase(Kid);

            BindGridView();

        }*/

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow row = e.Row;
                int pageIndex = GridView1.PageIndex;
                int pageSize = GridView1.PageSize;
                int rowIndex = row.RowIndex;
                int sNo = (pageIndex * pageSize) + rowIndex + 1;

                // Find the S_no Literal control in the row
                Literal literalSNo = (Literal)row.FindControl("literalSNo");
                if (literalSNo != null)
                {
                    literalSNo.Text = sNo.ToString();
                }
            }
        }


        private void UpdateDataInDatabase(int id, string title, string dept)
        {
            // Replace with your database update logic
        }

        private void DeleteDataFromDatabase(string id)
        {
            // Replace with your database delete logic


            string empID = (string)Session["username"];
            
            connection.Open();


            try
            {
                string selectQuery = "SELECT * FROM IE_USERS_KAIZEN_DETAILS WHERE Kaizen_ID = @kid";
                SqlCommand cmd3 = new SqlCommand(selectQuery, connection);
                cmd3.Parameters.AddWithValue("kid", id);

                SqlDataReader dr3 = cmd3.ExecuteReader();

                if (dr3.HasRows)
                {
                    dr3.Read();

                    tempbeforeimagepath = Convert.ToString(dr3["beforeimgpath"]);
                    tempbeforeimagename = Convert.ToString(dr3["Before_Implementation_img_details"]);

                    tempafterimagepath = Convert.ToString(dr3["afterimgpath"]);
                    tempafterimagename = Convert.ToString(dr3["After_Implementation_Img_Details"]);
                    if (!string.IsNullOrEmpty(tempbeforeimagepath))
                    {
                        string filePathofoldbeforeimage = "~/kaizenbeforeimgs/" + tempbeforeimagepath;
                        // Delete the file
                        if (File.Exists(Server.MapPath(filePathofoldbeforeimage)))
                        {
                            File.Delete(Server.MapPath(filePathofoldbeforeimage));
                        }
                    }
                    if (!string.IsNullOrEmpty(tempafterimagepath))
                    {
                        string filePathofoldafterimage = "~/kaizenafterimgs/" + tempafterimagepath;
                        // Delete the file
                        if (File.Exists(Server.MapPath(filePathofoldafterimage)))
                        {
                            File.Delete(Server.MapPath(filePathofoldafterimage));
                        }
                    }
                }
                dr3.Dispose();

                String querydeletefrommemberstable = "delete from IE_USERS_KAIZEN_MEMBERS_DETAILS where Kaizen_ID= @Id";

                SqlCommand cmd2 = new SqlCommand(querydeletefrommemberstable, connection);
                cmd2.Parameters.AddWithValue("Id", id);
                cmd2.ExecuteNonQuery();


                String querydelete = "delete from IE_USERS_KAIZEN_DETAILS where Kaizen_ID= @Id AND Ticket_no_kaizen_submitter = @empID ";

                SqlCommand cmd = new SqlCommand(querydelete, connection);
                cmd.Parameters.AddWithValue("Id", id);
                cmd.Parameters.AddWithValue("empID", empID);

                cmd.ExecuteNonQuery();
                GridView1.EditIndex = -1;
                BindGridView();


                GridView1.EditIndex = -1;
                BindGridView();
                connection.Close();
                GridView1label.Text = "Record successfully deleted.";
            }
            catch (Exception ex)
            {
                GridView1label.Text = "Error deleting record from DB";

            }
            finally
            {
                connection.Close();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Literal Kaizen_ID = (Literal)GridView1.Rows[index].FindControl("Kaizen_ID");
                Session["Kaizen_ID"] = Kaizen_ID.Text;

                // Redirect to the view page passing the ID as a query parameter

                Response.Redirect("ViewKaizenDetails.aspx");
            }

            if (e.CommandName == "EditRow")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Literal Kaizen_ID = (Literal)GridView1.Rows[index].FindControl("Kaizen_ID");
                Session["Kaizen_ID"] = Kaizen_ID.Text;

                // Redirect to the view page passing the ID as a query parameter

                Response.Redirect("EditUpdateKaizenDetails.aspx");
            }
            if (e.CommandName == "remove")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Literal Kaizen_ID = (Literal)GridView1.Rows[index].FindControl("Kaizen_ID");
                string Kid = Kaizen_ID.Text;
                // Delete the record from the database
                DeleteDataFromDatabase(Kid);
                BindGridView();
            }
            BindGridView();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            SortDirection sortDirection = GetSortDirection(e.SortExpression);

            // Perform the sorting operation based on the sort expression and direction
            string empID = (string)Session["username"];
            DataTable dataTable = GetDataFromDatabase(empID); // Replace this with your own data retrieval logic
            DataView dataView = new DataView(dataTable);
            dataView.Sort = sortExpression + (sortDirection == SortDirection.Ascending ? " ASC" : " DESC");
            GridView1.DataSource = dataView;
            GridView1.DataBind();
        }

        private SortDirection GetSortDirection(string sortExpression)
        {
            // By default, set the sort direction to ascending
            SortDirection sortDirection = SortDirection.Ascending;

            // Check if the sort expression already exists in the ViewState
            string lastSortExpression = ViewState["SortExpression"] as string;
            if (lastSortExpression != null && lastSortExpression == sortExpression)
            {
                // The same column is being sorted again, so toggle the sort direction
                SortDirection lastSortDirection = (SortDirection)ViewState["SortDirection"];
                sortDirection = (lastSortDirection == SortDirection.Ascending) ? SortDirection.Descending : SortDirection.Ascending;
            }

            // Store the sort expression and direction in the ViewState for future reference
            ViewState["SortExpression"] = sortExpression;
            ViewState["SortDirection"] = sortDirection;

            return sortDirection;
        }
        private DataTable GetDataFromDatabase(string KID)
        {

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);
            string empID = (string)Session["username"];

            DataSet dataset = new DataSet();
            try
            {
                int StatusofKai = 0;
                String queryRetrive = "SELECT * FROM IE_USERS_KAIZEN_DETAILS WHERE Ticket_no_kaizen_submitter = @empID AND Status_of_Kaizen = @STATUSOFK ORDER BY Kaizen_ID ASC";

                SqlCommand cmd = new SqlCommand(queryRetrive, connection);
                cmd.Parameters.AddWithValue("empID", empID);
                cmd.Parameters.AddWithValue("STATUSOFK", StatusofKai);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Dispose();
                SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);

                dataadapter.Fill(dataset);


                return dataset.Tables[0];

            }
            catch (Exception EX)
            {
                GridView1label.Text = "Error loading the data from DB";
            }
            finally
            {
                connection.Close();
            }
            return dataset.Tables[0];
        }
    }
}