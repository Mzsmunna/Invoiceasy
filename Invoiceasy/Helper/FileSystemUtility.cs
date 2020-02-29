using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.Helper
{
    public static class FileSystemUtility
    {
        private static string _fileLocation;
        private static string _fullPathWithFileName;
        private static string _fileName;
        private static string _fileText;
        private static string _appPath = Environment.CurrentDirectory;
        private static bool _ignoreAppPath = false;
        //private static string _userDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static void Initialize(bool ignoreAppPath, Files file)
        {
            _ignoreAppPath = ignoreAppPath;
            _fileText = file.FileText;
            _fileLocation = file.FileLocation;
            _fileName = file.FileName;

            _fullPathWithFileName = file.FileLocation + @"\" + file.FileName;

            if(!_ignoreAppPath)
            {
                _fileLocation = _appPath + @"\" + file.FileLocation;
                _fullPathWithFileName = _appPath + @"\" + file.FileLocation + @"\" + file.FileName;
            }

        }

        public static bool CreateFile()
        {
            return false;
        }

        public static bool RenameFile(string oldFile, string newFile)
        {
            File.Move(oldFile, newFile);
            return true;
        }

        public static string ReadFile(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                string text;
                var fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }
                return text;
            }

            return "";
        }

        public static bool WriteFile()
        {
            CreateFolder();

            using (var fileStream = File.Open(_fullPathWithFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.Write(_fileText);
                    return true;
                }
            }
        }

        public static bool SaveFile()
        {
            return false;
        }

        public static bool CopyFile(string fromPath, string toPath, bool overwrite)
        {
            if(File.Exists(toPath) && overwrite == false)
            {
                return false;
            }
            else
            {
                if (File.Exists(fromPath))
                {
                    File.Copy(fromPath, toPath, overwrite);
                    return true;
                }
                else
                {
                    return false;
                }               
            }
        }

        public static void CopyFolder(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAllFiles(diSource, diTarget);
        }

        public static void CopyAllFiles(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAllFiles(diSourceSubDir, nextTargetSubDir);
            }
        }

        private static bool DeleteFile()
        {
            return false;
        }

        public static bool DeleteFile(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);

                return true;
            }

            return false;
        }

        public static void CreateFolder(string fullPath)
        {
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);
        }

        private static void CreateFolder()
        {
            if (!Directory.Exists(_fileLocation))
                Directory.CreateDirectory(_fullPathWithFileName);
        }

        public static string GetFileDirectory(string fullPath)
        {
            var subString = GetSubstringOfIndex(fullPath, false);
            return subString;
        }

        public static string GetFileName(string fullPath)
        {
            var subString = GetSubstringOfIndex(fullPath, true);
            return subString;
        }

        private static string GetSubstringOfIndex(string fullPath, bool fromCurrentIndex)
        {
            int index = fullPath.LastIndexOf(@"\");
            string subString = string.Empty;

            if (index != -1)
            {
                if(fromCurrentIndex)
                {
                    subString = fullPath.Substring(index + 1);
                }
                else
                {
                    subString = fullPath.Substring(0, index + 1);
                }                
            }

            return subString;
        }

        public static FileInfo[] GetFilesFromFolder(string directory, string fileName)
        {
            CreateFolder(directory);
            //string partialName = "171_s";
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(directory);
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + fileName + "*.*");
            //List <FileInfo> filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + fileName + "*.*");

            //foreach (FileInfo foundFile in filesInDir)
            //{
            //    string fullName = foundFile.FullName;
            //    Console.WriteLine(fullName);
            //}
            filesInDir = filesInDir.OrderByDescending(x=>x.CreationTime).ToArray();
            return filesInDir;
        }
    }

    public class Files
    {
        public string FileLocation { get; set; }
        public string FileName { get; set; }
        public string FileText { get; set; }
    }
}
