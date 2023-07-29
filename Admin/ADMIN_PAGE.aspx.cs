using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Industrial_Engineering.IE_Kaizen.Admin
{
    public partial class ADMIN_PAGE : System.Web.UI.Page
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

        // System.Data.OracleClient.OracleTransaction transaction;
      

        protected void Page_Load(object sender, EventArgs e)
        {
            String username = (string)(Session["username"]);
            if (String.IsNullOrEmpty(username))
            {
                HttpContext.Current.Response.Redirect("~/IE_Central_Login.aspx");
            }
            if (!IsPostBack) { 
            FillDepartment();
            FillDiscipline();
            FillRole();
            loadGridview();
            }
        }

        private void FillRole()
        {
            
            string roleListQuery = "select ROLE from IE_KAIZEN_PLANT_ROLE_CREDS";
            SqlCommand cmd = new SqlCommand(roleListQuery, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Role.DataSource = dr;
            Role.DataTextField = "ROLE";
            Role.DataValueField = "ROLE";
            Role.DataBind();
            //dr.Close();
            dr.Dispose();
            connection.Close();
        }

        private void FillDiscipline()
        {
            
            string disciplineListQuery = "select DISCIPLINE from IE_KAIZEN_PLANT_DISCIPLINE_CREDS";
            SqlCommand cmd = new SqlCommand(disciplineListQuery, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Discipline.DataSource = dr;
            Discipline.DataTextField = "DISCIPLINE";
            Discipline.DataValueField = "DISCIPLINE";
            Discipline.DataBind();
            //dr.Close();
            dr.Dispose();
            connection.Close();
        }

        private void FillDepartment()
        {
            
            string departmentListQuery = "select Department from IE_KAIZEN_PLANT_DEPARTMENT_CREDS";
            SqlCommand cmd = new SqlCommand(departmentListQuery, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Department.DataSource = dr;
            Department.DataTextField = "DEPARTMENT";
            Department.DataValueField = "DEPARTMENT";
            Department.DataBind();
            //dr.Close();
            dr.Dispose();
            connection.Close();

        }

        protected void Register_Click(object sender, EventArgs e)
        {

            if (Employee_Number.Text == string.Empty)
            {
                Employee_Number_label.Text = "Please enter Employee Number";
            }
            if (FIRSTNAME.Text == string.Empty)
            {
                FIRSTNAME_label.Text = "Please enter FIRSTNAME";
            }
            if (LASTNAME.Text == string.Empty)
            {
                LASTNAME_label.Text = "Please enter LASTNAME";
            }

            if (string.IsNullOrEmpty(Employee_Number.Text) || string.IsNullOrEmpty(FIRSTNAME.Text) || string.IsNullOrEmpty(LASTNAME.Text)
                || string.IsNullOrEmpty(Department.SelectedItem.Value) || string.IsNullOrEmpty(Discipline.SelectedItem.Value) || string.IsNullOrEmpty(Role.SelectedItem.Value)
                )
            {
                Register_User_label.Text = "Please fill in all fields before submitting form";
            }
            else
            {
                if (checkUser()) { 
                Insertuser();
                loadGridview();
                }
                else
                {
                    Register_User_label.Text = "Employee No and Role combination has already been registered!";
                    loadGridview();
                }
            }
        }

        private void Insertuser()
        {
            using (connection)
            {
                try
                {

                    string employeeNo = Employee_Number.Text;
                    string firstName = FIRSTNAME.Text;
                    string lastName = LASTNAME.Text;
                    string department = Department.SelectedItem.Text;
                    string discipline = Discipline.SelectedItem.Text;
                    string role = Role.SelectedItem.Text;
                    connection.Open();
                    //transaction = connection.BeginTransaction();
                    string queryuserinsert = "INSERT INTO IE_ADMIN (EMPLOYEE_NO, FIRSTNAME, LASTNAME, DEPARTMENT, DISCIPLINE, ROLE) VALUES (@employeeNo, @firstName, @lastName, @department, @discipline, @role)";
                    SqlCommand cmd = new SqlCommand(queryuserinsert, connection);
                    
                    //commanduserinsert.Connection = connection;
                    //commanduserinsert.Transaction = transaction;

                    cmd.Parameters.AddWithValue("employeeNo", employeeNo);
                    cmd.Parameters.AddWithValue("firstName", firstName);
                    cmd.Parameters.AddWithValue("lastName", lastName);
                    cmd.Parameters.AddWithValue("department", department);
                    cmd.Parameters.AddWithValue("discipline", discipline);
                    cmd.Parameters.AddWithValue("role", role);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                    //transaction.Commit();
                    //ClientScript.RegisterStartupScript(this.GetType(), "showPopUp", "showPopUp();", true);
                    Register_User_label.Text = "User has been registred successfully!";
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                    //transaction.Rollback();
                    // StatusLabelp.Text = "Data is not updated ";
                    connection.Close();
                    return;
                }
                finally
                {
                    Employee_Number.Text = string.Empty;
                    FIRSTNAME.Text = string.Empty;
                    LASTNAME.Text = string.Empty;
                    Department.SelectedItem.Value = null;
                    Discipline.SelectedItem.Value = null;
                    Role.SelectedItem.Value = null;
                    connection.Close();
                }
            }
        }

        private bool checkUser()
        {
            try{
       
            string departmentListQuery = "select EMPLOYEE_NO,ROLE from IE_Admin";
            SqlCommand cmd = new SqlCommand(departmentListQuery, connection);

            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    String empno = Convert.ToString(dr["EMPLOYEE_NO"]);
                    String role = Convert.ToString(dr["ROLE"]);

                    if (Employee_Number.Text == empno && Role.SelectedItem.Text == role)
                    {
                        return false;
                    }
                }
            }

            //dr.Close();
            dr.Dispose();
            connection.Close();
            return true;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        private void loadGridview()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);
             try
            {
                String queryRetrive = "SELECT * FROM IE_ADMIN ORDER BY EMPLOYEE_NO ASC";
                SqlCommand cmd = new SqlCommand(queryRetrive, connection);

                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Dispose();
                SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                dataadapter.Fill(dataset);
                grdViewAdminPage.DataSource = dataset.Tables[0];
                grdViewAdminPage.DataBind();


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
    }
}