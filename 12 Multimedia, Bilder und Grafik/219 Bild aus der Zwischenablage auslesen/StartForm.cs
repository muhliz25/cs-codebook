using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.Multimedia;

namespace Bild_aus_Zwischenablage
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button readImageButton;
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
			this.readImageButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(16, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(264, 184);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// readImageButton
			// 
			this.readImageButton.Location = new System.Drawing.Point(16, 200);
			this.readImageButton.Name = "readImageButton";
			this.readImageButton.Size = new System.Drawing.Size(80, 24);
			this.readImageButton.TabIndex = 1;
			this.readImageButton.Text = "Bild auslesen";
			this.readImageButton.Click += new System.EventHandler(this.readImageButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 245);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.readImageButton,
																		  this.pictureBox1});
			this.Name = "StartForm";
			this.Text = "Bild aus der Zwischenablage lesen";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void readImageButton_Click(object sender, System.EventArgs e)
		{
			this.pictureBox1.Image = ImageUtils.GetBitmapFromClipboard();
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
		
		}

	}
}
