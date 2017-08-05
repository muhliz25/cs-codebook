using System;
using System.Collections.Specialized;

namespace Suchen_in_Arrays
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Array von Circle-Objekten erzeugen
			Circle[] circles  = new Circle[4];
			circles[0] = new Circle(10, 20, 100);
			circles[1] = new Circle(15, 25, 80);
			circles[2] = new Circle(5, 10, 120);
			circles[3] = new Circle(35, 45, 70);

			// Nach einem Kreis mit dem Radius 120 suchen
			Array.Sort(circles);
			int index = Array.BinarySearch(circles, new Circle(0, 0, 120));
			if (index > -1)
				Console.WriteLine("Gefunden: Radius: {0}, x: {1}, y: {2}", circles[index].Radius, 
					circles[index].x, circles[index].y);
			else
				Console.WriteLine("Nicht gefunden");


			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
