using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Addison_Wesley.Codebook.Controls
{
	public class NumberTextBox: TextBox
	{
		/* Aufz�hlung und Eigenschaft, die den Eingabetyp festlegen */
		public enum InputTypeEnum
		{
			Double,
			Integer
		}
		
		private InputTypeEnum inputType = InputTypeEnum.Double;

		[Category("Verhalten")]
		[Description("Definiert, welche Eingaben die TextBox zul�sst")] 
		public InputTypeEnum InputType
		{
			get {return this.inputType;}
			set {this.inputType = value;}
		}

		/* Ereignis f�r Eingabefehlermeldungen */
		[Description("Wird aufgerufen, wenn eine Eingabe nicht dem Schema entspricht")] 
		public delegate void InvalidInputHandler(string invalidText);
		public event InvalidInputHandler InvalidInput;

		/* Methode zum �berpr�fen, ob die Eingabe in Ordnung ist */
		private bool inputValid(string input)
		{
			switch (this.inputType)
			{
				case InputTypeEnum.Double:
					try 
					{
						Convert.ToDouble(input);			
						return true;
					}
					catch 
					{
						if (InvalidInput != null) InvalidInput(input);
						return false;
					}

				default:  // InputTypeEnum.Integer
					try 
					{
						Convert.ToInt64(input);			
						return true;
					}
					catch 
					{
						if (InvalidInput != null) InvalidInput(input);
						return false;
					}
			}
		}


		/* �berschreiben der Text-Eigenschaft */
		public override string Text
		{
			get {return base.Text;}
			set
			{
				if (this.inputValid(value))
					base.Text = value;
			}
		}

		/* �berschreiben der OnKeyPress-Methode zum �berpr�fen von Tastatureingaben */
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (Char.IsControl(e.KeyChar) == false)
			{
				// Den potenziell neuen Text zusammensetzen
				string newText = base.Text.Substring(0, base.SelectionStart)
					+ e.KeyChar.ToString() + base.Text.Substring(
					base.SelectionStart + base.SelectionLength);
				
				if (this.inputValid(newText) == false)
					// Die Eingabe f�hrt zu einem ung�ltigen Ergebnis,
					// also verwerfen
					e.Handled = true;
			}
			
			base.OnKeyPress(e);
		}


		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			
   
			base.WndProc(ref m);
		}
		

		/* �berschreiben der ProcessCmdKey-Methode zum Abfangen der
		 * Tastenkombinationen f�r das Einf�gen von Daten */
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == (Keys)Shortcut.CtrlV || 
				keyData == (Keys)Shortcut.ShiftIns)
			{
				// Daten aus der Zwischenablage auslesen
				IDataObject iData = Clipboard.GetDataObject();
 
				// Die neuen Daten mit dem Text au�erhalb der aktuellen Auswahl
				// verkn�pfen um den neuen Text zu erhalten
				string newText = base.Text.Substring(0, base.SelectionStart) +
					(string)iData.GetData(DataFormats.Text) +
					base.Text.Substring(base.SelectionStart +
					base.SelectionLength);

				// Den potenziell neuen Text �berpr�fen
				if (this.inputValid(newText) == false)
					// Beenden und true zur�ckgeben, um die Verarbeitung
					// abzuschlie�en
					return true; 
			}
         
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
