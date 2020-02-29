using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invoiceasy.Helper;
using Invoiceasy.ViewModel;
using Invoiceasy.Enum;
using Invoiceasy.Manager;

namespace Invoiceasy.WinForms
{
    public partial class UserMenuControl : UserControl
    {
        private Panel _vPanel;
        private Panel _hPanel;

        public UserMenuControl()
        {
            InitializeComponent();
        }

        public UserMenuControl(Panel vPanel, Panel hPanel)
                                    : this()
        {
            _vPanel = vPanel;
            _hPanel = hPanel;
        }

        private void BUC_NewInvoice_Click(object sender, EventArgs e)
        {
            if(BUC_NewInvoice.Text.Equals("New Invoice"))
            {
                _hPanel.Controls.Clear();
                SelectDealerControl sdc = new SelectDealerControl(_hPanel, _vPanel);
                _hPanel.Controls.Add(sdc);
                sdc.Dock = DockStyle.Fill;
                sdc.Show();
                BUC_NewInvoice.Text = "Cancel Invoice";
            }
            else if (BUC_NewInvoice.Text.Equals("Cancel Invoice"))
            {
                _hPanel.Controls.Clear();
                HomeControl hc = new HomeControl();
                _hPanel.Controls.Add(hc);
                hc.Dock = DockStyle.Fill;
                hc.Show();
                BUC_NewInvoice.Text = "New Invoice";
            }

        }

        private void BUC_Home_Click(object sender, EventArgs e)
        {
            _hPanel.Controls.Clear();
            HomeControl hc = new HomeControl();
            _hPanel.Controls.Add(hc);
            hc.Dock = DockStyle.Fill;
            hc.Show();
        }

        private void BUC_Products_Click(object sender, EventArgs e)
        {
            _hPanel.Controls.Clear();
            ProductControl pc = new ProductControl(_vPanel, _hPanel);
            _hPanel.Controls.Add(pc);
            pc.Dock = DockStyle.Fill;
            pc.Show();
        }

        private void BUC_Dealers_Click(object sender, EventArgs e)
        {
            _hPanel.Controls.Clear();
            DealerControl dc = new DealerControl(_vPanel, _hPanel);
            _hPanel.Controls.Add(dc);
            dc.Dock = DockStyle.Fill;
            dc.Show();
        }

        private void BUC_InvoiceHistory_Click(object sender, EventArgs e)
        {
            _hPanel.Controls.Clear();
            ICHistoryControl ihc = new ICHistoryControl(_hPanel, _vPanel, PageType.Invoice);
            _hPanel.Controls.Add(ihc);
            ihc.Dock = DockStyle.Fill;
            ihc.Show();
        }

        private void BUC_ChallanHistory_Click(object sender, EventArgs e)
        {
            _hPanel.Controls.Clear();
            ICHistoryControl ihc = new ICHistoryControl(_hPanel, _vPanel, PageType.Challan);
            _hPanel.Controls.Add(ihc);
            ihc.Dock = DockStyle.Fill;
            ihc.Show();
        }

        private void BUC_SalesAndCollection_Click(object sender, EventArgs e)
        {
            _hPanel.Controls.Clear();
            SalesAndCollectionControl sacc = new SalesAndCollectionControl(_hPanel, _vPanel);
            _hPanel.Controls.Add(sacc);
            sacc.Dock = DockStyle.Fill;
            sacc.Show();
        }

        private void BUC_TheWeb_Click(object sender, EventArgs e)
        {
            Experiment.ExecuteMongoDBOperations();
        }
    }
}
