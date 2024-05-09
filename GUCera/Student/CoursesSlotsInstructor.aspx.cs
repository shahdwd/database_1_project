using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Advising_System
{
    public partial class CoursesSlotsInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void BindGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;
            string query = "SELECT * FROM Courses_Slots_Instructor";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();

                    connection.Open();
                    adapter.Fill(table);
                    connection.Close();

                    if (table.Rows.Count > 0)
                    {
                        GridViewCourses.DataSource = table;
                        GridViewCourses.DataBind();
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