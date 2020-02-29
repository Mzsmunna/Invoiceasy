namespace Invoiceasy.WinForms
{
    partial class SelectProductsControl
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
            this.LSP_Title = new System.Windows.Forms.Label();
            this.DGV_SPC_Products = new System.Windows.Forms.DataGridView();
            this.BSPC_Next = new System.Windows.Forms.Button();
            this.DGV_SPC_Items = new System.Windows.Forms.DataGridView();
            this.LSPC_Search = new System.Windows.Forms.Label();
            this.TB_SPC_Search = new System.Windows.Forms.TextBox();
            this.LSPC_All_Products = new System.Windows.Forms.Label();
            this.BSPC_Add = new System.Windows.Forms.Button();
            this.LSPC_Selected_Items = new System.Windows.Forms.Label();
            this.BSPC_Remove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SPC_Products)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SPC_Items)).BeginInit();
            this.SuspendLayout();
            // 
            // LSP_Title
            // 
            this.LSP_Title.AutoSize = true;
            this.LSP_Title.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSP_Title.Location = new System.Drawing.Point(214, 13);
            this.LSP_Title.Name = "LSP_Title";
            this.LSP_Title.Size = new System.Drawing.Size(253, 25);
            this.LSP_Title.TabIndex = 0;
            this.LSP_Title.Text = "Select Products For Invoice";
            // 
            // DGV_SPC_Products
            // 
            this.DGV_SPC_Products.AllowUserToAddRows = false;
            this.DGV_SPC_Products.AllowUserToDeleteRows = false;
            this.DGV_SPC_Products.AllowUserToOrderColumns = true;
            this.DGV_SPC_Products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SPC_Products.Location = new System.Drawing.Point(15, 107);
            this.DGV_SPC_Products.Name = "DGV_SPC_Products";
            this.DGV_SPC_Products.ReadOnly = true;
            this.DGV_SPC_Products.Size = new System.Drawing.Size(736, 223);
            this.DGV_SPC_Products.TabIndex = 1;
            // 
            // BSPC_Next
            // 
            this.BSPC_Next.Location = new System.Drawing.Point(676, 607);
            this.BSPC_Next.Name = "BSPC_Next";
            this.BSPC_Next.Size = new System.Drawing.Size(75, 23);
            this.BSPC_Next.TabIndex = 2;
            this.BSPC_Next.Text = "Next";
            this.BSPC_Next.UseVisualStyleBackColor = true;
            this.BSPC_Next.Click += new System.EventHandler(this.BSPC_Next_Click);
            // 
            // DGV_SPC_Items
            // 
            this.DGV_SPC_Items.AllowUserToOrderColumns = true;
            this.DGV_SPC_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SPC_Items.Location = new System.Drawing.Point(15, 365);
            this.DGV_SPC_Items.Name = "DGV_SPC_Items";
            this.DGV_SPC_Items.Size = new System.Drawing.Size(736, 235);
            this.DGV_SPC_Items.TabIndex = 3;
            this.DGV_SPC_Items.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGV_SPC_Items_CellValidating);
            this.DGV_SPC_Items.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DGV_SPC_Items_RowValidating);
            // 
            // LSPC_Search
            // 
            this.LSPC_Search.AutoSize = true;
            this.LSPC_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSPC_Search.Location = new System.Drawing.Point(12, 60);
            this.LSPC_Search.Name = "LSPC_Search";
            this.LSPC_Search.Size = new System.Drawing.Size(60, 16);
            this.LSPC_Search.TabIndex = 4;
            this.LSPC_Search.Text = "Search : ";
            // 
            // TB_SPC_Search
            // 
            this.TB_SPC_Search.Location = new System.Drawing.Point(78, 59);
            this.TB_SPC_Search.Name = "TB_SPC_Search";
            this.TB_SPC_Search.Size = new System.Drawing.Size(225, 20);
            this.TB_SPC_Search.TabIndex = 5;
            this.TB_SPC_Search.TextChanged += new System.EventHandler(this.TB_SPC_Search_TextChanged);
            // 
            // LSPC_All_Products
            // 
            this.LSPC_All_Products.AutoSize = true;
            this.LSPC_All_Products.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSPC_All_Products.Location = new System.Drawing.Point(12, 89);
            this.LSPC_All_Products.Name = "LSPC_All_Products";
            this.LSPC_All_Products.Size = new System.Drawing.Size(95, 15);
            this.LSPC_All_Products.TabIndex = 6;
            this.LSPC_All_Products.Text = "All Products : ";
            // 
            // BSPC_Add
            // 
            this.BSPC_Add.Location = new System.Drawing.Point(676, 336);
            this.BSPC_Add.Name = "BSPC_Add";
            this.BSPC_Add.Size = new System.Drawing.Size(75, 23);
            this.BSPC_Add.TabIndex = 7;
            this.BSPC_Add.Text = "Add";
            this.BSPC_Add.UseVisualStyleBackColor = true;
            this.BSPC_Add.Click += new System.EventHandler(this.BSPC_Add_Click);
            // 
            // LSPC_Selected_Items
            // 
            this.LSPC_Selected_Items.AutoSize = true;
            this.LSPC_Selected_Items.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSPC_Selected_Items.Location = new System.Drawing.Point(12, 343);
            this.LSPC_Selected_Items.Name = "LSPC_Selected_Items";
            this.LSPC_Selected_Items.Size = new System.Drawing.Size(123, 16);
            this.LSPC_Selected_Items.TabIndex = 8;
            this.LSPC_Selected_Items.Text = "Selected Items : ";
            // 
            // BSPC_Remove
            // 
            this.BSPC_Remove.Location = new System.Drawing.Point(595, 607);
            this.BSPC_Remove.Name = "BSPC_Remove";
            this.BSPC_Remove.Size = new System.Drawing.Size(75, 23);
            this.BSPC_Remove.TabIndex = 9;
            this.BSPC_Remove.Text = "Remove";
            this.BSPC_Remove.UseVisualStyleBackColor = true;
            this.BSPC_Remove.Click += new System.EventHandler(this.BSPC_Remove_Click);
            // 
            // SelectProductsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BSPC_Remove);
            this.Controls.Add(this.LSPC_Selected_Items);
            this.Controls.Add(this.BSPC_Add);
            this.Controls.Add(this.LSPC_All_Products);
            this.Controls.Add(this.TB_SPC_Search);
            this.Controls.Add(this.LSPC_Search);
            this.Controls.Add(this.DGV_SPC_Items);
            this.Controls.Add(this.BSPC_Next);
            this.Controls.Add(this.DGV_SPC_Products);
            this.Controls.Add(this.LSP_Title);
            this.Name = "SelectProductsControl";
            this.Size = new System.Drawing.Size(770, 630);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SPC_Products)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SPC_Items)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LSP_Title;
        private System.Windows.Forms.DataGridView DGV_SPC_Products;
        private System.Windows.Forms.Button BSPC_Next;
        private System.Windows.Forms.DataGridView DGV_SPC_Items;
        private System.Windows.Forms.Label LSPC_Search;
        private System.Windows.Forms.TextBox TB_SPC_Search;
        private System.Windows.Forms.Label LSPC_All_Products;
        private System.Windows.Forms.Button BSPC_Add;
        private System.Windows.Forms.Label LSPC_Selected_Items;
        private System.Windows.Forms.Button BSPC_Remove;
    }
}
