using Crypto.Rabbit;
using MetadataExtractor;
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

namespace RabbitProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            txtFileName.Text = Path.GetFileName(openFileDialog.FileName);
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Buscar archivo";
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            openFileDialog.AddExtension = true;
            openFileDialog.FileName = "";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog.ShowDialog();
        }

        private void btnEncriptarDesencriptar_Click(object sender, EventArgs e)
        {
            byte[] key = Convert.FromBase64String(txtKey.Text);
            byte[] iv = Convert.FromBase64String(txtVector.Text);
            var sourceFileName = openFileDialog.FileName;var sourceFileNameMod = sourceFileName.Replace((string)btnDesencriptar.Tag, "").Replace((string)btnEncriptar.Tag, "");
            var targetFileName = Path.Combine(Path.GetDirectoryName(sourceFileNameMod), ((Button)sender).Tag + Path.GetFileName(sourceFileNameMod));
            ICryptoTransform cipher = RabbitCipher.CreateEncryptor(key, iv);
            byte[] buffer = new byte[10000];
            using (FileStream infs = new FileStream(sourceFileName, FileMode.Open, FileAccess.Read))
            using (FileStream outfs = new FileStream(targetFileName, FileMode.Create, FileAccess.Write))
            using (CryptoStream cs = new CryptoStream(outfs, cipher, CryptoStreamMode.Write))
            {
                while (true)
                {
                    int r = infs.Read(buffer, 0, buffer.Length);
                    if (r <= 0) break;
                    cs.Write(buffer, 0, r);
                }
            }
        }

        private void btnRandomKey_Click(object sender, EventArgs e)
        {
            byte[] bytes = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            txtKey.Text = Convert.ToBase64String(bytes);
        }

        private void btnRandomV_Click(object sender, EventArgs e)
        {
            byte[] bytes = new byte[8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            txtVector.Text = Convert.ToBase64String(bytes);
        }
    }
}
