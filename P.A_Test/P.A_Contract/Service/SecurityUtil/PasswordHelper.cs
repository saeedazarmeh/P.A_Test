
using System;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace P.A_Contract.Service.SecurityUtil;
public static class PasswordHelper
{
    public static string EncodePasswordMd5(string pass) //Encrypt using MD5   
    {
        using (var md5 = new MD5CryptoServiceProvider())
        {
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
                string key = "za\a0306\a01FD\a03B2\aD8FF\aDCFF";
                tdes.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                using (var transform = tdes.CreateEncryptor())
                {
                    byte[] textBytes = Encoding.UTF8.GetBytes(pass);
                    byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                    return Convert.ToBase64String(bytes, 0, bytes.Length);
                }
            }
        }
    }
    public static string DecodePasswordMd5(string hashedPass)
    {
        using (var md5 = new MD5CryptoServiceProvider())
        {
            using (var tdes = new TripleDESCryptoServiceProvider())
            {
                string key = "za\a0306\a01FD\a03B2\aD8FF\aDCFF";
                tdes.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                using (var transform = tdes.CreateDecryptor())
                {
                    byte[] cipherBytes = Convert.FromBase64String(hashedPass);
                    byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                    return Encoding.UTF8.GetString(bytes);
                }
            }
        }
    }
}