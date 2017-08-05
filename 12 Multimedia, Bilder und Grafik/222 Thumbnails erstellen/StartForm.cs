using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.Images;

namespace Thumbnails
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox3;
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 80);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(120, 8);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(100, 80);
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox4
			// 
			this.pictureBox4.Location = new System.Drawing.Point(120, 104);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(100, 80);
			this.pictureBox4.TabIndex = 3;
			this.pictureBox4.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Location = new System.Drawing.Point(8, 104);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(100, 80);
			this.pictureBox3.TabIndex = 2;
			this.pictureBox3.TabStop = false;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(232, 189);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBox4,
																		  this.pictureBox3,
																		  this.pictureBox2,
																		  this.pictureBox1});
			this.Name = "StartForm";
			this.Text = "Thumbnails erstellen";
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
			// Zwei Bilder im Ordner der Anwendung einlesen und über GetThumbnailImage
			// skalieren
			string fileName = Path.Combine(Application.StartupPath, "Les Crosets1.jpg");
			Bitmap bitmap1 = new Bitmap(fileName);
			this.pictureBox1.Image = bitmap1.GetThumbnailImage(this.pictureBox1.Width, 
				this.pictureBox1.Height, null, IntPtr.Zero);
			
			fileName = Path.Combine(Application.StartupPath, "Les Crosets2.jpg");
			Bitmap bitmap2 = new Bitmap(fileName);
			this.pictureBox2.Image = bitmap2.GetThumbnailImage(this.pictureBox2.Width, 
				this.pictureBox2.Height, null, IntPtr.Zero);

			// Die Bilder über ScaleBitmap skalieren
			this.pictureBox3.Image = ImageUtils.ScaleBitmap(bitmap1, this.pictureBox2.Width, 
				this.pictureBox2.Height, InterpolationMode.HighQualityBicubic, 
				PixelOffsetMode.HighQuality, SmoothingMode.HighQuality);

			this.pictureBox4.Image = ImageUtils.ScaleBitmap(bitmap2, this.pictureBox2.Width, 
				this.pictureBox2.Height, InterpolationMode.HighQualityBicubic, 
				PixelOffsetMode.HighQuality, SmoothingMode.HighQuality);
		
		}
	}
}
