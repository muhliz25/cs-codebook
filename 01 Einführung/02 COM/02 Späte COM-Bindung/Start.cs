using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Späte_COM_Bindung
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			
			Type wordType = null;
			object wordObject = null;
			try
			{
				// .NET-Typ für die COM-Klasse Word.Application erzeugen
				wordType = Type.GetTypeFromProgID("Word.Application");
				
				// Instanz dieses Typs erzeugen
				wordObject = Activator.CreateInstance(wordType);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim Erzeugen der Word-Instanz: " + 
					ex.Message, Application.ProductName, MessageBoxButtons.OK, 
					MessageBoxIcon.Error);
				return;
			}

			// Visible-Eigenschaft setzen
			wordType.InvokeMember("Visible", BindingFlags.Public | BindingFlags.SetProperty, 
				null, wordObject, new object[] {true});

			// Documents-Auflistung referenzieren ...
			object documents = wordType.InvokeMember("Documents", System.Reflection.BindingFlags.Public | BindingFlags.Instance |
				BindingFlags.GetProperty, null, wordObject, null);

			// ... und deren Add-Methode ohne Argumente aufrufen
			documents.GetType().InvokeMember("Add", BindingFlags.Public | BindingFlags.Instance
				| BindingFlags.InvokeMethod, null, documents, null);

			// Die Methode TypeText der Selection-Eigenschaft aufrufen
			object selection = wordType.InvokeMember("Selection", BindingFlags.Public |
				BindingFlags.GetProperty, null, wordObject, null);
			selection.GetType().InvokeMember("TypeText", BindingFlags.Public |
				BindingFlags.Instance | BindingFlags.InvokeMethod, null, selection, 
				new object[] {"Hallo, das ist ein Text, der von außen kommt"});

			// Das aktive Dokument referenzieren und ausdrucken
			object document = wordType.InvokeMember("ActiveDocument", BindingFlags.Public | 
				BindingFlags.GetProperty, null, wordObject, null);
			document.GetType().InvokeMember("PrintOut", BindingFlags.Public | 
				BindingFlags.InvokeMethod, null, document, null);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
