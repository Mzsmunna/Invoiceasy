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
    public partial class ProductControl : UserControl
    {
        private Panel _vPanel;
        private Panel _hPanel;
        private List<ProductModel> _productList;
        public ProductControl()
        {
            InitializeComponent(); 
            this.Load += new System.EventHandler(this.ProductControl_Load);
        }

        public ProductControl(Panel vPanel, Panel hPanel)
                                    : this()
        {
            _vPanel = vPanel;
            _hPanel = hPanel;
        }

        private void ProductControl_Load(object sender, EventArgs e)
        {
            _productList = ProductManager.GetAllProducts();

            DGV_ProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_ProductList.MultiSelect = false;
            _productList = ProductManager.GetAllProducts();

            BindObjectDataToInterface();

            DGV_ProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_ProductList.MultiSelect = false;

            DGV_ProductList.Columns["Sl"].ReadOnly = true;
            DGV_ProductList.Columns["Image"].Visible = false;
        }

        private void BindObjectDataToInterface()
        {
            var bindingList = new BindingList<ProductModel>(_productList);
            var source = new BindingSource(bindingList, null);
            DGV_ProductList.DataSource = source;
        }

        private void BPC_Add_Product_Click(object sender, EventArgs e)
        {
            PopupModalForm pmf = new PopupModalForm();

            PopupProductModelControl pmc = new PopupProductModelControl(_vPanel, _hPanel, pmf, this);
            pmc.Show();
            //pmc.Dispose();

            pmf.Controls.Add(pmc);
            pmf.ShowDialog();
        }

        private void BPC_Delete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.DGV_ProductList.SelectedRows[0];

            if (row != null)
            {
                DialogResult dialogResult = MessageBox.Show(" Are you sure? ", "Confirm Delete?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ProductModel product = row.DataBoundItem as ProductModel;

                    ProductManager.DeleteProduct(product);

                    MessageBox.Show("Product has been deleated successfully!");

                    _productList = ProductManager.GetAllProducts();

                    BindObjectDataToInterface();

                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }
            else
            {
                MessageBox.Show("Select a Product to Delete.");
            }
        }

        private void BPC_Edit_Product_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.DGV_ProductList.SelectedRows[0];

            if (row != null)
            {
                ProductModel product = row.DataBoundItem as ProductModel;

                PopupModalForm pmf = new PopupModalForm();

                PopupProductModelControl pmc = new PopupProductModelControl(_vPanel, _hPanel, product, this, pmf);
                pmc.Show();
                //pmc.Dispose();

                pmf.Controls.Add(pmc);
                pmf.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a Product to Edit.");
            }
        }

        private void RefreshProductTable(List<ProductModel> productList)
        {
            var dealerBindingList = new BindingList<ProductModel>(productList);
            var dealerSource = new BindingSource(dealerBindingList, null);
            DGV_ProductList.DataSource = dealerSource;
        }

        private void TBPC_Search_TextChanged(object sender, EventArgs e)
        {
            var searchText = TBPC_Search.Text.ToLower();

            List<ProductModel> searchedProducts = new List<ProductModel>();

            if (string.IsNullOrEmpty(searchText))
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
    }
}
