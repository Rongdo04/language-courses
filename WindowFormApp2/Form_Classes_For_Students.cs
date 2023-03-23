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
    public partial class Form_Classes_For_Students : Form
    {
        public Form_Classes_For_Students()
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
        private void Form_Classes_For_Students_Load(object sender, EventArgs e)
        {
            Program.connection.Open();
            GridFill();
            Program.connection.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
