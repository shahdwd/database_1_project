using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Configuration;
using System.Web.UI;

namespace GUCera
{
    public partial class StudentLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signin_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                int id = Int16.Parse(username.Text);
                String pass = password.Text;

                SqlCommand checkExist = new SqlCommand("Select count(*) from Student where student_id = @id ", conn);
                checkExist.Parameters.AddWithValue("@id", id);

                conn.Open();
                int count = (int)checkExist.ExecuteScalar();
                conn.Close();

                if (count == 0)
                {
                    ErrorLabel.Text = "ID DOES NOT EXIST!";
                }
                else
                {


                    using (SqlCommand loginfun = new SqlCommand("SELECT dbo.FN_StudentLogin(@Student_id, @password)", conn))
                    {

                        loginfun.Parameters.AddWithValue("@Student_id", id);
                        loginfun.Parameters.AddWithValue("@password", pass);

                        SqlParameter success = loginfun.Parameters.Add("@RETURN_VALUE", SqlDbType.Bit);
                        success.Direction = ParameterDirection.ReturnValue;

                        conn.Open();
                        bool loginsuccess = (bool)loginfun.ExecuteScalar();
                        conn.Close();

                        if (loginsuccess)
                        {
                            Session["UserID"] = id;
                            Session["password"] = pass;

                            Response.Redirect("Home Page.aspx");
                        }
                        else
                        {

                            SqlCommand checkStatus = new SqlCommand("Select financial_status from Student where student_id=@id", conn);
                            checkStatus.Parameters.AddWithValue("@id", id);

                            conn.Open();
                            bool status = (bool)checkStatus.ExecuteScalar();
                            conn.Close();

                            if (!status)
                            {
                                ClearLabels();
                                ErrorLabel.Text = "PLEASE PAY YOUR DEBTS!";

                            }
                            else
                            {
                                ClearLabels();
                                ErrorLabel.Text = "INCORRECT PASSWORD!";
                            }
                        }
                    }
                }
            }
            catch (FormatException)
            {
                if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Text))
                {
                    ClearLabels();
                    ErrorLabel.Text = "ID or Password cannot be empty!";

                }
                else
                {
                    ClearLabels();
                    ErrorLabel.Text = "ID must be an Integer";
                }

            }
            catch (Exception)
            {
                ClearLabels();
                ErrorLabel.Text = "Invalid username or Password";
            }

        }

        protected void signup_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        private void ClearLabels()
        {
            ErrorLabel.Text = "";
            
        }
    }
}