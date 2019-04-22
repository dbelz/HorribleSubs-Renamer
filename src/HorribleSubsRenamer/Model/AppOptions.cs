using CommandLine;
using System.Collections.Generic;

namespace HorribleSubsRenamer.Model
{
    public class AppOptions
    {
        [Option("extensions", Required = false)]
        public IEnumerable<string> Extensions { get; set; }

        [Option("dir", HelpText = "Can be used for specifying the directory where the media files are located.", Default = null, Required = false)]
        public string Directory { get; set; }

        [Option("season", HelpText = "Can be used for specifying the season.", Default = 1, Required = false)]
        public int Season { get; set; }
    }
}
