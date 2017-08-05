using System;
using System.Windows.Forms;

namespace Addison_Wesley.Codebook.Controls
{
	public class AutoCompleteComboBox: ComboBox
	{
		/* Private Eigenschaft zur Vermeidung rekursiver Aufrufe */
		private bool dontWork = false;

		protected override void OnTextChanged(System.EventArgs e)
		{
			if (this.dontWork == false)
			{
				// Nach einem Eintrag suchen, der am Anfang dem eingegebenen
				// Text entspricht
				int index = base.FindString(base.Text);
				if (index >= 0)
				{
					// Eintrag gefunden: Alten Text merken, neuen Eintrag
					// auswählen und den differenten Teil selektieren
					string input = base.Text;
					this.dontWork = true;
					base.SelectedIndex = index;
					this.dontWork = false;
					base.Select(input.Length, base.Text.Length);
				}
			}

			base.OnTextChanged(e);
		}

		protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			// Verarbeitung vermeiden, wenn die Backspace- oder die Löschen-
			// Taste betätigt wurde
			this.dontWork = (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete);
			base.OnKeyDown(e);
		}
	}
}