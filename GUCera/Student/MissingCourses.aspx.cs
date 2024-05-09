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
    public partial class MissingCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MissCourses();
            }
        }

        protected void MissCourses()
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    //int id = 3; // For testing purposes; replace with (int)Session["UserID"] in your actual code
                    int id = (int)Session["UserID"];

                    conn.Open();

                    SqlCommand misscourseproc = new SqlCommand("Procedures_ViewMS", conn);
                    misscourseproc.CommandType = CommandType.StoredProcedure;
                    misscourseproc.Parameters.AddWithValue("@StudentID", id);

                    SqlDataReader courseReader = misscourseproc.ExecuteReader();
                    DataTable results = new DataTable();
                    results.Load(courseReader);

                    conn.Close();

                    
                    gridView1.DataSource = results;
                    gridView1.DataBind();
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