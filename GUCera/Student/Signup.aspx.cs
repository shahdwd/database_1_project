using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace GUCera
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sign_up_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            try
            {
                
                string firstname = fname.Text;
                string lastname = lname.Text;
                string password = pass.Text;
                string confirmPassword = confirmpass.Text;
                string faculty = fac.Text;
                string email = em.Text;
                string major = maj.Text;
                int semester = Int16.Parse(sem.Text);

                if(!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    ClearLabels();
                    Error.Text = "Incorrect Email Format!";
                }

                if (password != confirmPassword)
                {
                    ClearLabels();
                    Error.Text = "Passwords do not match.<br/> Please enter matching passwords.";
                    
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand studentregister = new SqlCommand("Procedures_StudentRegistration", conn);
                    studentregister.CommandType = CommandType.StoredProcedure;
                    studentregister.Parameters.AddWithValue("@first_name", firstname);
                    studentregister.Parameters.AddWithValue("@last_name", lastname);
                    studentregister.Parameters.AddWithValue("@password", password);
                    studentregister.Parameters.AddWithValue("@faculty", faculty);
                    studentregister.Parameters.AddWithValue("@email", email);
                    studentregister.Parameters.AddWithValue("@major", major);
                    studentregister.Parameters.AddWithValue("@Semester", semester);

                    SqlParameter studentid = studentregister.Parameters.Add("@Student_id", SqlDbType.Int);
                    studentid.Direction = ParameterDirection.Output;

                    studentregister.ExecuteNonQuery();

                    int studentID = (int)studentid.Value;
                    conn.Close();

                    ClearLabels();
                    SuccessLabel.Text = "Successful Registeration!";
                    IDLabel.Text = "Your Student ID:" + studentID.ToString();
                }
            }
            catch (FormatException)
            {

                if (string.IsNullOrEmpty(fname.Text) || string.IsNullOrEmpty(lname.Text)
                    || string.IsNullOrEmpty(pass.Text) || string.IsNullOrEmpty(confirmpass.Text)
                    || string.IsNullOrEmpty(fac.Text) || string.IsNullOrEmpty(em.Text)
                    || string.IsNullOrEmpty(maj.Text) || string.IsNullOrEmpty(sem.Text))
                {
                    ClearLabels();
                    Error.Text = "Please fill in your empty fields!";
                }
            }
            catch (Exception ex)
            {
                ClearLabels();
                Error.Text = "An error occurred: " + ex.Message;
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogin.aspx");
        }

        private void ClearLabels()
        {
            Error.Text = "";
            SuccessLabel.Text = "";
        }
    }
}