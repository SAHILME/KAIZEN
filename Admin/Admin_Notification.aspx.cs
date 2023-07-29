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


namespace Industrial_Engineering.IE_Kaizen.Admin
{
    public partial class Admin_Notification : System.Web.UI.Page
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);
        int index = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //String username = (string)(Session["username"]);
            //if (String.IsNullOrEmpty(username))
            //{
            //    HttpContext.Current.Response.Redirect("~/IE_Central_Login.aspx");
            //}
            if (!IsPostBack)
            {
                loadGridView();
                loadNotification();
            }
        }
        private void insertNotification()
        {
            using (connection)
            {
                try
                {
                    Int32 s_no = 0;
                  
                    string selectQuery = "SELECT MAX(S_NO) FROM IE_ADMIN_NOTIFICATION";
                    SqlCommand cmd = new SqlCommand(selectQuery, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();

                    }
                    string SERIALNO = dr.GetValue(0).ToString();

                    if (SERIALNO == "")
                    {
                        s_no = 1;
                    }
                    else
                    {
                        s_no = Convert.ToInt32(SERIALNO);
                        s_no = s_no + 1;
                    }

                    dr.Dispose();
                    
                   // string s_no = (index + 1).ToString();
                    var datetime = DateTime.Today;
                    string sysdate = datetime.ToString();
                    string Notification = txNotification.Text;
                    
                    //transaction = connection.BeginTransaction();
                    string queryuserinsert = "INSERT INTO IE_ADMIN_NOTIFICATION (S_NO, NOTIFICATION_DATE, NOTIFICATION) VALUES (@S_NO, @NOTIFICATION_DATE, @NOTIFICATION)";
                    SqlCommand cmduserinsert = new SqlCommand(queryuserinsert, connection);
                    //commanduserinsert.Connection = connection;
                    //commanduserinsert.Transaction = transaction;
                    cmduserinsert.Parameters.AddWithValue("S_NO", s_no);
                    cmduserinsert.Parameters.AddWithValue("NOTIFICATION_DATE", sysdate);
                    cmduserinsert.Parameters.AddWithValue("NOTIFICATION", Notification);


                    cmduserinsert.ExecuteNonQuery();
                    cmduserinsert.Dispose();
                    connection.Close();
                    //transaction.Commit();
                    //ClientScript.RegisterStartupScript(this.GetType(), "showPopUp", "showPopUp();", true);
                    lblAlert.Text = "Notification has been submitted successfully!";
                    LabelUpdate.Text = string.Empty;
                    //IE_Kaizen_Admin_Master_Page ms = new IE_Kaizen_Admin_Master_Page();
                    //ms.showNotification();
                    loadNotification();
                }
                catch (Exception ex)
                {
                    Response.Write(ex);

                    connection.Close();
                    return;
                }
                finally
                {
                    txNotification.Text = string.Empty;

                    connection.Close();
                }
            }
        }
        private void loadGridView()
        {

        }
        public void loadNotification()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);
            try
            {
                
                String queryRetrive = "SELECT * FROM IE_ADMIN_NOTIFICATION ORDER BY S_NO ASC";

                SqlCommand cmd = new SqlCommand(queryRetrive, connection);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Dispose();
                SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                dataadapter.Fill(dataset);
                grdViewTest.DataSource = dataset.Tables[0];
                grdViewTest.DataBind();


                //readerRetrive.Close();
                
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (txNotification.Text == string.Empty)
            {
                lblAlert.Text = "Please enter notification";
            }
            else
            {
                insertNotification();
            }
        }

        protected void grdViewTest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void grdViewTest_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Change")
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

                //--- Get primarry key value of the selected record.
                // int index = Convert.ToInt32(e.CommandArgument);
                Int32 index = Convert.ToInt32(e.CommandArgument.ToString());
                Literal ind = (Literal) grdViewTest.Rows[index].FindControl("S_NO");
                // get Index
                string strS_no = ind.Text;
                int S_no = int.Parse(strS_no);
               // S_no = S_no + 1;
                
                //--- Set S_no in viewstate so that we can use in update process.
                ViewState["selectedRec"] = S_no.ToString();

                String queryRetrive = "SELECT * FROM IE_ADMIN_NOTIFICATION WHERE S_NO = @S_no";

                SqlCommand cmd = new SqlCommand(queryRetrive, connection);
                connection.Open();

                cmd.Parameters.AddWithValue("S_no", S_no);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    txNotification.Text = dr["NOTIFICATION"].ToString();

                        //==== Store primary key of the selected record in ViewState for future reference.
                        //==== This will help us when we write update method.
                    ViewState["selectedRec"] = dr["S_NO"].ToString();

                }
                //readerRetrive.Close();
                dr.Dispose();
                connection.Close();

                Submit.Visible = false;
                Update.Visible = true;
                lblAlert.Text = string.Empty;
                LabelUpdate.Text = string.Empty;
            }
            else if (e.CommandName == "remove")
            {
               // int S_no = Convert.ToInt32(e.CommandArgument);

                //--- Get primarry key value of the selected record.
                Int32 index = Convert.ToInt32(e.CommandArgument.ToString());
                Literal ind = (Literal)grdViewTest.Rows[index].FindControl("S_NO");
                // get Index
                string strS_no = ind.Text;
                int S_no = int.Parse(strS_no);
              

                //--- Set S_no in viewstate so that we can use in update process.
                ViewState["selectedRec"] = S_no.ToString();

                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

                

                String queryDelete = "DELETE FROM IE_ADMIN_NOTIFICATION WHERE S_NO = @S_no";

                SqlCommand cmd = new SqlCommand(queryDelete, connection);
                connection.Open();

                cmd.Parameters.AddWithValue("S_no", S_no);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connection.Close();
                loadNotification();
                lblAlert.Text = string.Empty;
                LabelUpdate.Text = "Record has been deleted successfully!";
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

            try
            {

                int S_No = Convert.ToInt32(ViewState["selectedRec"]);
                var datetime = DateTime.Today;
                string sysdate = datetime.ToString();



                String queryUpdate = "UPDATE IE_ADMIN_NOTIFICATION SET S_NO =@S_NO, NOTIFICATION_DATE =@NOTIFICATION_DATE, NOTIFICATION =@NOTIFICATION WHERE S_NO = @S_no";

                SqlCommand cmd = new SqlCommand(queryUpdate, connection);
                connection.Open();

                cmd.Parameters.AddWithValue("S_NO", S_No);
                cmd.Parameters.AddWithValue("NOTIFICATION_DATE", sysdate);
                cmd.Parameters.AddWithValue("NOTIFICATION", txNotification.Text);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connection.Close();
                loadNotification();

                txNotification.Text = string.Empty;
                LabelUpdate.Text = "Record successfully updated.";
                lblAlert.Text = string.Empty;
                LabelUpdate.ForeColor = Color.Green;
                Submit.Visible = true;
                Update.Visible = false;
                lblAlert.Text = string.Empty;
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