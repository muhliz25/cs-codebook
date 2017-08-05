using System;
using System.Data;
using System.Data.SqlClient;

namespace Anzahl_Datens�tze
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Verbindung zur Northwind-Datenbank auf dem lokalen SQL Server aufbauen
			SqlConnection connection = null;
			try
			{
				connection = new SqlConnection("Server=(local);Database=Northwind;" +
					"Trusted_Connection=Yes");
				connection.Open();

				// Produkte abfragen
				SqlCommand command = new SqlCommand("SELECT COUNT(*) AS Count, " +
					"ProductName, ProductId  FROM Products WHERE CategoryId = 1 " +
					"GROUP BY ProductName, ProductId", connection);
			
				Console.WriteLine("{0} Datens�tze", command.ExecuteScalar());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				try 
				{
					connection.Close();
				}
				catch {}
			}

			Console.WriteLine("Beenden mit Return");
			Console.ReadLine();
		}
	}
}
