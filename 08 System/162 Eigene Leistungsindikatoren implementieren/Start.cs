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
			// und L�schen derselben, falls dies der Fall ist
			if (PerformanceCounterCategory.Exists(Application.ProductName))
				PerformanceCounterCategory.Delete(Application.ProductName);

			// CounterCreationDataCollection-Instanz f�r die Indikatorendaten der zu
			// erzeugenden Leistungsindikatoren-Kategorie erzeugen und mit den Daten von
			// drei Leistungs-Indikatoren (plus einem Basis-Indikator) f�llen
			CounterCreationDataCollection ccdCol = new CounterCreationDataCollection();
			ccdCol.Add(new CounterCreationData("Gesamtanzahl der Transaktionen",
				"Verwaltet die Anzahl der insgesamt ausgef�hrten Transaktionen", 
				PerformanceCounterType.NumberOfItems32));
			ccdCol.Add(new CounterCreationData("Offene Transaktionen", 
				"Zeigt die Anzahl der aktuell offenen Transaktionen an", 
				PerformanceCounterType.NumberOfItems32));
			ccdCol.Add(new CounterCreationData("Offene Transaktionen, Durchschnitt", 
				"Zeigt die durchschnittlichen offenen Transaktionen", 
				PerformanceCounterType.AverageCount64));
			ccdCol.Add(new CounterCreationData("Offene Transaktionen, Durchschnitt, Basis", 
				"Basis f�r den Counter 'Offene Transaktionen, Durchschnitt'", 
				PerformanceCounterType.AverageBase));

			// Leistungsindikatorekategorie erzeugen
			PerformanceCounterCategory.Create(Application.ProductName, 
				"Demo f�r Leistungsindikatoren", ccdCol);
			
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

			// Gesamtanzahl der Transaktionen zur�cksetzen
			pc1.RawValue = 0;

			// Aktualisieren der eigenen Leistungsindikatoren
			Random random = new Random();
			for (int i = 0; i < 100; i++)
			{
				int openTransactionCount = random.Next(10);
				pc1.Increment();  // Gesamtanzahl der Transaktionen erh�hen
				pc2.RawValue = openTransactionCount; // Anzahl der offenen Transaktionen
				int updateCount = i; // random.Next(10);
				pc3.IncrementBy(openTransactionCount); // Durchschnitt der offenen Transaktionen
				pc4.Increment(); // Basis-Z�hler f�r den Indikator pc3

				System.Threading.Thread.Sleep(500);
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
