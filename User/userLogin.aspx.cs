using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.DirectoryServices;

namespace Industrial_Engineering.IE_Kaizen.User
{
    public partial class userLogin : System.Web.UI.Page
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringTraining"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("userDashboard.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            Session["KaizenUser"] = txtEmployeeNo.Text;
            CallOfficer();

        }

        public void CallOfficer()
        {
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

                        }
                        dominName = string.Empty;
                        adPath = string.Empty;
                        if (String.IsNullOrEmpty(strError)) break;
                    }
                }
                if (!string.IsNullOrEmpty(strError))
                {
                    Response.Write("Invalid user name or Password!");
                }
                else
                {
                    //Response.Redirect("userDashboard.aspx");
                    Response.Redirect("~/Project_Navigation.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Something Went Wrong! - " + ex.Message);
            }
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