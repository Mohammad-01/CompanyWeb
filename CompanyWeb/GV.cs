using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CompanyWeb
{
    public class GV
    {
        public static string BassUrl = ConfigurationManager.AppSettings["Bass_Url"];
    }
}