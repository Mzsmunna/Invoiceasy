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
            this.BDC_Add = new System.Windows.Forms.Button();
            this.BDC_Edit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BDC_Delete = new System.Windows.Forms.Button();
            this.LDC_Search = new System.Windows.Forms.Label();
            this.TBDC_Search = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DealerList)).BeginInit();
            this.SuspendLayout();
            // 
            // LDealerList
            // 
            this.LDealerList.AutoSize = true;
            this.LDealerList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDealerList.Location = new System.Drawing.Point(329, 19);
            this.LDealerList.Name = "LDealerList";
            this.LDealerList.Size = new System.Drawing.Size(126, 18);
            this.LDealerList.TabIndex = 0;
            this.LDealerList.Text = "All Dealerts List";
            // 
            // DGV_DealerList
            // 
            this.DGV_DealerList.AccessibleDescription = "All Dealers List";
            this.DGV_DealerList.AccessibleName = "DGV_DealerList";
            this.DGV_DealerList.AllowDrop = true;
            this.DGV_DealerList.AllowUserToAddRows = false;
            this.DGV_DealerList.AllowUserToDeleteRows = false;
            this.DGV_DealerList.AllowUserToOrderColumns = true;
            this.DGV_DealerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_DealerList.Location = new System.Drawing.Point(14, 108);
            this.DGV_DealerList.Name = "DGV_DealerList";
            this.DGV_DealerList.ReadOnly = true;
            this.DGV_DealerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_DealerList.Size = new System.Drawing.Size(742, 462);
            this.DGV_DealerList.TabIndex = 1;
            this.DGV_DealerList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_DealerList_CellClick);
            // 
            // BDC_Add
            // 
            this.BDC_Add.Location = new System.Drawing.Point(637, 576);
            this.BDC_Add.Name = "BDC_Add";
            this.BDC_Add.Size = new System.Drawing.Size(119, 40);
            this.BDC_Add.TabIndex = 2;
            this.BDC_Add.Text = "Add New Dealer";
            this.BDC_Add.UseVisualStyleBackColor = true;
            this.BDC_Add.Click += new System.EventHandler(this.BDC_Add_Click);
            // 
            // BDC_Edit
            // 
            this.BDC_Edit.Location = new System.Drawing.Point(556, 576);
            this.BDC_Edit.Name = "BDC_Edit";
            this.BDC_Edit.Size = new System.Drawing.Size(75, 40);
            this.BDC_Edit.TabIndex = 3;
            this.BDC_Edit.Text = "Edit Dealer";
            this.BDC_Edit.UseVisualStyleBackColor = true;
            this.BDC_Edit.Click += new System.EventHandler(this.BDC_Edit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-15, -15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BDC_Delete
            // 
            this.BDC_Delete.Location = new System.Drawing.Point(456, 576);
            this.BDC_Delete.Name = "BDC_Delete";
            this.BDC_Delete.Size = new System.Drawing.Size(94, 40);
            this.BDC_Delete.TabIndex = 5;
            this.BDC_Delete.Text = "Delete Dealer";
            this.BDC_Delete.UseVisualStyleBackColor = true;
            this.BDC_Delete.Click += new System.EventHandler(this.BDC_Delete_Click);
            // 
            // LDC_Search
            // 
            this.LDC_Search.AutoSize = true;
            this.LDC_Search.Location = new System.Drawing.Point(11, 85);
            this.LDC_Search.Name = "LDC_Search";
            this.LDC_Search.Size = new System.Drawing.Size(50, 13);
            this.LDC_Search.TabIndex = 6;
            this.LDC_Search.Text = "Search : ";
            // 
            // TBDC_Search
            // 
            this.TBDC_Search.Location = new System.Drawing.Point(67, 82);
            this.TBDC_Search.Name = "TBDC_Search";
            this.TBDC_Search.Size = new System.Drawing.Size(292, 20);
            this.TBDC_Search.TabIndex = 7;
            this.TBDC_Search.TextChanged += new System.EventHandler(this.TBDC_Search_TextChanged);
            // 
            // DealerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TBDC_Search);
            this.Controls.Add(this.LDC_Search);
            this.Controls.Add(this.BDC_Delete);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BDC_Edit);
            this.Controls.Add(this.BDC_Add);
            this.Controls.Add(this.DGV_DealerList);
            this.Controls.Add(this.LDealerList);
            this.Name = "DealerControl";
            this.Size = new System.Drawing.Size(770, 630);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DealerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LDealerList;
        public System.Windows.Forms.DataGridView DGV_DealerList;
        private System.Windows.Forms.Button BDC_Add;
        private System.Windows.Forms.Button BDC_Edit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BDC_Delete;
        private System.Windows.Forms.Label LDC_Search;
        private System.Windows.Forms.TextBox TBDC_Search;
    }
}
