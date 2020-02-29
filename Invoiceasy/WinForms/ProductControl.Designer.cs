namespace Invoiceasy.WinForms
{
    partial class ProductControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LProductList = new System.Windows.Forms.Label();
            this.DGV_ProductList = new System.Windows.Forms.DataGridView();
            this.BPC_Delete = new System.Windows.Forms.Button();
            this.BPC_Add_Product = new System.Windows.Forms.Button();
            this.BPC_Edit_Product = new System.Windows.Forms.Button();
            this.TBPC_Search = new System.Windows.Forms.TextBox();
            this.LPC_Search = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ProductList)).BeginInit();
            this.SuspendLayout();
            // 
            // LProductList
            // 
            this.LProductList.AutoSize = true;
            this.LProductList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProductList.Location = new System.Drawing.Point(315, 23);
            this.LProductList.Name = "LProductList";
            this.LProductList.Size = new System.Drawing.Size(111, 16);
            this.LProductList.TabIndex = 0;
            this.LProductList.Text = "All Product List";
            // 
            // DGV_ProductList
            // 
            this.DGV_ProductList.AllowUserToAddRows = false;
            this.DGV_ProductList.AllowUserToDeleteRows = false;
            this.DGV_ProductList.AllowUserToOrderColumns = true;
            this.DGV_ProductList.AllowUserToResizeColumns = false;
            this.DGV_ProductList.AllowUserToResizeRows = false;
            this.DGV_ProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ProductList.Location = new System.Drawing.Point(12, 105);
            this.DGV_ProductList.Name = "DGV_ProductList";
            this.DGV_ProductList.ReadOnly = true;
            this.DGV_ProductList.Size = new System.Drawing.Size(744, 461);
            this.DGV_ProductList.TabIndex = 1;
            // 
            // BPC_Delete
            // 
            this.BPC_Delete.Location = new System.Drawing.Point(477, 572);
            this.BPC_Delete.Name = "BPC_Delete";
            this.BPC_Delete.Size = new System.Drawing.Size(93, 42);
            this.BPC_Delete.TabIndex = 4;
            this.BPC_Delete.Text = "Delete Product";
            this.BPC_Delete.UseVisualStyleBackColor = true;
            this.BPC_Delete.Click += new System.EventHandler(this.BPC_Delete_Click);
            // 
            // BPC_Add_Product
            // 
            this.BPC_Add_Product.Location = new System.Drawing.Point(657, 572);
            this.BPC_Add_Product.Name = "BPC_Add_Product";
            this.BPC_Add_Product.Size = new System.Drawing.Size(99, 42);
            this.BPC_Add_Product.TabIndex = 5;
            this.BPC_Add_Product.Text = "Add New Product";
            this.BPC_Add_Product.UseVisualStyleBackColor = true;
            this.BPC_Add_Product.Click += new System.EventHandler(this.BPC_Add_Product_Click);
            // 
            // BPC_Edit_Product
            // 
            this.BPC_Edit_Product.Location = new System.Drawing.Point(576, 572);
            this.BPC_Edit_Product.Name = "BPC_Edit_Product";
            this.BPC_Edit_Product.Size = new System.Drawing.Size(75, 42);
            this.BPC_Edit_Product.TabIndex = 6;
            this.BPC_Edit_Product.Text = "Edit Product";
            this.BPC_Edit_Product.UseVisualStyleBackColor = true;
            this.BPC_Edit_Product.Click += new System.EventHandler(this.BPC_Edit_Product_Click);
            // 
            // TBPC_Search
            // 
            this.TBPC_Search.Location = new System.Drawing.Point(76, 75);
            this.TBPC_Search.Name = "TBPC_Search";
            this.TBPC_Search.Size = new System.Drawing.Size(267, 20);
            this.TBPC_Search.TabIndex = 7;
            this.TBPC_Search.TextChanged += new System.EventHandler(this.TBPC_Search_TextChanged);
            // 
            // LPC_Search
            // 
            this.LPC_Search.AutoSize = true;
            this.LPC_Search.Location = new System.Drawing.Point(20, 75);
            this.LPC_Search.Name = "LPC_Search";
            this.LPC_Search.Size = new System.Drawing.Size(50, 13);
            this.LPC_Search.TabIndex = 8;
            this.LPC_Search.Text = "Search : ";
            // 
            // ProductControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LPC_Search);
            this.Controls.Add(this.TBPC_Search);
            this.Controls.Add(this.BPC_Edit_Product);
            this.Controls.Add(this.BPC_Add_Product);
            this.Controls.Add(this.BPC_Delete);
            this.Controls.Add(this.DGV_ProductList);
            this.Controls.Add(this.LProductList);
            this.Name = "ProductControl";
            this.Size = new System.Drawing.Size(770, 630);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ProductList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LProductList;
        public System.Windows.Forms.DataGridView DGV_ProductList;
        private System.Windows.Forms.Button BPC_Delete;
        private System.Windows.Forms.Button BPC_Add_Product;
        private System.Windows.Forms.Button BPC_Edit_Product;
        private System.Windows.Forms.TextBox TBPC_Search;
        private System.Windows.Forms.Label LPC_Search;
    }
}
