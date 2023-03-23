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
    public partial class Form_Courses : Form
    {
        public Form_Courses()
        {
            InitializeComponent();
        }
        void GridFill() // FillData
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from mydb.course", Program.connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "course");
            dataGridView1.DataSource = ds.Tables["course"];
        }
        private void Form_Courses_Load(object sender, EventArgs e) 
        {
            Program.connection.Open();
            GridFill();
            Program.connection.Close();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
        }

        private void button1_Click(object sender, EventArgs e) // Add
        {
            Program.connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO `mydb`.`course` ( `lessons`, `description`, `level_id`,`category_id`,`language_id`) VALUES (@ls,@ds,@le_id,@ca_id,@la_id);", Program.connection);
            //command.Parameters.Add("@id", MySqlDbType.Int32).Value = textBox1.Text;
            command.Parameters.Add("@ls", MySqlDbType.Int32).Value = textBox1.Text;
            command.Parameters.Add("@ds", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@le_id", MySqlDbType.Int32).Value = textBox4.Text;
            command.Parameters.Add("@ca_id", MySqlDbType.Int32).Value = textBox5.Text;
            command.Parameters.Add("@la_id", MySqlDbType.Int32).Value = textBox6.Text;
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

        private void button2_Click(object sender, EventArgs e) //delete
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Program.connection.Open();
            MySqlCommand command = new MySqlCommand("delete_by_id_course", Program.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("_id", id);
            command.ExecuteNonQuery();
            GridFill();
            Program.connection.Close();
        }

        private void button3_Click(object sender, EventArgs e) //update
        {
            Program.connection.Open();
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            MySqlCommand command = new MySqlCommand("update_course", Program.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("_id", id);
            command.Parameters.AddWithValue("_ls", textBox1.Text);
            command.Parameters.AddWithValue("_ds", textBox2.Text);
            command.Parameters.AddWithValue("le_id", textBox4.Text);
            command.Parameters.AddWithValue("ca_id", textBox5.Text);
            command.Parameters.AddWithValue("la_id", textBox6.Text);
            command.ExecuteNonQuery();
            GridFill();
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
                    textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e) //clear
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Program.connection.Open();
            MySqlDataAdapter sqlDa = new MySqlDataAdapter("search_by_name_course", Program.connection);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("_ds", textBox7.Text);
            sqlDa.SelectCommand.Parameters.AddWithValue("_t", textBox7.Text);
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            Program.connection.Close();
        }
    }
}
