namespace WindowsFormsApp1
{
    partial class Form_Registration
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirm_Password = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Birth_day = new System.Windows.Forms.DateTimePicker();
            this.Pnumber = new System.Windows.Forms.TextBox();
            this.txtLast_name = new System.Windows.Forms.TextBox();
            this.txtFirst_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 228);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(1);
            this.label5.Size = new System.Drawing.Size(87, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Username : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Password : ";
            this.label6.Click += new System.EventHandler(this.label11_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 359);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(1);
            this.label7.Size = new System.Drawing.Size(135, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "Confirm Password : ";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(193, 225);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 22);
            this.txtUsername.TabIndex = 15;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(193, 312);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 22);
            this.txtPassword.TabIndex = 17;
            // 
            // txtConfirm_Password
            // 
            this.txtConfirm_Password.Location = new System.Drawing.Point(193, 359);
            this.txtConfirm_Password.Name = "txtConfirm_Password";
            this.txtConfirm_Password.PasswordChar = '*';
            this.txtConfirm_Password.Size = new System.Drawing.Size(100, 22);
            this.txtConfirm_Password.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 42);
            this.button1.TabIndex = 23;
            this.button1.Text = "Sign up";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Birth_day
            // 
            this.Birth_day.Location = new System.Drawing.Point(193, 183);
            this.Birth_day.Name = "Birth_day";
            this.Birth_day.Size = new System.Drawing.Size(200, 22);
            this.Birth_day.TabIndex = 38;
            // 
            // Pnumber
            // 
            this.Pnumber.Location = new System.Drawing.Point(193, 273);
            this.Pnumber.Name = "Pnumber";
            this.Pnumber.Size = new System.Drawing.Size(100, 22);
            this.Pnumber.TabIndex = 37;
            // 
            // txtLast_name
            // 
            this.txtLast_name.Location = new System.Drawing.Point(193, 149);
            this.txtLast_name.Name = "txtLast_name";
            this.txtLast_name.Size = new System.Drawing.Size(100, 22);
            this.txtLast_name.TabIndex = 36;
            // 
            // txtFirst_name
            // 
            this.txtFirst_name.Location = new System.Drawing.Point(193, 113);
            this.txtFirst_name.Name = "txtFirst_name";
            this.txtFirst_name.Size = new System.Drawing.Size(100, 22);
            this.txtFirst_name.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 276);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(1);
            this.label4.Size = new System.Drawing.Size(115, 19);
            this.label4.TabIndex = 34;
            this.label4.Text = "Phone number : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 188);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(1);
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 33;
            this.label3.Text = "Date birth :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 149);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(1);
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 32;
            this.label2.Text = "Last name : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 113);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(1);
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 31;
            this.label1.Text = "First name :";
            // 
            // Form_Registration
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 572);
            this.Controls.Add(this.Birth_day);
            this.Controls.Add(this.Pnumber);
            this.Controls.Add(this.txtLast_name);
            this.Controls.Add(this.txtFirst_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtConfirm_Password);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Name = "Form_Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Registration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirm_Password;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker Birth_day;
        private System.Windows.Forms.TextBox Pnumber;
        private System.Windows.Forms.TextBox txtLast_name;
        private System.Windows.Forms.TextBox txtFirst_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}