using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Advising_System
{
    public partial class CoursePrerequisites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayCourseDetails();
            }
        }

        private void DisplayCourseDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM view_Course_prerequisites", connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        connection.Close();

                        if (table.Rows.Count > 0)
                        {
                            CoursesGridView.DataSource = table;
                            CoursesGridView.DataBind();
                        }
                        else
                        {
                            ErrorMessageLabel.Text = "No data found.";
                        }
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
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home Page.aspx");
        }
    }
}