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
using MySqlX.XDevAPI.Relational;

namespace WindowsFormsApp1
{
    public partial class Form_Classes : Form
    {
        
        public Form_Classes()
        {
            InitializeComponent();
        }
        void GridFill() // FillData
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from mydb.class", Program.connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "class");
            dataGridView1.DataSource = ds.Tables["class"];
        }
        private void Form_Classes_Load(object sender, EventArgs e)
        {
            

            Program.connection.Open();
            GridFill();
            Program.connection.Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e) // Cancel
        {
           
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)   // Add
        {
            Program.connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO `mydb`.`class` ( `name`, `start_date`, `end_date`, `price`,`teacher_id`,`course_id`,`Amount) VALUES (@name,@sd,@ed,@p,@ti,@ci,@A);", Program.connection);
            //command.Parameters.Add("@id", MySqlDbType.Int32).Value = textBox1.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@sd", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@ed", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@p", MySqlDbType.Int32).Value = textBox5.Text;
            command.Parameters.Add("@ti", MySqlDbType.Int32).Value = textBox6.Text;
            command.Parameters.Add("@ci", MySqlDbType.Int32).Value = textBox7.Text;
            command.Parameters.Add("@ci", MySqlDbType.Int32).Value = textBox8.Text;
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

        private void button5_Click(object sender, EventArgs e) // Clear
        {
        
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox7.Clear();
            this.textBox6.Clear();
            this.textBox8.Clear();
        }

        private void button2_Click(object sender, EventArgs e) //Delete
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Program.connection.Open();
            MySqlCommand command = new MySqlCommand("delete_by_id_class", Program.connection);
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
            MySqlCommand command = new MySqlCommand("update_class", Program.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("_id", id);
            command.Parameters.AddWithValue("_name", textBox2.Text);
            command.Parameters.AddWithValue("_sd", textBox3.Text);
            command.Parameters.AddWithValue("_ed", textBox4.Text);
            command.Parameters.AddWithValue("_p", textBox5.Text);
            command.Parameters.AddWithValue("_ti", textBox6.Text);
            command.Parameters.AddWithValue("_ci", textBox7.Text);
            command.Parameters.AddWithValue("a", textBox8.Text);
            command.ExecuteNonQuery();
            GridFill();
            Program.connection.Close();

        }

        private void button6_Click(object sender, EventArgs e) // Search
        {
            
            Program.connection.Open();
            MySqlDataAdapter sqlDa = new MySqlDataAdapter("search_by_name_class", Program.connection);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("_name", textBox1.Text);
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            Program.connection.Close();
        }
      
        private void dataGridView1_DoubleClick(object sender, EventArgs e) // Double click
        {
            
            
            try
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    textBox8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }

}
