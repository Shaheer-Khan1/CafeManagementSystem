using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class Sign_In : System.Web.UI.Page
    {

        private string GetLoggedInUsername()
        {
            HttpCookie authCookie = Request.Cookies["CampusBitesAuth"];

            if (authCookie != null)
            {
                return authCookie["Username"];
            }

            return null;
        }

        protected void Signup_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

            string username = txtSignupEmail.Text.Trim(); 
            string password = txtSignupPassword.Text.Trim();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            HttpCookie authCookie = new HttpCookie("CampusBitesAuth");
                            authCookie["Username"] = username;
                           
                            Response.Cookies.Add(authCookie);

                            string userTypeQuery = "SELECT UserType FROM Users WHERE Username = @Username AND Password = @Password";

                            using (SqlCommand userTypeCommand = new SqlCommand(userTypeQuery, connection))
                            {
                                userTypeCommand.Parameters.AddWithValue("@Username", username);
                                userTypeCommand.Parameters.AddWithValue("@Password", password);

                                try
                                {
                                    string userType = userTypeCommand.ExecuteScalar()?.ToString();

                                    if (!string.IsNullOrEmpty(userType))
                                    {
                                        switch (userType)
                                        {
                                            case "cafemanager":
                                                Response.Redirect("CafeManager.aspx");
                                                break;
                                            case "cashier":
                                                Response.Redirect("Cashier.aspx");
                                                break;
                                            case "Inventorymanager":
                                                Response.Redirect("InventoryManager.aspx");
                                                break;
                                            case "\0":
                                                Response.Redirect("Customer.aspx"); 
                                                break;
                                           
                                        }
                                    }
                                    else
                                    {
                                        Response.Redirect("Customer.aspx");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    lblResponse.Text = "An error occurred: " + ex.Message;
                                }
                            }
                        }
                        else
                        {
                            lblResponse.Text = "Invalid username or password.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblResponse.Text = "An error occurred: " + ex.Message;
                    }
                }
            }
        }
    }
}
