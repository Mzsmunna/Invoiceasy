using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.Helper
{
    public class ExcelApp
    {
        public Application _xlApp { set; get; }
        public Workbook _xlWorkBook { get; set; }
        public Worksheet _xlWorkSheet { get; set; }
        public Range _xlRange { get; set; }
        public object _misValue { get; set; }

        public ExcelApp()
        {
            _xlApp = new Application();
            _misValue = System.Reflection.Missing.Value; // needed when creating or saving a excel file
        }

        public bool CreateNewExcelFile()
        {
            _xlWorkBook = _xlApp.Workbooks.Add(_misValue);
            return true;
        }

        public bool LoadExcelFile(string filePath, int sheetNumber)
        {
            _xlWorkBook = _xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            _xlWorkSheet = (Worksheet)_xlWorkBook.Worksheets.get_Item(sheetNumber);
            //_xlWorkBook.Close();
            return true;
        }
    }
}
