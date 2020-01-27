using Invoiceasy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Invoiceasy.Manager
{
    public class InvoiceManager : IManager
    {
        private Excel.Application _xlApp { set; get; }
        private InvoicePageModel _invoiceData { set; get; }
        private Excel.Workbook _xlWorkBook { get; set; }
        private Excel.Worksheet _xlWorkSheet { get; set; }
        private Excel.Range _xlRange { get; set; }
        private object _misValue { get; set; }

        public InvoiceManager(InvoicePageModel invoiceData)
        {
            _invoiceData = invoiceData;
        }

        public bool Execute()
        {
            try
            {               
                int x = 13;
                if (_invoiceData != null)
                {
                    //**Writting the Excel File: **

                    string basePath = Environment.CurrentDirectory;
                    var filePath = @"\Libs\Files\CoreFiles\TemplateFiles\invoice-template.xlsx";
                    filePath = basePath + filePath;

                    _xlApp = new Excel.Application();
                    _misValue = System.Reflection.Missing.Value; // needed when creating or saving a excel file

                    //_xlWorkBook = _xlApp.Workbooks.Add(misValue); // when creating a new excel file
                    _xlWorkBook = _xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    _xlWorkSheet = (Excel.Worksheet)_xlWorkBook.Worksheets.get_Item(1);

                    //Console.WriteLine((_xlWorkSheet.Cells[12, 2] as Excel.Range).Text);
                    //Console.WriteLine((_xlWorkSheet.Cells[12, 4] as Excel.Range).Text);
                    //Console.WriteLine((_xlWorkSheet.Cells[12, 5] as Excel.Range).Text);
                    //Console.WriteLine((_xlWorkSheet.Cells[12, 6] as Excel.Range).Text);
                    //Console.WriteLine((_xlWorkSheet.Cells[12, 7] as Excel.Range).Text);

                    _xlWorkSheet.Cells[8, 3] = _invoiceData.No;
                    _xlWorkSheet.Cells[8, 7] = _invoiceData.Date;
                    _xlWorkSheet.Cells[9, 3] = _invoiceData.Dealer.DealerName;
                    _xlWorkSheet.Cells[9, 7] = _invoiceData.Dealer.Code;
                    _xlWorkSheet.Cells[10, 3] = _invoiceData.Dealer.Address;
                    _xlWorkSheet.Cells[11, 3] = _invoiceData.Dealer.Contact;
                    

                    if (_invoiceData.AllProducts != null)
                    {
                        while(x < 40)
                        {
                            foreach (var item in _invoiceData.AllProducts)
                            {
                                _xlWorkSheet.Cells[x, 2] = item.SerialNo;
                                _xlWorkSheet.Cells[x, 4] = item.ProductDescriptions;
                                _xlWorkSheet.Cells[x, 5] = item.UnitPrice;
                                _xlWorkSheet.Cells[x, 6] = item.Quantity;
                                _xlWorkSheet.Cells[x, 7] = item.TotalAmount;

                                x++;
                            }

                            if(x < 40)
                            {
                                break;
                            }
                        }
                        
                    }

                    _xlWorkSheet.Cells[40, 2] = _invoiceData.Note;
                    _xlWorkSheet.Cells[43, 3] = _invoiceData.AmountInWord;
                    _xlWorkSheet.Cells[40, 7] = _invoiceData.InTotalAmount;
                    _xlWorkSheet.Cells[41, 5] = _invoiceData.SpecialDiscount;
                    _xlWorkSheet.Cells[41, 7] = _invoiceData.DiscountAmount;
                    _xlWorkSheet.Cells[42, 7] = _invoiceData.PayableAmount;

                    //while (x <= 39)
                    //{
                    //    _xlWorkSheet.Cells[x, 7] = "";
                    //    x++;
                    //}

                    //var filePath2 = @"\Public\Output\in-output.xlsx";
                    _xlWorkBook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, @"E:\xyz.pdf");

                    //PrintOut();

                    _xlWorkBook.Close();

                    //_xlWorkBook.SaveAs(filePath2, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue,
                    //Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    
                    _xlApp.Quit();

                    return true;
                }
                else
                {
                    Console.WriteLine("Nothing to Print or write on Excel file");
                    return false;
                }               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        private void PrintOut()
        {
            // Get the current printer
            string Defprinter = null;
            Defprinter = _xlApp.ActivePrinter;

            // Set the printer to Microsoft XPS Document Writer
            _xlApp.ActivePrinter = "Microsoft XPS Document Writer on Ne01:";

            // Setup our sheet
            var _with1 = _xlWorkSheet.PageSetup;
            // A4 papersize
            _with1.PaperSize = Excel.XlPaperSize.xlPaperA4;
            // Landscape orientation
            _with1.Orientation = Excel.XlPageOrientation.xlLandscape;
            // Fit Sheet on One Page 
            _with1.FitToPagesWide = 1;
            _with1.FitToPagesTall = 1;
            // Normal Margins
            _with1.LeftMargin = _xlApp.InchesToPoints(0.7);
            _with1.RightMargin = _xlApp.InchesToPoints(0.7);
            _with1.TopMargin = _xlApp.InchesToPoints(0.75);
            _with1.BottomMargin = _xlApp.InchesToPoints(0.75);
            _with1.HeaderMargin = _xlApp.InchesToPoints(0.3);
            _with1.FooterMargin = _xlApp.InchesToPoints(0.3);

            // Print the range
            _xlRange.PrintOutEx(_misValue, _misValue, _misValue, _misValue,
            _misValue, _misValue, _misValue, _misValue);

            // Set printer back to what it was
            _xlApp.ActivePrinter = Defprinter;
        }
    }
}
