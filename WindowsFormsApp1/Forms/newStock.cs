using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using VanityWorks.Core.Domain;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Services;
using VanityWorks.Services;

namespace VanityWorks.Forms
{
    public partial class newStock : Form
    {
        DataGrid dg = new DataGrid();
        Button newButton = new Button();

        public delegate void DoEvent();
        public event DoEvent RefreshDgv;

        public newStock(string a)
        {

            InitializeComponent();
            ItemName(a);


            label3.Hide();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        public void Passvalue()
        {


        }
        //private void Main_Load(object sender, EventArgs e)
        //{

        //    Program.LoggedInUser = new Core.Domain.User { Admin = true, FirstName = "Test", MiddleName = "Mid", LastName = "tester", EmailAddress = "test@tester.com" }; //TODO: Remove this
        //   // stri

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                if (InventoryentryService.ApproveNewStock((comboBox1.SelectedItem as ComboboxItem).Value.ToString()) == "0")
                {
                    UserService.UpdateItemStock((comboBox1.SelectedItem as ComboboxItem).Value.ToString(), int.Parse(textBox1.Text));
                    ItemName("c");
                }
                else
                {
                    MessageBox.Show("You have already input new stock");
                }
                Main mm = new Main();
                this.RefreshDgv();
                textBox1.Clear();
            }
            catch { }
          //  this.Close();
          // this.Hide();
        }
        public void ItemName(string a)
        {
            using (MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString()))
            {
                con.Open();
                string query = "";
                query = $"Select Id,Name,Unit From item where Deleted='0' and id not in (Select ItemId from inventoryentry where InventoryLogEntryType='1' and inventoryid='{InventoryService.GetIDinventory()}')";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                int x = 0;
                int y = 0;
                comboBox1.Items.Clear();
                while (dataReader.Read())
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = dataReader["Name"].ToString() +" ( "+ dataReader["Unit"].ToString() + " )";
                    item.Value = dataReader["Id"].ToString();
                    comboBox1.Items.Add(item);
                    if (dataReader["Id"].ToString() == a)
                    {
                        comboBox1.SelectedIndex = x;
                        y = 1;
                    }
                    x++;
                }
                if (y !=1)
                {
                    try { 
                    comboBox1.SelectedIndex = 0;
                    }
                    catch { }
                }
          
                con.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
