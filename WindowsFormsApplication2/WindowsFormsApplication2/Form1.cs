using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            student_login sl = new student_login();
            sl.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            teacher_login tl = new teacher_login();
            tl.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_login al = new admin_login();
            al.Show();
        }
    }
}
