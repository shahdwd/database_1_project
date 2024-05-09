using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class adminlinkstci : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void btnMP4_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void btnSubmit4_Click(object sender, EventArgs e)
        {
            string courseId = string.IsNullOrEmpty(txtCourseId4.Text) ? null : txtCourseId4.Text;
            string instructorId = string.IsNullOrEmpty(txtInstructorId4.Text) ? null : txtInstructorId4.Text;
            string studentId = string.IsNullOrEmpty(txtStudentId4.Text) ? null : txtStudentId4.Text;
            string semesterCode = string.IsNullOrEmpty(txtSemesterCode4.Text) ? null : txtSemesterCode4.Text;

            if (courseId == null || instructorId == null || studentId == null || semesterCode == null)
            {
                Response.Write("<strong>Error:</strong> Please enter values for all fields.");
                return;
            }

            int courseIdInt, instructorIdInt, studentIdInt;

            if (!int.TryParse(courseId, out courseIdInt) || !int.TryParse(instructorId, out instructorIdInt) || !int.TryParse(studentId, out studentIdInt))
            {
                Response.Write("<strong>Error:</strong> Please enter valid numeric values for Course ID, Instructor ID, and Student ID.");
                return;
            }

            if (!ValidateSemesterCode(semesterCode))
            {
                return;
            }
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Procedures_AdminLinkStudent", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cours_id", courseIdInt);
                    cmd.Parameters.AddWithValue("@instructor_id", instructorIdInt);
                    cmd.Parameters.AddWithValue("@studentID", studentIdInt);
                    cmd.Parameters.AddWithValue("@semester_code", semesterCode);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("<strong>Success:</strong> Record updated successfully.");
                    }
                    else
                    {
                        Response.Write("<strong>Error:</strong> One of the inputs is null or invalid.");
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    Response.Write("<strong>Error:</strong> Student ID, Course ID, or Instructor ID not found in the database.");
                }
                else if (ex.Number == 2627)
                {
                    Response.Write("<strong>Error:</strong> Link already exists in the database.");
                }
                else
                {
                    Response.Write("<strong>Error:</strong> An error occurred: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<strong>Error:</strong> An unexpected error occurred: " + ex.Message);
            }
        }

        private bool SemesterCodeExists(string semesterCode)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Semester WHERE semester_code = @semesterCode", conn);
                    cmd.Parameters.AddWithValue("@semesterCode", semesterCode);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
            catch (SqlException ex)
            {
                Response.Write("<strong>Error:</strong> An error occurred while checking semester code: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Response.Write("<strong>Error:</strong> An unexpected error occurred: " + ex.Message);
                return false;
            }
        }

        private bool ValidateSemesterCode(string code)
        {
            code = code.ToUpper();
            if (code.Length < 3)
            {
                return false;
            }

            char firstChar = code[0];
            string remainingChars = code.Substring(1);

            if ((firstChar == 'W' && remainingChars.Length == 2) || (firstChar == 'S' && remainingChars.Length == 2))
            {
                if (firstChar == 'S' && remainingChars.EndsWith("R"))
                {
                    string integerPart = remainingChars.Substring(0, remainingChars.Length - 1);
                    int result;
                    if (int.TryParse(integerPart, out result) && SemesterCodeExists(code))
                    {
                        return true;
                    }
                }
                else
                {
                    int result;
                    if (int.TryParse(remainingChars, out result) && SemesterCodeExists(code))
                    {
                        return true;
                    }
                }
            }

            Response.Write("<strong>Error:</strong> Semester code doesn't exist in the database.");
            return false;
        }
    }
}