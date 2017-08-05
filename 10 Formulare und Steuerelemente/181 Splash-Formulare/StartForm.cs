using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Splash_Form
{
	public class StartForm : System.Windows.Forms.Form
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
			this.Text = "Splash-Form-Demo";
			this.Load += new System.EventHandler(this.StartForm_Load);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			// Splash-Formular erzeugen und anzeigen
			SplashForm f = new SplashForm();
			f.Show();
			Application.DoEvents();

			// Simulation einer Initialisierung
			try
			{
				for (int i = 0; i < 100; i++)
				{
					f.infoLabel.Text = "Lese Datensätze. Datensatz " + i;
					f.infoLabel.Refresh();

					System.Threading.Thread.Sleep(30);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim Initialisieren: " + ex.Message, 
					Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}

			// Splash-Formular wieder schließen
			f.Close();

			Application.Run(new StartForm());
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
			/*
			// Splash-Formular erzeugen und anzeigen
			SplashForm f = new SplashForm();
			f.Show();
			Application.DoEvents();

			// Simulation einer Initialisierung
			try
			{
				for (int i = 0; i < 100; i++)
				{
					f.infoLabel.Text = "Lese Datensätze. Datensatz " + i;
					f.infoLabel.Refresh();

					System.Threading.Thread.Sleep(30);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim Initialisieren: " + ex.Message, 
					Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}

			// Splash-Formular wieder schließen
			f.Close();
			*/
		}
	}
}
