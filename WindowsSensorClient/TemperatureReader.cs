using System;
using System.Linq;
using OpenHardwareMonitor.Hardware;

namespace WindowsSensorClient
{
    public sealed class TemperatureReader : IDisposable
    {
        private readonly Computer _computer = new Computer();

        public float? ReadCpuTemperature()
        {
            _computer.Open();
            _computer.CPUEnabled = true;
            var cpu = _computer.Hardware.FirstOrDefault(hw => hw.HardwareType == HardwareType.CPU);
            if (cpu == null)
                return null;

            var temperatureSensor = cpu.Sensors.FirstOrDefault(s => s.SensorType == SensorType.Temperature);

            return temperatureSensor == null ? null : temperatureSensor.Value;
        }

        public void Dispose()
        {
            if (_computer != null)
                _computer.Close();
        }
    }
}
