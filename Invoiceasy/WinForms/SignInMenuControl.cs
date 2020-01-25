using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoiceasy.WinForms
{
    public partial class SignInMenuControl : UserControl
    {
        private Panel _vPanel;
        private Panel _hPanel;

        public SignInMenuControl()
        {
            InitializeComponent();
        }

        public SignInMenuControl(Panel vPanel, Panel hPanel)
                                    : this()
        {
            _vPanel = vPanel;
            _hPanel = hPanel;
        }

        private void BSIC_Guest_Click(object sender, EventArgs e)
        {
            UserMenuControl umc = new UserMenuControl(_vPanel, _hPanel);
            _vPanel.Controls.Clear();
            _vPanel.Controls.Add(umc);
            umc.Dock = DockStyle.Fill;
            umc.Show();
        }
    }
}
