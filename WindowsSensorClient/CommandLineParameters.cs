using System;
using System.Reflection;
using CommandLine;
using CommandLine.Text;

namespace WindowsSensorClient
{
    public class CommandLineParameters
    {
        [Option('q', "quiet", DefaultValue = false,
            HelpText = "No console output.")]
        public bool Quiet { get; set; }

        [Option('s', "single-run", DefaultValue = false,
            HelpText = "Single run - Read sensor values and uploads them once.")]
        public bool SingleRun { get; set; }

        [Option("install-service", DefaultValue = false,
            HelpText = "Installs the service")]
        public bool Install { get; set; }

        [Option("uninstall-service", DefaultValue = false,
            HelpText = "Uninstalls the service")]
        public bool Uninstall { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var title = GetAssemblyAttribute<AssemblyTitleAttribute>(a => a.Title); 
            var description = GetAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description);
            var version = Assembly.GetEntryAssembly().GetName().Version;

            var help = new HelpText
            {
                Heading = new HeadingInfo(title, version.ToString()),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            help.AddPreOptionsLine(description);
            help.AddPostOptionsLine("Server credentials, address and sensor ID must be set in .config-file before usage.");
            help.AddOptions(this);


            return help;
        }

        private string GetAssemblyAttribute<T>(Func<T, string> value) where T : Attribute
        {
            var attribute = (T)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(T));
            return value.Invoke(attribute);
        }
    }
}
