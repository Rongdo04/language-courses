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
    public partial class Form_Menu_For_Student : Form
    {
       

        public Form_Menu_For_Student()
        {
            InitializeComponent();
        }

        private void Show_role_account_Load(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Login f = new Form_Login();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Teachers_For_Students f = new Form_Teachers_For_Students();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Courses_For_Students f = new Form_Courses_For_Students();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_Levels_For_Students f = new Form_Levels_For_Students();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_Categories_For_Students f = new Form_Categories_For_Students();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_Classes_For_Students f = new Form_Classes_For_Students();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form_Students_For_Students f = new Form_Students_For_Students();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Reg2 f = new Reg2();
            f.ShowDialog();
        }
    }
}
