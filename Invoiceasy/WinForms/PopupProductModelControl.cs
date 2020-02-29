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
    public partial class PopupProductModelControl : UserControl
    {
        ProductModel _product;
        ProductControl _productControl;
        Form _popUpForm;

        private Panel _vPanel;
        private Panel _hPanel;

        public PopupProductModelControl(Panel vPanel, Panel hPanel, Form popUpForm, ProductControl productControl)
        {
            _popUpForm = popUpForm;
            _vPanel = vPanel;
            _hPanel = hPanel;
            _productControl = productControl;
            InitializeComponent(); 
            this.Load += new System.EventHandler(this.PopupModelControl_Load);
        }

        public PopupProductModelControl(Panel vPanel, Panel hPanel, ProductModel product, ProductControl productControl, Form popUpForm)
                                    : this(vPanel, hPanel, popUpForm, productControl)
        {
            _product = product;
        }

        private void PopupModelControl_Load(object sender, EventArgs e)
        {
            if(_product == null)
            {
                LPMC_Title.Text = "ADD New Product";
                BPMC_AddOrUpdate.Text = "Add";

                _product = new ProductModel
                {
                    Category = "",
                    ProductCode = "",
                    ItemDescription = "",
                    StockAvailable = 10,
                    UnitPrice = 100.ToString(),
                    Sl = (ProductManager.GetAllProductsCount() + 1).ToString(),
                };
            }
            else
            {
                LPMC_Title.Text = "Edit Product";
                BPMC_AddOrUpdate.Text = "Update";
            }

            BindObjectDataToInterface();

        }

        private void BindObjectDataToInterface()
        {
            TB_PMC_Category.Text = _product.Category;
            TB_PMC_Code.Text = _product.ProductCode;
            TB_PMC_Description.Text = _product.ItemDescription;
            TB_PMC_Stock.Text = _product.StockAvailable.ToString();
            TB_PMC_UnitPrice.Text = _product.UnitPrice;
        }

        private void BindInterfaceDataToObject()
        {
            _product.Category = TB_PMC_Category.Text;
            _product.ProductCode = TB_PMC_Code.Text;
            _product.ItemDescription = TB_PMC_Description.Text;
            _product.UnitPrice = TB_PMC_UnitPrice.Text;

            if (_product.Category.Equals("")
                || _product.ProductCode.Equals("")
                || _product.ItemDescription.Equals("")
                || TB_PMC_Stock.Text.Equals("")
                || TB_PMC_UnitPrice.Text.Equals(""))
            {
                MessageBox.Show("Fill up all boxes!!");
            }
            else
            {
                _product.StockAvailable = Convert.ToInt32(TB_PMC_Stock.Text);
                ConfirmChange();
            }

            void ConfirmChange()
            {
                DialogResult dialogResult = MessageBox.Show(BPMC_AddOrUpdate.Text + " Dealer? ", "Confirm Change?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (_product != null)
                    {
                        if (BPMC_AddOrUpdate.Text.Equals("Update"))
                        {
                            if (ProductManager.UpdateProduct(_product))
                            {
                                MessageBox.Show("Product Updated successfully!");

                                ReloadDealerControl();
                            }
                            else
                            {
                                MessageBox.Show("Error! Product Code already Exist! Dealer Code must be unique!");
                            }
                        }
                        else if (BPMC_AddOrUpdate.Text.Equals("Add"))
                        {
                            if (ProductManager.AddProduct(_product))
                            {
                                MessageBox.Show("Product Added successfully!");

                                ReloadDealerControl();
                            }
                            else
                            {
                                MessageBox.Show("Error! Product Code already Exist! Dealer Code must be unique!");
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
                    _productControl = new ProductControl(_vPanel, _hPanel);
                    _hPanel.Controls.Add(_productControl);
                    _productControl.Dock = DockStyle.Fill;
                    _productControl.Show();
                    _popUpForm.Close();
                }
            }
        }

        private void BPMC_AddOrUpdate_Click(object sender, EventArgs e)
        {
            BindInterfaceDataToObject();
        }

        private void TB_PMC_Stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void TB_PMC_UnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
    }
}
