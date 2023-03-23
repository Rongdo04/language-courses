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
    public partial class Form_Levels : Form
    {
        public Form_Levels()
        {
            InitializeComponent();
        }

        void GridFill() // FillData
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from mydb.level", Program.connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "level");
            dataGridView1.DataSource = ds.Tables["level"];
        }
        private void Form_Levels_Load(object sender, EventArgs e)
        {
            
            
            Program.connection.Open();
            GridFill();
            Program.connection.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Add
        {
            Program.connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO `mydb`.`level` ( `Sign`, `Name`) VALUES (@S,@N);", Program.connection);
            command.Parameters.Add("@S", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@N", MySqlDbType.VarChar).Value = textBox2.Text;
            
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
            MySqlCommand command = new MySqlCommand("delete_by_id_level", Program.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("_id", id);
            command.ExecuteNonQuery();
            GridFill();
            Program.connection.Close();
        }

        private void button4_Click(object sender, EventArgs e) // cancel
        {
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e) //update
        {
            Program.connection.Open();
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            MySqlCommand command = new MySqlCommand("update_level", Program.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("_id", id);
            command.Parameters.AddWithValue("_S", textBox1.Text);
            command.Parameters.AddWithValue("_N", textBox2.Text);
            command.ExecuteNonQuery();
            GridFill();
            Program.connection.Close();
        }
    }
}
