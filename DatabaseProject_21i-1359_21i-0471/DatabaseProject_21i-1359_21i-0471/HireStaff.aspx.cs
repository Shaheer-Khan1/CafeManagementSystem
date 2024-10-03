using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject_21i_1359_21i_0471
{
    public partial class HireStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Hire_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=CampusBites;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

               
                string userQuery = "INSERT INTO Users (Username, Password, UserType) VALUES (@Username, @Password, @UserType)";

                string staffQuery = "INSERT INTO Staff (Username, TrainingStatus, ScheduleStart, ScheduleEnd, Pay) " +
                                    "VALUES (@Username, @TrainingStatus, @ScheduleStart, @ScheduleEnd, @Pay)";

                using (SqlCommand userCommand = new SqlCommand(userQuery, connection))
                {
                    userCommand.Parameters.AddWithValue("@Username", UserName.Text);
                    userCommand.Parameters.AddWithValue("@Password", Password.Text);
                    userCommand.Parameters.AddWithValue("@UserType", UserType.Text);

                    int userRowsAffected = userCommand.ExecuteNonQuery();

                    using (SqlCommand staffCommand = new SqlCommand(staffQuery, connection))
                    {
                        staffCommand.Parameters.AddWithValue("@Username", UserName.Text);
                        staffCommand.Parameters.AddWithValue("@TrainingStatus", Convert.ToBoolean(TrainingStatus.Text)); // Assuming TrainingStatus is boolean
                        staffCommand.Parameters.AddWithValue("@ScheduleStart", Convert.ToDateTime(SchedStart.Text)); // Assuming SchedStart is in DateTime format
                        staffCommand.Parameters.AddWithValue("@ScheduleEnd", Convert.ToDateTime(SchedEnd.Text)); // Assuming SchedEnd is in DateTime format
                        staffCommand.Parameters.AddWithValue("@Pay", Convert.ToDecimal(Pay.Text)); // Assuming Pay is in Decimal format

                        int staffRowsAffected = staffCommand.ExecuteNonQuery();

                        if (userRowsAffected > 0 && staffRowsAffected > 0)
                        {
                            Response.Write("User hired successfully!");
                        }
                        else
                        {
                            Response.Write("Failed to hire user.");
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffManagement.aspx");
        }
    }
}