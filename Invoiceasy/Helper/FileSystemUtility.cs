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

        public static void Initialize(bool ignoreAppPath, string fileName, string fileLocation, string fileText)
        {
            _ignoreAppPath = ignoreAppPath;
            _fileText = fileText;
            _fileLocation = fileLocation;
            _fileName = fileName;

            _fullPathWithFileName = _fileLocation + @"\" + _fileName;

            if(!_ignoreAppPath)
            {
                _fileLocation = _appPath + @"\" + _fileLocation;
                _fullPathWithFileName = _appPath + @"\" + _fileLocation + @"\" + _fileName;
            }

        }

        public static bool CreateFile()
        {
            return false;
        }

        public static string ReadFile()
        {
            return null;
        }

        public static bool WriteFile()
        {
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

        public static bool CopyFile()
        {
            return false;
        }

        public static bool DeleteFile()
        {
            return false;
        }

        public static void CreateFolder()
        {
            if (!Directory.Exists(_fileLocation))
                Directory.CreateDirectory(_fullPathWithFileName);
        }

        public static List<string> GetFilesInFolder()
        {
            return null;
        }

    }
}
