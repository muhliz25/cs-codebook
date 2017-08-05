using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.Multimedia;

namespace Screenshot
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button screenshotButton;
		private System.Windows.Forms.Button screenshotFormButton;
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
			this.screenshotButton = new System.Windows.Forms.Button();
			this.screenshotFormButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(16, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(264, 184);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// screenshotButton
			// 
			this.screenshotButton.Location = new System.Drawing.Point(16, 200);
			this.screenshotButton.Name = "screenshotButton";
			this.screenshotButton.Size = new System.Drawing.Size(168, 24);
			this.screenshotButton.TabIndex = 1;
			this.screenshotButton.Text = "Screenshot des Bildschirms";
			this.screenshotButton.Click += new System.EventHandler(this.screenshotButton_Click);
			// 
			// screenshotFormButton
			// 
			this.screenshotFormButton.Location = new System.Drawing.Point(16, 232);
			this.screenshotFormButton.Name = "screenshotFormButton";
			this.screenshotFormButton.Size = new System.Drawing.Size(168, 24);
			this.screenshotFormButton.TabIndex = 2;
			this.screenshotFormButton.Text = "Screenshot des Formulars";
			this.screenshotFormButton.Click += new System.EventHandler(this.screenshotFormButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 269);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.screenshotFormButton,
																		  this.screenshotButton,
																		  this.pictureBox1});
			this.Name = "StartForm";
			this.Text = "Screenshots erstellen";
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

		private void screenshotButton_Click(object sender, System.EventArgs e)
		{
			this.pictureBox1.Image = ImageUtils.Screenshot();
		}

		private void screenshotFormButton_Click(object sender, System.EventArgs e)
		{
			this.pictureBox1.Image = ImageUtils.Screenshot(this);
		}

	}
}
