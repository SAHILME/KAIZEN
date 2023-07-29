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

namespace Industrial_Engineering.IE_Kaizen.User
{
    public partial class MyKaizens : System.Web.UI.Page
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
                int StatusofKai = 1;
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


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView();
        }


       /* protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            //int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0]);

            TableCell cell = GridView1.Rows[e.RowIndex].Cells[0];
            int SrNo = Convert.ToInt32(cell.Text);
            
           

            // Delete the record from the database
            DeleteDataFromDatabase(SrNo);

            BindGridView();
           
        }*/

        private void UpdateDataInDatabase(int id, string title, string dept)
        {
            // Replace with your database update logic
        }

       /* private void DeleteDataFromDatabase(int id)
        {
            // Replace with your database delete logic


             string empID = (string)Session["username"];
            
            connection.Open();
           

            try
            {
               
                String querydeletefrommemberstable = "delete from IE_USERS_KAIZEN_MEMBERS_DETAILS where SrNo= @Id";

                SqlCommand cmd2 = new SqlCommand(querydeletefrommemberstable, connection);
                 cmd2.Parameters.AddWithValue("Id", id);
                 cmd2.ExecuteNonQuery();


                String querydelete = "delete from IE_USERS_KAIZEN_DETAILS where S_no= @Id AND Ticket_no_kaizen_submitter = @empID ";

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
        }*/

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

            /*if (e.CommandName == "EditRow")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Literal Kaizen_ID = (Literal)GridView1.Rows[index].FindControl("Kaizen_ID");
                Session["Kaizen_ID"] = Kaizen_ID.Text;

                // Redirect to the view page passing the ID as a query parameter

                Response.Redirect("EditUpdateKaizenDetails.aspx");
            }*/
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
                int StatusofKai = 1;
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