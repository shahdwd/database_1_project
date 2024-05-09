using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class issueinstallment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("AdminLogin.aspx", false);
                Context.ApplicationInstance.CompleteRequest();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (!int.TryParse(TextBox1.Text, out int paymentid))
            {
                Response.Write("Invalid Payment ID. Please enter a valid payment ID.");
                return;
            }
            SqlCommand checkPaymentExistence = new SqlCommand("SELECT COUNT(*) FROM Payment WHERE payment_id = @paymentID", conn);
            checkPaymentExistence.Parameters.Add(new SqlParameter("@paymentID", paymentid));

            SqlCommand checkExistingInstallments = new SqlCommand("SELECT COUNT(*) FROM Installment WHERE payment_id = @paymentID", conn);
            checkExistingInstallments.Parameters.Add(new SqlParameter("@paymentID", paymentid));

            SqlCommand issueinst = new SqlCommand("Procedures_AdminIssueInstallment", conn);
            issueinst.CommandType = CommandType.StoredProcedure;
            issueinst.Parameters.Add(new SqlParameter("@payment_id", paymentid));
            try
            {
                conn.Open();
                int paymentExistenceCount = (int)checkPaymentExistence.ExecuteScalar();
                if (paymentExistenceCount == 0)
                {
                    Response.Write($"No payment found with Payment ID {paymentid}. Please enter a valid Payment ID.");
                    return;
                }
                int existingInstallmentsCount = (int)checkExistingInstallments.ExecuteScalar();
                if (existingInstallmentsCount > 0)
                {
                    Response.Write($"Installments for Payment ID {paymentid} have already been issued before.");
                    return;
                }
                issueinst.ExecuteNonQuery();
                Response.Write("Installments for the payment ID have been issued successfully");
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", false);
            Context.ApplicationInstance.CompleteRequest();

        }
    }
}