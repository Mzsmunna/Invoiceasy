﻿using System;
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

namespace Invoiceasy.WinForms
{
    public partial class SelectProductsControl : UserControl
    {
        private Panel _hPanel;
        private List<ProductModel> _productList;
        private PageModel _page;
        public SelectProductsControl()
        {
            InitializeComponent(); 
            this.Load += new System.EventHandler(this.SelectProductsControl_Load);
        }

        public SelectProductsControl(Panel hPanel, PageModel page)
                                    : this()
        {
            _hPanel = hPanel;
            _page = page;

            var productFilePath = @"\Libs\Files\CoreFiles\DataFiles\ProductList.txt";

            _productList = CsvHelperUtility.ReadDataFromFile<ProductModel, ProductModelMap>(productFilePath);

            var bindingList = new BindingList<ProductModel>(_productList);
            var source = new BindingSource(bindingList, null);
            DGV_SPC_Products.DataSource = source;

        }

        private void SelectProductsControl_Load(object sender, EventArgs e)
        {
            this.DGV_SPC_Products.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
            this.DGV_SPC_Products.MultiSelect = true;

        }

        private void BSPC_Next_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.DGV_SPC_Products.SelectedRows;

            if(rows.Count > 0)
            {
                List<ProductModel> selectedProducts = new List<ProductModel>();

                foreach (DataGridViewRow row in rows)
                {
                    ProductModel product = row.DataBoundItem as ProductModel;
                    selectedProducts.Add(product);

                    var item = new ItemModel
                    {
                        SerialNo = _page.ItemCount.ToString(),
                        ProductDescriptions = product.ItemDescription,
                        Quantity = product.StockAvailable, //random.Next(1, 100),
                        UnitPrice = Convert.ToInt32(product.UnitPrice),
                        Unit = "Pcs"
                    };

                    item.TotalAmount = Convert.ToInt32(item.UnitPrice * item.Quantity);
                    product.StockAvailable -= item.Quantity;

                    _page.AllProducts.Add(item);
                    _page.ItemCount++;
                }

                InvoiceControl ic = new InvoiceControl(_hPanel, _page);
                _hPanel.Controls.Clear();
                _hPanel.Controls.Add(ic);
                ic.Dock = DockStyle.Fill;
                ic.Show();
            }
            else
            {
                MessageBox.Show("Select One or More Products to proceed Next.");
            }          
        }
    }
}