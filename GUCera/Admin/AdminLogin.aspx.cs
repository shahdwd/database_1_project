using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            int enteredId;
            if (int.TryParse(idTextBox.Text, out enteredId))
            {
                string enteredPassword = passwordTextBox.Text;

                int adminId = 1;
                string adminPassword = "admin123";

                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();

                        if (enteredId == adminId && enteredPassword.Equals(adminPassword))
                        {
                            Session["user"] = enteredId;
                            Response.Write("Login successful");
                            Response.Redirect("MainPage.aspx", false);

                        }
                        else
                        {
                            Response.Write("Login failed. Please check your ID and password.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                Response.Write("Invalid ID format. Please enter a valid integer ID.");
            }
        }

    }
}