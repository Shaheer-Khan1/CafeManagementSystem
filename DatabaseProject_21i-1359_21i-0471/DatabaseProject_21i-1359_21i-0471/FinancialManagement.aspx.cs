using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class FinancialManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataTable dt = GetDataFromDatabase(); 

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        private DataTable GetDataFromDatabase()
        {
            DataTable dt = new DataTable();
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT OD.OrderDID AS OrderID, P.PaymentID, P.Amount, OD.PhoneNumber " +
                                                "FROM OrderDescription OD " +
                                                "INNER JOIN Payment P ON OD.OrderDID = P.OrderID", connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CafeManager.aspx");
        }
    }
}
