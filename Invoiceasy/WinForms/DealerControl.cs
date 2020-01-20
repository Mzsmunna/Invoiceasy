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
        }

        public void Assign(List<DealerModel> dealerList)
        {
            _dealerList = dealerList;
            var bindingList = new BindingList<DealerModel>(dealerList);
            var source = new BindingSource(bindingList, null);
            DGV_DealerList.DataSource = source;
        }
    }
}
