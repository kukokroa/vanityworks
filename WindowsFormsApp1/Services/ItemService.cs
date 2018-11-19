using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanityWorks.Core.Domain;
using WindowsFormsApp1;

namespace VanityWorks.Services
{
    class ItemService
    {



        public static string UpdateAvailable(string id)
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";
                query = $"Select * From item join inventoryentry on item.Id = inventoryentry.ItemId where item.Id='{id}' limit 1";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string user = dataReader["Id"].ToString();


                    con.Close();
                    if (user != null)
                    {
                        return "no";
                    }
                    else
                    {
                        return "yes";
                    }
                }
                con.Close();
                return "yes";
            }
        }
      

    }
}
