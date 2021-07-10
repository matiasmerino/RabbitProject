
namespace RabbitProject
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnEncriptar = new System.Windows.Forms.Button();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lblVector = new System.Windows.Forms.Label();
            this.txtVector = new System.Windows.Forms.TextBox();
            this.btnRandomKey = new System.Windows.Forms.Button();
            this.btnRandomV = new System.Windows.Forms.Button();
            this.btnDesencriptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Seleccionar";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // btnSelectFile
            // 
            resources.ApplyResources(this.btnSelectFile, "btnSelectFile");
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtFileName
            // 
            resources.ApplyResources(this.txtFileName, "txtFileName");
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            // 
            // btnEncriptar
            // 
            resources.ApplyResources(this.btnEncriptar, "btnEncriptar");
            this.btnEncriptar.Name = "btnEncriptar";
            this.btnEncriptar.Tag = "Encripted_";
            this.btnEncriptar.UseVisualStyleBackColor = true;
            this.btnEncriptar.Click += new System.EventHandler(this.btnEncriptarDesencriptar_Click);
            // 
            // lblKey
            // 
            resources.ApplyResources(this.lblKey, "lblKey");
            this.lblKey.Name = "lblKey";
            // 
            // txtKey
            // 
            resources.ApplyResources(this.txtKey, "txtKey");
            this.txtKey.Name = "txtKey";
            // 
            // lblVector
            // 
            resources.ApplyResources(this.lblVector, "lblVector");
            this.lblVector.Name = "lblVector";
            // 
            // txtVector
            // 
            resources.ApplyResources(this.txtVector, "txtVector");
            this.txtVector.Name = "txtVector";
            // 
            // btnRandomKey
            // 
            resources.ApplyResources(this.btnRandomKey, "btnRandomKey");
            this.btnRandomKey.Name = "btnRandomKey";
            this.btnRandomKey.UseVisualStyleBackColor = true;
            this.btnRandomKey.Click += new System.EventHandler(this.btnRandomKey_Click);
            // 
            // btnRandomV
            // 
            resources.ApplyResources(this.btnRandomV, "btnRandomV");
            this.btnRandomV.Name = "btnRandomV";
            this.btnRandomV.UseVisualStyleBackColor = true;
            this.btnRandomV.Click += new System.EventHandler(this.btnRandomV_Click);
            // 
            // btnDesencriptar
            // 
            resources.ApplyResources(this.btnDesencriptar, "btnDesencriptar");
            this.btnDesencriptar.Name = "btnDesencriptar";
            this.btnDesencriptar.Tag = "Decripted_";
            this.btnDesencriptar.UseVisualStyleBackColor = true;
            this.btnDesencriptar.Click += new System.EventHandler(this.btnEncriptarDesencriptar_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDesencriptar);
            this.Controls.Add(this.btnRandomV);
            this.Controls.Add(this.btnRandomKey);
            this.Controls.Add(this.txtVector);
            this.Controls.Add(this.lblVector);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.btnEncriptar);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnSelectFile);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnEncriptar;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label lblVector;
        private System.Windows.Forms.TextBox txtVector;
        private System.Windows.Forms.Button btnRandomKey;
        private System.Windows.Forms.Button btnRandomV;
        private System.Windows.Forms.Button btnDesencriptar;
    }
}

