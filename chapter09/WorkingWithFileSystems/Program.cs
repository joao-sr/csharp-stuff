using System.IO;
using static System.IO.Directory;
using static System.Environment;
using static System.IO.Path;

namespace WorkingWithFileSystems
{
    class Program
    {
        public static void Main(string[] args)
        {
            //OutputFileSystemInfo();
            //WorkingWithDrives();

            //WorkingWithDirectories();
            WorkWithFiles();
        }
        public static void OutputFileSystemInfo()
        {
            System.Console.WriteLine($"{"Path.PathSeparator", -33} {PathSeparator}");
            System.Console.WriteLine($"{"Path.DirectorySeparatorChar", -33} {DirectorySeparatorChar}");
            System.Console.WriteLine($"{"Directory.GetCurrentDirectory()", -33} {GetCurrentDirectory()}");
            System.Console.WriteLine($"{"Environment.CurrentDirectory", -33} {CurrentDirectory}");
            System.Console.WriteLine($"{"Environment.SystemDirectory", -33} {SystemDirectory}");
            System.Console.WriteLine($"{"Path.GetTempPath()", -33} {GetTempPath()}");

            System.Console.WriteLine("GetFolderPath(SpecialFolder");
            System.Console.WriteLine($"{" .System)", -33} {GetFolderPath(SpecialFolder.System)}");
            System.Console.WriteLine($"{" .ApplicationData)", -33} {GetFolderPath(SpecialFolder.ApplicationData)}");
            System.Console.WriteLine($"{" .MyDocuments)", -33} {GetFolderPath(SpecialFolder.MyDocuments)}");
            System.Console.WriteLine($"{" .Personal)", -33} {GetFolderPath(SpecialFolder.Personal)}");
        }

        static void WorkingWithDrives()
        {
            System.Console.WriteLine($"{"NAME",-30} | {"TYPE",-10} | {"FORMAT",-7} | {"SIZE(BYTES)", 18} | {"FREE SPACE", 18}");

            foreach(DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    System.Console.WriteLine($"{drive.Name,-30} | {drive.DriveType,-10} | {drive.DriveFormat,-7} | {drive.TotalSize, 18} | {drive.AvailableFreeSpace, 18}");
                }
                else
                {
                    System.Console.WriteLine($"{drive.Name, 30} | {drive.DriveType, -10}");
                }
            }
        }

        static void WorkingWithDirectories()
        {
            // define a directory path for a new folder
            // starting in the users folder
            var newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "_code_programming", "csharp-stuff", "chapter09", "NewFolder");

            System.Console.WriteLine($"Working with: {newFolder}");

            // checking if it exists
            System.Console.WriteLine($"Does it exist?: {Exists(newFolder)}");

            // create directory
            System.Console.WriteLine("Creating it ...");
            CreateDirectory(newFolder);
            System.Console.WriteLine($"Does it exist?: {Exists(newFolder)}");

            System.Console.Write("Confirm the directory exists, and press ENTER: ");
            System.Console.ReadLine();

            // delete directory
            System.Console.WriteLine("Deleting directory...");
            Delete(newFolder, recursive:true);
            System.Console.WriteLine($"Does it exist?: {Exists(newFolder)}");
        }

        static void WorkWithFiles()
        {
            // define a directory path to output files
            var dir = Combine(GetFolderPath(SpecialFolder.Personal), "_code_programming", "csharp-stuff", "chapter09", "OutputFiles");

            CreateDirectory(dir);

            // define file paths
            string textFile = Combine(dir, "Dummy.txt");
            string backupFile = Combine(dir, "Dummy.bak");

            System.Console.WriteLine($"Working with: {textFile}");

            // check if file exists
            System.Console.WriteLine($"File exists?: {File.Exists(textFile)}");

            // creta new text file and write a line to it
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello daniel san!");
            textWriter.Close(); // file and release resources

            System.Console.WriteLine($"Does it exist: {File.Exists(textFile)}");

            // copy the file and overwrite if it already exists
            File.Copy(sourceFileName: textFile, destFileName:backupFile, overwrite:true);

            System.Console.WriteLine($"Does {backupFile} exist?: {File.Exists(backupFile)}");

            System.Console.Write("Confirm the files exist, and then press ENTER: ");
            System.Console.ReadLine();

            // delete file
            File.Delete(textFile);

            System.Console.WriteLine($"Does it exist?: {File.Exists(textFile)}");

            // read from the textfile backup
            System.Console.WriteLine($"Reading contents of {backupFile}: ");
            StreamReader textReader = File.OpenText(backupFile);
            System.Console.WriteLine(textReader.ReadToEnd());
            textReader.Close();

            // managing paths
            System.Console.WriteLine($"Folder Name: {GetDirectoryName(textFile)}");
            System.Console.WriteLine($"File Name: {GetFileName(textFile)}");
            System.Console.WriteLine($"File Name without extension: {GetFileNameWithoutExtension(textFile)}");
            System.Console.WriteLine($"File extension: {GetExtension(textFile)}");
            System.Console.WriteLine($"Random File Name: {GetRandomFileName()}");
            System.Console.WriteLine($"Temporary File Name: {GetTempFileName()}");

            var info = new FileInfo(backupFile);
            System.Console.WriteLine($"{backupFile}: ");
            System.Console.WriteLine($"Contains {info.Length} bytes");
            System.Console.WriteLine($"Last accessed {info.LastAccessTime}");
            System.Console.WriteLine($"Has readonly set to {info.IsReadOnly}");
        }


    }
}