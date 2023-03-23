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
using System.IO;
namespace WindowsFormsApp1
{
    public partial class Form_Students : Form
    {
      

        public Form_Students()
        {
            InitializeComponent();
        }

        void GridFill() // FillData
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from mydb.student", Program.connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "student");
            dataGridView1.DataSource = ds.Tables["student"];
        }
        private void Form_Students_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mydbDataSet11.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter1.Fill(this.mydbDataSet11.student);

            Program.connection.Open();
            GridFill();
            Program.connection.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) //cancel
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) // add
        {
            Program.connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO `mydb`.`student` ( `date_birth`, `state`, `city`, `zip_code`,`street`,`first_name`,`last_name`,`email`,`phone_number`,`class_id`,`login`,`password`) VALUES (@db,@ste,@ci,@zc,@stt,@fn,@ln,@e,@pn,@cli,@usn,@pwd);", Program.connection);
            command.Parameters.Add("@db", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@ste", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@ci", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@zc", MySqlDbType.Int32).Value = textBox4.Text;
            command.Parameters.Add("@stt", MySqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBox6.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBox7.Text;
            command.Parameters.Add("@e", MySqlDbType.VarChar).Value = textBox8.Text;
            command.Parameters.Add("@pn", MySqlDbType.VarChar).Value = textBox9.Text;
            command.Parameters.Add("@cli", MySqlDbType.VarChar).Value = textBox11.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBox12.Text;
            command.Parameters.Add("@pwd", MySqlDbType.VarChar).Value = textBox13.Text;
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
            MySqlCommand command = new MySqlCommand("delete_by_id_student", Program.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("_id", id);
            command.ExecuteNonQuery();
            GridFill();
            Program.connection.Close();
        }

        private void button5_Click(object sender, EventArgs e) //clear
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
            this.textBox7.Clear();
            this.textBox8.Clear();
            this.textBox9.Clear();
            this.textBox11.Clear();
            this.textBox12.Clear();
            this.textBox13.Clear();
        }

        private void button3_Click(object sender, EventArgs e) //update
        {
            
            Program.connection.Open();
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            MySqlCommand command = new MySqlCommand("update_student", Program.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("_id", id);
            command.Parameters.AddWithValue("db", textBox1.Text);
            command.Parameters.AddWithValue("ste", textBox2.Text);
            command.Parameters.AddWithValue("ci", textBox3.Text);
            command.Parameters.AddWithValue("zc", textBox4.Text);
            command.Parameters.AddWithValue("stt", textBox5.Text);
            command.Parameters.AddWithValue("fn", textBox6.Text);
            command.Parameters.AddWithValue("ln", textBox7.Text);
            command.Parameters.AddWithValue("e", textBox8.Text);
            command.Parameters.AddWithValue("pn", textBox9.Text);
            command.Parameters.AddWithValue("cli", textBox11.Text);
            command.Parameters.AddWithValue("usn", textBox12.Text);
            command.Parameters.AddWithValue("pwd", textBox13.Text);
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
                    textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    textBox11.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    textBox12.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    textBox13.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e) // Search
        {
            Program.connection.Open();
            MySqlDataAdapter sqlDa = new MySqlDataAdapter("search_by_id_student", Program.connection);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("_id", textBox10.Text);
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
        private void button7_Click(object sender, EventArgs e) //Print
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
