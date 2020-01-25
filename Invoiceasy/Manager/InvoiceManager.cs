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

                    Excel.Application xlApp = new Excel.Application();
                    object misValue = System.Reflection.Missing.Value; // when creating a new excel file

                    //Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue); // when creating a new excel file
                    Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    //Console.WriteLine((xlWorkSheet.Cells[12, 2] as Excel.Range).Text);
                    //Console.WriteLine((xlWorkSheet.Cells[12, 4] as Excel.Range).Text);
                    //Console.WriteLine((xlWorkSheet.Cells[12, 5] as Excel.Range).Text);
                    //Console.WriteLine((xlWorkSheet.Cells[12, 6] as Excel.Range).Text);
                    //Console.WriteLine((xlWorkSheet.Cells[12, 7] as Excel.Range).Text);

                    xlWorkSheet.Cells[8, 3] = _invoiceData.No;
                    xlWorkSheet.Cells[8, 7] = _invoiceData.Date;
                    xlWorkSheet.Cells[9, 3] = _invoiceData.Dealer.DealerName;
                    xlWorkSheet.Cells[9, 7] = _invoiceData.Dealer.Code;
                    xlWorkSheet.Cells[10, 3] = _invoiceData.Dealer.Address;
                    xlWorkSheet.Cells[11, 3] = _invoiceData.Dealer.Contact;
                    

                    if (_invoiceData.AllProducts != null)
                    {
                        while(x < 40)
                        {
                            foreach (var item in _invoiceData.AllProducts)
                            {
                                xlWorkSheet.Cells[x, 2] = item.SerialNo;
                                xlWorkSheet.Cells[x, 4] = item.ProductDescriptions;
                                xlWorkSheet.Cells[x, 5] = item.UnitPrice;
                                xlWorkSheet.Cells[x, 6] = item.Quantity;
                                xlWorkSheet.Cells[x, 7] = item.TotalAmount;

                                x++;
                            }

                            if(x < 40)
                            {
                                break;
                            }
                        }
                        
                    }

                    xlWorkSheet.Cells[40, 2] = _invoiceData.Note;
                    xlWorkSheet.Cells[43, 3] = _invoiceData.AmountInWord;
                    xlWorkSheet.Cells[40, 7] = _invoiceData.InTotalAmount;
                    xlWorkSheet.Cells[41, 5] = _invoiceData.SpecialDiscount;
                    xlWorkSheet.Cells[41, 7] = _invoiceData.DiscountAmount;
                    xlWorkSheet.Cells[42, 7] = _invoiceData.PayableAmount;

                    //while (x <= 39)
                    //{
                    //    xlWorkSheet.Cells[x, 7] = "";
                    //    x++;
                    //}

                    //var filePath2 = @"\Public\Output\in-output.xlsx";

                    xlWorkBook.Close();

                    //xlWorkBook.SaveAs(filePath2, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue,
                    //Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                    xlApp.Quit();

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
    }
}
