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
            //Resize
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //this.WindowState = FormWindowState.Maximized;

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

        private void LandingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExcelApp.Quit();
        }
    }
}
