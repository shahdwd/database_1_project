using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Configuration;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{



    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*
        protected void login(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            //int id = Int16.Parse(username.Text);
            if (!int.TryParse(username.Text, out int id))
            {
                Response.Write("Invalid username. Please enter a valid integer.");
                return;
            }
            
            String pass = password.Text;

            SqlCommand loginFn = new SqlCommand("FN_AdvisorLogin", conn);
            loginFn.CommandType = CommandType.StoredProcedure;
            loginFn.Parameters.Add(new SqlParameter("@Student_id", SqlDbType.Int)).Value = id;
            loginFn.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 40)).Value = pass;

            SqlParameter success = new SqlParameter("@success", SqlDbType.Bit);
            success.Direction = ParameterDirection.Output;
            loginFn.Parameters.Add(success);

            conn.Open();

            // Use ExecuteScalar to get the return value of the function
            loginFn.ExecuteNonQuery();

            conn.Close();

            if (success.Value.ToString() == "1")
            {
                Response.Write("Hello");
            }





        }*/
        protected void login(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Check if username is a valid integer
                    if (!int.TryParse(username.Text, out int id))
                    {
                        lbl5.Text = "Invalid username.<br />Please enter a valid integer.";
                        lbl5.Visible = true;
                        return;
                    }

                    String pass = password.Text;

                    using (SqlCommand loginproc = new SqlCommand("FN_AdvisorLogin", conn))
                    {
                        loginproc.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        loginproc.Parameters.Add(new SqlParameter("@Advisor_id", SqlDbType.Int)).Value = id;
                        loginproc.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 40)).Value = pass;

                        // Output parameter
                        SqlParameter success = loginproc.Parameters.Add("@RETURN_VALUE", SqlDbType.Bit);
                        success.Direction = ParameterDirection.ReturnValue;

                        conn.Open();
                        loginproc.ExecuteNonQuery();
                        conn.Close();

                        // Check the return value
                        bool loginSuccess = (bool)success.Value;
                        if (string.IsNullOrWhiteSpace(pass))
                        {
                            lbl5.Text = "The Password field cannot be empty.";
                            lbl5.Visible = true;
                            lbl5.ForeColor = System.Drawing.Color.Red;

                            return;
                        }
                        if (string.IsNullOrWhiteSpace(username.Text))
                        {
                            lbl5.Text = "The Username field cannot be empty.";
                            lbl5.Visible = true;
                            lbl5.ForeColor = System.Drawing.Color.Red;

                            return;
                        }
                        if (loginSuccess)
                        {
                            Session["advisor"] = id;
                            Response.Redirect("Functioningpage.aspx");
                        }
                        else
                        {
                            // Check if the username exists in the database
                            if (CheckIfUserExists(id))
                            {
                                lbl5.Text = "Incorrect password.";
                            }
                            else
                            {
                                lbl5.Text = "You do not have an account.<br />Sign Up first.";
                            }

                            lbl5.ForeColor = System.Drawing.Color.Red;
                            lbl5.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lbl5.Text = $"An error occurred: {ex.Message}";
                lbl5.ForeColor = System.Drawing.Color.Red;
                lbl5.Visible = true;
            }
        }

        private bool CheckIfUserExists(int userId)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand checkUserProc = new SqlCommand("SELECT COUNT(*) FROM Advisor WHERE Advisor_id = @Advisor_id", conn))
                {
                    checkUserProc.Parameters.Add(new SqlParameter("@Advisor_id", SqlDbType.Int)).Value = userId;

                    conn.Open();

                    int userCount = (int)checkUserProc.ExecuteScalar();

                    conn.Close();

                    return userCount > 0;
                }
            }
        }

        protected void Register(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}