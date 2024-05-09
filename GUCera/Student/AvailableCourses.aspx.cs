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
    public partial class AvailableCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }


        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home Page.aspx");
        }

        protected void avalcourses_Click(object sender, EventArgs e)
        {

            Error.Text = "";
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
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

                    //SqlCommand getcsc = new SqlCommand("SELECT Semester.semester_code FROM dbo.Semester WHERE Semester.start_date < GETDATE() AND Semester.end_date > GETDATE()", conn);
                    //conn.Open();

                    /* SqlDataReader reader = getcsc.ExecuteReader();
                     if (reader.Read())
                     {
                         currentSemesterCode = reader["semester_code"].ToString();
                     }
                     conn.Close();*/

                    if (!string.IsNullOrEmpty(currentSemesterCode))
                    {
                        conn.Open();

                        SqlCommand avalcoursefun = new SqlCommand("SELECT name, course_id FROM dbo.FN_SemsterAvailableCourses(@semstercode)", conn);
                        avalcoursefun.Parameters.AddWithValue("@semstercode", currentSemesterCode);

                        SqlDataReader courseReader = avalcoursefun.ExecuteReader();
                        DataTable results = new DataTable();
                        results.Load(courseReader); // Load the data into DataTable

                        conn.Close();

                        // Use the 'results' DataTable for further processing/display
                        gridViewResults.DataSource = results;
                        gridViewResults.DataBind();


                    }
                }
            }
            catch (Exception ex)
            {
                Error.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}