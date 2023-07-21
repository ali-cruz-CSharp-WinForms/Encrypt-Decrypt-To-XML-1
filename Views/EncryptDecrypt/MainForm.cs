using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Encrypt_Decrypt_XML_WinForms01.Core;

namespace Encrypt_Decrypt_XML_WinForms01.Views.EncryptDecrypt
{
    public partial class MainForm : Form
    {
        private string pathFile = string.Empty;
        //private string pathFileToCreate = string.Empty;
        //private readonly string keyToEncry = "f4f56r412";


        public MainForm()
        {
            InitializeComponent();
            //BtnDesencriptar.Enabled = false;
            //BtnEncriptar.Enabled = false;
        }

        private void BtnOpenXmlFile_Click(object sender, EventArgs e)
        {
            pathFile = ReturnPathOfXmlSelected();

            if (pathFile != null && CheckIfFileExist(pathFile) && CheckIfFileCanOpen(pathFile))
            {   
                TxbPathXmlSelected.Text = pathFile;
                string passwordValue = GetPasswordValueFromXml(pathFile);
                LblPasswordInXml.Text = passwordValue;

                //if (IsPasswordValueEncrypted(passwordValue))
                //{
                //    BtnEncriptar.Enabled = false;
                //    BtnDesencriptar.Enabled = true;
                //} else
                //{
                //    BtnEncriptar.Enabled = true;
                //    BtnDesencriptar.Enabled = false;
                //}

                FillTreeView(pathFile);
                FillWebBrowser(pathFile);

            } else
            {
                //BtnDesencriptar.Enabled = false;
                //BtnEncriptar.Enabled = false;
                MessageBox.Show("El archivo seleccionado no existe o se encuentra protegido contra lectura.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsPasswordValueEncrypted(string dataToCheck)
        {
            if (IsReadable(dataToCheck))
            {
                // Not Encrypted
                return false;
            } else
            {
                // Encrypted
                return true;
            }
        }

        // Check if the string contains redeable text
        private bool IsReadable(string text)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[\x20-\x7E]+$");
            return regex.IsMatch(text);
        }

        private string ReturnPathOfXmlSelected()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Selecciona el archivo XML";
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return null;
        }

        private bool CheckIfFileExist(string pathFile)
        {
            if (File.Exists(pathFile))
            {
                return true;
            }
            else
            {                
                return false;
            }
        }


        private bool CheckIfFileCanOpen(string pathFile)
        {
            try
            {
                using (FileStream fileStream = File.OpenRead(pathFile))
                {
                    return true;
                }
            } catch (Exception ex)
            {
                return false;
            }
        }

        private void BtnDesencriptar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(pathFile))
            {
                MessageBox.Show("Seleccione un archivo XML a revisar");
                return;
            }

            Core.EncryptDecrypt encryptDecrypt = new Core.EncryptDecrypt();
            string valueOfPasswordOfXml = GetPasswordValueFromXml(pathFile);
            string valueOfSaltOfXml = GetSaltValueFromXml(pathFile);

            string decriptedData = encryptDecrypt.DecryptString(valueOfPasswordOfXml, valueOfSaltOfXml);
            LblPasswordInXml.Text = valueOfPasswordOfXml;

            if (SavePasswordValueOnXml(pathFile, decriptedData))
            {
                MessageBox.Show("Desencriptado y guardado correctamente.", "Desencriptado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //BtnDesencriptar.Enabled = false;
                //BtnEncriptar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error al intentar desencriptar la cadena recibida.", "No desencriptado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //BtnDesencriptar.Enabled = true;
                //BtnEncriptar.Enabled = false;
            }

            FillTreeView(pathFile);
            FillWebBrowser(pathFile);
        }

