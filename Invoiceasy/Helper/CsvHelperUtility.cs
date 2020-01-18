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
        public static List<T1> ReadDataFromFile<T1, T2>(string filePath) where T1 : class //new()
                                                                            where T2 : ClassMap<T1>//, new()
        {
            //T1 p = new T1();
            //T2 r = new T2();

            string basePath = Environment.CurrentDirectory;
            using (var reader = new StreamReader(basePath + filePath))
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
    }
}
