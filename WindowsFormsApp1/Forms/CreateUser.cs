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
using WindowsFormsApp1.Services;

namespace WindowsFormsApp1.Forms
{
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBoxPassword.Text == txtBoxConfirmPassword.Text)
            {
                var adminUser = UserService.GetUserByEmailAndPassword(txtBoxAdminEmailAddress.Text, txtBoxAdminPassword.Text);

                if (adminUser != null && adminUser.Admin)
                {
                    var user = new User();
                    user.FirstName = txtBoxFirstName.Text;
                    user.MiddleName = txtBoxMiddleName.Text;
                    user.LastName = txtBoxLastName.Text;
                    user.EmailAddress = txtBoxEmailAddress.Text;
                    user.ContactNumber = txtBoxContactNumber.Text;
                    user.Password = txtBoxPassword.Text;

                    if (chkAdmin.Checked)
                        user.Admin = true;
                    else
                        user.Admin = false;

                    user.Id = 0;

                    UserService.AddOrUpdate(user);

                    MessageBox.Show("User created!");
                }
                else
                {
                    MessageBox.Show("Admin not found.");
                }
            }
            else
            {
                MessageBox.Show("Password fields don't match.");
            }


        }
    }
}
