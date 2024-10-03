using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class StaffManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void VStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewStaff.aspx");
        }

        protected void Hire_Click(object sender, EventArgs e)
        {
            Response.Redirect("HireStaff.aspx");
        }

        protected void tStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("TrainStaff.aspx");
        }

        protected void SchedStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScheduleStaff.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CafeManager.aspx");
        }
    }
}