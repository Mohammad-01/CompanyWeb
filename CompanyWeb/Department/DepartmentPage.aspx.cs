using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompanyWeb
{
    public partial class DepartmentPage : System.Web.UI.Page
    {
        public string id;

        LoggedUser loggedUser = new LoggedUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                loggedUser = Session["LoggedUser"] as LoggedUser;
                if (!loggedUser.CanAccesThePage("Add Department"))
                    Response.Redirect(GV.BassUrl + "Default.aspx");
            }
            catch
            {
                Response.Redirect(GV.BassUrl + "login/login.aspx");

            }

            if (!IsPostBack)
                GetDept();
        }

        void GetDept()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT  [DeptId]\r\n ,[DeptName]\r\n ,[Address]\r\n  FROM [Test].[dbo].[Dept]";
            DataTable dataTable = new DataTable();
            dataTable = DBOPS.SqlDatabaseDatatable(cmd);
            DeptGV.DataSource = dataTable;
            DeptGV.DataBind();
        }

        public void DeptGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var str = "";
            if (e.CommandName == "EditDept") { 
            str = e.CommandArgument.ToString();
            Response.Redirect("~/Department/EditDept.aspx?DeptId=" + str);

        }
             else if (e.CommandName == "DeleteDept")
            {
                DeleteRow(Convert.ToInt16(e.CommandArgument));
            }
        }


        public void DeleteRow(int deptId)
        {


            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = "DELETE FROM Dept WHERE DeptId = @deptId";

            sqlCommand.Parameters.AddWithValue("@deptId", deptId);

            DBOPS.SqlDatabaseNonQuery(sqlCommand);


        }
    }
}