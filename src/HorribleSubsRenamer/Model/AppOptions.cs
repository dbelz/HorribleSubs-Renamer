using CommandLine;
using System.Collections.Generic;

namespace HorribleSubsRenamer.Model
{
    public class AppOptions
    {
        [Option("dir", HelpText = "This option is used to specify the directory where the files to rename are located.", Default = null, Required = false)]
        public string Directory { get; set; }

        [Option("extensions", Required = false)]
        public IEnumerable<string> Extensions { get; set; }        

        [Option("season", HelpText = "Can be used for specifying the season.", Default = 1, Required = false)]
        public int Season { get; set; }

        [Option("headless", HelpText = "Can be used to run the application in headless mode (not asking for confirmations.", Required = false, Default = true)]
        public bool Headless { get; set; }
    }
}
