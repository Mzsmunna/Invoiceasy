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
using Invoiceasy.Manager;

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
            InitializeComponent(); 
            this.Load += new System.EventHandler(this.SelectDealerControl_Load);
        }

        public SelectDealerControl(Panel hPanel, Panel vPanel)
                                    : this()
        {
            _hPanel = hPanel;
            _vPanel = vPanel;
        }

        private void SelectDealerControl_Load(object sender, EventArgs e)
        {
            DGV_SDC_Dealers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_SDC_Dealers.MultiSelect = false;

            _dealerList = DealerManager.GetAllDealers();
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

        private void RefreshProductTable(List<DealerModel> dealerList)
        {
            var dealerBindingList = new BindingList<DealerModel>(dealerList);
            var dealerSource = new BindingSource(dealerBindingList, null);
            DGV_SDC_Dealers.DataSource = dealerSource;
        }

        private void TB_SDC_Search_TextChanged(object sender, EventArgs e)
        {
            var searchText = TB_SDC_Search.Text.ToLower();

            List<DealerModel> searchedDealers = new List<DealerModel>();

            if (string.IsNullOrEmpty(searchText))
            {
                RefreshProductTable(_dealerList);
            }
            else
            {
                searchedDealers = _dealerList.Where(x => x.Code.ToLower().Contains(searchText)
                                                    || x.DealerName.ToLower().Contains(searchText)
                                                    || x.Address.ToLower().Contains(searchText)
                                                    || x.Contact.ToLower().Contains(searchText)).ToList();


                RefreshProductTable(searchedDealers);

            }
        }
    }
}
