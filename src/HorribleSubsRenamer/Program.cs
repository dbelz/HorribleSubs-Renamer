using CommandLine;
using Crayon;
using HorribleSubsRenamer.Extensions;
using HorribleSubsRenamer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HorribleSubsRenamer
{
    class Program
    {
        private static readonly List<FileRenameJob> _jobs = new List<FileRenameJob>();

        private static int _season;
        private static IEnumerable<string> _extensions;
        private static string _oldValue;
        private static string _newValue;
        private static bool _shouldRunHeadless;

        static void Main(string[] args)
        {
            Console.Title = "HorribleSubs Renamer";

            Parser.Default.ParseArguments<AppOptions>(args)
            .WithParsed(options =>
            {
                _season = options.Season;
                _extensions = options.Extensions;
                _oldValue = options.OldValue;
                _newValue = options.NewValue;
                _shouldRunHeadless = options.ShouldRunHeadless;

                if (!options.Extensions.Any())
                    _extensions = new List<string> { "mkv" };

                if (options.SourceDirectory == null)
                    options.SourceDirectory = Environment.CurrentDirectory;

                var directory = new DirectoryInfo(options.SourceDirectory);

                if (!directory.Exists)
                {
                    WriteLine(Output.BrightRed("The provided path does not lead to a directory!"), false);
                    ShowMessageAndExit();
                }

                PopulateFileRenameJobList(directory);

                if (!_jobs.Any())
                {
                    WriteLine(Output.BrightRed($"No files where found in directory '{directory.Name}'"), false);
                    ShowMessageAndExit();
                }

                if (!options.ShouldRunHeadless)
                {
                    if (!QueryUserForConfirmation())
                        return;

                    WriteLine(string.Empty, false);
                    WriteLine(string.Empty, false);
                }

                foreach (var item in _jobs)
                {
                    if (!File.Exists(item.File.FullName))
                    {
                        WriteLine(Output.BrightYellow($"Skipping file '{item.File.Name}' because it does not exist anymore!"));
                        return;
                    }

                    try
                    {
                        var targetDirectory = directory;

                        if (options.ShouldCreateSubfolders)
                        {
                            targetDirectory = directory.CreateSubdirectory(item.NewFileName.Replace(item.File.Extension, ""));
                            WriteLine(Output.Green($"Created directory for file '{item.File.Name}'"));
                        }

                        File.Move(item.File.FullName, Path.Combine(targetDirectory.FullName, item.NewFileName));
                        WriteLine(Output.Green($"Renamed file '{item.File.Name}' to '{item.NewFileName}'"));
                    }
                    catch (Exception e)
                    {
                        WriteLine(Output.BrightRed($"Failed to process file '{item.File.Name}' : {e.Message}"));
                    }
                }
            });

            Console.ReadLine();
        }

        private static bool QueryUserForConfirmation()
        {
            WriteLine($"{_jobs.Count} file(s) where found to rename. Do you want to proceed? (y / any other key for exit)", false);
            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.Y)
                return true;

            return false;
        }

        private static void PopulateFileRenameJobList(DirectoryInfo directory)
        {
            var files = directory.GetFiles().Where(f => _extensions.Contains(f.Extension.Replace(".", "")));

            if (!files.Any())
                return;

            foreach(var file in files)
            {
                var nameAndEpisode = file.Name.Between("]", "[");

                if (string.IsNullOrWhiteSpace(nameAndEpisode))
                    return;

                var nameAndEpisodeSplit = nameAndEpisode.Split(" - ");

                if (nameAndEpisodeSplit.Length < 2)
                    return;

                string name = nameAndEpisodeSplit[0].Trim();
                string episode = nameAndEpisodeSplit[1].Trim();

                if (_oldValue != null && _newValue != null)
                    name = name.Replace(_oldValue, _newValue);

                var item = new FileRenameJob(
                    GetNewFileName(name, episode, file.Extension),
                    file);

                _jobs.Add(item);
            };
        }

        private static string GetNewFileName(
            string title,
            string episode,
            string extension)
        {
            string season = _season.ToString();

            if (_season < 10)
                season = $"0{_season}";

            return $"{title} - s{season}e{episode}{extension}";
        }

        private static void ShowMessageAndExit()
        {
            WriteLine($"The application will exit in 5 seconds..", false);
            Thread.Sleep(5000);

            Environment.Exit(0);
        }

        private static void WriteLine(string input, bool printDateTime = true)
        {
            if (_shouldRunHeadless)
                return;

            if (printDateTime)
                Console.WriteLine($"{DateTime.Now} : {input}");
            else
                Console.WriteLine(input);
        }
    }
}
