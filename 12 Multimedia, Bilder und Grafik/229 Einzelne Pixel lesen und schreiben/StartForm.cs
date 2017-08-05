using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.Images;

namespace Bildnegativ
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button negativeButton;
		private System.Windows.Forms.PictureBox pictureBox1;
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
			this.negativeButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// negativeButton
			// 
			this.negativeButton.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.negativeButton.Location = new System.Drawing.Point(8, 152);
			this.negativeButton.Name = "negativeButton";
			this.negativeButton.Size = new System.Drawing.Size(104, 23);
			this.negativeButton.TabIndex = 1;
			this.negativeButton.Text = "Negativ erzeugen";
			this.negativeButton.Click += new System.EventHandler(this.negativeButton_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(160, 120);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(256, 181);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBox1,
																		  this.negativeButton});
			this.Name = "StartForm";
			this.Text = "Erzeugen eines Bildnegativs";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void negativeButton_Click(object sender, System.EventArgs e)
		{
			// Negativ erzeugen und der PictureBox wieder zuweisen 
			this.pictureBox1.Image = ImageUtils.CreateNegative2((Bitmap)this.pictureBox1.Image);
		}
	}
}
