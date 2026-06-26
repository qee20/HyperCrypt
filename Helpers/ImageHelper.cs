using System.Drawing.Imaging;

public static class ImageProcessingService
{
    public static byte[,] LoadAsSquareGrayscale(Bitmap src)
    {
        int side = Math.Min(src.Width, src.Height);
        int offX = (src.Width - side) / 2;
        int offY = (src.Height - side) / 2;

        var result = new byte[side, side];
        for (int y = 0; y < side; y++)
            for (int x = 0; x < side; x++)
            {
                Color c = src.GetPixel(offX + x, offY + y);
                byte gray = (byte)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B); // standard luma
                result[y, x] = gray;
            }
        return result;
    }

    public static Bitmap ByteArrayToBitmap(byte[,] img)
    {
        int N = img.GetLength(0);
        var bmp = new Bitmap(N, N, PixelFormat.Format24bppRgb);
        for (int y = 0; y < N; y++)
            for (int x = 0; x < N; x++)
            {
                byte v = img[y, x];
                bmp.SetPixel(x, y, Color.FromArgb(v, v, v));
            }
        return bmp;
    }

    public static void DrawHistogram(Graphics g, Size size, long[] hist)
    {
        g.Clear(Color.White);
        if (hist == null) return;

        long max = 1;
        foreach (var v in hist) if (v > max) max = v;

        float barW = size.Width / 256f;
        using (var pen = new Pen(Color.FromArgb(30, 30, 110)))
        {
            for (int i = 0; i < 256; i++)
            {
                float barH = (float)(hist[i] / (double)max * (size.Height - 4));
                g.DrawLine(pen, i * barW, size.Height, i * barW, size.Height - barH);
            }
        }
    }
}