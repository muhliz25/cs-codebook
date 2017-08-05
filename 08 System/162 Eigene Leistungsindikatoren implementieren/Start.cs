using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Eigene_Leistungsindikatoren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Ermitteln, ob die Leistungsindikatoren-Kategorie bereits existiert,
			// und Löschen derselben, falls dies der Fall ist
			if (PerformanceCounterCategory.Exists(Application.ProductName))
				PerformanceCounterCategory.Delete(Application.ProductName);

			// CounterCreationDataCollection-Instanz für die Indikatorendaten der zu
			// erzeugenden Leistungsindikatoren-Kategorie erzeugen und mit den Daten von
			// drei Leistungs-Indikatoren (plus einem Basis-Indikator) füllen
			CounterCreationDataCollection ccdCol = new CounterCreationDataCollection();
			ccdCol.Add(new CounterCreationData("Gesamtanzahl der Transaktionen",
				"Verwaltet die Anzahl der insgesamt ausgeführten Transaktionen", 
				PerformanceCounterType.NumberOfItems32));
			ccdCol.Add(new CounterCreationData("Offene Transaktionen", 
				"Zeigt die Anzahl der aktuell offenen Transaktionen an", 
				PerformanceCounterType.NumberOfItems32));
			ccdCol.Add(new CounterCreationData("Offene Transaktionen, Durchschnitt", 
				"Zeigt die durchschnittlichen offenen Transaktionen", 
				PerformanceCounterType.AverageCount64));
			ccdCol.Add(new CounterCreationData("Offene Transaktionen, Durchschnitt, Basis", 
				"Basis für den Counter 'Offene Transaktionen, Durchschnitt'", 
				PerformanceCounterType.AverageBase));

			// Leistungsindikatorekategorie erzeugen
			PerformanceCounterCategory.Create(Application.ProductName, 
				"Demo für Leistungsindikatoren", ccdCol);
			
			Console.WriteLine("Leistungsindikatoren erzeugt. Inkrementiere die Werte ...");

			// Ermitteln der eigenen Leistungsindikatoren
			PerformanceCounter pc1 = new PerformanceCounter(Application.ProductName,
				"Gesamtanzahl der Transaktionen", false);
			PerformanceCounter pc2 = new PerformanceCounter(Application.ProductName,
				"Offene Transaktionen", false);
			PerformanceCounter pc3 = new PerformanceCounter(Application.ProductName,
				"Offene Transaktionen, Durchschnitt", false);
			PerformanceCounter pc4 = new PerformanceCounter(Application.ProductName,
				"Offene Transaktionen, Durchschnitt, Basis", false);

			// Gesamtanzahl der Transaktionen zurücksetzen
			pc1.RawValue = 0;

			// Aktualisieren der eigenen Leistungsindikatoren
			Random random = new Random();
			for (int i = 0; i < 100; i++)
			{
				int openTransactionCount = random.Next(10);
				pc1.Increment();  // Gesamtanzahl der Transaktionen erhöhen
				pc2.RawValue = openTransactionCount; // Anzahl der offenen Transaktionen
				int updateCount = i; // random.Next(10);
				pc3.IncrementBy(openTransactionCount); // Durchschnitt der offenen Transaktionen
				pc4.Increment(); // Basis-Zähler für den Indikator pc3

				System.Threading.Thread.Sleep(500);
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
