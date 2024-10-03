using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class Fullfill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView(); 
            }
        }

        private void BindGridView()
        {
            string constr = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM OrderDetails", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string orderId = ID.Text.Trim();

            if (!string.IsNullOrEmpty(orderId))
            {
                string constr = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

                if (OrderExists(orderId, constr))
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE OrderDetails SET OrderStatus = 'Fulfilled' WHERE OrderID = @OrderID", con))
                        {
                            cmd.Parameters.AddWithValue("@OrderID", orderId);
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            con.Close();

                            if (rowsAffected > 0)
                            {
                              
                                BindGridView();
                               
                                Response.Write("Order status updated successfully.");
                            }
                            else
                            {

                                Response.Write("Failed to update order status.");
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("Order ID not found.");
                }
            }
            else
            {
                Response.Write("Please enter an Order ID.");
            }
        }

        private bool OrderExists(string orderId, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM OrderDetails WHERE OrderID = @OrderID", con))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    con.Close();
                    return count > 0;
                }
            }
        }


    }
}
