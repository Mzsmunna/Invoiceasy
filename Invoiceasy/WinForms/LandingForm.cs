using Invoiceasy.Helper;
using Invoiceasy.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoiceasy.WinForms
{
    public partial class LandingForm : Form
    {
        public LandingForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.LandingForm_Load);
        }

        private void LandingForm_Load(object sender, EventArgs e)
        {
            //BHome_Click(new object(), new EventArgs());
            HPanel.Controls.Clear();
            HomeControl hc = new HomeControl();
            HPanel.Controls.Add(hc);
            hc.Dock = DockStyle.Fill;
            hc.Show();

            VPanel.Controls.Clear();
            SignInMenuControl sic = new SignInMenuControl(VPanel, HPanel);
            VPanel.Controls.Add(sic);
            sic.Dock = DockStyle.Fill;
            sic.Show();

        }

        private void BDealers_Click(object sender, EventArgs e)
        {
            var dealerFilePath = @"\Libs\Files\CoreFiles\DataFiles\DelerList.txt";

            var dealerList = CsvHelperUtility.ReadDataFromFile<DealerModel, DealerModelMap>(dealerFilePath);

            HPanel.Controls.Clear();
            DealerControl dc = new DealerControl();
            dc.Assign(dealerList);
            HPanel.Controls.Add(dc);
            dc.Dock = DockStyle.Fill;
            dc.Show();
        }

        private void BHome_Click(object sender, EventArgs e)
        {
            HPanel.Controls.Clear();
            HomeControl hc = new HomeControl();
            HPanel.Controls.Add(hc);
            hc.Dock = DockStyle.Fill;
            hc.Show();


        }

        private void BProducts_Click(object sender, EventArgs e)
        {
            var productFilePath = @"\Libs\Files\CoreFiles\DataFiles\ProductList.txt";

            var productList = CsvHelperUtility.ReadDataFromFile<ProductModel, ProductModelMap>(productFilePath);

            HPanel.Controls.Clear();
            ProductControl pc = new ProductControl();
            pc.Assign(productList);
            HPanel.Controls.Add(pc);
            pc.Dock = DockStyle.Fill;
            pc.Show();
        }

        private void BInvoiceNew_Click(object sender, EventArgs e)
        {
            HPanel.Controls.Clear();
            SelectDealerControl sdc = new SelectDealerControl(HPanel,VPanel);
            HPanel.Controls.Add(sdc);
            sdc.Dock = DockStyle.Fill;
            sdc.Show();

            //InvoiceControl ic = new InvoiceControl();
            //HPanel.Controls.Add(ic);
            //ic.Dock = DockStyle.Fill;
            //ic.Show();
        }
    }
}
