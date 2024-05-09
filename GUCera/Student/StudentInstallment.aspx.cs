using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class StudentInstallment : System.Web.UI.Page
    {
        protected void ViewInstallmentButton_Click(object sender, EventArgs e)
        {
            ClearLabels(); // Clears labels before each run

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                int studentId = (int)Session["UserID"];
               
               /* if (!int.TryParse(StudentIDTextBox.Text, out studentId))
                {
                    ErrorLabel.Text = "Please enter a valid student ID";
                    return;
                }

                if (!CheckStudentExists(conn, studentId))
                {
                    ErrorLabel.Text = "Student not found";
                    return;
                }*/

                SqlCommand cmd = new SqlCommand("SELECT dbo.FN_StudentUpcoming_installment(@student_ID)", conn);
                cmd.Parameters.AddWithValue("@student_ID", studentId);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        DateTime upcomingInstallment = Convert.ToDateTime(result);
                        UpcomingInstallmentLabel.Text = $"Upcoming Not-Paid Installment: {upcomingInstallment.ToShortDateString()}";
                    }
                    else
                    {
                        UpcomingInstallmentLabel.Text = "No upcoming not-paid installment found for this student.";
                    }
                }
                catch (Exception ex)
                {
                    ErrorLabel.Text = "An error occurred: " + ex.Message;
                }
            }
        }

        private bool CheckStudentExists(SqlConnection conn, int studentId)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Student WHERE student_id = @student_ID", conn);
            cmd.Parameters.AddWithValue("@student_ID", studentId);

            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();

            return count > 0;
        }

        private void ClearLabels()
        {
            UpcomingInstallmentLabel.Text = string.Empty;
            ErrorLabel.Text = string.Empty;
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home Page.aspx");
        }
    }
}

