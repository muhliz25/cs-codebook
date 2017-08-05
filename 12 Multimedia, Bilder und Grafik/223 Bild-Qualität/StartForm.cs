using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.Images;

namespace Bild_Qualität
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button demoButton;
		private System.Windows.Forms.ListBox encoderList;
		private System.Windows.Forms.Button encoder4ImageFormatButton;
		private System.Windows.Forms.ComboBox mimeList;
		private System.ComponentModel.Container components = null;

		public StartForm()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.demoButton = new System.Windows.Forms.Button();
			this.encoder4ImageFormatButton = new System.Windows.Forms.Button();
			this.encoderList = new System.Windows.Forms.ListBox();
			this.mimeList = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// demoButton
			// 
			this.demoButton.Location = new System.Drawing.Point(16, 16);
			this.demoButton.Name = "demoButton";
			this.demoButton.Size = new System.Drawing.Size(240, 23);
			this.demoButton.TabIndex = 0;
			this.demoButton.Text = "JPEG-Datei mit 50% Qualität speichern";
			this.demoButton.Click += new System.EventHandler(this.demoButton_Click);
			// 
			// encoder4ImageFormatButton
			// 
			this.encoder4ImageFormatButton.Location = new System.Drawing.Point(16, 48);
			this.encoder4ImageFormatButton.Name = "encoder4ImageFormatButton";
			this.encoder4ImageFormatButton.Size = new System.Drawing.Size(240, 23);
			this.encoder4ImageFormatButton.TabIndex = 1;
			this.encoder4ImageFormatButton.Text = "Encoder für Bildformat auslesen";
			this.encoder4ImageFormatButton.Click += new System.EventHandler(this.encoder4ImageFormatButton_Click);
			// 
			// encoderList
			// 
			this.encoderList.Location = new System.Drawing.Point(16, 80);
			this.encoderList.Name = "encoderList";
			this.encoderList.Size = new System.Drawing.Size(240, 160);
			this.encoderList.TabIndex = 2;
			// 
			// mimeList
			// 
			this.mimeList.Location = new System.Drawing.Point(264, 48);
			this.mimeList.Name = "mimeList";
			this.mimeList.Size = new System.Drawing.Size(121, 21);
			this.mimeList.TabIndex = 3;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 261);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.mimeList,
																		  this.encoderList,
																		  this.encoder4ImageFormatButton,
																		  this.demoButton});
			this.Name = "StartForm";
			this.Text = "Bilder mit definierter Qualität speichern";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void demoButton_Click(object sender, System.EventArgs e)
		{
			// JPEG-Datei in Bitmap einlesen
			string fileName = Path.Combine(Application.StartupPath, "Les Crosets.jpg");
			Bitmap bitmap = new Bitmap(fileName);

			// Als JPEG mit mittlerer Qualität
			fileName = Path.Combine(Application.StartupPath, "Les Crosets neu.jpg");
			ImageUtils.SaveAsJpeg(bitmap, fileName, 50);
		}

		private void encoder4ImageFormatButton_Click(object sender, System.EventArgs e)
		{
			encoderList.DataSource = ImageUtils.GetAvailableEncoderNames(mimeList.Text);
			if (encoderList.Items.Count == 0)
			{
				encoderList.DataSource = null;
				encoderList.Items.Add("Keine Encoder verfügbar");
			}

		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
			// Die verfügbaren MIME-Typen auslesen und in die
			// ComboBox schreiben
			this.mimeList.DataSource = ImageUtils.GetAvailableMimeTypes();
		}

	}
}
