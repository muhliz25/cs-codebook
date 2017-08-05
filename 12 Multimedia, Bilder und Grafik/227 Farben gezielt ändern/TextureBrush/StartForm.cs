using System;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TextureBrush_Demo
{
	public class StartForm: System.Windows.Forms.Form
	{
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
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackgroundImage = ((System.Drawing.Bitmap)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "StartForm";
			this.Text = "Farben bei einem TextureBrush ändern";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.StartForm_Paint);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void StartForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			// Bild für die Textur aus der Ressource einlesen
			Assembly assembly = Assembly.GetExecutingAssembly();
			Bitmap textureBitmap = new Bitmap(assembly.GetManifestResourceStream(
				assembly.GetName().Name + ".texture.jpg"));
			
			// ColorMatrix- und ImageAttributes-Objekt für die 
			// Transformation der Farben erzeugen (der Alpha-Wert wird auf 70% reduziert)
			ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
				new float[] {1, 0, 0, 0, 0},
				new float[] {0, 1, 0, 0, 0},
				new float[] {0, 0, 1, 0, 0},
				new float[] {0, 0, 0, 0.7F, 0},
				new float[] {0, 0, 0, 0, 1}
			});
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(colorMatrix);
			
			// TextureBrush erzeugen
			TextureBrush brush = new TextureBrush(textureBitmap, new RectangleF(0, 0, textureBitmap.Width,
				textureBitmap.Height), imageAttributes);
			brush.WrapMode = WrapMode.TileFlipXY;
			
			Graphics g = e.Graphics;
			g.SmoothingMode = SmoothingMode.HighQuality;

			// Rechteck und Kreis mit der Textur zeichnen
			g.FillRectangle(brush, 20, 20, 200, 100);
			g.FillEllipse(brush, 70, 50, 150, 150);


			g.Dispose();

		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
		
		}

	}
}
