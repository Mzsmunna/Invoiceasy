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
            this.BPC_Next = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ProductList)).BeginInit();
            this.SuspendLayout();
            // 
            // LProductList
            // 
            this.LProductList.AutoSize = true;
            this.LProductList.Location = new System.Drawing.Point(222, 34);
            this.LProductList.Name = "LProductList";
            this.LProductList.Size = new System.Drawing.Size(77, 13);
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
            this.DGV_ProductList.Location = new System.Drawing.Point(25, 63);
            this.DGV_ProductList.Name = "DGV_ProductList";
            this.DGV_ProductList.ReadOnly = true;
            this.DGV_ProductList.Size = new System.Drawing.Size(478, 204);
            this.DGV_ProductList.TabIndex = 1;
            this.DGV_ProductList.MultiSelectChanged += new System.EventHandler(this.DGV_ProductList_MultiSelectChanged);
            // 
            // BPC_Next
            // 
            this.BPC_Next.Location = new System.Drawing.Point(427, 305);
            this.BPC_Next.Name = "BPC_Next";
            this.BPC_Next.Size = new System.Drawing.Size(75, 23);
            this.BPC_Next.TabIndex = 2;
            this.BPC_Next.Text = "Next";
            this.BPC_Next.UseVisualStyleBackColor = true;
            this.BPC_Next.Click += new System.EventHandler(this.BPC_Next_Click);
            // 
            // ProductControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BPC_Next);
            this.Controls.Add(this.DGV_ProductList);
            this.Controls.Add(this.LProductList);
            this.Name = "ProductControl";
            this.Size = new System.Drawing.Size(545, 361);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ProductList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LProductList;
        private System.Windows.Forms.DataGridView DGV_ProductList;
        private System.Windows.Forms.Button BPC_Next;
    }
}
