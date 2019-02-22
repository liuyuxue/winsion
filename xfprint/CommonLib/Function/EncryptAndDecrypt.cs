using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Function
{
    public class EncryptAndDecrypt
    {
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(pToEncrypt);
            dESCryptoServiceProvider.Key = Encoding.UTF8.GetBytes(sKey.Substring(0, 8));
            dESCryptoServiceProvider.IV = Encoding.UTF8.GetBytes(sKey.Substring(0, 8));
            MemoryStream memoryStream = new System.IO.MemoryStream();
            CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array = memoryStream.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                byte b = array[i];
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            stringBuilder.ToString();
            return stringBuilder.ToString();
        }

        public static string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] array = new byte[pToDecrypt.Length / 2];
            checked
            {
                for (int i = 0; i < pToDecrypt.Length / 2; i++)
                {
                    int num = Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 16);
                    array[i] = (byte)num;
                }
                dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey.Substring(0, 8));
                dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey.Substring(0, 8));
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                cryptoStream.Write(array, 0, array.Length);
                cryptoStream.FlushFinalBlock();
                StringBuilder stringBuilder = new StringBuilder();
                return Encoding.Default.GetString(memoryStream.ToArray());
            }
        }
    }
}
