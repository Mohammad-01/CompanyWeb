using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace CompanyWeb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            BuildMainDiv();
            if (Session["username"] != null)
            {
               string username =  Session["username"].ToString();
                GetClientName(username);
            }
        }


        void BuildMainDiv()
        {
            LoggedUser loggedUser = Session["LoggedUser"] as LoggedUser;
            
            StringBuilder stringBuilder = new StringBuilder();
            string CurrentSetion = "";
            stringBuilder.AppendLine("<ul class=\"navbar-nav flex-grow-1\">");
            stringBuilder.AppendLine($"<li class=\"nav-item\"><a class=\"nav-link\" runat=\"server\" href= {GV.BassUrl} > Home</a></li>");
            int Counter = 0;
            foreach (var page in loggedUser.UserPagesList)
            {
                if (page.PageSection == CurrentSetion)
                {
                    stringBuilder.AppendLine($"<a class=\"dropdown-item\" href=\"{GV.BassUrl + page.PageURL}\">{page.PageName}</a>");
                }
                else
                {
                    if (Counter == 0)
                    {
                        CurrentSetion=page.PageSection;
                        stringBuilder.AppendLine("<li class=\"nav-item dropdown\">");
                        stringBuilder.AppendLine($"<a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"{page.PageSection}\" role=\"button\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">{page.PageSection}</a>");
                        stringBuilder.AppendLine($"<div class=\"dropdown-menu\" aria-labelledby=\"{page.PageSection}\">");
                        stringBuilder.AppendLine($"<a class=\"dropdown-item\" href=\"{GV.BassUrl+ page.PageURL}\">{page.PageName}</a>");
                    }
                    else
                    {
                        CurrentSetion = page.PageSection;
                        stringBuilder.AppendLine("</div>");
                        stringBuilder.AppendLine("</li>");
                        stringBuilder.AppendLine("<li class=\"nav-item dropdown\">");
                        stringBuilder.AppendLine($"<a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"{page.PageSection}\" role=\"button\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">{page.PageSection}</a>");
                        stringBuilder.AppendLine($"<div class=\"dropdown-menu\" aria-labelledby=\"{page.PageSection}\">");
                        stringBuilder.AppendLine($"<a class=\"dropdown-item\" href=\"{GV.BassUrl + page.PageURL}\">{page.PageName}</a>");
                    }
                }
                Counter++;
                
            }

            stringBuilder.AppendLine("</ul>");
            mainDiv.InnerHtml = stringBuilder.ToString();
        }

       
        public class NavBarBuilder
        {
            public string BuildNavBar(List<UserPage> userPagesList)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("<nav>");
                sb.Append("<ul>");


                sb.Append("</ul>");
                sb.Append("</nav>");

                return sb.ToString();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login/Login.aspx");

        }

        public string GetClientName(string Username)
        {
            string ClinetName = string.Empty;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "  SELECT TOP(1) [Username] FROM [RegestAcc] where username = @Username ";
            sqlCommand.Parameters.AddWithValue("@Username", Username);
            DataTable dt = new DataTable();
            dt = DBOPS.SqlDatabaseDatatable(sqlCommand);
            WelcomeTex.Text = "Welcome "+Username +" to RJ website";
            return dt.Rows[0]["Username"].ToString();
        }
    }
}

