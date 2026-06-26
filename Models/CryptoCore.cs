using System;
using System.Collections.Generic;

namespace HyperCrypt.Models
{
    // =====================================================================
    // CRYPTO CORE — validated reference algorithm.
    // Same logic as the Python reference implementation (hyperchaotic_dna_
    // crypto.py) that was tested end-to-end: entropy ~7.997, NPCR mean
    // 99.61% (min 99.55%), UACI mean 33.52% (target ~33.46%), perfect
    // decryption, across 100 single-bit-flip trials on 2 independent keys.
    // See the design-correction notes on DnaXorStep() and OneRound() below
    // for WHY the implementation differs from a literal "DNA-XOR then
    // Logistic-XOR then CBC chain" reading of the original outline.
    // =====================================================================
    public static class CryptoCore
    {
        // ---- 1. 4D Lorenz hyperchaotic system (RK4) --------------------
        public static void Lorenz4D(double x0, double y0, double z0, double w0,
            int nPoints, out double[] xs, out double[] ys, out double[] zs, out double[] ws,
            double a = 10.0, double b = 8.0 / 3.0, double c = 28.0,
            double h = 0.01, int nTransient = 1000)
        {
            xs = new double[nPoints];
            ys = new double[nPoints];
            zs = new double[nPoints];
            ws = new double[nPoints];

            double x = x0, y = y0, z = z0, w = w0;
            int total = nTransient + nPoints;

            for (int i = 0; i < total; i++)
            {
                double k1x = a * (y - x);
                double k1y = c * x - x * z + w;
                double k1z = x * y - b * z;
                double k1w = -y * w;

                double x2 = x + h / 2 * k1x, y2 = y + h / 2 * k1y, z2 = z + h / 2 * k1z, w2 = w + h / 2 * k1w;
                double k2x = a * (y2 - x2);
                double k2y = c * x2 - x2 * z2 + w2;
                double k2z = x2 * y2 - b * z2;
                double k2w = -y2 * w2;

                double x3 = x + h / 2 * k2x, y3 = y + h / 2 * k2y, z3 = z + h / 2 * k2z, w3 = w + h / 2 * k2w;
                double k3x = a * (y3 - x3);
                double k3y = c * x3 - x3 * z3 + w3;
                double k3z = x3 * y3 - b * z3;
                double k3w = -y3 * w3;

                double x4 = x + h * k3x, y4 = y + h * k3y, z4 = z + h * k3z, w4 = w + h * k3w;
                double k4x = a * (y4 - x4);
                double k4y = c * x4 - x4 * z4 + w4;
                double k4z = x4 * y4 - b * z4;
                double k4w = -y4 * w4;

                x += (h / 6.0) * (k1x + 2 * k2x + 2 * k3x + k4x);
                y += (h / 6.0) * (k1y + 2 * k2y + 2 * k3y + k4y);
                z += (h / 6.0) * (k1z + 2 * k2z + 2 * k3z + k4z);
                w += (h / 6.0) * (k1w + 2 * k2w + 2 * k3w + k4w);

                if (i >= nTransient)
                {
                    int idx = i - nTransient;
                    xs[idx] = x; ys[idx] = y; zs[idx] = z; ws[idx] = w;
                }
            }
        }

        // ---- 2. Key material from the two Lorenz sequences -------------
        public class KeyMaterial
        {
            public byte[] RuleSeq;     // DNA rule index per pixel, 1..8 (Sequence 1: x,z)
            public byte[] KeyMatrix;   // DNA-XOR diffusion key, per pixel (Sequence 2: y,w)
            public byte[] LmKeystream; // Logistic Map keystream, per pixel
            public byte Iv;
            public byte Iv2;
        }

