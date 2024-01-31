using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Helper
{
    internal class Helperr
    {
        #region Encrypting And Decrypting
        public static string ConvertToMD5(string plainText)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        #endregion

        #region RandomStringGeneration
        public static string GenerateOTP()
        {
            Random random = new Random();

            int randomNumber = random.Next(100000, 1000000);
            return randomNumber.ToString();
        }
        #endregion

    }
}
