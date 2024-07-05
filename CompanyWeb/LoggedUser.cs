using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.DynamicData;

namespace CompanyWeb
{
    public class LoggedUser
    {
        public List<UserPage> UserPagesList { get; set; }
        public List<UserPageFunctionsClass> UserPagesFunctionsList { get; set; }
        public string userName { get; set; } 

        public void SetUserPagesList()
        {
            SqlCommand SQL = new SqlCommand();
            SQL.CommandText= "SELECT dbo.SystemPages.PageName, dbo.SystemPages.PageWeb ,dbo.SystemPages.PageUrl," +
                "dbo.SystemSection.SectionName,dbo.UsersAccess.Username FROM            dbo.SystemPages INNER JOIN                          dbo.SystemSection " +
                "ON dbo.SystemSection.SectionId = dbo.SystemPages.SectionId INNER JOIN dbo.UsersAccess on " +
                "dbo.UsersAccess.PageWeb = dbo.SystemPages.PageWeb Where dbo.UsersAccess.Username=@Username  order by dbo.SystemSection.SectionOrder";
            SQL.Parameters.AddWithValue("Username", userName);
            DataTable dt = DBOPS.SqlDatabaseDatatable(SQL);

            UserPagesList = new List<UserPage>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserPage Obj = new UserPage();

                Obj.PageName = dt.Rows[i]["PageName"].ToString();
                Obj.PageSection = dt.Rows[i]["SectionName"].ToString();
                Obj.PageURL = dt.Rows[i]["PageUrl"].ToString();
                Obj.PageWeb = dt.Rows[i]["PageWeb"].ToString();
                Obj.Username = dt.Rows[i]["Username"].ToString();

                UserPagesList.Add(Obj);
            }

            SetUserPagesFunctionList();
        }

        public void SetUserPagesFunctionList()
        {
            SqlCommand SQL = new SqlCommand();
            SQL.CommandText= "SELECT Username,PageWeb FROM UsersAccess WHERE Username =@userName";
            SQL.Parameters.AddWithValue("Username", userName);
            DataTable dt = DBOPS.SqlDatabaseDatatable(SQL);

            UserPagesFunctionsList = new List<UserPageFunctionsClass>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserPageFunctionsClass obj = new UserPageFunctionsClass();

                obj.PageName = dt.Rows[i]["PageWeb"].ToString();
         

                UserPagesFunctionsList.Add(obj);
            }
        }

        public bool CanAccesThePage(string PageWeb)
        {
            SqlCommand SQL = new SqlCommand();
            SQL.CommandText = "SELECT Username,PageWeb FROM UsersAccess WHERE Username =@userName and PageWeb=@PageWeb";
            SQL.Parameters.AddWithValue("Username", userName);
            SQL.Parameters.AddWithValue("PageWeb", PageWeb);
            DataTable dt = DBOPS.SqlDatabaseDatatable(SQL);
            if (dt.Rows.Count > 0) 
                return true;    
            return false;
        }
    }

    public class UserPage
    {
        public string PageName { get; set; }
        public string PageURL { get; set; }
        public string PageSection { get; set; }
        public string PageWeb { get; set; }
       
        public string Username { get; set; }
    }

    public class UserPageFunctionsClass
    {
        public string PageName { get; set; }
    }


    

}
