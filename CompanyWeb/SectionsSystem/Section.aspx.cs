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
    public partial class Section : System.Web.UI.Page
    {
        LoggedUser loggedUser = new LoggedUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                loggedUser = Session["LoggedUser"] as LoggedUser;
                if (!loggedUser.CanAccesThePage("Section"))
                    Response.Redirect( "Default.aspx");
            }
            catch
            {
                Response.Redirect(GV.BassUrl + "login/login.aspx");

            }

            GetSections();
        }

        protected void RunBtn_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "insert into SystemSection (SectionName, SectionOrder) values (@SectionName, @SectionOrder)";
            sqlCommand.Parameters.AddWithValue("SectionName", nameTex.Value);
            sqlCommand.Parameters.AddWithValue("SectionOrder", OrderTex.Value);
            DBOPS.SqlDatabaseNonQuery(sqlCommand);

            nameTex.Value = "";
        }

        void GetSections()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT [SectionId]\r\n      ,[SectionName]\r\n      ,[SectionOrder]\r\n  FROM [Test].[dbo].[SystemSection]";
            DataTable dataTable = new DataTable();
            dataTable = DBOPS.SqlDatabaseDatatable(cmd);
            SectionGV.DataSource = dataTable;
            SectionGV.DataBind();

        }
    }
}