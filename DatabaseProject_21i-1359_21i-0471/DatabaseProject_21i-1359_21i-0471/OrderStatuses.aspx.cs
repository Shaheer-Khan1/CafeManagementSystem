using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class OrderStatuses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

                //3 Table 
                string query = @"SELECT OD.OrderID,
                                        OD.Username,
                                        OD.OrderStatus,
                                        P.Amount AS PaymentAmount
                                 FROM OrderDetails OD
                                 INNER JOIN OrderDescription ODesc ON OD.OrderID = ODesc.OrderDID
                                 LEFT JOIN Payment P ON OD.OrderID = P.OrderID
                                 INNER JOIN Users U ON OD.Username = U.Username";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    DataSet dataSet = new DataSet();

                    try
                    {
                        connection.Open();

                        adapter.Fill(dataSet, "OrderDetails");

                        GridView1.DataSource = dataSet.Tables["OrderDetails"];
                        GridView1.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        protected void return_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cashier.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
