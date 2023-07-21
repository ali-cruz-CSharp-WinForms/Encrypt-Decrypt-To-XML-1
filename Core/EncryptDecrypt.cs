using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Encrypt_Decrypt_XML_WinForms01.Core
{
    class EncryptDecrypt
    {
        public string EncryptString(string decryptedDataString, string key)
        {
            // Encrypt sensitive data            
            byte[] encryptedData = ProtectedData.Protect(Encoding.Unicode.GetBytes(decryptedDataString),
                Encoding.Unicode.GetBytes(key), DataProtectionScope.LocalMachine);
            string encryptedDataString = Convert.ToBase64String(encryptedData);

            return encryptedDataString;
        }

        // Decrypt string file
        public string DecryptString(string encryptedDataString, string key)
        {
            if (!IsBase64String(encryptedDataString))
            {
                MessageBox.Show("No es base 64");
                return encryptedDataString;
            }

            byte[] encryptedData = Convert.FromBase64String(encryptedDataString);
            byte[] decryptedData = ProtectedData.Unprotect(encryptedData,
                Encoding.Unicode.GetBytes(key), DataProtectionScope.LocalMachine);
            string decryptedDataString = Encoding.Unicode.GetString(decryptedData);

            return decryptedDataString;
        }


        // Check if is base64
        private bool IsBase64String(string str)
        {
            try
            {
                //byte[] data = Convert.From
                Convert.FromBase64String(str);
                return true;
            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return false;
            }
        }


    }
}
