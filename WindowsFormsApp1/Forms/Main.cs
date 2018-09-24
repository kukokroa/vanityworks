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
            textBox5.Hide();
            textBox6.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
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
            Program.LoggedInUser = null;
            this.Close();
            var Login = new Login();
            Login.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            //Button newButton = new Button();
            //newButton.Name = "hahaa";
            //newButton.Text = "wewee";
        //    flowLayoutPanel1.Controls.Clear();
           // flowLayoutPanel1.Controls.Add(newButton);
        }

        private void newOpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
        }
        public DataTable Select()
        {
            MySqlConnection con = new MySqlConnection(DatabaseHelper.GetSQLiteConnectionString());
            DataTable dt = new DataTable();
         try
            {
                string sql = $"Select id,Name,SupplierName,Unit,UnitQuantity,UnitQuantityPrice,sum(UnitQuantityPrice / UnitQuantity) as Price,DateCreated From item where Deleted='0' Group by id";
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
            dataGridView1.Show();
            textBox1.Show();
            textBox2.Show();
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
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            DataTable dt = Select();
            dataGridView1.AutoResizeRows();
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly=true;
            dg.Size = new System.Drawing.Size(550, 288);
            newButton.BackColor = System.Drawing.Color.White; 
            dg.DataSource = dt;
        //    flowLayoutPanel1.Controls.Clear();
      //     flowLayoutPanel1.Controls.Add(dg);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex=e.RowIndex;
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                var item = new Item();
                item.Id = int.Parse(textBox1.Text);
                item.Name = textBox2.Text;
                item.SupplierName = textBox3.Text;
                item.Unit = textBox4.Text;
                item.UnitQuantity = Convert.ToDecimal(textBox5.Text);
                item.UnitQuantityPrice = Convert.ToDecimal(textBox6.Text);
                UserService.UpdateItem(item);
                DataTable dt = Select();
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new Item();
                item.Name = textBox2.Text;
                item.SupplierName = textBox3.Text;
                item.Unit = textBox4.Text;
                item.UnitQuantity = Convert.ToDecimal(textBox5.Text);
                item.UnitQuantityPrice = Convert.ToDecimal(textBox6.Text);
                UserService.InsertItem(item);
                DataTable dt = Select();
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                var item = new Item();
                item.Id = int.Parse(textBox1.Text);
                item.Name = textBox2.Text;
                item.SupplierName = textBox3.Text;
                item.Unit = textBox4.Text;
                item.UnitQuantity = Convert.ToDecimal(textBox5.Text);
                item.UnitQuantityPrice = Convert.ToDecimal(textBox6.Text);
                UserService.DeleteItem(item);
                DataTable dt = Select();
                dataGridView1.DataSource = dt;
            }
            catch (Exception) { }
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
          
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
          
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
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
    }
}
