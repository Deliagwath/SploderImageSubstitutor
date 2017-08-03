using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace SploderImageSubstitutor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Init()
        {
            this.ImagePaths = new List<string>();
        }

        private void InitDialog()
        {
            XMLFileDialog.Title = "Please find game.xml";
            ImageFileDialog.Title = "Please pick images";
        }

        private void Log(string log)
        {
            TextBoxLog.Text += String.Format("{0}{1}", log, Environment.NewLine);
        }

        private string XMLPath;
        private List<string> XMLData;
        private List<string> ImagePaths;

        private void XMLButton_Click(object sender, EventArgs e)
        {
            DialogResult result = XMLFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.XMLPath = XMLFileDialog.FileName;
                Log(String.Format("XML Location: {0}", this.XMLPath));
            }

            XDocument xdoc = XDocument.Load(this.XMLPath);
            this.XMLData = xdoc.Elements().ToList().Select(el => el.ToString()).ToList();
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            DialogResult result = ImageFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.ImagePaths = ImageFileDialog.FileNames.ToList();
                this.ImagePaths.ForEach(imagePath => Log(String.Format("Image Location: {0}", imagePath)));
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            // Create a Backup
            //string backup = this.XMLPath;
            //backup += ".bak";
            //File.Copy(this.XMLPath, backup, true);

            // Credit to Nitin Varpe and Hakam Fostok
            // https://stackoverflow.com/questions/21325661/convert-image-path-to-base64-string
            List<string> b64s = this.ImagePaths.Select(imagePath =>
            {
                using (Image image = Image.FromFile(imagePath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, image.RawFormat);
                        byte[] imageBytes = ms.ToArray();
                        return Convert.ToBase64String(imageBytes);
                    }
                }
            }).ToList();
            b64s.ForEach(b64 => Log(String.Format("Image Converted: {0}", b64)));
        }
    }
}