        private void BtnGeneraXml_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK && 
                CheckIfPasswordIsSet())
            {
                pathFile = saveFileDialog.FileName;

                if (CreateXmlDocument(pathFile))
                {
                    LblNameXmlGenerated.Text = pathFile;                    

                    FillTreeView(pathFile);
                    FillWebBrowser(pathFile);                    

                    MessageBox.Show("XML guardado correctamente.", "Guardado con exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //BtnDesencriptar.Enabled = false;
                    //BtnEncriptar.Enabled = false;
                    TxbPathXmlSelected.Text = string.Empty;
                    LblPasswordInXml.Text = string.Empty;
                } else
                {
                    MessageBox.Show("Error al intentar guardar el archivo XML.", "No se pudo generar XML",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }               
            } else
            {
                MessageBox.Show("Falta que especifique una contraseña.", "Error de validación.",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LblNameXmlGenerated.Text = string.Empty;
            }
        }

        private void FillWebBrowser(string pathXml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathXml);

            webBrowser1.DocumentText = xmlDoc.OuterXml;
        }

        private bool CheckIfPasswordIsSet()
        {
            if (TxbPassword.Text.Trim() == string.Empty)
            {
                return false;
            } else
            {
                return true;
            }
        }

        // Fill from a XML file.
        private void FillTreeView(string pathXml)
        {
            // Load xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathXml);

            // Clear the treeview
            treeView1.Nodes.Clear();

            // Add the root node to the treeview
            TreeNode rootNode = new TreeNode(xmlDoc.DocumentElement.Name);
            rootNode.Tag = xmlDoc.DocumentElement;
            treeView1.Nodes.Add(rootNode);

            // Add the child nodes to the treeview
            AddNodesToTreeView(xmlDoc.DocumentElement, rootNode);

            // Expand the treeview
            treeView1.ExpandAll();
        }

        // Iterate list nodes and put in treeview
        private void AddNodesToTreeView(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            // Add the child nodes to the treeview
            XmlNodeList nodeList = inXmlNode.ChildNodes;

            if (nodeList != null)
            {
                foreach (XmlNode xmlNode in nodeList)
                {
                    if (xmlNode.NodeType == XmlNodeType.Element)
                    {
                        TreeNode childNode = new TreeNode(xmlNode.Name);
                        childNode.Tag = xmlNode.InnerText;
                        inTreeNode.Nodes.Add(childNode);
                        AddNodesToTreeView(xmlNode, childNode);
                    } else if (xmlNode.NodeType == XmlNodeType.Text)
                    {
                        inTreeNode.Text += ": " + xmlNode.Value;
                    }
                }
            }
        }

        // Create the structure of xml file
        private bool CreateXmlDocument(string pathFile)
        {
            // Create a new Xml writer settings
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Encoding = Encoding.UTF8;
            xmlSettings.Indent = true;

            // Create a new xml writer object
            using (XmlWriter writerXml = XmlWriter.Create(pathFile, xmlSettings))
            {
                // Write the xml declaration
                writerXml.WriteStartDocument();

                // write root elements
                writerXml.WriteStartElement("Confuguration");                

                // Write first child element
                writerXml.WriteStartElement("Server");

                // Write first sub child element
                writerXml.WriteStartElement("Salt");
                writerXml.WriteString(TxbSalt.Text.Trim());
                writerXml.WriteEndElement();

                // write second sub child element
                writerXml.WriteStartElement("Password");
                writerXml.WriteString(TxbPassword.Text.Trim());
                writerXml.WriteEndElement();

                // write end "Server" node element
                writerXml.WriteEndElement();

                // Write end root "Configuration" element
                writerXml.WriteEndElement();

                // End xml Document
                writerXml.WriteEndDocument();

                return true;
            }
        }

        // Encrypt string from xml and save the new encrypted string on xml file.
        private void BtnEncriptar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(pathFile))
            {
                MessageBox.Show("Seleccione primeramente un archivo xml");
                return;
            }            

            // Get value of password node and encrypt            
            byte[] dataBytesPass = Encoding.UTF8.GetBytes(GetPasswordValueFromXml(pathFile));
            LblPasswordInXml.Text = GetPasswordValueFromXml(pathFile);

            // Salt random
            byte[] salt = GenerateRandomIV();
            byte[] encryptedPassData = EncryptDecryptAnyPc.EncryptData(dataBytesPass, salt);

            byte[] decryptedPassData = EncryptDecryptAnyPc.EncryptData(encryptedPassData, salt);
            string decryptedPassDataS = Encoding.UTF8.GetString(decryptedPassData);
            string saltS = Encoding.UTF8.GetString(salt);

            bool isSavedPass = SavePasswordValueOnXml(pathFile, decryptedPassDataS);
            bool isSavedSalt = SaveSaltValueOnXml(pathFile, saltS);            

            if (isSavedPass && isSavedSalt)
            {
                MessageBox.Show("Encriptado y guardado correctamente.", "Encriptado correctamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //BtnEncriptar.Enabled = false;
                //BtnDesencriptar.Enabled = true;
            } else
            {
                MessageBox.Show("Error al intentar encriptar la cadena recibida. No se guardó.", "No Encriptado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //BtnEncriptar.Enabled = true;
            }

            FillTreeView(pathFile);
            FillWebBrowser(pathFile);
        }

        // password

        public static string EncryptPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] salt = GenerateRandomIV();
            byte[] encryptedPassword = EncryptDecryptAnyPc.EncryptData(passwordBytes, salt);

            // Combina el salt y la contraseña encriptada para guardarlos juntos.
            byte[] combinedData = new byte[salt.Length + encryptedPassword.Length];
            Buffer.BlockCopy(salt, 0, combinedData, 0, salt.Length);
            Buffer.BlockCopy(encryptedPassword, 0, combinedData, salt.Length, encryptedPassword.Length);

            // Devuelve la contraseña encriptada y el salt combinados como un string en Base64.
            return Convert.ToBase64String(combinedData);
        }



        public static byte[] GenerateRandomIV()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateIV();
                return aes.IV;
            }
        }

        // Get value of Password node whether encrypted or decrypted
        private string GetPasswordValueFromXml(string pathXml)
        {
            // Load encrypted configuration file
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(pathXml);
                return xmlDoc.SelectSingleNode("//Password").InnerText;                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Get value of Salt node whether encrypted or decrypted
        private string GetSaltValueFromXml(string pathXml)
        {
            // Load encrypted configuration file
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(pathXml);
                return xmlDoc.SelectSingleNode("//Salt").InnerText;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Saves the received password whether encrypted or decrypted
        private bool SavePasswordValueOnXml(string pathXml, string passwordValue)
        {
            // xmlDoc to hold xml file
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(pathXml);
                doc.SelectSingleNode("//Password").InnerText = passwordValue;

                // Save decrypted configuration file
                doc.Save(pathXml);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        // Saves the salt whether encrypted or decrypted
        private bool SaveSaltValueOnXml(string pathXml, string saltValue)
        {
            // xmlDoc to hold xml file
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(pathXml);
                doc.SelectSingleNode("//Salt").InnerText = saltValue;

                // Save decrypted configuration file
                doc.Save(pathXml);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
