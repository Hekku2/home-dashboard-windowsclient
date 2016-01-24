using System;

namespace WindowsSensorClient
{
    /// <summary>
    /// Worker periodically monitors computer.
    /// </summary>
    public class MonitoringWorker : BaseWorker
    {
        private readonly Monitor _monitor;

        public MonitoringWorker(ConnectionInformation connectionInformation, int sensorId) : base(TimeSpan.FromSeconds(10))
        {
            _monitor = new Monitor(connectionInformation, sensorId);
        }

        protected override void OnWork()
        {
            try
            {
                _monitor.ReadAndReport();
            }
            catch (Exception)
            {
                //TODO handle exception
            }
        }
    }
}
