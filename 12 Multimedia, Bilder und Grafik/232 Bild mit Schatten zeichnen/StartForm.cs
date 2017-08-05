using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.Images;
using System.Reflection;

namespace Bild_mit_Schatten_zeichnen
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
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "StartForm";
			this.Text = "Bild mit Schatten zeichnen";
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
			// Bild aus der Ressource laden und auf dem Formular mit Schatten ausgeben
			Assembly assembly = Assembly.GetExecutingAssembly();
			Bitmap bitmap = new Bitmap(assembly.GetManifestResourceStream(
				"Bild_mit_Schatten_zeichnen.Hitchhiker.jpg"));
			ImageUtils.DrawBitmapWithShadow(e.Graphics, bitmap, 10, 10, 6);


			
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
