using Invoiceasy.Helper;
using Invoiceasy.Manager;
using Invoiceasy.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Invoiceasy
{
    public static class TestEnvironment
    {
        public static void Program()
        {
            try
            {
                Console.WriteLine("Checking Internet Access....");
                if (CheckForInternetConnection())
                {
                    Console.Out.WriteLine("Established Connection! :)");
                }
                else
                {
                    Console.Out.WriteLine("No Internet Access!! :(");
                }

                //IManager tmanager = new InvoiceManager(new InvoicePageModel());
                //tmanager.Execute();

                var userFilePath = @"\Libs\Files\CoreFiles\DataFiles\UserList.txt";
                var dealerFilePath = @"\Libs\Files\CoreFiles\DataFiles\DelerList.txt";
                var productFilePath = @"\Libs\Files\CoreFiles\DataFiles\ProductList.txt";

                var userList = CsvHelperUtility.ReadDataFromFile<UserModel, UserModelMap>(userFilePath);
                var dealerList = CsvHelperUtility.ReadDataFromFile<DealerModel, DealerModelMap>(dealerFilePath);
                var productList = CsvHelperUtility.ReadDataFromFile<ProductModel, ProductModelMap>(productFilePath);

                int input = 0;

                Console.Out.WriteLine("total Dealers : " + productList.Count + "\n");

                Console.Out.WriteLine("SL |      Code     |         Dealer_Name         |                 Contact                 |                             Address                             ");
                Console.Out.WriteLine("----------------------------------------------------------------------------------------\n");
                foreach (var dealer in dealerList)
                {
                    Console.Out.WriteLine(dealer.Sl + " | " + dealer.DealerName + " | " + dealer.Code + " | " + dealer.Contact + " | " + dealer.Address);
                }

                Console.Out.WriteLine("Total Dealers : " + dealerList.Count + "\n");

                var assignDealer = new DealerModel();

                do
                {
                    Console.Out.WriteLine("Choose A dealer SL :");
                    input = Convert.ToInt32(Console.ReadLine());

                    assignDealer = dealerList.Where(x => x.Sl.Equals(input.ToString())).FirstOrDefault();

                    if (assignDealer != null)
                    {
                        Console.Out.WriteLine("You Have chosen... Dealer Code : " + assignDealer.Code + "| Dealer Name : " + assignDealer.DealerName + "| Contact : " + assignDealer.Contact);
                        Console.Out.WriteLine("Wanna Proceed? \n\t\t 1. Yes \n\t\t 2. No ");
                        var confirmation = Console.ReadLine();

                        if ((confirmation.Equals("1")) || (confirmation.ToLower().Equals("yes")))
                        {
                            break;
                        }
                        else
                        {
                            assignDealer = null;
                        }
                    }

                } while (assignDealer == null);

                Console.Out.WriteLine("SL |    Category    |         Item Description       |   Product Code   |  Stock  |  Unit Price  |  Image");
                Console.Out.WriteLine("----------------------------------------------------------------------------------------\n");
                foreach (var product in productList)
                {
                    Console.Out.WriteLine(product.Sl + " | " + product.Category + " | " + product.ItemDescription + " | " + product.ProductCode + " | " + product.StockAvailable + " | " + product.UnitPrice + " | " + product.Image);
                }

                var page = new PageModel();
                Random random = new Random();

                do
                {
                    Console.Out.WriteLine("Enter the product SL No to add them on list");
                    input = Convert.ToInt32(Console.ReadLine());

                    var product = productList.Where(x => x.Sl.Equals(input.ToString())).FirstOrDefault();

                    if (product != null)
                    {
                        int quantity = 0;

                        do
                        {
                            Console.Out.WriteLine("Enter Quantity for the Product : " + product.ProductCode);
                            quantity = Convert.ToInt32(Console.ReadLine());

                            if (quantity > product.StockAvailable)
                            {
                                Console.Out.WriteLine("Your Quantity is more than Stock Available : " + product.StockAvailable);
                                Console.Out.WriteLine("Still wanna Proceed? \n\t\t 1. Yes \n\t\t 2. No ");
                                var confirmation = Console.ReadLine();

                                if ((confirmation.Equals("1")) || (confirmation.ToLower().Equals("yes")))
                                {
                                    break;
                                }
                                else
                                {
                                    continue;
                                }

                            }

                        } while (quantity > product.StockAvailable);

                        var item = new ItemModel
                        {
                            SerialNo = page.ItemCount.ToString(),
                            ProductDescriptions = product.ItemDescription,
                            Quantity = quantity, //random.Next(1, 100),
                            UnitPrice = Convert.ToInt32(product.UnitPrice),
                            Unit = "Pcs"
                        };

                        item.TotalAmount = Convert.ToInt32(item.UnitPrice * item.Quantity);
                        product.StockAvailable -= item.Quantity;

                        page.AllProducts.Add(item);
                        page.ItemCount++;
                    }

                } while (input != 0 && page.ItemCount <= 27);

                if (page.ItemCount >= 27)
                {
                    Console.Out.WriteLine("Page is full! Can't add anymore Product");
                }

                page.AllProducts.RemoveAll(item => item == null);

                var invoicePage = new InvoicePageModel();
                string json = JsonConvert.SerializeObject(page);
                invoicePage = JsonConvert.DeserializeObject<InvoicePageModel>(json);
                Console.Out.WriteLine("INVOICE PAGE! NO:");
                invoicePage.No = Console.ReadLine();
                invoicePage.Dealer = assignDealer;
                //invoicePage.To = assignDealer.DealerName;
                //invoicePage.Code = assignDealer.Code;
                //invoicePage.Address = assignDealer.Address;
                //invoicePage.Contact = assignDealer.Contact;
                invoicePage.Date = DateTime.Now.ToString("MMMM dd, yyyy");
                Console.Out.WriteLine("INVOICE PAGE! NOTE:");
                invoicePage.Note = Console.ReadLine();
                invoicePage.InTotalAmount = invoicePage.AllProducts.Sum(x => x.TotalAmount);
                //invoicePage.AmountInWord = NumberToWords.ConvertAmount(Convert.ToDouble(invoicePage.InTotalAmount));
                Console.Out.WriteLine("Discount In Percentage :");
                invoicePage.Discount = Convert.ToInt32(Console.ReadLine());
                invoicePage.SpecialDiscount += "(" + invoicePage.Discount + " %)";
                double parcentage = 100;
                double discountAmount = Convert.ToDouble(invoicePage.Discount) / parcentage * Convert.ToDouble(invoicePage.InTotalAmount);
                invoicePage.DiscountAmount = Convert.ToInt32(discountAmount);
                invoicePage.PayableAmount = invoicePage.InTotalAmount - invoicePage.DiscountAmount;
                invoicePage.AmountInWord = NumberToWords.ConvertAmount(Convert.ToDouble(invoicePage.PayableAmount));

                //Excel.Application xlApp = new Excel.Application();
                ExcelApp _excelApp = new ExcelApp();
                _excelApp.LoadExcelFile(Environment.CurrentDirectory + @"\Libs\Files\CoreFiles\TemplateFiles\invoice-template.xlsx", 1);
                IManager manager = new InvoiceManager(invoicePage, _excelApp);
                manager.Execute();

                var challanPage = JsonConvert.DeserializeObject<ChalanPageModel>(json);
                challanPage.TotalQuality = challanPage.AllProducts.Sum(x => x.Quantity);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
