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
    public partial class Form_Levels_For_Students : Form
    {
        void GridFill() // FillData
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from mydb.level", Program.connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "level");
            dataGridView1.DataSource = ds.Tables["level"];
        }
        public Form_Levels_For_Students()
        {
            InitializeComponent();
        }

        private void Form_Levels_For_Students_Load(object sender, EventArgs e)
        {
            Program.connection.Open();
            GridFill();
            Program.connection.Close();

        }
    }
}
