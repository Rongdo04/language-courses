using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form_Payments : Form
    {
        public Form_Payments()
        {
            InitializeComponent();
        }
        void GridFill() // FillData
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from mydb.payment", Program.connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "payment");
            dataGridView1.DataSource = ds.Tables["payment"];
        }

        private void Form_Payments_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mydbDataSet1.payment' table. You can move, or remove it, as needed.
            
            Program.connection.Open();
            GridFill();
            Program.connection.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Add
        {
            Program.connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO `mydb`.`payment` ( `payment_date`, `amount`, `status`, `payment_menthod_id`,`student_id`,`class_id`) VALUES (@pd,@a,@s,@pmi,@si,@ci);", Program.connection);
            command.Parameters.Add("@pd", MySqlDbType.Date).Value = textBox1.Text;
            command.Parameters.Add("@a", MySqlDbType.Decimal).Value = textBox2.Text;
            command.Parameters.Add("@s", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@pmi", MySqlDbType.Int32).Value = textBox4.Text;
            command.Parameters.Add("@si", MySqlDbType.Int32).Value = textBox5.Text;
            command.Parameters.Add("@ci", MySqlDbType.Int32).Value = textBox6.Text;
            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Query Excuted");
                }
                else
                {
                    MessageBox.Show("Query not Excuted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            GridFill();

            Program.connection.Close();
        }

        private void button2_Click(object sender, EventArgs e) //Delete
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Program.connection.Open();
            MySqlCommand command = new MySqlCommand("delete_by_id_payment", Program.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("_id", id);
            command.ExecuteNonQuery();
            GridFill();
            Program.connection.Close();
        }

        private void button3_Click(object sender, EventArgs e) //Update
        {
            Program.connection.Open();
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            MySqlCommand command = new MySqlCommand("update_payment", Program.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("_id", id);
            command.Parameters.AddWithValue("_pd", textBox1.Text);
            command.Parameters.AddWithValue("_a", textBox2.Text);
            command.Parameters.AddWithValue("_s", textBox3.Text);
            command.Parameters.AddWithValue("_pmi", textBox4.Text);
            command.Parameters.AddWithValue("_si", textBox5.Text);
            command.Parameters.AddWithValue("_ci", textBox6.Text);
            command.ExecuteNonQuery();
            GridFill();
            Program.connection.Close();
        }

        private void button4_Click(object sender, EventArgs e) // Cancel
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e) // Clear
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
        }

        private void button6_Click(object sender, EventArgs e) // Search
        {
            Program.connection.Open();
            MySqlDataAdapter sqlDa = new MySqlDataAdapter("search_by_id_payment", Program.connection);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("_id", textBox7.Text);
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);
            dataGridView1.DataSource = dt;
            Program.connection.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
