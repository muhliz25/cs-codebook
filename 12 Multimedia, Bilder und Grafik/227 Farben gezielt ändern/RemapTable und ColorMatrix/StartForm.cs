using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Farben_ändern
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button colorMatrixButton;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button remapTableButton;
		private System.Windows.Forms.PictureBox pictureBox2;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(StartForm));
			this.colorMatrixButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.remapTableButton = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// colorMatrixButton
			// 
			this.colorMatrixButton.Location = new System.Drawing.Point(176, 8);
			this.colorMatrixButton.Name = "colorMatrixButton";
			this.colorMatrixButton.Size = new System.Drawing.Size(152, 23);
			this.colorMatrixButton.TabIndex = 46;
			this.colorMatrixButton.Text = "Bild aufhellen";
			this.colorMatrixButton.Click += new System.EventHandler(this.colorMatrixButton_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 40);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(150, 107);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 47;
			this.pictureBox1.TabStop = false;
			// 
			// remapTableButton
			// 
			this.remapTableButton.Location = new System.Drawing.Point(16, 8);
			this.remapTableButton.Name = "remapTableButton";
			this.remapTableButton.Size = new System.Drawing.Size(152, 23);
			this.remapTableButton.TabIndex = 49;
			this.remapTableButton.Text = "Hintergrundfarbe ändern";
			this.remapTableButton.Click += new System.EventHandler(this.remapTableButton_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(176, 41);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(150, 107);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 50;
			this.pictureBox2.TabStop = false;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(336, 157);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBox2,
																		  this.remapTableButton,
																		  this.pictureBox1,
																		  this.colorMatrixButton});
			this.Name = "StartForm";
			this.Text = "Farbinformationen verändern";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}


		private void colorMatrixButton_Click(object sender, System.EventArgs e)
		{
			// Bitmap aus der ersten PictureBox auslesen
			Bitmap sourceBitmap = (Bitmap)this.pictureBox1.Image;

			// Neues Bitmap mit den Ausmaßen des Originals erzeugen
			Bitmap destBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

			// ColorMatrix für die Transformation der Farben erzeugen
			ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
				new float[] {1, 0, 0, 0, 0},
				new float[] {0, 1, 0, 0, 0},
				new float[] {0, 0, 1, 0, 0},
				new float[] {0, 0, 0, 1, 0},
				new float[] {0.3F, 0.3F, 0.3F, 0, 1}
			});

			// Grafik auf dem Bitmap-Objekt ausgeben und dabei ein neues
			// ImageAttributes-Objekt mit der ColorMatrix übergeben 
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(colorMatrix);
			Graphics g = Graphics.FromImage(destBitmap);
			g.DrawImage(sourceBitmap, new Rectangle(0, 0, sourceBitmap.Width,
				sourceBitmap.Height), 0, 0, sourceBitmap.Width, sourceBitmap.Height,
				GraphicsUnit.Pixel, imageAttributes);
			g.Dispose();

			// Neues Bitmap-Objekt in der zweiten PictureBox ablegen
			pictureBox2.Image = destBitmap;
		}

		private void remapTableButton_Click(object sender, System.EventArgs e)
		{
			// Bitmap aus der ersten PictureBox auslesen
			Bitmap sourceBitmap = (Bitmap)this.pictureBox1.Image;

			// Neues Bitmap mit den Ausmaßen des Originals erzeugen
			Bitmap destBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

			// ColorMap-Array für die Transformation der Farben erzeugen
			ColorMap[] map = new ColorMap[1];
			map[0] = new ColorMap();
			map[0].OldColor = sourceBitmap.GetPixel(0,0);
			map[0].NewColor = Color.Silver;

			// Grafik auf dem Bitmap-Objekt ausgeben und dabei ein neues
			// ImageAttributes-Objekt mit dem ColorMap-Objekt übergeben 
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetRemapTable(map);
			Graphics g = Graphics.FromImage(destBitmap);
			g.DrawImage(sourceBitmap, new Rectangle(0, 0, sourceBitmap.Width,
				sourceBitmap.Height), 0, 0, sourceBitmap.Width, sourceBitmap.Height,
				GraphicsUnit.Pixel, imageAttributes);
			g.Dispose();

			// Neues Bitmap-Objekt in der zweiten PictureBox ablegen
			pictureBox2.Image = destBitmap;
		}
	}
}
