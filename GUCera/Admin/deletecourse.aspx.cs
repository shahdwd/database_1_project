using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace GUCera
{
    public partial class deletecourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("AdminLogin.aspx", false);
                Context.ApplicationInstance.CompleteRequest();

            }
        }

        protected void DeleteCourse(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                if (!int.TryParse(courseID.Text, out int courseid))
                {
                    Response.Write("Please enter a valid integer for Course ID.");
                    return;
                }
                SqlCommand deletecourse = new SqlCommand("Procedures_AdminDeleteCourse", conn);
                deletecourse.CommandType = CommandType.StoredProcedure;
                deletecourse.Parameters.Add(new SqlParameter("@courseID", courseid));

                conn.Open();
                int rowsAffected = deletecourse.ExecuteNonQuery();
                conn.Close();
                if (rowsAffected > 0)
                {
                    Response.Write($"Course with ID {courseid} deleted successfully.");
                }
                else
                {
                    Response.Write($"No course found with ID {courseid}.");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("conflicted with the REFERENCE constraint"))
                {
                    Response.Write($"Cannot delete this course because it is referenced by other records. Please delete all referencing records first.");
                }
                else
                {
                    Response.Write($"An error occurred: {ex.Message}");
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", false);
            Context.ApplicationInstance.CompleteRequest();

        }
    }
}