using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CompanyWeb
{
    public class DBOPS
    {
        public static DataTable SqlDatabaseDatatable(SqlCommand cmd)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeCon2"].ToString());
            cmd.Connection = conn;
            conn.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter();
            sqlData.SelectCommand = cmd;
            sqlData.Fill(table);
            conn.Close();
            return table;
        }
        public static int SqlDatabaseScalar(SqlCommand cmd)
        {
            int empId;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeCon2"].ToString());
            cmd.Connection = conn;
            conn.Open();
            empId = (int)cmd.ExecuteScalar();
            conn.Close();
            return empId;
        }

        public static void SqlDatabaseNonQuery(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeCon2"].ToString());
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


    }
}