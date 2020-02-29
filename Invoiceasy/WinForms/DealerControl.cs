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
using Invoiceasy.Manager;
using Invoiceasy.Helper;

namespace Invoiceasy.WinForms
{
    public partial class DealerControl : UserControl
    {
        private Panel _vPanel;
        private Panel _hPanel;
        private List<DealerModel> _dealerList;
        private int _dealerCount;
        public DealerControl()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.DealerControl_Load);
        }

        public DealerControl(Panel vPanel, Panel hPanel)
                                    : this()
        {
            _vPanel = vPanel;
            _hPanel = hPanel;
        }

        private void DealerControl_Load(object sender, EventArgs e)
        {
            DGV_DealerList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_DealerList.MultiSelect = false;
            _dealerList = DealerManager.GetAllDealers();

            BindObjectDataToInterface();

            DGV_DealerList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_DealerList.MultiSelect = false;

            DGV_DealerList.Columns["Sl"].ReadOnly = true;
            DGV_DealerList.Columns["Date"].ReadOnly = true;

        }

        private void BindObjectDataToInterface()
        {
            _dealerCount = _dealerList.Count;
            var bindingList = new BindingList<DealerModel>(_dealerList);
            var source = new BindingSource(bindingList, null);
            DGV_DealerList.DataSource = source;
        }

        private void DGV_DealerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.DGV_DealerList.SelectedRows[0];
            DealerModel dealer = row.DataBoundItem as DealerModel;
        }

        private void BDC_Add_Click(object sender, EventArgs e)
        {
            PopupModalForm pmf = new PopupModalForm();

            PopupDealerModelControl pmc = new PopupDealerModelControl(_vPanel, _hPanel, pmf, this);
            pmc.Show();
            //pmc.Dispose();

            pmf.Controls.Add(pmc);
            pmf.ShowDialog();       
        }

        private void BDC_Edit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.DGV_DealerList.SelectedRows[0];

            if (row != null)
            {
                DealerModel dealer = row.DataBoundItem as DealerModel;

                PopupModalForm pmf = new PopupModalForm();

                PopupDealerModelControl pmc = new PopupDealerModelControl(_vPanel, _hPanel, dealer, this, pmf);
                pmc.Show();
                //pmc.Dispose();
               
                pmf.Controls.Add(pmc);
                pmf.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a Dealer to Edit.");
            }
        }

        private void BDC_Delete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.DGV_DealerList.SelectedRows[0];

            if (row != null)
            {
                DialogResult dialogResult = MessageBox.Show(" Are you sure? ", "Confirm Delete?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DealerModel dealer = row.DataBoundItem as DealerModel;

                    DealerManager.DeleteDealer(dealer);

                    MessageBox.Show("Dealer has been deleated successfully!");

                    _dealerList = DealerManager.GetAllDealers();

                    BindObjectDataToInterface();

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
                
            }
            else
            {
                MessageBox.Show("Select a Dealer to Delete.");
            }
        }

        private void RefreshProductTable(List<DealerModel> dealerList)
        {
            var dealerBindingList = new BindingList<DealerModel>(dealerList);
            var dealerSource = new BindingSource(dealerBindingList, null);
            DGV_DealerList.DataSource = dealerSource;
        }

        private void TBDC_Search_TextChanged(object sender, EventArgs e)
        {
            var searchText = TBDC_Search.Text.ToLower();

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
