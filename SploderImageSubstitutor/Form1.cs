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
        private XDocument Game;
        private List<XElement> Graphics;
        private bool XMLLoaded = false;
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

            this.Game = XDocument.Load(this.XMLPath);
            this.Graphics = this.Game
                .Descendants().ToList().First(x => x.Name == "graphics")            // Get Graphics Node
                .Descendants().ToList().Where(x => x.Attributes().Count() == 1)     // Get Descendants with only one Attribute (Name)
                .ToList();                                                          // Return the list of graphic
            Log("Loaded XML");
            this.XMLLoaded = true;
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            DialogResult result = ImageFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.ImagePaths = ImageFileDialog.FileNames.ToList();
                this.ImagePaths.ForEach(imagePath => Log(String.Format("Image Location: {0}", imagePath)));
                Log(String.Format("Loaded {0} images", this.ImagePaths.Count));
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (!this.XMLLoaded) { MessageBox.Show("You haven't loaded game.xml!"); return; }
            if (this.ImagePaths.Count > this.Graphics.Count)
            {
                string error = String.Format(
                    "You have more images than the XML. Images ({0}/{1}) XML",
                    this.ImagePaths.Count,
                    this.Graphics.Count);
                MessageBox.Show(error);
            }
            
            // Conversion from Image File to Base64 String Format
            // Credit to Nitin Varpe and Hakam Fostok
            // https://stackoverflow.com/questions/21325661/convert-image-path-to-base64-string
            List<string> b64s = this.ImagePaths.Select((imagePath, index) =>
            {
                using (Image image = Image.FromFile(imagePath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, image.RawFormat);
                        byte[] imageBytes = ms.ToArray();
                        Log(String.Format("Image Converted: {0}/{1}", index + 1, this.ImagePaths.Count));
                        return Convert.ToBase64String(imageBytes);
                    }
                }
            }).ToList();

            // Clearing and Inserting new Image Data
            int i = 1;
            foreach (XElement graphic in this.Graphics)
            {
                if (b64s.Count > 0)
                {
                    graphic.SetValue(b64s[0]);
                    b64s.RemoveAt(0);
                    Log(String.Format("Replaced Graphic {0}/{1}, {2} Images Left", i, this.Graphics.Count, b64s.Count));
                }
                else { break; }
            }

            // Create a Backup
            Log(String.Format("Creating Backup {0}{1}", this.XMLPath, ".bak"));
            string backup = this.XMLPath + ".bak";
            File.Copy(this.XMLPath, backup, true);
            Log("Backup Created");

            // Save to file
            Log(String.Format("Saving to {0}", this.XMLPath));
            try
            {
                this.Game.Save(this.XMLPath);
            }
            catch (Exception err)
            {
                Log("Error while saving");
                Log(err.ToString());
            }
            finally
            {
                Log("Saved");
            }
        }
    }
}
