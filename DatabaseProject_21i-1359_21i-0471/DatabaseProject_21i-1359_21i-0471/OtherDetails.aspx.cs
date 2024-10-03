using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class OtherDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

                // Query 1: Category with lowest average price
                string queryLowestAvgPrice = @"
            SELECT c.CategoryID, c.CategoryName, AVG(mi.Price) AS AvgItemPrice
            FROM Categories c
            JOIN MenuItems mi ON c.CategoryID = mi.CategoryID
            GROUP BY c.CategoryID, c.CategoryName
            HAVING AVG(mi.Price) = (
                SELECT MIN(avg_price)
                FROM (
                    SELECT AVG(Price) AS avg_price
                    FROM MenuItems
                    GROUP BY CategoryID
                ) AS AvgPrices
            )";

                // Query 2: Categories with average price greater than 20
                string queryAvgPriceGreaterThan20 = @"
            SELECT c.CategoryID, c.CategoryName, AVG(mi.Price) AS AvgItemPrice
            FROM Categories c
            JOIN MenuItems mi ON c.CategoryID = mi.CategoryID
            GROUP BY c.CategoryID, c.CategoryName
            HAVING AVG(mi.Price) > 20";

                // Query 3: Additional query for Cart, OrderDetails, OrderDescription, Payment
                string queryCartOrderPayment = @"
            SELECT 
                C.CartItemId AS CartID,
                C.ItemID,
                C.ItemName,
                C.Price,
                C.Quantity,
                OD.OrderID,
                OD.OrderStatus,
                OD.City,
                OD.Sector,
                OD.StreetNO,
                OD.HouseNumber,
                OD.PhoneNumber,
                P.Amount
            FROM 
                Cart C
            LEFT JOIN 
                OrderDetails OD ON C.Username = OD.Username
            LEFT JOIN 
                OrderDescription OD ON OD.OrderDID = OD.OrderID
            LEFT JOIN 
                Payment P ON OD.OrderID = P.OrderID
            WHERE 
                C.Username = 'A'";

                // Query 4: Orders with a total bill greater than 150
                string queryOrdersTotalBillGreaterThan150 = @"
            SELECT OrderID, SUM(OrderBill) AS TotalBill
            FROM OrderDetails
            GROUP BY OrderID
            HAVING SUM(OrderBill) > 150";

                // Execute queries and bind data to GridViews
                BindGridView(GridView1, queryLowestAvgPrice, connectionString);
                BindGridView(GridView2, queryAvgPriceGreaterThan20, connectionString);
                BindGridView(GridView3, queryCartOrderPayment, connectionString);
                BindGridView(GridView4, queryOrdersTotalBillGreaterThan150, connectionString);
            }
        }
        private void BindGridView(GridView gridView, string query, string connectionString)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                gridView.DataSource = dt;
                                gridView.DataBind();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}