using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Formulare_über_den_Clientbereich_verschieben
{
	public class WndProcDemoForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Label positionInfoLabel;
		private System.ComponentModel.Container components = null;

		public WndProcDemoForm()
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
			this.positionInfoLabel.Location = new System.Drawing.Point(6, 16);
			this.positionInfoLabel.Name = "positionInfoLabel";
			this.positionInfoLabel.Size = new System.Drawing.Size(280, 24);
			this.positionInfoLabel.TabIndex = 3;
			// 
			// WndProcDemoForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.positionInfoLabel,
																		  this.closeButton});
			this.Name = "WndProcDemoForm";
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WndProcDemoForm_MouseMove);
			this.ResumeLayout(false);

		}
		#endregion

		/* Überschreiben der Methode WndProc um die Nachricht WM_NCHITTEST
		 * abzufangen und zu simulieren, dass der Anwender auf der Titelleiste
		 * geklickt hat */
		protected override void WndProc(ref Message m)
		{
			const int WM_NCHITTEST = 0x0084;
			const int HTCAPTION = 2;

			// Abfangen der Nachricht WM_NCHITTEST
			if (m.Msg == WM_NCHITTEST)
			{
				if (this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
				{
					// Wenn der Cursor sich im Clientbereich des Formulars befindet:
					// Simulieren, dass der Cursor sich auf der Titelleiste befindet
					m.Result = (IntPtr)HTCAPTION;
					return;
				}
			} 
   
			base.WndProc(ref m);
		}

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void WndProcDemoForm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// Dieses Ereignis wird nicht aufgerufen, da WndProc die Mausnachrichten abfängt
			// und nicht weitergibt
			this.positionInfoLabel.Text = "Aktuelle Mausposition: " + e.X.ToString() + ", " + e.Y.ToString();
		}
	}
}
