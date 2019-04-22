using System.IO;

namespace HorribleSubsRenamer.Model
{
    public class FileRenameJob
    {
        public string NewFileName { get; }
        public FileInfo File { get; }

        public FileRenameJob(
            string newFileName,
            FileInfo file)
        {
            NewFileName = newFileName;
            File = file;
        }
    }
}
