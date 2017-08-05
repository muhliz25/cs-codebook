using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace Formulare_mit_freien_Formen
{
	public class ShapedForm1: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button endButton;
		private System.ComponentModel.Container components = null;

		public ShapedForm1()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ShapedForm1));
			this.endButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// endButton
			// 
			this.endButton.BackgroundImage = ((System.Drawing.Bitmap)(resources.GetObject("endButton.BackgroundImage")));
			this.endButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.endButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.endButton.ForeColor = System.Drawing.Color.MediumBlue;
			this.endButton.Location = new System.Drawing.Point(120, 120);
			this.endButton.Name = "endButton";
			this.endButton.TabIndex = 0;
			this.endButton.Text = "OK";
			this.endButton.Click += new System.EventHandler(this.endButton_Click);
			// 
			// ShapedForm1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(320, 208);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.endButton});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ShapedForm1";
			this.TransparencyKey = System.Drawing.Color.Silver;
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ShapedForm1_Paint);
			this.ResumeLayout(false);

		}
		#endregion

		protected override void WndProc(ref Message m)
		{
			const int WM_NCHITTEST = 0x0084;
			const int HTCAPTION = 2;

			// Abfangen der Nachricht WM_NCHITTEST
			if (m.Msg == WM_NCHITTEST)
			{
				if (this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
				{
					// Wenn der Cursor sich im CLientbereich des Formulars befindet:
					// Simulieren, dass der Cursor sich auf der Titelleiste befindet
					m.Result = (IntPtr)HTCAPTION;
					return;
				}
			} 
   
			base.WndProc(ref m);
		}

		private void endButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void ShapedForm1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			// Die beiden Texturen aus der Ressource lesen und damit zwei
			// TextureBrush-Objekte für das Zeichnen erzeugen
			Assembly assembly = Assembly.GetExecutingAssembly();
			TextureBrush brush1 = new TextureBrush(new Bitmap(
				assembly.GetManifestResourceStream(
				"Formulare_mit_freien_Formen.texture1.jpg")));
			TextureBrush brush2 = new TextureBrush(new Bitmap(
				assembly.GetManifestResourceStream(
				"Formulare_mit_freien_Formen.texture2.jpg")));

			// Gefülltes Rechteck und gefüllten Kreis zeichnen
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.FillRectangle(brush1, 0, 40, 300, 100);
			g.FillEllipse(brush2, 65, 5, 180, 180);
		}
	}
}
