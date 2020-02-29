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
using Newtonsoft.Json;
using System.IO;
using Invoiceasy.Helper;
using Invoiceasy.Manager;

namespace Invoiceasy.WinForms
{
    public partial class ChallanControl : UserControl
    {
        private Panel _hPanel;
        private Panel _vPanel;
        private ChallanPageModel _challanPage;
        private bool _isSuccess = false;

        public ChallanControl()
        {
            InitializeComponent();

            ChallanBackgroundWorker.DoWork += BackgroundWorker_DoWork;
            ChallanBackgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        public ChallanControl(Panel hPanel, Panel vPanel, ChallanPageModel challanPage)
                                    : this()
        {
            _hPanel = hPanel;
            _vPanel = vPanel;

            _challanPage = challanPage;

            BindObjectDataToInterface();
        }

        private void BindObjectDataToInterface()
        {
            var bindingList = new BindingList<ItemModel>(_challanPage.AllProducts);
            var source = new BindingSource(bindingList, null);
            DGV_CC_PageItems.DataSource = source;

            DGV_CC_PageItems.Columns["SerialNo"].ReadOnly = true;
            DGV_CC_PageItems.Columns["TotalAmount"].Visible = false;
            DGV_CC_PageItems.Columns["ProductCode"].Visible = false;

            if (!string.IsNullOrEmpty(_challanPage.Date))
                DTP_CC_Date.Value = Convert.ToDateTime(_challanPage.Date);

            TBCC_NO.Text = _challanPage.No;
            TBCC_TO.Text = _challanPage.Dealer.DealerName;
            TBCC_Address.Text = _challanPage.Dealer.Address;
            TBCC_Contact.Text = _challanPage.Dealer.Contact;
            TBCC_Note.Text = _challanPage.Note;

            _challanPage.TotalQuality = _challanPage.AllProducts.Sum(x => x.Quantity);
            TBCC_TotalQ.Text = _challanPage.TotalQuality.ToString();

            if (string.IsNullOrEmpty(CBCC_Code.Text))
            {
                CBCC_Code.Text = _challanPage.Dealer.Code;
                //CBCC_Code.Items.AddRange(_challanPage.DealerList.Select(x => x.Code).ToArray());
            }
            else
            {
                CBCC_Code.Text = _challanPage.Dealer.Code;
            }
        }

        private void BindInterfaceDataToObject()
        {
            _challanPage.No = TBCC_NO.Text;
            _challanPage.Dealer.DealerName = TBCC_TO.Text;
            _challanPage.Dealer.Address = TBCC_Address.Text;
            _challanPage.Dealer.Contact = TBCC_Contact.Text;
            _challanPage.Date = DTP_CC_Date.Value.ToString("MMMM dd, yyyy");
            _challanPage.Note = TBCC_Note.Text;
        }

        private void DGV_CC_PageItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewColumn col = DGV_CC_PageItems.Columns[e.ColumnIndex] as DataGridViewColumn;

            if (col.Name.ToLower() == "unitprice" || col.Name.ToLower() == "quantity")
            {
                DataGridViewTextBoxCell cell = DGV_CC_PageItems[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
                if (cell != null)
                {
                    char[] chars = e.FormattedValue.ToString().ToCharArray();
                    foreach (char c in chars)
                    {
                        if (char.IsDigit(c) == false)
                        {
                            MessageBox.Show("You have to enter digits only");
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }
        }

        private void DGV_CC_PageItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRowCollection rows = this.DGV_CC_PageItems.Rows;

            if (rows.Count > 0)
            {
                List<ItemModel> allInvoiceItems = new List<ItemModel>();
                foreach (DataGridViewRow row in rows)
                {
                    ItemModel item = JsonConvert.DeserializeObject<ItemModel>(JsonConvert.SerializeObject(row.DataBoundItem));
                    if (item != null)
                    {
                        item.TotalAmount = Convert.ToInt32(item.UnitPrice * item.Quantity);
                        allInvoiceItems.Add(item);
                    }
                }

                _challanPage.AllProducts = allInvoiceItems;

                BindInterfaceDataToObject();
                BindObjectDataToInterface();
            }
        }

        private void BCC_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save";
            saveDialog.Filter = ".xlsx Files (*.xlsx)|*.xlsx" + "|" +
                                "Text Files (*.txt)|*.txt" + "|" +
                                "Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" +
                                "All Files (*.*)|*.*";

            if (string.IsNullOrEmpty(_challanPage.FullPath))
                saveDialog.FileName = "Challan-" + _challanPage.No+ "_" + DateTime.Now.ToString("dd MMMM yyyy HH-mm-ss");
            else
                saveDialog.FileName = _challanPage.FullPath;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                _challanPage.FullPath = saveDialog.FileName;
                _challanPage.FileLocation = Path.GetDirectoryName(saveDialog.FileName) + @"\";
                _challanPage.FileName = Path.GetFileNameWithoutExtension(saveDialog.FileName);

                BindInterfaceDataToObject();
                _challanPage.Note = "Note : " + TBCC_Note.Text;

                // start the animation
                CC_ProgressPanel.Visible = true;
                ChallanProgressBar.Visible = true;
                ChallanProgressBar.Style = ProgressBarStyle.Marquee;
                _vPanel.Enabled = false;
                _hPanel.Enabled = false;

                // start the job
                ChallanBackgroundWorker.RunWorkerAsync();
            }
            else
            {

            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            IManager manager = new ChallanManager(_challanPage);
            _isSuccess = manager.Execute();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CC_ProgressPanel.Visible = false;
            ChallanProgressBar.Visible = false;
            _vPanel.Enabled = true;
            _hPanel.Enabled = true;

            void SaveChallanLogFile()
            {
                Files challanLog = new Files();
                challanLog.FileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Invoiceasy\ChallanLog";

                if (!string.IsNullOrEmpty(_challanPage.PreviousLogFile))
                {
                    FileSystemUtility.DeleteFile(_challanPage.PreviousLogFile);
                }

                if (!string.IsNullOrEmpty(_challanPage.CurrentLogFile))
                {
                    challanLog.FileName = FileSystemUtility.GetFileName(_challanPage.CurrentLogFile);
                    FileSystemUtility.DeleteFile(_challanPage.CurrentLogFile);
                }
                else
                {
                    challanLog.FileName = "ChallanLog-" + _challanPage.No + "_" + DTP_CC_Date.Value.ToString("dd MMMM yyyy") + " " + DateTime.Now.ToString("HH-mm-ss") + ".txt";
                    _challanPage.CurrentLogFile = _challanPage.FileLocation + @"\" + _challanPage.FileName;
                    FileSystemUtility.DeleteFile(_challanPage.CurrentLogFile);
                }

                challanLog.FileText = JsonConvert.SerializeObject(_challanPage);
                
                FileSystemUtility.Initialize(true, challanLog);
                FileSystemUtility.WriteFile();
            }

            BindInterfaceDataToObject();

            SaveChallanLogFile();

            if (_isSuccess)
                MessageBox.Show("Challan file has been saved successfully");
            else
                MessageBox.Show("Error! Something Went Wrong while saving the file");

            //GetBackToHome();
            GoToDealerSalesAndCollection();
        }

        private void GoToDealerSalesAndCollection()
        {
            _hPanel.Controls.Clear();
            SalesAndCollectionControl sacc = new SalesAndCollectionControl(_hPanel, _vPanel,_challanPage.Dealer);
            _hPanel.Controls.Add(sacc);
            sacc.Dock = DockStyle.Fill;
            sacc.Show();
        }

        private void GetBackToHome()
        {
            _hPanel.Controls.Clear();
            HomeControl hc = new HomeControl();
            _hPanel.Controls.Add(hc);
            hc.Dock = DockStyle.Fill;
            hc.Show();
        }
    }
}
