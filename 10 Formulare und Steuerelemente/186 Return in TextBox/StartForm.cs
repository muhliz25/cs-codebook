using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Return_in_TextBox
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox demoTextBox;
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
			this.demoTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// demoTextBox
			// 
			this.demoTextBox.Location = new System.Drawing.Point(32, 24);
			this.demoTextBox.Name = "demoTextBox";
			this.demoTextBox.TabIndex = 0;
			this.demoTextBox.Text = "";
			this.demoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.demoTextBox_KeyPress);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 77);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.demoTextBox});
			this.Name = "StartForm";
			this.Text = "Return in einer TextBox abfangen";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void demoTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				// Ereignis als behandelt kennzeichnen um den Systemton zu verhindern
				e.Handled = true;

				// Weitere Programmierung
				MessageBox.Show("Sie haben Return betätigt");
			}
		}
	}
}
