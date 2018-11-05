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
    public partial class newStock : Form
    {
        DataGrid dg = new DataGrid();
        Button newButton = new Button();

        public delegate void DoEvent();
        public event DoEvent RefreshDgv;

        public newStock(string a, string b)
        {
      
            InitializeComponent();
            label1.Text = "id:" + a;
            label2.Text = b;
            label3.Text = a;
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

            UserService.UpdateItemStock(label3.Text, int.Parse(textBox1.Text));
            Main mm = new Main();
            this.RefreshDgv();
            this.Close();
            this.Hide();
        }
    }
}
