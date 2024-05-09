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
    public partial class addnewcourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("AdminLogin.aspx", false);
                Context.ApplicationInstance.CompleteRequest();

            }
        }
        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            string major = string.IsNullOrWhiteSpace(txtMajor.Text) ? null : txtMajor.Text.Trim();
            string semesterInput = string.IsNullOrWhiteSpace(txtSemester1.Text) ? null : txtSemester1.Text.Trim();
            string creditHoursInput = string.IsNullOrWhiteSpace(txtCreditHours.Text) ? null : txtCreditHours.Text.Trim();
            string courseName = string.IsNullOrWhiteSpace(txtCourseName.Text) ? null : txtCourseName.Text.Trim();
            bool isOffered = ddlIsOffered.SelectedValue == "1";

            if (major == null || semesterInput == null || creditHoursInput == null || courseName == null)
            {
                Response.Write("<strong>Error:</strong> Please fill all the required fields.");
                return;
            }

            if (!int.TryParse(semesterInput, out int semester))
            {
                Response.Write("<strong>Error:</strong> Please enter a valid semester.");
                return;
            }

            if (!int.TryParse(creditHoursInput, out int creditHours))
            {
                Response.Write("<strong>Error:</strong> Please enter a valid credit hour.");
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Procedures_AdminAddingCourse", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@major", major);
                    cmd.Parameters.AddWithValue("@semester", semester);
                    cmd.Parameters.AddWithValue("@credit_hours", creditHours);
                    cmd.Parameters.AddWithValue("@name", courseName);
                    cmd.Parameters.AddWithValue("@is_offered", isOffered);

                    cmd.ExecuteNonQuery();

                    Response.Write("<strong>Success:</strong> Course added successfully.");
                }
                catch (Exception ex)
                {
                    Response.Write("<strong>Error:</strong> An error occurred: " + ex.Message);
                }
            }
        }

        protected void btnMP_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", false);
            Context.ApplicationInstance.CompleteRequest();


        }
    }
}