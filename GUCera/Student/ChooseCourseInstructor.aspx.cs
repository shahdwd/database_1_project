using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Advising_System
{
    public partial class ChooseCourseInstructor : System.Web.UI.Page
    {
        protected void btnChooseInstructor_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtInstructorID.Text, out int instructorID) &&
                int.TryParse(txtCourseID.Text, out int courseID) &&
                !string.IsNullOrEmpty(txtSemesterCode.Text))
            {
                try
                {
                    int studentID = (int)Session["UserID"];
                    ChooseInstructor(studentID, instructorID, courseID, txtSemesterCode.Text);
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
                ErrorMessageLabel.Text = "Invalid input! Please enter valid IDs and semester code.";
            }
        }

        private void ChooseInstructor(int studentID, int instructorID, int courseID, string semesterCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.FN_StudentViewSlot(@CourseID, @InstructorID)", connection))
                {
                    cmd.Parameters.AddWithValue("@CourseID", courseID);
                    cmd.Parameters.AddWithValue("@InstructorID", instructorID);

                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    connection.Close();

                    YourGridView.DataSource = table;
                    YourGridView.DataBind();

                    if (table.Rows.Count == 0)
                    {
                        ErrorMessageLabel.Text = "No data found for the provided IDs.";
                    }
                    else
                    {
                        ErrorMessageLabel.Text = "Instructor chosen successfully!";
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