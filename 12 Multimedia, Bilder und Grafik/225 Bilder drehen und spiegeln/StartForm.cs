using System;
using System.Drawing;
using System.Windows.Forms;
using Addison_Wesley.Codebook.Images;

namespace Bilder_drehen_und_spiegeln
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button rotate90Button;
		private System.Windows.Forms.Button rotate180Button;
		private System.Windows.Forms.Button rotate270Button;
		private System.Windows.Forms.Button mirrorXButton;
		private System.Windows.Forms.Button mirrorYButton;
		private System.Windows.Forms.Button mirrorXYButton;
		private System.Windows.Forms.Button rotateAngleButton;
		private System.Windows.Forms.TextBox angleTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button resetButton;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.CheckBox resizeBitmapCheckBox;
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
			this.rotate90Button = new System.Windows.Forms.Button();
			this.rotate180Button = new System.Windows.Forms.Button();
			this.rotate270Button = new System.Windows.Forms.Button();
			this.mirrorXButton = new System.Windows.Forms.Button();
			this.mirrorYButton = new System.Windows.Forms.Button();
			this.mirrorXYButton = new System.Windows.Forms.Button();
			this.rotateAngleButton = new System.Windows.Forms.Button();
			this.angleTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.resetButton = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.resizeBitmapCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(160, 120);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			// 
			// rotate90Button
			// 
			this.rotate90Button.Location = new System.Drawing.Point(248, 16);
			this.rotate90Button.Name = "rotate90Button";
			this.rotate90Button.Size = new System.Drawing.Size(192, 23);
			this.rotate90Button.TabIndex = 1;
			this.rotate90Button.Text = "90° drehen";
			this.rotate90Button.Click += new System.EventHandler(this.rotate90Button_Click);
			// 
			// rotate180Button
			// 
			this.rotate180Button.Location = new System.Drawing.Point(248, 48);
			this.rotate180Button.Name = "rotate180Button";
			this.rotate180Button.Size = new System.Drawing.Size(192, 23);
			this.rotate180Button.TabIndex = 2;
			this.rotate180Button.Text = "180° drehen";
			this.rotate180Button.Click += new System.EventHandler(this.rotate180Button_Click);
			// 
			// rotate270Button
			// 
			this.rotate270Button.Location = new System.Drawing.Point(248, 80);
			this.rotate270Button.Name = "rotate270Button";
			this.rotate270Button.Size = new System.Drawing.Size(192, 23);
			this.rotate270Button.TabIndex = 3;
			this.rotate270Button.Text = "270° drehen";
			this.rotate270Button.Click += new System.EventHandler(this.rotate270Button_Click);
			// 
			// mirrorXButton
			// 
			this.mirrorXButton.Location = new System.Drawing.Point(248, 112);
			this.mirrorXButton.Name = "mirrorXButton";
			this.mirrorXButton.Size = new System.Drawing.Size(192, 23);
			this.mirrorXButton.TabIndex = 4;
			this.mirrorXButton.Text = "An der X-Achse spiegeln";
			this.mirrorXButton.Click += new System.EventHandler(this.mirrorXButton_Click);
			// 
			// mirrorYButton
			// 
			this.mirrorYButton.Location = new System.Drawing.Point(248, 144);
			this.mirrorYButton.Name = "mirrorYButton";
			this.mirrorYButton.Size = new System.Drawing.Size(192, 23);
			this.mirrorYButton.TabIndex = 5;
			this.mirrorYButton.Text = "An der Y-Achse spiegeln";
			this.mirrorYButton.Click += new System.EventHandler(this.mirrorYButton_Click);
			// 
			// mirrorXYButton
			// 
			this.mirrorXYButton.Location = new System.Drawing.Point(248, 176);
			this.mirrorXYButton.Name = "mirrorXYButton";
			this.mirrorXYButton.Size = new System.Drawing.Size(192, 23);
			this.mirrorXYButton.TabIndex = 6;
			this.mirrorXYButton.Text = "An der X- und Y-Achse spiegeln";
			this.mirrorXYButton.Click += new System.EventHandler(this.mirrorXYButton_Click);
			// 
			// rotateAngleButton
			// 
			this.rotateAngleButton.Location = new System.Drawing.Point(248, 208);
			this.rotateAngleButton.Name = "rotateAngleButton";
			this.rotateAngleButton.Size = new System.Drawing.Size(192, 24);
			this.rotateAngleButton.TabIndex = 7;
			this.rotateAngleButton.Text = "Um einen definierten Winkel drehen";
			this.rotateAngleButton.Click += new System.EventHandler(this.rotateAngleButton_Click);
			// 
			// angleTextBox
			// 
			this.angleTextBox.Location = new System.Drawing.Point(344, 240);
			this.angleTextBox.Name = "angleTextBox";
			this.angleTextBox.Size = new System.Drawing.Size(40, 20);
			this.angleTextBox.TabIndex = 8;
			this.angleTextBox.Text = "33";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(248, 240);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 24);
			this.label1.TabIndex = 9;
			this.label1.Text = "Winkel:";
			// 
			// resetButton
			// 
			this.resetButton.Location = new System.Drawing.Point(8, 240);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(160, 23);
			this.resetButton.TabIndex = 10;
			this.resetButton.Text = "Bitmap zurücksetzen";
			this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(8, 8);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(160, 120);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 11;
			this.pictureBox2.TabStop = false;
			// 
			// resizeBitmapCheckBox
			// 
			this.resizeBitmapCheckBox.Checked = true;
			this.resizeBitmapCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.resizeBitmapCheckBox.Location = new System.Drawing.Point(256, 264);
			this.resizeBitmapCheckBox.Name = "resizeBitmapCheckBox";
			this.resizeBitmapCheckBox.Size = new System.Drawing.Size(200, 24);
			this.resizeBitmapCheckBox.TabIndex = 12;
			this.resizeBitmapCheckBox.Text = "Bild automatisch vergrößern";
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 285);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.resizeBitmapCheckBox,
																		  this.resetButton,
																		  this.label1,
																		  this.angleTextBox,
																		  this.rotateAngleButton,
																		  this.mirrorXYButton,
																		  this.mirrorYButton,
																		  this.mirrorXButton,
																		  this.rotate270Button,
																		  this.rotate180Button,
																		  this.rotate90Button,
																		  this.pictureBox1,
																		  this.pictureBox2});
			this.Name = "StartForm";
			this.Text = "Bilder drehen und spiegeln";
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

		private void rotate90Button_Click(object sender, System.EventArgs e)
		{
			Image image = pictureBox2.Image;
			image.RotateFlip(RotateFlipType.Rotate90FlipNone); 
			pictureBox2.Refresh();
		}

		private void rotate180Button_Click(object sender, System.EventArgs e)
		{
			Image image = pictureBox2.Image;
			image.RotateFlip(RotateFlipType.Rotate180FlipNone); 
			pictureBox2.Refresh();
		}

		private void rotate270Button_Click(object sender, System.EventArgs e)
		{
			Image image = pictureBox2.Image;
			image.RotateFlip(RotateFlipType.Rotate270FlipNone); 
			pictureBox2.Refresh();
		}

		private void mirrorXButton_Click(object sender, System.EventArgs e)
		{
			Image image = pictureBox2.Image;
			image.RotateFlip(RotateFlipType.RotateNoneFlipX); 
			pictureBox2.Refresh();
		}

		private void mirrorYButton_Click(object sender, System.EventArgs e)
		{
			Image image = pictureBox2.Image;
			image.RotateFlip(RotateFlipType.RotateNoneFlipY); 
			pictureBox2.Refresh();
		}

		private void mirrorXYButton_Click(object sender, System.EventArgs e)
		{
			Image image = pictureBox2.Image;
			image.RotateFlip(RotateFlipType.Rotate90FlipXY); 
			pictureBox2.Refresh();
		}

		private void rotateAngleButton_Click(object sender, System.EventArgs e)
		{
			Image image = pictureBox2.Image;
			float angle = Convert.ToSingle(this.angleTextBox.Text);
			
			pictureBox2.Image = ImageUtils.RotateImage(pictureBox2.Image, angle, Color.Silver,
				resizeBitmapCheckBox.Checked);
			pictureBox2.Refresh();
		}

		private void resetButton_Click(object sender, System.EventArgs e)
		{
			this.pictureBox2.Image = (Image)this.pictureBox1.Image.Clone();
		}
	}
}
