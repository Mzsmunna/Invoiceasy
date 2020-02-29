using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.Helper
{
    public static class ExcelApp
    {
        public static Application XlApp { set; get; }
        public static Workbook XlWorkBook { get; set; }
        public static Worksheet XlWorkSheet { get; set; }
        public static Range XlRange { get; set; }
        public static object MisValue { get; set; }

        static ExcelApp()
        {
            if(XlApp == null)
                XlApp = new Application();

            MisValue = System.Reflection.Missing.Value; // needed when creating or saving a excel file
        }

        public static bool CreateNewExcelFile()
        {
            XlWorkBook = XlApp.Workbooks.Add(MisValue);
            return true;
        }

        public static bool LoadExcelFile(string filePath, int sheetNumber)
        {
            XlWorkBook = XlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            XlWorkSheet = (Worksheet)XlWorkBook.Worksheets.get_Item(sheetNumber);
            //XlWorkBook.Close();
            return true;
        }
    }
}