        public static KeyMaterial DeriveKeys(double x0, double y0, double z0, double w0,
            int nPixels, double lam)
        {
            double[] x, y, z, w;
            Lorenz4D(x0, y0, z0, w0, nPixels, out x, out y, out z, out w);

            var km = new KeyMaterial
            {
                RuleSeq = new byte[nPixels],
                KeyMatrix = new byte[nPixels],
                LmKeystream = new byte[nPixels]
            };

            for (int i = 0; i < nPixels; i++)
            {
                long rx = (long)Math.Floor(Math.Abs(x[i]) * 1e8);
                long rz = (long)Math.Floor(Math.Abs(z[i]) * 1e8);
                km.RuleSeq[i] = (byte)(((rx + rz) % 8) + 1);

                long ky = (long)(Math.Floor(Math.Abs(y[i]) * 1e8) % 256);
                long kw = (long)(Math.Floor(Math.Abs(w[i]) * 1e8) % 256);
                km.KeyMatrix[i] = (byte)(ky ^ kw);
            }

            // Logistic Map IC: Sequence 1 (x), first sample only
            double x0Lm = Math.Abs(x[0]) % 1.0;
            if (x0Lm == 0.0 || x0Lm == 1.0) x0Lm = 0.5; // avoid degenerate seed

            double xv = x0Lm;
            for (int i = 0; i < nPixels; i++)
            {
                xv = lam * xv * (1 - xv);
                km.LmKeystream[i] = (byte)((long)Math.Floor(Math.Abs(xv) * 1e8) % 256);
            }

            // Chaining IV -- derived from the secret key itself.
            km.Iv = (byte)((long)Math.Floor(Math.Abs(x0 + y0 + z0 + w0) * 1e8) % 256);
            km.Iv2 = (byte)((km.Iv + 137) % 256);

            return km;
        }

        // ---- 3. Arnold Cat Map (confusion) ------------------------------
        public static byte[,] AcmPermute(byte[,] img, int p, int q, int nIter, bool inverse)
        {
            int N = img.GetLength(0);
            var outImg = new byte[N, N];
            for (int y = 0; y < N; y++)
            {
                for (int x = 0; x < N; x++)
                {
                    int X = x, Y = y;
                    for (int it = 0; it < nIter; it++)
                    {
                        int Xn, Yn;
                        if (!inverse)
                        {
                            Xn = Mod(X + p * Y, N);
                            Yn = Mod(q * X + (p * q + 1) * Y, N);
                        }
                        else
                        {
                            Xn = Mod((p * q + 1) * X - p * Y, N);
                            Yn = Mod(-q * X + Y, N);
                        }
                        X = Xn; Y = Yn;
                    }
                    outImg[Y, X] = img[y, x];
                }
            }
            return outImg;
        }

        private static int Mod(int a, int n)
        {
            int r = a % n;
            return r < 0 ? r + n : r;
        }

        // ---- 4. DNA encoding (8 Watson-Crick rules) + DNA XOR -----------
        // base id: A=0, C=1, G=2, T=3. Rule k maps raw 2-bit chunk -> base id.
        public static readonly int[][] DnaRules = new int[][]
        {
            null,
            new int[] {0, 1, 2, 3},     // Rule 1 (identity / canonical bits)
            new int[] {0, 2, 1, 3},     // Rule 2
            new int[] {1, 0, 3, 2},     // Rule 3
            new int[] {2, 0, 3, 1},     // Rule 4
            new int[] {1, 3, 0, 2},     // Rule 5
            new int[] {2, 3, 0, 1},     // Rule 6
            new int[] {3, 1, 2, 0},     // Rule 7
            new int[] {3, 2, 1, 0},     // Rule 8
        };
        public static readonly int[][] DnaRulesInv;

        static CryptoCore()
        {
            DnaRulesInv = new int[9][];
            for (int r = 1; r <= 8; r++)
            {
                var inv = new int[4];
                for (int v = 0; v < 4; v++) inv[DnaRules[r][v]] = v;
                DnaRulesInv[r] = inv;
            }
        }

