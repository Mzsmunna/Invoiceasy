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

namespace Invoiceasy.WinForms
{
    public partial class InvoiceControl : UserControl
    {
        private Panel _hPanel;
        private InvoicePageModel _invoicePage;
        private List<ItemModel> _itemList;
        private PageModel _page;
        //BackgroundWorker worker = new BackgroundWorker();
        //ProgressBar progressBar1 = new ProgressBar();

        public InvoiceControl()
        {
            InitializeComponent();

            //worker.DoWork += (sender, args) => PerformReading();
            //worker.RunWorkerCompleted += (sender, args) => ReadingCompleted();
            InvoiceBackgroundWorker.DoWork += BackgroundWorker_DoWork;
            InvoiceBackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        public InvoiceControl(Panel hPanel, PageModel page)
                                    : this()
        {
            _hPanel = hPanel;
            _page = page;
            //_invoice = _page as InvoicePageModel;
            string json = JsonConvert.SerializeObject(_page);
            _invoicePage = JsonConvert.DeserializeObject<InvoicePageModel>(json);           

            _itemList = _invoicePage.AllProducts;
            TBIC_Discount.MaxLength = 2;
            
            BindObjectDataToInterface();
        }

        private void BIC_Save_Click(object sender, EventArgs e)
        {
            BindInterfaceDataToObject();
            _invoicePage.Note = "Note : " + TBIC_Note.Text;
            //IManager manager = new InvoiceManager(_invoicePage);
            //manager.Execute();

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

            DGV_PageItems.Columns[0].ReadOnly = true;
            DGV_PageItems.Columns[4].ReadOnly = true;
            DGV_PageItems.Columns[5].Visible = false;

            TBIC_To.Text = _invoicePage.Dealer.DealerName;
            TBIC_Address.Text = _invoicePage.Dealer.Address;
            TBIC_Contact.Text = _invoicePage.Dealer.Contact;
            CBIC_Code.Items.Add(_invoicePage.Dealer.Code);
            CBIC_Code.Text = _invoicePage.Dealer.Code;
            //TBIC_Note.Text = _invoicePage.Note;
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

            
            //product.StockAvailable -= item.Quantity;
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
            MessageBox.Show("Invoice file has been saved successfully");
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

    }
}
