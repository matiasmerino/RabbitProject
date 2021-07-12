using Crypto.Rabbit;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            openFileDialog.Filter = "Image Files (*.bmp)|*.bmp";
            openFileDialog.AddExtension = true;
            openFileDialog.FileName = "";
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.ShowDialog();
        }

        private void btnEncriptarDesencriptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFileName.Text))
                    throw new ArgumentException("Seleccione un archivo.");
                byte[] key = Encoding.ASCII.GetBytes(txtKey.Text);
                byte[] iv = Encoding.ASCII.GetBytes(txtVector.Text);
                var sourceFileName = openFileDialog.FileName;
                var sourceFileNameMod = sourceFileName.Replace((string)btnDesencriptar.Tag, "").Replace((string)btnEncriptar.Tag, "");
                var targetFileName = Path.Combine(Path.GetDirectoryName(sourceFileNameMod), ((Button)sender).Tag + Path.GetFileName(sourceFileNameMod));
                ICryptoTransform cipher = iv.Length == 0 ? RabbitCipher.CreateEncryptor(key) : RabbitCipher.CreateEncryptor(key, iv);
                byte[] buffer = new byte[10000];
                FileStream infs = new FileStream(sourceFileName, FileMode.Open, FileAccess.Read);
                FileStream outfs = new FileStream(targetFileName, FileMode.Create, FileAccess.Write);
                CryptoStream cs = new CryptoStream(outfs, cipher, CryptoStreamMode.Write);
                MemoryStream ms = new MemoryStream();
                infs.CopyTo(ms);
                byte[] headerArray = ms.ToArray().Take(54).ToArray();
                byte[] imageArray = ms.ToArray().Skip(54).ToArray();
                MemoryStream m2s = new MemoryStream(imageArray);
                while (true)
                {
                    int r = m2s.Read(buffer, 0, buffer.Length);
                    if (r <= 0) break;
                    cs.Write(buffer, 0, r);
                }
                cs.Dispose();
                outfs.Dispose();
                byte[] encryptedArray = File.ReadAllBytes(targetFileName);
                byte[] exportArray = new byte[headerArray.Length + encryptedArray.Length];
                Buffer.BlockCopy(headerArray, 0, exportArray, 0, headerArray.Length);
                Buffer.BlockCopy(encryptedArray, 0, exportArray, headerArray.Length, encryptedArray.Length);
                MemoryStream bitmapMS = new MemoryStream(exportArray);
                Bitmap newImage = new Bitmap(bitmapMS);
                newImage.Save(targetFileName);
                infs.Dispose();
                ms.Dispose();
                m2s.Dispose();
                bitmapMS.Dispose();
                newImage.Dispose();
                openFileDialog.Dispose();
                MessageBox.Show(((Button)sender).Tag + "correctamente.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Ups!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRandomKey_Click(object sender, EventArgs e)
        {
            txtKey.Text = GenerarClave(16);
        }

        private void btnRandomV_Click(object sender, EventArgs e)
        {
            txtVector.Text = GenerarClave(8);
        }

        private string GenerarClave(int size)
        {
            byte[] bytes = new byte[size];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes).Substring(0, bytes.Length);
        }
    }
}
