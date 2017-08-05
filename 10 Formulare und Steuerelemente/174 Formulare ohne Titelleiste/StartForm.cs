using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Formulare_ohne_Titelleiste
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button closeButton;
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
			this.SuspendLayout();
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(8, 240);
			this.closeButton.Name = "closeButton";
			this.closeButton.TabIndex = 0;
			this.closeButton.Text = "Schlieﬂen";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.closeButton});
			this.Name = "StartForm";
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
	}
}
