using CompanyWeb.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CompanyWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            if (IsValidCredentials(username, Hashing.GenerateHash(password)))
            
            {
                LoggedUser loggedUser = new LoggedUser();
                loggedUser.userName = username;
                loggedUser.SetUserPagesList();
                Session["LoggedUser"]=loggedUser;
                Session["username"]= loggedUser.userName;   
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                ErrorMessageLabel.Text = "Invalid username or password. Please try again.";
            }
        }

        private bool IsValidCredentials(string username, string password)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select count(*) from [RegestAcc] " +
                "where [Username] = @username And [Password] = @password";
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);
            int count = DBOPS.SqlDatabaseScalar(cmd);
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}