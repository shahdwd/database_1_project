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
    public partial class slotsdelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("AdminLogin.aspx", false);
                Context.ApplicationInstance.CompleteRequest();

            }
        }

        protected void semButton_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string scode = semcode.Text;
            SqlCommand deleteslotss = new SqlCommand("Procedures_AdminDeleteSlots", conn);
            deleteslotss.CommandType = CommandType.StoredProcedure;
            deleteslotss.Parameters.Add(new SqlParameter("@current_semester", scode));
            SqlCommand checkExistingSemester = new SqlCommand("SELECT COUNT(*) FROM Semester WHERE semester_code = @current_semester", conn);
            checkExistingSemester.Parameters.Add(new SqlParameter("@current_semester", scode));

            conn.Open();
            int rowsAffected = deleteslotss.ExecuteNonQuery();
            int semesterExistenceCount = (int)checkExistingSemester.ExecuteScalar();
            if (semesterExistenceCount == 0)
            {
                Response.Write($"No semester found with the following code  {scode}.");
                return;
            }
            conn.Close();
            if (rowsAffected > 0)
            {
                Response.Write($"Slots  for the semester with the code  {scode} deleted successfully.");
            }
            else
            {
                Response.Write($"No slots of unoffered courses for the following semester code {scode} to delete.");
            }
            Session["SemesterCode"] = scode;
            //elmafoudd ye input????/ wala session mn haga bara
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", false);
            Context.ApplicationInstance.CompleteRequest();

        }
    }
}