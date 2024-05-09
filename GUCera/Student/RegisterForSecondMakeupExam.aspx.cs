using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class RegisterForSecondMakeupExam : System.Web.UI.Page
    {
        protected void RegisterForSecondMakeupExamButton_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                int studentID = (int)Session["UserID"]; 
                int courseID;
                string currentSemester;

                if (!int.TryParse(CourseIDTextBox.Text, out courseID))
                {
                    // Display error message or handle invalid inputs
                    Response.Write("Invalid input for Course ID.");
                    return;
                }

                currentSemester = CurrentSemesterTextBox.Text;

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Procedures_StudentRegisterSecondMakeup", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@CourseID", courseID);
                    cmd.Parameters.AddWithValue("@studentCurr_sem", currentSemester);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Registration successful, display success message or handle appropriately
                        Response.Write("Registration for second makeup exam successful!");
                    }
                    else
                    {
                        // Registration failed, display error message or handle appropriately
                        Response.Write("Failed to register for second makeup exam.");
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions or display error message
                    Response.Write("An error occurred: " + ex.Message);
                }
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home Page.aspx");
        }
    }
}