using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Industrial_Engineering.IE_Kaizen.Coordinator
{
    public partial class IE_Kaizen_Coordinator_Central_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loggedinuserlabel.Text = (string)(Session["username"]);
            }
        }
        protected void LogOut(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Central_Logout.aspx");
        }

        protected void PendingforRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Coordinator/CoordinatorDashboard.aspx");
        }

        protected void ForwardedKaizenbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Coordinator/CO_Forward_Kaizen_List.aspx");
        }

        protected void RejectedKaizen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Coordinator/CO_Rejected_Kaizen_List.aspx");
        }

        protected void ApprovedByOM_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Coordinator/CO_Kaizen_Presentation_Pending.aspx");
        }

        protected void Reportsection_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CoordinatorDashboard.aspx");
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Role_Dashboard.aspx");
        }

        protected void Logoutbtnbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Central_Logout.aspx");
        }

        protected void PendingForClosing_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Coordinator/CO_Kaizen_Closing_Pending.aspx");
        }

        protected void Closedbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Coordinator/CO_Kaizen_Closed_Done.aspx");
        }

        protected void Presentataiondonebtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Coordinator/CO_Kaizen_Presentation_Done.aspx");
        }
    }
}