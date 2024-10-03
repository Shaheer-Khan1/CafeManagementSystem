using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class MainPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string usernameToCreate = "ShaheerCM";
                string passwordToCreate = "123456";
                string userType = "cafemanager";

                string meshalUsername = "MeshalIM";
                string meshalPassword = "123456";
                string meshalUserType = "Inventorymanager";

                string khanUsername = "KhanCashier";
                string khanPassword = "123456";
                string khanUserType = "cashier";

                string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";
                string checkExistingUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(checkExistingUserQuery, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@Username", usernameToCreate);
                            int existingUserCount = (int)command.ExecuteScalar();

                            if (existingUserCount == 0)
                            {
                                InsertUser(usernameToCreate, passwordToCreate, userType, connection);
                            }
                            else
                            {
                            }

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@Username", meshalUsername);
                            existingUserCount = (int)command.ExecuteScalar();

                            if (existingUserCount == 0)
                            {
                                InsertUser(meshalUsername, meshalPassword, meshalUserType, connection);
                            }
                            else
                            {
                            }

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@Username", khanUsername);
                            existingUserCount = (int)command.ExecuteScalar();

                            if (existingUserCount == 0)
                            {
                                InsertUser(khanUsername, khanPassword, khanUserType, connection);
                            }
                            else
                            {
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("An error occurred: " + ex.Message);
                }
            }
        }

        private void InsertUser(string username, string password, string userType, SqlConnection connection)
        {
            string insertQuery = "INSERT INTO Users (Username, Password, UserType) VALUES (@Username, @Password, @UserType)";

            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@Username", username);
                insertCommand.Parameters.AddWithValue("@Password", password);
                insertCommand.Parameters.AddWithValue("@UserType", userType);

                int rowsAffected = insertCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {

                }
                else
                {

                }
            }
        }

        protected void Signup_Click(object sender, EventArgs e)
        {
            string signupEmail = txtSignupEmail.Text.Trim();
            string signupPassword = txtSignupPassword.Text.Trim();

            if (!string.IsNullOrEmpty(signupEmail) && !string.IsNullOrEmpty(signupPassword))
            {

                string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

                string insertQuery = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Username", signupEmail);
                            command.Parameters.AddWithValue("@Password", signupPassword);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                Response.Write("User registered successfully!");
                            }
                            else
                            {
                                Response.Write("Failed to register user. Please try again.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    Response.Write("An error occurred: " + ex.Message);
                }
            }
            else
            {
                Response.Write("Please provide both email and password!");
            }
        }

    }
}
