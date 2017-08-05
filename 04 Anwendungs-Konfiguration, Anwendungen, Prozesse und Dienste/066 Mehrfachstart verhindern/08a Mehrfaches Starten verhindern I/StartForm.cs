using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Addison_Wesley.Codebook.Application;

namespace Mehrfachstart_verhindern
{
	public class StartForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label infoLabel;
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
			this.infoLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// infoLabel
			// 
			this.infoLabel.Location = new System.Drawing.Point(8, 16);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(320, 23);
			this.infoLabel.TabIndex = 0;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 245);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.infoLabel});
			this.Name = "StartForm";
			this.Text = "Mehrfaches Starten verhindern I";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.Activated += new System.EventHandler(this.StartForm_Activated);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			/* Anwendung mit dem Startformular starten */
			Application.Run(new StartForm());
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
			// Den Namen das aktuellen Prozesses im Info-Label ausgeben
			this.infoLabel.Text = "Prozessname: " + 
				System.Diagnostics.Process.GetCurrentProcess().ProcessName;
		}

		private void StartForm_Activated(object sender, System.EventArgs e)
		{
			// Überprüfen, ob die Anwendung bereits ausgeführt wird.
			// Da der Fenstertitel des Hauptfensters im Load-Ereignis
			// noch nicht definiert ist, kann die Überprüfung erst
			// im Activated-Ereignis erfolgen
			if (AppUtils.RunningInstance() != null)
			{
				// Die Anwendung wird bereits ausgeführt, also eine Meldung ausgeben 
				// und die Anwendung beenden
				MessageBox.Show("Dieses Programm kann nicht mehrfach ausgeführt werden.",
					Application.ProductName, MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
				Application.Exit();
			}
		}
	}
}
