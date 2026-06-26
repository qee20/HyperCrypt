using HyperCrypt.Models;
using System.Globalization;

public static class KeyOrTextHelperProcessingService
{
    public static bool TryParseDouble(string text, string fieldName, out double value, out string error)
    {
        error = null;
        if (!double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
        {
            error = $"Nilai '{fieldName}' tidak valid: '{text}'. Gunakan titik (.) sebagai pemisah desimal, contoh: 0.1";
            return false;
        }
        return true;
    }

    public static bool TryParseInt(string text, string fieldName, out int value, out string error)
    {
        error = null;
        if (!int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out value))
        {
            error = $"Nilai '{fieldName}' tidak valid: '{text}'. Harus berupa bilangan bulat.";
            return false;
        }
        return true;
    }
}
