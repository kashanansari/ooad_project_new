using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2;

namespace WindowsFormsApplication2
{
    public partial class student_login : Form
    {
            private BusinessLogicLayer bll = new BusinessLogicLayer();

            public student_login()
            {
                InitializeComponent();
            }

            private void label3_Click(object sender, EventArgs e)
            {

            }

            private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                student_signup ss = new student_signup();
                ss.Show();
            }

            private void button1_Click(object sender, EventArgs e)
            {
                string userEmail = email.Text;
                string userPassword = password.Text;

                string studentName = bll.ValidateStudentLogin(userEmail, userPassword).ToString();

                if (studentName != null)
                {
                    student_dashboard dashboardForm = new student_dashboard(); // Use the correct form name
                    //dashboardForm.WelcomeMessage = "Welcome, " + studentName;
                    dashboardForm.Show();
                    this.Hide(); // Hide the login form
                }
                else
                {
                    MessageBox.Show("Invalid credentials. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
