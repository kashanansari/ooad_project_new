using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    class DataAccessLayer
    {
        private string _connectionString = "Data Source=DESKTOP-FEN66L3;Initial Catalog=ooad_project;Integrated Security=True";

        public bool EmailExists(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT COUNT(*) FROM data WHERE email = @Email";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred in EmailExists: {ex.Message}");
                throw;
            }
        }

        public void AddUser(string name, string email, string password, string role)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO data (name, email, password, role) VALUES (@Name, @Email, @Password, @Role)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred in AddUser: {ex.Message}");
                throw;
            }
        }

        public bool ValidateStudentLogin(string email, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT COUNT(*) FROM data WHERE Email = @Email AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred in ValidateStudentLogin: {ex.Message}");
                throw;
            }
        }

        public bool ValidateTeacherLogin(string email, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT COUNT(*) FROM data WHERE Email = @Email AND Password = @Password AND Role = 'teacher'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred in ValidateTeacherLogin: {ex.Message}");
                throw;
            }
        }

        public bool ValidateAdminLogin(string email, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT COUNT(*) FROM data WHERE Email = @Email AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred in ValidateAdminLogin: {ex.Message}");
                throw;
            }
        }

        public List<string> GetTeacherEmails()
        {
            try
            {
                List<string> emails = new List<string>();

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT email FROM data WHERE role = 'teacher'";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            emails.Add(reader.GetString(0));
                        }
                    }
                    conn.Close();
                }

                return emails;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred in GetTeacherEmails: {ex.Message}");
                throw;
            }
        }

        public void AddSchedule(string teachername, string timings, string day, string courses, string status)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO timings (teachername, timings, day, course,status) VALUES (@teachername, @timings, @day, @courses,@status)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@teachername", teachername);
                    cmd.Parameters.AddWithValue("@timings", timings);
                    cmd.Parameters.AddWithValue("@day", day);
                    cmd.Parameters.AddWithValue("@courses", courses);
                    cmd.Parameters.AddWithValue("@status", status);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred in AddSchedule:{ex.Message}");
                throw;
            }
        }  
    public List<string> GetScheduledClasses()
        {
            try
            {
                List<string> scheduledClasses = new List<string>();

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM timings WHERE status = 1";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming the columns are in order: teachername, timings, day, courses, status
                            string classDetails = "{reader.GetString(0)}, {reader.GetString(1)}, {reader.GetString(2)}, {reader.GetString(3)}, {reader.GetString(4)}";
                            scheduledClasses.Add(classDetails);
                        }
                    }
                    conn.Close();
                }

                return scheduledClasses;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred in GetScheduledClasses: {ex.Message}");
                throw;
            }
        }
    }
}
