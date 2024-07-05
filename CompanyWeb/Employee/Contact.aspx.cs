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
    public partial class Contact : System.Web.UI.Page
    {
        LoggedUser loggedUser = new LoggedUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                loggedUser = Session["LoggedUser"] as LoggedUser;
                if (!loggedUser.CanAccesThePage("Contact"))
                    Response.Redirect(GV.BassUrl + "Default.aspx");
            }
            catch
            {
                Response.Redirect(GV.BassUrl + "login/login.aspx");

            }

            GetEmpContact();

        }

        void GetEmpContact()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT        dbo.Dept.DeptName, dbo.ContactInfo.EmpId, dbo.Emp.EmpName, dbo.Emp.DOB, dbo.Emp.StartDate, " +
                "dbo.ContactInfo.PhoneNumber, dbo.ContactInfo.AlternativePhoneNumber, dbo.ContactInfo.Email, \r\n                         " +
                "dbo.ContactInfo.Address\r\nFROM           " +
                " dbo.ContactInfo INNER JOIN\r\n                        " +
                " dbo.Emp ON dbo.ContactInfo.EmpId = dbo.Emp.EmpId INNER JOIN\r\n                         " +
                "dbo.Dept ON dbo.Emp.DepartmentID = dbo.Dept.DeptId";
            DataTable dataTable = new DataTable();
            dataTable = DBOPS.SqlDatabaseDatatable(cmd);
            EmpGv.DataSource = dataTable;
            EmpGv.DataBind();

        }
    }
}