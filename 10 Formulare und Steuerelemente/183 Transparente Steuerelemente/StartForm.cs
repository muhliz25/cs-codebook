using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Transparente_Steuerelemente
{
	public class StartForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label demoLabel1;
		private System.Windows.Forms.Label demoLabel2;
		private System.Windows.Forms.Label label1;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(StartForm));
			this.demoLabel1 = new System.Windows.Forms.Label();
			this.demoLabel2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// demoLabel1
			// 
			this.demoLabel1.BackColor = System.Drawing.SystemColors.Control;
			this.demoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.demoLabel1.Location = new System.Drawing.Point(24, 56);
			this.demoLabel1.Name = "demoLabel1";
			this.demoLabel1.Size = new System.Drawing.Size(216, 23);
			this.demoLabel1.TabIndex = 0;
			this.demoLabel1.Text = "Transparentes Label";
			// 
			// demoLabel2
			// 
			this.demoLabel2.BackColor = System.Drawing.SystemColors.Control;
			this.demoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.demoLabel2.Location = new System.Drawing.Point(24, 88);
			this.demoLabel2.Name = "demoLabel2";
			this.demoLabel2.Size = new System.Drawing.Size(216, 23);
			this.demoLabel2.TabIndex = 1;
			this.demoLabel2.Text = "Halb durchsichtiges Label";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Red;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(216, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Normales Label";
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.BackgroundImage = ((System.Drawing.Bitmap)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(360, 141);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.demoLabel2,
																		  this.demoLabel1});
			this.Name = "StartForm";
			this.Text = "Steuerelemente mit transparentem Hintergrund";
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
			this.demoLabel1.BackColor = Color.Transparent;
			this.demoLabel2.BackColor = Color.FromArgb(100, 255, 0, 0);
		}
	}
}
