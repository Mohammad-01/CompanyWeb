using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompanyWeb
{
    public partial class Employee : System.Web.UI.Page
    {

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
                GetEmp();
        }

        void GetEmp()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT emp.*, dept.DeptName FROM Emp" +
                " Inner JOIN dept ON emp.DepartmentID = Dept.DeptId";
            DataTable dataTable = new DataTable();
            dataTable = DBOPS.SqlDatabaseDatatable(cmd);
            EmpGv.DataSource = dataTable;
            EmpGv.DataBind();

        }

        public void EmpGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var str = "";
            if (e.CommandName == "EditEmp")
            {
                str = e.CommandArgument.ToString();
                Response.Redirect("~/Employee/EditEmp.aspx?empID=" + str);

            }
            else if (e.CommandName == "DeleteEmp")
            {
                DeleteRow(Convert.ToInt16(e.CommandArgument));
            }
                
        }

        protected void EmpGv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int empID = Convert.ToInt32(EmpGv.DataKeys[e.RowIndex].Value);
            DeleteRow(empID);
            GetEmp(); 
        }


        public void DeleteRow(int empID)
        {

            
                    SqlCommand sqlCommand = new SqlCommand();
            
                    sqlCommand.CommandText = "DELETE FROM Emp WHERE EmpId = @empId";

                    sqlCommand.Parameters.AddWithValue("@empId", empID);

                    DBOPS.SqlDatabaseNonQuery(sqlCommand);
                
           
        }

    }
}