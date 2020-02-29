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
    public partial class SalesAndCollectionControl : UserControl
    {
        private Panel _hPanel;
        private Panel _vPanel;
        private List<DealerModel> _dealerList;
        private DealerModel _dealer;

        private List<SalesAndCollectionModel> _tempedSalesAndCollections;

        private bool isPartyLedger;
        private bool isTimePeriodChanged;
        private string _fullPath;

        private SalesAndCollectionControl()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.SalesAndCollectionControl_Load);
            SACBackgroundWorker.DoWork += BackgroundWorker_DoWork;
            SACBackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        public SalesAndCollectionControl(Panel hPanel, Panel vPanel)
                                    : this()
        {
            _hPanel = hPanel;
            _vPanel = vPanel;
            isPartyLedger = false;
            isTimePeriodChanged = false;
            _fullPath = string.Empty;
            _dealerList = DealerManager.GetAllDealers();
        }

        public SalesAndCollectionControl(Panel hPanel, Panel vPanel, DealerModel dealer)
                                    : this(hPanel, vPanel)
        {
            _dealer = dealer;
            CB_SAC_DealerCode.Text = _dealer.Code;
        }

        private void SalesAndCollectionControl_Load(object sender, EventArgs e)
        {
            DGV_SAC_SalesAndCollectionList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_SAC_SalesAndCollectionList.MultiSelect = false;

            DTP_SAC_FromDate.Value = new DateTime(2020, 1, 1);
            DTP_SAC_ToDate.Value = DateTime.Today;

            BindingSource bs = new BindingSource();
            bs.DataSource = new List<string> { "Default", "Today", "Yesterday", "Weekly",  "Monthly", "This Month", "Last Month", "Custom" };
            CB_SAC_TimePeriod.DataSource = bs;

            BindAllFilters();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool isSuccess = false;

            if (isPartyLedger)
            {
                isSuccess = SalesAndCollectionManager.ExportAsPartyLedgerExcell(_fullPath, _tempedSalesAndCollections);
            }
            else
            {
                isSuccess = SalesAndCollectionManager.ExportAsDailyExcell(_fullPath, _tempedSalesAndCollections);
            }

            if(isSuccess)
            {
                MessageBox.Show("File has been saved successfully");
            }
            else
            {
                MessageBox.Show("Error! Something went wrong while saving file!!");
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SAC_ProgressPanel.Visible = false;
            SACProgressBar.Visible = false;
            _vPanel.Enabled = true;
            _hPanel.Enabled = true;
        }

        private void BindDataTable(List<SalesAndCollectionModel> salesAndCollections)
        {
            var bindingList = new BindingList<SalesAndCollectionModel>(salesAndCollections);
            var source = new BindingSource(bindingList, null);
            DGV_SAC_SalesAndCollectionList.DataSource = source;

            DGV_SAC_SalesAndCollectionList.Columns["SyncType"].Visible = false;
            DGV_SAC_SalesAndCollectionList.Columns["Id"].Visible = false;
        }

        private void CB_SAC_TimePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            isTimePeriodChanged = true;
            BindAllFilters();
        }

        private void BindAllFilters()
        {
            var filteredSalesAndCollections = new List<SalesAndCollectionModel>();

            if (string.IsNullOrEmpty(CB_SAC_DealerCode.Text))
            {
                CB_SAC_DealerCode.Text = "Any";
                CB_SAC_DealerCode.Items.Add("Any");
                CB_SAC_DealerCode.Items.AddRange(_dealerList.Select(x => x.Code).ToArray());
            }
            else if (CB_SAC_DealerCode.Items.Count <= 1)
            {
                CB_SAC_DealerCode.Items.Add("Any");
                CB_SAC_DealerCode.Items.AddRange(_dealerList.Select(x => x.Code).ToArray());
            }

            if (CB_SAC_DealerCode.Text.ToLower().Equals("any"))
            {
                _dealer = null;
            }
            else
            {
                if(!string.IsNullOrEmpty(CB_SAC_DealerCode.Text))
                {
                    _dealer = DealerManager.FindDealer(CB_SAC_DealerCode.Text);
                }
            }

            if (_dealer != null)
            {
                CB_SAC_DealerCode.Text = _dealer.Code;

                LSAC_PartyName.Visible = true;
                LSAC_PartyAddress.Visible = true;
                LSAC_PartyContact.Visible = true;
                TB_SAC_PartyName.Visible = true;
                TB_SAC_PartyAddress.Visible = true;
                TB_SAC_PartyContact.Visible = true;

                TB_SAC_PartyName.Text = _dealer.DealerName;
                TB_SAC_PartyAddress.Text = _dealer.Address;
                TB_SAC_PartyContact.Text = _dealer.Contact;
                //TB_SAC_PartyName.Enabled = false;
                //TB_SAC_PartyAddress.Enabled = false;
                //TB_SAC_PartyContact.Enabled = false;
            }
            else
            {
                LSAC_PartyName.Visible = false;
                LSAC_PartyAddress.Visible = false;
                LSAC_PartyContact.Visible = false;
                TB_SAC_PartyName.Visible = false;
                TB_SAC_PartyAddress.Visible = false;
                TB_SAC_PartyContact.Visible = false;

                TB_SAC_PartyName.Text = "";
                TB_SAC_PartyAddress.Text = "";
                TB_SAC_PartyContact.Text = "";
            }

            if (CKB_GroupBy.Checked)
            {
                if (CB_SAC_DealerCode.Text.ToLower().Equals("any"))
                    filteredSalesAndCollections = SalesAndCollectionManager.EverydaySalesAndCollections();
                else
                    filteredSalesAndCollections = SalesAndCollectionManager.EverydaySalesAndCollections(CB_SAC_DealerCode.Text);
            }
            else
            {
                if (CB_SAC_DealerCode.Text.ToLower().Equals("any"))
                    filteredSalesAndCollections = SalesAndCollectionManager.GetAllSalesAndCollections();
                else
                    filteredSalesAndCollections = SalesAndCollectionManager.GetSalesAndCollections(CB_SAC_DealerCode.Text);
            }

            if(filteredSalesAndCollections.Count > 0)
            {
                if (!string.IsNullOrEmpty(TB_SAC_Search.Text))
                {
                    filteredSalesAndCollections = SearchResult(TB_SAC_Search.Text, filteredSalesAndCollections);
                }

                if (CB_SAC_TimePeriod.Text.Equals("Custom"))
                {
                    filteredSalesAndCollections = filteredSalesAndCollections.Where(x => x.Date >= DTP_SAC_FromDate.Value && x.Date <= DTP_SAC_ToDate.Value).ToList();
                }
                else if (CB_SAC_TimePeriod.Text.Equals("Today"))
                {
                    DTP_SAC_FromDate.Value = DateTime.Today;
                    DTP_SAC_ToDate.Value = DTP_SAC_FromDate.Value;

                    filteredSalesAndCollections = filteredSalesAndCollections.Where(x => x.Date > DTP_SAC_FromDate.Value.AddDays(-1) && x.Date <= DTP_SAC_ToDate.Value).ToList();
                }
                else if (CB_SAC_TimePeriod.Text.Equals("Yesterday"))
                {
                    DTP_SAC_FromDate.Value = DateTime.Today.AddDays(-1);
                    DTP_SAC_ToDate.Value = DTP_SAC_FromDate.Value;

                    filteredSalesAndCollections = filteredSalesAndCollections.Where(x => x.Date > DTP_SAC_FromDate.Value.AddDays(-1) && x.Date <= DTP_SAC_ToDate.Value).ToList();
                }
                else if (CB_SAC_TimePeriod.Text.Equals("Weekly"))
                {
                    DTP_SAC_FromDate.Value = DateTime.Today.AddDays(-7);
                    DTP_SAC_ToDate.Value = DateTime.Today;

                    filteredSalesAndCollections = filteredSalesAndCollections.Where(x => x.Date > DTP_SAC_FromDate.Value && x.Date <= DTP_SAC_ToDate.Value).ToList();
                }
                else if (CB_SAC_TimePeriod.Text.Equals("Monthly"))
                {
                    DTP_SAC_FromDate.Value = DateTime.Today.AddDays(-30);
                    DTP_SAC_ToDate.Value = DateTime.Today;

                    filteredSalesAndCollections = filteredSalesAndCollections.Where(x => x.Date > DTP_SAC_FromDate.Value && x.Date <= DTP_SAC_ToDate.Value).ToList();
                }
                else if (CB_SAC_TimePeriod.Text.Equals("This Month"))
                {
                    DateTime date = DateTime.Today;
                    DTP_SAC_FromDate.Value = new DateTime(date.Year, date.Month, 1);
                    DTP_SAC_ToDate.Value = DTP_SAC_FromDate.Value.AddMonths(1).AddDays(-1);

                    filteredSalesAndCollections = filteredSalesAndCollections.Where(x => x.Date >= DTP_SAC_FromDate.Value && x.Date <= DTP_SAC_ToDate.Value).ToList();
                }
                else if (CB_SAC_TimePeriod.Text.Equals("Last Month"))
                {
                    DateTime date = DateTime.Today;
                    DTP_SAC_FromDate.Value = new DateTime(date.Year, date.AddMonths(-1).Month, 1);
                    DTP_SAC_ToDate.Value = DTP_SAC_FromDate.Value.AddMonths(1).AddDays(-1);

                    filteredSalesAndCollections = filteredSalesAndCollections.Where(x => x.Date >= DTP_SAC_FromDate.Value && x.Date <= DTP_SAC_ToDate.Value).ToList();
                }
                else if (CB_SAC_TimePeriod.Text.Equals("Default"))
                {
                    DTP_SAC_FromDate.Value = new DateTime(2020, 1, 1);
                    DTP_SAC_ToDate.Value = DateTime.Today;
                    filteredSalesAndCollections = filteredSalesAndCollections.Where(x => x.Date >= DTP_SAC_FromDate.Value && x.Date <= DTP_SAC_ToDate.Value).ToList();
                }


                var allDates = filteredSalesAndCollections.Select(x => x.Date).Distinct().ToList();
                allDates.RemoveAll(item => item == null);

                if (CKB_Ascending.Checked)
                {
                    allDates = allDates.OrderBy(x => x.Value).ToList();
                }
                else
                {
                    allDates = allDates.OrderByDescending(x => x.Value).ToList();
                }

                var mapSalesAndCollections = new List<SalesAndCollectionModel>();

                foreach (var date in allDates)
                {
                    var thatDaysHistory = filteredSalesAndCollections.Where(x => x.Date == date).ToList();

                    var allDealerForThatDay = thatDaysHistory.Select(x => x.DealerCode).Distinct().ToList();

                    foreach(var dealerCode in allDealerForThatDay)
                    {
                        var dealerHistoryForThatDay = thatDaysHistory.Where(x => x.DealerCode.Equals(dealerCode)).ToList();
                        mapSalesAndCollections.AddRange(dealerHistoryForThatDay);
                    }
                }

                filteredSalesAndCollections = mapSalesAndCollections;

                int count = 1;              
                foreach (var soc in filteredSalesAndCollections)
                {
                    soc.Sl = (count++).ToString();
                }                
            }

            if(filteredSalesAndCollections != null)
            {
                BindDataTable(filteredSalesAndCollections);
                _tempedSalesAndCollections = filteredSalesAndCollections;
            }

            isTimePeriodChanged = false;
        }
        private void TB_SAC_Search_TextChanged(object sender, EventArgs e)
        {
            BindAllFilters();
        }

        private List<SalesAndCollectionModel> SearchResult(string searchText, List<SalesAndCollectionModel> salesAndCollections)
        {
            searchText = searchText.ToLower();

            var filteredSalesAndCollections = salesAndCollections.Where(x => x.DealerName.ToLower().Contains(searchText)
                                                    || x.DealerCode.ToLower().Contains(searchText)
                                                    || x.Contact.ToLower().Contains(searchText)
                                                    || x.Address.ToLower().Contains(searchText)
                                                    || x.IC_NO.ToLower().Contains(searchText)
                                                    || x.MR_NO.ToLower().Contains(searchText)
                                                    || x.Remarks.ToLower().Contains(searchText)
                                                    || x.CollectionAmount.ToString().ToLower().Contains(searchText)
                                                    || x.SalesAmount.ToString().ToLower().Contains(searchText)).ToList();

            return filteredSalesAndCollections;
        }

        private void CKB_GroupBy_CheckedChanged(object sender, EventArgs e)
        {
            BindAllFilters();
        }

        private void CB_SAC_DealerCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAllFilters();
        }

        private void BSAC_AddNewCollection_Click(object sender, EventArgs e)
        {
            PopupModalForm pmf = new PopupModalForm();

            PopupCollectionModelControl pmc = new PopupCollectionModelControl(_vPanel, _hPanel, pmf, this, CB_SAC_DealerCode.Text);

            pmc.Show();
            //pmc.Dispose();

            pmf.Controls.Add(pmc);
            pmf.ShowDialog();
        }

        private void BSAC_SavePartyLedger_Click(object sender, EventArgs e)
        {
            isPartyLedger = true;

            if (CB_SAC_DealerCode.Text.ToLower().Equals("any"))
            {
                MessageBox.Show("Select a 'Dealer / Party Code' to save Party Ledger");
            }
            else
            {               
                if (_tempedSalesAndCollections.Count > 0)
                {
                    SaveFileDialogExecute();
                }
                else
                {
                    MessageBox.Show("List is Empty :(");
                }
            }
        }

        private void BSAC_SaveDaily_Click(object sender, EventArgs e)
        {
            if(_tempedSalesAndCollections.Count > 0)
            {
                isPartyLedger = false;
                SaveFileDialogExecute();
            }
            else
            {
                MessageBox.Show("List is Empty :(");
            }
        }

        private void SaveFileDialogExecute()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save";
            saveDialog.Filter = ".xlsx Files (*.xlsx)|*.xlsx" + "|" +
                                "Text Files (*.txt)|*.txt" + "|" +
                                "Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" +
                                "All Files (*.*)|*.*";

            if(isPartyLedger)
                saveDialog.FileName = _tempedSalesAndCollections.FirstOrDefault().DealerName + " (" + _tempedSalesAndCollections.FirstOrDefault().DealerCode + ") - Party Ledger " + DateTime.Now.ToString("dd MMMM yyyy");
            else
                saveDialog.FileName = "Sales And Collections " + " (" + CB_SAC_DealerCode.Text + ") - " + DateTime.Now.ToString("dd MMMM yyyy");

            if(!string.IsNullOrEmpty(saveDialog.FileName))
                saveDialog.FileName = saveDialog.FileName.Replace('/', '_');

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                _fullPath = saveDialog.FileName;

                // start the animation
                SAC_ProgressPanel.Visible = true;
                SACProgressBar.Visible = true;
                SACProgressBar.Style = ProgressBarStyle.Marquee;
                _vPanel.Enabled = false;
                _hPanel.Enabled = false;

                // start the job
                SACBackgroundWorker.RunWorkerAsync();
            }
            else
            {

            }
        }

        private void DTP_SAC_FromDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateIfTimePeriodNotChanged();
        }

        private void DTP_SAC_ToDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateIfTimePeriodNotChanged();
        }

        private void UpdateIfTimePeriodNotChanged()
        {
            if(!isTimePeriodChanged)
            {
                CB_SAC_TimePeriod.Text = "Custom";
                BindAllFilters();
            }
        }

        private void BSAC_DeleteSOC_Click(object sender, EventArgs e)
        {
            if(_tempedSalesAndCollections.Count > 0)
            {
                DataGridViewRow row = this.DGV_SAC_SalesAndCollectionList.SelectedRows[0];

                if (row != null)
                {
                    DialogResult dialogResult = MessageBox.Show(" Are you sure? ", "Confirm Delete?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SalesAndCollectionModel soc = row.DataBoundItem as SalesAndCollectionModel;

                        if (CKB_GroupBy.Checked)
                        {
                            if (CB_SAC_DealerCode.Text.ToLower().Equals("any"))
                            {
                                MessageBox.Show("Please select a Dealer code!");
                            }
                            else
                            {
                                if (SalesAndCollectionManager.DeleteSaleOrCollection(soc, true))
                                {
                                    MessageBox.Show("All sales and collections for Dealer :" + soc.DealerName + "(" + soc.DealerCode + ") on Date : " + soc.Date + " has been Deleated!");
                                    BindAllFilters();
                                }
                                else
                                {
                                    MessageBox.Show("Error! Something went wrong while Deleting!!");
                                }
                            }
                        }
                        else
                        {
                            if (SalesAndCollectionManager.DeleteSaleOrCollection(soc, false))
                            {
                                MessageBox.Show("Deleated Successfully!");
                                BindAllFilters();
                            }
                            else
                            {
                                MessageBox.Show("Error! Something went wrong while Deleting!!");
                            }
                        }

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
                else
                {
                    MessageBox.Show("Select a row to delete!");
                }
            }
            else
            {
                MessageBox.Show("List is Empty :(");
            }         
        }

        private void CKB_Ascending_CheckedChanged(object sender, EventArgs e)
        {
            BindAllFilters();
        }
    }
}
