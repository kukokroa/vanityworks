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

namespace VanityWorks.Forms
{
    public partial class Main : Form
    {
        DataGrid dg = new DataGrid();
        Button newButton = new Button();
        public Main()
        {
            InitializeComponent();
            dataGridView1.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            groupBox1.Hide();
            textBox5.Hide();
            textBox6.Hide();
            textBox7.Hide();
            textBox8.Hide();
            textBox9.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            comboBox1.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

   
        private void Main_Load(object sender, EventArgs e)
        {
            Program.LoggedInUser = new Core.Domain.User { Admin = true, FirstName = "Test", MiddleName = "Mid", LastName = "tester", EmailAddress = "test@tester.com" }; //TODO: Remove this
            stripLblUser.Text = Program.LoggedInUser.GetFullName();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to Logout??",
                                        "Confirm Logout!!",
                                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Program.LoggedInUser = null;
                this.Close();
                var Login = new Login();
                Login.Show();
            }
            else
            {
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 
            ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            //Button newButton = new Button();
            //newButton.Name = "hahaa";
            //newButton.Text = "wewee";
        //    flowLayoutPanel1.Controls.Clear();
           // flowLayoutPanel1.Controls.Add(newButton);
        }

        private void newOpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want new opening?? \n If you have existing open inventory it will be closed.",
                                        "Confirm Opening!!",
                                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                UserService.InsertInventoryID(UserService.GetisLogin());
                dataGridView1.Show();
                label9.Hide();
                comboBox1.Hide();
                groupBox1.Show();
                textBox1.Show();
                textBox2.Show();
                textBox9.Show();
                textBox9.Text = "0";
                label8.Text = "Input Data";
                label8.Show();
                button5.Show();
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox3.Show();
                textBox4.Hide();
                textBox5.Show();
                textBox6.Hide();
                label1.Show();
                label2.Show();
                label3.Show();
                label7.Show();
                label4.Hide();
                label5.Show();
                label6.Hide();
                button1.Hide();
                button2.Hide();
                button3.Hide();
                button4.Hide();
                button6.Show();
                button8.Hide();
                button9.Hide();
                button7.Show();
                button10.Show();
                DataTable dt = Select();
                dataGridView1.AutoResizeRows();
                dataGridView1.DataSource = dt;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dg.Size = new System.Drawing.Size(550, 288);
                newButton.BackColor = System.Drawing.Color.White;
                dg.DataSource = dt;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                // textBox9.Clear();
            }
            else
            {
                // If 'No', do something here.
            }
          
        }
        public DataTable SelectAllInventoryOpening()
        {
            MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString());
            DataTable dt = new DataTable();
            try
            {
                //string sql = $"Select id,Name,Price,UnitQuantity,DateCreated From inventory"
                string sql = $"Select inventoryid,sum(UnitQuantity)as Total_Quantity,round(sum(Price),2) as Total_Price,DateCreated From inventoryentry Group by inventoryid";
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
        public DataTable SelectAllInventoryItem()
        {
            MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString());
            DataTable dt = new DataTable();
            try
            {
                
                //string sql = $"Select id,Name,Price,UnitQuantity,DateCreated From inventory"
                string sql = $"Select item.name,sum(inventoryentry.UnitQuantity)as Total_Quantity,round(sum(inventoryentry.Price), 2) as Total_Price,inventoryentry.DateCreated From inventoryentry join item on item.Id = inventoryentry.item_id Group by inventoryentry.id";
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
        public DataTable SelectAllInventory()
        {
            MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString());
            DataTable dt = new DataTable();
            try
            {
                //string sql = $"Select id,Name,Price,UnitQuantity,DateCreated From inventory"
                string sql = $"Select sum(UnitQuantity)as Total_Quantity,round(sum(Price),2) as Total_Price,DateCreated From inventoryentry Group by DateCreated";
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
        public DataTable SelectAllInventoryReport()
        {
            MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString());
            DataTable dt = new DataTable();
            try
            {
                //string sql = $"Select id,Name,Price,UnitQuantity,DateCreated From inventory"
                string sql = $"Select inventoryentry.id,item.Name,inventoryentry.Price,inventoryentry.UnitQuantity,inventoryentry.DateCreated From inventoryentry Join item on item.id= inventoryentry.item_id Group by inventoryentry.DateCreated";
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
        public DataTable Select()
        {
            MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString());
            DataTable dt = new DataTable();
           string idinvent=UserService.GetIDinventory();
         try
            {
                // string sql = $"Select id,Name,SupplierName,Unit,UnitQuantity,UnitQuantityPrice,round(sum(UnitQuantityPrice / UnitQuantity),2) as Price,DateCreated From item where Deleted='0' and DateUpdated!='{DateTime.Now.ToString("yyyy-MM-dd")}' or DateUpdated ='DateCreated' Group by id";
                string sql = $"Select id,Name,SupplierName,Unit,UnitQuantity,UnitQuantityPrice,round(sum(UnitQuantityPrice / UnitQuantity),2) as Price,DateCreated From item where Deleted='0' and inventoryid !={idinvent} Group by id";
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
        public DataTable SelectAll()
        {
            MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString());
            DataTable dt = new DataTable();
            try
            {
                //  string sql = $"Select id,Name,SupplierName,Unit,UnitQuantity,UnitQuantityPrice,round(sum(UnitQuantityPrice / UnitQuantity ) ,2) as Price,DateCreated From item where Deleted='0' Group by id";
                string sql = $"Select id,Name,SupplierName,Unit,UnitQuantity,DateCreated From item where Deleted='0' Group by id";

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

        public DataTable SelectValue(int id)
        {
            MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString());
            DataTable dt = new DataTable();
            try
            {
                string sql = $"Select * From inventoryentry where item_id='{id}'";
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

        public DataTable SelectInF()
        {
            MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString());
            DataTable dt = new DataTable();
            string idinvent = UserService.GetIDinventory();
            try
            {
                string sql = $"Select id,Name,SupplierName,Unit,UnitQuantity,UnitQuantityPrice,round(sum(UnitQuantityPrice / UnitQuantity),2) as Price,DateCreated From item where Deleted='0' and inventoryid ={idinvent} Group by id";

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

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
    
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label9.Hide();
            comboBox1.Hide();
            groupBox1.Show();
            button9.Hide();
            button6.Hide();
            button7.Hide();
            textBox9.Hide();
            button8.Hide();
            textBox1.Clear();
            label8.Text = "Input Data";
            label8.Show();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dataGridView1.Show();
            textBox1.Show();
            textBox2.Show();
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox3.Show();
            textBox4.Show();
            textBox5.Show();
            textBox6.Show();
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            label6.Show();
            label7.Hide();
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            button5.Hide();
            button10.Hide();
            DataTable dt = SelectAll();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly=true;
            dg.Size = new System.Drawing.Size(550, 288);
            newButton.BackColor = System.Drawing.Color.White; 
            dg.DataSource = dt;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      
        }
        private void dg_RowHeaderMouseClick()
        {

        }

        private void newButton_Click(object sender, EventArgs e)
        {
      //      flowLayoutPanel1.Controls.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("hehehe");
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
           // int rowIndex=e.RowIndex;
           // textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
           // textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
           // textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
           // textBox4.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
           // textBox5.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
           //// textBox6.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();

           // textBox7.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
           // if (dataGridView1.Rows.Count <= 5)
           // {
           //     textBox8.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
           // }
           // else { textBox8.Text = "0"; }
        }
       
        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.ToString() != "")
                {
                    var item = new Item();
                    item.Id = int.Parse(textBox1.Text);
                    item.Name = textBox2.Text;
                    item.SupplierName = textBox3.Text;
                    item.Unit = textBox4.Text;
                    item.UnitQuantity = Convert.ToDecimal(textBox5.Text);
                 //   item.UnitQuantityPrice = Convert.ToDecimal(textBox6.Text);
                    DataTable dtValue = SelectValue(item.Id);
                    if (dtValue.Rows.Count > 0)
                    {
                        DialogResult = MessageBox.Show("Can't update Quantity because it has value in inventory Only Price can be updated",
                                "Confirmation", MessageBoxButtons.YesNo,  MessageBoxIcon.Information);
                        if (DialogResult == DialogResult.Yes)
                        {
                      //      MessageBox.Show("Yes");
                        }
                        else
                        {
                         //   MessageBox.Show("No");
                        }
                    }
                    else
                    { 
                    UserService.UpdateItem(item);
                    }
                    DataTable dt = SelectAll();
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Please Click a row");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Click a row");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //var inventory = new Inventory();
                //inventory.Name = textBox2.Text;
                //inventory.Price = Convert.ToDecimal(textBox6.Text)/ Convert.ToDecimal(textBox5.Text);
                //UserService.InsertInventory(inventory);

                var item = new Item();
                item.Name = textBox2.Text;
                item.SupplierName = textBox3.Text;
                item.Unit = textBox4.Text;
                item.UnitQuantity = Convert.ToDecimal(textBox5.Text);
                item.UnitQuantityPrice = Convert.ToDecimal(textBox6.Text);
               

                UserService.InsertItem(item);
                DataTable dt = SelectAll();
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                if (int.Parse(textBox1.Text) > 0)
                {
                    DialogResult = MessageBox.Show("Do you want to Delete it?",
                                 "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (DialogResult == DialogResult.Yes)
                    {
                        var item = new Item();
                        item.Id = int.Parse(textBox1.Text);
                        item.Name = textBox2.Text;
                        item.SupplierName = textBox3.Text;
                        item.Unit = textBox4.Text;
                        item.UnitQuantity = Convert.ToDecimal(textBox5.Text);
                      //  item.UnitQuantityPrice = Convert.ToDecimal(textBox6.Text);
                        UserService.DeleteItem(item);
                        DataTable dt = SelectAll();
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                       // MessageBox.Show("No");
                    }
                   
                }
                else
                {
                    MessageBox.Show("Please Click a row");
                }
            }
            catch (Exception) {
                MessageBox.Show("Please Click a row");
            }
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label9.Show();
            comboBox1.Show();
            comboBox1.SelectedItem = "";
            button10.Hide();
            button6.Hide();
            button7.Hide();
            textBox9.Hide();
            button8.Hide();
            textBox1.Hide();
            label8.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            button5.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button9.Show();
            DataTable dt = SelectAllInventory();
            groupBox1.Hide();
             dataGridView1.DataSource = null;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Clear();
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Show();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(textBox7.Text) >= Convert.ToDecimal(textBox5.Text))
                {
                    var item = new Item();
                    item.Id = int.Parse(textBox1.Text);
                    item.UnitQuantity = Convert.ToDecimal(textBox5.Text);
                    item.newStock = int.Parse(textBox9.Text);
                    item.OldUnitQuantity = Convert.ToDecimal(textBox7.Text) - Convert.ToDecimal(textBox5.Text);
                   // item.UnitQuantityPrice=

                    UserService.UpdateItemIn(item);
                  
                    var inventory = new Inventory();
                    inventory.item_id = int.Parse(textBox1.Text);
                    inventory.Name = textBox2.Text;
                    inventory.newStock = int.Parse(textBox9.Text);
                    inventory.Price = Convert.ToDecimal(textBox8.Text) * (Convert.ToDecimal(textBox7.Text) - Convert.ToDecimal(textBox5.Text));
                    inventory.UnitQuantity = Convert.ToDecimal(textBox7.Text) - Convert.ToDecimal(textBox5.Text);
                    inventory.OldUnitQuantity = Convert.ToDecimal(textBox7.Text);
                    UserService.InsertInventory(inventory, UserService.GetIDinventory());
                    DataTable dt = Select();
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox9.Text = "0";
                }
                else
                {
                    MessageBox.Show("Entry is to high");
                }
            }
            catch (Exception)
            {

            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            dataGridView1.AllowUserToAddRows = false;
            label8.Text = "Input Data";
            textBox1.Show();
            textBox2.Show();
            label8.Show();
            button5.Show();
            button8.Hide();
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox3.Show();
            textBox4.Hide();
            textBox5.Show();
            textBox9.Show();
            textBox9.Text = "0";
            textBox6.Hide();
            label1.Show();
            label2.Show();
            label3.Show();
            label7.Show();
            label4.Hide();
            label5.Show();
            label6.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button6.Show();
            button7.Show();
            DataTable dt = Select();
            dataGridView1.AutoResizeRows();
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dg.Size = new System.Drawing.Size(550, 288);
            newButton.BackColor = System.Drawing.Color.White;
            dg.DataSource = dt;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
           // textBox9.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button10.Hide();
            dataGridView1.Show();
            dataGridView1.AllowUserToAddRows = false;
            textBox1.Show();
            label8.Text = "Change Data";
            label8.Show();
            textBox2.Show();
            textBox9.Show();
            button5.Hide();
            button8.Show();
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox3.Show();
            textBox4.Hide();
            textBox5.Show();
            textBox6.Hide();
            label1.Show();
            label2.Show();
            label3.Show();
            label7.Show();
            label4.Hide();
            label5.Show();
            
            label6.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button6.Show();
            button7.Show();
            DataTable dt = SelectInF();
            dataGridView1.AutoResizeRows();
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
            dg.Size = new System.Drawing.Size(550, 288);
            newButton.BackColor = System.Drawing.Color.White;
            dg.DataSource = dt;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox9.Text = "0";
            // textBox9.Clear();
        }

        private void reportsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(textBox7.Text) >= Convert.ToDecimal(textBox5.Text))
                {
                    var inventory = new Inventory();
                    inventory.item_id = int.Parse(textBox1.Text);
                    inventory.Name = textBox2.Text;

                    inventory.newStock = int.Parse(textBox9.Text);
                    inventory.Price = Convert.ToDecimal(textBox8.Text) * (Convert.ToDecimal(textBox7.Text) - Convert.ToDecimal(textBox5.Text));
                    inventory.UnitQuantity = Convert.ToDecimal(textBox5.Text);
                    inventory.OldUnitQuantity = Convert.ToDecimal(textBox7.Text);
                    UserService.UpdateInventory(inventory);

                    var item = new Item();
                    item.Id = int.Parse(textBox1.Text);
                    item.newStock = int.Parse(textBox9.Text);
                    item.UnitQuantity = Convert.ToDecimal(textBox5.Text);
                    item.UnitQuantityPrice = Convert.ToDecimal(textBox6.Text);
                    UserService.UpdateItemQuantity(item);
                    DataTable dt = SelectInF();



                    dataGridView1.AutoResizeRows();
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;

                    dataGridView1.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Entry is to high");
                }
            }
            catch (Exception)
            {

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable dt = SelectAllInventoryReport();
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePaths = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string extension = DateTime.Now.ToString("yyyy-MM-dd")+".csv";
            filePath += @"\VanityWorks\" + extension;
            filePaths += @"\VanityWorks";
            if (System.IO.File.Exists(filePaths))
            {
                try
                {
                    System.IO.File.Delete(filePath);
                }
                catch (Exception )
                {
                }
               
            }
            else
            {
                try
                {
                    System.IO.File.Delete(filePath);
                }
                catch (Exception)
                {
                }

                System.IO.Directory.CreateDirectory(filePaths);
                  }
            StringBuilder csvContent = new StringBuilder();
          
                 csvContent.AppendLine("id, Name,UnitQuantity ,Price , Date_Sold");
            foreach (DataRow row in dt.Rows)
            {
                csvContent.AppendLine(row["id"].ToString() +','+ row["Name"].ToString() + ',' + row["UnitQuantity"].ToString() + ',' + row["Price"].ToString() + ',' + row["DateCreated"].ToString());
            }
            System.IO.File.AppendAllText(filePath, csvContent.ToString());
            MessageBox.Show("Successfully Exported");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if(rowIndex != -1 && comboBox1.Visible == false)
            { 
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            if (dataGridView1.Columns.Count > 3)
                {
                    string uPrice = UserService.GetPriceItem(textBox1.Text);
                  
                textBox4.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                    textBox6.Text = uPrice;
                textBox7.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
               
                }
            if (dataGridView1.Columns.Count >= 7)
            {
                  
                textBox8.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
           

                }
            else { textBox8.Text = "0"; }
            }
        }

        private void currentOpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
          string id=  UserService.GetIDinventory();
            if (id != "0")
            {
                dataGridView1.Show();
                groupBox1.Show();
                textBox1.Show();
                textBox2.Show();
                textBox9.Show();
                textBox9.Text = "0";
                label8.Text = "Input Data";
                label8.Show();
                button5.Show();
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox3.Show();
                textBox4.Hide();
                textBox5.Show();
                textBox6.Hide();
                label1.Show();
                label2.Show();
                label3.Show();
                label7.Show();
                label4.Hide();
                label5.Show();
                label6.Hide();
                label9.Hide();
                comboBox1.Hide();
                button1.Hide();
                button2.Hide();
                button3.Hide();
                button4.Hide();
                button6.Show();
                button8.Hide();
                button9.Hide();
                button7.Show();
                button10.Show();
                DataTable dt = Select();
                dataGridView1.AutoResizeRows();
                dataGridView1.DataSource = dt;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dg.Size = new System.Drawing.Size(550, 288);
                newButton.BackColor = System.Drawing.Color.White;
                dg.DataSource = dt;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else
            {
                MessageBox.Show("No existing inventory");
            }
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Successfully Exported");
            //  currentOpeningToolStripMenuItem.Visible = false;
        }

  
        private void button10_Click(object sender, EventArgs e)
        {
           if (textBox1.Text != "")
           {
            string stock = textBox1.Text;
            string stock1 = "Name:" + textBox2.Text;
            newStock ns = new newStock(stock, stock1);
            ns.RefreshDgv += new newStock.DoEvent(stocks);
                if (Application.OpenForms.OfType<newStock>().Count() == 1)
                { 
                    Application.OpenForms.OfType<newStock>().First().Close();
                }
                ns.Show();
          }
        }
        void stocks()
        {
            DataTable dt = Select();
            dataGridView1.AutoResizeRows();
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dg.Size = new System.Drawing.Size(550, 288);
            newButton.BackColor = System.Drawing.Color.White;
            dg.DataSource = dt;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
               
                if (textBox1.Text != ""  && button10.Visible == true)
                {
                    string stock = textBox1.Text;
                    string stock1 = "Name:" + textBox2.Text;
                    newStock ns = new newStock(stock, stock1);
                    ns.RefreshDgv += new newStock.DoEvent(stocks);
                    if (Application.OpenForms.OfType<newStock>().Count() == 1)
                    {
                        Application.OpenForms.OfType<newStock>().First().Close();
                    }
                    ns.Show();

                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem.ToString() == "Item")
            {
                DataTable dt = SelectAllInventoryItem();
                groupBox1.Hide();
                dataGridView1.DataSource = null;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Rows.Clear();
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Show();
            }
            else if (comboBox1.SelectedItem.ToString() == "Opening")
            {
                DataTable dt = SelectAllInventoryOpening();
                groupBox1.Hide();
                dataGridView1.DataSource = null;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Rows.Clear();
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = dt;
                 dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Show();
            }
            else
            {
                DataTable dt = SelectAllInventory();
                groupBox1.Hide();
                dataGridView1.DataSource = null;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.Rows.Clear();
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Show();
            }
          
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
