using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Courses f = new Form_Courses();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_Teachers f = new Form_Teachers();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Classes f = new Form_Classes();
                f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_Students f = new Form_Students();
            f.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_Payments f = new Form_Payments();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form_Levels f = new Form_Levels();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form_Categories f = new Form_Categories();
            f.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_Login f = new Form_Login();
            f.ShowDialog();
        }
    }
}
