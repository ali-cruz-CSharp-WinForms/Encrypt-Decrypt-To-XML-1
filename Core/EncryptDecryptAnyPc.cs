using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Decrypt_XML_WinForms01.Core
{
    public class EncryptDecryptAnyPc
    {
        // A

        private const string EncryptionKey = "Pass";

        public static byte[] EncryptData(byte[] data, byte[] salt)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey);
            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.Mode = CipherMode.CBC;

                // Use el salt (IV) proporcionado como parámetro
                aes.IV = salt;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(data, 0, data.Length);
                        cryptoStream.FlushFinalBlock();
                        return memoryStream.ToArray();
                    }
                }
            }
        }


        public static byte[] DecryptData(byte[] encryptedData, byte[] salt)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey);
            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.Mode = CipherMode.CBC;

                // Use el salt (IV) proporcionado como parámetro
                aes.IV = salt;

                using (MemoryStream memoryStream = new MemoryStream(encryptedData))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (MemoryStream decryptedMemoryStream = new MemoryStream())
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead;
                            while ((bytesRead = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                decryptedMemoryStream.Write(buffer, 0, bytesRead);
                            }
                            return decryptedMemoryStream.ToArray();
                        }
                    }
                }
            }
        }







        //private const int KeySize = 256;
        //private const int BlockSize = 128;
        //private const string EncryptionKey = "password";

        //public static string EncryptHash(string hash)
        //{
        //    byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey);
        //    byte[] hashBytes = Encoding.UTF8.GetBytes(hash);

        //    using (Aes aes = Aes.Create())
        //    {
        //        aes.KeySize = KeySize;
        //        aes.BlockSize = BlockSize;
        //        aes.Mode = CipherMode.CFB;
        //        aes.Padding = PaddingMode.PKCS7;
        //        aes.Key = keyBytes;

        //        using (MemoryStream memoryStream = new MemoryStream())
        //        {
        //            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                cryptoStream.Write(hashBytes, 0, hashBytes.Length);
        //                cryptoStream.FlushFinalBlock();
        //                byte[] encryptedBytes = memoryStream.ToArray();
        //                return Convert.ToBase64String(encryptedBytes);
        //            }
        //        }
        //    }
        //}

        //public static string DecryptHash(string encryptedHash)
        //{
        //    byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey);
        //    byte[] encryptedBytes = Convert.FromBase64String(encryptedHash);

        //    using (Aes aes = Aes.Create())
        //    {
        //        aes.KeySize = KeySize;
        //        aes.BlockSize = BlockSize;
        //        aes.Mode = CipherMode.CFB;
        //        aes.Padding = PaddingMode.PKCS7;
        //        aes.Key = keyBytes;

        //        using (MemoryStream memoryStream = new MemoryStream(encryptedBytes))
        //        {
        //            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
        //            {
        //                byte[] decryptedBytes = new byte[encryptedBytes.Length];
        //                int decryptedByteCount = cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
        //                return Encoding.UTF8.GetString(decryptedBytes, 0, decryptedByteCount);
        //            }
        //        }
        //    }
        //}


    }
}
