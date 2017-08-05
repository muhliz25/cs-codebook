using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Addison_Wesley.Codebook.Controls
{
	public class NumberTextBox: TextBox
	{
		/* Aufzählung und Eigenschaft, die den Eingabetyp festlegen */
		public enum InputTypeEnum
		{
			Double,
			Integer
		}
		
		private InputTypeEnum inputType = InputTypeEnum.Double;

		[Category("Verhalten")]
		[Description("Definiert, welche Eingaben die TextBox zulässt")] 
		public InputTypeEnum InputType
		{
			get {return this.inputType;}
			set {this.inputType = value;}
		}

		/* Ereignis für Eingabefehlermeldungen */
		[Description("Wird aufgerufen, wenn eine Eingabe nicht dem Schema entspricht")] 
		public delegate void InvalidInputHandler(string invalidText);
		public event InvalidInputHandler InvalidInput;

		/* Methode zum Überprüfen, ob die Eingabe in Ordnung ist */
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


		/* Überschreiben der Text-Eigenschaft */
		public override string Text
		{
			get {return base.Text;}
			set
			{
				if (this.inputValid(value))
					base.Text = value;
			}
		}

		/* Überschreiben der OnKeyPress-Methode zum Überprüfen von Tastatureingaben */
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (Char.IsControl(e.KeyChar) == false)
			{
				// Den potenziell neuen Text zusammensetzen
				string newText = base.Text.Substring(0, base.SelectionStart)
					+ e.KeyChar.ToString() + base.Text.Substring(
					base.SelectionStart + base.SelectionLength);
				
				if (this.inputValid(newText) == false)
					// Die Eingabe führt zu einem ungültigen Ergebnis,
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
		

		/* Überschreiben der ProcessCmdKey-Methode zum Abfangen der
		 * Tastenkombinationen für das Einfügen von Daten */
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == (Keys)Shortcut.CtrlV || 
				keyData == (Keys)Shortcut.ShiftIns)
			{
				// Daten aus der Zwischenablage auslesen
				IDataObject iData = Clipboard.GetDataObject();
 
				// Die neuen Daten mit dem Text außerhalb der aktuellen Auswahl
				// verknüpfen um den neuen Text zu erhalten
				string newText = base.Text.Substring(0, base.SelectionStart) +
					(string)iData.GetData(DataFormats.Text) +
					base.Text.Substring(base.SelectionStart +
					base.SelectionLength);

				// Den potenziell neuen Text überprüfen
				if (this.inputValid(newText) == false)
					// Beenden und true zurückgeben, um die Verarbeitung
					// abzuschließen
					return true; 
			}
         
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
