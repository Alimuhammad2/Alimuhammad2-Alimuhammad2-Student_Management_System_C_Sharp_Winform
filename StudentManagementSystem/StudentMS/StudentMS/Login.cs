using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace StudentMS
{
    public partial class Login : Form
    {
        private VideoCaptureDevice videoSource;
        private FilterInfoCollection videoDevices;
        private DatabaseHelper dbHelper;
        int count = 0;
        public Login()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            GetCameras();
            CameraOn();
        }
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private void button1_Click(object sender, EventArgs e)
        {

            if (count == 1)
            {
                MessageBox.Show("login failed");
                SaveCapturedImage();
            }
            SqlConnection sql = new SqlConnection(cs);
            sql.Open();
            string qry = "select * from Registrations where Name = @user and password = @pass";
            SqlCommand cmd = new SqlCommand(qry, sql);
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                // Store username in session-like class
                UserSession.Username = textBox1.Text;
                MessageBox.Show("Login Sucessfull ✔ ");
                UserDashboard d = new UserDashboard();
                d.Show();
                this.Hide();

            }
            else if (dr.HasRows == false)
            {
                count = +1;
                MessageBox.Show("login failed try again!");
            }
            else
            {
                MessageBox.Show("Failed to Login ☒ ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sql = new SqlConnection(cs);
                sql.Open();
                string qry = "select * from AdminTbl where Name = @user and password = @pass";
                SqlCommand cmd = new SqlCommand(qry, sql);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    // Store username in session-like class
                    UserSession.Username = textBox1.Text;

                    MessageBox.Show("Login Sucessfull ✔ ");
                    AdminDashboard a = new AdminDashboard();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("Failed to Login ☒ ");
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void SaveCapturedImage()
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    string directoryPath = @"C:\Users\Ali Muhammad\Desktop\picturee";
                    // Generate a unique file name
                    string fileName = $"captured_image_{DateTime.Now:yyyyMMddHHmmss}.jpg";
                    // Combine directory path and file name
                    string filePath = Path.Combine(directoryPath, fileName);
                    // Save the image to the specified directory
                    pictureBox1.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                    byte[] imageData;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageData = ms.ToArray();
                    }

                    // Save the image data to the database
                    SaveImageToDatabase(imageData);

                    //  MessageBox.Show("Image saved to database.");
                }
                else
                {
                    MessageBox.Show("No image captured.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveImageToDatabase(byte[] imageData)
        {
            try
            {
                SqlConnection sql = new SqlConnection(cs);
                sql.Open();

                string query = "INSERT INTO ImagesTable (Image) VALUES (@Image)";
                using (var command = new SqlCommand(query, sql))
                {
                    command.Parameters.AddWithValue("@Image", imageData);
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving image to database: " + ex.Message);
            }
        }

        private void GetCameras()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in videoDevices)
            {
                comboBox1.Items.Add(device.Name);
            }

            if (videoDevices.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (videoSource != null && videoSource.IsRunning)
                {
                    videoSource.SignalToStop();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // base.OnFormClosing(e);

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                pictureBox1.Image = bitmap;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    if (videoSource == null || !videoSource.IsRunning)
        //    {
        //        if (comboBox1.SelectedIndex != -1)
        //        {
        //            videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
        //            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
        //            videoSource.Start();
        //        }
        //        else
        //        {
        //            MessageBox.Show("No camera selected.");
        //        }
        //    }
        //    else
        //    {
        //        videoSource.SignalToStop();
        //        SaveCapturedImage();
        //    }
        //}

        private void CameraOn()
        {
            if (videoSource == null || !videoSource.IsRunning)
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                    videoSource.Start();
                }
                else
                {
                    MessageBox.Show("No camera selected.");
                }
            }
            else
            {
                videoSource.SignalToStop();
                SaveCapturedImage();
            }
        }

        private void backbox_Click(object sender, EventArgs e)
        {
            RegistrationForm r = new RegistrationForm();
            r.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
