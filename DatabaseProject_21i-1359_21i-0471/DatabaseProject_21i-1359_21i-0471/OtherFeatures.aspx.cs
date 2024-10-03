using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class OtherFeatures : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // 4 Sub Queries
                    // Query 1: Avg Payments by user
                    SqlCommand cmd1 = new SqlCommand("SELECT U.Username, " +
                        "(SELECT AVG(P.Amount) FROM Payment P WHERE P.Username = U.Username) AS AveragePaymentAmount " +
                        "FROM Users U", connection);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();

                    // Query 2: Feedback Counts
                    SqlCommand cmd2 = new SqlCommand("SELECT U.Username, " +
                        "(SELECT COUNT(F.FeedbackID) FROM Feedback F WHERE F.Username = U.Username) AS FeedbackCount " +
                        "FROM Users U", connection);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    GridView2.DataSource = dt2;
                    GridView2.DataBind();

                    // Query 3: Pay rates
                    SqlCommand cmd3 = new SqlCommand("SELECT S.Username, S.Pay, " +
                        "(SELECT CASE " +
                        "WHEN S.Pay > 50 THEN 'High' " +
                        "WHEN S.Pay BETWEEN 30 AND 50 THEN 'Medium' " +
                        "ELSE 'Low' END) AS PayRateCategory " +
                        "FROM Staff S", connection);
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    GridView3.DataSource = dt3;
                    GridView3.DataBind();

                    // Query 4: Training Status
                    SqlCommand cmd4 = new SqlCommand("SELECT S.Username, S.TrainingStatus, " +
                        "(CASE " +
                        "WHEN S.TrainingStatus = 1 THEN 'Completed' " +
                        "ELSE 'Pending' END) AS TrainingStatusText " +
                        "FROM Staff S", connection);
                    SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                    DataTable dt4 = new DataTable();
                    da4.Fill(dt4);
                    GridView4.DataSource = dt4;
                    GridView4.DataBind();
                }
            }
        }


       

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("CafeManager.aspx");
        }

      
    }
}
