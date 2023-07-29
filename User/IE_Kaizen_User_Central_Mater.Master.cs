using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Industrial_Engineering.IE_Kaizen.User
{
    public partial class IE_Kaizen_User_Central_Mater : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            loggedinuserlabel.Text = (string)(Session["username"]);
            }
        }
        protected void LogOut(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Central_Logout.aspx");
        }

        protected void NewKaizenbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/User/UserDashboard.aspx");
        }

        protected void saveasdraftbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/User/SaveasdraftKaizen.aspx");
        }

        protected void mykaizenpage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/User/MyKaizens.aspx");
        }

        protected void Summary_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/User/SummaryPage.aspx");
        }

        protected void Logoutbtnbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Central_Logout.aspx");
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Role_Dashboard.aspx");
        }

        
    }
}