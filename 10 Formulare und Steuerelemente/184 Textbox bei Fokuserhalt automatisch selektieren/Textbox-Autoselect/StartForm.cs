using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Textbox_Autoselect
{
	public class StartForm: System.Windows.Forms.Form
	{
		private Addison_Wesley.Codebook.Controls.AutoSelectTextBox firstNameTextBox;
		private Addison_Wesley.Codebook.Controls.AutoSelectTextBox lastNameTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
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
			this.firstNameTextBox = new Addison_Wesley.Codebook.Controls.AutoSelectTextBox();
			this.lastNameTextBox = new Addison_Wesley.Codebook.Controls.AutoSelectTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// firstNameTextBox
			// 
			this.firstNameTextBox.AutoSelect = true;
			this.firstNameTextBox.Location = new System.Drawing.Point(120, 24);
			this.firstNameTextBox.Name = "firstNameTextBox";
			this.firstNameTextBox.TabIndex = 0;
			this.firstNameTextBox.Text = "Zaphod";
			this.firstNameTextBox.Enter += new System.EventHandler(this.firstNameTextBox_Enter);
			// 
			// lastNameTextBox
			// 
			this.lastNameTextBox.AutoSelect = true;
			this.lastNameTextBox.Location = new System.Drawing.Point(120, 56);
			this.lastNameTextBox.Name = "lastNameTextBox";
			this.lastNameTextBox.TabIndex = 1;
			this.lastNameTextBox.Text = "Beeblebrox";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "Vorname:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.TabIndex = 3;
			this.label2.Text = "Nachname:";
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(360, 109);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label2,
																		  this.label1,
																		  this.lastNameTextBox,
																		  this.firstNameTextBox});
			this.Name = "StartForm";
			this.Text = "Textbox automatisch beim Eintritt selektieren";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void firstNameTextBox_Enter(object sender, System.EventArgs e)
		{
			this.firstNameTextBox.SelectAll();
		}
	}
}
