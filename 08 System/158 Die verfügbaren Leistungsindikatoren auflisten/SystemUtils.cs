using System;
using System.Diagnostics;
using System.Text;
using System.IO;

namespace Addison_Wesley.Codebook.System
{
	public class SystemUtils
	{
		/* Methode zum Schreiben der verfügbaren Leistungsindikatoren in eine Textdatei */
		public static void WritePerformanceCounterNames(string fileName)
		{
			// Datei zum Schreiben öffnen
			StreamWriter sr = new StreamWriter(fileName, false, Encoding.Default);

			// Ermitteln und Durchgehen der Leistungsindikatoren-Kategorien
			PerformanceCounterCategory[] pccList = 
				PerformanceCounterCategory.GetCategories();
			foreach (PerformanceCounterCategory pcc in pccList)
			{
				sr.WriteLine("Kategorie: {0}", pcc.CategoryName); 
      
				try
				{
					// Ermitteln der Namen der eventuell vorhandenen Instanzen 
					string[] pcInstanceNames = pcc.GetInstanceNames();

					PerformanceCounter[] pcList = null;
					if (pcInstanceNames.Length > 0)
					{
						// Es existieren Instanzen der Kategorie: Zunächst die Namen der
						// Instanzen ausgeben
						sr.WriteLine("Instanzen von {0}:", pcc.CategoryName);
						for (int i = 0; i < pcInstanceNames.Length; i++)
							sr.WriteLine("   " + pcInstanceNames[i]);
						// Abfragen der Leistungsindikatoren einer der Instanzen 
						bool ok = false;
						string lastError = null;
						foreach(string instanceName in pcInstanceNames)
						{
							try
							{
								pcList  = 
									pcc.GetCounters(instanceName);
								ok = true;
								break;
							}
							catch (Exception ex)
							{
								lastError = ex.Message;
							}
						}
						if (ok == false)
						{
							// Fehler ausgeben
							sr.WriteLine("Kann Kategorie {0} nicht abfragen, da " +
								"beim Abfragen der Instanzen Fehler aufgetreten sind. " +
								"Letzter Fehler: {1}", pcc.CategoryName, lastError);

							// Mit der nächsten Kategorie weitermachen
							sr.WriteLine();
							continue;
						}   
					}
					else
					{
						pcList  = pcc.GetCounters();
					}
					sr.WriteLine("Leistungsindikatoren von {0}:", pcc.CategoryName);
					foreach (PerformanceCounter pc in pcList)
					{
						sr.WriteLine("  {0}: {1} ({2})", pc.CounterName, pc.CounterHelp,
							pc.CounterType);
					}
				}
				catch (Exception ex)
				{
					sr.WriteLine("Kann Kategorie nicht abfragen: {0}", ex.Message);
				}
      
				sr.WriteLine();
			}

			// StreamWriter schließen
			sr.Close();
		}
	}
}
