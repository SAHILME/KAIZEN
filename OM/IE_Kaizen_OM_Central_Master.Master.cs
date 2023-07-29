using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Industrial_Engineering.IE_Kaizen.OM
{
    public partial class IE_Kaizen_OM_Central_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LogOut(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Central_Logout.aspx");
        }

        protected void PendingforApproval_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/OM/OMDashboard.aspx");
        }

        protected void EvaluatorRejectedKaizenbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/OM/EvaluatorRejectedKaizen.aspx");
        }

        protected void RejectedKaizen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/OM/RejectedKaizens.aspx");
        }

        protected void ApprovedByOM_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/OM/ApprovedKaizens.aspx");
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Role_Dashboard.aspx");
        }

        protected void Logoutbtnbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Central_Logout.aspx");
        }
    }
}