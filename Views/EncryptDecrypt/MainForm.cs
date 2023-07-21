using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnOpenXmlFile_Click(object sender, EventArgs e)
        {
            pathFile = ReturnPathOfXmlSelected();

            if (pathFile != null && CheckIfFileExist(pathFile) && CheckIfFileCanOpen(pathFile))
            {
                TxbPathXmlSelected.Text = pathFile;
                string passwordValue = GetPasswordValueFromXml(pathFile);
                LblPasswordInXml.Text = passwordValue;
                FillTreeView(pathFile);
                FillWebBrowser(pathFile);
            }
            else
            {
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
            }
            else
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

        // Retorna el path del xml seleccionado
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
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        // Pinta tree view
        private void FillWebBrowser(string pathXml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathXml);

            webBrowser1.DocumentText = xmlDoc.OuterXml;
        }

        // Se capturo Password en el TextBox?
        private bool CheckIfPasswordIsSet()
        {
            if (TxbPassword.Text.Trim() == string.Empty)
            {
                return false;
            }
            else
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
                    }
                    else if (xmlNode.NodeType == XmlNodeType.Text)
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
            Core.EncryptDecrypt encryptDecrypt = new Core.EncryptDecrypt();            

            string dataSaltPlain = GetSaltValueFromXml(pathFile);
            string dataPasswordEncrypted = encryptDecrypt.EncryptString(GetPasswordValueFromXml(pathFile), dataSaltPlain);
            bool isSavedPass = SavePasswordValueOnXml(pathFile, dataPasswordEncrypted);
            bool isSavedSalt = SaveSaltValueOnXml(pathFile, dataSaltPlain);

            // Get value of password node and encrypt
            LblPasswordInXml.Text = dataPasswordEncrypted;

            if (isSavedPass && isSavedSalt)
            {
                MessageBox.Show("Encriptado y guardado correctamente.", "Encriptado correctamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //BtnEncriptar.Enabled = false;
                //BtnDesencriptar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error al intentar encriptar la cadena recibida. No se guardó.", "No Encriptado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //BtnEncriptar.Enabled = true;
            }

            FillTreeView(pathFile);
            FillWebBrowser(pathFile);
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

        private void BtnGeneraXml_Click_1(object sender, EventArgs e)
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

                    TxbPathXmlSelected.Text = string.Empty;
                    LblPasswordInXml.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Error al intentar guardar el archivo XML.", "No se pudo generar XML",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Falta que especifique una contraseña.", "Error de validación.",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LblNameXmlGenerated.Text = string.Empty;
            }

        }

        private void BtnDesencriptar_Click_1(object sender, EventArgs e)
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

            if (SavePasswordValueOnXml(pathFile, decriptedData))
            {
                LblPasswordInXml.Text = decriptedData;
                MessageBox.Show("Desencriptado y guardado correctamente.", "Desencriptado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al intentar desencriptar la cadena recibida.", "No desencriptado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            FillTreeView(pathFile);
            FillWebBrowser(pathFile);
        }

        private void BtnEncriptar2_Click(object sender, EventArgs e)
        {
            var res = EncryptDecryptAnyPc.GenerateHash("Pr*gr4m4r");
            var res2 = EncryptDecryptAnyPc.GenerateHash("Pr*gr4m4r", "MDRTlknw9sfm1gyHV4GtWA==", "MDRTlknw9sfm1gyHV4GtWAdjlDYbt1DNdfdo8toeiqDoFyv2i+2RB6r1BLCWA+ad");
        }
    }
}
