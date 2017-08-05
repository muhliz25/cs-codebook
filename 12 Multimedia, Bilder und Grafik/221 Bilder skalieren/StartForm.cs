using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.Images;

namespace Bilder_skalieren
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button demoButton;
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
			this.SuspendLayout();
			// 
			// demoButton
			// 
			this.demoButton.Location = new System.Drawing.Point(16, 24);
			this.demoButton.Name = "demoButton";
			this.demoButton.TabIndex = 0;
			this.demoButton.Text = "Demo";
			this.demoButton.Click += new System.EventHandler(this.demoButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.demoButton});
			this.Name = "StartForm";
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
			string fileName = Path.Combine(Application.StartupPath, "Les Crosets.jpg");
			Bitmap bitmap1 = new Bitmap(fileName);

			// Skalieren über ein Bitmap-Objekt
			fileName = Path.Combine(Application.StartupPath, "Les Crosets verkleinert 1.jpg");
			Bitmap bitmap2 = new Bitmap(bitmap1, (int)(bitmap1.Width * 0.2), 
				(int)(bitmap1.Height * 0.2));
			bitmap2.Save(fileName, ImageFormat.Jpeg);

			// Skalieren über ScaleBitmap
			fileName = Path.Combine(Application.StartupPath, "Les Crosets verkleinert 2.jpg");
			bitmap2 = ImageUtils.ScaleBitmap(bitmap1, 0.2, InterpolationMode.HighQualityBicubic,
				PixelOffsetMode.HighQuality, SmoothingMode.HighQuality);
			bitmap2.Save(fileName, ImageFormat.Jpeg);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
