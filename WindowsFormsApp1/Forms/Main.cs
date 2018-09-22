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

namespace VanityWorks.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
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
    }
}
