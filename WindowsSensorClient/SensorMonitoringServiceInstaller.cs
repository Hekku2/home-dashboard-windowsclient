using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace WindowsSensorClient
{
    [RunInstaller(true)]
    public class SensorMonitoringServiceInstaller : Installer
    {
        public SensorMonitoringServiceInstaller()
        {
            var processInstaller = new ServiceProcessInstaller();
            var serviceInstaller = new ServiceInstaller();

            //set the privileges
            processInstaller.Account = ServiceAccount.LocalSystem;

            serviceInstaller.DisplayName = "Home Dashboard Monitor";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            //must be the same as what was set in Program's constructor
            serviceInstaller.ServiceName = "Home Dashboard Monitor";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
