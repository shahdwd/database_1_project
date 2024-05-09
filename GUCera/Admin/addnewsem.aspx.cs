using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class addnewsem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("AdminLogin.aspx", false);
                Context.ApplicationInstance.CompleteRequest();

            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string semesterCode = string.IsNullOrWhiteSpace(txtSemester.Text) ? null : txtSemester.Text;
            string startDateString = txtStartDate.Text;
            string endDateString = txtEndDate.Text;

            if (semesterCode == null || string.IsNullOrWhiteSpace(startDateString) || string.IsNullOrWhiteSpace(endDateString))
            {
                Response.Write("<strong>Error:</strong> Please fill all the text boxes.<br />");
                return;
            }

            if (!ValidateSemesterCode(semesterCode))
            {
                Response.Write("<strong>Error:</strong> Invalid semester code format. Correct format examples: W23, S23, S23R1...<br />");
                return;
            }

            DateTime? startDate = GetDateTime(startDateString);
            DateTime? endDate = GetDateTime(endDateString);

            if (startDate == null || endDate == null)
            {
                return;
            }

            if (startDate >= endDate)
            {
                Response.Write("<strong>Error:</strong> Start date must be less than end date.<br />");
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("AdminAddingSemester", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@start_date", startDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@end_date", endDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@semester_code", semesterCode ?? (object)DBNull.Value);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("<strong>Success:</strong> Semester added successfully.<br />");
                    }
                    else
                    {
                        Response.Write("<strong>Error:</strong> Failed to add semester.<br />");
                    }
                }
                catch (Exception ex)
                {
                    if (ex is SqlException sqlException && sqlException.Number == 2627)
                    {
                        Response.Write("<strong>Error:</strong> Semester already exists.<br />");
                    }
                    else
                    {
                        Response.Write("<strong>Error:</strong> An error occurred: " + ex.Message + "<br />");
                    }
                }
            }
        }

        private DateTime? GetDateTime(string dateString)
        {
            DateTime result;
            if (DateTime.TryParse(dateString, out result))
            {
                return result;
            }
            else
            {
                Response.Write("<strong>Error:</strong> Please enter a valid date format.<br />");
                return null;
            }
        }

        private bool ValidateSemesterCode(string code)
        {
            code = code.ToUpper();
            if (code.Length < 3)
            {
                return false;
            }

            char firstChar = code[0];
            string remainingChars = code.Substring(1);

            if ((firstChar == 'W' && remainingChars.Length == 2) || (firstChar == 'S' && remainingChars.Length == 2))
            {
                if (firstChar == 'S' && remainingChars.EndsWith("R"))
                {
                    string integerPart = remainingChars.Substring(0, remainingChars.Length - 1);
                    int result;
                    if (int.TryParse(integerPart, out result))
                    {
                        return true;
                    }
                }
                else
                {
                    int result;
                    if (int.TryParse(remainingChars, out result))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        protected void btnMP1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", false);
            Context.ApplicationInstance.CompleteRequest();


        }
    }
}