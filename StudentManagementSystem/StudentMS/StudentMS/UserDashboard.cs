using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentMS
{
    public partial class UserDashboard : Form
    {
        private DatabaseHelper dbHelper;
        private int userId;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public UserDashboard()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            this.userId = userId;
            PopulateCourses();
            EnrolledCourses();
        }
        private void PopulateCourses()
        {

            SqlConnection sql = new SqlConnection(cs);
            string query = "SELECT CourseName FROM courses";
            using (SqlCommand command = new SqlCommand(query, sql))
            {
                sql.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["CourseName"].ToString());
                }
                sql.Close();
            }

        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            DatabaseHelper d = new DatabaseHelper();

            string LoginUserName = UserSession.Username;
            var UserId = d.GetUserIdByUsername(LoginUserName);


            var data = dbHelper.GetData(Convert.ToInt32(UserId));

            if (data.Name != null)
            {
                label1.Text = data.Name;
                label2.Text = data.Enrollment;
                label3.Text = data.DateOfBirth;
            }
            else
            {
                MessageBox.Show("No data found.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedCourse = comboBox1.SelectedItem.ToString();

                if (!listBox1.Items.Contains(selectedCourse))
                {
                    listBox1.Items.Add(selectedCourse);
                }
                else
                {
                    MessageBox.Show("This course is already selected.", "Duplicate Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a course.", "No Course Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        public int AddCourse(string courseName)
        {
            int courseId = 0;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                string query = "INSERT INTO Courses (CourseName) OUTPUT INSERTED.CourseId VALUES (@CourseName)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseName", courseName);
                    connection.Open();
                    courseId = (int)command.ExecuteScalar();
                    connection.Close();
                }
            }

            return courseId;
        }

        private void AddCourseDetails(int courseId, int userId, string selectedCourse)
        {

            SqlConnection sql = new SqlConnection(cs);
            string query = "INSERT INTO CourseDetails (CourseId, RegistrationId, EnrollmentDate) VALUES (@CourseId, @RegistrationId, @EnrollmentDate)";
            using (SqlCommand command = new SqlCommand(query, sql))
            {
                command.Parameters.AddWithValue("@CourseId", courseId);
                command.Parameters.AddWithValue("@RegistrationId", userId);
                command.Parameters.AddWithValue("@EnrollmentDate", DateTime.Now);
                sql.Open();
                command.ExecuteNonQuery();
                MessageBox.Show($"{selectedCourse} Course Selected");
                sql.Close();
            }

        }

        private int GetUserId(string userName)
        {
            int userId = 0;

            SqlConnection sql = new SqlConnection(cs);
            {
                string query = "SELECT UserId FROM Users WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(query, sql))
                {
                    command.Parameters.AddWithValue("@UserName", userName);
                    sql.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        userId = (int)reader["UserId"];
                    }
                    sql.Close();
                }

                return userId;

            }
        }
        private int GetCourseId(string courseName)
        {
            int courseId = 0;

            SqlConnection sql = new SqlConnection(cs);
            string query = "SELECT CourseId FROM Courses WHERE CourseName = @CourseName";
            using (SqlCommand command = new SqlCommand(query, sql))
            {
                command.Parameters.AddWithValue("@CourseName", courseName);
                sql.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    courseId = (int)reader["CourseId"];
                }
                else
                {
                    // If the course does not exist, add it
                    sql.Close();
                    courseId = AddCourse(courseName);
                }
            }
            return courseId;
        }

        private void EnrolledCourses()
        {
            DatabaseHelper d = new DatabaseHelper();
            string LoginUserName = UserSession.Username;
            var UserId = d.GetUserIdByUsername(LoginUserName);

            DataTable dt = dbHelper.GetEnrolledCourses(Convert.ToInt32(UserId));
            dataGridView1.DataSource = dt;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select a course to remove.", "No Course Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatabaseHelper d = new DatabaseHelper();
            string LoginUserName = UserSession.Username;
            var UserId = d.GetUserIdByUsername(LoginUserName);

            foreach (var item in listBox1.Items)
            {
                string courseName = item.ToString();
                int courseId = GetCourseId(courseName);
                AddCourseDetails(courseId, Convert.ToInt32(UserId), courseName);
            }

            MessageBox.Show("Courses saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EnrolledCourses();
        }

        private void backbox_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }

    }
}
