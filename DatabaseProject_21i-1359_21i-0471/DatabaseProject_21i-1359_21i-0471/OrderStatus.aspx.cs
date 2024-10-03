using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class OrderStatus : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayRowInGridView(1);
            }


        }

        private void DisplayRowInGridView(int rowIndex)
        {
            BindGridView();

        }


        private void BindGridView()
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";
            string username = GetLoggedInUsername();
            //2 Table JOIN and aggregate query
            string query = @"SELECT p.Username, p.Amount, o.OrderStatus 
                     FROM Payment p
                     INNER JOIN OrderDetails o ON p.OrderID = o.OrderID
                     WHERE o.OrderStatus = 'confirmed'
                     AND p.Username = @username
                     GROUP BY p.Username, p.Amount, o.OrderStatus;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username); 

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                dataAdapter.Fill(dataTable);
                connection.Close();

                if (dataTable.Rows.Count > 0)
                {
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
                else
                {
                    dataTable.Rows.Add(dataTable.NewRow());
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                    int columnCount = GridView1.Columns.Count;
                    GridView1.Rows[0].Cells.Clear();
                    GridView1.Rows[0].Cells.Add(new TableCell());
                    GridView1.Rows[0].Cells[0].ColumnSpan = columnCount;
                    GridView1.Rows[0].Cells[0].Text = "No pending orders.";
                }
            }
        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
