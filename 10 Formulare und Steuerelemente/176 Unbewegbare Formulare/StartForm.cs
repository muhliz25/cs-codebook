using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace Unbewegbare_Formulare
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
			this.Text = "Unbewegbare Formulare";
			this.Load += new System.EventHandler(this.StartForm_Load);

		}
		#endregion


		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		/* Deklaration der benötigten API-Funktionen und -Konstanten */
		[DllImport("user32.dll")]
		private static extern IntPtr GetSystemMenu(IntPtr hWnd, int bRevert);

		[DllImport("user32.dll")]
		private static extern int DeleteMenu(IntPtr hMenu, int uPosition, int uFlags);		

		private const int SC_MOVE = 0xF010;
		private const int MF_BYCOMMAND = 0;

		/* Unbewegbar-Machen des Formulars im Load-Ereignis */
		private void StartForm_Load(object sender, System.EventArgs e)
		{
			// Handle des Systemmenüs ermitteln und den Verschieben-Befehl löschen
			IntPtr sysMenuHandle = GetSystemMenu(this.Handle, 0);
			DeleteMenu(sysMenuHandle, SC_MOVE, MF_BYCOMMAND);
		}
	}
}