        private static void ByteToChunks(byte b, int[] chunks)
        {
            chunks[0] = (b >> 6) & 3;
            chunks[1] = (b >> 4) & 3;
            chunks[2] = (b >> 2) & 3;
            chunks[3] = b & 3;
        }

        private static byte ChunksToByte(int[] c)
        {
            return (byte)((c[0] << 6) | (c[1] << 4) | (c[2] << 2) | c[3]);
        }

        // FIXED, NONLINEAR 256-ENTRY S-BOX (do not remove or "simplify away").
        //
        // Background: the original outline's Step 5 ("DNA-XOR then
        // Logistic-XOR then CBC-like chain") was implemented literally and
        // tested. Three compounding bugs were found and fixed, in order:
        //   1) chaining AFTER the keyed step instead of before collapses
        //      UACI to ~0.4% even though NPCR looks fine (~100%);
        //   2) XOR cannot carry information between a byte's four 2-bit
        //      DNA chunks, so even after fixing (1), UACI stayed ~0.4% --
        //      fixed by using modular addition (mod 256) instead of XOR at
        //      the chaining/keystream combination points;
        //   3) modular addition of exactly 128 (a bit-7/MSB difference) is
        //      mathematically IDENTICAL to XOR of 128 for every byte value
        //      (128 is exactly half of 256, so it never carries into other
        //      bits) -- this alone collapsed NPCR to ~7% for some pixel
        //      positions even after fix (2). A linear bit-permutation was
        //      tried first and did NOT fix it (still linear: a 1-bit
        //      difference stays a 1-bit difference, just relocated).
        // This S-box (fixed seed, verified to flip ~4.08 of 8 output bits
        // on average per single input-bit change; ideal = 4.0) is the fix
        // that actually worked. Validated result after all three fixes:
        // NPCR mean 99.61% (min 99.55%), UACI mean 33.52%.
        private static readonly byte[] SBox = new byte[]
        {
            119,37,205,191,145,16,176,33,25,150,183,143,112,95,210,90,117,189,219,138,
            153,94,5,174,123,35,175,15,166,193,89,49,27,164,225,11,132,154,200,221,
            163,68,226,26,73,159,134,169,222,242,39,152,64,129,104,52,32,201,216,184,
            249,77,71,1,252,170,111,67,13,44,202,194,36,246,229,42,137,173,212,100,
            213,38,130,147,253,245,122,14,255,113,99,78,192,34,18,190,106,127,19,51,
            12,93,172,74,180,79,178,72,244,241,207,181,185,124,107,28,8,75,46,70,
            139,206,141,151,114,218,239,208,248,56,54,9,182,198,98,20,131,196,84,53,
            121,41,40,224,215,6,142,187,236,91,21,228,144,188,110,199,160,97,168,2,
            146,88,60,140,66,240,220,250,136,211,165,4,30,83,82,57,232,128,125,85,
            59,223,204,158,102,247,156,101,195,135,96,120,126,209,10,43,230,81,197,
            214,148,167,45,69,58,65,234,251,103,86,155,105,7,243,24,29,62,31,92,
            109,118,116,149,171,177,237,203,161,76,61,48,80,17,115,3,87,235,108,47,
            162,0,55,233,227,217,254,22,23,133,231,186,63,238,50,157,179
        };
        private static readonly byte[] SBoxInv = BuildInverse(SBox);

        private static byte[] BuildInverse(byte[] sbox)
        {
            var inv = new byte[256];
            for (int v = 0; v < 256; v++) inv[sbox[v]] = (byte)v;
            return inv;
        }

