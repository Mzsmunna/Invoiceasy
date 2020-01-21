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

namespace Invoiceasy.WinForms
{
    public partial class InvoiceControl : UserControl
    {
        private Panel _hPanel;
        private InvoicePageModel _invoicePage;
        private List<ItemModel> _itemList;
        private PageModel _page;

        public InvoiceControl()
        {
            InitializeComponent();
        }

        public InvoiceControl(Panel hPanel, PageModel page)
                                    : this()
        {
            _hPanel = hPanel;
            _page = page;
            //_invoice = _page as InvoicePageModel;
            string json = JsonConvert.SerializeObject(_page);
            _invoicePage = JsonConvert.DeserializeObject<InvoicePageModel>(json);
            _invoicePage.InTotalAmount = _invoicePage.AllProducts.Sum(x => x.TotalAmount);
            _invoicePage.SpecialDiscount += "(" + _invoicePage.Discount + " %)";
            double parcentage = 100;
            double discountAmount = Convert.ToDouble(_invoicePage.Discount) / parcentage * Convert.ToDouble(_invoicePage.InTotalAmount);
            _invoicePage.DiscountAmount = Convert.ToInt32(discountAmount);
            _invoicePage.PayableAmount = _invoicePage.InTotalAmount - _invoicePage.DiscountAmount;
            _invoicePage.AmountInWord = NumberToWords.ConvertAmount(Convert.ToDouble(_invoicePage.PayableAmount));

            _itemList = _invoicePage.AllProducts;

            var bindingList = new BindingList<ItemModel>(_invoicePage.AllProducts);
            var source = new BindingSource(bindingList, null);
            DGV_PageItems.DataSource = source;

            TBIC_To.Text = _invoicePage.Dealer.DealerName;
            TBIC_Address.Text = _invoicePage.Dealer.Address;
            TBIC_Contact.Text = _invoicePage.Dealer.Contact;
            CBIC_Code.Items.Add(_invoicePage.Dealer.Code);
            CBIC_Code.Text = _invoicePage.Dealer.Code;
            //TBIC_Note.Text = _invoicePage.Note;
            TBIC_InWord.Text = _invoicePage.AmountInWord;
            TBIC_TotalAmount.Text = _invoicePage.InTotalAmount.ToString();
            TBIC_Discount.Text = _invoicePage.Discount.ToString();
            TBIC_SpecialDiscount.Text = _invoicePage.DiscountAmount.ToString();
            TBIC_PayableAmount.Text = _invoicePage.PayableAmount.ToString();
        }
    }
}
