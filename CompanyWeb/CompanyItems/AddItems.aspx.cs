using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompanyWeb.CompanyItems
{
    public partial class AddItems : System.Web.UI.Page
    {
        LoggedUser loggedUser = new LoggedUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                loggedUser = Session["LoggedUser"] as LoggedUser;
                if (!loggedUser.CanAccesThePage("Department"))
                    Response.Redirect(GV.BassUrl + "Default.aspx");
            }
            catch
            {
                Response.Redirect(GV.BassUrl + "login/login.aspx");

            }
            GetItems();
        }

        protected void RunBtn_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "insert into AddItems (ItemName, Count) values (@ItemName,@Count)";
            sqlCommand.Parameters.AddWithValue("ItemName", nameTex.Value);
            sqlCommand.Parameters.AddWithValue("Count", numberTex.Value);
            DBOPS.SqlDatabaseNonQuery(sqlCommand);

            nameTex.Value = "";
            numberTex.Value = "";
         

        }

        void GetItems()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT TOP (1000) [ItemId]\r\n      ,[ItemName]\r\n      ,[Count]\r\n  FROM [Test].[dbo].[AddItems]\r\n";
            DataTable dataTable = new DataTable();
            dataTable = DBOPS.SqlDatabaseDatatable(cmd);
            ItemsGv.DataSource = dataTable;
            ItemsGv.DataBind();

        }


    }
}