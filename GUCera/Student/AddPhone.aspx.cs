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
    public partial class AddPhone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Add_Phone(object sender, EventArgs e)
        {
            Error.Text = "";

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            try
            {
                SqlConnection conn = new SqlConnection(connStr);


                int id = (int)Session["UserID"];
                int phoneNumber = Int32.Parse(txtPhoneNumber.Text);


                lstPhoneNumbers.Items.Add(phoneNumber.ToString());
                txtPhoneNumber.Text = "";

                conn.Open();

                SqlCommand addPhoneNumber = new SqlCommand("Procedures_StudentaddMobile", conn);
                addPhoneNumber.CommandType = CommandType.StoredProcedure;

                addPhoneNumber.Parameters.AddWithValue("@StudentID", id);
                addPhoneNumber.Parameters.AddWithValue("@mobile_number", phoneNumber);

                addPhoneNumber.ExecuteNonQuery();


                conn.Close();
            }
            catch (FormatException)
            {
                if (String.IsNullOrEmpty(txtPhoneNumber.Text))
                {
                    Error.Text = "";
                    Error.Text = "Please Insert a Phone Number!";
                }
                else 
                {
                    Error.Text = "";
                    Error.Text = "Phone Numbers cannot contain characters!";
                }
            }
            catch (Exception ex)
            {
                Error.Text = "";
                Error.Text = "An error occurred: " + ex.Message;
               
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Home Page.aspx");
        }
    }
}