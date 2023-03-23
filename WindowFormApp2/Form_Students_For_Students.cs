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
    public partial class Form_Students_For_Students : Form
    {
       
        public Form_Students_For_Students()
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
      
        private void Form_Students_For_Students_Load(object sender, EventArgs e)
        {
            Program.connection.Open();
            GridFill();
            Program.connection.Close();

        }
    }
}
