using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class CafeManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMenu.aspx");
        }

        protected void VFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewFeedback.aspx");
        }

        protected void FinancialM_Click(object sender, EventArgs e)
        {
            Response.Redirect("FinancialManagement.aspx");
        }

        protected void StaffM_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffManagement.aspx");
        }

        protected void InventoryM_Click(object sender, EventArgs e)
        {
            Response.Redirect("InventoryManagement.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("OtherFeatures.aspx");
        }

        protected void Audit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Audit.aspx");
        }
    }
};