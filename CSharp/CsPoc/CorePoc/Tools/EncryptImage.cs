using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CorePoc.Tools
{
    public class EncryptImage
    {
        static string encryptKey = "Oyea";

        public static void Execute()
        {
            var sw = new Stopwatch();
            var source = FileToByte("I000004254.png");

            sw.Start();
            var encrypted = Encrypt(source);
            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds);

            ByteToFile(encrypted,"E000004254.png");

            var source2= FileToByte("E000004254.png");
            sw.Start();
            var decrypted = Decrypt(source2);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            ByteToFile(decrypted, "D000004254.png");
        }

        public static byte[] FileToByte(string fileUrl)
        {
            try
            {
                using (FileStream fs = new FileStream(fileUrl, FileMode.Open, FileAccess.Read))
                {
                    byte[] byteArray = new byte[fs.Length];
                    fs.Read(byteArray, 0, byteArray.Length);
                    return byteArray;
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool ByteToFile(byte[] byteArray, string fileName)
        {
            bool result = false;
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        static byte[] Encrypt(byte[] data)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();
            byte[] key = Encoding.Unicode.GetBytes(encryptKey);
            MemoryStream MStream = new MemoryStream();
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);
            CStream.FlushFinalBlock();
            return MStream.ToArray();
        }


        static byte[] Decrypt(byte[] data)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();
            byte[] key = Encoding.Unicode.GetBytes(encryptKey);
            MemoryStream MStream = new MemoryStream();
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);
            CStream.FlushFinalBlock();
            return MStream.ToArray();
        }


    }
}