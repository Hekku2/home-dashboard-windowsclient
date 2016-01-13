using WindowsSensorClient.Properties;

namespace WindowsSensorClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var temperatureReader = new TemperatureReader())
            using (var client = new WebServiceClient(Settings.Default.BackEndAddress, Settings.Default.Username, Settings.Default.Password, Settings.Default.SensorId))
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
