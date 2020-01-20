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

namespace Invoiceasy.WinForms
{
    public partial class ProductControl : UserControl
    {
        private List<ProductModel> _productList;
        public ProductControl()
        {
            InitializeComponent(); 
            this.Load += new System.EventHandler(this.ProductControl_Load);
        }

        private void ProductControl_Load(object sender, EventArgs e)
        {
            this.DGV_ProductList.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
            this.DGV_ProductList.MultiSelect = true;

        }

        public void Assign(List<ProductModel> productList)
        {
            _productList = productList;
            var bindingList = new BindingList<ProductModel>(_productList);
            var source = new BindingSource(bindingList, null);
            DGV_ProductList.DataSource = source;
        }

        private void DGV_ProductList_MultiSelectChanged(object sender, EventArgs e)
        {
            MessageBox.Show("You are in the DataGridView.MultiSelectChanged event.");
        }

        private void BPC_Next_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.DGV_ProductList.SelectedRows;

            List<ProductModel> selectedProducts = new List<ProductModel>(); 

            foreach(DataGridViewRow row in rows)
            {
                ProductModel product = row.DataBoundItem as ProductModel;
                selectedProducts.Add(product);
            }
        }
    }
}
