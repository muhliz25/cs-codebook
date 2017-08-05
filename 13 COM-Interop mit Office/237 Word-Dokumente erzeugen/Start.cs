using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Word_Dokumente_erzeugen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Word-Instanz erzeugen und sichtbar schalten
			Word.Application word = new Word.ApplicationClass();
			word.Visible = true;

			// Neues Dokument basierend auf der Dokumentenvorlage Brief.dot erzeugen
			object missing = Missing.Value;
			object template = Path.Combine(Application.StartupPath, "Brief.dot");
			word.Documents.Add(ref template, ref missing, ref missing, ref missing);

			// Die einzelnen Textmarken anspringen und den gewünschten Text einfügen
			object what = Word.WdGoToItem.wdGoToBookmark; 
			object name = "Name";
			word.Selection.GoTo(ref what, ref missing, ref missing, ref name);
			word.Selection.TypeText("Donald Duck");

			name = "Strasse";
			word.Selection.GoTo(ref what, ref missing, ref missing, ref name);
			word.Selection.TypeText("Entenweg 1");

			name = "Ort";
			word.Selection.GoTo(ref what, ref missing, ref missing, ref name);
			word.Selection.TypeText("Entenhausen");

			name = "Betreff";
			word.Selection.GoTo(ref what, ref missing, ref missing, ref name);
			word.Selection.TypeText("Party");

			name = "Anrede";
			word.Selection.GoTo(ref what, ref missing, ref missing, ref name);
			word.Selection.TypeText("Hallo Donald,");

			name = "Text";
			word.Selection.GoTo(ref what, ref missing, ref missing, ref name);
			word.Selection.TypeText("wir machen Samstag eine Party. Du bist eingeladen.");

			// Das Dokument ausdrucken ...
			word.ActiveDocument.PrintOut(ref missing, ref missing, ref missing, ref missing,
				ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
				ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
				ref missing, ref missing);

			// und speichern
			object fileName = Path.Combine(Application.StartupPath, "Brief.doc");
			word.ActiveDocument.SaveAs(ref fileName, ref missing, ref missing, ref missing,
				ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
				ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

			// Word beenden
			object saveChanges = false;
			word.Quit(ref saveChanges, ref missing, ref missing);

		}
	}
}
