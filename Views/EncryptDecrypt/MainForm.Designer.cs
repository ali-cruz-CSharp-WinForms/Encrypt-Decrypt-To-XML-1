
namespace Encrypt_Decrypt_XML_WinForms01.Views.EncryptDecrypt
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.LblNameXmlGenerated = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnGeneraXml = new System.Windows.Forms.Button();
            this.TxbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnOpenXmlFile = new System.Windows.Forms.Button();
            this.TxbPathXmlSelected = new System.Windows.Forms.TextBox();
            this.BtnDesencriptar = new System.Windows.Forms.Button();
            this.BtnEncriptar = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblPasswordInXml = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1142, 533);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.webBrowser1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.treeView1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(43, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1056, 487);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 2);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1050, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Encripta y Desencripta Informacion (XML)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblNameXmlGenerated
            // 
            this.LblNameXmlGenerated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblNameXmlGenerated.AutoSize = true;
            this.LblNameXmlGenerated.Location = new System.Drawing.Point(132, 98);
            this.LblNameXmlGenerated.Name = "LblNameXmlGenerated";
            this.LblNameXmlGenerated.Size = new System.Drawing.Size(16, 13);
            this.LblNameXmlGenerated.TabIndex = 10;
            this.LblNameXmlGenerated.Text = "...";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "XML";
            // 
            // BtnGeneraXml
            // 
            this.BtnGeneraXml.Location = new System.Drawing.Point(394, 109);
            this.BtnGeneraXml.Name = "BtnGeneraXml";
            this.BtnGeneraXml.Size = new System.Drawing.Size(113, 36);
            this.BtnGeneraXml.TabIndex = 8;
            this.BtnGeneraXml.Text = "Genera XML";
            this.BtnGeneraXml.UseVisualStyleBackColor = true;
            this.BtnGeneraXml.Click += new System.EventHandler(this.BtnGeneraXml_Click);
            // 
            // TxbPassword
            // 
            this.TxbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxbPassword.Location = new System.Drawing.Point(133, 57);
            this.TxbPassword.Name = "TxbPassword";
            this.TxbPassword.Size = new System.Drawing.Size(374, 20);
            this.TxbPassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contraseña Server";
            // 
            // BtnOpenXmlFile
            // 
            this.BtnOpenXmlFile.Location = new System.Drawing.Point(29, 38);
            this.BtnOpenXmlFile.Name = "BtnOpenXmlFile";
            this.BtnOpenXmlFile.Size = new System.Drawing.Size(113, 36);
            this.BtnOpenXmlFile.TabIndex = 5;
            this.BtnOpenXmlFile.Text = "Abrir XML";
            this.BtnOpenXmlFile.UseVisualStyleBackColor = true;
            this.BtnOpenXmlFile.Click += new System.EventHandler(this.BtnOpenXmlFile_Click);
            // 
            // TxbPathXmlSelected
            // 
            this.TxbPathXmlSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxbPathXmlSelected.Enabled = false;
            this.TxbPathXmlSelected.Location = new System.Drawing.Point(156, 46);
            this.TxbPathXmlSelected.Name = "TxbPathXmlSelected";
            this.TxbPathXmlSelected.Size = new System.Drawing.Size(353, 20);
            this.TxbPathXmlSelected.TabIndex = 4;
            // 
            // BtnDesencriptar
            // 
            this.BtnDesencriptar.Location = new System.Drawing.Point(158, 110);
            this.BtnDesencriptar.Name = "BtnDesencriptar";
            this.BtnDesencriptar.Size = new System.Drawing.Size(113, 36);
            this.BtnDesencriptar.TabIndex = 0;
            this.BtnDesencriptar.Text = "Desencriptar";
            this.BtnDesencriptar.UseVisualStyleBackColor = true;
            this.BtnDesencriptar.Click += new System.EventHandler(this.BtnDesencriptar_Click);
            // 
            // BtnEncriptar
            // 
            this.BtnEncriptar.Location = new System.Drawing.Point(397, 110);
            this.BtnEncriptar.Name = "BtnEncriptar";
            this.BtnEncriptar.Size = new System.Drawing.Size(113, 36);
            this.BtnEncriptar.TabIndex = 1;
            this.BtnEncriptar.Text = "Encriptar";
            this.BtnEncriptar.UseVisualStyleBackColor = true;
            this.BtnEncriptar.Click += new System.EventHandler(this.BtnEncriptar_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(3, 203);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(522, 281);
            this.treeView1.TabIndex = 0;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(531, 203);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(522, 281);
            this.webBrowser1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BtnGeneraXml);
            this.groupBox1.Controls.Add(this.LblNameXmlGenerated);
            this.groupBox1.Controls.Add(this.TxbPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 158);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crear XML";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.LblPasswordInXml);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.BtnDesencriptar);
            this.groupBox2.Controls.Add(this.TxbPathXmlSelected);
            this.groupBox2.Controls.Add(this.BtnEncriptar);
            this.groupBox2.Controls.Add(this.BtnOpenXmlFile);
            this.groupBox2.Location = new System.Drawing.Point(531, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 158);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Abrir XML";
            // 
            // LblPasswordInXml
            // 
            this.LblPasswordInXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblPasswordInXml.AutoSize = true;
            this.LblPasswordInXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPasswordInXml.Location = new System.Drawing.Point(305, 75);
            this.LblPasswordInXml.Name = "LblPasswordInXml";
            this.LblPasswordInXml.Size = new System.Drawing.Size(0, 13);
            this.LblPasswordInXml.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Password encontrado en Xml:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 542);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Encrypt Decrypt XML File";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxbPassword;
        private System.Windows.Forms.Button BtnEncriptar;
        private System.Windows.Forms.Button BtnDesencriptar;
        private System.Windows.Forms.TextBox TxbPathXmlSelected;
        private System.Windows.Forms.Button BtnOpenXmlFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnGeneraXml;
        private System.Windows.Forms.Label LblNameXmlGenerated;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LblPasswordInXml;
        private System.Windows.Forms.Label label5;
    }
}