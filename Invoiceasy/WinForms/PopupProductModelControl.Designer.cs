namespace Invoiceasy.WinForms
{
    partial class PopupProductModelControl
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
            this.LPMC_Title = new System.Windows.Forms.Label();
            this.TB_PMC_Category = new System.Windows.Forms.TextBox();
            this.TB_PMC_Code = new System.Windows.Forms.TextBox();
            this.TB_PMC_Description = new System.Windows.Forms.TextBox();
            this.TB_PMC_Stock = new System.Windows.Forms.TextBox();
            this.LPMC_Category = new System.Windows.Forms.Label();
            this.LPMC_Code = new System.Windows.Forms.Label();
            this.LPMC_Description = new System.Windows.Forms.Label();
            this.LPMC_Stock = new System.Windows.Forms.Label();
            this.BPMC_AddOrUpdate = new System.Windows.Forms.Button();
            this.LPMC_UnitPrice = new System.Windows.Forms.Label();
            this.TB_PMC_UnitPrice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LPMC_Title
            // 
            this.LPMC_Title.AutoSize = true;
            this.LPMC_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPMC_Title.Location = new System.Drawing.Point(288, 19);
            this.LPMC_Title.Name = "LPMC_Title";
            this.LPMC_Title.Size = new System.Drawing.Size(157, 16);
            this.LPMC_Title.TabIndex = 0;
            this.LPMC_Title.Text = "Popup Product Modal";
            // 
            // TB_PMC_Category
            // 
            this.TB_PMC_Category.Location = new System.Drawing.Point(118, 77);
            this.TB_PMC_Category.Name = "TB_PMC_Category";
            this.TB_PMC_Category.Size = new System.Drawing.Size(516, 20);
            this.TB_PMC_Category.TabIndex = 1;
            // 
            // TB_PMC_Code
            // 
            this.TB_PMC_Code.Location = new System.Drawing.Point(118, 126);
            this.TB_PMC_Code.Name = "TB_PMC_Code";
            this.TB_PMC_Code.Size = new System.Drawing.Size(516, 20);
            this.TB_PMC_Code.TabIndex = 2;
            // 
            // TB_PMC_Description
            // 
            this.TB_PMC_Description.Location = new System.Drawing.Point(118, 173);
            this.TB_PMC_Description.Name = "TB_PMC_Description";
            this.TB_PMC_Description.Size = new System.Drawing.Size(516, 20);
            this.TB_PMC_Description.TabIndex = 3;
            // 
            // TB_PMC_Stock
            // 
            this.TB_PMC_Stock.Location = new System.Drawing.Point(118, 221);
            this.TB_PMC_Stock.Name = "TB_PMC_Stock";
            this.TB_PMC_Stock.Size = new System.Drawing.Size(516, 20);
            this.TB_PMC_Stock.TabIndex = 4;
            this.TB_PMC_Stock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_PMC_Stock_KeyPress);
            // 
            // LPMC_Category
            // 
            this.LPMC_Category.AutoSize = true;
            this.LPMC_Category.Location = new System.Drawing.Point(20, 80);
            this.LPMC_Category.Name = "LPMC_Category";
            this.LPMC_Category.Size = new System.Drawing.Size(98, 13);
            this.LPMC_Category.TabIndex = 5;
            this.LPMC_Category.Text = "Product Category : ";
            // 
            // LPMC_Code
            // 
            this.LPMC_Code.AutoSize = true;
            this.LPMC_Code.Location = new System.Drawing.Point(20, 129);
            this.LPMC_Code.Name = "LPMC_Code";
            this.LPMC_Code.Size = new System.Drawing.Size(81, 13);
            this.LPMC_Code.TabIndex = 6;
            this.LPMC_Code.Text = "Product Code : ";
            // 
            // LPMC_Description
            // 
            this.LPMC_Description.AutoSize = true;
            this.LPMC_Description.Location = new System.Drawing.Point(20, 176);
            this.LPMC_Description.Name = "LPMC_Description";
            this.LPMC_Description.Size = new System.Drawing.Size(92, 13);
            this.LPMC_Description.TabIndex = 7;
            this.LPMC_Description.Text = "Item Description : ";
            // 
            // LPMC_Stock
            // 
            this.LPMC_Stock.AutoSize = true;
            this.LPMC_Stock.Location = new System.Drawing.Point(20, 224);
            this.LPMC_Stock.Name = "LPMC_Stock";
            this.LPMC_Stock.Size = new System.Drawing.Size(90, 13);
            this.LPMC_Stock.TabIndex = 8;
            this.LPMC_Stock.Text = "Stock Available : ";
            // 
            // BPMC_AddOrUpdate
            // 
            this.BPMC_AddOrUpdate.Location = new System.Drawing.Point(540, 322);
            this.BPMC_AddOrUpdate.Name = "BPMC_AddOrUpdate";
            this.BPMC_AddOrUpdate.Size = new System.Drawing.Size(94, 23);
            this.BPMC_AddOrUpdate.TabIndex = 9;
            this.BPMC_AddOrUpdate.Text = "Add Or Update";
            this.BPMC_AddOrUpdate.UseVisualStyleBackColor = true;
            this.BPMC_AddOrUpdate.Click += new System.EventHandler(this.BPMC_AddOrUpdate_Click);
            // 
            // LPMC_UnitPrice
            // 
            this.LPMC_UnitPrice.AutoSize = true;
            this.LPMC_UnitPrice.Location = new System.Drawing.Point(20, 270);
            this.LPMC_UnitPrice.Name = "LPMC_UnitPrice";
            this.LPMC_UnitPrice.Size = new System.Drawing.Size(59, 13);
            this.LPMC_UnitPrice.TabIndex = 10;
            this.LPMC_UnitPrice.Text = "Unit Price :";
            // 
            // TB_PMC_UnitPrice
            // 
            this.TB_PMC_UnitPrice.Location = new System.Drawing.Point(118, 270);
            this.TB_PMC_UnitPrice.Name = "TB_PMC_UnitPrice";
            this.TB_PMC_UnitPrice.Size = new System.Drawing.Size(516, 20);
            this.TB_PMC_UnitPrice.TabIndex = 11;
            this.TB_PMC_UnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_PMC_UnitPrice_KeyPress);
            // 
            // PopupProductModelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TB_PMC_UnitPrice);
            this.Controls.Add(this.LPMC_UnitPrice);
            this.Controls.Add(this.BPMC_AddOrUpdate);
            this.Controls.Add(this.LPMC_Stock);
            this.Controls.Add(this.LPMC_Description);
            this.Controls.Add(this.LPMC_Code);
            this.Controls.Add(this.LPMC_Category);
            this.Controls.Add(this.TB_PMC_Stock);
            this.Controls.Add(this.TB_PMC_Description);
            this.Controls.Add(this.TB_PMC_Code);
            this.Controls.Add(this.TB_PMC_Category);
            this.Controls.Add(this.LPMC_Title);
            this.Name = "PopupProductModelControl";
            this.Size = new System.Drawing.Size(659, 366);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LPMC_Title;
        private System.Windows.Forms.TextBox TB_PMC_Category;
        private System.Windows.Forms.TextBox TB_PMC_Code;
        private System.Windows.Forms.TextBox TB_PMC_Description;
        private System.Windows.Forms.TextBox TB_PMC_Stock;
        private System.Windows.Forms.Label LPMC_Category;
        private System.Windows.Forms.Label LPMC_Code;
        private System.Windows.Forms.Label LPMC_Description;
        private System.Windows.Forms.Label LPMC_Stock;
        private System.Windows.Forms.Button BPMC_AddOrUpdate;
        private System.Windows.Forms.Label LPMC_UnitPrice;
        private System.Windows.Forms.TextBox TB_PMC_UnitPrice;
    }
}
