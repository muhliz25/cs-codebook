using System;
using System.Collections;

namespace Arrays_sortieren
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// byte-Array sortiert ausgeben
			byte[] numbers = {10, 1, 3, 19, 33, 5, 7};
			Array.Sort(numbers);
			for (int i = 0; i < numbers.Length; i++)
				Console.WriteLine(numbers[i]);

			// ArrayList mit Strings sortieren
			ArrayList names = new ArrayList();
			names.Add("Zaphod");
			names.Add("Ford");
			names.Add("Trillian");
			names.Add("Arthur");
			names.Sort();
			for (int i = 0; i < names.Count; i++)
				Console.WriteLine(names[i]);

			// ArrayList mit DateTime-Instanzen sortieren
			ArrayList dates = new ArrayList();
			dates.Add(new DateTime(2002, 12, 31));
			dates.Add(new DateTime(2001, 1, 1));
			dates.Add(new DateTime(2002, 5, 30));
			dates.Sort();
			for (int i = 0; i < dates.Count; i++)
				Console.WriteLine(dates[i]);

			// Array mit eigenen Person-Objekten sortieren
			Person[] persons = new Person[4];
			persons[0] = new Person("Arthur", "Miller");
			persons[1] = new Person("John", "Dent");
			persons[2] = new Person("Arthur", "Dent");
			persons[3] = new Person("Tricia", "McMillan");
			Array.Sort(persons);
			for (int i = 0; i < persons.Length; i++)
				Console.WriteLine(persons[i].FirstName + " " + persons[i].LastName);

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
