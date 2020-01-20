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

namespace Invoiceasy.WinForms
{
    public partial class DealerControl : UserControl
    {
        private List<DealerModel> _dealerList;
        public DealerControl()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.DealerControl_Load);
        }

        private void DealerControl_Load(object sender, EventArgs e)
        {
            this.DGV_DealerList.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
            this.DGV_DealerList.MultiSelect = false;

        }

        public void Assign(List<DealerModel> dealerList)
        {
            _dealerList = dealerList;
            var bindingList = new BindingList<DealerModel>(_dealerList);
            var source = new BindingSource(bindingList, null);
            DGV_DealerList.DataSource = source;
        }

        private void DGV_DealerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.DGV_DealerList.SelectedRows[0];
            DealerModel dealer = row.DataBoundItem as DealerModel;
        }
    }
}
