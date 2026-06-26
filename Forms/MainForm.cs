namespace HyperCrypt
{
    public partial class MainForm : Form
    {
        // ---- application state ----
        private byte[,] originalImage;   // set by Browse Image
        private byte[,] resultImage;      // last Encrypt/Decrypt output
        private bool lastOpWasEncrypt;
        private string loadedImagePath = "";
        private long[] histInput = new long[256];
        private long[] histOutput = new long[256];
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplyDefaults();
        }

        private void pcbHistoInput_Paint(object sender, PaintEventArgs e)
        {
            ImageProcessingService.DrawHistogram(e.Graphics, pcbHistoInput.ClientSize, histInput);
        }

        private void pcbHistoOutput_Paint(object sender, PaintEventArgs e)
        {
            ImageProcessingService.DrawHistogram(e.Graphics, pcbHistoOutput.ClientSize, histOutput);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ApplyDefaults();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            EncryptImage();
        }
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            DecryptImage();
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            Analyze();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            BrowseImage();
        }

        private void btnSaveKey_Click(object sender, EventArgs e)
        {
            SaveKey();
        }

        private void btnLoadKey_Click(object sender, EventArgs e)
        {
            LoadKey();
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            SaveResultImage();
        }
    }
}
