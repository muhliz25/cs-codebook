using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Addison_Wesley.Codebook.Controls
{
	public class AutoSelectTextBox: TextBox
	{
		/* Eigenschaft für das automatische Selektieren */
		private bool autoSelect = true;
		[Category("Verhalten")]
		[Description("Definiert, ob der Inhalt der TextBox beim Fokuserhalt " +
		 "automatisch selektiert wird")]
		public bool AutoSelect
		{
			get {return this.autoSelect;}
			set {this.autoSelect = value;}
		}

		/* Überschreiben der OnEnter-Methode */
		protected override void OnEnter(EventArgs e)
		{
			if (this.autoSelect)
				this.SelectAll();
		}
	}
}
