using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentMS
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
        private void RegisterUser(string name, string password, string age, DateTime DateOfBirth)
        {
            //Trigger implement auto when userRegister it generates Random Enrollment Number
            int CurrentAge = DateTime.Today.Year - dateTimePicker1.Value.Year;
            Agetxt.Text = CurrentAge.ToString();
           // Agetxt.Enabled = true;


            SqlConnection sql = new SqlConnection(cs);
            string query = "INSERT INTO Registrations (Name, Password, Age, Enrollment,DateOfBirth) " +
                               "VALUES (@Name, @Password, @Age, '' ,@DateOfBirth)";
            using (SqlCommand command = new SqlCommand(query, sql))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Age", CurrentAge);
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                sql.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("User Registered");
                sql.Close();
                ClearTextBox();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (ValidateInputs())
            {
                RegisterUser(nametxt.Text, passwordtxt.Text, Agetxt.Text, dateTimePicker1.Value);
            }
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(nametxt.Text))
            {
                MessageBox.Show("Name is required.");
                nametxt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(passwordtxt.Text))
            {
                MessageBox.Show("Password is required.");
                passwordtxt.Focus();
                return false;
            }
            /*if (string.IsNullOrWhiteSpace(Agetxt.Text))
            {
                MessageBox.Show("Age is required.");
                Agetxt.Focus();
                return false;
            }*/
            if (!dateTimePicker1.Checked)
            {
                MessageBox.Show("Date of birth is required.");
                dateTimePicker1.Focus();
                return false;
            }
            return true;
        }

        private void ClearTextBox()
        {
            nametxt.Text = string.Empty;
            passwordtxt.Text = "";
            Agetxt.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Agetxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
