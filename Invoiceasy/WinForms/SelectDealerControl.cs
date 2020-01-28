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
using Invoiceasy.Helper;

namespace Invoiceasy.WinForms
{
    public partial class SelectDealerControl : UserControl
    {
        private Panel _hPanel;
        private Panel _vPanel;
        private List<DealerModel> _dealerList;
        private PageModel _page;
        public SelectDealerControl()
        {
            InitializeComponent(); this.Load += new System.EventHandler(this.SelectDealerControl_Load);
        }

        public SelectDealerControl(Panel hPanel, Panel vPanel)
                                    : this()
        {
            _hPanel = hPanel;
            _vPanel = vPanel;
        }

        private void SelectDealerControl_Load(object sender, EventArgs e)
        {
            this.DGV_SDC_Dealers.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
            this.DGV_SDC_Dealers.MultiSelect = false;

            var dealerFilePath = @"\Libs\Files\CoreFiles\DataFiles\DelerList.txt";

            _dealerList = CsvHelperUtility.ReadDataFromFile<DealerModel, DealerModelMap>(dealerFilePath);
            var bindingList = new BindingList<DealerModel>(_dealerList);
            var source = new BindingSource(bindingList, null);
            DGV_SDC_Dealers.DataSource = source;
        }

        private void BSDC_Next_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.DGV_SDC_Dealers.SelectedRows[0];

            if(row != null)
            {
                DealerModel dealer = row.DataBoundItem as DealerModel;
                _page = new PageModel();
                _page.Dealer = dealer;
                _page.DealerList = _dealerList;

                SelectProductsControl spc = new SelectProductsControl(_hPanel, _vPanel, _page);
                _hPanel.Controls.Clear();
                _hPanel.Controls.Add(spc);
                spc.Dock = DockStyle.Fill;
                spc.Show();
            }
            else
            {
                MessageBox.Show("Select a Dealer to proceed Next.");
            }
            
        }
    }
}
