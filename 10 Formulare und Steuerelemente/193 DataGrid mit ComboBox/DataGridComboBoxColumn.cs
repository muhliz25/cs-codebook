using System;
using System.Drawing;
using System.Windows.Forms; 

namespace Addison_Wesley.Codebook.Controls
{
	/* Klasse für eine DataGrid-Spalte mit einer ComboBox */
	public class DataGridComboBoxColumn: DataGridTextBoxColumn
	{
		/* Eigenschaften */
		public ComboBox ComboBox = null;
		private bool inEditMode;
		private CurrencyManager currencyManager = null;
		private int currentRow;
		private bool dontHandleSelectedItemChanged = false;

		/* Delegate und Ereignis für das ComboValueChanged-Ereignis */
		public delegate void ComboValueChanged(int changingRow, 
			object newValue);
		public event ComboValueChanged ComboValueChangedEvent;
		
		/* Konstruktor */
		public DataGridComboBoxColumn()
		{
			// ComboBox erzeugen und die Ereignisbehandlungs-Methoden zuweisen
			this.ComboBox = new ComboBox();
			this.ComboBox.Leave += 
				new EventHandler(this.ComboBoxLeaveHandler);
			this.ComboBox.SelectedIndexChanged += 
				new EventHandler(this.ComboBoxSelectedIndexChangedHandler);
			this.ComboBox.SelectionChangeCommitted += 
				new EventHandler(this.ComboBoxSelectionChangeCommittedHandler);
		}

		/* Überschreiben der Edit-Methode, die aufgerufen wird, wenn der 
		 * Anwender die Spalte in den Editiermodus versetzt */
		protected override void Edit(CurrencyManager source, int rowNum,
			System.Drawing.Rectangle bounds, bool readOnly, string instantText,
			bool cellIsVisible)
		{
			base.Edit(source, rowNum, bounds, readOnly, instantText,
				cellIsVisible);

			// Merken der aktuellen Zeile und des CurrencyManager-Objekts
			this.currentRow = rowNum;
			this.currencyManager = source;
      
			// Übergeben der Eigenschaften der TextBox der Spalte an die ComboBox
			this.ComboBox.Parent = this.TextBox.Parent;
			this.ComboBox.Location = this.TextBox.Location;
			this.ComboBox.Size = new Size(this.TextBox.Size.Width,
				this.ComboBox.Size.Height);
			// Abarbeitung des SelectedItemChanged-Ereignisses vermeiden
			this.dontHandleSelectedItemChanged = true;
			// Text übergeben
			this.ComboBox.SelectedValue =  this.TextBox.Text;
			// Abarbeitung des SelectedItemChanged-Ereignisses wieder erlauben
			this.dontHandleSelectedItemChanged = false;

			// TextBox unsichtbar, ComboBox sichtbar schalten, die ComboBox nach
			// vorne holen und den Fokus daraus setzen
			this.TextBox.Visible = false;
			this.ComboBox.Visible = true;
			this.ComboBox.BringToFront();
			this.ComboBox.Focus();   
		}

		/* Überschreiben der Commit-Methode, die aufgerufen wird, wenn der 
		 * Anwender seine Änderungen bestätigt */
		protected override bool Commit(CurrencyManager dataSource, int rowNum)
		{
			if (this.inEditMode)
			{
				this.inEditMode = false;
            
				// Den Wert der ComboBox in die TextBox schreiben
				base.SetColumnValueAtRow(dataSource, rowNum,
					this.ComboBox.SelectedValue);
			}
			return true;
		}

		/* Ereignisbehandlungs-Methoden für die ComboBox */
		private void ComboBoxSelectionChangeCommittedHandler(object sender,
			EventArgs e)
		{
			this.inEditMode = true;
			base.ColumnStartedEditing((Control)sender);
		}

		private void ComboBoxLeaveHandler(object sender, EventArgs e)
		{
			if (this.inEditMode)
				// Die Spalte auffordern, ihre TextBox neu zu zeichnen
				base.Invalidate();

			// ComboBox verstecken
			this.ComboBox.Hide();
		}

		private void ComboBoxSelectedIndexChangedHandler(object sender,
			EventArgs e)
		{
			// Wenn der Index des selektierten Eintrags sich in der ComboBox
			// ändert: Das eigene ComboValueChanged-Ereignis aufrufen
			if (this.dontHandleSelectedItemChanged == false)
			{
				if (this.ComboValueChangedEvent != null)
					this.ComboValueChangedEvent(this.currentRow,
						this.ComboBox.Text);    
			}
		}
	}
}


