using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Formulare_über_den_Clientbereich_verschieben
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Button wndProcDemo;
		private System.Windows.Forms.Button sendMessageDemo;
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
			this.closeButton = new System.Windows.Forms.Button();
			this.wndProcDemo = new System.Windows.Forms.Button();
			this.sendMessageDemo = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// closeButton
			// 
			this.closeButton.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.closeButton.Location = new System.Drawing.Point(8, 240);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 0;
			this.closeButton.Text = "Schließen";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// wndProcDemo
			// 
			this.wndProcDemo.Location = new System.Drawing.Point(32, 8);
			this.wndProcDemo.Name = "wndProcDemo";
			this.wndProcDemo.Size = new System.Drawing.Size(288, 23);
			this.wndProcDemo.TabIndex = 1;
			this.wndProcDemo.Text = "Über WndProc verschiebbar gemachtes Formular";
			this.wndProcDemo.Click += new System.EventHandler(this.wndProcDemo_Click);
			// 
			// sendMessageDemo
			// 
			this.sendMessageDemo.Location = new System.Drawing.Point(32, 40);
			this.sendMessageDemo.Name = "sendMessageDemo";
			this.sendMessageDemo.Size = new System.Drawing.Size(288, 23);
			this.sendMessageDemo.TabIndex = 2;
			this.sendMessageDemo.Text = "Über SendMessage verschiebbar gemachtes Formular";
			this.sendMessageDemo.Click += new System.EventHandler(this.sendMessageDemo_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.sendMessageDemo,
																		  this.wndProcDemo,
																		  this.closeButton});
			this.Name = "StartForm";
			this.Text = "Formulare über den Clientbereich verschieben";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		private void wndProcDemo_Click(object sender, System.EventArgs e)
		{
			WndProcDemoForm f = new WndProcDemoForm();
			f.Show();
		}

		private void sendMessageDemo_Click(object sender, System.EventArgs e)
		{
			SendMessageDemoForm f = new SendMessageDemoForm();
			f.Show();
		}
	}
}
