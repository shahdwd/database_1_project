using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace GUCera
{
    public partial class result2 : System.Web.UI.Page
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

                            SqlCommand cmd = new SqlCommand("SELECT request_id, type, comment, status, credit_hours, course_id, student_id, advisor_id FROM all_Pending_Requests", conn);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    Response.Write("<h1>Pending Requests</h1>");
                                    Response.Write("<table border='1'>");
                                    Response.Write("<tr><th>Request ID</th><th>Type</th><th>Comment</th><th>Status</th><th>Credit Hours</th><th>Course ID</th><th>Student ID</th><th>Advisor ID</th></tr>");

                                    while (reader.Read())
                                    {
                                        int requestId = Convert.ToInt32(reader["request_id"]);
                                        string type = reader["type"].ToString();
                                        string comment = reader["comment"].ToString();
                                        string status = reader["status"].ToString();
                                        string creditHours = reader["credit_hours"] == DBNull.Value ? "NULL" : reader["credit_hours"].ToString();
                                        string courseId = reader["course_id"] == DBNull.Value ? "NULL" : reader["course_id"].ToString();
                                        string studentId = reader["student_id"] == DBNull.Value ? "NULL" : reader["student_id"].ToString();
                                        string advisorId = reader["advisor_id"] == DBNull.Value ? "NULL" : reader["advisor_id"].ToString();

                                        Response.Write("<tr>");
                                        Response.Write($"<td>{requestId}</td>");
                                        Response.Write($"<td>{type}</td>");
                                        Response.Write($"<td>{comment}</td>");
                                        Response.Write($"<td>{status}</td>");
                                        Response.Write($"<td>{creditHours}</td>");
                                        Response.Write($"<td>{courseId}</td>");
                                        Response.Write($"<td>{studentId}</td>");
                                        Response.Write($"<td>{advisorId}</td>");
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