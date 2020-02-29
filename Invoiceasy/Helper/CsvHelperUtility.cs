using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.Helper
{
    public static class CsvHelperUtility
    {
        //private static string _basePath = Environment.CurrentDirectory;
        private static string _basePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Invoiceasy";
        public static List<T1> ReadDataFromFile<T1, T2>(string filePath) where T1 : class //new()
                                                                            where T2 : ClassMap<T1>//, new()
        {
            //T1 p = new T1();
            //T2 r = new T2();
            
            using (var reader = new StreamReader(_basePath + filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                //CsvReader csv = new CsvReader(new StreamReader(basePath + filePath)); //No Longer work after v13+
                csv.Configuration.RegisterClassMap<T2>();
                csv.Configuration.Delimiter = ",";
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;
                //csv.Configuration.BadDataFound = null;
                List<T1> csvResult = csv.GetRecords<T1>().ToList();

                return csvResult;

            }
        }

        public static bool WriteDataToFile<T>(bool ignoreBasePath, string filePath, string delimiter, List<T> dataList) where T : class
        {
            var exactLocation = filePath;

            if (!ignoreBasePath)
            {
                exactLocation = _basePath + filePath;
            }
            
            using (var writer = new StreamWriter(exactLocation))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = delimiter;
                csv.WriteRecords(dataList);
                return true;
            }
        }

        public static bool InsertManyNewDataToFile<T>(bool ignoreBasePath, string filePath, string delimiter, List<T> dataList) where T : class
        {
            var exactLocation = filePath;

            if (!ignoreBasePath)
            {
                exactLocation = _basePath + filePath;
            }

            // Do not include the header row if the file already exists
            CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = !File.Exists(exactLocation)
            };

            // WARNING: This will throw an error if the file is open in Excel!
            using (FileStream fileStream = new FileStream(exactLocation, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    using (var csv = new CsvWriter(streamWriter, csvConfig))
                    {
                        // Append records to csv OR txt
                        csv.WriteRecords(dataList);
                        return true;
                    }
                }
            }
        }

        public static bool InsertOneNewDataToFile<T>(bool ignoreBasePath, string filePath, string delimiter, T data) where T : class
        {
            var dataList = new List<T>();

            dataList.Add(data);

            var isSuccess = InsertManyNewDataToFile<T>(ignoreBasePath, filePath, delimiter, dataList);

            return isSuccess;
        }
    }
}
