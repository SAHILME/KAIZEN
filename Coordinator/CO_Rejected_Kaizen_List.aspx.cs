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

namespace Industrial_Engineering.IE_Kaizen.Coordinator
{
    public partial class CO_Rejected_Kaizen_List : System.Web.UI.Page
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            String username = (string)(Session["username"]);
            //String role = (string)(Session["role"]); String.IsNullOrEmpty(role) should not be empty and = coordinator
            //if (String.IsNullOrEmpty(username))
            // {
            //   HttpContext.Current.Response.Redirect("~/IE_Central_Login.aspx");
            // }


            GridView1label.Text = string.Empty;
            if (!IsPostBack)
            {
                BindGridView(null, null, null, null);
                FillDepartment();
                FillDiscipline();
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

                Response.Redirect("CO_view_details_of_action.aspx");
            }

            BindGridView(null, null, null, null);

        }

        public void BindGridView(DateTime? fromdate, DateTime? todate, string department, string discipline)
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);
            string empID = (string)Session["username"];

            DateTime? fromDatevalue = null;
            DateTime? toDatevalue = null;

            if (!(fromdate == DateTime.MinValue))
            {
                fromDatevalue = fromdate;
            }

            if (!(todate == DateTime.MinValue))
            {
                toDatevalue = todate;
            }

            String dept = null;
            string disci = null;

            if (!String.IsNullOrEmpty(department))
            {
                dept = department;
            }

            if (!String.IsNullOrEmpty(discipline))
            {
                disci = discipline;
            }


            if (fromDatevalue != null || toDatevalue != null || !String.IsNullOrEmpty(department) || !String.IsNullOrEmpty(discipline))
            {
                try
                {
                    int StatusofKaiByCo = -1;
                    
                    string searchquery = "SELECT t1.* FROM IE_USERS_KAIZEN_DETAILS as t1 WHERE 1 = 1 ";
                    if (fromDatevalue != null)
                    {
                        searchquery += " AND t1.Date_of_Kaizen_Submission >= @FromDate";
                    }
                    if (toDatevalue != null)
                    {
                        searchquery += " AND t1.Date_of_Kaizen_Submission <= @ToDate";
                    }
                    if (!String.IsNullOrEmpty(dept))
                    {
                        searchquery += " AND t1.Plant_Department = @departmentvalue";
                    }
                    if (!String.IsNullOrEmpty(disci))
                    {
                        searchquery += " AND t1.Discipline = @disciplinevalue";
                    }

                    searchquery += " AND t1.Status_of_Kaizen = @STATUSOFK ORDER BY t1.Kaizen_ID ASC";

                    SqlCommand cmd = new SqlCommand(searchquery, connection);

                    if (fromDatevalue != null)
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDatevalue);
                    }
                    if (toDatevalue != null)
                    {

                        cmd.Parameters.AddWithValue("@ToDate", toDatevalue);
                    }
                    if (!String.IsNullOrEmpty(dept))
                    {
                        cmd.Parameters.AddWithValue("@departmentvalue", dept);
                    }
                    if (!String.IsNullOrEmpty(disci))
                    {
                        cmd.Parameters.AddWithValue("@disciplinevalue", disci);
                    }

                    cmd.Parameters.AddWithValue("STATUSOFK", StatusofKaiByCo);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Dispose();
                    SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    dataadapter.Fill(dataset);

                    dataset.Tables[0].Columns.Add("RejectedBy", typeof(string));
                    foreach (DataRow row in dataset.Tables[0].Rows)
                    {
                        if (-1 == Convert.ToInt32(row["Status_of_Kaizen"]))
                        {
                            string modifiedValue = "Rejected By Coordinator";
                            row["RejectedBy"] = modifiedValue;
                        }
                        else if (-2 == Convert.ToInt32(row["Status_of_Kaizen"]))
                        {
                            string modifiedValue = "Rejected By OM";
                            row["RejectedBy"] = modifiedValue;
                        }
                    }

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
            else
            {
                try
                {
                    int StatusofKaiByCo = -1;
                    String queryRetrive = "SELECT t1.* FROM IE_USERS_KAIZEN_DETAILS as t1 WHERE t1.Status_of_Kaizen = @STATUSOFK ORDER BY t1.Kaizen_ID ASC";

                    SqlCommand cmd = new SqlCommand(queryRetrive, connection);

                    cmd.Parameters.AddWithValue("STATUSOFK", StatusofKaiByCo);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Dispose();
                    SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    dataadapter.Fill(dataset);

                    dataset.Tables[0].Columns.Add("RejectedBy", typeof(string));
                    foreach (DataRow row in dataset.Tables[0].Rows)
                    {
                        if (-1 == Convert.ToInt32(row["Status_of_Kaizen"]))
                        {
                            string modifiedValue = "Rejected By Coordinator";
                            row["RejectedBy"] = modifiedValue;
                        }
                        else if (-2 == Convert.ToInt32(row["Status_of_Kaizen"]))
                        {
                            string modifiedValue = "Rejected By OM";
                            row["RejectedBy"] = modifiedValue;
                        }
                    }

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
                int StatusofKaiByCo = -1;
                String queryRetrive = "SELECT t1.* FROM IE_USERS_KAIZEN_DETAILS as t1 WHERE t1.Status_of_Kaizen = @STATUSOFK ORDER BY t1.Kaizen_ID ASC";

                SqlCommand cmd = new SqlCommand(queryRetrive, connection);

                cmd.Parameters.AddWithValue("STATUSOFK", StatusofKaiByCo);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Dispose();
                SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
                
                dataadapter.Fill(dataset);

                dataset.Tables[0].Columns.Add("RejectedBy", typeof(string));
                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    if (-1 == Convert.ToInt32(row["Status_of_Kaizen"]))
                    {
                        string modifiedValue = "Rejected By Coordinator";
                        row["RejectedBy"] = modifiedValue;
                    }
                    else if (-2 == Convert.ToInt32(row["Status_of_Kaizen"]))
                    {
                        string modifiedValue = "Rejected By OM";
                        row["RejectedBy"] = modifiedValue;
                    }
                }


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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView(null, null, null, null);
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

        private void UpdateDataInDatabase(int id, string title, string dept)
        {
            // Replace with your database update logic
        }

        private void FillDiscipline()
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

        }
        private void FillDepartment()
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
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime? fromDate = null;
            DateTime? Todate = null;
            if (TxtFromndate.Text == "")
            {
                fromDate = null;
            }
            else
            {
                fromDate = DateTime.Parse(TxtFromndate.Text);
            }

            if (TextTodate.Text == "")
            {
                Todate = null;
            }
            else
            {
                Todate = DateTime.Parse(TextTodate.Text);
            }

            string department;
            if (ddlPlantDepartment.SelectedItem.Text == "---Select One---")
            {
                department = null;
            }
            else
            {
                department = ddlPlantDepartment.SelectedItem.Text;
            }

            string discipline;
            if (ddlDiscipline.SelectedItem.Text == "---Select One---")
            {
                discipline = null;
            }
            else
            {
                discipline = ddlDiscipline.SelectedItem.Text;
            }


            BindGridView(fromDate, Todate, department, discipline);
        }
    }
}