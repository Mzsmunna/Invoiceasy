using Invoiceasy.Helper;
using Invoiceasy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Invoiceasy.Manager
{
    public class ChallanManager : IManager
    {
        private ChallanPageModel _challanData { set; get; }

        public ChallanManager(ChallanPageModel challanData)
        {
            _challanData = challanData;
            //ExcelApp.LoadExcelFile(appDocumentPath + @"\Libs\Files\CoreFiles\TemplateFiles\challan-template.xlsx", 1);
            ExcelApp.LoadExcelFile(Environment.CurrentDirectory + @"\Libs\Files\CoreFiles\TemplateFiles\challan-template.xlsx", 1);
        }

        public bool Execute()
        {
            try
            {
                int x = 13;
                if (_challanData != null)
                {
                    //**Writting the Excel File: **

                    ExcelApp.XlWorkSheet.Cells[8, 3] = _challanData.No;
                    ExcelApp.XlWorkSheet.Cells[8, 7] = _challanData.Date;
                    ExcelApp.XlWorkSheet.Cells[9, 3] = _challanData.Dealer.DealerName;
                    ExcelApp.XlWorkSheet.Cells[9, 7] = _challanData.Dealer.Code;
                    ExcelApp.XlWorkSheet.Cells[10, 3] = _challanData.Dealer.Address;
                    ExcelApp.XlWorkSheet.Cells[11, 3] = _challanData.Dealer.Contact;

                    if (_challanData.AllProducts != null)
                    {
                        while (x < 41)
                        {
                            foreach (var item in _challanData.AllProducts)
                            {
                                ExcelApp.XlWorkSheet.Cells[x, 2] = item.SerialNo;
                                ExcelApp.XlWorkSheet.Cells[x, 4] = item.ProductDescriptions;
                                ExcelApp.XlWorkSheet.Cells[x, 6] = item.Unit;
                                ExcelApp.XlWorkSheet.Cells[x, 7] = item.Quantity;

                                x++;
                            }

                            if (x < 41)
                            {
                                break;
                            }
                        }
                    }

                    ExcelApp.XlWorkSheet.Cells[41, 2] = _challanData.Note;
                    ExcelApp.XlWorkSheet.Cells[41, 7] = _challanData.TotalQuality;

                    while (x <= 40)
                    {
                        ExcelApp.XlWorkSheet.Cells[x, 7] = "";
                        x++;
                    }

                    //PrintOut();

                    //save as PDF
                    ExcelApp.SaveAsPDF(_challanData.FileLocation + _challanData.FileName + @".pdf");

                    //save as Xlsx
                    ExcelApp.SaveExcelFile(_challanData.FullPath);

                    ExcelApp.XlWorkBook.Close();

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

                if (ex.Message.Equals("Exception from HRESULT: 0x800A03EC"))
                    return true;

                return false;
            }
        }

        private void PrintOut()
        {
            // Get the current printer
            string Defprinter = null;
            Defprinter = ExcelApp.XlApp.ActivePrinter;

            // Set the printer to Microsoft XPS Document Writer
            ExcelApp.XlApp.ActivePrinter = "Microsoft XPS Document Writer on Ne01:";

            // Setup our sheet
            var _with1 = ExcelApp.XlWorkSheet.PageSetup;
            // A4 papersize
            _with1.PaperSize = Excel.XlPaperSize.xlPaperA4;
            // Landscape orientation
            _with1.Orientation = Excel.XlPageOrientation.xlLandscape;
            // Fit Sheet on One Page 
            _with1.FitToPagesWide = 1;
            _with1.FitToPagesTall = 1;
            // Normal Margins
            _with1.LeftMargin = ExcelApp.XlApp.InchesToPoints(0.7);
            _with1.RightMargin = ExcelApp.XlApp.InchesToPoints(0.7);
            _with1.TopMargin = ExcelApp.XlApp.InchesToPoints(0.75);
            _with1.BottomMargin = ExcelApp.XlApp.InchesToPoints(0.75);
            _with1.HeaderMargin = ExcelApp.XlApp.InchesToPoints(0.3);
            _with1.FooterMargin = ExcelApp.XlApp.InchesToPoints(0.3);

            // Print the range
            ExcelApp.XlRange.PrintOutEx(ExcelApp.MisValue, ExcelApp.MisValue, ExcelApp.MisValue, ExcelApp.MisValue,
            ExcelApp.MisValue, ExcelApp.MisValue, ExcelApp.MisValue, ExcelApp.MisValue);

            // Set printer back to what it was
            ExcelApp.XlApp.ActivePrinter = Defprinter;
        }
    }
}
