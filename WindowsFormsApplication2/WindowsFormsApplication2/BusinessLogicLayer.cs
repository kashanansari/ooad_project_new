using System;
using System.Collections.Generic;

namespace WindowsFormsApplication2
{
    class BusinessLogicLayer
    {
        private DataAccessLayer dal = new DataAccessLayer();

        public bool ValidateAndAddUser(string name, string email, string password, string confirmPassword, string role, out string message)
        {
            if (password != confirmPassword)
            {
                message = "Password and Confirm Password do not match.";
                return false;
            }

            if (dal.EmailExists(email))
            {
                message = "Email already exists.";
                return false;
            }

            dal.AddUser(name, email, password, role);
            message = "Sign-up successful!";
            return true;
        }

        public bool ValidateStudentLogin(string email, string password)
        {
            return dal.ValidateStudentLogin(email, password);
        }

        public bool ValidateTeacherLogin(string email, string password)
        {
            return dal.ValidateTeacherLogin(email, password);
        }

        public bool ValidateAdminLogin(string email, string password)
        {
            return dal.ValidateAdminLogin(email, password);
        }

        public List<string> GetTeacherEmails()
        {
            return dal.GetTeacherEmails();
        }

        public void AddSchedule(string teachername, string timings, string day, string courses,string status)
        {
            dal.AddSchedule(teachername, timings, day, courses,status);
        }
        public List<string> GetScheduledClasses()
        {
            return dal.GetScheduledClasses();
        }
    }
}
