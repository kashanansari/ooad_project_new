using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class teacher_login : Form
    {
        private BusinessLogicLayer bll = new BusinessLogicLayer();

        public teacher_login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            teacher_signup ts = new teacher_signup();
            ts.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userEmail = email.Text; // Use a different name for the text box variable if needed
            string userPassword = password.Text; // Use a different name for the text box variable if needed

            try
            {
                if (bll.ValidateTeacherLogin(userEmail, userPassword))
                {
                    // Login successful, open the dashboard form
                    teacher_dashboard dashboardForm = new teacher_dashboard();
                    dashboardForm.Show();
                    this.Hide(); // Hide the login form
                }
                else
                {
                    MessageBox.Show("Invalid credentials. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
