using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VanityWorks.Core.Domain;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Services;
using WindowsFormsApp1.Forms;
using VanityWorks.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = UserService.GetUserByEmailAndPassword(txtBoxEmailAddress.Text, txtBoxPassword.Text);

            if (user != null)
            {
                lblLoginError.Text = "";
                Program.LoggedInUser = user;

                var mainForm = new Main();
                mainForm.Show();

                this.Hide();
            }
            else
            {
                lblLoginError.Text = "User not found.";
            }

        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            var newUserForm = new CreateUser();
            newUserForm.Show();
        }
    }
}
