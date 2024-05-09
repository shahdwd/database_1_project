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
    public partial class RequiredCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void reqcourses_Click(object sender, EventArgs e)
        {

            Error.Text = "";
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();



            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    //int id = 3; // For testing purposes; replace with (int)Session["UserID"] in your actual code
                    int id = (int)Session["UserID"];
                    string currentSemesterCode = semcode.Text;

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Semester WHERE semester_code = @semesterCode", conn);
                    cmd.Parameters.AddWithValue("@semesterCode", currentSemesterCode);

                    int count = (int)cmd.ExecuteScalar();

                    if (string.IsNullOrEmpty(semcode.Text))
                    {
                        Error.Text = "Please Insert a Semester Code";
                        return;
                    }

                    if (count == 0)
                    {
                        Error.Text = "Semester Code does not exist!";
                        return;
                    }
                    conn.Close();

                    /*SqlCommand getcsc = new SqlCommand("SELECT Semester.semester_code FROM dbo.Semester WHERE Semester.start_date < GETDATE() AND Semester.end_date > GETDATE()", conn);
                    conn.Open();

                    SqlDataReader reader = getcsc.ExecuteReader();
                    if (reader.Read())
                    {
                        currentSemesterCode = reader["semester_code"].ToString();
                    }
                    conn.Close();*/

                    if (!string.IsNullOrEmpty(currentSemesterCode))
                    {
                        conn.Open();

                        SqlCommand reqcourseproc = new SqlCommand("Procedures_ViewRequiredCourses", conn);
                        reqcourseproc.CommandType = CommandType.StoredProcedure;
                        reqcourseproc.Parameters.AddWithValue("@StudentID", id);
                        reqcourseproc.Parameters.AddWithValue("@current_semester_code", currentSemesterCode);

                        SqlDataReader courseReader = reqcourseproc.ExecuteReader();
                        DataTable results = new DataTable();
                        results.Load(courseReader);

                        conn.Close();


                        gridView2.DataSource = results;
                        gridView2.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Text = "An error occurred: " + ex.Message;
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home Page.aspx");
        }
    }
}