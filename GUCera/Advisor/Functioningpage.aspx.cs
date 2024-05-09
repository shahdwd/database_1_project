using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Web.Services.Description;
using System.Configuration;
using System.Globalization;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;

namespace GUCera
{

    public partial class Functioningpage : System.Web.UI.Page
    {
        public int advisorId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["advisor"] == null)
            {
                Response.Redirect("Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
               
            }

            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
                LoadDefaultContent();
            }
            if (Session["advisor"] != null)
            {
                advisorId = (int)Session["advisor"];
                //Response.Write($"<p>The advisor ID is: {advisorId}</p>");
            }
        }

        /* protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
         {
             // Handle menu item clicks and update content
             string menuItemValue = e.Item.Value;

             switch (menuItemValue)
             {
                 case "Home":
                     LoadDefaultContent();
                     break;
                 case "AdvisingStudents":
                     LoadAdvisingStudentsContent();
                     break;
                 case "StudentsMajorCourses":
                     LoadStudentsMajorCoursesContent();
                     break;
                 case "AllRequests":
                     LoadAllRequestsContent();
                     break;
                 case "PendingRequests":
                     LoadPendingRequestsContent();
                     break;
                 default:
                     LoadDefaultContent();
                     break;
             }
         }
         */
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            string menuItemValue = e.Item.Value;

            switch (menuItemValue)
            {
                case "Home":
                    MultiView1.ActiveViewIndex = 0;
                    break;
                case "StudentsMajorCourses":
                    MultiView1.ActiveViewIndex = 1;
                    break;
                case "AdvisingStudents":
                    MultiView1.ActiveViewIndex = 2;
                    break;

                case "AllRequests":
                    MultiView1.ActiveViewIndex = 3;
                    break;
                case "PendingRequests":
                    MultiView1.ActiveViewIndex = 4;
                    break;
                case "Gradplan":
                    MultiView1.ActiveViewIndex = 5;
                    break;
                case "Courseingradplan":
                    MultiView1.ActiveViewIndex = 6;
                    break;
                case "UpdateGP":
                    MultiView1.ActiveViewIndex = 7;
                    break;
                case "DeletefromGP":
                    MultiView1.ActiveViewIndex = 8;
                    break;
                case "SignOut":
                    {
                        Session.Clear();
                        Session.Abandon();
                        Response.Redirect("login.aspx");
                        break;
                    }
                default:
                    MultiView1.ActiveViewIndex = 0;
                    break;
            }
        }
        private void LoadUpdateGradDateContent()
        {
            ContentPanel.Controls.Add(new LiteralControl(""));
        }
        private void LoadDeleteCourseContent()
        {
            ContentPanel.Controls.Add(new LiteralControl(""));

        }
        private void LoadDefaultContent()
        {
            // Check if the control is already present to avoid duplicates
            if (!ContentPanel.Controls.OfType<LiteralControl>().Any())
            {
                ContentPanel.Controls.Add(new LiteralControl("Welcome to the advising students' system at the GUC"));

            }
        }





        private DataTable GetAdvisingStudentsTable(int advisorId)
        {
            DataTable advisingStudentsTable = new DataTable();

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("Procedures_AdvisorViewAssignedStudents2", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.Add(new SqlParameter("@AdvisorID", SqlDbType.Int)).Value = advisorId;

                    conn.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(advisingStudentsTable);
                    }

                    conn.Close();
                }
            }

            return advisingStudentsTable;
        }

        private void LoadAdvisingStudentsContent()
        {
            if (Session["advisor"] != null)
            {
                int advisorId = (int)Session["advisor"];

                // Get advising students DataTable
                DataTable advisingStudentsTable = GetAdvisingStudentsTable(advisorId);

                // Bind DataTable to GridView
                GridView1.DataSource = advisingStudentsTable;
                GridView1.DataBind();
            }
            else
            {
                Label2.Text = "Advisor ID not found in session.";
                Label2.Visible = true;
                LoginLink.Visible = true;

            }
        }


        private void LoadStudentsMajorCoursesContent()
        {

            ContentPanel.Controls.Add(new LiteralControl(""));
        }

        private void LoadAllRequestsContent()
        {
            if (Session["advisor"] != null)
            {
                int advisorId = (int)Session["advisor"];

                DataTable resultTable = GetDataFromRFunction(advisorId);

                if (resultTable.Rows.Count > 0)
                {
                    GridViewRequests.DataSource = resultTable;
                    GridViewRequests.DataBind();
                }
                else
                {
                    // Display a message or hide the GridView when no records are found
                    GridViewRequests.EmptyDataText = "No records found.";
                    GridViewRequests.DataBind();
                }
            }
            else
            {
                Label2.Text = "Advisor ID not found in session.";
                Label2.Visible = true;
                LoginLink.Visible = true;
            }
        }

        private DataTable GetDataFromRFunction(int advisorId)
        {
            DataTable resultTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["Advising_System"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM FN_Advisors_Requests(@AdvisorID)", conn))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AdvisorID", SqlDbType.Int)).Value = advisorId;
                    conn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(resultTable);
                    }

                    conn.Close();
                }
            }

            return resultTable;
        }

        private void LoadPendingRequestsContent()
        {
            if (Session["advisor"] != null)
            {
                int advisorId = (int)Session["advisor"];

                DataTable resultTable = GetDataFromProcedures(advisorId);

                if (resultTable.Rows.Count > 0)
                {
                    GridViewPending.DataSource = resultTable;
                    GridViewPending.DataBind();
                }
                else
                {
                    // Display a message or hide the GridView when no records are found
                    GridViewPending.EmptyDataText = "No records found.";
                    GridViewPending.DataBind();
                }
            }
            else
            {
                Label2.Text = "Advisor ID not found in session.";
                Label2.Visible = true;
                LoginLink.Visible = true;

            }

        }
        private string CalculateSemesterCode()
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Determine the semester based on the current month
            string semester = (currentDate.Month >= 1 && currentDate.Month <= 6) ? "S" : "W";

            // Get the last two digits of the year
            string year = currentDate.Year.ToString().Substring(2);

            // Combine the semester and year to form the semester code
            string semesterCode = $"{semester}{year}";

            return semesterCode;
        }


        protected void btnRespond_Click2(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int requestID = Convert.ToInt32(btn.CommandArgument);
            string type = GetRequestType(requestID);
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Advising_System"].ToString()))
            {
                connection.Open();
                if (type.CompareTo("course") == 0)
                {


                    using (SqlCommand cmd = new SqlCommand("Procedures_AdvisorApproveRejectCourseRequest", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@requestID", requestID);
                        cmd.Parameters.AddWithValue("@current_semester_code", CalculateSemesterCode());

                        cmd.ExecuteNonQuery();
                    }
                }
                else if (type.CompareTo("credit_hours") == 0)
                {
                    using (SqlCommand cmd = new SqlCommand("Procedures_AdvisorApproveRejectCHRequest", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@requestID", requestID);
                        cmd.Parameters.AddWithValue("@current_sem_code", CalculateSemesterCode());

                        cmd.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }



            BindGridView();
        }



        protected string GetRequestType(int requestID)
        {
            string type = "";
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Advising_System"].ToString()))
            {
                connection.Open();
                string query = "SELECT type FROM Request WHERE request_id = @requestID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@requestID", requestID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        type = reader["type"].ToString();
                    }
                }
            }
            return type;
        }




        /*protected string getRequestType(int requestID)
        {
            string type = "";
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Advising_System"].ToString()))
            {
                connection.Open();
                string query = "Select type from Request where request_id = requestID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@requestID", requestID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        type = reader["type"].ToString();
                    }
                }
            }
            return type;
        }*/

        protected string GetSemesterCode(int courseId)
        {
            string semesterCode = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Advising_System"].ToString()))
                {
                    connection.Open();
                    string query = "SELECT semester_code FROM Course_Semester WHERE course_id = @courseId";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@courseId", courseId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                semesterCode = reader["semester_code"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Error in GetSemesterCode: {ex.Message}");
            }

            return semesterCode;
        }


        protected void BindGridView()
        {
            LoadPendingRequestsContent();
        }


        private DataTable GetDataFromProcedures(int advisorId)
        {
            DataTable resultTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["Advising_System"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Procedures_AdvisorViewPendingRequests", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Advisor_ID", SqlDbType.Int)).Value = advisorId;
                    conn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(resultTable);
                    }

                    conn.Close();
                }
            }

            return resultTable;
        }

        /*private void LoadInsertGradPlanContent()
        {
            if (Session["advisor"] != null)
            {
                int advisorId = (int)Session["advisor"];
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {   

                string date1 = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
                string sem_code = SemCode.Text;
                String CHrs = Credit_Hours.Text;
                String StdId = Student_id.Text;
                
                using (SqlCommand insertproc = new SqlCommand("Procedures_AdvisorCreateGP", conn))
                {
                    insertproc.CommandType = CommandType.StoredProcedure;

                    insertproc.Parameters.Add(new SqlParameter("@Semester_code", SqlDbType.VarChar, 40)).Value = sem_code;

                    insertproc.Parameters.Add(new SqlParameter("@expected_graduation_date", SqlDbType.VarChar, 40)).Value = date1;
                        //insertproc.Parameters.Add(new SqlParameter("@sem_credit_hours", SqlDbType.Int)).Value = Int32.Parse(CHrs);
                        int semCreditHours;

                        if (int.TryParse(CHrs, out semCreditHours))
                        {
                            insertproc.Parameters.Add(new SqlParameter("@sem_credit_hours", SqlDbType.Int)).Value = semCreditHours;
                        }
                        else
                        {
                            // Log an error or handle the case where CHrs is not a valid integer
                            // You might want to display an error message to the user or take appropriate action.
                            Console.WriteLine("Error: Invalid value for sem_credit_hours");
                            // Additional handling if needed
                        }

                        insertproc.Parameters.Add(new SqlParameter("@advisor_id", SqlDbType.Int)).Value = advisorId;
                    //insertproc.Parameters.Add(new SqlParameter("@student_id", SqlDbType.Int)).Value = Int32.Parse(StdId);
                        

                        int studentId;
                        if (int.TryParse(StdId, out studentId))
                        {
                            insertproc.Parameters.Add(new SqlParameter("@student_id", SqlDbType.Int)).Value = studentId;
                        }
                        else
                        {
                            // Handle the case where StdId is not a valid integer
                            // You might want to display an error message to the user or take appropriate action.
                        }
                        conn.Open();
                    insertproc.ExecuteNonQuery();
                    conn.Close();
                    
                }
            }
            }
            else
            {
                Response.Write("<p>Advisor ID not found in session.</p>");
            }

        }*/
        private void LoadInsertGradPlanContent()
        {
            ContentPanel.Controls.Add(new LiteralControl(""));

        }


        private void LoadInsertCourseContent()
        {

            ContentPanel.Controls.Add(new LiteralControl(""));

        }
        /*protected void InsertCourse2(object sender, EventArgs e)
        {
            if (Session["advisor"] != null)
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                int studentId;

                if (int.TryParse(StudentIDD.Text, out studentId))
                {
                    string semesterCode = SemCodee.Text;
                    string courseName = CourseNamee.Text;

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();

                        // Check if the student exists
                        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Student WHERE student_id = @studentID", conn))
                        {
                            cmd.Parameters.AddWithValue("@studentID", studentId);
                            int count = (int)cmd.ExecuteScalar();

                            if (count <= 0)
                            {
                                lblMessage.Text = "This Student does not exist.";
                                lblMessage.Visible = true;
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                                return;
                            }
                        }

                        // Check if the student ID is empty
                        if (string.IsNullOrWhiteSpace(StudentIDD.Text))
                        {
                            lblMessage.Text = "Student ID cannot be empty.";
                            lblMessage.Visible = true;
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        // Check if the semester code is in the correct format
                        if (IsValidSemesterCode(semesterCode))
                        {
                            // Check if the course name exists in the course table
                            if (IsCourseNameValid(courseName))
                            {
                                try
                                {
                                    using (SqlCommand cmdCheckOffered = new SqlCommand("SELECT COUNT(*) FROM Course_Semester WHERE course_id = (SELECT course_id FROM Course WHERE course_name = @course_name) AND semester_code = @Semester_code", conn))
                                    {
                                        cmdCheckOffered.Parameters.AddWithValue("@course_name", courseName);
                                        cmdCheckOffered.Parameters.AddWithValue("@Semester_code", semesterCode);
                                        int offeredCount = (int)cmdCheckOffered.ExecuteScalar();

                                        if (offeredCount > 0)
                                        {
                                            using (SqlCommand cmdCheckGradPlan = new SqlCommand("SELECT COUNT(*) FROM GradPlan_Course WHERE plan_id = (SELECT plan_id FROM Graduation_Plan WHERE student_id = @student_id) AND course_id = (SELECT course_id FROM Course WHERE course_name = @course_name)", conn))
                                            {
                                                cmdCheckGradPlan.Parameters.AddWithValue("@student_id", studentId);
                                                cmdCheckGradPlan.Parameters.AddWithValue("@course_name", courseName);

                                                int gradPlanCount = (int)cmdCheckGradPlan.ExecuteScalar();

                                                if (gradPlanCount > 0)
                                                {
                                                    // Course is already in the graduation plan
                                                    lblMessage.Text = "This course is already inserted in the graduation plan of this student.";
                                                    lblMessage.Visible = true;
                                                    lblMessage.ForeColor = System.Drawing.Color.Red;
                                                    return;
                                                }
                                            }

                                            // If the course is offered and not in the graduation plan, proceed to insertion
                                            using (SqlCommand cmd = new SqlCommand("Procedures_AdvisorAddCourseGP", conn))
                                            {
                                                cmd.CommandType = CommandType.StoredProcedure;

                                                cmd.Parameters.Add(new SqlParameter("@student_id", SqlDbType.Int)).Value = studentId;
                                                cmd.Parameters.Add(new SqlParameter("@Semester_code", SqlDbType.VarChar, 40)).Value = semesterCode;
                                                cmd.Parameters.Add(new SqlParameter("@course_name", SqlDbType.VarChar, 40)).Value = courseName;

                                                int rowsAffected = cmd.ExecuteNonQuery();

                                                // Display success message only if rows are affected
                                                if (rowsAffected > 0)
                                                {
                                                    lblMessage.Text = "Course inserted successfully!";
                                                    lblMessage.Visible = true;
                                                    lblMessage.ForeColor = System.Drawing.Color.Green;
                                                    return;
                                                }
                                            }
                                        }
                                    }

                                    // If the code reaches here, the course is not offered
                                    lblMessage.Text = "This course is not offered in the semester.";
                                    lblMessage.Visible = true;
                                    lblMessage.ForeColor = System.Drawing.Color.Red;
                                    return;
                                }
                                catch (Exception ex)
                                {
                                    // Handle the exception, log it, or display an error message
                                    lblMessage.Text = "An error occurred while processing your request.";
                                    lblMessage.Visible = true;
                                    lblMessage.ForeColor = System.Drawing.Color.Red;

                                    // Log the exception details to help diagnose the issue
                                    Console.WriteLine("Exception Message: " + ex.Message);
                                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
                                }

                            }
                            else
                            {
                                lblMessage.Text = "Invalid course name. Please enter a valid course name.";
                                lblMessage.Visible = true;
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Invalid semester code format. Please enter a valid semester code.";
                            lblMessage.Visible = true;
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid student ID. Please enter a valid integer.";
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                Label2.Text = "Advisor ID not found in session.";
                Label2.Visible = true;
                LoginLink.Visible = true;
            }*/

        /* try
                                {

                                    using (SqlCommand cmdCheckOffered = new SqlCommand("SELECT COUNT(*) FROM Course_Semester WHERE course_id = (SELECT course_id FROM Course WHERE course_name = @course_name) AND semester_code = @Semester_code", conn))
                                    {
                                        cmdCheckOffered.Parameters.AddWithValue("@course_name", courseName);
                                        cmdCheckOffered.Parameters.AddWithValue("@Semester_code", semesterCode);
                                        int offeredCount = (int)cmdCheckOffered.ExecuteScalar();

                                        if (offeredCount > 0)
                                        {

                                            using (SqlCommand cmdCheckGradPlan = new SqlCommand("SELECT COUNT(*) FROM GradPlan_course WHERE plan_id = (SELECT plan_id FROM Graduation_Plan WHERE student_id = @student_id) AND course_id = (SELECT course_id FROM Course WHERE course_name = @course_name)", conn))
                                            {
                                                cmdCheckGradPlan.Parameters.AddWithValue("@student_id", studentId);
                                                cmdCheckGradPlan.Parameters.AddWithValue("@course_name", courseName);

                                                int gradPlanCount = (int)cmdCheckGradPlan.ExecuteScalar();

                                                if (gradPlanCount > 0)
                                                {
                                                    // Course is already in the graduation plan
                                                    lblMessage.Text = "This course is already inserted in the graduation plan of this student.";
                                                    lblMessage.Visible = true;
                                                    lblMessage.ForeColor = System.Drawing.Color.Red;
                                                    return;
                                                }
                                            }

                                        }
                                        using (SqlCommand cmd = new SqlCommand("Procedures_AdvisorAddCourseGP", conn))
                                        {
                                            cmd.CommandType = CommandType.StoredProcedure;

                                            cmd.Parameters.Add(new SqlParameter("@student_id", SqlDbType.Int)).Value = studentId;
                                            cmd.Parameters.Add(new SqlParameter("@Semester_code", SqlDbType.VarChar, 40)).Value = semesterCode;
                                            cmd.Parameters.Add(new SqlParameter("@course_name", SqlDbType.VarChar, 40)).Value = courseName;

                                            int rowsAffected = cmd.ExecuteNonQuery();

                                            // Display success message only if rows are affected
                                            if (rowsAffected > 0)
                                            {
                                                lblMessage.Text = "Course inserted successfully!";
                                                lblMessage.Visible = true;
                                                lblMessage.ForeColor = System.Drawing.Color.Green;
                                                return;
                                            }

                                        }
                                    }




                                }

                                catch (Exception ex)
                                {
                                    // Handle the exception, log it, or display an error message
                                    lblMessage.Text = "An error occurred while inserting the course.<br/>This course is not offered in the semester.";
                                    lblMessage.Visible = true;
                                    lblMessage.ForeColor = System.Drawing.Color.Red;
                                }*/
        protected void InsertCourse2(object sender, EventArgs e)
        {
            if (Session["advisor"] != null)
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                int studentId;
                if (int.TryParse(StudentIDD.Text, out studentId))
                {
                    string semesterCode = SemCodee.Text;
                    string courseName = CourseNamee.Text;
                    using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["Advising_System"].ToString()))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Student WHERE student_id = @studentID", conn))
                        {
                            cmd.Parameters.AddWithValue("@studentID", studentId);
                            conn.Open();
                            int count = (int)cmd.ExecuteScalar();

                            if (count <= 0)
                            {
                                lblMessage.Text = "This Student does not exist.";
                                lblMessage.Visible = true;
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                                return;
                            }
                        }
                    }
                    if (string.IsNullOrWhiteSpace(StudentIDD.Text))
                    {
                        lblMessage.Text = "Student ID  cannot be empty.";
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;

                        return;
                    }
                    // Check if the semester code is in the correct format
                    if (IsValidSemesterCode(semesterCode))
                    {
                        // Check if the course name exists in the course table
                        if (IsCourseNameValid(courseName))
                        {

                            using (SqlConnection conn = new SqlConnection(connStr))
                            using (SqlCommand cmdCheckGradPlan = new SqlCommand("SELECT COUNT(*) FROM GradPlan_course WHERE plan_id = any (SELECT plan_id FROM Graduation_Plan WHERE student_id = @student_id) AND course_id = (SELECT course_id FROM Course WHERE name = @course_name)", conn))
                            {
                                cmdCheckGradPlan.Parameters.AddWithValue("@student_id", studentId);
                                cmdCheckGradPlan.Parameters.AddWithValue("@course_name", courseName);
                                conn.Open();
                                int gradPlanCount = (int)cmdCheckGradPlan.ExecuteScalar();

                                if (gradPlanCount > 0)
                                {
                                    // Course is already in the graduation plan
                                    lblMessage.Text = "This course is already inserted in the graduation plan of this student.";
                                    lblMessage.Visible = true;
                                    lblMessage.ForeColor = System.Drawing.Color.Red;
                                    return;
                                }
                            }
                            try
                            {

                                using (SqlConnection conn = new SqlConnection(connStr))
                                {
                                    using (SqlCommand cmd = new SqlCommand("Procedures_AdvisorAddCourseGP", conn))
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;

                                        cmd.Parameters.Add(new SqlParameter("@student_id", SqlDbType.Int)).Value = studentId;
                                        cmd.Parameters.Add(new SqlParameter("@Semester_code", SqlDbType.VarChar, 40)).Value = semesterCode;
                                        cmd.Parameters.Add(new SqlParameter("@course_name", SqlDbType.VarChar, 40)).Value = courseName;

                                        conn.Open();
                                        int rowsAffected = cmd.ExecuteNonQuery();


                                        // Display success message only if rows are affected
                                        if (rowsAffected > 0)
                                        {
                                            lblMessage.Text = "Course inserted successfully!";
                                            lblMessage.Visible = true;
                                            lblMessage.ForeColor = System.Drawing.Color.Green;
                                        }

                                    }
                                }

                            }

                            catch (Exception ex)
                            {

                                // Handle the exception, log it, or display an error message
                                lblMessage.Text = "This course is not offered in the semester.";
                                lblMessage.Visible = true;
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                            }
                        }

                        else
                        {
                            lblMessage.Text = "Invalid course name. Please enter a valid course name.";
                            lblMessage.Visible = true;
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Invalid semester code format. Please enter a valid semester code.";
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid student ID. Please enter a valid integer.";
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                Label2.Text = "Advisor ID not found in session.";
                Label2.Visible = true;
                LoginLink.Visible = true;
            }
        }

        private bool IsCourseNameValid(string courseName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Advising_System"].ToString()))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Course WHERE name = @CourseName", connection))
                    {
                        cmd.Parameters.AddWithValue("@CourseName", courseName);

                        int count = (int)cmd.ExecuteScalar();

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        private bool IsValidSemesterCode(string semesterCode)
        {
            // Regular expression pattern: ^(W|w|S|s)\d+$
            // Explanation:
            //   ^: Asserts the start of the string
            //   (W|w|S|s): Matches either W, w, S, or s
            //   \d+: Matches one or more digits
            //   $: Asserts the end of the string
            string pattern = "^(W|w|S|s)\\d+$";

            return System.Text.RegularExpressions.Regex.IsMatch(semesterCode, pattern);
        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {

            if (MultiView1.ActiveViewIndex == 0)
            {
                LoadDefaultContent();
            }
            else if (MultiView1.ActiveViewIndex == 1)
            {

                LoadStudentsMajorCoursesContent();
            }
            else if (MultiView1.ActiveViewIndex == 2)
            {
                LoadAdvisingStudentsContent();
            }
            else if (MultiView1.ActiveViewIndex == 3)
            {
                LoadAllRequestsContent();
            }
            else if (MultiView1.ActiveViewIndex == 4)
            {
                LoadPendingRequestsContent();
            }
            else if (MultiView1.ActiveViewIndex == 5)
            {
                LoadInsertGradPlanContent();
            }
            else if (MultiView1.ActiveViewIndex == 6)
            {
                LoadInsertCourseContent();
            }
            else if (MultiView1.ActiveViewIndex == 7)
            {
                LoadUpdateGradDateContent();
            }
            else if (MultiView1.ActiveViewIndex == 8)
            {
                LoadDeleteCourseContent();
            }
        }
        protected void ViewAdvisingStudentsWithMajor(object sender, EventArgs e)
        {
            if (Session["advisor"] != null)
            {
                int advisorId = (int)Session["advisor"];
                string major = targetMajor.Text.Trim();

                DataTable resultTable = GetDataFromStoredProcedure(advisorId, major);

                GridViewStudents.DataSource = resultTable;
                GridViewStudents.DataBind();
            }
            else
            {
                Label2.Text = "Advisor ID not found in session.";
                Label2.Visible = true;
                LoginLink.Visible = true;

            }
        }

        private DataTable GetDataFromStoredProcedure(int advisorId, string major)
        {
            DataTable resultTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["Advising_System"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand("Procedures_AdvisorViewAssignedStudents", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AdvisorID", SqlDbType.Int)).Value = advisorId;
                    cmd.Parameters.Add(new SqlParameter("@major", SqlDbType.VarChar, 40)).Value = major;

                    conn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(resultTable);
                    }

                    conn.Close();
                }
            }

            return resultTable;
        }

        protected void InsertionConfirm(object sender, EventArgs e)
        {
            if (Session["advisor"] != null)
            {
                int advisorId = (int)Session["advisor"];
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string date1 = Calendar1.SelectedDate.ToString("yyyy-MM-dd");


                    string sem_code = SemCode.Text;
                    String CHrs = Credit_Hours.Text;
                    String StdId = Student_id.Text;
                    if (string.IsNullOrWhiteSpace(sem_code))
                    {
                        Label1.Text = "Semester code cannot be empty.";
                        Label1.Visible = true;
                        Label1.ForeColor = System.Drawing.Color.Red;

                        return;
                    }
                    if (!(IsValidSemesterCode(sem_code)))
                    {
                        Label1.Text = "Semetser code is in a wrong format.";
                        Label1.Visible = true;
                        Label1.ForeColor = System.Drawing.Color.Red;

                        return;
                    }
                    if (Calendar1.SelectedDate == DateTime.MinValue)
                    {

                        Label1.Text = "Please select a date.";
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label1.Visible = true;
                        return;
                    }
                    using (SqlCommand insertproc = new SqlCommand("Procedures_AdvisorCreateGP", conn))
                    {
                        insertproc.CommandType = CommandType.StoredProcedure;

                        insertproc.Parameters.Add(new SqlParameter("@Semester_code", SqlDbType.VarChar, 40)).Value = sem_code;
                        insertproc.Parameters.Add(new SqlParameter("@expected_graduation_date", SqlDbType.VarChar, 40)).Value = date1;
                        insertproc.Parameters.Add(new SqlParameter("@sem_credit_hours", SqlDbType.Int)).Value = DBNull.Value;
                        insertproc.Parameters.Add(new SqlParameter("@advisor_id", SqlDbType.Int)).Value = advisorId;
                        insertproc.Parameters.Add(new SqlParameter("@student_id", SqlDbType.Int)).Value = DBNull.Value;

                        int semCreditHours;
                        if (int.TryParse(CHrs, out semCreditHours))
                        {
                            insertproc.Parameters["@sem_credit_hours"].Value = semCreditHours;
                        }
                        else
                        {
                            Label1.Text = "Invalid value for Credit Hours.";
                            Label1.ForeColor = System.Drawing.Color.Red;
                            Label1.Visible = true;
                            return;
                        }

                        int studentId;
                        if (int.TryParse(StdId, out studentId))
                        {
                            insertproc.Parameters["@student_id"].Value = studentId;
                        }
                        else
                        {
                            Label1.Text = "Invalid value for Student ID.";
                            Label1.ForeColor = System.Drawing.Color.Red;
                            Label1.Visible = true;
                            return;
                        }

                        conn.Open();
                        int rowsAffected = insertproc.ExecuteNonQuery();

                        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Student WHERE student_id = @studentID", conn))
                        {
                            cmd.Parameters.AddWithValue("@studentID", studentId);

                            int count = (int)cmd.ExecuteScalar();

                            if (count <= 0)
                            {
                                Label1.Text = "This Student does not exist.";
                                Label1.Visible = true;
                                Label1.ForeColor = System.Drawing.Color.Red;
                                return;
                            }
                        }
                        if (rowsAffected > 0)
                        {
                            Label1.Text = "Insertion done!";
                            Label1.ForeColor = System.Drawing.Color.Green;
                            Label1.Visible = true;
                        }



                        else
                        {
                            Label1.Text = "Not enough acquired hours.";
                            Label1.ForeColor = System.Drawing.Color.Red;
                            Label1.Visible = true;
                        }
                    }
                }
            }
            else
            {
                Label1.Text = "Advisor ID not found in session.";
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Visible = true;
            }
        }


        private bool UpdateGraduationDate(DateTime newDate, int studentID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Advising_System"].ToString()))
                {
                    connection.Open();


                    using (SqlCommand cmd = new SqlCommand("Procedures_AdvisorUpdateGP", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@expected_grad_date", newDate);
                        cmd.Parameters.AddWithValue("@studentID", studentID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected <= 0)
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            DateTime newDate = Calendar2.SelectedDate;
            if (newDate == DateTime.MinValue)
            {

                lblUpdateStatus.Text = "Please select a date.";
                lblUpdateStatus.ForeColor = System.Drawing.Color.Red;
                lblUpdateStatus.Visible = true;
                return;
            }
            else if (int.TryParse(TextBox2.Text, out int studentID))
            {
                bool success = UpdateGraduationDate(newDate, studentID);
                if (string.IsNullOrWhiteSpace(TextBox2.Text))
                {
                    lblUpdateStatus.Text = "Student ID cannot be empty.";
                    lblUpdateStatus.Visible = true;
                    lblUpdateStatus.ForeColor = System.Drawing.Color.Red;

                    return;
                }
                if (success)
                {
                    lblUpdateStatus.ForeColor = System.Drawing.Color.Green;
                    lblUpdateStatus.Text = "Updated Successfully.";
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Advising_System"].ToString()))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Student WHERE student_id = @studentID", connection))
                        {
                            cmd.Parameters.AddWithValue("@studentID", studentID);

                            int count = (int)cmd.ExecuteScalar();

                            if (count <= 0)
                            {
                                lblUpdateStatus.Text = "This Student does not exist.";
                                lblUpdateStatus.Visible = true;
                                lblUpdateStatus.ForeColor = System.Drawing.Color.Red;


                            }
                            else
                            {
                                lblUpdateStatus.Text = "Update Failed. This Student do not have a Graduation Plan.";
                                lblUpdateStatus.Visible = true;
                                lblUpdateStatus.ForeColor = System.Drawing.Color.Red;

                            }
                        }
                        //lblUpdateStatus.Text = "Update Failed. This Student do not have a Graduation Plan.";
                    }
                }
                return;
            }
            else
            {
                lblUpdateStatus.Text = "Invalid student ID. Please enter a valid integer.";
                lblUpdateStatus.ForeColor = System.Drawing.Color.Red;
                lblUpdateStatus.Visible = true;
                return;
            }
        }

        private int DeleteCourseFromGradPlan(int studentID, string semesterCode, int courseID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Advising_System"].ToString()))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("Procedures_AdvisorDeleteFromGP", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@studentID", studentID);
                        cmd.Parameters.AddWithValue("@sem_code", semesterCode);
                        cmd.Parameters.AddWithValue("@courseID", courseID);

                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(TextBox3.Text, out int studentID))
            {
                lblDeleteStatus.Text = "Invalid student ID.";
                lblDeleteStatus.Visible = true;
                lblDeleteStatus.ForeColor = System.Drawing.Color.Red;

                return;
            }
            if (string.IsNullOrWhiteSpace(TextBox3.Text))
            {
                lblDeleteStatus.Text = "Student ID cannot be empty.";
                lblDeleteStatus.Visible = true;
                lblDeleteStatus.ForeColor = System.Drawing.Color.Red;

                return;
            }
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Advising_System"].ToString()))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Student WHERE student_id = @studentID", connection))
                {
                    cmd.Parameters.AddWithValue("@studentID", studentID);

                    int count = (int)cmd.ExecuteScalar();

                    if (count <= 0)
                    {
                        lblDeleteStatus.Text = "This Student does not exist.";
                        lblDeleteStatus.Visible = true;
                        lblDeleteStatus.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

            }
            string semesterCode = TextBox4.Text;

            if (string.IsNullOrWhiteSpace(semesterCode))
            {
                lblDeleteStatus.Text = "Semester code cannot be empty.";
                lblDeleteStatus.Visible = true;
                lblDeleteStatus.ForeColor = System.Drawing.Color.Red;

                return;
            }
            if (!(IsValidSemesterCode(semesterCode)))
            {
                lblDeleteStatus.Text = "Semetser code is in a wrong format.";
                lblDeleteStatus.Visible = true;
                lblDeleteStatus.ForeColor = System.Drawing.Color.Red;

                return;
            }
            if (!int.TryParse(TextBox5.Text, out int courseID))
            {
                lblDeleteStatus.Text = "Invalid course ID.";
                lblDeleteStatus.Visible = true;
                lblDeleteStatus.ForeColor = System.Drawing.Color.Red;

                return;
            }

            int rowsAffected = DeleteCourseFromGradPlan(studentID, semesterCode, courseID);
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Advising_System"].ToString()))
            {
                using (SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Course WHERE course_id = @courseID", connection))
                {
                    cmd2.Parameters.AddWithValue("@courseID", courseID);
                    connection.Open();

                    int count = (int)cmd2.ExecuteScalar();

                    if (count <= 0)
                    {
                        lblDeleteStatus.Text = "This Course does not exist.";
                        lblDeleteStatus.Visible = true;
                        lblDeleteStatus.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                if (rowsAffected > 0)
                {
                    lblDeleteStatus.Text = "Deletion successful!";
                    lblDeleteStatus.ForeColor = System.Drawing.Color.Green;
                }
                else if (rowsAffected == 0)
                {
                    using (SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Graduation_Plan WHERE student_id = @studentID and semester_code = @semesterCode", connection))
                    {
                        cmd2.Parameters.AddWithValue("@studentID", studentID);
                        cmd2.Parameters.AddWithValue("@semesterCode", semesterCode);
                        int count = (int)cmd2.ExecuteScalar();

                        if (count <= 0)
                        {
                            lblDeleteStatus.Text = "This Graduation Plan does not exist.";
                            lblDeleteStatus.Visible = true;
                            lblDeleteStatus.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        lblDeleteStatus.Text = "No Graduation Plan with this Semester code";
                        lblDeleteStatus.Visible = true;
                        lblDeleteStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblDeleteStatus.Text = "Deletion failed.";
                    lblDeleteStatus.ForeColor = System.Drawing.Color.Red;

                }

                lblDeleteStatus.Visible = true;
            }


        }
    }
}