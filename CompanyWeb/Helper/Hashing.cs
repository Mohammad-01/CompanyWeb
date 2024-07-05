using System;
using System.Security.Cryptography;
using System.Text;

namespace CompanyWeb.Helper
{
    public class Hashing
    {
        public static string GenerateHash(string plainText)
        {
            byte[] encodedParameters = Encoding.UTF8.GetBytes(plainText);
            SHA256Managed sHA256 = new SHA256Managed();
            byte[] hashedArr = sHA256.ComputeHash(encodedParameters);
            string hashedText = "";
            foreach (byte hashedByte in hashedArr)
            {
                hashedText += string.Format("{0:x2}", hashedByte);
            }
            return hashedText;
        }
    }
}