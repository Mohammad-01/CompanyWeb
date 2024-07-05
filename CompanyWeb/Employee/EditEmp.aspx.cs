using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompanyWeb
{
    public partial class EditEmp : System.Web.UI.Page
    {
        public string id;

        LoggedUser loggedUser = new LoggedUser();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                FillDll();
                id=Request.QueryString["empID"];
                if (id != "" && id != null)
                {
                    FillEmpInfo(id);
                    FillConInfo(id);
                }

            }
        }
        
        void FillDll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            sqlCommand.CommandText = "SELECT [DeptId] ,[DeptName] FROM [Test].[dbo].[Dept]";
            dataTable = DBOPS.SqlDatabaseDatatable(sqlCommand);
            ddlDepartment.DataSource = dataTable;
            ddlDepartment.DataTextField = "DeptName";
            ddlDepartment.DataValueField = "DeptId";
            ddlDepartment.DataBind();
        }

        protected void RunBtn_Click(object sender, EventArgs e)
        {

            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand();            
            sqlCommand.CommandText = "UPDATE emp SET EmpName = @EmpName, dob = @dob, StartDate = @StartDate, DepartmentID = @DepartmentID WHERE empId = @EmpId";
            sqlCommand.Parameters.AddWithValue("EmpName", nameTex.Value);
            
          

            sqlCommand.Parameters.AddWithValue("DepartmentID", ddlDepartment.SelectedValue);
            sqlCommand.Parameters.AddWithValue("EmpId", EmpId.Value);

            sqlCommand.CommandText = "UPDATE ContactInfo SET PhoneNumber = @PhoneNumber, AlternativePhoneNumber = @AlternativePhoneNumber, Email = @Email, Address = @Address";
            sqlCommand.Parameters.AddWithValue("PhoneNumber", phone_numberTex.Value);
            sqlCommand.Parameters.AddWithValue("AlternativePhoneNumber", alt_numberTex.Value);
            sqlCommand.Parameters.AddWithValue("Email", emailTex.Value);
            sqlCommand.Parameters.AddWithValue("Address", addressTex.Value);
            DBOPS.SqlDatabaseNonQuery(sqlCommand);

            nameTex.Value = "";
            dobTex.Value = ""; 
            start_dateTex.Value = "";
            EmpId.Value = "";
            phone_numberTex.Value = "";
            alt_numberTex.Value = "";
            emailTex.Value = "";
            addressTex.Value = "";


        }
        void FillEmpInfo(string id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * from emp where empid=@id";
            sqlCommand.Parameters.AddWithValue("id", id);
            DataTable dataTable = new DataTable();
            dataTable = DBOPS.SqlDatabaseDatatable(sqlCommand);
            if (dataTable.Rows.Count == 0)
                errorLab.Text = "No employee for this id ";
            else
            {
                 nameTex.Value = dataTable.Rows[0]["EmpName"].ToString();
                ddlDepartment.SelectedValue = dataTable.Rows[0]["DepartmentID"].ToString();              
                dobTex.Value =Convert.ToDateTime(dataTable.Rows[0]["DOB"].ToString()).ToString("yyyy-MM-dd");                
                start_dateTex.Value = Convert.ToDateTime(dataTable.Rows[0]["StartDate"].ToString()).ToString("yyyy-MM-dd");
               
            }
        }

        void FillConInfo(string id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * from ContactInfo where empid=@id";
            sqlCommand.Parameters.AddWithValue("id", id);
            DataTable dataTable = new DataTable();
            dataTable = DBOPS.SqlDatabaseDatatable(sqlCommand);
            if (dataTable.Rows.Count == 0)
                errorLab.Text = "No employee for this id ";
            else
            {
                phone_numberTex.Value = dataTable.Rows[0]["PhoneNumber"].ToString();
                alt_numberTex.Value = dataTable.Rows[0]["AlternativePhoneNumber"].ToString();
                emailTex.Value = dataTable.Rows[0]["Email"].ToString();
                addressTex.Value = dataTable.Rows[0]["Address"].ToString();

            }
        }

        protected void EmpBtn_Click(object sender, EventArgs e)
        {
            FillEmpInfo(EmpId.Value);
            FillConInfo(EmpId.Value);
        }
    }
}