using System.ServiceProcess;
using WindowsSensorClient.Properties;

namespace WindowsSensorClient
{
    partial class SensorMonitoringService : ServiceBase
    {
        private readonly MonitoringWorker _monitoringWorker;

        public SensorMonitoringService()
        {
            InitializeComponent();
            _monitoringWorker = new MonitoringWorker(new ConnectionInformation(Settings.Default.BackEndAddress, Settings.Default.Username, Settings.Default.Password), Settings.Default.SensorId);
        }

        protected override void OnStart(string[] args)
        {
            _monitoringWorker.Start();
        }

        protected override void OnStop()
        {
            if (_monitoringWorker != null)
            {
                _monitoringWorker.Dispose();
            }
        }
    }
}
