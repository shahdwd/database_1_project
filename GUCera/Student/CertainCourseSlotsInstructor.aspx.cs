using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Advising_System
{
    public partial class CertainCourseSlotsInstructor : System.Web.UI.Page
    {
        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            ErrorMessageLabel.Text = ""; // Reset error message label
            GridViewSlots.DataSource = null; // Clear the GridView data source
            GridViewSlots.DataBind(); // Bind the empty data source to clear the GridView

            if (int.TryParse(txtCourseID.Text, out int courseID) && int.TryParse(txtInstructorID.Text, out int instructorID))
            {
                try
                {
                    BindGridView(courseID, instructorID);
                }
                catch (SqlException ex)
                {
                    ErrorMessageLabel.Text = "Database error: " + ex.Message;
                }
                catch (Exception ex)
                {
                    ErrorMessageLabel.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                ErrorMessageLabel.Text = "Invalid input! Please enter valid IDs.";
            }
        }

        protected void BindGridView(int courseID, int instructorID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;
            string query = "SELECT * FROM FN_StudentViewSlot(@CourseID, @InstructorID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CourseID", courseID);
                    cmd.Parameters.AddWithValue("@InstructorID", instructorID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();

                    connection.Open();
                    adapter.Fill(table);
                    connection.Close();

                    if (table.Rows.Count > 0)
                    {
                        GridViewSlots.DataSource = table;
                        GridViewSlots.DataBind();
                    }
                    else
                    {
                        ErrorMessageLabel.Text = "No data found for the provided IDs.";
                    }
                }
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home Page.aspx");
        }
    }
}
