using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace StudentMS
{
    public class DatabaseHelper
    {
        readonly string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public (string Name, string Enrollment, string DateOfBirth) GetData(int UserId)
        {
            string query = $"SELECT Name, Enrollment, DateOfBirth FROM registrations WHERE RegistrationId = @RegistrationId";
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegistrationId", UserId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string name = reader["Name"].ToString();
                    string enrollment = reader["Enrollment"].ToString();
                    string dateOfBirth = reader["DateOfBirth"].ToString();

                    return (name, enrollment, dateOfBirth);
                }
                else
                {
                    return (null, null, null);
                }
            }
        }

        public int? GetUserIdByUsername(string username)   
        { 
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT RegistrationId FROM registrations WHERE Name = @Name");
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(stringBuilder.ToString(), connection);
                command.Parameters.AddWithValue("@Name", username);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["RegistrationId"]);
                    return userId;
                }
                else
                {
                    return null;
                }
            }
        }

        public DataTable GetCourseDetails()
        {
            DataTable dt = new DataTable();
            string query = "select CourseName , Name , Age , Enrollment , DateOfBirth from courses inner join CourseDetails on dbo.Courses.CourseId = dbo.CourseDetails.CourseId inner join Registrations on dbo.Registrations.RegistrationId = CourseDetails.RegistrationId";
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            return dt;
        }

        public int? CountStudents()
        {
            string query = "SELECT COUNT(*) AS Total_Students FROM registrations";
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int TotalStudents = Convert.ToInt32(reader["Total_Students"]);
                    return TotalStudents;
                }
                else
                {
                    return null;
                }
            }
        }

        public int? CountCourses()
        {
            string query = "SELECT COUNT(*) AS Total_Courses FROM Courses";
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int TCourses = Convert.ToInt32(reader["Total_Courses"]);
                    return TCourses;
                }
                else
                {
                    return null;
                }
            }
        }

        public DataTable GetCourseList()
        {
            DataTable dt = new DataTable();
            string query = "select Coursename from courses";
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable GetEnrolledCourses(int id)
        {
            DataTable dt = new DataTable();
            string query = $"select CourseName , Name , Age , Enrollment , DateOfBirth from courses inner join CourseDetails on dbo.Courses.CourseId = dbo.CourseDetails.CourseId inner join Registrations on dbo.Registrations.RegistrationId = CourseDetails.RegistrationId where Registrations.RegistrationId = {id}";
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            return dt;
        }

        //private void AddCourses(string CourseName)
        //{

        //    SqlConnection sql = new SqlConnection(cs);
        //    string query = "INSERT INTO courses VALUES (@CourseName)";
        //    using (SqlCommand command = new SqlCommand(query, sql))
        //    {
        //        command.Parameters.AddWithValue("@CourseName", CourseName);
        //        sql.Open();
        //        command.ExecuteNonQuery();
        //        sql.Close();
        //    }

        //}
    }
}
