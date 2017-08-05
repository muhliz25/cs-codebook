using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace Schließen_Befehl_entfernen
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button closeButton;

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
			this.closeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(8, 240);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 0;
			this.closeButton.Text = "Schließen";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.closeButton});
			this.Name = "StartForm";
			this.Text = "Schließen-Befehl im Systemmenü entfernen";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		/* Deklaration der benötigten API-Funktionen */
		[DllImport("user32.dll")]
		private static extern IntPtr GetSystemMenu(IntPtr hWnd, int bRevert);

		[DllImport("user32.dll")]
		private static extern int DeleteMenu(IntPtr hMenu, int uPosition, int uFlags);      

		private const int SC_CLOSE = 0xF060;
		private const int MF_BYCOMMAND = 0;
		private const int MF_BYPOSITION = 0x00000400;

		private void StartForm_Load(object sender, System.EventArgs e)
		{
			// Handle des Systemmenüs ermitteln und den Schließen-Befehl und 
			// den nun überflüssigen Separator löschen
			IntPtr sysMenuHandle = GetSystemMenu(this.Handle, 0);
			DeleteMenu(sysMenuHandle, SC_CLOSE, MF_BYCOMMAND);
			DeleteMenu(sysMenuHandle, 5, MF_BYPOSITION);
		}

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
