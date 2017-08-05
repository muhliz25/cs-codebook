using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Testprojekt
{
	public class StartForm: System.Windows.Forms.Form
	{
		private Addison_Wesley.Codebook.Controls.NumberTextBox numberTextBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label infoLabel;
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
			this.numberTextBox1 = new Addison_Wesley.Codebook.Controls.NumberTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.infoLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// numberTextBox1
			// 
			this.numberTextBox1.InputType = Addison_Wesley.Codebook.Controls.NumberTextBox.InputTypeEnum.Double;
			this.numberTextBox1.Location = new System.Drawing.Point(112, 32);
			this.numberTextBox1.Name = "numberTextBox1";
			this.numberTextBox1.Size = new System.Drawing.Size(168, 20);
			this.numberTextBox1.TabIndex = 0;
			this.numberTextBox1.Text = "";
			this.numberTextBox1.InvalidInput += new Addison_Wesley.Codebook.Controls.NumberTextBox.InvalidInputHandler(this.numberTextBox1_InvalidInput);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Zahl:";
			// 
			// infoLabel
			// 
			this.infoLabel.Location = new System.Drawing.Point(16, 80);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(336, 48);
			this.infoLabel.TabIndex = 2;
			// 
			// StartForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 149);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.infoLabel,
																		  this.label1,
																		  this.numberTextBox1});
			this.Name = "StartForm";
			this.Text = "TextBox für Zahl- und Datumseingaben";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StartForm());
		}

		private void numberTextBox1_InvalidInput(string invalidText)
		{
			infoLabel.Text = "Ihre Eingabe würde eine ungültigen Wert ergeben: " + invalidText;
		}
	}
}
