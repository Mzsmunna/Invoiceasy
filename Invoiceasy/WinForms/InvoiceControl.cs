using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invoiceasy.ViewModel;
using Newtonsoft.Json;
using Invoiceasy.Helper;
using Invoiceasy.Manager;
using System.IO;
using CsvHelper;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

namespace Invoiceasy.WinForms
{
    public partial class InvoiceControl : UserControl
    {
        private Panel _hPanel;
        private Panel _vPanel;
        private InvoicePageModel _invoicePage;
        private PageModel _page;
        private bool _isSuccess = false;

        private List<DealerModel> _dealerList;
        private List<ProductModel> _productList;
        private List<ItemModel> _itemList;

        public InvoiceControl()
        {
            InitializeComponent();

            InvoiceBackgroundWorker.DoWork += BackgroundWorker_DoWork;
            InvoiceBackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        public InvoiceControl(Panel hPanel, Panel vPanel, PageModel page)
                                    : this()
        {
            _hPanel = hPanel;
            _vPanel = vPanel;
            _page = page;
            _dealerList = DealerManager.GetAllDealers();
            _productList = ProductManager.GetAllProducts();
            _invoicePage = JsonConvert.DeserializeObject<InvoicePageModel>(JsonConvert.SerializeObject(_page));

            TBIC_Discount.MaxLength = 2;
            
            BindObjectDataToInterface();
        }

        public InvoiceControl(Panel hPanel, Panel vPanel, InvoicePageModel invoicePage)
                                    : this()
        {
            _hPanel = hPanel;
            _vPanel = vPanel;
            _invoicePage = invoicePage;
            _page = JsonConvert.DeserializeObject<PageModel>(JsonConvert.SerializeObject(_invoicePage));
            _dealerList = DealerManager.GetAllDealers();
            _productList = ProductManager.GetAllProducts();

            if (_invoicePage.sale != null)
            {
                _itemList = CommonHelper.CloneList<ItemModel>(_invoicePage.AllProducts);
            }                

            TBIC_Discount.MaxLength = 2;

            BindObjectDataToInterface();
        }

        private void BIC_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save";
            saveDialog.Filter = ".xlsx Files (*.xlsx)|*.xlsx" + "|" +
                                "Text Files (*.txt)|*.txt" + "|" +
                                "Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" +
                                "All Files (*.*)|*.*";

            if (string.IsNullOrEmpty(_invoicePage.FullPath))
                saveDialog.FileName = "Invoice-" + _invoicePage.No + "_" + DTP_IC_Date.Value.ToString("dd MMMM yyyy") + " " + DateTime.Now.ToString("HH-mm-ss");
            else
                saveDialog.FileName = _invoicePage.FullPath;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                _invoicePage.FullPath = saveDialog.FileName;
                _invoicePage.FileLocation = Path.GetDirectoryName(saveDialog.FileName) + @"\";
                _invoicePage.FileName = Path.GetFileNameWithoutExtension(saveDialog.FileName);

                BindInterfaceDataToObject();
                _invoicePage.Note = "Note : " + TBIC_Note.Text;

                // start the animation
                IC_ProgressPanel.Visible = true;
                InvoiceProgressBar.Visible = true;
                InvoiceProgressBar.Style = ProgressBarStyle.Marquee;
                _vPanel.Enabled = false;
                _hPanel.Enabled = false;

                // start the job
                InvoiceBackgroundWorker.RunWorkerAsync();
            }
            else
            {

            }           
        }

        private void BindObjectDataToInterface()
        {
            var bindingList = new BindingList<ItemModel>(_invoicePage.AllProducts);
            var source = new BindingSource(bindingList, null);
            DGV_PageItems.DataSource = source;

            DGV_PageItems.Columns["SerialNo"].ReadOnly = true;
            DGV_PageItems.Columns["TotalAmount"].ReadOnly = true;
            DGV_PageItems.Columns["Unit"].Visible = false;
            DGV_PageItems.Columns["ProductCode"].Visible = false;

            if(!string.IsNullOrEmpty(_invoicePage.Date))
                DTP_IC_Date.Value = Convert.ToDateTime(_invoicePage.Date);

            TBIC_No.Text = _invoicePage.No;
            TBIC_To.Text = _invoicePage.Dealer.DealerName;
            TBIC_Address.Text = _invoicePage.Dealer.Address;
            TBIC_Contact.Text = _invoicePage.Dealer.Contact;
            TBIC_Note.Text = _invoicePage.Note;
            TBIC_Discount.Text = _invoicePage.Discount.ToString();

            CalculateAmountAndDiscount();

            TBIC_InWord.Text = _invoicePage.AmountInWord;
            TBIC_TotalAmount.Text = _invoicePage.InTotalAmount.ToString();            
            TBIC_SpecialDiscount.Text = _invoicePage.DiscountAmount.ToString();
            TBIC_PayableAmount.Text = _invoicePage.PayableAmount.ToString();

            if(string.IsNullOrEmpty(CBIC_Code.Text))
            {
                CBIC_Code.Text = _invoicePage.Dealer.Code;
                CBIC_Code.Items.AddRange(_dealerList.Select(x => x.Code).ToArray());
            }
            else
            {
                CBIC_Code.Text = _invoicePage.Dealer.Code;
            }
        }

