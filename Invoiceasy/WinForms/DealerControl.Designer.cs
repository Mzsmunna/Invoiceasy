namespace Invoiceasy.WinForms
{
    partial class DealerControl
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
            this.LDealerList = new System.Windows.Forms.Label();
            this.DGV_DealerList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DealerList)).BeginInit();
            this.SuspendLayout();
            // 
            // LDealerList
            // 
            this.LDealerList.AutoSize = true;
            this.LDealerList.Location = new System.Drawing.Point(255, 38);
            this.LDealerList.Name = "LDealerList";
            this.LDealerList.Size = new System.Drawing.Size(79, 13);
            this.LDealerList.TabIndex = 0;
            this.LDealerList.Text = "All Dealerts List";
            // 
            // DGV_DealerList
            // 
            this.DGV_DealerList.AccessibleDescription = "All Dealers List";
            this.DGV_DealerList.AccessibleName = "DGV_DealerList";
            this.DGV_DealerList.AllowDrop = true;
            this.DGV_DealerList.AllowUserToOrderColumns = true;
            this.DGV_DealerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_DealerList.Location = new System.Drawing.Point(32, 90);
            this.DGV_DealerList.Name = "DGV_DealerList";
            this.DGV_DealerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_DealerList.Size = new System.Drawing.Size(543, 256);
            this.DGV_DealerList.TabIndex = 1;
            this.DGV_DealerList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_DealerList_CellClick);
            // 
            // DealerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGV_DealerList);
            this.Controls.Add(this.LDealerList);
            this.Name = "DealerControl";
            this.Size = new System.Drawing.Size(607, 384);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DealerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LDealerList;
        private System.Windows.Forms.DataGridView DGV_DealerList;
    }
}
