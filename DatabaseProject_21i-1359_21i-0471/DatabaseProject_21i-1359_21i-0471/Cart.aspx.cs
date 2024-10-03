using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartData();
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

        private void BindCartData()
        {
            string loggedInUsername = GetLoggedInUsername();

            if (!string.IsNullOrEmpty(loggedInUsername))
            {

                string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT CartItemID, Username, Quantity , ItemName, ItemID , Price " +
                                   "FROM cart " +
                                   "WHERE Username = @Username";


                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", loggedInUsername);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();

                    connection.Open();
                    adapter.Fill(dt);
                    connection.Close();

                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {

                        GridView1.DataSource = null;
                        GridView1.DataBind();

                    }
                }
            }
            else
            {

            }
        }

        int ItemIDtoDelete;
        int QuantitytoEdit;
        int ItemIDtoEdit;

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            int parsedItemID;
            if (int.TryParse(((TextBox)sender).Text, out parsedItemID))
            {

                QuantitytoEdit = parsedItemID;
            }
            else
            {

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

            string query = "DELETE FROM Cart WHERE CartItemID = @CartItemID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CartItemID", ItemIDtoDelete);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        BindCartData();
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {

                }
            }
        }



        protected void ItemID_TextChanged(object sender, EventArgs e)
        {
            int parsedItemID;
            if (int.TryParse(((TextBox)sender).Text, out parsedItemID))
            {

                ItemIDtoDelete = parsedItemID;
            }
            else
            {

            }
        }


        protected void Quantity_TextChanged(object sender, EventArgs e)
        {
            int parsedItemID;
            if (int.TryParse(((TextBox)sender).Text, out parsedItemID))
            {

                ItemIDtoEdit = parsedItemID;
            }
            else
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";


            string query = "UPDATE Cart SET Quantity = @Quantity WHERE CartItemID = @CartItemID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Quantity", QuantitytoEdit);
                command.Parameters.AddWithValue("@CartItemID", ItemIDtoEdit);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        
                        BindCartData();
                    }
                    else
                    { 
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}
