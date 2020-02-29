namespace Invoiceasy.WinForms
{
    partial class SelectDealerControl
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
            this.SDL_Title = new System.Windows.Forms.Label();
            this.DGV_SDC_Dealers = new System.Windows.Forms.DataGridView();
            this.BSDC_Next = new System.Windows.Forms.Button();
            this.LSDC_Search = new System.Windows.Forms.Label();
            this.TB_SDC_Search = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SDC_Dealers)).BeginInit();
            this.SuspendLayout();
            // 
            // SDL_Title
            // 
            this.SDL_Title.AutoSize = true;
            this.SDL_Title.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SDL_Title.Location = new System.Drawing.Point(311, 22);
            this.SDL_Title.Name = "SDL_Title";
            this.SDL_Title.Size = new System.Drawing.Size(169, 26);
            this.SDL_Title.TabIndex = 0;
            this.SDL_Title.Text = "Choose A Dealer";
            // 
            // DGV_SDC_Dealers
            // 
            this.DGV_SDC_Dealers.AllowUserToAddRows = false;
            this.DGV_SDC_Dealers.AllowUserToDeleteRows = false;
            this.DGV_SDC_Dealers.AllowUserToOrderColumns = true;
            this.DGV_SDC_Dealers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SDC_Dealers.Location = new System.Drawing.Point(14, 119);
            this.DGV_SDC_Dealers.Name = "DGV_SDC_Dealers";
            this.DGV_SDC_Dealers.ReadOnly = true;
            this.DGV_SDC_Dealers.Size = new System.Drawing.Size(735, 457);
            this.DGV_SDC_Dealers.TabIndex = 1;
            // 
            // BSDC_Next
            // 
            this.BSDC_Next.Location = new System.Drawing.Point(664, 582);
            this.BSDC_Next.Name = "BSDC_Next";
            this.BSDC_Next.Size = new System.Drawing.Size(85, 34);
            this.BSDC_Next.TabIndex = 2;
            this.BSDC_Next.Text = "Next";
            this.BSDC_Next.UseVisualStyleBackColor = true;
            this.BSDC_Next.Click += new System.EventHandler(this.BSDC_Next_Click);
            // 
            // LSDC_Search
            // 
            this.LSDC_Search.AutoSize = true;
            this.LSDC_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSDC_Search.Location = new System.Drawing.Point(11, 87);
            this.LSDC_Search.Name = "LSDC_Search";
            this.LSDC_Search.Size = new System.Drawing.Size(60, 16);
            this.LSDC_Search.TabIndex = 3;
            this.LSDC_Search.Text = "Search : ";
            // 
            // TB_SDC_Search
            // 
            this.TB_SDC_Search.Location = new System.Drawing.Point(77, 86);
            this.TB_SDC_Search.Name = "TB_SDC_Search";
            this.TB_SDC_Search.Size = new System.Drawing.Size(219, 20);
            this.TB_SDC_Search.TabIndex = 4;
            this.TB_SDC_Search.TextChanged += new System.EventHandler(this.TB_SDC_Search_TextChanged);
            // 
            // SelectDealerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TB_SDC_Search);
            this.Controls.Add(this.LSDC_Search);
            this.Controls.Add(this.BSDC_Next);
            this.Controls.Add(this.DGV_SDC_Dealers);
            this.Controls.Add(this.SDL_Title);
            this.Name = "SelectDealerControl";
            this.Size = new System.Drawing.Size(770, 630);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SDC_Dealers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SDL_Title;
        private System.Windows.Forms.DataGridView DGV_SDC_Dealers;
        private System.Windows.Forms.Button BSDC_Next;
        private System.Windows.Forms.Label LSDC_Search;
        private System.Windows.Forms.TextBox TB_SDC_Search;
    }
}
