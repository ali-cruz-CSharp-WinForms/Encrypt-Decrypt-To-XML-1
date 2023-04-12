using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Encrypt_Decrypt_XML_WinForms01.Core
{
    class EncryptDecrypt
    {
        // Encrypt configuration file
        //public void EncryptConfigFile(string configFilePath, string key)
        //{
        //    // Load configuration file
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(configFilePath);

        //    // Encrypt sensitive data
        //    string sensitiveData = doc.SelectSingleNode("//Server").InnerText;
        //    //XmlNode node = doc.SelectSingleNode("/Configuration/Server[@name='server']");
        //    byte[] encryptedData = ProtectedData.Protect(Encoding.Unicode.GetBytes(sensitiveData),
        //        Encoding.Unicode.GetBytes(key), DataProtectionScope.CurrentUser);
        //    string encryptedDataString = Convert.ToBase64String(encryptedData);
        //    doc.SelectSingleNode("//Server").InnerText = encryptedDataString;
        //    //doc.SelectSingleNode("/Configuration/Server[@name='server']").InnerText = encryptedDataString;

        //    // Save encrypted configuration file
        //    doc.Save(configFilePath);
        //}

        //// Decrypt configuration file
        //public string DecryptConfigFile(string configFilePath, string key)
        //{
        //    // Load encrypted configuration file
        //    XmlDocument doc = new XmlDocument();

        //    try
        //    {
        //        doc.Load(configFilePath);

        //        //XmlNode node = doc.SelectSingleNode("/Configuration/Server[@name='server']");

        //        // Decrypt sensitive data
        //        string encryptedDataString = doc.SelectSingleNode("//Server").InnerText;

        //        //var a = node.InnerText;
        //        //Console.WriteLine($"\na: {a}\n");

        //        byte[] encryptedData = Convert.FromBase64String(encryptedDataString);
        //        byte[] decryptedData = ProtectedData.Unprotect(encryptedData,
        //            Encoding.Unicode.GetBytes(key), DataProtectionScope.CurrentUser);
        //        string decryptedDataString = Encoding.Unicode.GetString(decryptedData);
        //        doc.SelectSingleNode("//Server").InnerText = decryptedDataString;

        //        // Save decrypted configuration file
        //        doc.Save(configFilePath);

        //        return decryptedDataString;
        //    } catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        public string EncryptString(string decryptedDataString, string key)
        {
            // Encrypt sensitive data            
            byte[] encryptedData = ProtectedData.Protect(Encoding.Unicode.GetBytes(decryptedDataString),
                Encoding.Unicode.GetBytes(key), DataProtectionScope.CurrentUser);
            string encryptedDataString = Convert.ToBase64String(encryptedData);

            return encryptedDataString;
        }

        // Decrypt string file
        public string DecryptString(string encryptedDataString, string key)
        {
            byte[] encryptedData = Convert.FromBase64String(encryptedDataString);
            byte[] decryptedData = ProtectedData.Unprotect(encryptedData,
                Encoding.Unicode.GetBytes(key), DataProtectionScope.CurrentUser);
            string decryptedDataString = Encoding.Unicode.GetString(decryptedData);

            return decryptedDataString;
        }

    }
}
