using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;


namespace Word_Dokumente_öffnen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Word-Instanz erzeugen und sichtbar schalten
			Word.Application word = new Word.ApplicationClass();
			word.Visible = true;

			// Variable für den Wert Missing.Value für nicht belegte optionale Argumente 
			object missing = Missing.Value;

			// Dokument öffnen
			object fileName = Path.Combine(Application.StartupPath, "Hitchhiker.doc");
			word.Documents.Open(ref fileName, ref missing, ref missing, ref missing,
				ref missing, ref missing, ref missing, ref missing, ref missing, 
				ref missing, ref missing, ref missing, ref missing, ref missing, 
				ref missing);

		}
	}
}
