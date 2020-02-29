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
    public partial class PopupCollectionModelControl : UserControl
    {
        List<DealerModel> _dealerList;
        DealerModel _dealer;
        SalesAndCollectionModel _collection;
        SalesAndCollectionControl _salesAndCollectionControl;
        Form _popUpForm;

        private Panel _vPanel;
        private Panel _hPanel;

        public PopupCollectionModelControl(Panel vPanel, Panel hPanel, Form popUpForm, SalesAndCollectionControl salesAndCollectionControl, string dealerCode)
        {
            _popUpForm = popUpForm;
            _vPanel = vPanel;
            _hPanel = hPanel;
            _salesAndCollectionControl = salesAndCollectionControl;
            _dealerList = DealerManager.GetAllDealers();

            if(string.IsNullOrEmpty(dealerCode) || dealerCode.ToLower().Equals("any"))
            {
                _dealer = null;
            }
            else
            {
                _dealer = DealerManager.FindDealer(dealerCode);
            }

            InitializeComponent(); 
            this.Load += new System.EventHandler(this.PopupModelControl_Load);
        }

        private void PopupModelControl_Load(object sender, EventArgs e)
        {
            if(_dealer != null)
            {
                CB_PMC_SelectDealer.Text = _dealer.Code;
            }

            if(_dealerList != null)
            {
                LPMC_Title.Text = "ADD New Collection";
                BPMC_Add.Text = "Add";

                _collection = new SalesAndCollectionModel
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Sl = (SalesAndCollectionManager.GetAllSalesAndCollectionsCount() + 1).ToString(),
                    DealerName = "",
                    Address = "",
                    Contact = "",
                    DealerCode = "",
                    Date = DTP_PMC_Date.Value.Date,
                    IC_NO = "",
                    MR_NO = "",
                    OpeningBalance = null,
                    SalesAmount = 0,
                    CollectionAmount = 0,
                    ClosingBalance = null,
                    Remarks = "",
                    SyncType = "Collection"
                };
            }

            BindObjectDataToInterface();

        }

        private void BindObjectDataToInterface()
        {
            if (string.IsNullOrEmpty(CB_PMC_SelectDealer.Text))
            {
                CB_PMC_SelectDealer.Text = _dealerList.FirstOrDefault().Code;
                CB_PMC_SelectDealer.Items.AddRange(_dealerList.Select(x => x.Code).ToArray());
            }
            else if(CB_PMC_SelectDealer.Items.Count <= 1)
            {
                CB_PMC_SelectDealer.Items.AddRange(_dealerList.Select(x => x.Code).ToArray());
            }

            TB_PMC_MR_No.Text = _collection.MR_NO;
            TB_PMC_IC_No.Text = _collection.IC_NO;
            TB_PMC_CollectionAmount.Text = _collection.CollectionAmount.ToString();
            TB_PMC_Remark.Text = _collection.Remarks;
        }

        private void BindInterfaceDataToObject()
        {
            var selectedDealer = _dealerList.Where(x => x.Code.Equals(CB_PMC_SelectDealer.Text)).FirstOrDefault();

            _collection.DealerName = selectedDealer.DealerName;
            _collection.DealerCode = selectedDealer.Code;
            _collection.Address = selectedDealer.Address;
            _collection.Contact = selectedDealer.Contact;

            _collection.MR_NO = TB_PMC_MR_No.Text;
            _collection.IC_NO = TB_PMC_IC_No.Text;
            _collection.CollectionAmount = Convert.ToInt32(TB_PMC_CollectionAmount.Text);
            _collection.Remarks = TB_PMC_Remark.Text;
            _collection.Date = DTP_PMC_Date.Value.Date;

            if (_collection.CollectionAmount <= 0
                //|| _collection.MR_NO.Equals("")
                //|| _collection.IC_NO.Equals("")
            )
            {
                MessageBox.Show("Make sure Collection amount is not 0 ");
            }
            else
            {
                ConfirmChange();
            }

            void ConfirmChange()
            {
                DialogResult dialogResult = MessageBox.Show(BPMC_Add.Text + " Collection? ", "Confirm Change?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (_collection != null)
                    {
                        if (BPMC_Add.Text.Equals("Add"))
                        {
                            if (SalesAndCollectionManager.AddNewSale(_collection))
                            {
                                MessageBox.Show("Collection Added successfully!");

                                ReloadDealerControl();
                            }
                            else
                            {
                                MessageBox.Show("Error! Something went wrong!!");
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
                    _salesAndCollectionControl = new SalesAndCollectionControl(_hPanel, _vPanel);
                    _hPanel.Controls.Add(_salesAndCollectionControl);
                    _salesAndCollectionControl.Dock = DockStyle.Fill;
                    _salesAndCollectionControl.Show();
                    _popUpForm.Close();
                }
            }
        }

        private void BPMC_AddOrUpdate_Click(object sender, EventArgs e)
        {
            BindInterfaceDataToObject();
        }

        private void TB_PMC_CollectionAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void CB_PMC_SelectDealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
