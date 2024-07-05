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
    public partial class ReqItems : System.Web.UI.Page
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
            FillDll();
        }


        protected void RunBtn_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = "insert into ReqItems (EmpId, ItemId, SerialNumber, ReqCount) values (@EmpId, @ItemId, @SerialNumber, @ReqCount)";
            sqlCommand.Parameters.AddWithValue("EmpId", EmpIdTex.Text);
            sqlCommand.Parameters.AddWithValue("ItemId", ddlItems.SelectedValue);
            sqlCommand.Parameters.AddWithValue("SerialNumber", SerialNoTex.Value);
            sqlCommand.Parameters.AddWithValue("ReqCount", CountTex.Value);

            EmpIdTex.Text = "";
            SerialNoTex.Value = "";
            CountTex.Value = "";

            DBOPS.SqlDatabaseNonQuery(sqlCommand);


        }

        void FillDll()
        {
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = "SELECT [ItemId]\r\n      ,[ItemName]\r\n     FROM [Test].[dbo].[AddItems]";
            DataTable dataTable = new DataTable();
            dataTable = DBOPS.SqlDatabaseDatatable(sqlCommand);
            ddlItems.DataSource = dataTable;
            ddlItems.DataTextField = "ItemName";
            ddlItems.DataValueField = "ItemId";
            ddlItems.DataBind();

        }


        protected void EmpIdTex_TextChanged(object sender, EventArgs e)
        {
            string empId = EmpIdTex.Text;
            string empName = GetEmployeeName(empId);
            EmpNameTex.Text = empName;
        }

        private string GetEmployeeName(string empId)
        {
            string empName = string.Empty;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT [EmpName] FROM [Emp] where EmpId = @EmpId";
            sqlCommand.Parameters.AddWithValue("@EmpId", empId);
            DataTable dt = new DataTable();
            dt= DBOPS.SqlDatabaseDatatable(sqlCommand) ;
            return dt.Rows[0]["EmpName"].ToString();
        }


    }
}