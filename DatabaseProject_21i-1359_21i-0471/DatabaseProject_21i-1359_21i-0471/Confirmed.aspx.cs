using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class Confirmed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

            string loggedInUsername = GetLoggedInUsername();

            if (loggedInUsername != null)
            {
                DataTable dt = new DataTable();

                //4 Table Join
                string selectQuery  = @"SELECT TOP 1
    C.CartItemId AS CartID,
    OD.OrderID,
    OD.OrderStatus,
    OD.OrderBill,
    ODsc.PhoneNumber
FROM 
    Cart C
JOIN 
    OrderDetails OD ON C.Username = OD.Username
JOIN 
    OrderDescription ODsc ON OD.OrderID = ODsc.OrderDID
JOIN
    Users U ON OD.Username = U.Username
WHERE 
    U.Username = @loggedInUsername
GROUP BY 
    C.CartItemId, OD.OrderID, OD.OrderStatus, OD.OrderBill, ODsc.PhoneNumber
HAVING 
    SUM(C.Price * C.Quantity) > 0  
ORDER BY 
    OD.OrderID DESC;";



                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@loggedInUsername", loggedInUsername);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);

                        }
                    }
                }

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                // Handle case when user is not logged in
                // For example, display a message or redirect to a login page
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }




        protected void backButton_Click(object sender, EventArgs e)
        {
            string loggedInUsername = GetLoggedInUsername();

            if (loggedInUsername != null)
            {

                int orderId = GetOrderIdForUser(loggedInUsername);

                if (orderId != -1)
                {

                    decimal totalBill = CalculateTotalBill(loggedInUsername);

                    InsertIntoPaymentTable(loggedInUsername, totalBill, orderId);
                }
                else
                {
                }
            }
            else
            {
            }

            DeleteCartItemsForUser(loggedInUsername);   
            Response.Redirect("Customer.aspx");


        }

        private void DeleteCartItemsForUser(string username)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True"))
            {
                string deleteQuery = "DELETE FROM Cart WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        private int GetOrderIdForUser(string username)
        {
            int orderId = -1;

            using (SqlConnection connection = new SqlConnection("Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True"))
            {
                string query = "SELECT OrderID FROM OrderDetails WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        orderId = Convert.ToInt32(result);
                    }
                }
            }

            return orderId;
        }
        private decimal CalculateTotalBill(string username)
        {
            decimal totalBill = 0;

            
            using (SqlConnection connection = new SqlConnection("Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True"))
            {
                string query = "SELECT SUM(Price * Quantity) FROM Cart WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        totalBill = Convert.ToDecimal(result);
                    }
                }
            }

            return totalBill;
        }

        private void InsertIntoPaymentTable(string username, decimal amount, int orderId)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True"))
            {
                string query = "INSERT INTO Payment (Username, Amount, OrderID) VALUES (@Username, @Amount, @OrderID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@OrderID", orderId);

                    connection.Open();
                    command.ExecuteNonQuery();
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
    }
}