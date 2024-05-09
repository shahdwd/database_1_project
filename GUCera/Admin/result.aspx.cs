using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace GUCera
{
    public partial class result : System.Web.UI.Page
    {
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

                            SqlCommand cmd = new SqlCommand("Procedures_AdminListAdvisors", conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            Response.Write("<h1>Advisors List</h1>");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    Response.Write("<table border='1'>");
                                    Response.Write("<tr><th>ID</th><th>Name</th><th>Email</th><th>Office</th></tr>");

                                    while (reader.Read())
                                    {
                                        int advisorId = Convert.ToInt32(reader["advisor_id"]);
                                        string advisorName = reader["advisor_name"].ToString();
                                        string email = reader["email"].ToString();
                                        string office = reader["office"].ToString();

                                        Response.Write("<tr>");
                                        Response.Write($"<td>{advisorId}</td>");
                                        Response.Write($"<td>{advisorName}</td>");
                                        Response.Write($"<td>{email}</td>");
                                        Response.Write($"<td>{office}</td>");
                                        Response.Write("</tr>");
                                    }

                                    Response.Write("</table>");
                                }
                                else
                                {
                                    Response.Write("<h2>(no data)</h2>");
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
                    Response.Redirect("AdmnLogin.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", false);
        }
    }
}