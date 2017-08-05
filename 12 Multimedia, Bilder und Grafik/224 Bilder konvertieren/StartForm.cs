using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Bilder_konvertieren
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
			this.demoButton.Location = new System.Drawing.Point(16, 16);
			this.demoButton.Name = "demoButton";
			this.demoButton.Size = new System.Drawing.Size(240, 23);
			this.demoButton.TabIndex = 0;
			this.demoButton.Text = "JPEG-Datei in Bitmap konvertieren";
			this.demoButton.Click += new System.EventHandler(this.demoButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 61);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.demoButton});
			this.Name = "StartForm";
			this.Text = "Bilder mit definierter Qualität speichern";
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

			// Als Bitmap abspeichern
			fileName = Path.Combine(Application.StartupPath, "Les Crosets.bmp");
			bitmap.Save(fileName, ImageFormat.Bmp);
		}

	}
}
