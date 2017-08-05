using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace AutoCompleteComboBox_Demo
{
	public class StartForm: System.Windows.Forms.Form
	{
		private Addison_Wesley.Codebook.Controls.AutoCompleteComboBox demoComboBox;
		private Addison_Wesley.Codebook.Controls.AutoCompleteComboBox demoAutoCompleteComboBox;
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
			this.demoAutoCompleteComboBox = new Addison_Wesley.Codebook.Controls.AutoCompleteComboBox();
			this.SuspendLayout();
			// 
			// demoAutoCompleteComboBox
			// 
			this.demoAutoCompleteComboBox.Location = new System.Drawing.Point(40, 16);
			this.demoAutoCompleteComboBox.Name = "demoAutoCompleteComboBox";
			this.demoAutoCompleteComboBox.Size = new System.Drawing.Size(152, 21);
			this.demoAutoCompleteComboBox.TabIndex = 0;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(256, 61);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.demoAutoCompleteComboBox});
			this.Name = "StartForm";
			this.Text = "AutoCompleteComboBox-Demo";
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
			this.demoAutoCompleteComboBox.Items.Add("Arthur");
			this.demoAutoCompleteComboBox.Items.Add("Armin");
			this.demoAutoCompleteComboBox.Items.Add("Slartibartfaﬂ");
			this.demoAutoCompleteComboBox.Items.Add("Marvin");
			this.demoAutoCompleteComboBox.Items.Add("Mike");
			this.demoAutoCompleteComboBox.Items.Add("Zaphod");
			this.demoAutoCompleteComboBox.Items.Add("Trillian");
			this.demoAutoCompleteComboBox.Items.Add("Fort");

		}
	}
}

