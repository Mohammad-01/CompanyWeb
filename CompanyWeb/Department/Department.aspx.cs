using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompanyWeb
{
    public partial class Department : System.Web.UI.Page
    {
        LoggedUser loggedUser =new LoggedUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            try 
            {
                loggedUser = Session["LoggedUser"] as LoggedUser;
                if (!loggedUser.CanAccesThePage("Department"))
                    Response.Redirect(GV.BassUrl + "Default.aspx");                    
            }
            catch {
                    Response.Redirect(GV.BassUrl + "login/login.aspx");

            }

        }

        protected void RunBtn_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "insert into dept (DeptName, Address) values (@name,@address)";
            sqlCommand.Parameters.AddWithValue("name", nameTex.Value);
            sqlCommand.Parameters.AddWithValue("address", addressTex.Value);
            DBOPS.SqlDatabaseNonQuery(sqlCommand);


        }
    }
}