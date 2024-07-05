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
    public partial class EditDept : System.Web.UI.Page
    {
        public string id;

        LoggedUser loggedUser = new LoggedUser();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    id = Request.QueryString["DeptId"];
                    if (id != "" && id != null)
                    {
                        FillDeptInfo(id);   
                    }

                }
            }
            catch (Exception ex)
            {
                errorLab.Text = ex.Message;
            }

        }

        protected void RunBtn_Click(object sender, EventArgs e)
        {

            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "UPDATE Dept SET DeptName = @DeptName, Address = @Address WHERE DeptId = @DeptId";
            sqlCommand.Parameters.AddWithValue("DeptName", nameTex.Value);
            sqlCommand.Parameters.AddWithValue("DeptId", DeptId.Value);
            sqlCommand.Parameters.AddWithValue("Address", addressTex.Value);
            DBOPS.SqlDatabaseNonQuery(sqlCommand);

            nameTex.Value = "";
            DeptId.Value = "";
            addressTex.Value = "";
        }

        void FillDeptInfo(string id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * from Dept where DeptId=@DeptId";
            sqlCommand.Parameters.AddWithValue("DeptId", id);
            DataTable dataTable = new DataTable();
            dataTable = DBOPS.SqlDatabaseDatatable(sqlCommand);
            if (dataTable.Rows.Count == 0)
                errorLab.Text = "No Drpatmernt for this id ";
            else
            {
                nameTex.Value = dataTable.Rows[0]["DeptName"].ToString();
                addressTex.Value = dataTable.Rows[0]["Address"].ToString();


            }
        }

        protected void EmpBtn_Click(object sender, EventArgs e)
        {
            FillDeptInfo(DeptId.Value);
          
        }


    }
}