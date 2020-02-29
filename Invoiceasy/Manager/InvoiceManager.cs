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
    public class InvoiceManager : IManager
    {
        private InvoicePageModel _invoiceData { set; get; }

        public InvoiceManager(InvoicePageModel invoiceData)
        {
            _invoiceData = invoiceData;
            //ExcelApp.LoadExcelFile(appDocumentPath + @"\Libs\Files\CoreFiles\TemplateFiles\invoice-template.xlsx", 1);
            ExcelApp.LoadExcelFile(Environment.CurrentDirectory + @"\Libs\Files\CoreFiles\TemplateFiles\invoice-template.xlsx", 1);
        }

        public bool Execute()
        {
            try
            {               
                int x = 13;
                if (_invoiceData != null)
                {
                    //**Writting the Excel File: **

                    //Console.WriteLine((ExcelApp.XlWorkSheet.Cells[12, 2] as Excel.Range).Text);
                    //Console.WriteLine((ExcelApp.XlWorkSheet.Cells[12, 4] as Excel.Range).Text);
                    //Console.WriteLine((ExcelApp.XlWorkSheet.Cells[12, 5] as Excel.Range).Text);
                    //Console.WriteLine((ExcelApp.XlWorkSheet.Cells[12, 6] as Excel.Range).Text);
                    //Console.WriteLine((ExcelApp.XlWorkSheet.Cells[12, 7] as Excel.Range).Text);

                    ExcelApp.XlWorkSheet.Cells[8, 3] = _invoiceData.No;
                    ExcelApp.XlWorkSheet.Cells[8, 7] = _invoiceData.Date;
                    ExcelApp.XlWorkSheet.Cells[9, 3] = _invoiceData.Dealer.DealerName;
                    ExcelApp.XlWorkSheet.Cells[9, 7] = _invoiceData.Dealer.Code;
                    ExcelApp.XlWorkSheet.Cells[10, 3] = _invoiceData.Dealer.Address;
                    ExcelApp.XlWorkSheet.Cells[11, 3] = _invoiceData.Dealer.Contact;

                    if (_invoiceData.AllProducts != null)
                    {
                        while(x < 40)
                        {
                            foreach (var item in _invoiceData.AllProducts)
                            {
                                ExcelApp.XlWorkSheet.Cells[x, 2] = item.SerialNo;
                                ExcelApp.XlWorkSheet.Cells[x, 4] = item.ProductDescriptions;
                                ExcelApp.XlWorkSheet.Cells[x, 5] = item.UnitPrice;
                                ExcelApp.XlWorkSheet.Cells[x, 6] = item.Quantity;
                                ExcelApp.XlWorkSheet.Cells[x, 7] = item.TotalAmount;

                                x++;
                            }

                            if(x < 40)
                            {
                                break;
                            }
                        }
                        
                    }

                    ExcelApp.XlWorkSheet.Cells[40, 2] = _invoiceData.Note;
                    ExcelApp.XlWorkSheet.Cells[43, 3] = _invoiceData.AmountInWord;
                    ExcelApp.XlWorkSheet.Cells[40, 7] = _invoiceData.InTotalAmount;
                    ExcelApp.XlWorkSheet.Cells[41, 5] = _invoiceData.SpecialDiscount;
                    ExcelApp.XlWorkSheet.Cells[41, 7] = _invoiceData.DiscountAmount;
                    ExcelApp.XlWorkSheet.Cells[42, 7] = _invoiceData.PayableAmount;

                    while (x <= 39)
                    {
                        ExcelApp.XlWorkSheet.Cells[x, 7] = "";
                        x++;
                    }

                    //PrintOut();

                    //setup your page orientation + fit to pages
                    //ExcelApp.XlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                    //ExcelApp.XlWorkSheet.PageSetup.Zoom = false;
                    //ExcelApp.XlWorkSheet.PageSetup.FitToPagesWide = 1;
                        //ExcelApp.XlWorkSheet.PageSetup.FitToPagesTall = false;

                    //save as PDF
                    ExcelApp.SaveAsPDF(_invoiceData.FileLocation + _invoiceData.FileName + @".pdf");

                    //save as Xlsx
                    ExcelApp.SaveExcelFile(_invoiceData.FullPath);

                    //foreach (Excel.Worksheet ws in ExcelApp.XlWorkBook.Worksheets.OfType<Excel.Worksheet>())
                    //{
                    //    ws.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                    //    ws.PageSetup.Zoom = false;
                    //    ws.PageSetup.FitToPagesWide = 1;
                    //    ws.PageSetup.FitToPagesTall = false;
                    //}

                    ExcelApp.XlWorkBook.Close();
                    //ExcelApp.XlApp.Quit();

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
