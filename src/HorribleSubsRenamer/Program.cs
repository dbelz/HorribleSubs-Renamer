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

                if (!options.Extensions.Any())
                    _extensions = new List<string> { "mkv" };

                if (options.Directory == null)
                    options.Directory = Environment.CurrentDirectory;

                var directory = new DirectoryInfo(options.Directory);

                if (!directory.Exists)
                    throw new ArgumentException("The provided path does not lead to a directory!");

                PopulateFileRenameJobList(directory);

                if (!_jobs.Any())
                {
                    Console.WriteLine(Output.BrightRed($"No files where found in directory '{directory.Name}'! The application will exit in 5 seconds.."));
                    Thread.Sleep(5000);
                    return;
                }

                if (!options.Headless)
                {
                    if (!QueryUserForConfirmation())
                        return;

                    Console.WriteLine();
                    Console.WriteLine();
                }

                Parallel.ForEach(_jobs, (item) =>
                {
                    if (!File.Exists(item.File.FullName))
                    {
                        WriteLine(Output.BrightYellow($"Skipping file '{item.File.Name}' because it does not exist anymore!"));
                        return;
                    }

                    WriteLine(Output.Green($"Renaming file '{item.File.Name}' to '{item.NewFileName}'"));

                    File.Move(item.File.FullName, Path.Combine(directory.FullName, item.NewFileName));
                });

                Console.ReadLine();
            });
        }

        private static bool QueryUserForConfirmation()
        {
            Console.WriteLine($"{_jobs.Count} file(s) where found to rename. Do you want to proceed? (y / any other key for exit)");
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

            Parallel.ForEach(files, (file) =>
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
            });
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

        private static void WriteLine(string input)
        {
            Console.WriteLine($"{DateTime.Now} : {input}");
        }
    }
}
