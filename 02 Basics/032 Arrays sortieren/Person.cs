using System;

namespace Arrays_sortieren
{
	/* Klasse, die die IComparable-Schnittstelle für ein 
	 * korrektes Sortieren implementiert */
	public class Person: IComparable
	{
		public string FirstName;
		public string LastName;
		public Person(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		/* Implementierung der CompareTo-Methode */
		public int CompareTo(object o)
		{
			Person otherPerson = (Person)o;
			string firstName1 = this.FirstName.ToLower();
			string firstName2 = otherPerson.FirstName.ToLower();
			string lastName1 = this.LastName.ToLower();
			string lastName2 = otherPerson.LastName.ToLower();

			if (lastName1 == lastName2 && firstName1 == firstName2)
				// Beide Instanzen sind gleich
				return 0;
			else if (lastName1.CompareTo(lastName2) < 0 || 
				(lastName1 == lastName2 &&
				firstName1.CompareTo(firstName2) < 0))
				// Diese Instanz ist kleiner als die andere
				return -1;
			else 
				// Diese Instanz ist kleiner als die andere
				return 1;
		}
	}

}