        // DNA-encode(rule) -> DNA-XOR(fixed Rule 1, self-inverse) ->
        // DNA-decode(rule), wrapped in the S-box / inverse S-box.
        private static byte DnaXorStep(byte value, int rule, byte keyByte)
        {
            byte scrambled = SBox[value];
            var chunks = new int[4];
            var keyChunks = new int[4];
            ByteToChunks(scrambled, chunks);
            ByteToChunks(keyByte, keyChunks);

            var ruleMap = DnaRules[rule];
            var rule1Map = DnaRules[1];

            var dIds = new int[4];
            for (int k = 0; k < 4; k++)
            {
                int bId = ruleMap[chunks[k]];
                int kId = rule1Map[keyChunks[k]];
                dIds[k] = bId ^ kId; // self-inverse DNA XOR
            }

            var invRuleMap = DnaRulesInv[rule];
            var outChunks = new int[4];
            for (int k = 0; k < 4; k++) outChunks[k] = invRuleMap[dIds[k]];
            byte decoded = ChunksToByte(outChunks);

            return SBoxInv[decoded];
        }

        // ---- 5. One bidirectional (forward+backward) diffusion round ---
        // A single forward-only pass only propagates a plaintext change to
        // pixels AFTER it in scan order (measured NPCR as low as ~5% for
        // changes late in the scan). Running forward then backward lets a
        // change anywhere reach the whole image. rounds=2 by design
        // (not exposed in the UI -- changing it requires editing this file).
        private static byte[] OneRound(byte[] arrIn, KeyMaterial km)
        {
            int n = arrIn.Length;
            var stage1 = new byte[n];
            int prev = km.Iv;
            for (int i = 0; i < n; i++)
            {
                int chained = (arrIn[i] + prev) % 256;
                byte inter = DnaXorStep((byte)chained, km.RuleSeq[i], km.KeyMatrix[i]);
                stage1[i] = (byte)((inter + km.LmKeystream[i]) % 256);
                prev = stage1[i];
            }

            var outArr = new byte[n];
            prev = km.Iv2;
            for (int i = n - 1; i >= 0; i--)
            {
                int chained = (stage1[i] + prev) % 256;
                byte inter = DnaXorStep((byte)chained, km.RuleSeq[i], km.KeyMatrix[i]);
                outArr[i] = (byte)((inter + km.LmKeystream[i]) % 256);
                prev = outArr[i];
            }
            return outArr;
        }

        private static byte[] OneRoundInverse(byte[] arrIn, KeyMaterial km)
        {
            int n = arrIn.Length;
            var stage1 = new byte[n];
            int prev = km.Iv2;
            for (int i = n - 1; i >= 0; i--)
            {
                int inter = Mod(arrIn[i] - km.LmKeystream[i], 256);
                byte chained = DnaXorStep((byte)inter, km.RuleSeq[i], km.KeyMatrix[i]);
                stage1[i] = (byte)Mod(chained - prev, 256);
                prev = arrIn[i];
            }

            var outArr = new byte[n];
            prev = km.Iv;
            for (int i = 0; i < n; i++)
            {
                int inter = Mod(stage1[i] - km.LmKeystream[i], 256);
                byte chained = DnaXorStep((byte)inter, km.RuleSeq[i], km.KeyMatrix[i]);
                outArr[i] = (byte)Mod(chained - prev, 256);
                prev = stage1[i];
            }
            return outArr;
        }

        // ---- 6. Full pipeline -------------------------------------------
        public class SecretKey
        {
            public double X0, Y0, Z0, W0;
            public int P, Q, NIter;
            public double Lambda;
            public int Rounds = 2;
        }

        public static byte[,] Encrypt(byte[,] img, SecretKey key)
        {
            int N = img.GetLength(0);
            int nPixels = N * N;
            var km = DeriveKeys(key.X0, key.Y0, key.Z0, key.W0, nPixels, key.Lambda);

            byte[,] permuted2D = AcmPermute(img, key.P, key.Q, key.NIter, inverse: false);
            byte[] arr = Flatten(permuted2D);

            for (int r = 0; r < key.Rounds; r++)
                arr = OneRound(arr, km);

            return Unflatten(arr, N);
        }

