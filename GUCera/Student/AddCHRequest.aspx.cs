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
    public partial class AddCHRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_CHpressed(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            try
            {

                int studentID = (int)Session["UserID"];
                
                int CH = Int16.Parse(ch.Text);
                string typeText = "credit";
                string commentText = comment.Text;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand sendcoursereqproc = new SqlCommand("Procedures_StudentSendingCHRequest", conn);
                    sendcoursereqproc.CommandType = CommandType.StoredProcedure;
                    
                    sendcoursereqproc.Parameters.AddWithValue("@StudentID", studentID);
                    sendcoursereqproc.Parameters.AddWithValue("@credit_hours", CH);
                    sendcoursereqproc.Parameters.AddWithValue("@type", typeText);
                    sendcoursereqproc.Parameters.AddWithValue("@comment", commentText);

                    sendcoursereqproc.ExecuteNonQuery();
                    conn.Close();
                    ClearLabels();
                    Success.Text = "Request sent successfully!";
                }
            }
            catch (FormatException)
            {
                ClearLabels();
                Error.Text = "Credit Hours cannot contain characters!";
            }
            catch (Exception ex)
            {
                ClearLabels();
                Error.Text = "An error occurred: " + ex.Message;
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home Page.aspx");
        }

        private void ClearLabels()
        {
            Error.Text = "";
            Success.Text = "";
        }
    }
    
}