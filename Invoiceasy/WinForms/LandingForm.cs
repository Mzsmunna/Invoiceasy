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
            BHome_Click(new object(), new EventArgs());
            
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
    }
}
