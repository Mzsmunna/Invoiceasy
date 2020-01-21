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
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SDC_Dealers)).BeginInit();
            this.SuspendLayout();
            // 
            // SDL_Title
            // 
            this.SDL_Title.AutoSize = true;
            this.SDL_Title.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SDL_Title.Location = new System.Drawing.Point(170, 20);
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
            this.DGV_SDC_Dealers.AllowUserToResizeColumns = false;
            this.DGV_SDC_Dealers.AllowUserToResizeRows = false;
            this.DGV_SDC_Dealers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SDC_Dealers.Location = new System.Drawing.Point(25, 62);
            this.DGV_SDC_Dealers.Name = "DGV_SDC_Dealers";
            this.DGV_SDC_Dealers.Size = new System.Drawing.Size(451, 209);
            this.DGV_SDC_Dealers.TabIndex = 1;
            // 
            // BSDC_Next
            // 
            this.BSDC_Next.Location = new System.Drawing.Point(401, 287);
            this.BSDC_Next.Name = "BSDC_Next";
            this.BSDC_Next.Size = new System.Drawing.Size(75, 23);
            this.BSDC_Next.TabIndex = 2;
            this.BSDC_Next.Text = "Next";
            this.BSDC_Next.UseVisualStyleBackColor = true;
            this.BSDC_Next.Click += new System.EventHandler(this.BSDC_Next_Click);
            // 
            // SelectDealerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BSDC_Next);
            this.Controls.Add(this.DGV_SDC_Dealers);
            this.Controls.Add(this.SDL_Title);
            this.Name = "SelectDealerControl";
            this.Size = new System.Drawing.Size(507, 327);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SDC_Dealers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SDL_Title;
        private System.Windows.Forms.DataGridView DGV_SDC_Dealers;
        private System.Windows.Forms.Button BSDC_Next;
    }
}
