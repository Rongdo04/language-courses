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
using MySql.Data;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form_Teachers : Form
    {
        public Form_Teachers()
        {
            InitializeComponent();
        }
        void GridFill() // FillData
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from mydb.teacher", Program.connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "teacher");
            dataGridView1.DataSource = ds.Tables["teacher"];
        }
        private void Form_Teachers_Load(object sender, EventArgs e)
        { 
            Program.connection.Open();
            GridFill();
            Program.connection.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //add
        {
            Program.connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO `mydb`.`teacher` ( `description`, `first_name`, `last_name`, `email`,`phone_number`) VALUES (@des,@fn,@ln,@e,@pn);", Program.connection);
            command.Parameters.Add("@des", MySqlDbType.VarChar).Value = richTextBox1.Text;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@e", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@pn", MySqlDbType.VarChar).Value = textBox4.Text;
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

        private void button5_Click(object sender, EventArgs e) //clear
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.richTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e) //delete
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Program.connection.Open();
            MySqlCommand command = new MySqlCommand("delete_by_id_teacher", Program.connection);
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
            MySqlCommand command = new MySqlCommand("update_teacher", Program.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("_id", id);
            command.Parameters.AddWithValue("des", richTextBox1.Text);
            command.Parameters.AddWithValue("fn", textBox1.Text);
            command.Parameters.AddWithValue("ln", textBox2.Text);
            command.Parameters.AddWithValue("e", textBox3.Text);
            command.Parameters.AddWithValue("pn", textBox4.Text);
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
                    richTextBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e) //search
        {
            Program.connection.Open();
            MySqlDataAdapter sqlDa = new MySqlDataAdapter("search_by_id_teacher", Program.connection);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("_id", textBox5.Text);
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);
            dataGridView1.DataSource = dt;
            //dataGridView1.Columns[0].Visible = false;
            Program.connection.Close();
        }
        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.doc)|*.doc";

            sfd.FileName = "export.doc";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                //ToCsV(dataGridView1, @"c:\export.xls");

                ToCsV(dataGridView1, sfd.FileName); // Here dataGridview1 is your grid view name 

            }
        }
    }
}