        private void BindInterfaceDataToObject()
        {
            _invoicePage.No = TBIC_No.Text;
            _invoicePage.Dealer.DealerName = TBIC_To.Text;
            _invoicePage.Dealer.Address = TBIC_Address.Text;
            _invoicePage.Dealer.Contact = TBIC_Contact.Text;
            _invoicePage.Date = DTP_IC_Date.Value.ToString("MMMM dd, yyyy");
            _invoicePage.Note = TBIC_Note.Text;

            if(!string.IsNullOrEmpty(TBIC_Discount.Text))
            {
                _invoicePage.Discount = Convert.ToInt32(TBIC_Discount.Text);
                CalculateAmountAndDiscount();
            }            
        }

        private void CalculateAmountAndDiscount()
        {
            foreach(var item in _invoicePage.AllProducts)
            {
                item.TotalAmount = Convert.ToInt32(item.UnitPrice * item.Quantity);
            }

            _invoicePage.InTotalAmount = _invoicePage.AllProducts.Sum(x => x.TotalAmount);
            _invoicePage.SpecialDiscount = "Special Discount (" + _invoicePage.Discount + " %)";
            double parcentage = 100;
            double discountAmount = 0;

            if (!(_invoicePage.Discount == 0))
            {
                discountAmount = Convert.ToDouble(_invoicePage.Discount) / parcentage * Convert.ToDouble(_invoicePage.InTotalAmount);
            }
            
            _invoicePage.DiscountAmount = Convert.ToInt32(discountAmount);
            _invoicePage.PayableAmount = _invoicePage.InTotalAmount - _invoicePage.DiscountAmount;
            _invoicePage.AmountInWord = NumberToWords.ConvertAmount(Convert.ToDouble(_invoicePage.PayableAmount));
        }

        private void BIC_Cancel_Click(object sender, EventArgs e)
        {
            _page = null;
            _invoicePage = null;
            _invoicePage = null;

            GetBackToHome();
        }

