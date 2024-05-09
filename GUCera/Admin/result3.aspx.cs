using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace GUCera
{
    public partial class result3 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        try
                        {
                            conn.Open();

                            SqlCommand cmd = new SqlCommand("SELECT instructor_id, Instructor, course_id, Course FROM Instructors_AssignedCourses", conn);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    Response.Write("<h1>Instructors Assigned Courses</h1>");
                                    Response.Write("<table border='1'>");
                                    Response.Write("<tr><th>Instructor ID</th><th>Instructor Name</th><th>Course ID</th><th>Course Name</th></tr>");

                                    while (reader.Read())
                                    {
                                        int instructorId = Convert.ToInt32(reader["instructor_id"]);
                                        string instructorName = reader["Instructor"].ToString();
                                        int courseId = Convert.ToInt32(reader["course_id"]);
                                        string courseName = reader["Course"].ToString();

                                        Response.Write("<tr>");
                                        Response.Write($"<td>{instructorId}</td>");
                                        Response.Write($"<td>{instructorName}</td>");
                                        Response.Write($"<td>{courseId}</td>");
                                        Response.Write($"<td>{courseName}</td>");
                                        Response.Write("</tr>");
                                    }

                                    Response.Write("</table>");
                                }
                                else
                                {
                                    Response.Write("<p>(no data)</p>");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write("An error occurred: " + ex.Message);
                        }
                    }
                }
                else
                {
                    Response.Redirect("AdminLogin.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
    }
}
