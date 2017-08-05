using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Farben_ändern
{
	public class ImageForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;

		public ImageForm()
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
			// 
			// ImageForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 469);
			this.Name = "ImageForm";
			this.Text = "ImageForm";

		}
		#endregion
	}
}
