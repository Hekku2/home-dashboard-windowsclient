using System.Collections.Generic;

namespace WindowsSensorClient.Output
{
    public class ProgramOutput : IOutput
    {
        private readonly List<IOutput> _outputs = new List<IOutput>();

        public ProgramOutput(CommandLineParameters parameters)
        {
            if (!parameters.Quiet)
            {
                _outputs.Add(new ConsoleOutput());
            }
        }

        public void Print(string format, params object[] objects)
        {
            foreach (var output in _outputs)
            {
                output.Print(format, objects);
            }
        }
    }
}
