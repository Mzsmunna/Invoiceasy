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
using Invoiceasy.Helper;
using Invoiceasy.Manager;

namespace Invoiceasy.WinForms
{
    public partial class SelectProductsControl : UserControl
    {
        private Panel _hPanel;
        private Panel _vPanel;
        private List<ProductModel> _productList;
        private PageModel _page;
        private bool newRowNeeded = false;

        public SelectProductsControl()
        {
            InitializeComponent(); 
            this.Load += new System.EventHandler(this.SelectProductsControl_Load);
        }

        public SelectProductsControl(Panel hPanel, Panel vPanel, PageModel page)
                                    : this()
        {
            _hPanel = hPanel;
            _vPanel = vPanel;
            _page = page;

            _productList = ProductManager.GetAllProducts();

            RefreshProductTable(_productList);

            RefreshItemTable();

        }

        private void SelectProductsControl_Load(object sender, EventArgs e)
        {
            this.DGV_SPC_Products.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
            this.DGV_SPC_Products.MultiSelect = true;

        }

        private void BSPC_Next_Click(object sender, EventArgs e)
        {
            if(_page.AllProducts.Count > 0)
            {
                InvoiceControl ic = new InvoiceControl(_hPanel, _vPanel, _page);
                _hPanel.Controls.Clear();
                _hPanel.Controls.Add(ic);
                ic.Dock = DockStyle.Fill;
                ic.Show();
            }
            else
            {
                MessageBox.Show("Selected items is Empty!! Add One or More Products to proceed Next.");
            }         
        }

        private void BSPC_Add_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.DGV_SPC_Products.SelectedRows;

            if (rows.Count > 0)
            {
                List<ProductModel> selectedProducts = new List<ProductModel>();

                foreach (DataGridViewRow row in rows)
                {
                    ProductModel product = row.DataBoundItem as ProductModel;
                    selectedProducts.Add(product);

                    var exist = _page.AllProducts.Where(x => x.ProductCode.Equals(product.ProductCode)).FirstOrDefault();

                    if(exist == null)
                    {
                        var item = new ItemModel
                        {
                            SerialNo = _page.ItemCount.ToString(),
                            ProductDescriptions = product.ItemDescription,
                            Quantity = 1,
                            UnitPrice = Convert.ToInt32(product.UnitPrice),
                            Unit = "Pcs",
                            ProductCode = product.ProductCode
                        };

                        _page.AllProducts.Add(item);
                        _page.ItemCount++;
                    }
                    else
                    {
                        MessageBox.Show("Product '" + product.ProductCode +"' is already Added. You can't select same product twice!!");
                    }
                    
                }

                _page.AllProducts.RemoveAll(item => item == null);

                RefreshItemTable();
            }
            else
            {
                MessageBox.Show("Select One or More Products to Add.");
            }
        }

        private void RefreshItemTable()
        {
            var itemBindingList = new BindingList<ItemModel>(_page.AllProducts);
            var itemSource = new BindingSource(itemBindingList, null);
            DGV_SPC_Items.DataSource = itemSource;
            DGV_SPC_Items.Columns["SerialNo"].ReadOnly = true;
            DGV_SPC_Items.Columns["TotalAmount"].Visible = false;
        }

        private void RefreshProductTable(List<ProductModel> productList)
        {
            var productBindingList = new BindingList<ProductModel>(productList);
            var productSource = new BindingSource(productBindingList, null);
            DGV_SPC_Products.DataSource = productSource;
        }

        private void TB_SPC_Search_TextChanged(object sender, EventArgs e)
        {
            var searchText = TB_SPC_Search.Text.ToLower();

            List<ProductModel> searchedProducts = new List<ProductModel>();

            if(string.IsNullOrEmpty(searchText))
            {
                RefreshProductTable(_productList);
            }
            else
            {
                searchedProducts = _productList.Where(x => x.ProductCode.ToLower().Contains(searchText)
                                                    || x.Category.ToLower().Contains(searchText)
                                                    || x.ItemDescription.ToLower().Contains(searchText)).ToList();


                RefreshProductTable(searchedProducts);

            }
        }

        private void BSPC_Remove_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = DGV_SPC_Items.SelectedRows;

            if (rows.Count > 0)
            {
                List<ItemModel> selectedItems = new List<ItemModel>();

                foreach (DataGridViewRow row in rows)
                {
                    ItemModel item = row.DataBoundItem as ItemModel;
                    selectedItems.Add(item);

                    var exist = _page.AllProducts.Where(x => x.ProductCode.Equals(item.ProductCode) || x.SerialNo.Equals(item.SerialNo)).FirstOrDefault();

                    if (exist != null)
                    {
                        _page.AllProducts.Remove(item);
                        _page.ItemCount--;
                    }
                    else
                    {
                        MessageBox.Show("Product can't be remove for some unknown reason!!");
                    }

                }

                _page.AllProducts.RemoveAll(item => item == null);

                int count = 1;

                foreach(var item in _page.AllProducts)
                {
                    item.SerialNo = count.ToString();
                    count++;
                }

                RefreshItemTable();
            }
            else
            {
                MessageBox.Show("Select One or More Products to Remove.");
            }
        }

        private void DGV_SPC_Items_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(_page.AllProducts.Count == e.RowIndex + 1)
            {
                DataGridViewRow row = DGV_SPC_Items.Rows[e.RowIndex];

                ItemModel item = row.DataBoundItem as ItemModel;

                if (item != null)
                {
                    if (string.IsNullOrEmpty(item.SerialNo))
                    {
                        item.SerialNo = (_page.ItemCount++).ToString();

                        if (string.IsNullOrEmpty(item.Unit))
                        {
                            item.Unit = "Pcs";
                        }
                    }
                }
            }           
        }

        private void DGV_SPC_Items_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewColumn col = DGV_SPC_Items.Columns[e.ColumnIndex] as DataGridViewColumn;

            if (col.Name.ToLower() == "unitprice" || col.Name.ToLower() == "quantity")
            {
                DataGridViewTextBoxCell cell = DGV_SPC_Items[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
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
    }
}
