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
    public partial class adminlinksta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("AdminLogin.aspx", false);
                Context.ApplicationInstance.CompleteRequest();

            }
        }
        protected void btnMP4_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", false);
            Context.ApplicationInstance.CompleteRequest();


        }
        protected void btnSubmit3_Click(object sender, EventArgs e)
        {
            string studentId = string.IsNullOrEmpty(txtStudentId3.Text) ? null : txtStudentId3.Text;
            string advisorId = string.IsNullOrEmpty(txtAdvisorId3.Text) ? null : txtAdvisorId3.Text;

            if (studentId == null || advisorId == null)
            {
                Response.Write("<strong>Error:</strong> Please enter values for all fields.");
                return;
            }

            int studentIdInt, advisorIdInt;
            if (!int.TryParse(studentId, out studentIdInt) || !int.TryParse(advisorId, out advisorIdInt))
            {
                Response.Write("<strong>Error:</strong> Please enter valid numeric values for Student ID and Advisor ID.");
                return;
            }

            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand checkAdvisorCmd = new SqlCommand("SELECT COUNT(*) FROM Advisor WHERE advisor_id = @advisorID", conn);
                    checkAdvisorCmd.Parameters.AddWithValue("@advisorID", advisorIdInt);

                    int advisorCount = (int)checkAdvisorCmd.ExecuteScalar();

                    if (advisorCount == 0)
                    {
                        Response.Write("<strong>Error:</strong> Advisor ID not found in the database.");
                        return;
                    }

                    SqlCommand updateCmd = new SqlCommand("Procedures_AdminLinkStudentToAdvisor", conn);
                    updateCmd.CommandType = CommandType.StoredProcedure;

                    updateCmd.Parameters.AddWithValue("@studentID", studentIdInt);
                    updateCmd.Parameters.AddWithValue("@advisorID", advisorIdInt);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("<strong>Success:</strong> Record updated successfully.");
                    }
                    else
                    {
                        Response.Write("<strong>Error:</strong> Student ID not found in the database.");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<strong>Error:</strong> An error occurred: " + ex.Message);
            }
        }


    }
}