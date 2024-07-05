using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;

namespace CompanyWeb
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void ResetPasswordButton_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(email))
            {
         
                if (UserExists(email))
                {
                  
                    SendResetInstructions(email);
                    ResetMessageLabel.Text = "Reset instructions sent to your email.";
                }
                else
                {
                    ResetMessageLabel.Text = "Email address not found.";
                }
            }
            else
            {
                ResetMessageLabel.Text = "Please enter your email address.";
            }
        }

        private bool UserExists(string email)
        {
   
                string emailvalue = string.Empty;

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "  SELECT TOP(1) [email] FROM [RegestAcc] where username = @Username ";
                sqlCommand.Parameters.AddWithValue("@Username", Username);
                DataTable dt = new DataTable();
                dt = DBOPS.SqlDatabaseDatatable(sqlCommand);
                WelcomeTex.Text = "Welcome " + Username + " to RJ website";
                return dt.Rows[0]["Username"].ToString();
           

            return false; 
        }

        private void SendResetInstructions(string email)
        {
           

        }
    }
}
