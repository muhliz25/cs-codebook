using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.Multimedia;

namespace Byte2Bitmap
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button demoButton;
		private System.Windows.Forms.PictureBox pictureBox1;
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.demoButton = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(264, 184);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// demoButton
			// 
			this.demoButton.Location = new System.Drawing.Point(16, 200);
			this.demoButton.Name = "demoButton";
			this.demoButton.Size = new System.Drawing.Size(80, 24);
			this.demoButton.TabIndex = 1;
			this.demoButton.Text = "Demo";
			this.demoButton.Click += new System.EventHandler(this.demoButton_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(288, 8);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(264, 184);
			this.pictureBox2.TabIndex = 2;
			this.pictureBox2.TabStop = false;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(576, 237);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBox2,
																		  this.demoButton,
																		  this.pictureBox1});
			this.Name = "StartForm";
			this.Text = "Bitmap aus Byte-Array erzeugen";
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
		
		}

		private void demoButton_Click(object sender, System.EventArgs e)
		{
			// Das Bild in der linken PictureBox in ein Byte-Array schreiben
			byte[] imageBytes = ImageUtils.Image2Byte(this.pictureBox1.Image, ImageFormat.Gif);

			// Das Byte-Array wieder in ein Bitmap-Objekt schreiben
			// und in die rechte PictureBox schreiben
			pictureBox2.Image = ImageUtils.Byte2Btmap(imageBytes);
		}
	}
}
