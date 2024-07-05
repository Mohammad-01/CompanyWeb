using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompanyWeb.SectionsSystem
{
    public partial class Users : System.Web.UI.Page
    {
        LoggedUser loggedUser = new LoggedUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                loggedUser = Session["LoggedUser"] as LoggedUser;
                if (!loggedUser.CanAccesThePage("Add new user"))
                    Response.Redirect("Default.aspx");
            }
            catch
            {
                Response.Redirect("login/login.aspx");

            }
            if (!IsPostBack)
            {
                FillDllForUser();
                FillDll();
                GetPages();
            }
           

        }

        void FillDll(string user ="")
        {
                SqlCommand sqlCommand = new SqlCommand();
                if (user == "")
                {
                    sqlCommand.CommandText = "SELECT [PageWeb] FROM [Test].[dbo].[SystemPages]";
                }
                else
                {
                    sqlCommand.CommandText = "SELECT        SystemPages.PageWeb\r\nFROM            SystemPages \r\nexcept SELECT UsersAccess.PageWeb\r\nFROM UsersAccess WHERE  UsersAccess.Username=@username";
                    sqlCommand.Parameters.AddWithValue("@username", user);
                }

                DataTable dataTable = new DataTable();
                dataTable = DBOPS.SqlDatabaseDatatable(sqlCommand);
                DDL.DataSource = dataTable;
                DDL.DataTextField = "PageWeb";
                DDL.DataBind();
            }

      

        void FillDllForUser()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT [Username] FROM [Test].[dbo].[RegestAcc]";

            DataTable dataTable = new DataTable();
            dataTable = DBOPS.SqlDatabaseDatatable(sqlCommand);
            DDLUser.DataSource = dataTable;
            DDLUser.DataTextField = "Username";
            DDLUser.DataValueField = "Username";
            DDLUser.DataBind();
        }


        protected void RunBtn_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "insert into UsersAccess (PageWeb ,Username) values (@PageWeb ,@Username)";
            sqlCommand.Parameters.AddWithValue("PageWeb", DDL.SelectedValue);
            sqlCommand.Parameters.AddWithValue("Username", DDLUser.SelectedValue);
            DBOPS.SqlDatabaseNonQuery(sqlCommand);

        }

        public void DDLUser_TextChanged(object sender, EventArgs e)
        {
            FillDll(DDLUser.SelectedValue);
        }

        void GetPages()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  [Username] ,[PageWeb]  FROM [Test].[dbo].[UsersAccess]";
            DataTable dataTable = new DataTable();
            dataTable = DBOPS.SqlDatabaseDatatable(cmd);
            UserGV.DataSource = dataTable;
            UserGV.DataBind();

        }
    }
}