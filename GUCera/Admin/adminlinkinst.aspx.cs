using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace GUCera
{
    public partial class adminlinkinst : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("AdminLogin.aspx", false);
                Context.ApplicationInstance.CompleteRequest();

            }
        }
        protected void btnSubmit2_Click(object sender, EventArgs e)
        {
            string courseId = string.IsNullOrEmpty(txtCourseId2.Text) ? null : txtCourseId2.Text;
            string instructorId = string.IsNullOrEmpty(txtInstructorId.Text) ? null : txtInstructorId.Text;
            string slotId = string.IsNullOrEmpty(txtSlotId.Text) ? null : txtSlotId.Text;

            if (courseId == null || instructorId == null || slotId == null)
            {
                Response.Write("<strong>Error:</strong> Please enter values for all fields.");
                return;
            }

            int courseIdInt, instructorIdInt, slotIdInt;
            if (!int.TryParse(courseId, out courseIdInt) || !int.TryParse(instructorId, out instructorIdInt) || !int.TryParse(slotId, out slotIdInt))
            {
                Response.Write("<strong>Error:</strong> Please enter valid numeric values for Course ID, Instructor ID, and Slot ID.");
                return;
            }

            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Procedures_AdminLinkInstructor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cours_id", courseIdInt);
                    cmd.Parameters.AddWithValue("@instructor_id", instructorIdInt);
                    cmd.Parameters.AddWithValue("@slot_id", slotIdInt);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("<strong>Success:</strong> Record updated successfully.");
                    }
                    else
                    {
                        Response.Write("<strong>Error:</strong> Slot ID not found in the database.");
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    Response.Write("<strong>Error:</strong> Course ID or Instructor ID not found in the database.");
                }
                else if (ex.Number == 2627)
                {
                    Response.Write("<strong>Error:</strong> Slot ID already exists in the database.");
                }
                else
                {
                    Response.Write("<strong>Error:</strong> An unexpected database error occurred: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<strong>Error:</strong> An unexpected error occurred: " + ex.Message);
            }
        }

        protected void btnMP2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", false);
            Context.ApplicationInstance.CompleteRequest();

        }

    }
}