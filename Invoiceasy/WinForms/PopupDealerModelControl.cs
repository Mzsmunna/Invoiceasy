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

namespace Invoiceasy.WinForms
{
    public partial class PopupDealerModelControl : UserControl
    {
        DealerModel _dealer;
        DealerControl _dealerControl;
        Form _popUpForm;

        private Panel _vPanel;
        private Panel _hPanel;

        public PopupDealerModelControl(Panel vPanel, Panel hPanel, Form popUpForm, DealerControl dealerControl)
        {
            _popUpForm = popUpForm;
            _vPanel = vPanel;
            _hPanel = hPanel;
            _dealerControl = dealerControl;
            InitializeComponent(); 
            this.Load += new System.EventHandler(this.PopupModelControl_Load);
        }

        public PopupDealerModelControl(Panel vPanel, Panel hPanel, DealerModel dealer, DealerControl dealerControl, Form popUpForm)
                                    : this(vPanel, hPanel, popUpForm, dealerControl)
        {           
            _dealer = dealer;
        }

        private void PopupModelControl_Load(object sender, EventArgs e)
        {
            if(_dealer == null)
            {
                LPMC_Title.Text = "ADD New Dealer";
                BPMC_AddOrUpdate.Text = "Add";

                _dealer = new DealerModel
                {
                    Address = "",
                    Code = "",
                    Contact = "",
                    Date = DateTime.Now.ToString("dd-MMM-yy"),
                    DealerName = "",
                    Sl = (DealerManager.GetAllDealersCount() + 1).ToString(),
                };
            }
            else
            {
                LPMC_Title.Text = "Edit Dealer";
                BPMC_AddOrUpdate.Text = "Update";
            }

            BindObjectDataToInterface();

        }

        private void BindObjectDataToInterface()
        {
            TB_PMC_DealerName.Text = _dealer.DealerName;
            TB_PMC_DealerCode.Text = _dealer.Code;
            TB_PMC_DealerAddress.Text = _dealer.Address;
            TB_PMC_DealerContact.Text = _dealer.Contact;
        }

        private void BindInterfaceDataToObject()
        {
            _dealer.DealerName = TB_PMC_DealerName.Text;
            _dealer.Code = TB_PMC_DealerCode.Text;
            _dealer.Address = TB_PMC_DealerAddress.Text;
            _dealer.Contact = TB_PMC_DealerContact.Text;

            if(_dealer.DealerName.Equals("")
                || _dealer.Code.Equals("")
                || _dealer.Address.Equals("")
                || _dealer.Contact.Equals(""))
            {
                MessageBox.Show("Fill up all boxes!!");
            }
            else
            {
                ConfirmChange();
            }

            void ConfirmChange()
            {
                DialogResult dialogResult = MessageBox.Show(BPMC_AddOrUpdate.Text + " Dealer? ", "Confirm Change?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (_dealer != null)
                    {
                        if (BPMC_AddOrUpdate.Text.Equals("Update"))
                        {
                            if (DealerManager.UpdateDealer(_dealer))
                            {
                                MessageBox.Show("Dealer Updated successfully!");

                                ReloadDealerControl();
                            }
                            else
                            {
                                MessageBox.Show("Error! Dealer Code already Exist! Dealer Code must be unique!");
                            }
                        }
                        else if (BPMC_AddOrUpdate.Text.Equals("Add"))
                        {
                            if (DealerManager.AddDealer(_dealer))
                            {
                                MessageBox.Show("Dealer Added successfully!");

                                ReloadDealerControl();
                            }
                            else
                            {
                                MessageBox.Show("Error! Dealer Code already Exist! Dealer Code must be unique!");
                            }
                        }
                    }
                    else
                    {

                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

                void ReloadDealerControl()
                {
                    _hPanel.Controls.Clear();
                    _dealerControl = new DealerControl(_vPanel, _hPanel);
                    _hPanel.Controls.Add(_dealerControl);
                    _dealerControl.Dock = DockStyle.Fill;
                    _dealerControl.Show();
                    _popUpForm.Close();
                }
            }
        }

        private void BPMC_AddOrUpdate_Click(object sender, EventArgs e)
        {
            BindInterfaceDataToObject();
        }
    }
}
