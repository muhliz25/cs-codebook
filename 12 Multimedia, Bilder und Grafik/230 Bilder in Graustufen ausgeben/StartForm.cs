using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.Images;

namespace Graustufen
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button grayscaleButton;
		private System.Windows.Forms.Button readOriginalButton;
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
			this.grayscaleButton = new System.Windows.Forms.Button();
			this.readOriginalButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// grayscaleButton
			// 
			this.grayscaleButton.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.grayscaleButton.Location = new System.Drawing.Point(8, 352);
			this.grayscaleButton.Name = "grayscaleButton";
			this.grayscaleButton.Size = new System.Drawing.Size(192, 23);
			this.grayscaleButton.TabIndex = 0;
			this.grayscaleButton.Text = "Graustufen-Umwandlung";
			this.grayscaleButton.Click += new System.EventHandler(this.grayscaleButton_Click);
			// 
			// readOriginalButton
			// 
			this.readOriginalButton.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.readOriginalButton.Location = new System.Drawing.Point(8, 320);
			this.readOriginalButton.Name = "readOriginalButton";
			this.readOriginalButton.Size = new System.Drawing.Size(192, 23);
			this.readOriginalButton.TabIndex = 2;
			this.readOriginalButton.Text = "Original einlesen";
			this.readOriginalButton.Click += new System.EventHandler(this.readOriginalButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 381);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.readOriginalButton,
																		  this.grayscaleButton});
			this.Name = "StartForm";
			this.Text = "Graustufen";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
			// Original einlesen
			string fileName = Path.Combine(Application.StartupPath, "Les Crosets.jpg");
			this.BackgroundImage = new Bitmap(fileName);
		}

		private void grayscaleButton_Click(object sender, System.EventArgs e)
		{
			// Original einlesen
			string fileName = Path.Combine(Application.StartupPath, "Les Crosets.jpg");
			Bitmap bitmap = new Bitmap(fileName);

			// Bild in Graustufen umgewandelt als Hintergrundbild setzen
			this.BackgroundImage = ImageUtils.CreateGrayscaledBitmap(bitmap);
		}

		private void readOriginalButton_Click(object sender, System.EventArgs e)
		{
			// Original einlesen
			string fileName = Path.Combine(Application.StartupPath, "Les Crosets.jpg");

			// Bild als Hintergrundbild setzen
			this.BackgroundImage = new Bitmap(fileName);
		}

	}
}
