namespace WindowsFormsApp1.Forms
{
    partial class CreateUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxFirstName = new System.Windows.Forms.TextBox();
            this.txtBoxMiddleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxEmailAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxContactNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grp = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBoxAdminPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxAdminEmailAddress = new System.Windows.Forms.TextBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // txtBoxFirstName
            // 
            this.txtBoxFirstName.Location = new System.Drawing.Point(107, 6);
            this.txtBoxFirstName.Name = "txtBoxFirstName";
            this.txtBoxFirstName.Size = new System.Drawing.Size(244, 20);
            this.txtBoxFirstName.TabIndex = 1;
            // 
            // txtBoxMiddleName
            // 
            this.txtBoxMiddleName.Location = new System.Drawing.Point(107, 32);
            this.txtBoxMiddleName.Name = "txtBoxMiddleName";
            this.txtBoxMiddleName.Size = new System.Drawing.Size(244, 20);
            this.txtBoxMiddleName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Middle Name";
            // 
            // txtBoxLastName
            // 
            this.txtBoxLastName.Location = new System.Drawing.Point(107, 58);
            this.txtBoxLastName.Name = "txtBoxLastName";
            this.txtBoxLastName.Size = new System.Drawing.Size(244, 20);
            this.txtBoxLastName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Name";
            // 
            // txtBoxEmailAddress
            // 
            this.txtBoxEmailAddress.Location = new System.Drawing.Point(107, 84);
            this.txtBoxEmailAddress.Name = "txtBoxEmailAddress";
            this.txtBoxEmailAddress.Size = new System.Drawing.Size(244, 20);
            this.txtBoxEmailAddress.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Email Address";
            // 
            // txtBoxContactNumber
            // 
            this.txtBoxContactNumber.Location = new System.Drawing.Point(107, 110);
            this.txtBoxContactNumber.Name = "txtBoxContactNumber";
            this.txtBoxContactNumber.Size = new System.Drawing.Size(244, 20);
            this.txtBoxContactNumber.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Contact Number";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(107, 136);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PasswordChar = '*';
            this.txtBoxPassword.Size = new System.Drawing.Size(244, 20);
            this.txtBoxPassword.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Password";
            // 
            // txtBoxConfirmPassword
            // 
            this.txtBoxConfirmPassword.Location = new System.Drawing.Point(107, 162);
            this.txtBoxConfirmPassword.Name = "txtBoxConfirmPassword";
            this.txtBoxConfirmPassword.PasswordChar = '*';
            this.txtBoxConfirmPassword.Size = new System.Drawing.Size(244, 20);
            this.txtBoxConfirmPassword.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Confirm Password";
            // 
            // grp
            // 
            this.grp.BackColor = System.Drawing.Color.MistyRose;
            this.grp.Controls.Add(this.button1);
            this.grp.Controls.Add(this.txtBoxAdminPassword);
            this.grp.Controls.Add(this.label8);
            this.grp.Controls.Add(this.label9);
            this.grp.Controls.Add(this.txtBoxAdminEmailAddress);
            this.grp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grp.Location = new System.Drawing.Point(7, 221);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(348, 107);
            this.grp.TabIndex = 14;
            this.grp.TabStop = false;
            this.grp.Text = "Admin Authorization";
            this.grp.Enter += new System.EventHandler(this.grp_Enter);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(251, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Create User";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBoxAdminPassword
            // 
            this.txtBoxAdminPassword.Location = new System.Drawing.Point(114, 51);
            this.txtBoxAdminPassword.Name = "txtBoxAdminPassword";
            this.txtBoxAdminPassword.PasswordChar = '*';
            this.txtBoxAdminPassword.Size = new System.Drawing.Size(212, 20);
            this.txtBoxAdminPassword.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Admin Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Admin Email Address";
            // 
            // txtBoxAdminEmailAddress
            // 
            this.txtBoxAdminEmailAddress.Location = new System.Drawing.Point(114, 25);
            this.txtBoxAdminEmailAddress.Name = "txtBoxAdminEmailAddress";
            this.txtBoxAdminEmailAddress.Size = new System.Drawing.Size(212, 20);
            this.txtBoxAdminEmailAddress.TabIndex = 16;
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Location = new System.Drawing.Point(265, 188);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(86, 17);
            this.chkAdmin.TabIndex = 15;
            this.chkAdmin.Text = "Administrator";
            this.chkAdmin.UseVisualStyleBackColor = true;
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(363, 351);
            this.Controls.Add(this.chkAdmin);
            this.Controls.Add(this.grp);
            this.Controls.Add(this.txtBoxConfirmPassword);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBoxContactNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxEmailAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxLastName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxMiddleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxFirstName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "CreateUser";
            this.Text = "Create User";
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxFirstName;
        private System.Windows.Forms.TextBox txtBoxMiddleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxEmailAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxContactNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxConfirmPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBoxAdminPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxAdminEmailAddress;
        private System.Windows.Forms.CheckBox chkAdmin;
    }
}