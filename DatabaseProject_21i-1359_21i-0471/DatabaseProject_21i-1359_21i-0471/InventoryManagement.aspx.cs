using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class InventoryManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            int ingredientId = int.Parse(IngredientID.Text);
            string ingredientName = IngredientName.Text;

            UpdateIngredient(ingredientId, ingredientName);
            BindGrid();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            int ingredientIdToDelete = int.Parse(IngIDtoDLT.Text);

            DeleteIngredient(ingredientIdToDelete);
            BindGrid();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string itemNameToAdd = ItemNameToAdd.Text;

            InsertIngredient(itemNameToAdd);
            BindGrid();
        }

        private void BindGrid()
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Ingredients";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
        }

        private void UpdateIngredient(int ingredientId, string ingredientName)
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Ingredients SET IngredientName = @IngredientName WHERE IngredientID = @IngredientID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredientName", ingredientName);
                command.Parameters.AddWithValue("@IngredientID", ingredientId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void DeleteIngredient(int ingredientId)
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Ingredients WHERE IngredientID = @IngredientID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredientID", ingredientId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void InsertIngredient(string ingredientName)
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Ingredients (IngredientName) VALUES (@IngredientName)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredientName", ingredientName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
