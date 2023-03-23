using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace WindowsFormsApp1
{
    public partial class Form_Login : Form
    {
       
        public Form_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                int count = -999;
                int i = 0;
                Program.connection.Open();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT login,password FROM mydb.staff_account where `login` = @lg and `password` = @pwd", Program.connection);
                command.Parameters.Add("@lg", MySqlDbType.VarChar).Value = login.Text;
                command.Parameters.Add("@pwd", MySqlDbType.VarChar).Value = txtpassword.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                i = table.Rows.Count;
                count++;
                label3.Text = count.ToString();

                if (login.Text == "" && txtpassword.Text == "")
                {
                    MessageBox.Show("USERNAME and PASSWORD cannot be blank");
                    if (count >= 3)
                    {
                        MessageBox.Show("Failed in 3 login attempts. Assuming unauthorized access. Terminating!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    login.Focus();
                }
                else if (i == 0)
                {
                    if (count >= 3)
                    {
                        MessageBox.Show("Failed in 3 login attempts. Assuming unauthorized access. Terminating!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    MessageBox.Show("Please check your username and password again");
                }
                else
                {
                    this.Hide();
                    Form_Greeting f = new Form_Greeting();
                    f.ShowDialog();
                }
                Program.connection.Close();
            }
            if(radioButton2.Checked == true)
            {
                int count = -999;
                int i = 0;
                Program.connection.Open();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT login,password FROM mydb.student where `login` = @lg2 and `password` = @pwd2", Program.connection);
                command.Parameters.Add("@lg2", MySqlDbType.VarChar).Value = login.Text;
                command.Parameters.Add("@pwd2", MySqlDbType.VarChar).Value = txtpassword.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                i = table.Rows.Count;
                count++;


                label3.Text = count.ToString();

                if (login.Text == "" && txtpassword.Text == "")
                {
                    MessageBox.Show("USERNAME and PASSWORD cannot be blank");
                    if (count >= 3)
                    {
                        MessageBox.Show("Failed in 3 login attempts. Assuming unauthorized access. Terminating!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    login.Focus();
                }
                else if (i == 0)
                {
                    if (count >= 3)
                    {
                        MessageBox.Show("Failed in 3 login attempts. Assuming unauthorized access. Terminating!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    MessageBox.Show("Please check your username and password again");
                }
                else
                {
                    this.Hide();
                    Form_Greeting_for_student f = new Form_Greeting_for_student();
                    f.ShowDialog();
                }
                Program.connection.Close();
            }
           
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Registration f = new Form_Registration();
            f.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
