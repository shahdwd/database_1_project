using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class addmexam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string type = TextBox1.Text;
            DateTime examd;
            if (!int.TryParse(TextBox3.Text, out int cID))
            {
                ClearLabels();
                Error.Text="Invalid Course ID. Please enter a valid course ID value.";
                return;
            }
            if (!DateTime.TryParse(TextBox2.Text, out examd))
            {
                ClearLabels();
                Error.Text = "Invalid Date. Please enter a valid date in the correct format.";
                return;
            }
            if (examd < DateTime.Now)
            {
                ClearLabels();
                Error.Text = "Invalid Date. Please enter upcomping date";
                return;
            }
            if (type != "First_makeup" && type != "Second_makeup" && type != "Normal")
            {
                ClearLabels();
                Error.Text = "Invalid Exam Type. Please enter a valid type (First_makeup, Second_makeup, Normal).";
                return;
            }
            SqlCommand checkCourse = new SqlCommand("SELECT COUNT(*) FROM Course WHERE course_id = @courseID", conn);
            checkCourse.Parameters.Add(new SqlParameter("@courseID", cID));
            try
            {
                conn.Open();
                int courseCount = (int)checkCourse.ExecuteScalar();

                if (courseCount == 0)
                {
                    ClearLabels();
                    Error.Text = $"No course found with Course ID {cID}. Cannot add an exam.";
                    return;
                    
                }
                SqlCommand checkExistingExam = new SqlCommand("SELECT COUNT(*) FROM MakeUp_Exam WHERE type = @Type AND date = @date AND course_id = @courseID", conn);
                checkExistingExam.Parameters.Add(new SqlParameter("@Type", type));
                checkExistingExam.Parameters.Add(new SqlParameter("@date", examd));
                checkExistingExam.Parameters.Add(new SqlParameter("@courseID", cID));

                int existingExamCount = (int)checkExistingExam.ExecuteScalar();

                if (existingExamCount > 0)
                {
                    ClearLabels();
                    Error.Text = "An exam with the same type, date, and course ID already exists.";
                    return;
                }
                SqlCommand addmexam = new SqlCommand("Procedures_AdminAddExam", conn);
                addmexam.CommandType = CommandType.StoredProcedure;
                addmexam.Parameters.Add(new SqlParameter("@Type", type));
                addmexam.Parameters.Add(new SqlParameter("@date", examd));
                addmexam.Parameters.Add(new SqlParameter("@courseID", cID));

                addmexam.ExecuteNonQuery();
                ClearLabels();
                Success.Text = "Exam has been added successfully";
            }
            catch (Exception ex)
            {
                ClearLabels();
                Error.Text = "Error: " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        private void ClearLabels()
        {
            Error.Text = "";
            Success.Text = "";
        }
    }
}