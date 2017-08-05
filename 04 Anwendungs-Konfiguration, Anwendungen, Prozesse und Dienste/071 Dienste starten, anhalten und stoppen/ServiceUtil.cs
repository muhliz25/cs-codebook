using System;
using System.ServiceProcess;

namespace Addison_Wesley.Codebook.Services
{
	public class ServiceUtil
	{
		/* Methode zum Starten eines Dienstes */
		public static ServiceControllerStatus StartService(string serviceName, 
			string machineName, string[] arguments, int timeout)
		{
			// Dienst ermitteln
			if (machineName == null) machineName = ".";
			ServiceController service = new ServiceController(serviceName,
				machineName);

			// Dienst starten, falls dieser nicht bereits gestartet ist oder wird
			if (service.Status != ServiceControllerStatus.Running &&
				service.Status != ServiceControllerStatus.StartPending &&
				service.Status != ServiceControllerStatus.ContinuePending)
			{
				if (arguments != null)
					service.Start(arguments);
				else
					service.Start();
			}

			// Den übergebenen Timeout (in Millisekunden) warten, 
			// bis der Dienst den Status Running besitzt
			service.WaitForStatus(ServiceControllerStatus.Running,
				new TimeSpan(0, 0, 0, timeout));

			// Status des Dienstes zurückliefern
			return service.Status;
		}

		/* Methode zum toleranten Anhalten eines Dienstes */
		public static ServiceControllerStatus PauseService(string serviceName,
			string machineName, int timeout)
		{
			// Dienst ermitteln
			if (machineName == null) machineName = ".";
			ServiceController service = new ServiceController(serviceName,
				machineName);

			// Überprüfen, ob der Dienst angehalten werden kann
			if (service.CanPauseAndContinue == false)
				throw new Exception("Der Dienst '" + serviceName + 
					"' kann nicht angehalten werden");

			// Dienst anhalten, falls dieser nicht bereits angehalten ist
			if (service.Status != ServiceControllerStatus.Paused &&
				service.Status != ServiceControllerStatus.PausePending &&
				service.Status != ServiceControllerStatus.StopPending)
				service.Pause();

			// Den übergebenen Timeout (in Millisekunden) warten, 
			// bis der Dienst den Status Paused besitzt
			service.WaitForStatus(ServiceControllerStatus.Paused,
				new TimeSpan(0, 0, 0, timeout));
   
			// Status des Dienstes zurückliefern
			return service.Status;
		}

		/* Methode zum Fortfahren eines Dienstes */
		public static ServiceControllerStatus ContinueService(string serviceName, 
			string machineName, int timeout)
		{
			// Dienst ermitteln
			if (machineName == null) machineName = ".";
			ServiceController service = new ServiceController(
				serviceName, machineName);

			// Überprüfen, ob der Dienst fortgefahren werden kann
			if (service.CanPauseAndContinue == false)
				throw new Exception("Der Dienst '" + serviceName + 
					"' kann nicht fortgefahren werden");

			// Dienst fortfahren, falls dieser nicht bereits ausgeführt wird 
			// oder gerade startet 
			if (service.Status != ServiceControllerStatus.Running &&
				service.Status != ServiceControllerStatus.StartPending &&
				service.Status != ServiceControllerStatus.ContinuePending)
				service.Continue();
   
			// Den übergebenen Timeout (in Millisekunden) warten, bis der Dienst den
			// Status Running besitzt
			service.WaitForStatus(ServiceControllerStatus.Running,
				new TimeSpan(0, 0, 0, timeout));

			// Status des Dienstes zurückliefern
			return service.Status;
		}

		/* Methode zum Stoppen eines Dienstes */
		public static ServiceControllerStatus StopService(string serviceName,
			string machineName, int timeout)
		{
			// Dienst ermitteln
			if (machineName == null) machineName = ".";
			ServiceController service = new ServiceController(serviceName,
				machineName);

			// Überprüfen, ob der Dienst gestoppt werden kann
			if (service.CanStop == false)
				throw new Exception("Der Dienst '" + serviceName + 
					"' kann nicht gestoppt werden");
   
			// Dienst stoppen, falls dieser nicht gestoppt ist oder gerade stoppt
			if (service.Status != ServiceControllerStatus.Stopped && 
				service.Status != ServiceControllerStatus.StopPending)
				service.Stop();

			// Warten, bis der Dienst den Status Stopped besitzt
			service.WaitForStatus(ServiceControllerStatus.Stopped,
				new TimeSpan(0, 0, timeout));

			// Status des Dienstes zurückliefern
			return service.Status;
		}
	}
}
