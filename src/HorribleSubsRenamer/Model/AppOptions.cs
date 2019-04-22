using CommandLine;
using System.Collections.Generic;

namespace HorribleSubsRenamer.Model
{
    public class AppOptions
    {
        [Option("source", HelpText = "This option is used to specify the directory where the files to rename are located.", Default = null, Required = false)]
        public string SourceDirectory { get; set; }

        [Option("extensions", HelpText = "This option is used to specify the file extensions which should be indexed.", Required = false)]
        public IEnumerable<string> Extensions { get; set; }        

        [Option("season", HelpText = "This option is used to specify the season number.", Default = 1, Required = false)]
        public int Season { get; set; }

        [Option("old-value", HelpText = "This option contains the value which should be replaced in the extracted title.", Default = null, Required = false)]
        public string OldValue { get; set; }

        [Option("new-value", HelpText = "This option contains the value which should be placed in the extracted title instead of the string specific in the 'old-value' parameter.", Default = null, Required = false)]
        public string NewValue { get; set; }

        [Option("create-subfolders", HelpText = "Used to specify if the application should create a directory for every renamed episode.", Default = true, Required = true)]
        public bool ShouldCreateSubfolders { get; set; }

        [Option("headless", HelpText = "Used to specify if the application should run in headless mode (not asking for confirmation).", Default = false, Required = false)]
        public bool ShouldRunHeadless { get; set; }
    }
}
