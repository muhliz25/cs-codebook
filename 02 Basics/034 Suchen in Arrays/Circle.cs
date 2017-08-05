using System;

namespace Suchen_in_Arrays
{
	/* Klasse zur Speicherung von Kreisdaten */
	public class Circle: IComparable
	{
		public int x;
		public int y;
		public int Radius;
		public Circle(int x, int y, int radius)
		{
			this.x = x;
			this.y = y;
			this.Radius = radius;
		}

		/* Implementierung der CompareTo-Methode */
		public int CompareTo(object o)
		{
			Circle otherCircle = (Circle)o;
			return this.Radius.CompareTo(otherCircle.Radius);
		}
	}
}
