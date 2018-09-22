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
