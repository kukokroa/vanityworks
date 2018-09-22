using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VanityWorks.Core.Domain;

namespace WindowsFormsApp1
{
    class DatabaseHelper
    {
        public static string GetSQLiteConnectionString()
        {
            return @"Server=localhost;Database=test;Uid=root;Pwd=;SslMode=none;";
        }

       
    }
}
