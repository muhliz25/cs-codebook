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
		private ImageForm imageForm;
		private System.Windows.Forms.Button readImageButton;
		private System.Windows.Forms.Button colorTranslateButton;
		private System.Windows.Forms.TextBox matrix00;
		private System.Windows.Forms.TextBox matrix01;
		private System.Windows.Forms.TextBox matrix02;
		private System.Windows.Forms.TextBox matrix03;
		private System.Windows.Forms.TextBox matrix04;
		private System.Windows.Forms.TextBox matrix14;
		private System.Windows.Forms.TextBox matrix13;
		private System.Windows.Forms.TextBox matrix12;
		private System.Windows.Forms.TextBox matrix11;
		private System.Windows.Forms.TextBox matrix10;
		private System.Windows.Forms.TextBox matrix24;
		private System.Windows.Forms.TextBox matrix23;
		private System.Windows.Forms.TextBox matrix22;
		private System.Windows.Forms.TextBox matrix21;
		private System.Windows.Forms.TextBox matrix20;
		private System.Windows.Forms.TextBox matrix34;
		private System.Windows.Forms.TextBox matrix33;
		private System.Windows.Forms.TextBox matrix32;
		private System.Windows.Forms.TextBox matrix31;
		private System.Windows.Forms.TextBox matrix30;
		private System.Windows.Forms.TextBox matrix44;
		private System.Windows.Forms.TextBox matrix43;
		private System.Windows.Forms.TextBox matrix42;
		private System.Windows.Forms.TextBox matrix41;
		private System.Windows.Forms.TextBox matrix40;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button colorTableButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox resultValueBlue;
		private System.Windows.Forms.TextBox resultValueGreen;
		private System.Windows.Forms.TextBox resultValueRed;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox inputValueBlue;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox inputValueGreen;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox inputValueRed;
		private System.Windows.Forms.Button testButton;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox resultValueAlpha;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox inputValueAlpha;
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
			this.readImageButton = new System.Windows.Forms.Button();
			this.colorTranslateButton = new System.Windows.Forms.Button();
			this.matrix00 = new System.Windows.Forms.TextBox();
			this.matrix01 = new System.Windows.Forms.TextBox();
			this.matrix02 = new System.Windows.Forms.TextBox();
			this.matrix03 = new System.Windows.Forms.TextBox();
			this.matrix04 = new System.Windows.Forms.TextBox();
			this.matrix14 = new System.Windows.Forms.TextBox();
			this.matrix13 = new System.Windows.Forms.TextBox();
			this.matrix12 = new System.Windows.Forms.TextBox();
			this.matrix11 = new System.Windows.Forms.TextBox();
			this.matrix10 = new System.Windows.Forms.TextBox();
			this.matrix24 = new System.Windows.Forms.TextBox();
			this.matrix23 = new System.Windows.Forms.TextBox();
			this.matrix22 = new System.Windows.Forms.TextBox();
			this.matrix21 = new System.Windows.Forms.TextBox();
			this.matrix20 = new System.Windows.Forms.TextBox();
			this.matrix34 = new System.Windows.Forms.TextBox();
			this.matrix33 = new System.Windows.Forms.TextBox();
			this.matrix32 = new System.Windows.Forms.TextBox();
			this.matrix31 = new System.Windows.Forms.TextBox();
			this.matrix30 = new System.Windows.Forms.TextBox();
			this.matrix44 = new System.Windows.Forms.TextBox();
			this.matrix43 = new System.Windows.Forms.TextBox();
			this.matrix42 = new System.Windows.Forms.TextBox();
			this.matrix41 = new System.Windows.Forms.TextBox();
			this.matrix40 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.colorTableButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.testButton = new System.Windows.Forms.Button();
			this.resultValueBlue = new System.Windows.Forms.TextBox();
			this.resultValueGreen = new System.Windows.Forms.TextBox();
			this.resultValueRed = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.inputValueBlue = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.inputValueGreen = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.inputValueRed = new System.Windows.Forms.TextBox();
			this.resultValueAlpha = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.inputValueAlpha = new System.Windows.Forms.TextBox();
			this.demoButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// readImageButton
			// 
			this.readImageButton.Location = new System.Drawing.Point(8, 56);
			this.readImageButton.Name = "readImageButton";
			this.readImageButton.Size = new System.Drawing.Size(192, 23);
			this.readImageButton.TabIndex = 4;
			this.readImageButton.Text = "Bild einlesen";
			this.readImageButton.Click += new System.EventHandler(this.readOriginalButton_Click);
			// 
			// colorTranslateButton
			// 
			this.colorTranslateButton.Location = new System.Drawing.Point(8, 120);
			this.colorTranslateButton.Name = "colorTranslateButton";
			this.colorTranslateButton.Size = new System.Drawing.Size(192, 23);
			this.colorTranslateButton.TabIndex = 3;
			this.colorTranslateButton.Text = "Farb-Umwandlung";
			this.colorTranslateButton.Click += new System.EventHandler(this.colorTranslateButton_Click);
			// 
			// matrix00
			// 
			this.matrix00.Location = new System.Drawing.Point(8, 176);
			this.matrix00.Name = "matrix00";
			this.matrix00.Size = new System.Drawing.Size(24, 20);
			this.matrix00.TabIndex = 5;
			this.matrix00.Text = "1";
			// 
			// matrix01
			// 
			this.matrix01.Location = new System.Drawing.Point(40, 176);
			this.matrix01.Name = "matrix01";
			this.matrix01.Size = new System.Drawing.Size(24, 20);
			this.matrix01.TabIndex = 6;
			this.matrix01.Text = "0";
			// 
			// matrix02
			// 
			this.matrix02.Location = new System.Drawing.Point(72, 176);
			this.matrix02.Name = "matrix02";
			this.matrix02.Size = new System.Drawing.Size(24, 20);
			this.matrix02.TabIndex = 7;
			this.matrix02.Text = "0";
			// 
			// matrix03
			// 
			this.matrix03.Location = new System.Drawing.Point(104, 176);
			this.matrix03.Name = "matrix03";
			this.matrix03.Size = new System.Drawing.Size(24, 20);
			this.matrix03.TabIndex = 8;
			this.matrix03.Text = "0";
			// 
			// matrix04
			// 
			this.matrix04.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.matrix04.Enabled = false;
			this.matrix04.Location = new System.Drawing.Point(136, 176);
			this.matrix04.Name = "matrix04";
			this.matrix04.Size = new System.Drawing.Size(24, 20);
			this.matrix04.TabIndex = 9;
			this.matrix04.Text = "0";
			// 
			// matrix14
			// 
			this.matrix14.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.matrix14.Enabled = false;
			this.matrix14.Location = new System.Drawing.Point(136, 200);
			this.matrix14.Name = "matrix14";
			this.matrix14.Size = new System.Drawing.Size(24, 20);
			this.matrix14.TabIndex = 14;
			this.matrix14.Text = "0";
			// 
			// matrix13
			// 
			this.matrix13.Location = new System.Drawing.Point(104, 200);
			this.matrix13.Name = "matrix13";
			this.matrix13.Size = new System.Drawing.Size(24, 20);
			this.matrix13.TabIndex = 13;
			this.matrix13.Text = "0";
			// 
			// matrix12
			// 
			this.matrix12.Location = new System.Drawing.Point(72, 200);
			this.matrix12.Name = "matrix12";
			this.matrix12.Size = new System.Drawing.Size(24, 20);
			this.matrix12.TabIndex = 12;
			this.matrix12.Text = "0";
			// 
			// matrix11
			// 
			this.matrix11.Location = new System.Drawing.Point(40, 200);
			this.matrix11.Name = "matrix11";
			this.matrix11.Size = new System.Drawing.Size(24, 20);
			this.matrix11.TabIndex = 11;
			this.matrix11.Text = "1";
			// 
			// matrix10
			// 
			this.matrix10.Location = new System.Drawing.Point(8, 200);
			this.matrix10.Name = "matrix10";
			this.matrix10.Size = new System.Drawing.Size(24, 20);
			this.matrix10.TabIndex = 10;
			this.matrix10.Text = "0";
			// 
			// matrix24
			// 
			this.matrix24.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.matrix24.Enabled = false;
			this.matrix24.Location = new System.Drawing.Point(136, 224);
			this.matrix24.Name = "matrix24";
			this.matrix24.Size = new System.Drawing.Size(24, 20);
			this.matrix24.TabIndex = 19;
			this.matrix24.Text = "0";
			// 
			// matrix23
			// 
			this.matrix23.Location = new System.Drawing.Point(104, 224);
			this.matrix23.Name = "matrix23";
			this.matrix23.Size = new System.Drawing.Size(24, 20);
			this.matrix23.TabIndex = 18;
			this.matrix23.Text = "0";
			// 
			// matrix22
			// 
			this.matrix22.Location = new System.Drawing.Point(72, 224);
			this.matrix22.Name = "matrix22";
			this.matrix22.Size = new System.Drawing.Size(24, 20);
			this.matrix22.TabIndex = 17;
			this.matrix22.Text = "1";
			// 
			// matrix21
			// 
			this.matrix21.Location = new System.Drawing.Point(40, 224);
			this.matrix21.Name = "matrix21";
			this.matrix21.Size = new System.Drawing.Size(24, 20);
			this.matrix21.TabIndex = 16;
			this.matrix21.Text = "0";
			// 
			// matrix20
			// 
			this.matrix20.Location = new System.Drawing.Point(8, 224);
			this.matrix20.Name = "matrix20";
			this.matrix20.Size = new System.Drawing.Size(24, 20);
			this.matrix20.TabIndex = 15;
			this.matrix20.Text = "0";
			// 
			// matrix34
			// 
			this.matrix34.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.matrix34.Enabled = false;
			this.matrix34.Location = new System.Drawing.Point(136, 248);
			this.matrix34.Name = "matrix34";
			this.matrix34.Size = new System.Drawing.Size(24, 20);
			this.matrix34.TabIndex = 24;
			this.matrix34.Text = "0";
			// 
			// matrix33
			// 
			this.matrix33.Location = new System.Drawing.Point(104, 248);
			this.matrix33.Name = "matrix33";
			this.matrix33.Size = new System.Drawing.Size(24, 20);
			this.matrix33.TabIndex = 23;
			this.matrix33.Text = "1";
			// 
			// matrix32
			// 
			this.matrix32.Location = new System.Drawing.Point(72, 248);
			this.matrix32.Name = "matrix32";
			this.matrix32.Size = new System.Drawing.Size(24, 20);
			this.matrix32.TabIndex = 22;
			this.matrix32.Text = "0";
			// 
			// matrix31
			// 
			this.matrix31.Location = new System.Drawing.Point(40, 248);
			this.matrix31.Name = "matrix31";
			this.matrix31.Size = new System.Drawing.Size(24, 20);
			this.matrix31.TabIndex = 21;
			this.matrix31.Text = "0";
			// 
			// matrix30
			// 
			this.matrix30.Location = new System.Drawing.Point(8, 248);
			this.matrix30.Name = "matrix30";
			this.matrix30.Size = new System.Drawing.Size(24, 20);
			this.matrix30.TabIndex = 20;
			this.matrix30.Text = "0";
			// 
			// matrix44
			// 
			this.matrix44.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.matrix44.Enabled = false;
			this.matrix44.Location = new System.Drawing.Point(136, 272);
			this.matrix44.Name = "matrix44";
			this.matrix44.Size = new System.Drawing.Size(24, 20);
			this.matrix44.TabIndex = 29;
			this.matrix44.Text = "1";
			// 
			// matrix43
			// 
			this.matrix43.Location = new System.Drawing.Point(104, 272);
			this.matrix43.Name = "matrix43";
			this.matrix43.Size = new System.Drawing.Size(24, 20);
			this.matrix43.TabIndex = 28;
			this.matrix43.Text = "0";
			// 
			// matrix42
			// 
			this.matrix42.Location = new System.Drawing.Point(72, 272);
			this.matrix42.Name = "matrix42";
			this.matrix42.Size = new System.Drawing.Size(24, 20);
			this.matrix42.TabIndex = 27;
			this.matrix42.Text = "0";
			// 
			// matrix41
			// 
			this.matrix41.Location = new System.Drawing.Point(40, 272);
			this.matrix41.Name = "matrix41";
			this.matrix41.Size = new System.Drawing.Size(24, 20);
			this.matrix41.TabIndex = 26;
			this.matrix41.Text = "0";
			// 
			// matrix40
			// 
			this.matrix40.Location = new System.Drawing.Point(8, 272);
			this.matrix40.Name = "matrix40";
			this.matrix40.Size = new System.Drawing.Size(24, 20);
			this.matrix40.TabIndex = 25;
			this.matrix40.Text = "0";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 160);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 30;
			this.label1.Text = "Farbmatrix";
			// 
			// colorTableButton
			// 
			this.colorTableButton.Location = new System.Drawing.Point(8, 88);
			this.colorTableButton.Name = "colorTableButton";
			this.colorTableButton.Size = new System.Drawing.Size(192, 23);
			this.colorTableButton.TabIndex = 31;
			this.colorTableButton.Text = "Farb-Tabelle";
			this.colorTableButton.Click += new System.EventHandler(this.colorTableButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.resultValueAlpha,
																					this.label11,
																					this.inputValueAlpha,
																					this.label9,
																					this.label8,
																					this.testButton,
																					this.resultValueBlue,
																					this.resultValueGreen,
																					this.resultValueRed,
																					this.label4,
																					this.inputValueBlue,
																					this.label3,
																					this.inputValueGreen,
																					this.label2,
																					this.inputValueRed});
			this.groupBox1.Location = new System.Drawing.Point(184, 168);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(280, 200);
			this.groupBox1.TabIndex = 45;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Transformations-Test";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(144, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 16);
			this.label9.TabIndex = 59;
			this.label9.Text = "Ergebnis:";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(56, 32);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 16);
			this.label8.TabIndex = 58;
			this.label8.Text = "Original-Farbe:";
			// 
			// testButton
			// 
			this.testButton.BackColor = System.Drawing.SystemColors.Control;
			this.testButton.Location = new System.Drawing.Point(8, 160);
			this.testButton.Name = "testButton";
			this.testButton.Size = new System.Drawing.Size(96, 23);
			this.testButton.TabIndex = 57;
			this.testButton.Text = "Test";
			this.testButton.Click += new System.EventHandler(this.testButton_Click);
			// 
			// resultValueBlue
			// 
			this.resultValueBlue.Location = new System.Drawing.Point(144, 104);
			this.resultValueBlue.Name = "resultValueBlue";
			this.resultValueBlue.Size = new System.Drawing.Size(32, 20);
			this.resultValueBlue.TabIndex = 55;
			this.resultValueBlue.Text = "32";
			// 
			// resultValueGreen
			// 
			this.resultValueGreen.Location = new System.Drawing.Point(144, 80);
			this.resultValueGreen.Name = "resultValueGreen";
			this.resultValueGreen.Size = new System.Drawing.Size(32, 20);
			this.resultValueGreen.TabIndex = 53;
			this.resultValueGreen.Text = "32";
			// 
			// resultValueRed
			// 
			this.resultValueRed.Location = new System.Drawing.Point(144, 56);
			this.resultValueRed.Name = "resultValueRed";
			this.resultValueRed.Size = new System.Drawing.Size(32, 20);
			this.resultValueRed.TabIndex = 51;
			this.resultValueRed.Text = "32";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 16);
			this.label4.TabIndex = 50;
			this.label4.Text = "Blau:";
			// 
			// inputValueBlue
			// 
			this.inputValueBlue.Location = new System.Drawing.Point(56, 104);
			this.inputValueBlue.Name = "inputValueBlue";
			this.inputValueBlue.Size = new System.Drawing.Size(32, 20);
			this.inputValueBlue.TabIndex = 49;
			this.inputValueBlue.Text = "32";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 48;
			this.label3.Text = "Grün:";
			// 
			// inputValueGreen
			// 
			this.inputValueGreen.Location = new System.Drawing.Point(56, 80);
			this.inputValueGreen.Name = "inputValueGreen";
			this.inputValueGreen.Size = new System.Drawing.Size(32, 20);
			this.inputValueGreen.TabIndex = 47;
			this.inputValueGreen.Text = "32";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 46;
			this.label2.Text = "Rot:";
			// 
			// inputValueRed
			// 
			this.inputValueRed.Location = new System.Drawing.Point(56, 56);
			this.inputValueRed.Name = "inputValueRed";
			this.inputValueRed.Size = new System.Drawing.Size(32, 20);
			this.inputValueRed.TabIndex = 45;
			this.inputValueRed.Text = "32";
			// 
			// resultValueAlpha
			// 
			this.resultValueAlpha.Location = new System.Drawing.Point(144, 128);
			this.resultValueAlpha.Name = "resultValueAlpha";
			this.resultValueAlpha.Size = new System.Drawing.Size(32, 20);
			this.resultValueAlpha.TabIndex = 62;
			this.resultValueAlpha.Text = "255";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 128);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(40, 16);
			this.label11.TabIndex = 61;
			this.label11.Text = "Alpha:";
			// 
			// inputValueAlpha
			// 
			this.inputValueAlpha.Location = new System.Drawing.Point(56, 128);
			this.inputValueAlpha.Name = "inputValueAlpha";
			this.inputValueAlpha.Size = new System.Drawing.Size(32, 20);
			this.inputValueAlpha.TabIndex = 60;
			this.inputValueAlpha.Text = "255";
			// 
			// demoButton
			// 
			this.demoButton.Location = new System.Drawing.Point(8, 24);
			this.demoButton.Name = "demoButton";
			this.demoButton.Size = new System.Drawing.Size(192, 23);
			this.demoButton.TabIndex = 46;
			this.demoButton.Text = "Einfache Demo";
			this.demoButton.Click += new System.EventHandler(this.demoButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 389);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.demoButton,
																		  this.groupBox1,
																		  this.colorTableButton,
																		  this.label1,
																		  this.matrix44,
																		  this.matrix43,
																		  this.matrix42,
																		  this.matrix41,
																		  this.matrix40,
																		  this.matrix34,
																		  this.matrix33,
																		  this.matrix32,
																		  this.matrix31,
																		  this.matrix30,
																		  this.matrix24,
																		  this.matrix23,
																		  this.matrix22,
																		  this.matrix21,
																		  this.matrix20,
																		  this.matrix14,
																		  this.matrix13,
																		  this.matrix12,
																		  this.matrix11,
																		  this.matrix10,
																		  this.matrix04,
																		  this.matrix03,
																		  this.matrix02,
																		  this.matrix01,
																		  this.matrix00,
																		  this.readImageButton,
																		  this.colorTranslateButton});
			this.Name = "StartForm";
			this.Text = "Farbinformationen verändern";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.groupBox1.ResumeLayout(false);
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
			imageForm = new ImageForm();
			// Original einlesen und als Hintergrund darstellen
			string fileName = Path.Combine(Application.StartupPath, "Les Crosets.jpg");
			imageForm.BackgroundImage = new Bitmap(fileName);
			imageForm.Show();
		}

		private void readOriginalButton_Click(object sender, System.EventArgs e)
		{
			// Original einlesen und als Hintergrund darstellen
			string fileName = Path.Combine(Application.StartupPath, "Les Crosets.jpg");
			if (imageForm.Created == false)
			{
				imageForm = new ImageForm();
			}
			imageForm.BackgroundImage = new Bitmap(fileName);
			imageForm.Show();
		}

		private void colorTranslateButton_Click(object sender, System.EventArgs e)
		{
			if (imageForm.Created == false)
			{
				// Bild einlesen
				imageForm = new ImageForm();
				string fileName = Path.Combine(Application.StartupPath, "Les Crosets.jpg");
				imageForm.BackgroundImage = new Bitmap(fileName);
				imageForm.Show();
			}

			Bitmap sourceBitmap = (Bitmap)imageForm.BackgroundImage;

			// Neues Bitmap mit den Ausmaßen des Originals erzeugen
			Bitmap destBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

			// ColorMatrix für die Transformation der Farben erzeugen
			/*
			ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
				new float[] {1, 0, 0, 0, 0},
				new float[] {0, 1, 0, 0, 0},
				new float[] {0, 0, 1, 0, 0},
				new float[] {0, 0, 0, 1, 0},
				new float[] {0, 0, 0, 0, 1}
				});
			*/

			ColorMatrix colorMatrix = new ColorMatrix();
			colorMatrix.Matrix00 = Convert.ToSingle(this.matrix00.Text);
			colorMatrix.Matrix01 = Convert.ToSingle(this.matrix01.Text);
			colorMatrix.Matrix02 = Convert.ToSingle(this.matrix02.Text);
			colorMatrix.Matrix03 = Convert.ToSingle(this.matrix03.Text);
			colorMatrix.Matrix04 = Convert.ToSingle(this.matrix04.Text);
			colorMatrix.Matrix10 = Convert.ToSingle(this.matrix10.Text);
			colorMatrix.Matrix11 = Convert.ToSingle(this.matrix11.Text);
			colorMatrix.Matrix12 = Convert.ToSingle(this.matrix12.Text);
			colorMatrix.Matrix13 = Convert.ToSingle(this.matrix13.Text);
			colorMatrix.Matrix14 = Convert.ToSingle(this.matrix14.Text);
			colorMatrix.Matrix20 = Convert.ToSingle(this.matrix20.Text);
			colorMatrix.Matrix21 = Convert.ToSingle(this.matrix21.Text);
			colorMatrix.Matrix22 = Convert.ToSingle(this.matrix22.Text);
			colorMatrix.Matrix23 = Convert.ToSingle(this.matrix23.Text);
			colorMatrix.Matrix24 = Convert.ToSingle(this.matrix24.Text);
			colorMatrix.Matrix30 = Convert.ToSingle(this.matrix30.Text);
			colorMatrix.Matrix31 = Convert.ToSingle(this.matrix31.Text);
			colorMatrix.Matrix32 = Convert.ToSingle(this.matrix32.Text);
			colorMatrix.Matrix33 = Convert.ToSingle(this.matrix33.Text);
			colorMatrix.Matrix34 = Convert.ToSingle(this.matrix34.Text);
			colorMatrix.Matrix40 = Convert.ToSingle(this.matrix40.Text);
			colorMatrix.Matrix41 = Convert.ToSingle(this.matrix41.Text);
			colorMatrix.Matrix42 = Convert.ToSingle(this.matrix42.Text);
			colorMatrix.Matrix43 = Convert.ToSingle(this.matrix43.Text);
			colorMatrix.Matrix44 = Convert.ToSingle(this.matrix44.Text);

			// Grafik auf dem Bitmap-Objekt ausgeben und dabei ein neues
			// ImageAttributes-Objekt mit der ColorMatrix übergeben 
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(colorMatrix);
			Graphics g = Graphics.FromImage(destBitmap);
			g.DrawImage(sourceBitmap, new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
				0, 0, sourceBitmap.Width, sourceBitmap.Height, GraphicsUnit.Pixel,
				imageAttributes);
			g.Dispose();

			// Neues Bitmap-Objekt als Formularhintergrund setzen
			if (imageForm.Created == false)
			{
				imageForm = new ImageForm();
			}
			imageForm.BackgroundImage = destBitmap;
			imageForm.Show();

		}

		private void colorTableButton_Click(object sender, System.EventArgs e)
		{
			Bitmap bitmap = new Bitmap(imageForm.BackgroundImage.Width, imageForm.BackgroundImage.Height);
			Graphics g = Graphics.FromImage(bitmap);

			if (imageForm.Created == false)
			{
				imageForm = new ImageForm();
			}

			g.Clear(Color.White);
			g.FillRectangle(new SolidBrush(Color.Black), 0, imageForm.ClientRectangle.Height - 50, 50, 50);
			g.FillRectangle(new SolidBrush(Color.FromArgb(255, 0, 0)), 50, imageForm.ClientRectangle.Height - 50, 50, 50);
			g.FillRectangle(new SolidBrush(Color.FromArgb(0, 255, 0)), 100, imageForm.ClientRectangle.Height - 50, 50, 50);
			g.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 255)), 150, imageForm.ClientRectangle.Height - 50, 50, 50);
			g.FillRectangle(new SolidBrush(Color.Yellow), 200, imageForm.ClientRectangle.Height - 50, 50, 50);
			g.FillRectangle(new SolidBrush(Color.FromArgb(128, 128, 128)), 250, imageForm.ClientRectangle.Height - 50, 50, 50);

			imageForm.BackgroundImage = bitmap;
			imageForm.Show();
		}

		private void testButton_Click(object sender, System.EventArgs e)
		{
			// Test-Bitmap mit der angegebenen Farbe erzeugen, transformieren und
			// die Ergebnisfarbe auslesen
			Bitmap bitmap1 = new Bitmap(10, 10);
			Bitmap bitmap2 = new Bitmap(10, 10);
			Graphics g1 = Graphics.FromImage(bitmap1);
			g1.Clear(Color.FromArgb(Convert.ToInt16(this.inputValueAlpha.Text), Convert.ToInt16(this.inputValueRed.Text), Convert.ToInt16(this.inputValueGreen.Text), Convert.ToInt16(this.inputValueBlue.Text)));
			Graphics g2 = Graphics.FromImage(bitmap2);
			
			ColorMatrix colorMatrix = new ColorMatrix();
			colorMatrix.Matrix00 = Convert.ToSingle(this.matrix00.Text);
			colorMatrix.Matrix01 = Convert.ToSingle(this.matrix01.Text);
			colorMatrix.Matrix02 = Convert.ToSingle(this.matrix02.Text);
			colorMatrix.Matrix03 = Convert.ToSingle(this.matrix03.Text);
			colorMatrix.Matrix04 = Convert.ToSingle(this.matrix04.Text);
			colorMatrix.Matrix10 = Convert.ToSingle(this.matrix10.Text);
			colorMatrix.Matrix11 = Convert.ToSingle(this.matrix11.Text);
			colorMatrix.Matrix12 = Convert.ToSingle(this.matrix12.Text);
			colorMatrix.Matrix13 = Convert.ToSingle(this.matrix13.Text);
			colorMatrix.Matrix14 = Convert.ToSingle(this.matrix14.Text);
			colorMatrix.Matrix20 = Convert.ToSingle(this.matrix20.Text);
			colorMatrix.Matrix21 = Convert.ToSingle(this.matrix21.Text);
			colorMatrix.Matrix22 = Convert.ToSingle(this.matrix22.Text);
			colorMatrix.Matrix23 = Convert.ToSingle(this.matrix23.Text);
			colorMatrix.Matrix24 = Convert.ToSingle(this.matrix24.Text);
			colorMatrix.Matrix30 = Convert.ToSingle(this.matrix30.Text);
			colorMatrix.Matrix31 = Convert.ToSingle(this.matrix31.Text);
			colorMatrix.Matrix32 = Convert.ToSingle(this.matrix32.Text);
			colorMatrix.Matrix33 = Convert.ToSingle(this.matrix33.Text);
			colorMatrix.Matrix34 = Convert.ToSingle(this.matrix34.Text);
			colorMatrix.Matrix40 = Convert.ToSingle(this.matrix40.Text);
			colorMatrix.Matrix41 = Convert.ToSingle(this.matrix41.Text);
			colorMatrix.Matrix42 = Convert.ToSingle(this.matrix42.Text);
			colorMatrix.Matrix43 = Convert.ToSingle(this.matrix43.Text);
			colorMatrix.Matrix44 = Convert.ToSingle(this.matrix44.Text);

			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(colorMatrix);
			g2.DrawImage(bitmap1, new Rectangle(0, 0, bitmap1.Width, bitmap1.Height),
				0, 0, bitmap1.Width, bitmap1.Height, GraphicsUnit.Pixel,
				imageAttributes);
			
			g1.Dispose();
			g2.Dispose();

			Color resultColor = bitmap2.GetPixel(1, 1);
			this.resultValueRed.Text = resultColor.R.ToString();
			this.resultValueGreen.Text = resultColor.G.ToString();
			this.resultValueBlue.Text = resultColor.B.ToString();
			this.resultValueAlpha.Text = resultColor.A.ToString();
		}

		private void demoButton_Click(object sender, System.EventArgs e)
		{
			// Bitmap einlesen
			Bitmap sourceBitmap = new Bitmap(Path.Combine(Application.StartupPath, "Zaphod.jpg"));

			// Neues Bitmap mit den Ausmaßen des Originals erzeugen
			Bitmap destBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

			// ColorMatrix für die Transformation der Farben erzeugen
			ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
				new float[] {1, 0, 0, 0, 0},
				new float[] {0, 1, 0, 0, 0},
				new float[] {0, 0, 1, 0, 0},
				new float[] {0, 0, 0, 1, 0},
				new float[] {0.2F, 0.2F, 0.2F, 0, 1}
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

			// Neues Bitmap-Objekt speichern
			destBitmap.Save(@"C:\Zaphod hell.jpg", ImageFormat.Jpeg);

		}

	}
}
