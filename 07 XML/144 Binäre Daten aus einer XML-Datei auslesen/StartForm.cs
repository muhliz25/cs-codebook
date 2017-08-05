using System;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Binre_Dateien_aus_Base64_codierten_Strings_erzeugen
{
	public class StartForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button ReadImage;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.ComponentModel.Container components = null;

		[STAThread]
		static void Main(string[] args)
		{
			Application.Run(new StartForm());
		}


		public StartForm()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			this.ReadImage = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// ReadImage
			// 
			this.ReadImage.Location = new System.Drawing.Point(16, 24);
			this.ReadImage.Name = "ReadImage";
			this.ReadImage.Size = new System.Drawing.Size(96, 32);
			this.ReadImage.TabIndex = 0;
			this.ReadImage.Text = "Bild einlesen";
			this.ReadImage.Click += new System.EventHandler(this.ReadImage_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(16, 64);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(248, 192);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBox1,
																		  this.ReadImage});
			this.Name = "StartForm";
			this.Text = "Binäre Daten aus einer XML-Datei lesen";
			this.ResumeLayout(false);

		}
		#endregion


		private void ReadImage_Click(object sender, System.EventArgs e)
		{
			// XML-Datei einlesen
			string xmlFileName = Path.Combine(
				Application.StartupPath, "Persons.xml");
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(xmlFileName);
			XmlNode personNode = xmlDoc.SelectSingleNode("persons/person[attribute::id='1000']");
			XmlNode imageNode = personNode.SelectSingleNode("image");

			// Base64-codierten String in Bitmap umwandeln
			byte[] buffer = Convert.FromBase64String(imageNode.InnerText);
			Bitmap bitmap = new Bitmap(new MemoryStream(buffer, 
				0, buffer.Length));

			pictureBox1.Image = bitmap;
		}
	}
}
