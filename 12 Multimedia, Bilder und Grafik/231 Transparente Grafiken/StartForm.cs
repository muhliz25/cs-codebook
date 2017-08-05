using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace Transparente_Grafiken
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
			this.ClientSize = new System.Drawing.Size(416, 309);
			this.Name = "StartForm";
			this.Text = "Transparente Grafiken";
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
			Graphics g = e.Graphics;

			// Halb-Transparentes Rechteck mit Text zeichnen
			Color color = Color.FromArgb(80, 0, 0, 30); 
			g.FillRectangle(new SolidBrush(color), 20, 60, this.ClientRectangle.Width - 40, 60);
			Font font = new Font("Tahoma", 28, FontStyle.Bold);
			SizeF textSize = g.MeasureString("Hitchhiker", font);
			int x = (int)((this.ClientRectangle.Width - textSize.Width) / 2); 
			g.DrawString("Hitchhiker", font, new SolidBrush(color), x, 65); 

			// ColorMap für die Umwandlung aller schwarzen Pixel in
			// durchsichtige Pixel erzeugen
			ColorMap[] colorMap = new ColorMap[1];
			colorMap[0] = new ColorMap();
			colorMap[0].OldColor = Color.Black;
			colorMap[0].NewColor = Color.FromArgb(0, 0, 0, 0);

			// ColorMatrix für die Transformation des Alphawerts erzeugen
			ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
				new float[] {1, 0, 0, 0, 0},
				new float[] {0, 1, 0, 0, 0},
				new float[] {0, 0, 1, 0, 0},
				new float[] {0, 0, 0, 0.6F, 0},
				new float[] {0, 0, 0, 0, 1}
			});

			// Neues ImageAttributes-Objekt erzeugen und das ColorMap- und
			// ColorMatrix-Objekt übergeben 
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetRemapTable(colorMap);
			imageAttributes.SetColorMatrix(colorMatrix);

			// Bitmap aus der Ressource auslesen und zeichnen
			Assembly assembly = Assembly.GetExecutingAssembly();
			Bitmap hitchhikerBitmap = new Bitmap(assembly.GetManifestResourceStream("Transparente_Grafiken.Hitchhiker.bmp"));
			Rectangle destRect = new Rectangle((int)((this.ClientRectangle.Width - hitchhikerBitmap.Width) / 2),
				130, hitchhikerBitmap.Width, hitchhikerBitmap.Height);
			g.DrawImage(hitchhikerBitmap, destRect, 0, 0, hitchhikerBitmap.Width, hitchhikerBitmap.Height, GraphicsUnit.Pixel,
				imageAttributes);

			g.Dispose();
			hitchhikerBitmap.Dispose();
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
