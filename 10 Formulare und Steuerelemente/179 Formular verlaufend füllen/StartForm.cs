using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Formular_verlaufend_füllen
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
			this.ClientSize = new System.Drawing.Size(312, 293);
			this.Name = "StartForm";
			this.Text = "Formular verlaufend füllen";
			this.Resize += new System.EventHandler(this.StartForm_Resize);
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
			
			// LinearGradientBrush für die verlaufende Füllung erzeugen
			LinearGradientBrush brush = new LinearGradientBrush(
				this.ClientRectangle, Color.Blue, Color.Black, 30, false);

			// Formularfläche mit dem Pinsel füllen
			g.FillRectangle(brush, this.ClientRectangle);
		}

		private void StartForm_Resize(object sender, System.EventArgs e)
		{
			this.Invalidate();
		}
	}
}
