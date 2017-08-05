using System;

namespace Typisierte_Auflistungen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Collection mit Person-Objekten erzeugen
			PersonCollection pc = new PersonCollection();
			pc.Add(new Person(1003, "Tricia", "McMillan"));
			pc.Add(new Person(1001, "Zaphod", "Beeblebrox"));
			pc.Add(new Person(1004, "Arthur", "Dent"));
			Person ford = new Person(1002, "Ford", "Prefect");
			pc.Add(ford);

			// Collection sortieren
			pc.Sort();

			// Collection durchgehen
			Console.WriteLine("Sortierte Auflistung:");
			foreach (Person p in pc)
				Console.WriteLine(p.ToString());
			Console.WriteLine();

			// Ermitteln, ob in der Collection ein bestimmtes Objekt existiert
			if (pc.Contains(ford))
				Console.WriteLine("Ford existiert in der Auflistung");
			else
				Console.WriteLine("Ford existiert nicht in der Auflistung");
			Console.WriteLine();

			// Nach einem Objekt mit einer Id suchen
			Person person = pc.BinarySearch(1003);
			if (person != null)
				Console.WriteLine("Gefunden: {0}", person.ToString());
			else
				Console.WriteLine("Nicht gefunden");
			Console.WriteLine();

			// Ein Objekt an einem bestimmten Index löschen
			pc.RemoveAt(2);

			// Ein bestimmtes Objekt löschen
			pc.Remove(ford);

			// Collection durchgehen
			Console.WriteLine("Auflistung nach dem Löschen:");
			for (int i = 0; i < pc.Count; i++)
				Console.WriteLine(pc[i].ToString());
			Console.WriteLine();
			
			// Hashtable mit Person-Objekten erzeugen
			Console.WriteLine();
			PersonHashtable ph = new PersonHashtable();
			ph.Add(new Person(1001, "Zaphod", "Beeblebrox"));
			ford = new Person(1002, "Ford", "Prefect");
			ph.Add(ford);
			ph.Add(new Person(1003, "Tricia", "McMillan"));
			ph.Add(new Person(1004, "Arthur", "Dent"));

			// Die Hastable testen

			// Die Hastable durchgehen
			Console.WriteLine("Hashtable:");
			foreach (Person p in ph.Values)
				Console.WriteLine(p.ToString());
			Console.WriteLine();

			// Überprüfen, ob ein Objekt mit einem bestimmten Schlüssel
			// in der Hastable existiert
			if (ph.Contains(1001))
			{
				Person p = ph[1001];
				Console.WriteLine("Gefunden: {0}", p.ToString());
			}
			Console.WriteLine();

			// Eine Person mit einem bestimmten Schlüssel löschen
			ph.Remove(1004);

			// Personen über das Kopieren in ein Array sortieren
			Person[] persons = new Person[ph.Count];
			ph.CopyTo(persons, 0);
			Array.Sort(persons);
			Console.WriteLine("Hashtable nach dem Löschen und Sortieren:");
			foreach (Person p in persons)
				Console.WriteLine(p.ToString());
			Console.WriteLine();

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
