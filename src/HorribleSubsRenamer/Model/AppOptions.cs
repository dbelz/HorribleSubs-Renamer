using CommandLine;
using System.Collections.Generic;

namespace HorribleSubsRenamer.Model
{
    public class AppOptions
    {
        [Option("dir", HelpText = "This option is used to specify the directory where the files to rename are located.", Default = null, Required = false)]
        public string Directory { get; set; }

        [Option("extensions", HelpText = "This option is used to specify the file extensions which should be indexed.", Required = false)]
        public IEnumerable<string> Extensions { get; set; }        

        [Option("season", HelpText = "This option is used to specify the season number.", Default = 1, Required = false)]
        public int Season { get; set; }

        [Option("headless", HelpText = "This option is used to specify if the application should run in headless mode (not asking for confirmation etc.).", Required = false, Default = true)]
        public bool Headless { get; set; }
    }
}
