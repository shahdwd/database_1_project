using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class result1 : System.Web.UI.Page
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

                            SqlCommand cmd = new SqlCommand("AdminListStudentsWithAdvisors", conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            Response.Write("<h1>Students List with Advisors</h1>");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    Response.Write("<table border='1'>");
                                    Response.Write("<tr><th>Student ID</th><th>Name</th><th>Advisor ID</th><th>Advisor Name</th></tr>");

                                    while (reader.Read())
                                    {
                                        int studentId = Convert.ToInt32(reader["student_id"]);
                                        string firstName = reader["f_name"].ToString();
                                        string lastName = reader["l_name"].ToString();
                                        int advisorId = Convert.ToInt32(reader["advisor_id"]);
                                        string advisorName = reader["advisor_name"].ToString();

                                        Response.Write("<tr>");
                                        Response.Write($"<td>{studentId}</td>");
                                        Response.Write($"<td>{firstName} {lastName}</td>");
                                        Response.Write($"<td>{advisorId}</td>");
                                        Response.Write($"<td>{advisorName}</td>");
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