using System;
using WindowsSensorClient.WebService;

namespace WindowsSensorClient
{
    /// <summary>
    /// Reads temperature and reports to to web service.
    /// </summary>
    public sealed class Monitor
    {
        private readonly ConnectionInformation _connectionInformation;
        private readonly int _sensorId;

        public Monitor(ConnectionInformation connectionInformation, int sensorId)
        {
            if (connectionInformation == null)
                throw new ArgumentNullException("connectionInformation", "connectionInformation is required.");
            _connectionInformation = connectionInformation;
            _sensorId = sensorId;
        }

        public void ReadAndReport()
        {
            using (var temperatureReader = new TemperatureReader())
            using (var client = new WebServiceClient(_connectionInformation.Url, _connectionInformation.Username, _connectionInformation.Password, _sensorId))
            {
                var temperature = temperatureReader.ReadCpuTemperature();
                if (temperature.HasValue)
                {
                    client.Authenticate();
                    client.SendTemperature(temperature.Value);
                }
            }
        }
    }
}
