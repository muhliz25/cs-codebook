using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Formulare_über_den_Clientbereich_verschieben
{
	public class SendMessageDemoForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Label positionInfoLabel;
		private System.ComponentModel.Container components = null;

		public SendMessageDemoForm()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.positionInfoLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// closeButton
			// 
			this.closeButton.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.closeButton.Location = new System.Drawing.Point(8, 240);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 1;
			this.closeButton.Text = "Schließen";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// positionInfoLabel
			// 
			this.positionInfoLabel.Location = new System.Drawing.Point(8, 16);
			this.positionInfoLabel.Name = "positionInfoLabel";
			this.positionInfoLabel.Size = new System.Drawing.Size(280, 24);
			this.positionInfoLabel.TabIndex = 2;
			// 
			// SendMessageDemoForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.positionInfoLabel,
																		  this.closeButton});
			this.Name = "SendMessageDemoForm";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WndProcDemoForm_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SendMessageDemoForm_MouseMove);
			this.ResumeLayout(false);

		}
		#endregion

		/* Deklaration benötigter API-Funktionen und Konstanten */
		[DllImport("User32.dll")]
		private static extern int SendMessage(IntPtr handle, int msg, int wparam, int lparam);

		[DllImport("User32.dll")]
		public static extern int ReleaseCapture();

		private const int WM_NCLBUTTONDOWN = 0x00A1;
		private const int HTCAPTION = 2;

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void WndProcDemoForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				// Wenn die linke Maustaste betätigt wurde: Maus freigeben
				// und simulieren, dass der Benutzer auf der Titelleiste
				// geklickt hat
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
			}
		}

		private void SendMessageDemoForm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// Dieses Ereignis wird aufgerufen
			this.positionInfoLabel.Text = "Aktuelle Mausposition: " + e.X.ToString() + ", " + e.Y.ToString();
		}
	}
}

