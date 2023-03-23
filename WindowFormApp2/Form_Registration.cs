using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form_Registration : Form
    {
        public Form_Registration()
        {
            InitializeComponent();
        }

        public Boolean checkUsername()
        {

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT login,password FROM mydb.student where `login` = @usn", Program.connection);
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = txtUsername.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_Registration_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Program.connection.Open();
            MySqlCommand command = new MySqlCommand(" INSERT INTO `mydb`.`student` ( `date_birth`, `first_name`, `last_name`, `phone_number`,`login`,`password`) VALUES(@bd, @fn, @ln, @pn,@usn,@pwd);", Program.connection);
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = txtUsername.Text;
            command.Parameters.Add("@pwd", MySqlDbType.VarChar).Value = txtPassword.Text;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = txtFirst_name.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = txtLast_name.Text;
            command.Parameters.Add("@bd", MySqlDbType.VarChar).Value = Birth_day.Value;
            command.Parameters.Add("@pn", MySqlDbType.VarChar).Value = Pnumber.Text;
            if (checkUsername())
            {
                MessageBox.Show("Username already exists");
            }
            else
            {
                if (txtConfirm_Password.Text != txtPassword.Text)
                {
                    MessageBox.Show("Password and Confirm don't match!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Acount created");
                    }
                    else
                    {

                        MessageBox.Show("error");
                    }
                }
            }
            Program.connection.Close();

        }
    }
}
