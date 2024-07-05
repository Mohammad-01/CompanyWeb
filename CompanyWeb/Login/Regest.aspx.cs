using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompanyWeb.Helper;

namespace CompanyWeb
{
    public partial class Regest : System.Web.UI.Page
    {
        protected void RunBtn_Click(object sender, EventArgs e)
        {

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = "insert into RegestAcc (Username ,Password, Email) values (@Username,@Password,@Email)";
            sqlCommand.Parameters.AddWithValue("Username", UsernameTextBox.Text);
            sqlCommand.Parameters.AddWithValue("Password", Hashing.GenerateHash(PasswordBox.Text));
            sqlCommand.Parameters.AddWithValue("Email", EmailTextBox.Text);

            UsernameTextBox.Text = "";
            PasswordBox.Text = "";
            EmailTextBox.Text = "";

            DBOPS.SqlDatabaseNonQuery(sqlCommand);
        }
    }
}