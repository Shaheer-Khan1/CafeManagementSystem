using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class ScheduleStaff : System.Web.UI.Page
    {

        private void LoadDataIntoGridView()
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True"; // Replace with your database connection string
            string query = "SELECT * FROM Staff";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                    else
                    {
                    }
                }
                catch (SqlException ex)
                {
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataIntoGridView();
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffManagement.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string username = Username.Text.Trim();
            DateTime startTime, endTime;

            if (DateTime.TryParse(StartTime.Text, out startTime) && DateTime.TryParse(EndTime.Text, out endTime))
            {

                string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";// Replace with your database connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Staff SET ScheduleStart = @StartTime, ScheduleEnd = @EndTime WHERE Username = @Username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@StartTime", startTime);
                    command.Parameters.AddWithValue("@EndTime", endTime);
                    command.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)

                        {
                            LoadDataIntoGridView();

                        }
                        else
                        {

                        }
                    }
                    catch (SqlException ex)
                    {

                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            else
            {

            }
        }

    }
}