        private void TBIC_Discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back) || (e.KeyChar == '.');
        }

        private void TBIC_Discount_TextChanged(object sender, EventArgs e)
        {
            BindInterfaceDataToObject();
            BindObjectDataToInterface();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            IManager manager = new InvoiceManager(_invoicePage);
            _isSuccess = manager.Execute();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IC_ProgressPanel.Visible = false;
            InvoiceProgressBar.Visible = false;
            _vPanel.Enabled = true;
            _hPanel.Enabled = true;

            void UpdateProductStock()
            {
                foreach (var item in _invoicePage.AllProducts)
                {
                    var product = _productList.Where(x => x.ProductCode.Equals(item.ProductCode)).FirstOrDefault();

                    if(product != null)
                    {
                        if(_itemList != null)
                        {
                            var previousItem = _itemList.Where(x => x.ProductCode.Equals(item.ProductCode)).FirstOrDefault();
                            product.StockAvailable += previousItem.Quantity;
                        }        

                        product.StockAvailable -= item.Quantity;
                    }                
                }

                ProductManager.UpdateAllProducts(_productList);
            }

            void SaveInvoiceLogFile()
            {
                if (!string.IsNullOrEmpty(_invoicePage.CurrentLogFile))
                {
                    _invoicePage.PreviousLogFile = _invoicePage.CurrentLogFile;
                    FileSystemUtility.DeleteFile(_invoicePage.CurrentLogFile);
                }

                Files invoiceLog = new Files();
                invoiceLog.FileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Invoiceasy\InvoiceLog";

                invoiceLog.FileName = "InvoiceLog-" + _invoicePage.No + "_" + DTP_IC_Date.Value.ToString("dd MMMM yyyy") + " " + DateTime.Now.ToString("HH-mm-ss") + ".txt";
                _invoicePage.CurrentLogFile = invoiceLog.FileLocation + @"\" + invoiceLog.FileName;

                invoiceLog.FileText = JsonConvert.SerializeObject(_invoicePage);
                FileSystemUtility.DeleteFile(_invoicePage.CurrentLogFile);
                FileSystemUtility.Initialize(true, invoiceLog);
                FileSystemUtility.WriteFile();

                var logFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Invoiceasy" + @"\InvoiceItems\" + "Invoice-" + _invoicePage.No + "_" + "ItemList_" + DTP_IC_Date.Value.ToString("dd MMMM yyyy HH-mm-ss") + ".txt";
                FileSystemUtility.CreateFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Invoiceasy" + @"\InvoiceItems");
                CsvHelperUtility.WriteDataToFile<ItemModel>(true, logFilePath, ",", _invoicePage.AllProducts);
            }

            void AddSale()
            {
                var sale = new SalesAndCollectionModel
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Sl = (SalesAndCollectionManager.GetAllSalesAndCollectionsCount() + 1).ToString(),
                    DealerName = _invoicePage.Dealer.DealerName,
                    Address = _invoicePage.Dealer.Address,
                    Contact= _invoicePage.Dealer.Contact,
                    DealerCode = _invoicePage.Dealer.Code,
                    Date = DTP_IC_Date.Value,
                    IC_NO = _invoicePage.No,
                    MR_NO = "",
                    OpeningBalance = null,
                    SalesAmount = _invoicePage.PayableAmount,
                    CollectionAmount = 0,
                    ClosingBalance = null,
                    Remarks = "",
                    SyncType = "Sales"
                };

                if(_invoicePage.sale == null)
                {
                    _invoicePage.sale = sale;
                    SalesAndCollectionManager.AddNewSale(sale);
                }
                else
                {
                    SalesAndCollectionManager.UpdateSale(_invoicePage.sale, sale);
                }             
            }

            BindInterfaceDataToObject();

            UpdateProductStock();           

            AddSale();

            SaveInvoiceLogFile();

            if (_isSuccess)
                MessageBox.Show("Invoice file has been saved successfully");
            else
                MessageBox.Show("Error! Something Went Wrong while saving the file");

            LoadChallanForm();

        }

        private void LoadChallanForm()
        {
            var challanPage = JsonConvert.DeserializeObject<ChallanPageModel>(JsonConvert.SerializeObject(_invoicePage));

            challanPage.FullPath = _invoicePage.FullPath.Replace("Invoice", "Challan");
            challanPage.FileName = _invoicePage.FileName.Replace("Invoice", "Challan");
            challanPage.FileLocation = _invoicePage.FileLocation.Replace("Invoice", "Challan");
            challanPage.CurrentLogFile = _invoicePage.CurrentLogFile.Replace("InvoiceLog", "ChallanLog");

            if (!string.IsNullOrEmpty(_invoicePage.PreviousLogFile))
            {
                challanPage.PreviousLogFile = _invoicePage.PreviousLogFile.Replace("InvoiceLog", "ChallanLog");
            }

            ChallanControl cc = new ChallanControl(_hPanel, _vPanel, challanPage);
            _hPanel.Controls.Clear();
            _hPanel.Controls.Add(cc);
            cc.Dock = DockStyle.Fill;
            cc.Show();
        }

        private void DGV_PageItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRowCollection rows = this.DGV_PageItems.Rows;

            if (rows.Count > 0)
            {
                List<ItemModel> allInvoiceItems = new List<ItemModel>();
                foreach (DataGridViewRow row in rows)
                {
                    ItemModel item = row.DataBoundItem as ItemModel;

                    if (item != null)
                    {
                        item.TotalAmount = Convert.ToInt32(item.UnitPrice * item.Quantity);
                        allInvoiceItems.Add(item);
                    }
                }

                _invoicePage.AllProducts = allInvoiceItems;

                BindInterfaceDataToObject();
                BindObjectDataToInterface();
            }
        }

        private void GetBackToHome()
        {
            _hPanel.Controls.Clear();
            HomeControl hc = new HomeControl();
            _hPanel.Controls.Add(hc);
            hc.Dock = DockStyle.Fill;
            hc.Show();
        }

        private void DGV_PageItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewColumn col = DGV_PageItems.Columns[e.ColumnIndex] as DataGridViewColumn;

            if (col.Name.ToLower() == "unitprice" || col.Name.ToLower() == "quantity")
            {
                DataGridViewTextBoxCell cell = DGV_PageItems[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
                if (cell != null)
                {
                    char[] chars = e.FormattedValue.ToString().ToCharArray();
                    foreach (char c in chars)
                    {
                        if (char.IsDigit(c) == false)
                        {
                            MessageBox.Show("You have to enter digits only");
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }
        }

        private void CBIC_Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDealer = _dealerList.Where(x => x.Code.Equals(CBIC_Code.Text)).FirstOrDefault();
            BindInterfaceDataToObject();
            _page.Dealer = selectedDealer;
            _invoicePage.Dealer = selectedDealer; 
            BindObjectDataToInterface();
        }

        private void DGV_PageItems_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (_page.AllProducts.Count == e.RowIndex)
            {
                DataGridViewRow row = DGV_PageItems.Rows[e.RowIndex];

                ItemModel item = row.DataBoundItem as ItemModel;

                if (item != null)
                {
                    if (string.IsNullOrEmpty(item.SerialNo))
                    {
                        item.SerialNo = (_page.ItemCount++).ToString();

                        if(string.IsNullOrEmpty(item.Unit))
                        {
                            item.Unit = "Pcs";

                        }
                        _page.AllProducts.Add(item);
                    }
                }
            }
        }
    }
}
