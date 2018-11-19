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
    class InventoryentryService
    {

        public static string ApproveNewStock(string id)
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";
                query = $"Select ItemId From inventoryentry WHERE InventoryId='{InventoryService.GetIDinventory()}' and ItemId='{id}' and InventoryLogEntryType='1' limit 1";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string user = dataReader["ItemId"].ToString();


                    con.Close();

                    return user;
                }
                con.Close();
                return "0";
            }

        }
        public static void InsertInventoryClosed0()
        {
            if (InventoryService.GetIDinventory() != "0") { 
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";
                    query = $"INSERT INTO inventoryentry(ItemId, InventoryId, DateCreated, Quantity, InventoryLogEntryType) " +
                   //       $"Select ItemId, {InventoryService.GetIDinventory()}, DateCreated, Quantity, InventoryLogEntryType From inventoryentry where InventoryLogEntryType='0' and InventoryId={Int32.Parse(InventoryService.GetIDinventory()) -1} and ItemId not in(Select ItemId From inventoryentry where InventoryLogEntryType='0' and InventoryId={InventoryService.GetIDinventory()} )";
                   $"Select ItemId, {InventoryService.GetIDinventory()}, DateCreated, sum(Quantity), 0 From inventoryentry where InventoryId={Int32.Parse(InventoryService.GetIDinventory()) - 1} and ItemId not in(Select ItemId From inventoryentry where InventoryLogEntryType='0' and InventoryId={InventoryService.GetIDinventory()} ) Group by ItemId";

                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                con.Close();
            }
            }

        }
        public static string CorrectQuantity(string id)
        {
          
                using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
                {
                    con.Open();
                    string query = "";
                    query = $"Select  sum(round(Quantity,0)) as Quantity  From inventoryentry where ItemId='{id}' and InventoryId={Int32.Parse(InventoryService.GetIDinventory()) - 1}  Group by ItemId";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string user = dataReader["Quantity"].ToString();

                        return user;
                    }
                    con.Close();
                    return "0";
                }
          
        }
        public static void InsertInventoryClosed1()
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";

                query = $"INSERT INTO inventoryentry(ItemId, InventoryId, DateCreated, Quantity, InventoryLogEntryType) " +
                $"Select ItemId, {InventoryService.GetIDinventory()}, DateCreated, Quantity, InventoryLogEntryType From inventoryentry where InventoryLogEntryType='1' and InventoryId={Int32.Parse(InventoryService.GetIDinventory()) - 1} and ItemId not in(Select ItemId From inventoryentry where InventoryLogEntryType='1' and InventoryId={InventoryService.GetIDinventory()} )";

                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                con.Close();
            }

        }
    }
}
