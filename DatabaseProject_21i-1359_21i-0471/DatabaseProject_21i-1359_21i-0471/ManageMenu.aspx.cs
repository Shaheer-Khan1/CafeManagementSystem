using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class ManageMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void GoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CafeManager.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BindGridView()
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM MenuItems";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                GridView1.DataSource = reader;
                GridView1.DataBind();

                reader.Close();
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";


            int itemId = Convert.ToInt32(ItemID.Text);

            string itemName = ItemName.Text;
            int categoryID = 0;
            if (CategoryID.Text != "")
            {
                categoryID = Convert.ToInt32(CategoryID.Text);
            }
            decimal price = 0;
            if (Price.Text != "")
            {
                price = Convert.ToDecimal(Price.Text);
            }
            string availabilityStatus = null;
            if (AvailabilityStatus.Text != "")
            {
                availabilityStatus = AvailabilityStatus.Text;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE MenuItems SET ";
                List<string> updateFields = new List<string>();

                if (!string.IsNullOrEmpty(itemName))
                {
                    updateFields.Add("ItemName = @ItemName");
                }
                if (categoryID != 0)
                {
                    updateFields.Add("CategoryID = @CategoryID");
                }
                if (price != 0)
                {
                    updateFields.Add("Price = @Price");
                }
                if (!string.IsNullOrEmpty(availabilityStatus))
                {
                    updateFields.Add("AvailabilityStatus = @AvailabilityStatus");
                }

                updateQuery += string.Join(", ", updateFields) + " WHERE ItemID = @ItemID";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@ItemID", itemId);

                    if (!string.IsNullOrEmpty(itemName))
                    {
                        command.Parameters.AddWithValue("@ItemName", itemName);
                    }
                    if (categoryID != 0)
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryID);
                    }
                    if (price != 0)
                    {
                        command.Parameters.AddWithValue("@Price", price);
                    }
                    if (!string.IsNullOrEmpty(availabilityStatus))
                    {
                        command.Parameters.AddWithValue("@AvailabilityStatus", availabilityStatus);
                    }

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        BindGridView(); 
                    }
                    else
                    {
                    }
                }
            }
        }

    }
}
