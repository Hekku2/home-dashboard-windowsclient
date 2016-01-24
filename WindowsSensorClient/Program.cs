using System;
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;
using WindowsSensorClient.Output;
using WindowsSensorClient.Properties;
using CommandLine;

namespace WindowsSensorClient
{
    public class Program
    {
        private static readonly CommandLineParameters Options = new CommandLineParameters();
        private static IOutput _output;

        public static void Main(string[] args)
        {
            //No arguments are currently read when ran in service mode.
            if (!Environment.UserInteractive)
            {
                ServiceBase.Run(new SensorMonitoringService());
                return;
            }

            if (Parser.Default.ParseArguments(args, Options))
            {
                _output = new ProgramOutput(Options);

                if (Options.SingleRun)
                {
                    _output.Print("Initializing single run for sensor {0}", Settings.Default.SensorId);
                    var monitor = new Monitor(GetConnectionInformation(), Settings.Default.SensorId);
                    monitor.ReadAndReport();
                    _output.Print("Run finished.");
                    return;
                }

                if (Options.Install)
                {
                    _output.Print("Installing service...");
                    Install();
                    _output.Print("Service installed. Exiting...");
                    return;
                }

                if (Options.Uninstall)
                {
                    _output.Print("Installing service...");
                    Uninstall();
                    _output.Print("Service installed. Exiting...");
                    return;
                }               
            }
            else
            {
                _output = new ConsoleOutput();
            }
            _output.Print(Options.GetUsage());
        }

        private static ConnectionInformation GetConnectionInformation()
        {
            return new ConnectionInformation(Settings.Default.BackEndAddress, Settings.Default.Username,
                Settings.Default.Password);
        }

        private static void Install()
        {
            ManagedInstallerClass.InstallHelper(new[] { Assembly.GetExecutingAssembly().Location });
        }

        private static void Uninstall()
        {
            ManagedInstallerClass.InstallHelper(new[] { "/u", Assembly.GetExecutingAssembly().Location });
        }
    }
}
