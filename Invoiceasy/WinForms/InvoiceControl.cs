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

namespace Invoiceasy.WinForms
{
    public partial class InvoiceControl : UserControl
    {
        private Panel _hPanel;
        private InvoicePageModel _invoicePage;
        private List<ProductModel> _productList;
        private PageModel _page;

        public InvoiceControl()
        {
            InitializeComponent();

            InvoiceBackgroundWorker.DoWork += BackgroundWorker_DoWork;
            InvoiceBackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        public InvoiceControl(Panel hPanel, PageModel page, List<ProductModel> productList)
                                    : this()
        {
            _hPanel = hPanel;
            _page = page;
            _productList = productList;

            _invoicePage = JsonConvert.DeserializeObject<InvoicePageModel>(JsonConvert.SerializeObject(_page));

            TBIC_Discount.MaxLength = 2;
            
            BindObjectDataToInterface();
        }

        private void BIC_Save_Click(object sender, EventArgs e)
        {
            BindInterfaceDataToObject();
            _invoicePage.Note = "Note : " + TBIC_Note.Text;

            // start the animation
            IC_ProgressPanel.Visible = true;
            InvoiceProgressBar.Visible = true;
            InvoiceProgressBar.Style = ProgressBarStyle.Marquee;

            // start the job
            InvoiceBackgroundWorker.RunWorkerAsync();
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

            TBIC_To.Text = _invoicePage.Dealer.DealerName;
            TBIC_Address.Text = _invoicePage.Dealer.Address;
            TBIC_Contact.Text = _invoicePage.Dealer.Contact;
            CBIC_Code.Items.Add(_invoicePage.Dealer.Code);
            CBIC_Code.Text = _invoicePage.Dealer.Code;
            TBIC_Note.Text = _invoicePage.Note;
            TBIC_Discount.Text = _invoicePage.Discount.ToString();

            CalculateAmountAndDiscount();

            TBIC_InWord.Text = _invoicePage.AmountInWord;
            TBIC_TotalAmount.Text = _invoicePage.InTotalAmount.ToString();            
            TBIC_SpecialDiscount.Text = _invoicePage.DiscountAmount.ToString();
            TBIC_PayableAmount.Text = _invoicePage.PayableAmount.ToString();
        }

        private void BindInterfaceDataToObject()
        {
            _invoicePage.No = TBIC_No.Text;
            _invoicePage.Dealer.DealerName = TBIC_To.Text;
            _invoicePage.Dealer.Address = TBIC_Address.Text;
            _invoicePage.Dealer.Contact = TBIC_Contact.Text;
            _invoicePage.Date = DTP_IC_Date.Value.ToString();
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
            _productList = null;

            GetBackToHome();
        }

        private void TBIC_Discount_KeyDown(object sender, KeyEventArgs e)
        {

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
            //LoadExcel
            IManager manager = new InvoiceManager(_invoicePage);
            manager.Execute();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IC_ProgressPanel.Visible = false;
            InvoiceProgressBar.Visible = false;

            foreach(var item in _invoicePage.AllProducts)
            {
                var product = _productList.Where(x => x.ProductCode.Equals(item.ProductCode)).FirstOrDefault();
                product.StockAvailable -= item.Quantity;
            }

            var productFilePath = @"\Libs\Files\CoreFiles\DataFiles\ProductList.txt";

            CsvHelperUtility.WriteDataToFile<ProductModel>(false, productFilePath, ",", _productList);

            string invoiceJSON = JsonConvert.SerializeObject(_invoicePage);

            var fileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Invoiceasy";

            var fileName = "InvoiceLog_" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH-mm-ss") + ".txt";

            FileSystemUtility.Initialize(true, fileName, fileLocation, invoiceJSON);
            FileSystemUtility.CreateFolder();
            FileSystemUtility.WriteFile();

            var logFilePath = fileLocation + @"\" + "InvoiceItemList_" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH-mm-ss") + ".txt";

            CsvHelperUtility.WriteDataToFile<ItemModel>(true, logFilePath, ",", _invoicePage.AllProducts);

            MessageBox.Show("Invoice file has been saved successfully");

            GetBackToHome();
        }

        private void DGV_PageItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRowCollection rows = this.DGV_PageItems.Rows;

            if (rows.Count > 0)
            {
                List<ItemModel> allInvoiceItems = new List<ItemModel>();
                foreach (DataGridViewRow row in rows)
                {
                    ItemModel item = JsonConvert.DeserializeObject<ItemModel>(JsonConvert.SerializeObject(row.DataBoundItem));
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
    }
}
