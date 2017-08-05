using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Andockende_Formulare
{
	public class ChildForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.ComponentModel.Container components = null;

		public ChildForm()
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(184, 173);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "";
			// 
			// ChildForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(184, 173);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.textBox1});
			this.Name = "ChildForm";
			this.Text = "ChildForm";
			this.ResumeLayout(false);

		}
		#endregion

	}
}
