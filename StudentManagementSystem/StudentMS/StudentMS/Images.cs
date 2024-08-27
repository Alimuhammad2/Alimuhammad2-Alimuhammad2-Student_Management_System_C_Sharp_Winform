using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StudentMS
{
    public partial class Images : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Images()
        {
            InitializeComponent();

            // Clear existing columns
            dataGridView1.Columns.Clear();

            // Add a column for displaying images
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "Image";
            imageColumn.Name = "ImageColumn";
            imageColumn.Width = 150; // Set column width
            dataGridView1.Columns.Add(imageColumn);

            // Adjust row height
            dataGridView1.RowTemplate.Height = 200; // Set row height
        }

        private void LoadImagesToDataGridView()
        {
            try
            {
                SqlConnection sql = new SqlConnection(cs);
                sql.Open();

                string query = "SELECT Image FROM ImagesTable";
                using (var command = new SqlCommand(query, sql))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Retrieve image data from database
                            byte[] imageData = (byte[])reader["Image"];
                            // Convert byte array to image
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                Image image = Image.FromStream(ms);
                                // Resize image to passport size
                                Image resizedImage = ResizeImage(image, 150, 200);
                                // Add image to DataGridView
                                dataGridView1.Rows.Add(new object[] { resizedImage });
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading images from database: " + ex.Message);
            }
        }
        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }
        private void Images_Load(object sender, EventArgs e)
        {
            LoadImagesToDataGridView();
            style();
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

        }
    }
}
