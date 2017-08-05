using System;
using System.Windows.Forms;
using System.IO;

namespace Addison_Wesley.Codebook.Filesystem
{
	/* Klasse f�r die Speicherung fehlgeschlagener Kopieroperationen */
	public class CopyFault
	{
		// Eigenschaften
		public bool IsFile;
		public string Source;
		public string Destination;
		public string Error;

		// Konstruktor
		public CopyFault(bool isFile, string source, string destination,
			string error)
		{
			this.IsFile = isFile;
			this.Source = source;
			this.Destination = destination;
			this.Error = error;
		}
	}

	/* Klasse f�r eine Auflistung von CopyFault-Objekten */
	public class CopyFaults: System.Collections.CollectionBase 
	{
		// Methode zum Hinzuf�gen
		public void Add(CopyFault cf)
		{
			this.List.Add(cf);
		}

		// Indexer zum Zugriff auf die Elemente
		public CopyFault this[int index]
		{
			get {return (CopyFault)this.List[index];}
			set {this.List[index] = value;}
		}
	}

	/* Klasse mit einer Methode zum flexiblen Kopieren eines Ordners */
	public class FolderUtil
	{
		/* Eigenschaften, die f�r das �berschreiben aller Dateien verwendet
		 * werden */
		private static bool overwriteAllFiles;
		private static bool alreadyAskedForOverwriteAllFiles;

		/* Methode zum Kopieren eines Ordners */ 
		public static bool ExtCopy(string sourceFolderName, string destFolderName,
			CopyFaults copyFaults)
		{
			/* Datei-�berschreib-Flags voreinstellen */ 
			overwriteAllFiles = false;
			alreadyAskedForOverwriteAllFiles = false;
 
			// Rekursive Methode zum Kopieren der Unterordner und Dateien aufrufen
			CopySubFoldersAndFiles(new DirectoryInfo(sourceFolderName),
				sourceFolderName, destFolderName, copyFaults);

			// Erfolg zur�ckmelden
			return (copyFaults.Count == 0) ;
		}

		/* Methode zum rekursiven Kopieren eines Ordners */
		private static bool CopySubFoldersAndFiles(DirectoryInfo folder, 
			string mainSourceFolderName, string mainDestFolderName, 
			CopyFaults copyFaults)
		{
			// Zielordner anlegen
			try
			{
				// Zielordnername ermitteln
				string destFolderName = folder.FullName.Replace(mainSourceFolderName, 
					mainDestFolderName);

				// Ordner anlegen
				Directory.CreateDirectory(destFolderName);
			}
			catch (IOException ex)
			{
				// Fehler in der CopyFaults-Auflistung dokumentieren
				copyFaults.Add(new CopyFault(false, mainSourceFolderName,
					mainDestFolderName, ex.Message)); 
			}
 
			// Alle Unterordner des �bergebenen Ordners durchgehen
			DirectoryInfo[] subFolders = folder.GetDirectories();
			for (int i = 0; i < subFolders.Length; i++)
			{
				// Pfad f�r den Ziel-Unterordner ermitteln, indem der Pfad zum 
				// Quellordner durch den Pfad zum Zielordner ersetzt wird
				string destSubFolderName = subFolders[i].FullName.Replace(
					mainSourceFolderName, mainDestFolderName);

				// Funktion rekursiv aufrufen um zun�chst die weiteren Unterordner 
				// zu erzeugen
				CopySubFoldersAndFiles(subFolders[i], mainSourceFolderName,
					mainDestFolderName, copyFaults);
			}

			// Die im Ordner enthaltenen Dateien ermitteln
			FileInfo[] files = folder.GetFiles(); 

			// Alle Dateien durchgehen
			for (int i = 0; i < files.Length; i++)
			{
				// Ziel-Dateiname ermitteln, indem der Pfad zum Quellordner
				// durch den Pfad zum Zielordner ersetzt wird
				string destFileName = files[i].FullName.Replace(
					mainSourceFolderName, mainDestFolderName);

				// Flag setzen, das festlegt, ob die Datei kopiert werden soll
				bool performCopyOperation;
				performCopyOperation = true;

				// �berpr�fen, ob die Datei bereits existiert
				if (File.Exists(destFileName))
				{
					// Fragen, ob die Datei �berschrieben werden soll, falls der
					// Anwender dies zuvor noch nicht f�r alle Dateien und Ordner
					// gemeinsam best�tigt hat
					if (overwriteAllFiles == false)
					{
						switch (MessageBox.Show("Die Datei '" + destFileName + 
							"' existiert bereits.\r\n\r\n" +
							"Soll diese Datei �berschrieben werden?",
							Application.ProductName, MessageBoxButtons.YesNoCancel, 
							MessageBoxIcon.Question))
						{
							case DialogResult.Yes: 
								// Nachfragen, ob alle Dateien �berschrieben werden
								// sollen, falls dies noch nicht geschehen ist
								if (alreadyAskedForOverwriteAllFiles == false)
								{
									switch (MessageBox.Show("Sollen alle im Zielordner " +
										"vorhandenen Dateien �berschrieben werden?", 
										Application.ProductName, 
										MessageBoxButtons.YesNoCancel,
										MessageBoxIcon.Question))
									{
										case DialogResult.Yes:
											// Flag setzen, das das �berschreiben steuert
											overwriteAllFiles = true;
											break;

										case DialogResult.Cancel:
											// Anwender hat abgebrochen: Ausnahme erzeugen,
											// da der Ordner nicht komplett kopiert werden
											// konnte
											throw new IOException("Benutzerabbruch");
									}

									// Festlegen, dass nicht mehr nachgefragt werden muss
									alreadyAskedForOverwriteAllFiles = true;
								}
								break;
             
							case DialogResult.No: 
								// Festlegen, dass die aktuelle Datei nicht kopiert
								// werden soll
								performCopyOperation = false;
								break;
             
							case DialogResult.Cancel: 
								// Anwender hat abgebrochen: Ausnahme erzeugen, da der 
								// Ordner nicht komplett kopiert werden konnte
								throw new IOException(
									"Benutzerabbruch");
						}
					}
				}

				// Datei kopieren, wenn die Operation ausgef�hrt werden soll
				if (performCopyOperation)
				{
					try
					{
						File.Copy(files[i].FullName, destFileName,
							true);
					}
					catch (Exception ex)
					{
						// Fehler in der CopyFaults-Auflistung dokumentieren
						copyFaults.Add(new CopyFault(true, files[i].FullName,
							destFileName, ex.Message)); 
					}
				}
				else
				{
					// Datei sollte nicht �berschrieben werden: Fehler in der 
					// CopyFaults-Auflistung dokumentieren
					copyFaults.Add(new CopyFault(true, files[i].FullName,
						destFileName, 
						"Fehlende Anwender-Erlaubnis zum �berschreiben")); 
				}
			} 
    
			// Erfolg zur�ckmelden
			return true;
		}
	}
}
