using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Industrial_Engineering.IE_Kaizen.Evaluator
{
    public partial class IE_Kaizen_Evaluator_Central_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LogOut(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Central_Logout.aspx");
        }

        protected void PendingforEvaluation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Evaluator/EvaluatorDashboard.aspx");
        }

        protected void EvaluatedKaizenbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Evaluator/EvaluatedKaizen.aspx");
        }

        protected void RejectedKaizen_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Evaluator/RejectedKaizen.aspx");
        }

        protected void ApprovedByOM_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Kaizen/Evaluator/ApprovedByOM.aspx");
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Role_Dashboard.aspx");
        }

        protected void Logoutbtnbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IE_Central_Logout.aspx");
        }
    }
}