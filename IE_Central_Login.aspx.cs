using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.DirectoryServices;
using System.Data.SqlClient;

namespace Industrial_Engineering
{
    public partial class IE_Central_Login : System.Web.UI.Page
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SmallNo();
            }
            finalmsgLabel1.Text = string.Empty;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            // Session["KaizenUser"] = txtEmployeeNo.Text;
            if (string.IsNullOrEmpty(txtEmployeeNo.Text) && string.IsNullOrEmpty(txtPassword.Text))
            {
                finalmsgLabel1.Text = "Please enter Employee Number and Password";
                SmallNo();
                return;
            }
            else if (txtEmployeeNo.Text == string.Empty)
            {
                finalmsgLabel1.Text = "Please enter Employee Number.";
                SmallNo();
                return;
            }
            else if (txtPassword.Text == string.Empty)
            {
                finalmsgLabel1.Text = "Please enter Employee Password.";
                SmallNo();
                return;
            }
            else if (!validatecapt())
            {
                finalmsgLabel1.Text = "Captcha is wrong, please retry!";
                SmallNo();
                return;
            }
            else 
            {
                Boolean blogin;
                blogin = CallOfficer();
                if(blogin)
                {
                    Response.Redirect("~/Project_Navigation.aspx", false);
                }
                else
                {
                    finalmsgLabel1.Text = "Invalid user name or Password!";
                    SmallNo();
                    return;
                }
            }
        }

        public void SmallNo()
        {
            lbl1.Text = string.Empty;

            lbl1.Text += "Enter the Smaller Number between: ";
            Random rnd = new Random();
            int a = rnd.Next(100, 999);
            lbl1.Text += a;


            lbl1.Text += " and ";

            int b = rnd.Next(100, 999);
            lbl1.Text += b;

            String answer;
            if (a == b)
            {
                answer = a.ToString();
                Session["answer"] = answer;
            }
            if (a > b)
            {
                answer = b.ToString();
                Session["answer"] = answer;
            }
            if (b > a)
            {
                answer = a.ToString();
                Session["answer"] = answer;
            }
        }

        public bool validatecapt()
        {
            String user_entered = txt1.Text;
            String answer = (string)(Session["answer"]);

            if (answer == user_entered)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean CallOfficer()
        {
            Boolean bblogin = false;
            try
            {
                string dominName = string.Empty;
                string adPath = string.Empty;
                String username = txtEmployeeNo.Text;
                String password = txtPassword.Text;
                string strError = string.Empty;
                
                foreach (string key in ConfigurationSettings.AppSettings.Keys)
                {
                    dominName = key.Contains("DirectoryDomain") ? ConfigurationSettings.AppSettings[key] : dominName;
                    adPath = key.Contains("DirectoryPath") ? ConfigurationSettings.AppSettings[key] : adPath;

                    if (!String.IsNullOrEmpty(dominName) && !String.IsNullOrEmpty(adPath))
                    {
                        if (true == AuthenticateUser(dominName, username, password, adPath, out strError))
                        {
                            //Response.Redirect("BookingCalender.aspx");// Authenticated user redirects to default.aspx
                            Session["username"] = username;
                            Session["KaizenUser"] = txtEmployeeNo.Text;
                            // OpenSystem();
                            bblogin = true;
                        }
                        else
                        {
                            bblogin = false;
                        }
                        dominName = string.Empty;
                        adPath = string.Empty;
                        if (String.IsNullOrEmpty(strError)) break;
                    }
                }
                /*if (!string.IsNullOrEmpty(strError))
                {
                    finalmsgLabel1.Text = "Invalid user name or Password!";

                    return;
                }
                else
                {
                   // Response.Redirect("IE_Kaizen/User/userDashboard.aspx");
                    //Response.Redirect("~/Project_Navigation.aspx",false);
                    //Context.ApplicationInstance.CompleteRequest();
                }*/
            }
            catch (Exception ex)
            {
                finalmsgLabel1.Text = "Something Went Wrong! - " + ex.Message;
            }
            finally
            {
                
            }
            return bblogin;
        }

        public bool AuthenticateUser(string domain, string username, string password, string LdapPath, out string Errmsg)
        {
            Errmsg = "";
            //string domainAndUsername = domain + @"\" + username;

            /*string domainAndUsername = domain + @"\" + "adshare";
            password = "Aug@2019";*/

            //string admin_username = "administrator";
            //string admin_password = "asds$2036";
            string domainAndUsername = domain + @"\" + username;
            //password = "Aug@2019";

            DirectoryEntry entry_admin = new DirectoryEntry(LdapPath, domainAndUsername, password);

            try
            {
                //Bind to the native AdsObject to force authentication.
                Object obj = entry_admin.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry_admin);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                search.PropertiesToLoad.Add("userAccountControl");
                SearchResult result = search.FindOne();

                if (null == result)
                {
                    Response.Write("AD Not Authenticated! - ");
                    return false;
                }
                else
                {
                    // Update the new path to the user in the directory
                    LdapPath = result.Path;
                    string _filterAttribute = (String)result.Properties["cn"][0];
                    Session["LoggedInUser"] = _filterAttribute;
                    Int32 account_value = (Int32)result.Properties["userAccountControl"][0];
                    if (account_value == 514)
                    {
                        Response.Write("Your Account Has Been Disabled!");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Errmsg = ex.Message;
                throw new Exception("Error authenticating user." + ex.Message);
                //return false;
            }
        }

       

        /*public void OpenSystem()
        {
            System.Data.OracleClient.OracleConnection connection = new System.Data.OracleClient.OracleConnection(connectionString);
            try
            {
                connection.Open();

                String queryBillData = "SELECT * FROM IE_KAIZEN_ADMINS WHERE USERID = '" + txtEmployeeNo.Text + "'";

                System.Data.OracleClient.OracleCommand commandBillData = new System.Data.OracleClient.OracleCommand(queryBillData, connection);
                System.Data.OracleClient.OracleDataReader readerBillData = commandBillData.ExecuteReader();

                if (readerBillData.HasRows)
                {
                    while (readerBillData.Read())
                    {
                        String USERGROUP = Convert.ToString(readerBillData["USERGROUP"]);
                        if (USERGROUP == "ADMIN")
                        {
                            Response.Redirect("ADMIN_PAGE.aspx");
                        }
                    }
                }
                else
                {
                    Response.Write("No Access To This System!");
                }
                readerBillData.Close();
                commandBillData.Dispose();
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
        }*/
        
    }
}