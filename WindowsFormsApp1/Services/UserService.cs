using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VanityWorks.Core.Domain;
using VanityWorks.Services;

namespace WindowsFormsApp1.Services
{
    public class UserService
    {
        public static User GetUserByEmailAndPassword(string emailaddress, string password)
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                password = MD5Hash(password);
                con.Open();
                string query = $"SELECT * FROM user WHERE emailaddress='{emailaddress}' AND password='{password}'"; 
                  //  $"UPDATE user SET isLogin='1' WHERE emailaddress='{emailaddress}' AND password='{password}'";

                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    var user = new User();
                    user.Id = Convert.ToInt32(dataReader["Id"].ToString());
                    user.FirstName = dataReader["FirstName"].ToString();
                    user.MiddleName = dataReader["MiddleName"].ToString();
                    user.LastName = dataReader["LastName"].ToString();
                    user.EmailAddress = dataReader["EmailAddress"].ToString();
                    user.ContactNumber = dataReader["ContactNumber"].ToString();
                    var admin = dataReader["Admin"].ToString();

                    if (admin == "1")
                    {
                        user.Admin = true;
                    }

                    isLogin(Convert.ToInt32(dataReader["Id"].ToString()));
                    con.Close();

                    return user;
                }

                return null;
            }
        }
      

        public static void isLogin(int id)
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";
                query =   $"UPDATE user SET isLogin='1' WHERE id='"+id+"'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                con.Close();
            }
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";
                query = $"UPDATE user SET isLogin='0' WHERE id !='" + id + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                con.Close();
            }
        }

        public static string GetisLogin()
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";
                query = $"Select * From user WHERE isLogin='1' limit 1";
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
      
        public static string ApproveUpdate(string id)
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";
                query = $"Select InventoryLogEntryType From inventoryentry WHERE InventoryId='{InventoryService.GetIDinventory()}' and ItemId='{id}' limit 1";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string user = dataReader["InventoryLogEntryType"].ToString();


                    con.Close();

                    return user;
                }
                con.Close();
                return "0";
            }

        }
     
    
        public static string GetPriceItem(string id)
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";
                query = $"Select UnitQuantityPrice From item where id='{id}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string user = dataReader["UnitQuantityPrice"].ToString();


                    con.Close();

                    return user;
                }

                con.Close();
                return "0";
            }

        }
        public static void AddOrUpdate(User user)
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";

                if (user.Id > 0)
                {
                    query = $"UPDATE user " +
                    $"SET FirstName ='{user.FirstName}', MiddleName='{user.MiddleName}',LastName='{user.LastName}'," +
                    $"EmailAddress='{user.EmailAddress}',Password='{MD5Hash(user.Password)}',ContactNumber='{user.ContactNumber}'," +
                    $"Admin= '{user.Admin}' WHERE Id = {user.Id}";

                }
                else
                {
                    query = $"INSERT INTO user(FirstName,MiddleName,LastName,EmailAddress,Password,ContactNumber,Admin, DateCreated, Deleted ) " +
                    $"VALUES('{user.FirstName}','{user.MiddleName}','{user.LastName}','{user.EmailAddress}','{MD5Hash(user.Password)}','{user.ContactNumber}', '{user.Admin}', '{DateTime.Now}', '0')";
                }
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                con.Close();
            }

        }

        public static void UpdateItem(Item item)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
                {
                    con.Open();
                    string query = "";

                    if (item.Id > 0)
                    {


                        //query = $"UPDATE item " +
                        //$"SET Name ='{item.Name}', SupplierName='{item.SupplierName}',Unit='{item.Unit}'," +
                        //$"UnitQuantity='{item.UnitQuantity}',UnitQuantityPrice='{(item.UnitQuantityPrice)}'" +
                        //$" WHERE Id = {item.Id} and DateCreated='{DateTime.Now.ToString("yyyy-MM-dd")}'";
                        query = $"UPDATE item " +
                    $"SET Name ='{item.Name}', SupplierName='{item.SupplierName}',Unit='{item.Unit}'," +
                    $"UnitQuantity='{item.UnitQuantity}',UnitQuantityPrice='{item.UnitQuantityPrice}',DateCreated='{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}'" +
                    $" WHERE Id = {item.Id}";
                    }
                    else
                    {
                    }
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    con.Close();
                }
            }
            catch { }

        }

        public static void UpdateItemStock(string id,int stock)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
                {
                   
                    con.Open();
                    string query = "";
                    query = $"INSERT INTO inventoryentry(DateCreated,Quantity,ItemId,InventoryId,InventoryLogEntryType) " +
                  $"values('{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}',{stock},{id},{InventoryService.GetIDinventory()},'1') ";
                    //query = $"UPDATE item " +
                    //$"SET UnitQuantityPrice=(UnitQuantityPrice/UnitQuantity) * (UnitQuantity +  '{stock}'),UnitQuantity=UnitQuantity +'{stock}',DateUpdated='{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}'" +
                    //$" WHERE Id = {id}";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    con.Close();
                }
            }
            catch { }

        }
        public static void UpdateItemIn(Item item)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
                {
                    con.Open();
                    string query = "";
                    string idinvent = InventoryService.GetIDinventory();
                    if (item.Id > 0)
                    {
                        query = $"UPDATE item " +
                      //  $"SET UnitQuantityPrice=(UnitQuantityPrice/UnitQuantity) * '{item.UnitQuantity + item.newStock}',DateUpdated='{DateTime.Now.ToString("yyyy-MM-dd")}',UnitQuantity='{item.UnitQuantity + item.newStock}',OldUnitQuantity='{item.OldUnitQuantity}',newStock='{item.newStock}',inventoryid={idinvent}" +
                        $"SET UnitQuantityPrice=(UnitQuantityPrice/UnitQuantity) * '{item.UnitQuantity}',DateUpdated='{DateTime.Now.ToString("yyyy-MM-dd")}',UnitQuantity='{item.UnitQuantity }'" +
                        $" WHERE Id = {item.Id}";

                    }
                    else
                    {
                    }
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    con.Close();
                }
            }
            catch { }

        }

        public static void UpdateItemQuantity(Item item, string entrytype)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
                {
                    con.Open();
                    string query = "";

                    if (item.Id > 0)
                    {
                        query = $"UPDATE inventoryentry " +
                        $"SET Quantity='{item.UnitQuantity}' " +
                        $" WHERE ItemId = {item.Id} and InventoryId={InventoryService.GetIDinventory()} and InventoryLogEntryType={entrytype}";
                    }
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    con.Close();
                }
            }
            catch { }

        }
        public static void DeleteItem(Item item)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
                {
                    con.Open();
                    string query = "";

                    if (item.Id > 0)
                    {


                        query = $"UPDATE item " +
                        $"SET Deleted ='1'" +
                        $" WHERE Id = {item.Id}";

                    }
                    else
                    {
                    }
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    con.Close();
                }
            }
            catch { }

        }
        public static void InsertItem(Item item)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
                {
                    con.Open();
                    string query = "";


                    query = $"INSERT INTO item(Name,SupplierName,Unit,UnitQuantity,UnitQuantityPrice,Deleted,DateCreated,DateUpdated) " +
                   $"VALUES('{item.Name}','{item.SupplierName}','{item.Unit}','{item.UnitQuantity}','{item.UnitQuantityPrice}','0','{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}','{DateTime.Now.ToString("yyyy-MM-dd")}')";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    con.Close();
                }
            }
            catch { }
        }
   
        public static void InsertInventory(InventoryEntry inventory, string id2)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
                {
                    con.Open();
                    string query = "";
                 
                    query = $"INSERT INTO inventoryentry(DateCreated,Quantity,ItemId,InventoryId,InventoryLogEntryType) " +
                $"VALUES('{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}','{inventory.Quantity}','{inventory.ItemId}','{id2}','{inventory.InventoryLogEntryType}')";

               //     query = $"UPDATE inventoryentry " +
               //$"SET Quantity='{inventory.Quantity}'" +
               //$" WHERE ItemId = '{inventory.ItemId}' and InventoryLogEntryType='0' and InventoryId ='{id2}'";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    con.Close();
                }
            }
            catch { }
        }
        public static void InsertInventoryID(string id)
        {
            try
            {
             
                CloseInventory();
                InventoryentryService.InsertInventoryClosed0();
                using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
                {
                    con.Open();
                    string query = "";
                
                    query = $"INSERT INTO inventory(DateCreated,Deleted,UserId) " +
                   $"VALUES('{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}','0','"+id+"')";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                

                    con.Close();
                }
              
            }
            catch { }
        }
        public static void CloseInventory()
        {
            try
            {
              string id  = InventoryService.GetIDinventory();
                using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
                {
                    con.Open();
                    string query = "";
                    query = $"UPDATE inventory " +
                  $"SET DateClosed='{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}'" +
                  $" WHERE id = {id} and DateClosed ='0000-00-00 00:00:00'";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    con.Close();
                }
            }
            catch { }
        }
        public static void UpdateInventory(InventoryEntry inventory)
        {
            //try
            //{
            //    using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            //    {
            //        con.Open();
            //        string query = "";
            //        //Price=(Price/UnitQuantity) *(OldUnitQuantity -'{inventory.UnitQuantity }')
            //        query = $"UPDATE inventoryentry " +
            //      //$"SET Price={inventory.Price} , UnitQuantity=OldUnitQuantity -'{inventory.UnitQuantity }'" +
            //      //$" WHERE item_id = {inventory.item_id} and DateCreated='{DateTime.Now.ToString("yyyy-MM-dd")}'";
            //        MySqlCommand cmd = new MySqlCommand(query, con);
            //        MySqlDataReader dataReader = cmd.ExecuteReader();

            //        con.Close();
            //    }
            //}
            //catch { }
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
