namespace HyperCrypt
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            picInput.Image = Properties.Resources.imageplaceholderfornoimage;
        }

        private void pcbHistoInput_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int[] values = { 5, 12, 8, 15 };
            for (int i = 0; i < values.Length; i++)
            {
                g.FillRectangle(
                    Brushes.SteelBlue,
                    i * 60 + 20,
                    200 - values[i] * 10,
                    40,
                    values[i] * 10);
            }
        }

        private void pcbHistoOutput_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int[] values = { 5, 12, 8, 15 };
            for (int i = 0; i < values.Length; i++)
            {
                g.FillRectangle(
                    Brushes.SteelBlue,
                    i * 60 + 20,
                    200 - values[i] * 10,
                    40,
                    values[i] * 10);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Clear previous image to avoid file lock
                        if (picInput.Image != null)
                        {
                            picInput.Image.Dispose();
                        }

                        // Load the selected image
                        picInput.Image = Image.FromFile(openFileDialog.FileName);
                        picInput.SizeMode = PictureBoxSizeMode.Zoom;
                        lblInputImagepath.Text = openFileDialog.FileName;

                        FileInfo fi = new FileInfo(openFileDialog.FileName);
                        lblimgInfo.Text = $"{picInput.Image.Width} x {picInput.Image.Height} | {fi.Length / 1024} kb";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
