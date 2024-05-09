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
    public partial class updatestatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("AdminLogin.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            if (!int.TryParse(TextBox13.Text, out int sID))
            {
                Response.Write("Invalid Student ID. Please enter a valid student ID.");
                return;
            }
            SqlCommand updatestatuss = new SqlCommand("Procedure_AdminUpdateStudentStatus", conn);
            updatestatuss.CommandType = CommandType.StoredProcedure;
            updatestatuss.Parameters.Add(new SqlParameter("@student_id", sID));
            try
            {
                conn.Open();
                int rowAffect = updatestatuss.ExecuteNonQuery();
                if (rowAffect > 0)
                {
                    Response.Write("Status updated successfully");
                }
                else
                {
                    Response.Write($"No student found with ID {sID}.");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", false);
            Context.ApplicationInstance.CompleteRequest();

        }
    }
}