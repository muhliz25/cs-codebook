using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace Formulare_mit_freien_Formen
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button shapedForm1Button;
		private System.Windows.Forms.Button shapedForm2Button;
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
			this.shapedForm1Button = new System.Windows.Forms.Button();
			this.shapedForm2Button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// shapedForm1Button
			// 
			this.shapedForm1Button.Location = new System.Drawing.Point(16, 16);
			this.shapedForm1Button.Name = "shapedForm1Button";
			this.shapedForm1Button.Size = new System.Drawing.Size(248, 23);
			this.shapedForm1Button.TabIndex = 0;
			this.shapedForm1Button.Text = "Freiform-Formular über TransparentColor";
			this.shapedForm1Button.Click += new System.EventHandler(this.shapedForm1Button_Click);
			// 
			// shapedForm2Button
			// 
			this.shapedForm2Button.Location = new System.Drawing.Point(16, 48);
			this.shapedForm2Button.Name = "shapedForm2Button";
			this.shapedForm2Button.Size = new System.Drawing.Size(248, 23);
			this.shapedForm2Button.TabIndex = 1;
			this.shapedForm2Button.Text = "Freiform-Formular über Region";
			this.shapedForm2Button.Click += new System.EventHandler(this.shapedForm2Button_Click);
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(280, 93);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.shapedForm2Button,
																		  this.shapedForm1Button});
			this.Name = "StartForm";
			this.Text = "Formulare mit freien Formen";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void endButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void shapedForm1Button_Click(object sender, System.EventArgs e)
		{
			ShapedForm1 f = new ShapedForm1();
			f.Show();
		}

		private void shapedForm2Button_Click(object sender, System.EventArgs e)
		{
			ShapedForm2 f = new ShapedForm2();
			f.Show();
		}
	}
}
