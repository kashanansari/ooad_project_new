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
    public partial class teacher_signup : Form
    {
        private BusinessLogicLayer bll = new BusinessLogicLayer();

        public teacher_signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = name.Text;
            string emailAddress = email.Text;
            string userPassword = password.Text;
            string confirmPassword = confirmpassword.Text;
            string role = "teacher";

            string message;
            if (bll.ValidateAndAddUser(userName, emailAddress, userPassword, confirmPassword, role, out message))
            {
                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Clear the form or redirect the user as needed
                name.Clear();
                email.Clear();
                password.Clear();
                confirmpassword.Clear();
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
