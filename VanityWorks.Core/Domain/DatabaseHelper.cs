using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanityWorks.Core.Domain
{
    class DatabaseHelper
    {
        public static string GetSQLiteConnectionString()
        {
            return @"Server=localhost;Database=test;Uid=root;Pwd=;SslMode=none;";
        }
    }
}
