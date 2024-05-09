using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace GUCera
{
    public partial class result4 : System.Web.UI.Page
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

                            SqlCommand cmd = new SqlCommand("SELECT course_id, name, semester_code FROM Semster_offered_Courses", conn);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                Response.Write("<h1>Semester Offered Courses</h1>");
                                Response.Write("<table border='1'>");
                                Response.Write("<tr><th>Course ID</th><th>Name</th><th>Semester Code</th></tr>");

                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        string courseId = reader["course_id"].ToString();
                                        string courseName = reader["name"].ToString();
                                        string semesterCode = reader["semester_code"].ToString();

                                        Response.Write("<tr>");
                                        Response.Write($"<td>{courseId}</td>");
                                        Response.Write($"<td>{courseName}</td>");
                                        Response.Write($"<td>{semesterCode}</td>");
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