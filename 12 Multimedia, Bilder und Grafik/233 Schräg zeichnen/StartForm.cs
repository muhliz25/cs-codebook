using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Gedreht_zeichnen
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button rotateAtDefinedMiddleButton;
		private System.Windows.Forms.Button drawRectanglesButton;
		private System.Windows.Forms.Button drawTextButton;
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
			this.drawRectanglesButton = new System.Windows.Forms.Button();
			this.rotateAtDefinedMiddleButton = new System.Windows.Forms.Button();
			this.drawTextButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.White;
			this.pictureBox1.Location = new System.Drawing.Point(8, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(336, 256);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// drawRectanglesButton
			// 
			this.drawRectanglesButton.Location = new System.Drawing.Point(8, 320);
			this.drawRectanglesButton.Name = "drawRectanglesButton";
			this.drawRectanglesButton.Size = new System.Drawing.Size(184, 23);
			this.drawRectanglesButton.TabIndex = 1;
			this.drawRectanglesButton.Text = "Mehrere Rechtecke zeichnen";
			this.drawRectanglesButton.Click += new System.EventHandler(this.drawRectanglesButton_Click);
			// 
			// rotateAtDefinedMiddleButton
			// 
			this.rotateAtDefinedMiddleButton.Location = new System.Drawing.Point(8, 352);
			this.rotateAtDefinedMiddleButton.Name = "rotateAtDefinedMiddleButton";
			this.rotateAtDefinedMiddleButton.Size = new System.Drawing.Size(184, 23);
			this.rotateAtDefinedMiddleButton.TabIndex = 2;
			this.rotateAtDefinedMiddleButton.Text = "Um definierten Mittelpunkt drehen";
			this.rotateAtDefinedMiddleButton.Click += new System.EventHandler(this.rotateAtDefinedMiddleButton_Click);
			// 
			// drawTextButton
			// 
			this.drawTextButton.Location = new System.Drawing.Point(8, 288);
			this.drawTextButton.Name = "drawTextButton";
			this.drawTextButton.Size = new System.Drawing.Size(184, 23);
			this.drawTextButton.TabIndex = 3;
			this.drawTextButton.Text = "Text schräg ausgeben";
			this.drawTextButton.Click += new System.EventHandler(this.drawTextButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 389);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.drawTextButton,
																		  this.rotateAtDefinedMiddleButton,
																		  this.drawRectanglesButton,
																		  this.pictureBox1});
			this.Name = "StartForm";
			this.Text = "Gedreht zeichnen";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}


		private void rotateAtDefinedMiddleButton_Click(object sender, System.EventArgs e)
		{
			Graphics g = Graphics.FromHwnd(this.pictureBox1.Handle);

			// SmoothingMode auf HighQuality einstellen, damit die Linien sauber
			// gezeichnet werden
			g.SmoothingMode = SmoothingMode.HighQuality;

			// Matrix-Objekt für die eigene Transformation erstellen und
			// initialisieren (aus mir vollkommen unklaren Gründen funktioniert
			// die Transformation nicht direkt über g.Transform !?) 
			Matrix matrix = new Matrix();

			// Transformation so einstellen, dass die Matrix so verschoben
			// wird, dass die Zeichnung in der Mitte der PictureBox erscheint
			// und dass eine Drehung des Bildes um den Mittelpunkt und um 20 Grad erfolgt
			const int rectangleSize = 150;
			matrix.Translate ((int)((pictureBox1.Width / 2) - (rectangleSize / 2)) , 
				(int)((pictureBox1.Height / 2) - (rectangleSize / 2)), 
				MatrixOrder.Prepend);
			matrix.RotateAt(20, new Point(rectangleSize / 2, rectangleSize / 2), 
				MatrixOrder.Prepend); 

			// Die neue Transformationsmatrix zuweisen
			g.Transform = matrix;

			// Zeichnen
			g.FillRectangle(new SolidBrush(Color.Blue), 0, 0, rectangleSize, 
				rectangleSize);
			g.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1), 0, 0, 
				rectangleSize, rectangleSize);

			g.Dispose();
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
			// Automatisches Neuzeichnen einstellen
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
		}

		private void drawRectanglesButton_Click(object sender, System.EventArgs e)
		{
			Graphics g = Graphics.FromHwnd(this.pictureBox1.Handle);
			
			// Pens, Brush und Font für das Zeichnen erzeugen
			Pen blackPen = new Pen(new SolidBrush(Color.Black), 1);
			Brush blackBrush = new SolidBrush(Color.Black);
			Font captionFont = new Font("Arial", 8);

			// Zeichenmatrix so verschieben, dass die nachfolgenden
			// Zeichnungen in der Mitte der PictureBox erscheinen
			g.TranslateTransform((int)(pictureBox1.Width / 2), (int)(pictureBox1.Height / 2), 
				MatrixOrder.Prepend);
			
			// SmoothingMode auf HighQuality einstellen, damit die Linien sauber
			// gezeichnet werden
			g.SmoothingMode = SmoothingMode.HighQuality;
			
			// Zwölf Rechtecke mit Beschriftung zeichnen und dabei die 
			// Zeichenmatrix um jeweil 30 Grad drehen
			for (int i = 1; i < 13; i++)
			{
				g.RotateTransform(30, MatrixOrder.Prepend);
				g.FillRectangle(new SolidBrush(Color.FromArgb(255 - i * 10, 255 - i * 10, 255 - i * 10)) , 0, 0, 80, 80);
				g.DrawRectangle(blackPen, 0, 0, 80, 80);
				g.DrawString("Rechteck " + i, captionFont, blackBrush, 5, 5);
			}

			// Transformation wieder zurücksetzen
			g.ResetTransform();

			// Kreis zeichnen
			int x = 120;
			g.DrawEllipse(blackPen, (int)((pictureBox1.Width / 2) - (x / 2)), 
				(int)((pictureBox1.Height / 2) - (x / 2)), x, x);

			g.Dispose();
		}

		private void drawTextButton_Click(object sender, System.EventArgs e)
		{
			Graphics g = Graphics.FromHwnd(this.pictureBox1.Handle);

			// Zeichenmatrix so verschieben, dass die nachfolgenden
			// Zeichnungen ab der Position 10, 10 um 30 Grad gedreht erscheinen
			g.TranslateTransform(30, 30, MatrixOrder.Prepend);
			g.RotateTransform(30, MatrixOrder.Prepend);

			// SmoothingMode auf HighQuality einstellen, damit die Linien sauber
			// gezeichnet werden
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;

			// Text ausgeben
			g.DrawString("Das ist ein gedrehter Text", new Font("Arial", 20),  new SolidBrush(Color.Black), 0, 0);

			// Transformation wieder zurücksetzen
			g.ResetTransform();

			// Text ausgeben
			g.DrawString("Das ist ein gerader Text", new Font("Arial", 20),  new SolidBrush(Color.Black), 0, 0);

			g.Dispose();
		}
	}
}
