using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.Images;

namespace Bilder_zuschneiden
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cropImageButton;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.PictureBox pictureBox6;
		private System.Windows.Forms.PictureBox pictureBox7;
		private System.Windows.Forms.PictureBox pictureBox8;
		private System.Windows.Forms.PictureBox pictureBox9;
		private System.Windows.Forms.PictureBox pictureBox10;
		private System.Windows.Forms.PictureBox pictureBox11;
		private System.Windows.Forms.PictureBox pictureBox12;
		private System.Windows.Forms.PictureBox pictureBox13;
		private System.Windows.Forms.PictureBox pictureBox14;
		private System.Windows.Forms.PictureBox pictureBox15;
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
			this.cropImageButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.pictureBox7 = new System.Windows.Forms.PictureBox();
			this.pictureBox8 = new System.Windows.Forms.PictureBox();
			this.pictureBox9 = new System.Windows.Forms.PictureBox();
			this.pictureBox10 = new System.Windows.Forms.PictureBox();
			this.pictureBox11 = new System.Windows.Forms.PictureBox();
			this.pictureBox12 = new System.Windows.Forms.PictureBox();
			this.pictureBox13 = new System.Windows.Forms.PictureBox();
			this.pictureBox14 = new System.Windows.Forms.PictureBox();
			this.pictureBox15 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// cropImageButton
			// 
			this.cropImageButton.Location = new System.Drawing.Point(16, 344);
			this.cropImageButton.Name = "cropImageButton";
			this.cropImageButton.Size = new System.Drawing.Size(256, 23);
			this.cropImageButton.TabIndex = 0;
			this.cropImageButton.Text = "Bild zuschneiden und in PictureBoxen anzeigen";
			this.cropImageButton.Click += new System.EventHandler(this.cropImageButton_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(24, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 100);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(128, 16);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(100, 100);
			this.pictureBox2.TabIndex = 2;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Location = new System.Drawing.Point(232, 16);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(100, 100);
			this.pictureBox3.TabIndex = 3;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox4
			// 
			this.pictureBox4.Location = new System.Drawing.Point(336, 16);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(100, 100);
			this.pictureBox4.TabIndex = 4;
			this.pictureBox4.TabStop = false;
			// 
			// pictureBox5
			// 
			this.pictureBox5.Location = new System.Drawing.Point(440, 16);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new System.Drawing.Size(100, 100);
			this.pictureBox5.TabIndex = 5;
			this.pictureBox5.TabStop = false;
			// 
			// pictureBox6
			// 
			this.pictureBox6.Location = new System.Drawing.Point(24, 120);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new System.Drawing.Size(100, 100);
			this.pictureBox6.TabIndex = 10;
			this.pictureBox6.TabStop = false;
			// 
			// pictureBox7
			// 
			this.pictureBox7.Location = new System.Drawing.Point(128, 120);
			this.pictureBox7.Name = "pictureBox7";
			this.pictureBox7.Size = new System.Drawing.Size(100, 100);
			this.pictureBox7.TabIndex = 9;
			this.pictureBox7.TabStop = false;
			// 
			// pictureBox8
			// 
			this.pictureBox8.Location = new System.Drawing.Point(232, 120);
			this.pictureBox8.Name = "pictureBox8";
			this.pictureBox8.Size = new System.Drawing.Size(100, 100);
			this.pictureBox8.TabIndex = 8;
			this.pictureBox8.TabStop = false;
			// 
			// pictureBox9
			// 
			this.pictureBox9.Location = new System.Drawing.Point(336, 120);
			this.pictureBox9.Name = "pictureBox9";
			this.pictureBox9.Size = new System.Drawing.Size(100, 100);
			this.pictureBox9.TabIndex = 7;
			this.pictureBox9.TabStop = false;
			// 
			// pictureBox10
			// 
			this.pictureBox10.Location = new System.Drawing.Point(440, 120);
			this.pictureBox10.Name = "pictureBox10";
			this.pictureBox10.Size = new System.Drawing.Size(100, 100);
			this.pictureBox10.TabIndex = 6;
			this.pictureBox10.TabStop = false;
			// 
			// pictureBox11
			// 
			this.pictureBox11.Location = new System.Drawing.Point(24, 224);
			this.pictureBox11.Name = "pictureBox11";
			this.pictureBox11.Size = new System.Drawing.Size(100, 100);
			this.pictureBox11.TabIndex = 15;
			this.pictureBox11.TabStop = false;
			// 
			// pictureBox12
			// 
			this.pictureBox12.Location = new System.Drawing.Point(128, 224);
			this.pictureBox12.Name = "pictureBox12";
			this.pictureBox12.Size = new System.Drawing.Size(100, 100);
			this.pictureBox12.TabIndex = 14;
			this.pictureBox12.TabStop = false;
			// 
			// pictureBox13
			// 
			this.pictureBox13.Location = new System.Drawing.Point(232, 224);
			this.pictureBox13.Name = "pictureBox13";
			this.pictureBox13.Size = new System.Drawing.Size(100, 100);
			this.pictureBox13.TabIndex = 13;
			this.pictureBox13.TabStop = false;
			// 
			// pictureBox14
			// 
			this.pictureBox14.Location = new System.Drawing.Point(336, 224);
			this.pictureBox14.Name = "pictureBox14";
			this.pictureBox14.Size = new System.Drawing.Size(100, 100);
			this.pictureBox14.TabIndex = 12;
			this.pictureBox14.TabStop = false;
			// 
			// pictureBox15
			// 
			this.pictureBox15.Location = new System.Drawing.Point(440, 224);
			this.pictureBox15.Name = "pictureBox15";
			this.pictureBox15.Size = new System.Drawing.Size(100, 100);
			this.pictureBox15.TabIndex = 11;
			this.pictureBox15.TabStop = false;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(560, 373);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBox11,
																		  this.pictureBox12,
																		  this.pictureBox13,
																		  this.pictureBox14,
																		  this.pictureBox15,
																		  this.pictureBox6,
																		  this.pictureBox7,
																		  this.pictureBox8,
																		  this.pictureBox9,
																		  this.pictureBox10,
																		  this.pictureBox5,
																		  this.pictureBox4,
																		  this.pictureBox3,
																		  this.pictureBox2,
																		  this.pictureBox1,
																		  this.cropImageButton});
			this.Name = "StartForm";
			this.Text = "Bilder zuschneiden";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void cropImageButton_Click(object sender, System.EventArgs e)
		{
			// Bild laden
			string fileName = Path.Combine(Application.StartupPath, "Les Crosets.jpg");
			Bitmap bitmap = new Bitmap(fileName);

			// Fünf Spalten in drei Zeilen mit je 100 * 100 Pixel ausschneiden
			int width = 100;
			int height = 100;

			pictureBox1.Image = ImageUtils.CropImage(bitmap, 0, 0, width, height);
			pictureBox2.Image = ImageUtils.CropImage(bitmap, 100, 0, width, height);
			pictureBox3.Image = ImageUtils.CropImage(bitmap, 200, 0, width, height);
			pictureBox4.Image = ImageUtils.CropImage(bitmap, 300, 0, width, height);
			pictureBox5.Image = ImageUtils.CropImage(bitmap, 400, 0, width, height);

			pictureBox6.Image = ImageUtils.CropImage(bitmap, 0, 100, width, height);
			pictureBox7.Image = ImageUtils.CropImage(bitmap, 100, 100, width, height);
			pictureBox8.Image = ImageUtils.CropImage(bitmap, 200, 100, width, height);
			pictureBox9.Image = ImageUtils.CropImage(bitmap, 300, 100, width, height);
			pictureBox10.Image = ImageUtils.CropImage(bitmap, 400, 100, width, height);

			pictureBox11.Image = ImageUtils.CropImage(bitmap, 0, 200, width, height);
			pictureBox12.Image = ImageUtils.CropImage(bitmap, 100, 200, width, height);
			pictureBox13.Image = ImageUtils.CropImage(bitmap, 200, 200, width, height);
			pictureBox14.Image = ImageUtils.CropImage(bitmap, 300, 200, width, height);
			pictureBox15.Image = ImageUtils.CropImage(bitmap, 400, 200, width, height);

			
		
		}
	}
}
