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
    public partial class Form_Greeting_for_student : Form
    {
        public Form_Greeting_for_student()
        {
            InitializeComponent();
        }
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    
        void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
            Form f3 = new Form_Menu_For_Student();
            f3.Show();
            timer.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form_Greeting_for_student_Load(object sender, EventArgs e)
        {
            timer.Start();
            timer.Interval = 3000;
            timer.Tick += new EventHandler(timer_Tick);

        }
    }
}
