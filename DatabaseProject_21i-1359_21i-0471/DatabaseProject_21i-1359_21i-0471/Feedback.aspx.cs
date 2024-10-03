using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class Feedbakcaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsUserAuthenticated())
            {

                Response.Redirect("Sign_In.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

            string feedbackText = txtFeedback.Text.Trim(); 
            string loggedInUsername = GetLoggedInUsername();

            if (!string.IsNullOrEmpty(loggedInUsername))
            {
                SaveFeedbackToDatabase(connectionString, loggedInUsername, feedbackText);
                lblMessage.Visible = true;
                lblMessage.Text = "Thank you for your feedback!";
            }
            else
            {
                Response.Redirect("Sign_In.aspx");
            }
        }

        private bool IsUserAuthenticated()
        {
            return Request.Cookies["CampusBitesAuth"] != null;
        }

        private string GetLoggedInUsername()
        {
            HttpCookie authCookie = Request.Cookies["CampusBitesAuth"];

            if (authCookie != null)
            {
                return authCookie["Username"];
            }

            return null;
        }

        private void SaveFeedbackToDatabase(string connectionString, string username, string feedbackText)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Feedback (Username, FeedbackText, FeedbackDate) VALUES (@Username, @FeedbackText, @FeedbackDate)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@FeedbackText", feedbackText);
                command.Parameters.AddWithValue("@FeedbackDate", DateTime.Now);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
