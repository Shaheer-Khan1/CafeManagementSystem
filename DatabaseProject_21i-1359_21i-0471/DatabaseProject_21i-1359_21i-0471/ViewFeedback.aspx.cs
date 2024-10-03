using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class ViewFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                //2 Table join
                string query = "SELECT F.Username, " +
                               "STUFF((SELECT ', ' + F2.FeedbackText " +
                               "FROM Feedback F2 WHERE F.Username = F2.Username " +
                               "FOR XML PATH('')), 1, 2, '') AS CombinedFeedbacks, " +
                               "STUFF((SELECT ', ' + CONVERT(VARCHAR, F3.FeedbackDate, 101) " +
                               "FROM Feedback F3 WHERE F.Username = F3.Username " +
                               "FOR XML PATH('')), 1, 2, '') AS CombinedFeedbackDates, " +
                               "O.OrderID " +
                               "FROM Feedback F " +
                               "INNER JOIN OrderDetails O ON F.Username = O.Username " +
                               "WHERE F.Username IN (SELECT DISTINCT Username FROM Feedback)";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

               
                if (dataTable.Rows.Count > 0)
                {
                    
                    dataTable.Columns.Add("CombinedOrderIDs", typeof(string));

                   
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string username = row["Username"].ToString();
                        DataRow[] orderRows = dataTable.Select($"Username = '{username}'");
                        string combinedOrderIDs = string.Join(", ", Array.ConvertAll(orderRows, r => r["OrderID"].ToString()));
                        row["CombinedOrderIDs"] = combinedOrderIDs;
                    }

                    DataTable distinctData = dataTable.DefaultView.ToTable(false, "Username", "CombinedFeedbacks", "CombinedFeedbackDates", "CombinedOrderIDs");

                    
                    DataTable distinctTable = distinctData.AsEnumerable()
                        .GroupBy(row => row.Field<string>("Username"))
                        .Select(group => group.First())
                        .CopyToDataTable();


                    if (distinctTable.Rows.Count > 0)
                    {
                        GridView1.DataSource = distinctTable;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle GridView row selection if needed
        }
    }
}
