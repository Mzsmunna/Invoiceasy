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
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SPC_Products)).BeginInit();
            this.SuspendLayout();
            // 
            // LSP_Title
            // 
            this.LSP_Title.AutoSize = true;
            this.LSP_Title.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSP_Title.Location = new System.Drawing.Point(189, 13);
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
            this.DGV_SPC_Products.Location = new System.Drawing.Point(25, 57);
            this.DGV_SPC_Products.Name = "DGV_SPC_Products";
            this.DGV_SPC_Products.Size = new System.Drawing.Size(616, 301);
            this.DGV_SPC_Products.TabIndex = 1;
            // 
            // BSPC_Next
            // 
            this.BSPC_Next.Location = new System.Drawing.Point(566, 373);
            this.BSPC_Next.Name = "BSPC_Next";
            this.BSPC_Next.Size = new System.Drawing.Size(75, 23);
            this.BSPC_Next.TabIndex = 2;
            this.BSPC_Next.Text = "Next";
            this.BSPC_Next.UseVisualStyleBackColor = true;
            this.BSPC_Next.Click += new System.EventHandler(this.BSPC_Next_Click);
            // 
            // SelectProductsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BSPC_Next);
            this.Controls.Add(this.DGV_SPC_Products);
            this.Controls.Add(this.LSP_Title);
            this.Name = "SelectProductsControl";
            this.Size = new System.Drawing.Size(670, 407);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SPC_Products)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LSP_Title;
        private System.Windows.Forms.DataGridView DGV_SPC_Products;
        private System.Windows.Forms.Button BSPC_Next;
    }
}
