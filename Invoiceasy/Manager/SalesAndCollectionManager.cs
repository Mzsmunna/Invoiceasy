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
    public static class SalesAndCollectionManager
    {
        private static List<SalesAndCollectionModel> SalesAndCollectionData { set; get; }
        private static List<SalesAndCollectionModel> FilteredSalesAndCollections;
        private static readonly string salesAndCollectionFilePath;

        static SalesAndCollectionManager()
        {
            salesAndCollectionFilePath = @"\Libs\Files\CoreFiles\DataFiles\SalesAndCollectionList.txt";

            if (SalesAndCollectionData == null)
            {
                SalesAndCollectionData = new List<SalesAndCollectionModel>();
                LoadAllSalesAndCollections();
            }
        }

        public static List<SalesAndCollectionModel> LoadAllSalesAndCollections()
        {
            FileSystemUtility.CopyFile(Environment.CurrentDirectory + salesAndCollectionFilePath, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Invoiceasy" + salesAndCollectionFilePath, false);

            SalesAndCollectionData = CsvHelperUtility.ReadDataFromFile<SalesAndCollectionModel, SalesAndCollectionModelMap>(salesAndCollectionFilePath);
            SalesAndCollectionData = SalesAndCollectionData.OrderBy(x => x.Date).ToList();
            return SalesAndCollectionData;
        }

        public static List<SalesAndCollectionModel> GetAllSalesAndCollections()
        {
            return SalesAndCollectionData;         
        }

        public static int GetAllSalesAndCollectionsCount()
        {
            return SalesAndCollectionData.Count;
        }

        public static List<SalesAndCollectionModel> GetSalesAndCollections(string dealerCode)
        {
            if(SalesAndCollectionData.Count>0)
            {
                return SalesAndCollectionData.Where(x => x.DealerCode.Equals(dealerCode)).ToList();
            }
            else
            {
                return new List<SalesAndCollectionModel>();
            }          
        }

        public static bool UpdateSale(SalesAndCollectionModel previousSale, SalesAndCollectionModel newSale)
        {
            var found = SalesAndCollectionData.Find(x => x.Id.Equals(previousSale.Id));

            if(found != null)
            {
                found.Address = newSale.Address;
                found.Contact = newSale.Contact;
                found.ClosingBalance = newSale.ClosingBalance;
                found.OpeningBalance = newSale.OpeningBalance;
                found.IC_NO = newSale.IC_NO;
                found.MR_NO = newSale.MR_NO;
                found.Remarks = newSale.Remarks;
                found.SyncType = newSale.SyncType;
                found.CollectionAmount = newSale.CollectionAmount;
                found.SalesAmount = newSale.SalesAmount;
                found.DealerCode = newSale.DealerCode;
                found.DealerName = newSale.DealerName;
                found.Date = newSale.Date;
                found.Sl = previousSale.Sl;
                

                SaveChange();
                CalculateOpeningAndClosingBalance(found.DealerCode);
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void CalculateOpeningAndClosingBalance(string dealerCode)
        {
            int openingBalance = 0;
            int closingBalance = 0;
            var dealersHistory = new List<SalesAndCollectionModel>();

            dealersHistory = SalesAndCollectionData.Where(x => x.DealerCode.Equals(dealerCode)).ToList();

            if (dealersHistory.Count > 0)
            {
                var allDates = dealersHistory.Select(x => x.Date).Distinct().ToList();
                allDates = allDates.OrderBy(x => x.Value).ToList();
                int totalSalesAmount = 0;
                int totalCollectionAmount = 0;

                foreach (var date in allDates)
                {
                    var thatDaysHistory = dealersHistory.Where(x => x.Date == date).ToList();
                    var totalSaleOfThatDay = thatDaysHistory.Sum(x => x.SalesAmount);
                    totalSalesAmount += totalSaleOfThatDay;
                    var totalCollectionOfThatDay = thatDaysHistory.Sum(x => x.CollectionAmount);
                    totalCollectionAmount += totalCollectionOfThatDay;
                   
                    var thatDaysFirstHistory = thatDaysHistory.FirstOrDefault();

                    if (thatDaysFirstHistory != null)
                    {
                        thatDaysFirstHistory.OpeningBalance = openingBalance;
                        closingBalance = (openingBalance + totalSaleOfThatDay) - totalCollectionOfThatDay;
                    }

                    var thatDaysLastHistory = thatDaysHistory.LastOrDefault();

                    if (thatDaysLastHistory != null)
                    {
                        thatDaysLastHistory.ClosingBalance = closingBalance;
                        openingBalance = closingBalance;
                    }

                    if(thatDaysHistory.Count == 2)
                    {
                        thatDaysFirstHistory.ClosingBalance = null;
                        thatDaysLastHistory.OpeningBalance = null;
                    }
                    else if(thatDaysHistory.Count > 2)
                    {
                        var middleHistory = thatDaysHistory.Skip(1).ToList();
                        middleHistory = middleHistory.Take(middleHistory.Count - 1).ToList();

                        foreach(var history in middleHistory)
                        {
                            history.ClosingBalance = null;
                            history.OpeningBalance = null;
                        }
                    }
                }
            }

            SaveChange();
        }

        public static List<SalesAndCollectionModel> EverydaySalesAndCollections(string dealerCode)
        {
            var dealersHistory = new List<SalesAndCollectionModel>();

            if (SalesAndCollectionData.Count>0)
            {                
                var dealer = DealerManager.FindDealer(dealerCode);

                dealersHistory = SalesAndCollectionData.Where(x => x.DealerCode.Equals(dealerCode)).ToList();

                var everydayDealersHistory = new List<SalesAndCollectionModel>();

                if (dealersHistory.Count > 0)
                {
                    var allDates = dealersHistory.Select(x => x.Date).Distinct().ToList();
                    allDates = allDates.OrderBy(x => x.Value).ToList();

                    int count = 1;
                    foreach (var date in allDates)
                    {
                        var thatDaysHistory = dealersHistory.Where(x => x.Date == date).ToList();
                        var mergeThatDaysHistory = new SalesAndCollectionModel();

                        mergeThatDaysHistory.Address = dealer.Address;
                        mergeThatDaysHistory.Contact = dealer.Contact;
                        mergeThatDaysHistory.DealerName = dealer.DealerName;
                        mergeThatDaysHistory.DealerCode = dealer.Code;
                        mergeThatDaysHistory.Date = date;
                        mergeThatDaysHistory.IC_NO = "";
                        mergeThatDaysHistory.MR_NO = "";
                        mergeThatDaysHistory.Remarks = "";
                        mergeThatDaysHistory.SyncType = "Daily";
                        mergeThatDaysHistory.Sl = (count++).ToString();

                        mergeThatDaysHistory.OpeningBalance = thatDaysHistory.FirstOrDefault().OpeningBalance;
                        mergeThatDaysHistory.SalesAmount = thatDaysHistory.Sum(x => x.SalesAmount);
                        mergeThatDaysHistory.CollectionAmount = thatDaysHistory.Sum(x => x.CollectionAmount);
                        mergeThatDaysHistory.ClosingBalance = thatDaysHistory.LastOrDefault().ClosingBalance;

                        everydayDealersHistory.Add(mergeThatDaysHistory);
                    }
                }

                return everydayDealersHistory;
            }

            return dealersHistory;
        }

        public static List<SalesAndCollectionModel> EverydaySalesAndCollections()
        {
            var allDealers = DealerManager.GetAllDealers();

            var allDealersHistory = new List<SalesAndCollectionModel>();

            int count = 1;
            foreach (var dealer in allDealers)
            {
                var dealersHistory = EverydaySalesAndCollections(dealer.Code);

                foreach(var history in dealersHistory)
                {
                    history.Sl = (count++).ToString();
                }

                allDealersHistory.AddRange(dealersHistory);
            }

            return allDealersHistory;
        }

        public static bool AddNewSale(SalesAndCollectionModel sale)
        {
            if (CsvHelperUtility.InsertOneNewDataToFile(false, salesAndCollectionFilePath, ",", sale))
            {
                LoadAllSalesAndCollections();
                CalculateOpeningAndClosingBalance(sale.DealerCode);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AddNewCollection(SalesAndCollectionModel collection)
        {
            if (CsvHelperUtility.InsertOneNewDataToFile(false, salesAndCollectionFilePath, ",", collection))
            {
                LoadAllSalesAndCollections();
                CalculateOpeningAndClosingBalance(collection.DealerCode);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AddManySales(List<SalesAndCollectionModel> sales)
        {
            if (CsvHelperUtility.InsertManyNewDataToFile(true, salesAndCollectionFilePath, ",", sales))
            {
                LoadAllSalesAndCollections();

                foreach(var sale in sales)
                {
                    CalculateOpeningAndClosingBalance(sale.DealerCode);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AddManyCollections(List<SalesAndCollectionModel> collections)
        {
            if (CsvHelperUtility.InsertManyNewDataToFile(true, salesAndCollectionFilePath, ",", collections))
            {
                LoadAllSalesAndCollections();

                foreach (var collection in collections)
                {
                    CalculateOpeningAndClosingBalance(collection.DealerCode);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private static void SaveChange()
        {
            SalesAndCollectionData.RemoveAll(item => item == null);
            SalesAndCollectionData = SalesAndCollectionData.OrderBy(x => x.Date).ToList();

            int count = 1;
            foreach(var each in SalesAndCollectionData)
            {
                each.Sl = (count++).ToString();
            }

            CsvHelperUtility.WriteDataToFile<SalesAndCollectionModel>(false, salesAndCollectionFilePath, ",", SalesAndCollectionData);
            LoadAllSalesAndCollections();
        }

        public static bool DeleteSaleOrCollection(SalesAndCollectionModel saleORCollection, bool isGroupedByDate)
        {
            if(isGroupedByDate)
            {
                var thatDaysSOC = SalesAndCollectionData.Where(x => x.DealerCode.ToLower().Equals(saleORCollection.DealerCode.ToLower()) && x.Date == saleORCollection.Date).ToList();

                if(thatDaysSOC.Count > 0)
                {
                    foreach(var soc in thatDaysSOC)
                    {
                        SalesAndCollectionData.Remove(soc);
                    }

                    SaveChange();
                    CalculateOpeningAndClosingBalance(saleORCollection.DealerCode);
                    return true;
                }

                return false;
            }
            else
            {
                var findSOC = SalesAndCollectionData.Where(x => x.Id.Equals(saleORCollection.Id)).FirstOrDefault();

                if (findSOC != null)
                {
                    SalesAndCollectionData.Remove(findSOC);
                    SaveChange();
                    CalculateOpeningAndClosingBalance(saleORCollection.DealerCode);
                    return true;
                }
                
                return false;
            }        
        }

        public static bool ExportAsDailyExcell(string fullPath, List<SalesAndCollectionModel> filteredSalesAndCollections)
        {
            FilteredSalesAndCollections = filteredSalesAndCollections;

            try
            {
                ExcelApp.LoadExcelFile(Environment.CurrentDirectory + @"\Libs\Files\CoreFiles\TemplateFiles\daily-Sales-and-collection-report.xlsx", 1);

                int x = 11;
                if (FilteredSalesAndCollections != null)
                {
                    //**Writting the Excel File: **
                    
                    while (x <= FilteredSalesAndCollections.Count+11)
                    {
                        int grandSalesAmount = 0;
                        int grandCollectionAmount = 0;

                        ExcelApp.XlWorkSheet.Cells[5, 1] = "Branch : ";
                        ExcelApp.XlWorkSheet.Cells[5, 7] = DateTime.Now.ToString("MMMM yyyy");

                        foreach (var item in FilteredSalesAndCollections)
                        {
                            ExcelApp.XlWorkSheet.Cells[x, 1] = item.Sl;

                            if(item.Date.HasValue)
                            {
                                ExcelApp.XlWorkSheet.Cells[x, 2] = item.Date.Value.ToString("dd-MM-yy");
                            }
                            
                            ExcelApp.XlWorkSheet.Cells[x, 3] = item.DealerName;
                            ExcelApp.XlWorkSheet.Cells[x, 4] = item.IC_NO;

                            if (item.SyncType.ToLower().Equals("collection"))
                            {
                                ExcelApp.XlWorkSheet.Cells[x, 4] = item.MR_NO;
                            }

                            ExcelApp.XlWorkSheet.Cells[x, 5] = item.SalesAmount;
                            ExcelApp.XlWorkSheet.Cells[x, 6] = item.CollectionAmount;

                            grandSalesAmount += item.SalesAmount;
                            grandCollectionAmount += item.CollectionAmount;

                            x++;
                            Excel.Range line = (Excel.Range)ExcelApp.XlWorkSheet.Rows[x];
                            line.Insert();
                        }

                        x++;

                        ExcelApp.XlWorkSheet.Cells[x, 5] = grandSalesAmount;
                        ExcelApp.XlWorkSheet.Cells[x, 6] = grandCollectionAmount;
                    }

                    //PrintOut();

                    //save as PDF
                    ExcelApp.SaveAsPDF(FileSystemUtility.GetFileDirectory(fullPath) + FileSystemUtility.GetFileName(fullPath) + @".pdf");

                    //save as Xlsx
                    ExcelApp.SaveExcelFile(fullPath);

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

        public static bool ExportAsPartyLedgerExcell(string fullPath, List<SalesAndCollectionModel> filteredSalesAndCollections)
        {
            FilteredSalesAndCollections = filteredSalesAndCollections;

            try
            {
                ExcelApp.LoadExcelFile(Environment.CurrentDirectory + @"\Libs\Files\CoreFiles\TemplateFiles\dealer-party-ledger.xlsx", 1);

                int x = 13;
                if (FilteredSalesAndCollections != null)
                {
                    //**Writting the Excel File: **

                    while (x <= FilteredSalesAndCollections.Count + 13)
                    {
                        int grandSalesAmount = 0;
                        int grandCollectionAmount = 0;

                        ExcelApp.XlWorkSheet.Cells[9, 1] = "Party Name : " + filteredSalesAndCollections.FirstOrDefault().DealerName;
                        ExcelApp.XlWorkSheet.Cells[9, 4] = "Code : " + filteredSalesAndCollections.FirstOrDefault().DealerCode;
                        ExcelApp.XlWorkSheet.Cells[10, 1] = "Address : " + filteredSalesAndCollections.FirstOrDefault().Address;

                        foreach (var item in FilteredSalesAndCollections)
                        {
                            ExcelApp.XlWorkSheet.Cells[x, 1] = item.Sl;

                            if (item.Date.HasValue)
                            {
                                ExcelApp.XlWorkSheet.Cells[x, 2] = item.Date.Value.ToString("dd-MMM-yy");
                            }

                            ExcelApp.XlWorkSheet.Cells[x, 3] = item.IC_NO;
                            ExcelApp.XlWorkSheet.Cells[x, 4] = item.MR_NO;
                            ExcelApp.XlWorkSheet.Cells[x, 5] = item.OpeningBalance;
                            ExcelApp.XlWorkSheet.Cells[x, 6] = item.SalesAmount;
                            ExcelApp.XlWorkSheet.Cells[x, 7] = item.CollectionAmount;
                            ExcelApp.XlWorkSheet.Cells[x, 8] = item.ClosingBalance;

                            grandSalesAmount += item.SalesAmount;
                            grandCollectionAmount += item.CollectionAmount;

                            x++;
                            Excel.Range line = (Excel.Range)ExcelApp.XlWorkSheet.Rows[x];
                            line.Insert();
                        }

                        x++;

                        ExcelApp.XlWorkSheet.Cells[x, 6] = grandSalesAmount;
                        ExcelApp.XlWorkSheet.Cells[x, 7] = grandCollectionAmount;
                        ExcelApp.XlWorkSheet.Cells[x, 8] = FilteredSalesAndCollections.LastOrDefault().ClosingBalance;
                    }

                    //PrintOut();

                    //save as PDF
                    ExcelApp.SaveAsPDF(FileSystemUtility.GetFileDirectory(fullPath) + FileSystemUtility.GetFileName(fullPath) + @".pdf");

                    //save as Xlsx
                    ExcelApp.SaveExcelFile(fullPath);

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

        private static void PrintOut()
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
