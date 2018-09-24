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
      
        public static void AddOrUpdate(Item item)
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";

                if (item.Id > 0)
                {
                    query = $"UPDATE item " +
                    $"SET Name ='{item.Name}', SupplierName='{item.SupplierName}',Unit='{item.Unit}'," +
                    $"UnitQuantity='{item.UnitQuantity}',UnitQuantityPrice='{item.UnitQuantityPrice}'" +
                    $"WHERE Id = {item.Id}";

                }
                else
                {
                    query = $"INSERT INTO user(Name,SupplierName,Unit,UnitQuantity,UnitQuantityPrice, DateCreated, Deleted) " +
                    $"VALUES('{item.Name}','{item.SupplierName}','{item.Unit}','{item.UnitQuantity}', {item.UnitQuantityPrice}, {DateTime.Now}, 0)";
                }
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                con.Close();
            }

        }

        public static void AddOrUpdate1(Item item)
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";

                //if (item.Id > 0)
                //{
                //    query = $"UPDATE item " +
                //    $"SET Name ='{item.Name}', SupplierName='{item.SupplierName}',Unit='{item.Unit}'," +
                //    $"UnitQuantity='{item.UnitQuantity}',UnitQuantityPrice='{item.UnitQuantityPrice}'" +
                //    $"WHERE Id = {item.Id}";

                //}
                //else
                //{
                //    query = $"INSERT INTO user(Name,SupplierName,Unit,UnitQuantity,UnitQuantityPrice, DateCreated, Deleted) " +
                //    $"VALUES('{item.Name}','{item.SupplierName}','{item.Unit}','{item.UnitQuantity}', {item.UnitQuantityPrice}, {DateTime.Now}, 0)";
                //}

                query = $"Select * From item";


                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                MySqlDataAdapter adapater = new MySqlDataAdapter(cmd);
                con.Open();
             //   adapater.Fill();
                con.Close();
            }

        }


    }
}
