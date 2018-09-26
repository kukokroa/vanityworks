using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VanityWorks.Core.Domain;

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
                    con.Close();

                    return user;
                }

                return null;
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
                    $"VALUES('{user.FirstName}','{user.MiddleName}','{user.LastName}','{user.EmailAddress}','{MD5Hash(user.Password)}','{user.ContactNumber}', {user.Admin}, {DateTime.Now}, 0)";
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


                        query = $"UPDATE item " +
                        $"SET Name ='{item.Name}', SupplierName='{item.SupplierName}',Unit='{item.Unit}'," +
                        $"UnitQuantity='{item.UnitQuantity}',UnitQuantityPrice='{(item.UnitQuantityPrice)}'" +
                        $" WHERE Id = {item.Id} and DateCreated='{DateTime.Now.ToString("yyyy-MM-dd")}'";

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
        public static void UpdateItemIn(Item item)
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
                        $"SET DateUpdated='{DateTime.Now.ToString("yyyy-MM-dd")}',UnitQuantity='{item.UnitQuantity}',OldUnitQuantity='{item.OldUnitQuantity}'" +
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

        public static void UpdateItemQuantity(Item item)
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
                        $"SET UnitQuantity= '{item.UnitQuantity}'" +
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


                    query = $"INSERT INTO item(Name,SupplierName,Unit,UnitQuantity,UnitQuantityPrice,Deleted,DateCreated,Price,DateUpdated) " +
                   $"VALUES('{item.Name}','{item.SupplierName}','{item.Unit}','{item.UnitQuantity}','{item.UnitQuantityPrice}','0','{DateTime.Now.ToString("yyyy-MM-dd")}','{Math.Round(item.UnitQuantityPrice / item.UnitQuantity) }','{DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")}')";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    con.Close();
                }
            }
            catch { }
        }
        public static void InsertInventory(Inventory inventory)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
                {
                    con.Open();
                    string query = "";


                    query = $"INSERT INTO inventory(Name,Price,DateCreated,UnitQuantity,OldUnitQuantity,item_id) " +
                   $"VALUES('{inventory.Name}','{inventory.Price}','{DateTime.Now.ToString("yyyy-MM-dd")}','{inventory.UnitQuantity}','{inventory.OldUnitQuantity}','{inventory.item_id}')";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    con.Close();
                }
            }
            catch { }
        }

        public static void UpdateInventory(Inventory inventory)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
                {
                    con.Open();
                    string query = "";

                    query = $"UPDATE inventory " +
                  $"SET UnitQuantity=UnitQuantity +'{inventory.UnitQuantity }', Price='{inventory.Price }'" +
                  $" WHERE item_id = {inventory.item_id} and DateCreated='{DateTime.Now.ToString("yyyy-MM-dd")}'";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    con.Close();
                }
            }
            catch { }
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
