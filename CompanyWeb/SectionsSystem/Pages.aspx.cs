using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Css.Ast;
using static System.Collections.Specialized.BitVector32;

namespace CompanyWeb.SectionsSystem
{
    public partial class Pages : System.Web.UI.Page
    {
        public string id;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedUser loggedUser = new LoggedUser();

            try
            {
                loggedUser = Session["LoggedUser"] as LoggedUser;
                if (!loggedUser.CanAccesThePage("Add new page"))
                    Response.Redirect(GV.BassUrl + "Default.aspx");
            }
            catch
            {
                Response.Redirect(GV.BassUrl + "login/login.aspx");

            }

            FillDll();
            GetPages();
        }

        void FillDll()
        {
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = "SELECT TOP (1000) [SectionId]\r\n      ,[SectionName]\r\n  FROM [Test].[dbo].[SystemSection]\r\n";
            DataTable dataTable = new DataTable();
            dataTable = DBOPS.SqlDatabaseDatatable(sqlCommand);
            DDL.DataSource = dataTable;
            DDL.DataTextField = "SectionName";
            DDL.DataValueField = "SectionId";
            DDL.DataBind();
        }

        protected void RunBtn_Click(object sender, EventArgs e)
        {

            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "insert into SystemPages (SectionId, PageName ,PageWeb, PageUrl, PageOrder) values (@SectionId, @PageName, @PageWeb, @PageUrl, @PageOrder)";
            sqlCommand.Parameters.AddWithValue("SectionId", DDL.SelectedValue);
            sqlCommand.Parameters.AddWithValue("PageName", PageWebnameTex.Value);
            sqlCommand.Parameters.AddWithValue("PageWeb", PageWebTex.Value);
            sqlCommand.Parameters.AddWithValue("PageUrl", UrlTex.Value);
            sqlCommand.Parameters.AddWithValue("PageOrder", OrderTex.Value);

            DBOPS.SqlDatabaseNonQuery(sqlCommand);

      
        }

        void GetPages()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  [PageId]\r\n    ,[PageName]\r\n      ,[SectionId]\r\n      ,[PageWeb]\r\n      ,[PageUrl]\r\n      ,[PageOrder]\r\n  FROM [Test].[dbo].[SystemPages]\r\n";
            DataTable dataTable = new DataTable();
            dataTable = DBOPS.SqlDatabaseDatatable(cmd);
            PageGV.DataSource = dataTable;
            PageGV.DataBind();

        }
    }
}