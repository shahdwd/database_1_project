using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Advising_System
{
    public partial class Student_gradplan_courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;
        //    SqlConnection conn = new SqlConnection(connStr);
        //    int id = Int16.Parse(std_id.Text);

        //    SqlCommand S_GP_C = new SqlCommand("SELECT * FROM FN_StudentViewGP(@student_ID)", conn);
        //   // S_GP_C.CommandType = System.Data.CommandType.StoredProcedure;
        //    S_GP_C.Parameters.AddWithValue("@student_ID", id);
        //    DataTable table = new DataTable();
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader reader = S_GP_C.ExecuteReader();
        //        table.Load(reader);
        //        GridView1.DataSource = table; // Bind the DataTable to the GridView
        //        GridView1.DataBind();

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        // Handle exceptions or return null, empty table, etc.
        //    }
        //    finally
        //    {
        //        conn.Close(); // Close the connection when done
        //    }
        //}
        /* protected void ViewGradPlanButton_Click(object sender, EventArgs e)
         {
             string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;
             using (SqlConnection conn = new SqlConnection(connStr))
             {
                  int studentId = int.Parse(StudentIDTextBox.Text);
                 if (!int.TryParse(StudentIDTextBox.Text, out studentId))
                 {
                     StudentIDErrorLabel.Text = "Please enter a valid student ID";
                    return;
                 }



                 SqlCommand cmd = new SqlCommand("SELECT * FROM FN_StudentViewGP(@student_ID)", conn);
                 cmd.Parameters.AddWithValue("@student_ID", studentId);
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable();

                 try
                 {
                     conn.Open();
                     da.Fill(dt);
                     if (!int.TryParse(StudentIDTextBox.Text, out studentId))
                     {
                         StudentIDErrorLabel.Text = "Please enter a valid student ID";
                         return;
                     }


                     GridView1.DataSource = dt;
                     GridView1.DataBind();
                 }

                 catch (SqlException ex)
                 {
                     // Handle SQL-related exceptions
                     Console.WriteLine("SQL Error:\"Please enter a valid student ID\" " + ex.Message);
                 }
                 catch (Exception ex)
                 {
                     // Catch any other exceptions
                     if (dt.Rows.Count == 0)
                     {
                         NotFoundErrorLabel.Text = "Student not found";
                         return;
                     }
                     Console.WriteLine("An error occurred:\"Please enter a valid student ID\" " + ex.Message);
                 }
             }
         }



     }*/
        protected void ViewGradPlanButton_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();

            StudentIDErrorLabel.Text = "";
            NotFoundErrorLabel.Text = "";

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                int studentId = (int)Session["UserID"];
               /* if (!int.TryParse(StudentIDTextBox.Text, out studentId))
                {
                    StudentIDErrorLabel.Text = "Please enter a valid student ID";
                    return;
                }*/

                SqlCommand cmd = new SqlCommand("SELECT * FROM FN_StudentViewGP(@student_ID)", conn);
                cmd.Parameters.AddWithValue("@student_ID", studentId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        NotFoundErrorLabel.Text = "Student not found";
                        return;
                    }

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                catch (SqlException ex)
                {
                    // Handle SQL-related exceptions
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // Catch any other exceptions
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home Page.aspx");
        }
    }
}
