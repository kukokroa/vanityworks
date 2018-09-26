using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VanityWorks.Core.Domain
{
    public class Item : Entity
    {
        public int id { get; set; }
        public string Name { get; set; }

        public string SupplierName { get; set; }

        public string Unit { get; set; } //kg, mL, L, g

        public decimal UnitQuantity { get; set; }
        public decimal OldUnitQuantity { get; set; }

        public decimal UnitQuantityPrice { get; set; } //Actual price : UnitQuantity / UnitQuantityPrice
        public decimal Price { get; set; }

        //public decimal Price()
        //{
        //    return UnitQuantityPrice / UnitQuantity;
        //}
        public DataTable Select()
        {
            MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString());
            DataTable dt = new DataTable();
            try
            {
                string sql = $"Select * From items ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter adapater = new MySqlDataAdapter(cmd);
                con.Open();
                adapater.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }

    }
}
