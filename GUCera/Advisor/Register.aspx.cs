using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Web.UI;

namespace GUCera
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Resgistered(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string advisorName = advisorname.Text;

                    if (string.IsNullOrWhiteSpace(advisorName))
                    {

                        Label1.Text = "Advisor name cannot be empty.<br/> Please enter a valid value.";
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label1.Visible = true;
                        return;
                    }
                    if (!Regex.IsMatch(advisorName, @"^[a-zA-Z]+$"))
                    {
                        // The string is not a valid integer
                        Label1.Text = "Advisor name cannot be a number.<br/> Please enter a valid value.";
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label1.Visible = true;
                        return;
                    }
                    string advisorEmail = advisoremail.Text;
                    string advisorPassword1 = advisorpassword1.Text;
                    string advisorPassword2 = advisorpassword2.Text;
                    if (string.IsNullOrWhiteSpace(advisorEmail))
                    {
                        Label1.Text = "The email field cannot be empty.";
                        Label1.Visible = true;
                        Label1.ForeColor = System.Drawing.Color.Red;

                        return;
                    }
                    if (string.IsNullOrWhiteSpace(advisorPassword1))
                    {
                        Label1.Text = "The password field cannot be empty.";
                        Label1.Visible = true;
                        Label1.ForeColor = System.Drawing.Color.Red;

                        return;
                    }
                    if (string.IsNullOrWhiteSpace(advisorPassword2))
                    {
                        Label1.Text = "The Password field cannot be empty.";
                        Label1.Visible = true;
                        Label1.ForeColor = System.Drawing.Color.Red;

                        return;
                    }
                    if (advisorPassword1 != advisorPassword2)
                    {

                        Label1.Text = "Passwords do not match.<br/> Please enter matching passwords.";
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label1.Visible = true;
                        return;
                    }
                    string office = this.office.Text;
                    if (string.IsNullOrWhiteSpace(office))
                    {
                        Label1.Text = "The Office field cannot be empty.";
                        Label1.Visible = true;
                        Label1.ForeColor = System.Drawing.Color.Red;

                        return;
                    }
                    using (SqlCommand registerProc = new SqlCommand("Procedures_AdvisorRegistration", conn))
                    {
                        registerProc.CommandType = CommandType.StoredProcedure;

                        registerProc.Parameters.Add(new SqlParameter("@advisor_name", SqlDbType.VarChar, 20)).Value = advisorName;
                        registerProc.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 40)).Value = advisorPassword1;
                        registerProc.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 40)).Value = advisorEmail;
                        registerProc.Parameters.Add(new SqlParameter("@office", SqlDbType.VarChar, 40)).Value = office;

                        SqlParameter advisorIdParam = registerProc.Parameters.Add("@Advisor_id", SqlDbType.Int);
                        advisorIdParam.Direction = ParameterDirection.Output;

                        conn.Open();
                        registerProc.ExecuteNonQuery();
                        int advisorId = (int)advisorIdParam.Value;

                        ShowSuccessMessage("Registration successful. Advisor ID: " + advisorId);




                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirectScript", "setTimeout(function(){ window.location.href = 'Login.aspx'; }, 3000);", true);
                        conn.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
        }

        private void ShowErrorMessage(string message)
        {
            // Display error message to the user (consider using a label or other control)
            Response.Write($"<script>alert('{message}');</script>");
        }

        private void ShowSuccessMessage(string message)
        {
            // Display success message to the user (consider using a label or other control)
            Response.Write($"<script>alert('{message}');</script>");
        }
    }
}