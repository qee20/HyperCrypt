using HyperCrypt.Models;
using System.Drawing.Imaging;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace HyperCrypt
{
    public partial class MainForm
    {
        private void BrowseImage()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Image";
                ofd.Filter = "Images (*.bmp;*.png;*.jpg;*.jpeg)|*.bmp;*.png;*.jpg;*.jpeg";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var bmp = new Bitmap(ofd.FileName))
                        {
                            int origW = bmp.Width, origH = bmp.Height;
                            picInput.Image = new Bitmap(bmp);   
                            originalImage = ImageProcessingService.LoadAsSquareGrayscale(bmp); 

                            resultImage = null;
                            pictureBox1.Image = null;
                            histOutput = new long[256];
                            pcbHistoOutput.Invalidate();

                            loadedImagePath = ofd.FileName;
                            int side = originalImage.GetLength(0);
                            lblInputImagepath.Text = $"{Path.GetFileName(ofd.FileName)}";

                            histInput = CryptoCore.Histogram(originalImage);
                            pcbHistoInput.Invalidate();

                            lblreport.Text = "The image has been loaded. Ensure that the secret key (x₀, y₀, z₀, w₀) is correct, then click Encrypt.";
                        }
                       

                        // Load the selected image
                        picInput.SizeMode = PictureBoxSizeMode.Zoom;

                        FileInfo fi = new FileInfo(ofd.FileName);
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

        private bool TryReadKey(out CryptoCore.SecretKey key, out string error)
        {
            key = null;
            error = null;

            if (!KeyOrTextHelperProcessingService.TryParseDouble(txtnumx0.Text, "x0", out double x0, out error)) return false;
            if (!KeyOrTextHelperProcessingService.TryParseDouble(txtNumy0.Text, "y0", out double y0, out error)) return false;
            if (!KeyOrTextHelperProcessingService.TryParseDouble(txtNumz0.Text, "z0", out double z0, out error)) return false;
            if (!KeyOrTextHelperProcessingService.TryParseDouble(txtNumw0.Text, "w0", out double w0, out error)) return false;
            if (!KeyOrTextHelperProcessingService.TryParseInt(textNumAcmP.Text, "ACM p", out int p, out error)) return false;
            if (!KeyOrTextHelperProcessingService.TryParseInt(txtNumACMQ.Text, "ACM q", out int q, out error)) return false;
            if (!KeyOrTextHelperProcessingService.TryParseInt(txtNumAcmIter.Text, "ACM iter", out int nIter, out error)) return false;
            if (!KeyOrTextHelperProcessingService.TryParseDouble(txtNumLambdaKey.Text, "lambda (LM)", out double lambda, out error)) return false;

            if (nIter < 1) { error = "ACM iter harus >= 1."; return false; }
            if (lambda < 3.57 || lambda > 4.0)
            {
                MessageBox.Show(
                    "lambda (Logistic Map) sebaiknya di rentang 3.57\u20134.0 agar tetap chaotic. " +
                    "Nilai saat ini tetap dipakai, tapi keamanan tidak terjamin di luar rentang ini.",
                    "Peringatan parameter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            key = new CryptoCore.SecretKey
            {
                X0 = x0,
                Y0 = y0,
                Z0 = z0,
                W0 = w0,
                P = p,
                Q = q,
                NIter = nIter,
                Lambda = lambda,
                Rounds = 2
            };
            return true;
        }

        private void EncryptImage()
        {
            if (originalImage == null)
            {
                MessageBox.Show("Muat gambar dulu lewat Browse Image.", "Belum ada gambar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!TryReadKey(out var key, out string err))
            {
                MessageBox.Show(err, "Parameter tidak valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                var t0 = DateTime.Now;
                //var cipher = CryptoCore.Encrypt(originalImage, key);
                //var plain = CryptoCore.Decrypt(cipher, key);
                //double mse = CryptoCore.Mse(originalImage, plain);
                //MessageBox.Show($"MSE = {mse}");
                //return;   // hentikan dulu
                resultImage = CryptoCore.Encrypt(originalImage, key);
                double elapsed = (DateTime.Now - t0).TotalSeconds;

                pictureBox1.Image = ImageProcessingService.ByteArrayToBitmap(resultImage);
                histOutput = CryptoCore.Histogram(resultImage);
                pcbHistoOutput.Invalidate();
                lastOpWasEncrypt = true;

                lblreport.Text =
                    $"Encrypted {originalImage.GetLength(0)}x{originalImage.GetLength(0)} dalam {elapsed:F2}s.\r\n" +
                    "Pipeline: ACM -> 2x [DNA-XOR(dynamic rule + S-box) -> Logistic-Map add], bidirectional chaining.\r\n" +
                    "Klik Analysis untuk entropy / NPCR / UACI / correlation. Histogram Output sudah diperbarui.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Encrypt gagal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { Cursor = Cursors.Default; }
        }

        private void DecryptImage()
        {
            byte[,] source = resultImage ?? originalImage;
            
            if (source == null)
            {
                MessageBox.Show("Belum ada apa pun untuk didekripsi.", "Kosong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!TryReadKey(out var key, out string err))
            {
                MessageBox.Show(err, "Parameter tidak valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //var testCipher = CryptoCore.Encrypt(originalImage, key);
            //double mseCipher = CryptoCore.Mse(resultImage, testCipher);
            //MessageBox.Show($"Cipher MSE = {mseCipher}");
            Cursor = Cursors.WaitCursor;
            try
            {
                var t0 = DateTime.Now;
                var decrypted = CryptoCore.Decrypt(source, key);
                double elapsed = (DateTime.Now - t0).TotalSeconds;

                pictureBox1.Image = ImageProcessingService.ByteArrayToBitmap(decrypted);
                histOutput = CryptoCore.Histogram(decrypted);
                pcbHistoOutput.Invalidate();
                resultImage = decrypted;
                lastOpWasEncrypt = false;

                string verdict;
                if (originalImage != null && originalImage.GetLength(0) == decrypted.GetLength(0))
                {
                    double mse = CryptoCore.Mse(originalImage, decrypted);
                    verdict = mse == 0
                        ? "COCOK SEMPURNA dengan gambar asli (MSE = 0)."
                        : $"TIDAK COCOK dengan gambar asli (MSE = {mse:F4}) -- kemungkinan key/parameter salah, atau ini bukan ciphertext dari gambar asli yang sedang dimuat.";
                }
                else
                {
                    verdict = "(Tidak ada gambar asli untuk dibandingkan -- load lewat Browse Image dulu kalau ingin verifikasi MSE.)";
                }

                lblreport.Text = $"Decrypted dalam {elapsed:F2}s.\r\n{verdict}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Decrypt gagal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { Cursor = Cursors.Default; }
        }

        private void Analyze()
        {
            if (originalImage == null || resultImage == null || !lastOpWasEncrypt)
            {
                MessageBox.Show("Load gambar dan klik Encrypt dulu, baru jalankan Analysis.", "Belum siap", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!TryReadKey(out var key, out string err))
            {
                MessageBox.Show(err, "Parameter tidak valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                int N = originalImage.GetLength(0);

                double entPlain = CryptoCore.Entropy(originalImage);
                double entCipher = CryptoCore.Entropy(resultImage);

                CryptoCore.CorrelationCoefficients(originalImage, out double hP, out double vP, out double dP);
                CryptoCore.CorrelationCoefficients(resultImage, out double hC, out double vC, out double dC);

                var modified = (byte[,])originalImage.Clone();
                modified[0, 0] = (byte)(modified[0, 0] ^ 0x01);
                var cipher2 = CryptoCore.Encrypt(modified, key);

                double npcr = CryptoCore.Npcr(resultImage, cipher2);
                double uaci = CryptoCore.Uaci(resultImage, cipher2);

                var sb = new StringBuilder();
                sb.AppendLine("=== Security Analysis Report ===");
                sb.AppendLine($"Gambar: {Path.GetFileName(loadedImagePath)}   Ukuran: {N}x{N}");
                sb.AppendLine();
                sb.AppendLine($"Entropy       plain = {entPlain:F4}    cipher = {entCipher:F4}    (target cipher > 7.990)");
                sb.AppendLine($"Correlation   plain (H,V,D) = ({hP:F4}, {vP:F4}, {dP:F4})");
                sb.AppendLine($"              cipher (H,V,D) = ({hC:F4}, {vC:F4}, {dC:F4})    (target \u2248 0)");
                sb.AppendLine($"NPCR = {npcr:F4} %    (target > 99.60)");
                sb.AppendLine($"UACI = {uaci:F4} %    (target \u2248 33.46)");
                sb.AppendLine();
                sb.AppendLine("NPCR/UACI: bit 0 pixel (0,0) plaintext diflip internal, dienkripsi ulang");
                sb.AppendLine("dengan key yang sama, dibandingkan ke ciphertext yang tampil -- uji standar.");

                MessageBox.Show(sb.ToString(), "Security Analysis", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblreport.Text =
                    $"Analysis selesai. Entropy(cipher)={entCipher:F4}  NPCR={npcr:F4}%  UACI={uaci:F4}%  " +
                    $"Correlation(cipher H,V,D)=({hC:F4},{vC:F4},{dC:F4}). Lihat dialog untuk detail lengkap.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Analysis gagal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { Cursor = Cursors.Default; }
        }

        private void SaveResultImage()
        {
            if (resultImage == null)
            {
                MessageBox.Show("Belum ada hasil untuk disimpan.", "Kosong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (var sfd = new SaveFileDialog { Filter = "PNG Image|*.png" })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                using (var bmp = ImageProcessingService.ByteArrayToBitmap(resultImage))
                    bmp.Save(sfd.FileName, ImageFormat.Png);
                lblreport.Text = "Gambar hasil disimpan ke " + sfd.FileName;
            }
        }

        private void LoadKey()
        {
            using (var ofd = new OpenFileDialog { Filter = "Key file (*.key)|*.key|Text file (*.txt)|*.txt|All files|*.*" })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;
                try
                {
                    var parts = File.ReadAllText(ofd.FileName).Trim().Split(',');
                    if (parts.Length != 8) throw new FormatException("Diharapkan 8 nilai dipisah koma, ditemukan " + parts.Length + ".");

                    txtnumx0.Text = parts[0];
                    txtNumy0.Text = parts[1];
                    txtNumz0.Text = parts[2];
                    txtNumw0.Text = parts[3];
                    textNumAcmP.Text = parts[4];
                    txtNumACMQ.Text = parts[5];
                    txtNumAcmIter.Text = parts[6];
                    txtNumLambdaKey.Text = parts[7];

                    lblreport.Text = "Key dimuat dari " + ofd.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat key file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveKey()
        {
            if (!TryReadKey(out var key, out string err))
            {
                MessageBox.Show(err, "Parameter tidak valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var sfd = new SaveFileDialog { Filter = "Key file (*.key)|*.key|Text file (*.txt)|*.txt" })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                string line = string.Join(",", new string[]
                {
                    key.X0.ToString("G17", CultureInfo.InvariantCulture),
                    key.Y0.ToString("G17", CultureInfo.InvariantCulture),
                    key.Z0.ToString("G17", CultureInfo.InvariantCulture),
                    key.W0.ToString("G17", CultureInfo.InvariantCulture),
                    key.P.ToString(CultureInfo.InvariantCulture),
                    key.Q.ToString(CultureInfo.InvariantCulture),
                    key.NIter.ToString(CultureInfo.InvariantCulture),
                    key.Lambda.ToString("G17", CultureInfo.InvariantCulture)
                });
                File.WriteAllText(sfd.FileName, line);
                lblreport.Text = "Key (8 nilai: x0,y0,z0,w0,ACM p,ACM q,ACM iter,lambda) disimpan ke " + sfd.FileName;
            }
        }
    }
}
