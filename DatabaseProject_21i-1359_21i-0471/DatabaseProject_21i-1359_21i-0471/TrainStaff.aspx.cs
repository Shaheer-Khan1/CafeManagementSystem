using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class TrainStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void BindGridView()
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True"; ;
            string query = "SELECT Username, TrainingStatus FROM Staff";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnTrain_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chkTrainingStatus = row.FindControl("chkTrainingStatus") as CheckBox;
                if (chkTrainingStatus != null && chkTrainingStatus.Checked)
                {
                    string username = GridView1.DataKeys[row.RowIndex].Value.ToString();
                    UpdateTrainingStatus(username, true); 
                }
                else
                {
                   
                }
            }

            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void UpdateTrainingStatus(string username, bool status)
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True"; ; // Replace with your actual connection string
            string updateQuery = "UPDATE Staff SET TrainingStatus = @Status WHERE Username = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {

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


        protected void return_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffManagement.aspx");
        }
    }
}
