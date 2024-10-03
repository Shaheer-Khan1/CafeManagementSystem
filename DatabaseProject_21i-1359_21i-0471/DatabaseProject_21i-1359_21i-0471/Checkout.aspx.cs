using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class Checkout : Page
    {
        decimal bill;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string loggedInUser = GetLoggedInUsername();

                if (!string.IsNullOrEmpty(loggedInUser))
                {
                    string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT SUM(Price * Quantity) AS TotalPrice FROM Cart WHERE Username = @Username";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Username", loggedInUser);

                        try
                        {
                            connection.Open();
                            object result = command.ExecuteScalar();
                            bill = Convert.ToDecimal(result);
                            if (result != DBNull.Value)
                            {

                                Label1.Text = "Total Price: $" + Convert.ToDecimal(result).ToString("0.00");
                            }
                            else
                            {
                                Label1.Text = "No items in the cart for the user.";
                            }
                        }
                        catch (Exception ex)
                        {
                            Label1.Text = "Error retrieving total price: " + ex.Message;
                        }
                    }
                }
                else
                {
                    Label1.Text = "User not logged in.";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string city = Request.Form["city"];
            string sector = Request.Form["sector"];
            string streetNo = Request.Form["streetNo"];
            string houseNo = Request.Form["houseNo"];
            string phoneNo = Request.Form["phoneNo"];
            string paymentOption = Request.Form["payment"];

            string loggedInUser = GetLoggedInUsername();

            if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(sector) ||
                string.IsNullOrEmpty(streetNo) || string.IsNullOrEmpty(houseNo) ||
                string.IsNullOrEmpty(phoneNo) || string.IsNullOrEmpty(paymentOption) ||
                string.IsNullOrEmpty(loggedInUser))
            {
                string script = "Validation();";
                ClientScript.RegisterStartupScript(this.GetType(), "ValidationScript", script, true);
            }
            else
            {
                string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO OrderDetails (Username, OrderStatus, OrderBill) VALUES (@Username, @OrderStatus, @OrderBill); SELECT SCOPE_IDENTITY();";
                        command.Parameters.AddWithValue("@Username", loggedInUser);
                        command.Parameters.AddWithValue("@OrderStatus", "Confirmed");

                        decimal totalBill = CalculateTotalBill(loggedInUser);

                        if (totalBill == 0)
                        {
                            Response.Redirect("Fries.aspx");
                        }
                        command.Parameters.AddWithValue("@OrderBill", totalBill);

                        int orderId = Convert.ToInt32(command.ExecuteScalar());

                        command.CommandText = "INSERT INTO OrderDescription (OrderDID, City, Sector, StreetNO, HouseNumber, PhoneNumber) VALUES (@OrderDID, @City, @Sector, @StreetNO, @HouseNumber, @PhoneNumber)";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@OrderDID", orderId);
                        command.Parameters.AddWithValue("@City", city);
                        command.Parameters.AddWithValue("@Sector", sector);
                        command.Parameters.AddWithValue("@StreetNO", streetNo);
                        command.Parameters.AddWithValue("@HouseNumber", houseNo);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNo);

                        command.ExecuteNonQuery();
                    }
                }

                switch (paymentOption)
                {
                    case "Cash On Delivery":
                        Response.Redirect("COD.aspx");
                        break;
                    case "Easypaisa":
                        Response.Redirect("Easypaisa.aspx");
                        break;
                    case "Debit Card":
                        Response.Redirect("Card.aspx");
                        break;
                    default:
                        
                        break;
                }
            }
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

        private decimal CalculateTotalBill(string loggedInUser)
        {
            decimal totalBill = 0;

            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(Price * Quantity) AS TotalPrice FROM Cart WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", loggedInUser);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            totalBill = Convert.ToDecimal(result);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            return totalBill;
        }




    }
}
