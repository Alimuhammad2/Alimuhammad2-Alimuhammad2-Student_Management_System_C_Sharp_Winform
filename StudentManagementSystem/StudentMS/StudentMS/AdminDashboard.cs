using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace StudentMS
{
    public partial class AdminDashboard : Form
    {
        private DatabaseHelper dbHelper;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public AdminDashboard()
        {

            dbHelper = new DatabaseHelper();
            InitializeComponent();
            LoadCourseDetails();
            LoadCourseNamesList();

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
           
            var Count = dbHelper.CountStudents();
            var TCountCourses = dbHelper.CountCourses();

            label2.Text = Count.ToString();
            label3.Text = TCountCourses.ToString();
        }


        private void LoadCourseDetails()
        {
            DataTable dt = dbHelper.GetCourseDetails();
            dataGridView1.DataSource = dt;
            style2();
        }

        private void LoadCourseNamesList()
        {
            DataTable dt = dbHelper.GetCourseList();
            dataGridView2.DataSource = dt;
            style();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please Insert Course");
            }
            else
            {
                SqlConnection sql = new SqlConnection(cs);
                string query = "INSERT INTO courses VALUES (@CourseName)";
                using (SqlCommand command = new SqlCommand(query, sql))
                {
                    command.Parameters.AddWithValue("@CourseName", textBox1.Text);
                    sql.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show($"Courses Added : {textBox1.Text}");
                    sql.Close();
                    LoadCourseNamesList();
                    textBox1.Text = string.Empty;
                }
            }

        }

        public void style()
        {
            //DataGridView Design
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans serif", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Size = new Size(600, 400);

        }
        public void style2()
        {
            //DataGridView Design
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkSlateGray;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans serif", 10);
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(cs);
            sql.Open();
            //Wild Card Search
            string qry = "select CourseName , Name , Age , Enrollment , DateOfBirth from courses inner join CourseDetails on dbo.Courses.CourseId = dbo.CourseDetails.CourseId inner join Registrations on dbo.Registrations.RegistrationId = CourseDetails.RegistrationId WHERE name LIKE '%" + textBox2.Text + "%' ";
            SqlDataAdapter da = new SqlDataAdapter(qry, sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sql.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Images image = new Images();
            image.Show();

        }

        private void backbox_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

      
    }
}
