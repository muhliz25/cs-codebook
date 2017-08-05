using System;

namespace Objekte_in_XML_serialisieren
{
	public class Person
	{
		/* Eigenschaften */
		
		// Diese Eigenschaft wird nicht serialisiert, da keine set-Methode
		// zur Verfügung steht
		private int id;
		public int Id
		{
			get {return this.id;}
		}
		
		private string firstName;
		public string FirstName
		{
			get {return this.firstName;}
			set {this.firstName = value;}
		}
		
		private string lastName;
		public string LastName
		{
			get {return this.lastName;}
			set {this.lastName = value;}
		}
		
		public DateTime BirthDate;

		/* Konstruktoren */
		public Person()
		{
		}

		public Person(int id, string firstName, string lastName)
		{
			this.id = id;
			this.firstName = firstName;
			this.lastName = lastName;
		}
	}
}
