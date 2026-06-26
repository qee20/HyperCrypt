using System.Globalization;

namespace HyperCrypt
{
    public partial class MainForm
    {
        private void ApplyDefaults()
        {
            picInput.Image = Properties.Resources.imageplaceholderfornoimage;
            // Secret key (Lorenz 4D initial conditions) -- the ONLY truly
            // secret part of the key, per the design carried over from the
            // mockup ("Secret Key, wajib diisi").
            txtnumx0.Text = "0.1";
            txtNumy0.Text = "0.2";
            txtNumz0.Text = "0.3";
            txtNumw0.Text = "0.4";

            // Fixed Lorenz system parameters (read-only in the UI).
            txtParamA.Text = "10.0";
            txtParamB.Text = (8.0 / 3.0).ToString("0.0000", CultureInfo.InvariantCulture);
            txtParamC.Text = "28.0";
            txtParamH.Text = "0.01";
            txtParamTransient.Text = "1000";

            // Fixed ACM / Logistic Map / DNA parameters (editable, but
            // these must match exactly between Encrypt and Decrypt, same
            // as the secret key -- see label21/label9 tooltip notes).
            textNumAcmP.Text = "1";
            txtNumACMQ.Text = "1";
            txtNumAcmIter.Text = "10";
            txtNumLambdaKey.Text = "4.0";
            txtNumDnaRUleKey.Text = "1";

            originalImage = null;
            resultImage = null;
            picInput.Image = null;
            pictureBox1.Image = null;
            histInput = new long[256];
            histOutput = new long[256];
            pcbHistoInput.Invalidate();
            pcbHistoOutput.Invalidate();
            loadedImagePath = "";
            lblInputImagepath.Text = "Image Path Info will be shown here";
            lblimgInfo.Text = "Load image first";
            lblreport.Text = "Ready.";
        }
    }
}
