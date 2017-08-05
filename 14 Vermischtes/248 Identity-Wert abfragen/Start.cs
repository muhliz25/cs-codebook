using System;
using System.Data;
using System.Data.SqlClient;

namespace Identity_Wert_abfragen
{
	class Start
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Verbindung zur Bookstore-Datenbank auf dem lokalen SQL Server aufbauen
			SqlConnection connection = null;
			try
			{
				connection = new SqlConnection("Server=(local);" +
					"Database=Bookstore;Trusted_Connection=Yes");
				connection.Open();

				// Autor hinzufügen
				string sql = "INSERT INTO Authors (FirstName, LastName) " +
					"VALUES ('Matt', 'Ruff')";
				SqlCommand command = new SqlCommand(sql, connection);
				command.ExecuteNonQuery();

				// Den Wert der @@IDENTITY-Variablen auslesen
				sql = "SELECT @@IDENTITY";
				command = new SqlCommand(sql, connection);
				int identityValue = Convert.ToInt32(command.ExecuteScalar());

				Console.WriteLine("Id des neuen Autors: {0}", identityValue);


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
