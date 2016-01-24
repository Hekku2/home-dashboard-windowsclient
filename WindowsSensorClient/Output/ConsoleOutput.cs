using System;

namespace WindowsSensorClient.Output
{
    public class ConsoleOutput : IOutput
    {
        public void Print(string format, params object[] objects)
        {
            Console.WriteLine(format, objects);
        }
    }
}
