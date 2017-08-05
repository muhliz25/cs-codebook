using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Mehrfaches_Starten_verhindern
{
	public class StartForm : System.Windows.Forms.Form
	{
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
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 245);
			this.Name = "StartForm";
			this.Text = "Mehrfaches Starten verhindern";
			this.Load += new System.EventHandler(this.StartForm_Load);
		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void StartForm_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
