using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompanyWeb.Page
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        LoggedUser loggedUser = new LoggedUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            FillDll();
        }
       

        void FillDll()
        {
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = "SELECT [DeptId] ,[DeptName] FROM [Test].[dbo].[Dept]";
            DataTable dataTable = new DataTable();
            dataTable=DBOPS.SqlDatabaseDatatable(sqlCommand);
            ddlDepartment.DataSource = dataTable;
            ddlDepartment.DataTextField = "DeptName";
            ddlDepartment.DataValueField = "DeptId";
            ddlDepartment.DataBind();
            
        }
        protected void RunBtn_Click(object sender, EventArgs e)
        {
            
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = "insert into emp (EmpName ,DepartmentID,DOB,StartDate) OUTPUT INSERTED.EmpId values (@name,@depid,@dob,@startDate)";

            sqlCommand.Parameters.AddWithValue("name", nameTex.Value);
            sqlCommand.Parameters.AddWithValue("depid", ddlDepartment.SelectedValue);
            sqlCommand.Parameters.AddWithValue("dob", dobTex.Value);
            sqlCommand.Parameters.AddWithValue("startDate", start_dateTex.Value);

            int EmpId = DBOPS.SqlDatabaseScalar(sqlCommand);
            sqlCommand.Parameters.Clear();
            
            sqlCommand.CommandText = "insert into contactinfo (EmpId,PhoneNumber, AlternativePhoneNumber, Email, Address) OUTPUT INSERTED.EmpId values (@EmpId,@PhoneNumber,@AlternativePhoneNumber,@Email, @Address)";

            sqlCommand.Parameters.AddWithValue("PhoneNumber", phone_numberTex.Value);
            sqlCommand.Parameters.AddWithValue("AlternativePhoneNumber", alt_numberTex.Value);
            sqlCommand.Parameters.AddWithValue("Email", emailTex.Value);
            sqlCommand.Parameters.AddWithValue("address", addressTex.Value);
            sqlCommand.Parameters.AddWithValue("EmpId", EmpId);
            DBOPS.SqlDatabaseScalar(sqlCommand);
        }
    }
}