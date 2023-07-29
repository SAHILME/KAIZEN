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

namespace Industrial_Engineering.IE_Kaizen.Evaluator
{
    public partial class AllotmarkstoKaizen : System.Web.UI.Page
    {
        public SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSql"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            GetDataFromDatabaseAndDisplay();
        }

        private void GetDataFromDatabaseAndDisplay()
        {
            try
            {
                string selectQuery = "SELECT * FROM IE_EV_OM_QUESTION_DETAILS";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
               
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        HtmlTableRow row = new HtmlTableRow();
                        HtmlTableCell cell1 = new HtmlTableCell();
                        HtmlTableCell cell2 = new HtmlTableCell();

                        //cell1.ColSpan = 3;
                        cell1.InnerText = dr["Questionaire"].ToString();
                        cell2.InnerText = dr["Questionaire"].ToString();
                       
                        row.Cells.Add(cell1);
                        row.Cells.Add(cell2);
                        tableContent.Rows.Add(row);
                    }
                }


                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                connection.Close();

            }
            finally
            {
                connection.Close();
            }
        }
    }
}