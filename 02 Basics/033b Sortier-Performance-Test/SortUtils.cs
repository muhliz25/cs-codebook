using System;
using System.Collections.Specialized;

namespace Addison_Wesley.Codebook.Basics
{
	public class SortUtils
	{
	
		/* Methode zum Sortieren einer StringCollection */
		public static void Sort(StringCollection col)
		{
			// StringCollection in ein Array kopieren
			// und dieses sortieren 
			string[] values = new string[col.Count];
			col.CopyTo(values, 0);
			Array.Sort(values);
         
			// Das Ergebnis wieder zurückkopieren
			for (int i = 0; i < values.Length; i++)
				col[i] = values[i];
		}
		
		/* Methode zum Sortieren einer StringCollection nach dem Heapsort-Algorithmus
		 * (leicht fehlerhaft, da das erste Element nicht berücksichtigt wird) */
		public static void Heapsort(StringCollection col) 
		{
			int l, j, ir, i;
			string rra;

			l = ((col.Count -1) >> 1) + 1;
			ir = col.Count - 1;
			for (;;) 
			{
				if (l > 1) 
				{
					rra = col[--l];
				} 
				else 
				{
					rra = col[ir];
					col[ir] = col[1];
					if (--ir == 1) 
					{
						col[1] = rra;
						return;
					}
				}
				i = l;
				j = l << 1;
				while (j <= ir) 
				{
					if (j < ir && col[j].CompareTo(col[j+1]) < 0) 
						++j;
					if (rra.CompareTo(col[j]) < 0) 
					{
						col[i] = col[j];
						j += (i = j);
					} 
					else 
					{
						j = ir + 1;
					}
				}
				col[i] = rra;
			}
		}

		
		/* Methode zum Sortieren einer StringCollection nach dem 
		 * Quicksort-Algorithmus */
		public static void Quicksort(StringCollection col)
		{
			// Aufruf der rekursiven Sortiermethode
			quicksort(col, 0, col.Count - 1);
		}

		/* Rekursive Methode zum Sortieren eines Teilabschnitts */
		private static void quicksort(StringCollection col, int start, int end)
		{
			int left = start;
			int right = end;
			
			if (end > start)
			{
				// Position des Pivot-Elements in der Mitte
				// berechnen
				int pivotIndex = (start + end) / 2;

				// Solange durchlaufen, bis der linke Zähler größer gleich dem rechten ist
				while (left <= right)
				{
					// Vom Anfang aus nach rechts das erste Element suchen, das größer oder
					// gleich dem Pivot-Element ist
					for (; left < end; left++)
					{
						if (col[left].CompareTo(col[pivotIndex]) >= 0)
							break;
					}

					// Vom Ende aus nach links das erste Element suchen, das kleiner oder
					// gleich dem Pivot-Element ist
					for (; right > start; right--)
					{
						if (col[right].CompareTo(col[pivotIndex]) <= 0)
							break;
					}

					// Falls die Indizes sich nicht überschnitten haben werden
					// die Elemente getauscht
					if (left <= right)
					{
						string value = col[left];
						col[left] = col[right];
						col[right] = value;

						left++;
						right--;
					}

					// Den linken Teil rekursiv sortieren falls der rechte Index
					// nicht den Anfang erreicht hat
					if (right > start)
						quicksort(col, start, right);

					// Den rechten Teil rekursiv sortieren falls der linke Index
					// nicht das Ende erreicht hat
					if (left < end)
						quicksort(col, left, end);
				}
			}
		}
	}
}

