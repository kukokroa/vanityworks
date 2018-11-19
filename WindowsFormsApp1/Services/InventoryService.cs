using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanityWorks.Core.Domain;
using WindowsFormsApp1;
using WindowsFormsApp1.Services;

namespace VanityWorks.Services
{
    class InventoryService
    {

        public static string GetIDinventory()
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";
                query = $"Select * From inventory order by id Desc limit 1";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string user = dataReader["Id"].ToString();


                    con.Close();

                    return user;
                }

                con.Close();
                return "0";
            }

        }
  
        public static string CloseIDinventory()
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";
                query = $"Select * From inventory where DateClosed ='0000-00-00 00:00:00' order by id Desc limit 1";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string user = dataReader["Id"].ToString();


                    con.Close();

                    return "1";
                }

                con.Close();
                return "0";
            }

        }

    }
}
