using System;
using System.Collections;

namespace Typisierte_Auflistungen
{
	/* Klasse, deren Instanzen aufgelistet werden sollen */
	public class Person: IComparable
	{
		public int Id;
		public string FirstName;
		public string LastName;

		public Person(int id, string firstName, string lastName)
		{
			this.Id = id;
			this.LastName = lastName;
			this.FirstName = firstName;
		}

		public override string ToString()
		{
			return this.Id + " " + this.FirstName + " " + this.LastName;
		}
   
		public int CompareTo(object o)
		{
			return this.Id.CompareTo(((Person)o).Id);
		}
	}

	/* Typisierte Auflistung vom Typ Collection f�r Person-Objekte */
	public class PersonCollection: CollectionBase
	{
		/* Konstruktoren */
		public PersonCollection()
		{
		}

		public PersonCollection(int capacity)
		{
			this.InnerList.Capacity = capacity;
		}

		/* Add-Methode */
		public void Add(Person p)
		{
			base.InnerList.Add(p);
		}

		/* Remove-Methode */
		public void Remove(Person p)
		{
			base.InnerList.Remove(p);
		}
   
		/* Indizierer */
		public Person this[int index]
		{
			get {return (Person)base.InnerList[index];}
			set {base.InnerList[index] = value;}
		}

		/* CopyTo-Methode */
		public void CopyTo(Person[] persons, int startIndex)
		{
			base.InnerList.CopyTo(persons, startIndex);
		}

		/* Contains-Methode */
		public bool Contains(Person p)
		{
			return base.InnerList.Contains(p);
		}

		/* Sort-Methoden */
		public void Sort()
		{
			base.InnerList.Sort();
		}

		public void Sort(IComparer comparer)
		{
			base.InnerList.Sort(comparer);
		}

		public void Sort(int index, int count, IComparer comparer)
		{
			base.InnerList.Sort(index, count, comparer);
		}

		/* BinarySearch-Methode */
		public Person BinarySearch(int Id)
		{
			int index = base.InnerList.BinarySearch(new Person(Id, null, null));
			if (index > -1)
				return (Person)base.InnerList[index];
			else
				return null;
		}
	}

	/* Typsichere Hashtable-Auflistung */
	public class PersonHashtable: DictionaryBase
	{
		/* Add-Methode */
		public void Add(Person p)
		{
			base.InnerHashtable.Add(p.Id, p);
		}

		/* Remove-Methode */
		public void Remove(int id)
		{
			base.InnerHashtable.Remove(id);
		}

		/* Indizierer */
		public Person this[int id]
		{
			get {return (Person)base.InnerHashtable[id];}
			set {base.InnerHashtable[id] = value;}
		}

		/* Contains-Methode */
		public bool Contains(int id)
		{
			return base.InnerHashtable.Contains(id);
		}

		/* Values-Eigenschaft */
		public ICollection Values
		{
			get {return base.InnerHashtable.Values;}
		}

		/* Keys-Eigenschaft */
		public ICollection Keys
		{
			get {return base.InnerHashtable.Keys;}
		}

		/* CopyValues */
		public void CopyTo(Person[] persons, int startIndex)
		{
			this.InnerHashtable.Values.CopyTo(persons, startIndex);
		}
	}
}
