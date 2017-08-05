using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;

namespace Fehlercodes_ermitteln
{
	public class StartForm : System.Windows.Forms.Form
	{
		/* Deklaration der benötigten API-Funktionen und -Konstanten */
		[DllImport("Kernel32.dll")]
		private static extern int FormatMessage(int dwFlags, IntPtr lpSource,
			int dwMessageId, int dwLanguageId, System.Text.StringBuilder lpBuffer, 
			int nSize, string[] Arguments);

		[DllImport("kernel32.dll")]
		static extern IntPtr LoadLibrary(string lpFileName);

		[DllImport("kernel32.dll")]
		static extern IntPtr FreeLibrary(IntPtr hModule);
		
		private const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;
		private const int FORMAT_MESSAGE_FROM_HMODULE = 0x0800;
		
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox dllFileName;
		private System.Windows.Forms.Button readButton;
		private System.Windows.Forms.ListBox errorCodes;
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
			this.label1 = new System.Windows.Forms.Label();
			this.dllFileName = new System.Windows.Forms.TextBox();
			this.readButton = new System.Windows.Forms.Button();
			this.errorCodes = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "DLL-Datei:";
			// 
			// dllFileName
			// 
			this.dllFileName.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.dllFileName.Location = new System.Drawing.Point(80, 24);
			this.dllFileName.Name = "dllFileName";
			this.dllFileName.Size = new System.Drawing.Size(400, 20);
			this.dllFileName.TabIndex = 1;
			this.dllFileName.Text = "System";
			// 
			// readButton
			// 
			this.readButton.Location = new System.Drawing.Point(16, 56);
			this.readButton.Name = "readButton";
			this.readButton.Size = new System.Drawing.Size(136, 24);
			this.readButton.TabIndex = 2;
			this.readButton.Text = "Fehlercodes ermitteln";
			this.readButton.Click += new System.EventHandler(this.readButton_Click);
			// 
			// errorCodes
			// 
			this.errorCodes.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.errorCodes.Location = new System.Drawing.Point(16, 88);
			this.errorCodes.Name = "errorCodes";
			this.errorCodes.Size = new System.Drawing.Size(464, 290);
			this.errorCodes.TabIndex = 3;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 381);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.errorCodes,
																		  this.readButton,
																		  this.dllFileName,
																		  this.label1});
			this.Name = "StartForm";
			this.Text = "Fehlercodes aus dem System oder aus einer DLL ermitteln";
			this.Load += new System.EventHandler(this.StartForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
		
		}

		private void readButton_Click(object sender, System.EventArgs e)
		{
			this.errorCodes.Items.Clear();
			if (this.dllFileName.Text == "" || this.dllFileName.Text == null || this.dllFileName.Text.ToLower() == "system")
			{
				// Meldungen aus dem System auslesen
				for (int i = 0; i < 1000000; i++)
				{
					StringBuilder sb = new StringBuilder(1024); 
					if (FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, (IntPtr)0, i, 0, sb, 1024, null) > 0)
					{
						this.errorCodes.Items.Add(i.ToString() + ": " + sb.ToString());
					}
				}
			}
			else
			{
				IntPtr hModule = LoadLibrary(this.dllFileName.Text);

				// Meldungen aus der DLL auslesen
				for (int i = 0; i < 1000000; i++)
				{
					StringBuilder sb = new StringBuilder(1024); 
					if (FormatMessage(FORMAT_MESSAGE_FROM_HMODULE, hModule, i, 0, sb, 1024, null) > 0)
					{
						this.errorCodes.Items.Add(i.ToString() + ": " + sb.ToString());
					}
				}

				FreeLibrary(hModule);
			}
		}
	}
}
