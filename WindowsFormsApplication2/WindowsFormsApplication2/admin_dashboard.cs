using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class admin_dashboard : Form
    {
        private BusinessLogicLayer bll = new BusinessLogicLayer();

        public admin_dashboard()
        {
            InitializeComponent();
            this.Load += new EventHandler(admin_dashboard_Load);
        }

        private void admin_dashboard_Load(object sender, EventArgs e)
        {
            LoadTeacherEmails();
        }

        private void LoadTeacherEmails()
        {
            try
            {
                List<string> teacherEmails = bll.GetTeacherEmails();
                teacher_email.Items.Clear();
                foreach (string email in teacherEmails)
                {
                    teacher_email.Items.Add(email);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading teacher emails: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string teachername = teacher_email.Text;
                string timings = class_timing.Text;
                string day = class_date.Text;
                string courses = course.Text;
                string status = "1";

                if (string.IsNullOrEmpty(teachername) || string.IsNullOrEmpty(timings) || string.IsNullOrEmpty(day) || string.IsNullOrEmpty(courses))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                bll.AddSchedule(teachername, timings, day, courses,status);
                MessageBox.Show("Schedule added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            view_class_schedular vs = new view_class_schedular();
            vs.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle ComboBox selection change if needed
        }
    }
}
