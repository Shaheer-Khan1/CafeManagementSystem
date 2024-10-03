using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class Burger : System.Web.UI.Page
    {
        SqlConnection c = new SqlConnection("Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            //3 Tables Join
            SqlCommand cmd = new SqlCommand("SELECT MI.ItemID, MI.ItemName, MI.Price, I.IngredientName " +
                                             "FROM MenuItems MI " +
                                             "JOIN MenuItemIngredients MII ON MI.ItemID = MII.MenuItemID " +
                                             "JOIN Ingredients I ON MII.IngredientID = I.IngredientID " +
                                             "WHERE MI.AvailabilityStatus = 'Available' AND MI.CategoryID = 1;", c);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        string itemName = "";
        string category = "";
        string ingredients = "";
        decimal price = 0;
        bool isVariation = false;
        string availabilityStatus = "";
        int ID = 0;
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            int itemId;
            if (int.TryParse(QuantityText.Text, out itemId))
            {
                ID = itemId;


                string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ItemName, CategoryID, Price, AvailabilityStatus " +
                         "FROM MenuItems WHERE ItemID = @ItemId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ItemId", itemId);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        itemName = reader["ItemName"].ToString();
                        price = (decimal)reader["Price"];
                        availabilityStatus = reader["AvailabilityStatus"].ToString();
                    }
                    else
                    {
                    }

                    reader.Close();
                }


            }
            else
            {

            }
        }

        private int enteredQuantity = 0;

        protected void QuantityText_TextChanged(object sender, EventArgs e)
        {
            int quantity;
            if (int.TryParse(QuantityText.Text, out quantity))
            {

                enteredQuantity = quantity;
            }
            else
            {
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
        protected void Cart_Click(object sender, EventArgs e)
        {
            string username = GetLoggedInUsername();

            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string ID = ItemIdtext.Text;
                string enteredQuantity = QuantityText.Text;

                if (int.TryParse(ID, out int itemId) && int.TryParse(enteredQuantity, out int quantity))
                {

                }
                else
                {

                }
                if (!(string.IsNullOrEmpty(ItemIdtext.Text) || string.IsNullOrEmpty(QuantityText.Text)))
                {
                    string query = "INSERT INTO Cart (Username, ItemID, ItemName, Quantity, Price) " +
                               "VALUES (@Username, @ItemID, @ItemName, @Quantity, @Price); SELECT SCOPE_IDENTITY();";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@ItemID", enteredQuantity);
                    command.Parameters.AddWithValue("@ItemName", itemName);
                    command.Parameters.AddWithValue("@Quantity", ID);
                    command.Parameters.AddWithValue("@Price", price);

                    connection.Open();
                    object cartItemId = command.ExecuteScalar();

                    if (cartItemId != null)
                    {
                        int newCartItemId;
                        if (int.TryParse(cartItemId.ToString(), out newCartItemId))
                        {

                            Response.Write("Added to cart!");
                        }

                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please fill in both Item ID and Quantity.');", true);
                }
            }
        }


        protected void Checkout_Click(object sender, EventArgs e)
        {

            Response.Redirect("Cart.aspx");
        }

        protected void Menu_Click(object sender, EventArgs e)
        {

            Response.Redirect("Customer.aspx");
        }

    }
}
