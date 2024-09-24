using System.Security.Cryptography;
using System.Text;

namespace P.A_Contract.Service.SecurityUtil;

/// <summary>
/// These methods are using for Hashing data Like Password
/// </summary>
public class Sha256Hasher
{
    public static string Hash(string inputValue)
    {
        using var sha256 = SHA256.Create();
        var originalBytes = Encoding.Default.GetBytes(inputValue);
        var encodedBytes = sha256.ComputeHash(originalBytes);
        return Convert.ToBase64String(encodedBytes);
    }
    public static bool IsCompare(string hashText, string rawText)
    {
        rawText = PasswordHelper.EncodePasswordMd5(rawText);
        return hashText == rawText;
    }
}