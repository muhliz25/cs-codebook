using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Textbreite_und__höhe
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
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 125);
			this.Name = "StartForm";
			this.Text = "Textbreite- und höhe ermitteln";
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

			// Ermitteln der Breite und der Höhe des auszugebenden Textes
			string text = "   Test1::::Test2.Test3   ";
			Font font = new Font("Tahoma", 20, FontStyle.Bold);
			StringFormat sf = StringFormat.GenericDefault;
			sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
			SizeF textSize = g.MeasureString(text, font, -1, sf);

			// Text mittig und etwas nach oben versetzt ausgeben
			float x = (this.ClientRectangle.Width - textSize.Width) / 2;
			float y = (this.ClientRectangle.Height - textSize.Height) / 2;
			y -= textSize.Height / 2;
			g.DrawString(text, font, new SolidBrush(Color.Black), x, y);

			// Noch einmal mit einem typografischen StringFormat-Objekt
			sf = StringFormat.GenericTypographic;
			sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
			textSize = g.MeasureString(text, font, -1, sf);
			x = (this.ClientRectangle.Width - textSize.Width) / 2;
			y = ((this.ClientRectangle.Height - textSize.Height) / 2);
			y += textSize.Height / 2;
			g.DrawString(text, font, new SolidBrush(Color.Black), x, y, sf);
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
