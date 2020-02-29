using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Invoiceasy.Helper;
using Invoiceasy.ViewModel;
using Newtonsoft.Json;
using Invoiceasy.Enum;

namespace Invoiceasy.WinForms
{
    public partial class ICHistoryControl : UserControl
    {
        private Panel _hPanel;
        private Panel _vPanel;
        private PageType _logType;
        private FileInfo[] _logListFiles;
        private UserControl _ic;

        public ICHistoryControl()
        {
            InitializeComponent();
        }

        public ICHistoryControl(Panel hPanel, Panel vPanel, PageType logType)
                                    : this()
        {
            _hPanel = hPanel;
            _vPanel = vPanel;
            _logType = logType;

            //LV_ICHC_InvoiceLog.FullRowSelect = true;
            //LV_ICHC_InvoiceLog.GridLines = true;
            //LV_ICHC_InvoiceLog.View = System.Windows.Forms.View.List;

            LoadListView();           
        }

        private void LoadListView()
        {
            LV_ICHC_InvoiceLog.Clear();

            if (_logType == PageType.Invoice)
            {
                _logListFiles = FileSystemUtility.GetFilesFromFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Invoiceasy\InvoiceLog\", "InvoiceLog");
                LV_ICHC_InvoiceLog.Columns.Add("Invoice History", -2, HorizontalAlignment.Left);
                LICHC_Title.Text = "Invoice History";
            }
            else if (_logType == PageType.Challan)
            {
                _logListFiles = FileSystemUtility.GetFilesFromFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Invoiceasy\ChallanLog\", "ChallanLog");
                LV_ICHC_InvoiceLog.Columns.Add("Challan History", -2, HorizontalAlignment.Left);
                LICHC_Title.Text = "Challan History";
            }

            BindListView();
        }

        private void BindListView()
        {
            LV_ICHC_InvoiceLog.FullRowSelect = true;
            LV_ICHC_InvoiceLog.GridLines = true;
            LV_ICHC_InvoiceLog.View = System.Windows.Forms.View.List;

            foreach (FileInfo foundFile in _logListFiles)
            {
                //string fullName = foundFile.FullName;
                //Console.WriteLine(fullName);
                ListViewItem lvi = new ListViewItem(foundFile.FullName);
                //lvi.SubItems.Add(foundFile.Name);
                //lvi.SubItems.Add(foundFile.Extension);
                //lvi.SubItems.Add(foundFile.DirectoryName);
                //lvi.SubItems.Add(foundFile.CreationTime.ToString());

                LV_ICHC_InvoiceLog.Items.Add(lvi);
            }
        }

        private void LV_IHC_InvoiceLog_DoubleClick(object sender, EventArgs e)
        {
            var file = LV_ICHC_InvoiceLog.SelectedItems[0].Text;

            string logJSON = FileSystemUtility.ReadFile(file);
            InvoicePageModel invoicePage;
            ChallanPageModel challanPage;

            if (_logType == PageType.Invoice)
            {
                invoicePage = JsonConvert.DeserializeObject<InvoicePageModel>(logJSON);
                _ic = new InvoiceControl(_hPanel, _vPanel, invoicePage);
            }               
            else if (_logType == PageType.Challan)
            {
                challanPage = JsonConvert.DeserializeObject<ChallanPageModel>(logJSON);
                _ic = new ChallanControl(_hPanel, _vPanel, challanPage);
            }
                
            _hPanel.Controls.Clear();
            _hPanel.Controls.Add(_ic);
            _ic.Dock = DockStyle.Fill;
            _ic.Show();
        }

        private void BICHC_Delete_Click(object sender, EventArgs e)
        {
            var file = LV_ICHC_InvoiceLog.SelectedItems[0].Text;

            if(FileSystemUtility.DeleteFile(file))
            {
                MessageBox.Show("File has been Deleted successfully");

                LoadListView();
            }
            else
            {
                MessageBox.Show("file not found!");
            }
        }

        private void BICHC_ExcellOpen_Click(object sender, EventArgs e)
        {
            var file = LV_ICHC_InvoiceLog.SelectedItems[0].Text;
            string logJSON = FileSystemUtility.ReadFile(file);

            PageModel page = JsonConvert.DeserializeObject<PageModel>(logJSON);

            if(page != null)
            {
                if (File.Exists(page.FullPath))
                    System.Diagnostics.Process.Start(page.FullPath);
                else
                    MessageBox.Show("file not found!");
            }
            else
            {
                MessageBox.Show("An error occurred!!");
            }
        }
    }
}