        public static byte[,] Decrypt(byte[,] cipherImg, SecretKey key)
        {
            int N = cipherImg.GetLength(0);
            int nPixels = N * N;
            var km = DeriveKeys(key.X0, key.Y0, key.Z0, key.W0, nPixels, key.Lambda);

            byte[] arr = Flatten(cipherImg);
            for (int r = 0; r < key.Rounds; r++)
                arr = OneRoundInverse(arr, km);

            byte[,] permuted2D = Unflatten(arr, N);
            return AcmPermute(permuted2D, key.P, key.Q, key.NIter, inverse: true);
        }

        private static byte[] Flatten(byte[,] img)
        {
            int N = img.GetLength(0);
            var arr = new byte[N * N];
            for (int y = 0; y < N; y++)
                for (int x = 0; x < N; x++)
                    arr[y * N + x] = img[y, x];
            return arr;
        }

        private static byte[,] Unflatten(byte[] arr, int N)
        {
            var img = new byte[N, N];
            for (int y = 0; y < N; y++)
                for (int x = 0; x < N; x++)
                    img[y, x] = arr[y * N + x];
            return img;
        }

        // ---- 7. Security metrics (used by Analysis) ---------------------
        public static double Entropy(byte[,] img)
        {
            var hist = Histogram(img);
            double total = img.GetLength(0) * (double)img.GetLength(0);
            double h = 0;
            for (int i = 0; i < 256; i++)
            {
                if (hist[i] == 0) continue;
                double pr = hist[i] / total;
                h -= pr * Math.Log(pr, 2);
            }
            return h;
        }

        public static long[] Histogram(byte[,] img)
        {
            var hist = new long[256];
            foreach (var v in img) hist[v]++;
            return hist;
        }

        public static double Npcr(byte[,] a, byte[,] b)
        {
            int N = a.GetLength(0);
            int diff = 0;
            for (int y = 0; y < N; y++)
                for (int x = 0; x < N; x++)
                    if (a[y, x] != b[y, x]) diff++;
            return diff / (double)(N * N) * 100.0;
        }

        public static double Uaci(byte[,] a, byte[,] b)
        {
            int N = a.GetLength(0);
            double sum = 0;
            for (int y = 0; y < N; y++)
                for (int x = 0; x < N; x++)
                    sum += Math.Abs(a[y, x] - (double)b[y, x]);
            return sum / (255.0 * N * N) * 100.0;
        }

        public static void CorrelationCoefficients(byte[,] img, out double h, out double v, out double d)
        {
            int N = img.GetLength(0);
            h = PearsonAdjacent(img, N, 0, 1);
            v = PearsonAdjacent(img, N, 1, 0);
            d = PearsonAdjacent(img, N, 1, 1);
        }

        private static double PearsonAdjacent(byte[,] img, int N, int dy, int dx)
        {
            var listA = new List<double>();
            var listB = new List<double>();
            for (int y = 0; y < N - dy; y++)
                for (int x = 0; x < N - dx; x++)
                {
                    listA.Add(img[y, x]);
                    listB.Add(img[y + dy, x + dx]);
                }
            double meanA = Mean(listA), meanB = Mean(listB);
            double cov = 0, varA = 0, varB = 0;
            for (int i = 0; i < listA.Count; i++)
            {
                double da = listA[i] - meanA, db = listB[i] - meanB;
                cov += da * db; varA += da * da; varB += db * db;
            }
            return cov / Math.Sqrt(varA * varB);
        }

        private static double Mean(List<double> v)
        {
            double s = 0; foreach (var x in v) s += x; return s / v.Count;
        }

        public static double Mse(byte[,] a, byte[,] b)
        {
            int N = a.GetLength(0);
            double sum = 0;
            for (int y = 0; y < N; y++)
                for (int x = 0; x < N; x++)
                {
                    double diff = a[y, x] - (double)b[y, x];
                    sum += diff * diff;
                }
            return sum / (N * N);
        }
    }
}
