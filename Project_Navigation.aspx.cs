using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Industrial_Engineering
{
    public partial class Project_Navigation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           String username = (string)(Session["username"]);
           if (String.IsNullOrEmpty(username))
           {
               HttpContext.Current.Response.Redirect("~/IE_Central_Logout.aspx");
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Role_Dashboard.aspx");
        }
    }
}